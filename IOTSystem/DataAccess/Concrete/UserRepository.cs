using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;

namespace IOTSystem.DataAccess.Concrete
{
    internal class UserRepository : EntityRepositoryBase<User, IOTContext>, IUserRepository
    {
    }
}
