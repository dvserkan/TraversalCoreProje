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
	public class IContactUsManager : IContactUsService
	{
		private readonly IContactUsDal _contactUsDal;

		public IContactUsManager(IContactUsDal contactUsDal)
		{
			_contactUsDal = contactUsDal;
		}

		public void TAdd(ContactUs entity)
		{
			_contactUsDal.Add(entity);
		}

		public void TContactUsStatusChangeToFalse(int id)
		{
			throw new NotImplementedException();
		}

		public void TDelete(ContactUs entity)
		{
			_contactUsDal.Delete(entity);
		}

		public ContactUs TGetById(int id)
		{
			return _contactUsDal.GetById(id);
		}

		public List<ContactUs> TGetList()
		{
			return _contactUsDal.GetList();
		}

		public List<ContactUs> TGetListContactUsByFalse()
		{
			return _contactUsDal.GetListContactUsByFalse();
		}

		public List<ContactUs> TGetListContactUsByTrue()
		{
			return _contactUsDal.GetListContactUsByTrue();
		}

		public void TUpdate(ContactUs entity)
		{
			_contactUsDal.Update(entity);
		}
	}
}
