using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfResarvationDal : GenericRepository<Resarvation>, IResarvationDal
    {
        public EfResarvationDal(Context context) : base(context)
        {
        }

        public List<Resarvation> GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Resarvations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();
            }
        }

        public List<Resarvation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Resarvations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            }
        }

        public List<Resarvation> GetListWithReservationByWaitAprroval(int id)
        {
            using (var context = new Context())
            {
                return context.Resarvations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId == id).ToList();
            }
        }
    }
}
