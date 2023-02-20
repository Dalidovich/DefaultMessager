using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories.AccountRepositores;
using DefaultMessager.DAL.Repositories.PostRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.PostModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.BLL.Implementation
{
    public class PostService<T> : BaseService<T>, IPostService where T : Post
    {
        private readonly PostNavRepository _navPostRepository;
        public PostService(IBaseRepository<T> repository, ILogger<T> logger, PostNavRepository navPostRepository) : base(repository, logger)
        {
            _navPostRepository = navPostRepository;
        }

        public async Task<IBaseResponse<IEnumerable<PostIconViewModel>>> GetAllPostIconRandom()
        {
            try
            {
                Random rnd = new Random();
                var contents = _navPostRepository.GetIncludePostIconViewModel();
                if (contents == null)
                {
                    return new BaseResponse<IEnumerable<PostIconViewModel>>()
                    {
                        Description = "post not found"
                    };
                }
                return new BaseResponse<IEnumerable<PostIconViewModel>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.PostRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetAllRandom] : {ex.Message}");
                return new BaseResponse<IEnumerable<PostIconViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
