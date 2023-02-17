using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.BLL.Implementation
{
    public class LikeService<T> : BaseService<T>, ILikeService where T : Like
    {
        public LikeService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
