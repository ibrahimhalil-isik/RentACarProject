using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}




//using Business.Abstract;
//using Business.ValidationRules.FluentValidation;
//using Core.Aspects.Autofac.Validation;
//using Core.Entities.Concrete;
//using Core.Utilities.Results.Abstract;
//using Core.Utilities.Results.Concrete;
//using DataAccess.Abstract;
//using System.Collections.Generic;

//namespace Business.Concrete
//{
//    public class UserManager : IUserService
//    {
//        IUserDal _userDal;

//        public UserManager(IUserDal userDal)
//        {
//            _userDal = userDal;
//        }

//[ValidationAspect(typeof(UserValidator))]
//public IResult Add(User user)
//{
//    _userDal.Add(user);
//    return new SuccessResult("mesajını sonra ekleyecem inşAllah");
//}

//        public IResult Delete(User user)
//        {
//            _userDal.Delete(user);
//            return new SuccessResult();
//        }

//        public IDataResult<List<User>> GetAll()
//        {
//            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Mesajı daha sonra ayarlayacam");
//        }

//        public IDataResult<User> GetById(int userId)
//        {
//            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
//        }

//        public IDataResult<User> GetByMail(string email)
//        {
//            return new SuccessDataResult<User>(_userDal.Get(p => p.Email == email));
//        }

//        public List<OperationClaim> GetClaims(User user)
//        {
//            return _userDal.GetClaims(user);
//        }

//        [ValidationAspect(typeof(UserValidator))]
//        public IResult Update(User user)
//        {
//            _userDal.Update(user);
//            return new SuccessResult();
//        }
//    }
//}
