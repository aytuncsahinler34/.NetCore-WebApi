using UserDemo.Core.DataAccess;
using UserDemo.Entities;

namespace UserDemo.DataAccess.Abstract
{
	public interface IUserDal : IBaseRepository<User>
	{
	}
}
