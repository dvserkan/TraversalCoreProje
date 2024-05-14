using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class IAboutManager : IAboutService
	{
		private readonly IAboutDal _aboutDal;

		public IAboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public void TAdd(About entity)
		{
			_aboutDal.Add(entity);
		}

		public void TDelete(About entity)
		{
			_aboutDal.Delete(entity);
		}

		public About TGetById(int id)
		{
			return _aboutDal.GetById(id);
		}

		public List<About> TGetList()
		{
			return _aboutDal.GetList();
		}

		public void TUpdate(About entity)
		{
			_aboutDal.Update(entity);
		}
	}
}
