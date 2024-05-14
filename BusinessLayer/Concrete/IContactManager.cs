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
	public class IContactManager : IContactService
	{
		private readonly IContactDal _contactDal;

		public IContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void TAdd(Contact entity)
		{
			_contactDal.Add(entity);
		}

		public void TDelete(Contact entity)
		{
			_contactDal.Delete(entity);
		}

		public Contact TGetById(int id)
		{
			return _contactDal.GetById(id);
		}

		public List<Contact> TGetList()
		{
			return _contactDal.GetList();
		}

		public void TUpdate(Contact entity)
		{
			_contactDal.Update(entity);
		}
	}
}
