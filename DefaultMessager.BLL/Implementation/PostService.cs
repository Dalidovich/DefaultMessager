using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.BackblazeS3.ClientProvider;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories.PostRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification;
using DefaultMessager.Domain.ViewModel.PostModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Implementation
{
    public class PostService<T> : BaseService<T>, IPostService where T : Post
    {
        private readonly PostNavRepository _navPostRepository;
        private readonly IBackblazeClientProvider _BackblazeClientProvider;
        private readonly AccountService<Account> _accountService;
        public PostService(IBaseRepository<T> repository, ILogger<T> logger, PostNavRepository navPostRepository
            ,IBackblazeClientProvider backblazeClientProvider, AccountService<Account> accountService) : base(repository, logger)
        {
            _navPostRepository = navPostRepository;
            _BackblazeClientProvider= backblazeClientProvider;
            _accountService= accountService;
        }

        public async Task<BaseResponse<IEnumerable<PostIconViewModel>>> GetPostIcons(int skipCount = 0, int countPost = StandartConst.countPostsOnOneLoad
            , Expression<Func<PostIconViewModel, bool>>? expression = null)
        {
            try
            {

                IEnumerable<PostIconViewModel> contents;
                if (expression != null)
                {
                    contents = await _navPostRepository.GetIncludePostIconViewModel().OrderBy(x => x.SendDateTime)
                    .Where(expression).Skip(skipCount * countPost).Take(countPost).ToListAsync();
                }
                else
                {
                    contents = await _navPostRepository.GetIncludePostIconViewModel().OrderBy(x => x.SendDateTime)
                    .Skip(skipCount * countPost).Take(countPost).ToListAsync();
                }
                    
                if (contents == null)
                {
                    return new StandartResponse<IEnumerable<PostIconViewModel>>()
                    {
                        Description = "post not found"
                    };
                }
                return new StandartResponse<IEnumerable<PostIconViewModel>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.PostRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetIncludePostIconViewModel] : {ex.Message}");
                return new StandartResponse<IEnumerable<PostIconViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<Post>>> GetFullPosts(Expression<Func<Post, bool>>? whereExpression)
        {
            try
            {
                var contents = await _navPostRepository.getFullPosts(whereExpression).ToListAsync();
                if (contents == null)
                {
                    return new StandartResponse<IEnumerable<Post>>()
                    {
                        Description = "post not found"
                    };
                }
                return new StandartResponse<IEnumerable<Post>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.PostRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetFullPosts] : {ex.Message}");
                return new StandartResponse<IEnumerable<Post>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<Post>> Add(PostCreateViewModel entity, IFormFileCollection imgPath
            , IFormFileCollection? audioPath,Guid accountId,string login)
        {
            try
            {
                var client=await _BackblazeClientProvider.GetClient();
                var bucketName=_accountService.GetAccountBucket(login);
                Post post=new Post(entity,accountId);
                string[] filePath=new string[imgPath.Count];
                post = (await Add((T)post)).Data;
                string startUploadPath = $"{login}/{TypeSaveContent.posts}/{post.Title}{post.Id}/";
                try
                {
                    for (int i = 0; i < imgPath.Count; i++)
                    {
                        MemoryStream memoryStreams = new MemoryStream();
                        await imgPath[i].CopyToAsync(memoryStreams);
                        var fileId = await client.UploadObjectFromStreamAsync(bucketName.Data, $"{post.Id}{imgPath[i].Name}"
                            , memoryStreams, login
                            , $"{startUploadPath}{DateTime.Now.Ticks}{imgPath[i].Name}");
                        filePath[i] = client.GetFileLink(fileId);
                    }
                }
                catch (Exception ex)
                {
                    await Delete(x=>x.Id==post.Id);
                    return new StandartResponse<Post>()
                    {
                        Description = ex.Message,
                        StatusCode = StatusCode.FileUploadFailed,
                    };
                }
                post.PathPictures= filePath;
                post = (await Update((T)post)).Data;
                return new StandartResponse<Post>()
                {
                    Data = post,
                    StatusCode = StatusCode.PostCreate,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Add Post] : {ex.Message}");
                return new StandartResponse<Post>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
