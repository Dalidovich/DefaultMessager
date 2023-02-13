using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.EntityTranslator;
using DefaultMessager.Domain.ViewModel.PostModel;
using DefaultMessager.Service.Base;
using DefaultMessager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Service.Implementation
{
    public class PostService<T> : BaseService<T>, IPostService where T : Post
    {
        private readonly IBaseRepository<Account> _accountRepository;
        public PostService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
        
        public async Task<IBaseResponse<IEnumerable<PostIconViewModel>>> GetAllPostIconRandom()
        {
            try
            {
                Random rnd = new Random();
                var contents = _repository.GetAll().PostListToPostIconViewList();                
                //contents = (IQueryable<PostIconView>)contents.OrderBy(n => rnd.Next()).ToList();
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
