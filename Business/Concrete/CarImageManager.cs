using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImage;

        public CarImageManager(ICarImageDal carImage)
        {
            _carImage = carImage;
        }
        [SecuredOperation("CarImage.Add,admin")]
        public IResult Add(CarImage carImage)
        {

            var Result = BusinessRules.Run(ResimKontrol(carImage.CarId));
            if (Result==null)
            {
                _carImage.Add(ResimYoksa(carImage).Data);
                return new SuccessResult();
            }
            return new ErrorResult();
          
        }
        [SecuredOperation("CarImage.Delete,admin")]
        public IResult Delete(CarImage carImage)
        {
            _carImage.Delete(carImage);
            return new SuccessResult();
        }
        [SecuredOperation("CarImage.List,admin")]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImage.GetAll());
        }

        [SecuredOperation("CarImage.GetById,admin")]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImage.Get(Image=>Image.Id==id));
        }
        [SecuredOperation("CarImage.Update,admin")]
        public IResult Update(CarImage carImage)
        {
            _carImage.Update(carImage);
            return new SuccessResult();
        }

        private IResult ResimKontrol(int CarID)
        {
            var CarimageCount = _carImage.GetAll(i=>i.CarId==CarID).Count;
            if (CarimageCount<5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ArabaResmi5Adet);

        }

        private IDataResult<CarImage> ResimYoksa(CarImage carImage)
        {
            if (carImage.ImagePath=="" || carImage.ImagePath==null)
            {
                CarImage image = new CarImage();

                image.CarId = carImage.CarId;
                image.Date = carImage.Date;
                image.Id = carImage.Id;
                image.ImagePath = "bos";

                return new ErrorDataResult<CarImage>(image);

            }
            return new SuccessDataResult<CarImage>(carImage);
        }
    }
}
