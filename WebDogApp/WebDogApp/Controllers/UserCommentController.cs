using Microsoft.AspNetCore.Mvc;

using WebDogApp.Core.Contacts;
using WebDogApp.Models.UserComment;

namespace WebDogApp.Controllers
{
    public class UserCommentController : Controller
    {
        private readonly IUserCommentService _commentService;

        public UserCommentController(IUserCommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: UserCommentController
        public IActionResult Index()
        {
            List<UserCommentIndexVM> comments = _commentService.GetAllComments()
                .Select(c => new UserCommentIndexVM
                {
                    Id = c.Id,
                    UserName = c.UserName,
                    Email = c.Email,
                    Comment = c.Comment
                })
                .ToList();

            return View(comments);
        }

        // GET: UserCommentController/Create
        public IActionResult Create()
        {
            return View(new UserCommentCreateVM());
        }

        // POST: UserCommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] UserCommentCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var created = _commentService.Create(model.UserName, model.Email, model.Comment);
                if (created)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }
    }
}
