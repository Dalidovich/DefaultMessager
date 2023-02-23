using Microsoft.AspNetCore.Mvc;
using DefaultMessager.Domain.Entities;
using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Controllers
{
    public class RelationsController : Controller
    {
        private readonly ILogger<RelationsController> _logger;
        private readonly RelationsService<Relations> _relationAlbumService;

        public RelationsController(ILogger<RelationsController> logger, RelationsService<Relations> service)
        {
            _logger = logger;
            _relationAlbumService = service;
        }
    }
}
