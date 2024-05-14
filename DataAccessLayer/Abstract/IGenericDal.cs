using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		void Delete(T entity);
		void Add(T entity);
		void Update(T entity);
		List<T> GetList();
		T GetById(int id);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}
