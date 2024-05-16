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
    public class ICommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public ICommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment entity)
        {
            _commentDal.Add(entity);
        }

        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public Comment TGetById(int id)
        {
           return _commentDal.GetById(id);
        }

        public List<Comment> TGetList()
        {
           return _commentDal.GetList();
        }

        public void TUpdate(Comment entity)
        {
           _commentDal.Update(entity);
        }

        public List<Comment> TGetDestinationById(int id)
        {
            return _commentDal.GetListByFilter(x=> x.DestinationID == id);
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> TGetListCommentWithDestinationAndUser(int id)
        {
            return _commentDal.GetListCommentWithDestinationAndUser(id);
        }
    }
}
