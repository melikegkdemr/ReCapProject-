using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

//(ATTENITON)

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;


        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpGet("getimagebycarid")]
        public IActionResult GetImageByCarId(int carId)
        {
            var result = _carImageService.GetImageByCarId(carId);
            if (result.IsSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpPost("update")]

        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]

        public IActionResult Add([FromForm]CarImage carImage,[FromForm]IFormFile file)
        {
            var result = _carImageService.Add(carImage,file);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //(ATTENITON)

        [HttpGet("delete")]

        public IActionResult Delete(int id)
        {
            var result = _carImageService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
