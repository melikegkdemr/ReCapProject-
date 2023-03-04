using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car {Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 2000, Description = "Sahibinden temiz", ModelYear = 2010 }, 
                new Car {Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 5000, Description = "Öğretmenden", ModelYear = 2018  },
                new Car { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 15000, Description = "Doktordan", ModelYear = 2020 }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car removedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(removedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault(c => c.Id == Id);
        }

        public void Update(Car car)
        {
            Car updateCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updateCar.BrandId = car.BrandId;
            updateCar.ColorId = car.ColorId;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.Description = car.Description;    
            updateCar.ModelYear = car.ModelYear;


        }
    }
}
