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
	public class ISubAboutManager : ISubAboutService
	{
		private readonly ISubAboutDal _subAboutDal;

		public ISubAboutManager(ISubAboutDal subAboutDal)
		{
			_subAboutDal = subAboutDal;
		}

		public void TAdd(SubAbout entity)
		{
			_subAboutDal.Add(entity);
		}

		public void TDelete(SubAbout entity)
		{
			_subAboutDal.Delete(entity);
		}

		public SubAbout TGetById(int id)
		{
			return _subAboutDal.GetById(id);
		}

		public List<SubAbout> TGetList()
		{
			return _subAboutDal.GetList();
		}

		public void TUpdate(SubAbout entity)
		{
			_subAboutDal.Update(entity);
		}
	}
}
