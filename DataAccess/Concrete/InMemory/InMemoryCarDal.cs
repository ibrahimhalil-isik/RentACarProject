using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { BrandId = 1, ColorId = 1, DailyPrice = 50000, ModelYear = 2010, Description = "Dizel" },
                new Car { BrandId = 2, ColorId = 2, DailyPrice = 150000, ModelYear = 2015, Description = "Dizel" },
                new Car { BrandId = 1, ColorId = 2, DailyPrice = 200000, ModelYear = 2021, Description = "Elektrikli" },
                new Car { BrandId = 3, ColorId = 1, DailyPrice = 100000, ModelYear = 2010, Description = "Benzin" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car carUpdate)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == carUpdate.CarId);
            carToUpdate.BrandId = carUpdate.BrandId;
            carToUpdate.ColorId = carUpdate.ColorId;
            carToUpdate.DailyPrice = carUpdate.DailyPrice;
            carToUpdate.Description = carUpdate.Description;
        }
    }
}

