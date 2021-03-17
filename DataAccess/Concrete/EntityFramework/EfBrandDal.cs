using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EfBrandDal : IBrandDal
    {
        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null
                   ? context.Set<Car>().ToList()
                   : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
