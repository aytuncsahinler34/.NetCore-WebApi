using UserDemo.Core.DataAccess.EfCore;
using UserDemo.DataAccess.Abstract;
using UserDemo.Entities;

namespace UserDemo.DataAccess.Concrete.EfCore
{
	public class UserDal : EfEntityRepositoryBase<User, EntityContext>, IUserDal
	{
	}
}
