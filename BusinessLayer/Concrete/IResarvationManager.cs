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
    public class IResarvationManager : IResarvationService
    {
        private readonly IResarvationDal _resarvationDal;

        public IResarvationManager(IResarvationDal resarvationDal)
        {
            _resarvationDal = resarvationDal;
        }

        public List<Resarvation> GetListWithReservationByAccepted(int id)
        {
            return _resarvationDal.GetListWithReservationByAccepted(id);
        }

        public List<Resarvation> GetListWithReservationByPrevious(int id)
        {
            return _resarvationDal.GetListWithReservationByPrevious(id);
        }

        public List<Resarvation> GetListWithReservationByWaitAprroval(int id)
        {
            return _resarvationDal.GetListWithReservationByWaitAprroval(id);
        }

        public void TAdd(Resarvation entity)
        {
            _resarvationDal.Add(entity);
        }

        public void TDelete(Resarvation entity)
        {
            _resarvationDal.Delete(entity);
        }

        public Resarvation TGetById(int id)
        {
            return _resarvationDal.GetById(id);
        }

        public List<Resarvation> TGetList()
        {
            return _resarvationDal.GetList();
        }

        public void TUpdate(Resarvation entity)
        {
           _resarvationDal.Update(entity);
        }
    }
}
