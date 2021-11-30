using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Autofac;
using Core.CrossCuttingConcerns.Validation;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {


            _carDal.Add(car);
            return new SuccessResult("okumuş musun");
        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==13)
            {
                return new ErrorDataResult<List<Car>>("Saat 13 bakımda");
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"işlem başarılı");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour==18)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdating);
            }
            return new ErrorResult("Güncelleme başarısız");
            
           
        }
    }
}
