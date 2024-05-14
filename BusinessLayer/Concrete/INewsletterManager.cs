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
	public class INewsletterManager : INewsletterService
	{
		private readonly INewsletterDal _newsletterDal;

		public INewsletterManager(INewsletterDal newsletterDal)
		{
			_newsletterDal = newsletterDal;
		}

		public void TAdd(Newsletter entity)
		{
			_newsletterDal.Add(entity);
		}

		public void TDelete(Newsletter entity)
		{
			_newsletterDal.Delete(entity);
		}

		public Newsletter TGetById(int id)
		{
			return _newsletterDal.GetById(id);
		}

		public List<Newsletter> TGetList()
		{
			return _newsletterDal.GetList();
		}

		public void TUpdate(Newsletter entity)
		{
			_newsletterDal.Update(entity);
		}
	}
}
