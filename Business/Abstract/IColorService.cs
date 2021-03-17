using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        List<Color> GetCarsByColorId(int colorId);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
