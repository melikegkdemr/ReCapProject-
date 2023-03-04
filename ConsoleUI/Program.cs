using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //CarAdd();

            //ColorAdd();

            //ColorTest();

            // UserTest();

            //carDetailsDtosDeneme();

            //UserAdd();

            RentalManager rentalManager = new RentalManager(new EntityFrameworkRentalDal());
            Rental rental = new Rental() { CarId = 1 , CustomerId = 2, RentDate = new DateTime(2023, 02, 21) };
            rentalManager.Add(rental);
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EntityFrameworkUserDal());

            User user = new User() { FirstName = "İlayda", LastName = "Cetin", Email = "ilayda@gmail.com", Password = "12345" };
            userManager.Add(user);
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EntityFrameworkUserDal());

            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        private static void carDetailsDtosDeneme()
        {
            CarManager carManager = new CarManager(new EntityFrameworkCarDal());

            var result = carManager.carDetailDtos();

            if (result.IsSuccess == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + "---> " + car.ColorName + "---> " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EntityFrameworkColorDal());

            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void ColorAdd()
        {
            Color color = new Color { Name = "Blue" };
            EntityFrameworkColorDal entityFrameworkColorDal = new EntityFrameworkColorDal();
            entityFrameworkColorDal.Add(color);
        }

        private static void CarAdd()
        {
            Car car1 = new Car { BrandId = 1, ColorId = 2, DailyPrice = 500, ModelYear = 2018, Description = "Hasarsız boyasız araç" };

            EntityFrameworkCarDal efObject = new EntityFrameworkCarDal();
            efObject.Add(car1);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EntityFrameworkCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
