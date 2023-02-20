using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.BLL.Implementation
{
    public class DescriptionAccountService<T> : BaseService<T>, IDescriptionAccountService where T : DescriptionAccount
    {
        public DescriptionAccountService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
