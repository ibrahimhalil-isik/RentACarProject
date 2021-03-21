using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        //List<RentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
