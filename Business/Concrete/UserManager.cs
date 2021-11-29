﻿using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new Result(true);  
            
            
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new Result(true);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new Result(true);
        }
    }
}