using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.DependencyResolvers.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entitiy.Concrete;
using Entitiy.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;

        }
        [SecuredOperation("Car.Add,admin")]

        [ValidationAspect(typeof(CarValidator))]
        public IResult add(Car car)
        {

          
                _CarDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }
        [SecuredOperation("Car.Delete,admin")]
        public IResult Delete(Car car)
        {
            _CarDal.Delete(car);
            return new SuccessResult(Messages.ProductDelted);
        }
        [SecuredOperation("Car.List,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll());
        }
        [SecuredOperation("Car.GetById,admin")]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_CarDal.Get(b => b.Id == id));
        }
        [SecuredOperation("Car.List,admin")]
        public IDataResult<List<CarDetails>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetails>>(_CarDal.GetCarDetails());
        }
        [SecuredOperation("Car.Update,admin")]
        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
