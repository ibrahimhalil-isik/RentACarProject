using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
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

        //[ValidationAspect(typeof(CarImageValidator))]
        //[SecuredOperation("carimage.add,admin")]       
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage,IFormFile formFile)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId)
                /*,CheckIfImageExtensionValid(formFile)*/);
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        //[SecuredOperation("carimage.add,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            carImage.ImagePath = FileHelper.Update(Environment.CurrentDirectory + @"\wwwroot\" + 
                            _carImageDal.Get(c => c.CarImageId == carImage.CarImageId).ImagePath, formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);           
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(Environment.CurrentDirectory + @"\wwwroot\" + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);           
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarImageListed);
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfAnyCarImageExists(carId));
        }        


        private IResult CheckIfImageLimit(int carId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageAddingLimit);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfAnyCarImageExists(int carId)
        {
            string path = @"\images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return _carImageDal.GetAll(p => p.CarId == carId);
            }

            return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now } };
        }


        [TransactionScopeAspect]
        public IResult TransactionalOperation(CarImage carImage, IFormFile file)
        {
            Add(carImage, file);
            Update(carImage, file);

            return new SuccessResult(Messages.CarImageUpdated);
        }


        //private IResult CheckIfImageExists(int id)
        //{
        //    if (_carImageDal.IsExist(id))
        //    {
        //        return new SuccessResult();
        //    }

        //    return new ErrorResult(Messages.PictureNotFound);
        //}


        //private IResult CheckIfImageExtensionValid(IFormFile file)
        //{
        //    bool isValidFileExtension = Messages.ValidImageFileTypes.Any(i => i == Path.GetExtension(file.FileName).ToUpper());
        //    if (!isValidFileExtension)
        //    {
        //        return new ErrorResult(Messages.IncorrectFileExtension);
        //    }

        //    return new SuccessResult();

        //}
    }
}
