using IOTSystem.Business.Dto;
using IOTSystem.Entities.Concrete;

namespace IOTSystem.Business.Abstract
{
    internal interface IUserService
    {
        User Register(UserRegister user);

        User Login(UserLogin user);
    }
}
