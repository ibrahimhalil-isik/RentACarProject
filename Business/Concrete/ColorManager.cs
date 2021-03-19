using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void Add(Entities.Concrete.Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(Entities.Concrete.Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Entities.Concrete.Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Entities.Concrete.Color> GetCarsByColorId(int colorId)
        {
            return _colorDal.GetAll(p => p.ColorId == colorId);
        }

        public void Update(Entities.Concrete.Color color)
        {
            _colorDal.Update(color);
        }
    }
}
