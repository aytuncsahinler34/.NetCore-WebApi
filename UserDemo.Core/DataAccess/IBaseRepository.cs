using UserDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UserDemo.Core.DataAccess
{
	public interface IBaseRepository<T> where T : class, IEntity, new()
	{
		T GetById(int id);
		T Get(Expression<Func<T, bool>> filter = null);
		List<T> GetAll(Expression<Func<T, bool>> filter = null);
		T Add(T entity);
		T Update(T entity);
		void Delete(int id);
	}
}
