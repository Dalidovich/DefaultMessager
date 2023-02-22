using Microsoft.AspNetCore.Mvc;
using DefaultMessager.Domain.Entities;
using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.CommentSpecification;

namespace DefaultMessager.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly CommentService<Comment> _commentService;

        public CommentController(ILogger<CommentController> logger, CommentService<Comment> service)
        {
            _logger = logger;
            _commentService = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetPartialComments(int? id,Guid postId)
        {
            var page = id ?? 0;
            CommentByPostId<Comment> commentByPost = new CommentByPostId<Comment>(postId);
            var response = await _commentService.GetFullComments(page,commentByPost.ToExpression());
            if (response.StatusCode == Domain.Enums.StatusCode.CommentRead)
            {
                var a= PartialView("_comments", response.Data);
                return a;
            }
            return RedirectToAction("Error");
        }
    }
}
