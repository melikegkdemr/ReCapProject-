using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImageByCarId(int id);
        IResult Add(CarImage carImage,IFormFile file);
        IResult Update(CarImage carImage);
        IResult Delete(int id);
      
    }
}
