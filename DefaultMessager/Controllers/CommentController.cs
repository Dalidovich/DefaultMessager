using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.CommentSpecification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetPartialComments(int? id, Guid postId)
        {
            var page = id ?? 0;
            CommentByPostId<Comment> commentByPost = new CommentByPostId<Comment>(postId);
            var response = await _commentService.GetFullComments(page, commentByPost.ToExpression());
            if (response.StatusCode == Domain.Enums.StatusCode.CommentRead)
            {
                return PartialView("_comments", response.Data);
            }
            return RedirectToAction("Error");
        }
        [Authorize]
        public async Task<IActionResult> SendComment(Guid postId, string commentContent)
        {
            string? id = Request.Cookies[CookieNames.AccountId];
            if (id != null && commentContent != "")
            {
                var createResponse = await _commentService.Add(new Comment(postId, new Guid(id), commentContent));
                if (createResponse.StatusCode == Domain.Enums.StatusCode.EntityCreate)
                {
                    var commentById = new CommentById<Comment>((Guid)createResponse.Data.Id);
                    var response = await _commentService.GetFullComments(0, commentById.ToExpression());
                    if (response.StatusCode == Domain.Enums.StatusCode.CommentRead)
                    {
                        return PartialView("_comments", response.Data);
                    }
                }
            }
            return RedirectToAction("Error");
        }
    }
}
