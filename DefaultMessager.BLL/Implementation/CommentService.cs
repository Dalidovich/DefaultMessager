using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories.CommentRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.CommentModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Implementation
{
    public class CommentService<T> : BaseService<T>, ICommentService where T : Comment
    {
        private CommentNavRepositories _navCommentRepository;

        public CommentService(IBaseRepository<T> repository, ILogger<T> logger,CommentNavRepositories commentNavRepositories) : base(repository, logger)
        {
            _navCommentRepository = commentNavRepositories;
        }
        public async Task<BaseResponse<IEnumerable<Comment>>> GetFullComments(int skipCount = 0, Expression<Func<Comment, bool>>? whereExpression = null, int countComments = StandartConst.countCommentsOnOneLoad)
        {
            try
            {
                var contents = await _navCommentRepository.GetCommentFullInclude(whereExpression).OrderBy(x => x.DatePublicate)
                    .Skip(skipCount * countComments).Take(countComments).ToListAsync();
                if (contents == null)
                {
                    return new StandartResponse<IEnumerable<Comment>>()
                    {
                        Description = "comments not found"
                    };
                }
                return new StandartResponse<IEnumerable<Comment>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.CommentRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetCommentView] : {ex.Message}");
                return new StandartResponse<IEnumerable<Comment>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
