
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarManager carManager = InMemory();

            //CarBrandsId();

            //CarManager carManager = new CarManager(new EfCarDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());


            //var result = carManager.GetAll();


            //foreach (var car in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine("Tüm Liste Dto Buradaaa" + car.CarName + car.ColorName + car.BrandName + car.DailyPrice);
            //}

            //carManager.Add(new Car()
            //{ BrandId = 1, ColorId = 2, DailyPrice = 350, ModelYear = 2021, Description = "Urfa Edition siyah passat" }
            //);
            //carManager.Delete(new Car() { Id=1002});
            //carManager.Update(new Car() { Id = 2, Description = "Diyarbakir yolları taştan"});
            // if (result.Success==true)
            //{
            //    foreach (var item in result.Data)
            //    {
            //        Console.WriteLine(item.Id + "/" + item.CarName);
            //    }

            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental { CustomerId = 1, CarId = 2, RentDate = (new DateTime(2021, 02, 10)), ReturnDate =  default});
            Console.WriteLine(result.Message);
            
            


























        }

        private static void CarBrandsId()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine("Rengine göre filtre :\t" + car.Description);
            }
            Console.WriteLine("-------------ayrı ------------------------------");

            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car1 in carManager1.GetCarsByColorId(1).Data)
            {
                Console.WriteLine("rengine göre filtre :\t" + car1.Description);
            }

            Console.WriteLine("-----------------add --------------------------");
        }

        private static CarManager InMemory()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("tüm listeler" + car.Description);
            }

            return carManager;
        }
    }
}
