using System.Collections.Generic;
using UserDemo.Entities;

namespace UserDemo.Business.Abstract
{
	public interface IUserService
	{
		User GetById(int id);
		List<User> GetAll();
		User Add(User entity);
		User Update(User entity);
		void Delete(int id);
	}
}
