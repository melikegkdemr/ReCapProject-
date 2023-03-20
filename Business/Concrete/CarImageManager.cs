using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }


        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfCarImageExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi.");
        }

        public IResult Delete(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            _fileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(result);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            var result = _carImageDal.GetAll(x => x.CarId == id);
            if (result.Count == 0)
            {
                var carImage = new List<CarImage>();
                carImage.Add(new CarImage { ImagePath = PathConstants.DefaultImagesPath });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageExceeded);
            }
            return new SuccessResult();
        }
    }
}
