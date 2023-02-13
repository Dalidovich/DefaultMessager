using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Base;
using DefaultMessager.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.Service.Implementation
{
    public class RelationsService<T> : BaseService<T>, IRelationService where T : Relations
    {
        public RelationsService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
