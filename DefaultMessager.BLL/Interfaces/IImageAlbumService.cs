using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.ImageAlbumModel;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IImageAlbumService
    {
        public Task<BaseResponse<IEnumerable<ImageAlbum>>> GetImageAlbum(int skipCount = 0
            , int countPost = StandartConst.countPostsOnOneLoad, Expression<Func<ImageAlbum, bool>>? expression = null);
        public Task<BaseResponse<ImageAlbum>> Add(ImageAlbumCreateViewModel viewModel, Guid accountId);
        public Task<BaseResponse<IEnumerable<ImageAlbum>>> GetImageAlbum(Expression<Func<ImageAlbum, bool>> expression);
        public Task<BaseResponse<ImageAlbum>> AddPhoto(IFormFileCollection files, Guid imageAlbumId, Guid accountId, string login);
        public Task<BaseResponse<bool>> DeleteWithId(Guid imageAlbumId);
        public Task<BaseResponse<Guid>> DeletePhoto(Guid imageAlbumId,string photoId);
    }
}
