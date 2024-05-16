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
    public class IAppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public IAppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TAdd(AppUser entity)
        {
            _appUserDal.Add(entity);
        }

        public void TDelete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public AppUser TGetById(int id)
        {
           return _appUserDal.GetById(id);
        }

        public List<AppUser> TGetList()
        {
           return _appUserDal.GetList();
        }

        public void TUpdate(AppUser entity)
        {
           _appUserDal.Update(entity);
        }
    }
}
