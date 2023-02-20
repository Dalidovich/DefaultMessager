using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.BLL.Implementation
{
    public class RelationsService<T> : BaseService<T>, IRelationService where T : Relations
    {
        public RelationsService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
