using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification;
using DefaultMessager.BLL.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DefaultMessager.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly PostService<Post> _postService;

        public PostController(ILogger<PostController> logger, PostService<Post> service)
        {
            _logger = logger;
            _postService = service;
        }
        public async Task<IActionResult> RandomPostIcons()
        {
            var response = await _postService.GetAllPostIconRandom();
            if (response.StatusCode == Domain.Enums.StatusCode.PostRead)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<ActionResult> FullPost(Guid postId)
        {
            var postById = new PostById<Post>(postId);
            var response = await _postService.GetOne(postById.ToExpression());
            if (response.StatusCode == Domain.Enums.StatusCode.EntityRead)
            {
                return PartialView(response.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
