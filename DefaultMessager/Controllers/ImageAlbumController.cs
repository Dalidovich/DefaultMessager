using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DefaultMessager.Controllers
{
    public class ImageAlbumController : Controller
    {
        private readonly ILogger<ImageAlbumController> _logger;
        private readonly ImageAlbumService<ImageAlbum> _imageAlbumService;

        public ImageAlbumController(ILogger<ImageAlbumController> logger, ImageAlbumService<ImageAlbum> service)
        {
            _logger = logger;
            _imageAlbumService = service;
        }
    }
}
