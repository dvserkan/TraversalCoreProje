using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            Context c = new Context();
            var user = c.Users.FirstOrDefault(x => x.Id == p.AppUserId);

            if (user != null)
            {
                // Kullanıcının adını ve soyadını birleştirir
                p.CommentUser = user.Name + " " + user.Surname;
            }
            p.CommentDate = DateTime.Now;
            p.CommentState = true;

            _commentService.TAdd(p);
            return Redirect($"/Destination/DestinationDetails/{p.DestinationID}");

        }
    }
}
