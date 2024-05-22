using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents._Comment
{
    public class _CommentList : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = context.Comments.Where(x => x.DestinationID == id).Count();
			var values = _commentService.TGetListCommentWithDestinationAndUser(id);
			return View(values);
        }
    }
}
