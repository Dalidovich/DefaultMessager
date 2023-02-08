using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Base;
using DefaultMessager.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.Service.Implementation
{
    public class CommentService<T> : BaseService<T>, ICommentService where T : Comment
    {
        public CommentService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
