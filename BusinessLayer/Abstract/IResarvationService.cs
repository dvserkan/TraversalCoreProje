using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IResarvationService : IGenericService<Resarvation>
    {
        List<Resarvation> GetListWithReservationByWaitAprroval(int id);
        List<Resarvation> GetListWithReservationByAccepted(int id);
        List<Resarvation> GetListWithReservationByPrevious(int id);
    }
}
