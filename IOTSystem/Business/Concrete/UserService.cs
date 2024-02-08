using IOTSystem.Business.Abstract;
using IOTSystem.Business.Dto;
using IOTSystem.DataAccess;
using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;
using IOTSystem.Helpers;
using IOTSystem.IoC;
using System;

namespace IOTSystem.Business.Concrete
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = InstanceFactory.GetInstance<IUserRepository>(new DataAccessModule());
        }

        public User Login(UserLogin user)
        {
            if (user.Username.Length < 3 || user.Password.Length < 5)
                throw new Exception(Messages.LoginFailed);

            var data = _userRepository.Get(u => u.Username == user.Username) ?? throw new Exception(Messages.LoginFailed);

            var hashResult = HashingHelper.VerifyHash(data.Password, user.Password);

            if(!hashResult)
                throw new Exception(Messages.LoginFailed);

            return data;
        }

        public User Register(UserRegister user)
        {
            if (user.Username.Length < 3 || user.Password.Length < 5)
                throw new Exception(Messages.RegisterFailed);

            var data = new User
            {
                Username = user.Username,
                Password = HashingHelper.GetHash(user.Password)
            };

            _userRepository.Add(data);

            return data;
        }
    }
}
