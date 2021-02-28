using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entitiy.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CarImagesController : ControllerBase
    {

        ICarImageService _carImageService;
        public static IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]


        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]

        public IActionResult Add([FromForm] imgUpluoad file)
        {
            CarImage carImage  = JsonConvert.DeserializeObject<CarImage>(file.CarImages);

            if (file.files != null)
            {

                if (file.files.Length > 0)
                {
                    string guid = Guid.NewGuid().ToString("N");
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\" + guid;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + file.files.FileName))
                    {
                        file.files.CopyTo(fileStream);
                        fileStream.Flush();

                    }

                    carImage.ImagePath = guid;
                } 
            }
         

            var result = _carImageService.Add(carImage);

            if (result.Success)
           {
               return Ok(result);
           }
           return BadRequest(result);

        }

       
    }
    public class imgUpluoad
    {
        public IFormFile files { get; set; }
        public string CarImages { get; set; }
    }

}