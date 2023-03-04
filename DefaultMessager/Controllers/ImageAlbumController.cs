using DefaultMessager.BLL.Implementation;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.ImageAlbumSpecification;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification;
using DefaultMessager.Domain.ViewModel.ImageAlbumModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DefaultMessager.Controllers
{
    public class ImageAlbumController : Controller
    {
        private readonly ILogger<ImageAlbumController> _logger;
        private readonly ImageAlbumService<ImageAlbum> _imageAlbumService;
        private Expression<Func<ImageAlbum, bool>>? _expression { get; set; }

        public ImageAlbumController(ILogger<ImageAlbumController> logger, ImageAlbumService<ImageAlbum> service)
        {
            _logger = logger;
            _imageAlbumService = service;
        }

        public async Task<IActionResult> ImageAlbumsWithOneOwner(Guid accountId)
        {
            _expression = new ImageAlbumByAccount<ImageAlbum>(accountId).ToExpression();

            return await ImageAlbums(0);
        }

        [HttpGet]
        public async Task<IActionResult> ImageAlbums(int? id)
        {
            var page = id ?? 0;
            var response = await _imageAlbumService.GetImageAlbum(page, StandartConst.countPostsOnOneLoad, _expression);
            if (response.StatusCode == Domain.Enums.StatusCode.ImageAlbumRead)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetPartialImageAlbums(int? id, Guid? accountId)
        {
            if (accountId != null)
            {
                _expression = new ImageAlbumByAccount<ImageAlbum>((Guid)accountId).ToExpression();
            }
            var page = id ?? 0;
            var response = await _imageAlbumService.GetImageAlbum(page, StandartConst.countPostsOnOneLoad, _expression);
            if (response.StatusCode == Domain.Enums.StatusCode.ImageAlbumRead)
            {
                return PartialView("_imageAlbums", response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize]
        public async Task<IActionResult> DeleteImageAlbumForm(Guid imageAlbumId)
        {
            return PartialView("_deleteImageAlbum",imageAlbumId);
        }

        [Authorize]
        public async Task<IActionResult> DeleteImageAlbum(Guid imageAlbumId)
        {
            var imageAlbumById =new ImageAlbumById<ImageAlbum>(imageAlbumId);
            var response =await _imageAlbumService.Delete(imageAlbumById.ToExpression());
            if (response.StatusCode == Domain.Enums.StatusCode.EntityDelete)
            {
                return await ImageAlbums(null);
            }
            return RedirectToAction("Error");
        }
    }
}
