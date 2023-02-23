using Microsoft.AspNetCore.Mvc;
using DefaultMessager.Domain.Entities;
using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILogger<LikeController> _logger;
        private readonly LikeService<Like> _likeAlbumService;

        public LikeController(ILogger<LikeController> logger, LikeService<Like> service)
        {
            _logger = logger;
            _likeAlbumService = service;
        }
    }
}
