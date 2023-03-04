using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.BackblazeS3.ClientProvider;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories.ImageAlbums;
using DefaultMessager.DAL.Repositories.PostRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.PostModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Implementation
{
    public class ImageAlbumService<T> : BaseService<T>, IImageAlbumService where T : ImageAlbum
    {
        private readonly ImageAlbumNavRepository _navImageAlbumRepository;
        private readonly IBackblazeClientProvider _BackblazeClientProvider;
        private readonly AccountService<Account> _accountService;
        public ImageAlbumService(IBaseRepository<T> repository, ILogger<T> logger, ImageAlbumNavRepository imageAlbumNavRepository) : base(repository, logger)
        {
            _navImageAlbumRepository = imageAlbumNavRepository;
        }
        public async Task<BaseResponse<IEnumerable<ImageAlbum>>> GetImageAlbum(int skipCount = 0, int countPost = StandartConst.countPostsOnOneLoad
            , Expression<Func<ImageAlbum, bool>>? expression = null)
        {
            try
            {

                IEnumerable<ImageAlbum> contents;
                if (expression != null)
                {
                    contents = await _navImageAlbumRepository.GetImageAlbumFullInclude().OrderBy(x => x.Title)
                    .Where(expression).Skip(skipCount * countPost).Take(countPost).ToListAsync();
                }
                else
                {
                    contents = await _navImageAlbumRepository.GetImageAlbumFullInclude().OrderBy(x => x.Title)
                    .Skip(skipCount * countPost).Take(countPost).ToListAsync();
                }

                if (contents == null)
                {
                    return new StandartResponse<IEnumerable<ImageAlbum>>()
                    {
                        Description = "image album not found"
                    };
                }
                return new StandartResponse<IEnumerable<ImageAlbum>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.ImageAlbumRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetImageAlbum] : {ex.Message}");
                return new StandartResponse<IEnumerable<ImageAlbum>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
