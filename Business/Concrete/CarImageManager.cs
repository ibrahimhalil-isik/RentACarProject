using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;        

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage,IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId),
                CheckIfImageExtensionValid(formFile));
            if (result != null)
            {
                return result;
            }

            var result2 = CarImagesFileHelper.Add(formFile);
            carImage.ImagePath = result2;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(carImage.CarImageId));
            if (result != null)
            {
                return result;
            }
            string path = GetById(carImage.CarImageId).Data.ImagePath;
            CarImagesFileHelper.Delete(path);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), "Mesajı daha sonra ayarlayacam");
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = carId, ImagePath = "default.jpg" });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == id));
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId),
               CheckIfImageExtensionValid(formFile));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            string OldPath = GetById(carImage.CarImageId).Data.ImagePath;
            _carImageDal.Update(carImage);
            return new SuccessResult();

        }

        private IResult CheckIfImageLimit(int carId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }

            return new SuccessResult();
        }

        private IResult CheckIfImageExists(int id)
        {
            if (_carImageDal.IsExist(id))
            {
                return new SuccessResult();
            }
               
            return new ErrorResult("Silinecek resim yok");
        }


        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(i => i == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
            {
                return new ErrorResult(Messages.IncorrectFileExtension);
            }
                
            return new SuccessResult();

        }
       
    }
}
