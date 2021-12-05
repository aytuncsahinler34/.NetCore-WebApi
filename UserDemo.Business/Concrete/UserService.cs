using System.Collections.Generic;
using System.Linq;
using UserDemo.Business.Abstract;
using UserDemo.DataAccess.Abstract;
using UserDemo.Entities;

namespace UserDemo.Business.Concrete
{
	public class UserService : IUserService
	{
		private IUserDal _userDal;
		
		public UserService(IUserDal userDal) {
			_userDal = userDal;
		}

		public User GetById(int id) {
			return _userDal.GetById(id);
		}

		public List<User> GetAll() {
			return _userDal.GetAll().ToList();
		}

		public User Add(User entity) {
			return _userDal.Add(entity);
		}

		public void Delete(int id) {
			_userDal.Delete(id);
		}

		public User Update(User entity) {
			return _userDal.Update(entity);
		}
	}
}
