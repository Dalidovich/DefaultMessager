using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.BackblazeS3.ClientProvider;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories.ImageAlbums;
using DefaultMessager.DAL.Repositories.PostRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.ImageAlbumSpecification;
using DefaultMessager.Domain.ViewModel.ImageAlbumModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Implementation
{
    public class ImageAlbumService<T> : BaseService<T>, IImageAlbumService where T : ImageAlbum
    {
        private readonly ImageAlbumNavRepository _navImageAlbumRepository;
        private readonly IBackblazeClientProvider _BackblazeClientProvider;
        private readonly AccountService<Account> _accountService;

        public ImageAlbumService(IBaseRepository<T> repository, ILogger<T> logger, ImageAlbumNavRepository imageAlbumNavRepository
            ,IBackblazeClientProvider backblazeClientProvider,AccountService<Account> accountService) : base(repository, logger)
        {
            _navImageAlbumRepository = imageAlbumNavRepository;
            _accountService= accountService;
            _BackblazeClientProvider= backblazeClientProvider;
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

        public async Task<BaseResponse<ImageAlbum>> Add(ImageAlbumCreateViewModel viewModel, Guid accountId)
        {
            try
            {
                ImageAlbum imageAlbum = new ImageAlbum(viewModel,accountId);
                return new StandartResponse<ImageAlbum>()
                {
                    Data = (await Add((T)imageAlbum)).Data,
                    StatusCode = StatusCode.ImageAlbumCreate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Add ImageAlbum] : {ex.Message}");
                return new StandartResponse<ImageAlbum>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        public async Task<BaseResponse<IEnumerable<ImageAlbum>>> GetImageAlbum(Expression<Func<ImageAlbum, bool>> expression)
        {
            try
            {
                var contents = await _navImageAlbumRepository.GetImageAlbumFullInclude().Where(expression).ToListAsync();
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
        public async Task<BaseResponse<ImageAlbum>> AddPhoto(IFormFileCollection files, Guid imageAlbumId, Guid accountId, string login)
        {
            try
            {
                var imageAlbumResponse=await GetImageAlbum(x=>x.Id==imageAlbumId);
                if (imageAlbumResponse.StatusCode == StatusCode.ImageAlbumRead)
                {
                    var imageAlbum=imageAlbumResponse.Data.First();
                    var client = await _BackblazeClientProvider.GetClient();
                    var bucketName = _accountService.GetAccountBucket(login);
                    string[] filePath = imageAlbum.PathPictures;
                    Array.Resize<string>(ref filePath, imageAlbum.PathPictures.Length + files.Count);
                    string startUploadPath = 
                        $"{login}/{TypeSaveContent.imageAlbums}/{imageAlbum.Title}{imageAlbum.Id}/";
                    try
                    {
                        for (int i = imageAlbum.PathPictures.Length; i < filePath.Length; i++)
                        {
                            MemoryStream memoryStreams = new MemoryStream();
                            await files[i - imageAlbum.PathPictures.Length].CopyToAsync(memoryStreams);
                            var fileId = await client.UploadObjectFromStreamAsync(bucketName.Data
                                , $"{imageAlbum.Id}{files[i - imageAlbum.PathPictures.Length].FileName}"
                                , memoryStreams, login
                                , $"{startUploadPath}{DateTime.Now.Ticks}{files[i - imageAlbum.PathPictures.Length].FileName}");
                            filePath[i] = client.GetFileLink(fileId);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"[Add Photo in ImageAlbum upload] : {ex.Message}");
                        return new StandartResponse<ImageAlbum>()
                        {
                            Description = ex.Message,
                            StatusCode = StatusCode.FileUploadFailed,
                        };
                    }
                    imageAlbum.PathPictures = filePath;
                    imageAlbum = (await Update((T)imageAlbum)).Data;
                    return new StandartResponse<ImageAlbum>()
                    {
                        Data = imageAlbum,
                        StatusCode = StatusCode.FileUpload,
                    };
                }
                return new StandartResponse<ImageAlbum>()
                {
                    Description = imageAlbumResponse.Description
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Add Photo in ImageAlbum] : {ex.Message}");
                return new StandartResponse<ImageAlbum>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<bool>> DeleteWithId(Guid imageAlbumId)
        {
            try
            {
                var imageAlbumById=new ImageAlbumById<ImageAlbum>(imageAlbumId);
                var entity = (await GetImageAlbum(imageAlbumById.ToExpression())).Data.SingleOrDefault();
                if (entity == null)
                {
                    return new StandartResponse<bool>()
                    {
                        Description = "image album not found"
                    };
                }
                var bucketName = _accountService.GetAccountBucket(entity.Account.Login).Data;
                var imageAlbumPath = $"{entity.Account.Login}/{TypeSaveContent.imageAlbums}/{entity.Title}{entity.Id}";
                var client = await _BackblazeClientProvider.GetClient();
                return new StandartResponse<bool>()
                {
                    Data = (await client.DeleteInFolderAsync(bucketName, imageAlbumPath)&await _repository.DeleteAsync((T)entity)),
                    StatusCode = StatusCode.ImageAlbumDelete
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[DeleteWithId] : {ex.Message}");
                return new StandartResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<Guid>> DeletePhoto(Guid imageAlbumId, string photoId)
        {
            try
            {
                var imageAlbumById = new ImageAlbumById<ImageAlbum>(imageAlbumId);
                var entity = (await GetImageAlbum(imageAlbumById.ToExpression())).Data.SingleOrDefault();
                if (entity == null)
                {
                    return new StandartResponse<Guid>()
                    {
                        Description = "image album not found"
                    };
                }
                List<string> links= entity.PathPictures.ToList();
                links.Remove(photoId);
                entity.PathPictures=links.ToArray();
                photoId = photoId.Substring(StandartConst.DounloadUrlApi.Length);
                var client = await _BackblazeClientProvider.GetClient();
                var bucketName = _accountService.GetAccountBucket(entity.Account.Login).Data;
                var deleteResponse = await client.DeleteObjectAsyncById(bucketName, photoId);
                return new StandartResponse<Guid>()
                {
                    Data= ((Guid)(await Update((T)entity)).Data.Id),
                    StatusCode=StatusCode.PhotoDelete
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[DeleteWithId] : {ex.Message}");
                return new StandartResponse<Guid>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
