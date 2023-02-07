using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Service.Implementation
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;
        private readonly ILogger<Post> _logger;

        public PostService(IPostRepository codeRepository, ILogger<Post> logger)
        {
            _postRepository = codeRepository;
            _logger = logger;
        }

        public async Task<IBaseResponse<bool>> Create(Post post)
        {
            try
            {
                return new BaseResponse<bool>()
                {
                    Data = await _postRepository.createAsync(post),
                    StatusCode = StatusCode.PostCreate,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Create] : {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(long id)
        {
            try
            {
                var code = await _postRepository.GetAll().FirstOrDefaultAsync(x => x.PostId == id);
                if (code == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "post not found"
                    };
                }

                return new BaseResponse<bool>()
                {
                    Data = await _postRepository.deleteAsync(code),
                    StatusCode = StatusCode.PostDelete
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Delete] : {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Post>>> GetAll()
        {
            try
            {
                var contents = await _postRepository.GetAll().ToListAsync();
                if (contents == null)
                {
                    return new BaseResponse<IEnumerable<Post>>()
                    {
                        Description = "post not found"
                    };
                }
                return new BaseResponse<IEnumerable<Post>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.PostRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetAll] : {ex.Message}");
                return new BaseResponse<IEnumerable<Post>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<Post>> GetOne(long id)
        {
            try
            {
                var code = await _postRepository.GetAll().FirstOrDefaultAsync(x => x.PostId == id);
                if (code == null)
                {
                    return new BaseResponse<Post>()
                    {
                        Description = "code not found"
                    };
                }
                return new BaseResponse<Post>()
                {
                    Data = code,
                    StatusCode = StatusCode.PostRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetOne] : {ex.Message}");
                return new BaseResponse<Post>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
