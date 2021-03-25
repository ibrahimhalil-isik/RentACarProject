using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Entities.Concrete.Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Entities.Concrete.Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Entities.Concrete.Color>> GetAll()
        {
            return new SuccessDataResult<List<Entities.Concrete.Color>>(_colorDal.GetAll(),"Sonradan bi mesaj ayarlayacam inşallah");
        }

        public IDataResult<List<Entities.Concrete.Color>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Entities.Concrete.Color>>(_colorDal.GetAll(p => p.ColorId == colorId));
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Entities.Concrete.Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}
