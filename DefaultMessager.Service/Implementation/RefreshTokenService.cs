using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Base;
using DefaultMessager.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.Service.Implementation
{
    public class RefreshTokenService<T> : BaseService<T>, IRefreshTokenService where T : RefreshToken
    {
        public RefreshTokenService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
