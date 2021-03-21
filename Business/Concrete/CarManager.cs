using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            else if (car.DailyPrice < 1)
            {
                return new ErrorResult(Messages.ProductNameInvalid2);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), "buraya bir massage ekleyecez");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {          
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
