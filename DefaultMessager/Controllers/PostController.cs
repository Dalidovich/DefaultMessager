using DefaultMessager.BLL.Implementation;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DefaultMessager.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly PostService<Post> _postService;
        private Expression<Func<PostIconViewModel, bool>>? _expression { get; set; }

        public PostController(ILogger<PostController> logger, PostService<Post> service)
        {
            _logger = logger;
            _postService = service;
        }

        public async Task<IActionResult> PostsIconsWithOneOwner(Guid accountId)
        {
            _expression = new PostIconViewModelByCreaterId<PostIconViewModel>(accountId).ToExpression();
            return await PostIcons(0);
        }

        [HttpGet]
        public async Task<IActionResult> PostIcons(int? id)
        {
            var page = id ?? 0;
            var response = await _postService.GetPostIcons(page,StandartConst.countPostsOnOneLoad, _expression);
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
            var response = await _postService.GetPostIcons(page, StandartConst.countPostsOnOneLoad, _expression);
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CreatePost()=> PartialView("_createPost");

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost(PostCreateViewModel postCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                IFormFileCollection files = Request.Form.Files;
                var responce = await _postService
                    .Add(postCreateViewModel, postCreateViewModel.FormFiles,null
                    ,new Guid(User.Identities.First().FindFirst(CustomClaimType.AccountId).Value),User.Identity.Name);
                if (responce.StatusCode == Domain.Enums.StatusCode.PostCreate)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", responce.Description);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
