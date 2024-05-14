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
	public class IAbout2Manager : IAbout2Service
	{
		private readonly IAbout2Dal _about2Dal;

		public IAbout2Manager(IAbout2Dal about2Dal)
		{
			_about2Dal = about2Dal;
		}

		public void TAdd(About2 entity)
		{
			_about2Dal.Add(entity);
		}

		public void TDelete(About2 entity)
		{
			_about2Dal.Delete(entity);
		}

		public About2 TGetById(int id)
		{
			return _about2Dal.GetById(id);
		}

		public List<About2> TGetList()
		{
			return _about2Dal.GetList();
		}

		public void TUpdate(About2 entity)
		{
			_about2Dal.Update(entity);
		}
	}
}
