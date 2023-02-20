using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.BLL.Implementation
{
    public class RefreshTokenService<T> : BaseService<T>, IRefreshTokenService where T : RefreshToken
    {
        public RefreshTokenService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
