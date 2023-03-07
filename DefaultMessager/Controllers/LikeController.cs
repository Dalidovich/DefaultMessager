using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Specification.CompositeSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.LikeSpecification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaultMessager.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILogger<LikeController> _logger;
        private readonly LikeService<Like> _likeService;

        public LikeController(ILogger<LikeController> logger, LikeService<Like> service)
        {
            _logger = logger;
            _likeService = service;
        }

        private async Task<IActionResult> _createLike(Guid postId, Guid accountId, LikeByPostId<Like> likeByPost)
        {
            var createtResponce = await _likeService.Add(new Like(postId, accountId));
            if (createtResponce.StatusCode == Domain.Enums.StatusCode.EntityCreate)
            {
                var response = await _likeService.GetAllSatisfactory(likeByPost.ToExpression());
                if (response.StatusCode == Domain.Enums.StatusCode.EntityRead)
                {
                    return PartialView("_likeCount", (response.Data, true));
                }
            }
            return RedirectToAction("Error");
        }

        private async Task<IActionResult> _deleteLike(Guid postId, AndSpecification<Like> andSpec, LikeByPostId<Like> likeByPost)
        {
            var deleteResponce = await _likeService.Delete(andSpec.ToExpression());
            if (deleteResponce.StatusCode == Domain.Enums.StatusCode.EntityDelete)
            {
                var response = await _likeService.GetAllSatisfactory(likeByPost.ToExpression());
                if (response.StatusCode == Domain.Enums.StatusCode.EntityRead)
                {
                    return PartialView("_likeCount", (response.Data, false));
                }
            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> GetLikes(Guid postId)
        {
            var likeByPost = new LikeByPostId<Like>(postId);
            string? id = Request.Cookies[CookieNames.AccountId];
            if (id != null)
            {
                var accountId = new Guid(id);
                var likeByAccount = new LikeByAccountId<Like>(accountId);
                var andSpec = new AndSpecification<Like>(likeByAccount, likeByPost);
                var responseOnPost = await _likeService.GetAllSatisfactory(likeByPost.ToExpression());
                var responseExistMyLike = await _likeService.GetOne(andSpec.ToExpression());
                return PartialView("_likeCount", (responseOnPost.Data, responseExistMyLike.StatusCode == Domain.Enums.StatusCode.EntityRead));
            }
            return RedirectToAction("Error");
        }

        [Authorize]
        public async Task<IActionResult> ManipulateLikeOnPost(Guid postId)
        {
            string? id = Request.Cookies[CookieNames.AccountId];
            if (id != null)
            {
                var accountId = new Guid(id);
                var likeByPost = new LikeByPostId<Like>(postId);
                var likeByAccount = new LikeByAccountId<Like>(accountId);
                var andSpec = new AndSpecification<Like>(likeByAccount, likeByPost);
                var responseExistMyLike = await _likeService.GetOne(andSpec.ToExpression());
                if (responseExistMyLike.StatusCode == Domain.Enums.StatusCode.EntityNotFound)
                {
                    return await _createLike(postId, accountId, likeByPost);
                }
                else if (responseExistMyLike.StatusCode == Domain.Enums.StatusCode.EntityRead)
                {
                    return await _deleteLike(postId, andSpec, likeByPost);
                }
            }
            return RedirectToAction("Error");
        }
    }
}
