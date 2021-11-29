using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice= 500, ModelYear= 1994, Description="1994 yılında çıkarılmış yepyeni toyata"},
                new Car{Id=2, BrandId=1, ColorId=2, DailyPrice= 5000, ModelYear= 2006, Description="2006 mavi toyota"},
                new Car{Id=3, BrandId=3, ColorId=4, DailyPrice= 4000, ModelYear= 2009, Description="2009 kırmızı bmw"},
                new Car{Id=4, BrandId=2, ColorId=3, DailyPrice= 47855, ModelYear= 218, Description="218 kodlu polo"},
                new Car{Id=5, BrandId=5, ColorId=1, DailyPrice= 98562, ModelYear= 1999, Description="qaskaii kıpkırmızı"}
            };   
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(p => p.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(p => p.Id == Id).ToList();
            
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
