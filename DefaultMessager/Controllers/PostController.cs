using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification;
using Microsoft.AspNetCore.Mvc;

namespace DefaultMessager.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly PostService<Post> _postService;

        public PostController(ILogger<PostController> logger, PostService<Post> service, PostService<Post> navPostService)
        {
            _logger = logger;
            _postService = service;
        }
        public async Task<IActionResult> PostIcons(int? id)
        {
            var page = id ?? 0;
            var response = await _postService.GetPostIcons(page);
            if (response.StatusCode == Domain.Enums.StatusCode.PostRead)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<ActionResult> GetPartialPostIcons(int? id)
        {
            var page = id ?? 0;
            var response = await _postService.GetPostIcons(page);
            if (response.StatusCode == Domain.Enums.StatusCode.PostRead)
            {
                return PartialView("_posts", response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<ActionResult> FullPost(Guid postId)
        {
            var postById = new PostById<Post>(postId);
            var response = await _postService.GetFullPosts(postById.ToExpression());
            if (response.StatusCode == Domain.Enums.StatusCode.PostRead)
            {
                return PartialView(response.Data.First());
            }
            return RedirectToAction("Error");
        }
    }
}
