using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.BLL.Implementation
{
    public class CommentService<T> : BaseService<T>, ICommentService where T : Comment
    {
        public CommentService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
