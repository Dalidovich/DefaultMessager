using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Base;
using DefaultMessager.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.Service.Implementation
{
    public class RelationService<T> : BaseService<T>, IPostService where T : Relations
    {
        public RelationService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
