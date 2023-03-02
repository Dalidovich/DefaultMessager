using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Base
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        protected readonly IBaseRepository<T> _repository;
        protected readonly ILogger<T> _logger;

        public BaseService(IBaseRepository<T> repository, ILogger<T> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<BaseResponse<T>> Add(T entity)
        {
            try
            {
                return new StandartResponse<T>()
                {
                    Data = await _repository.AddAsync(entity),
                    StatusCode = StatusCode.EntityCreate,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Create] : {ex.Message}");
                return new StandartResponse<T>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<bool>> Delete(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await _repository.GetAll().SingleOrDefaultAsync(expression);
                if (entity == null)
                {
                    return new StandartResponse<bool>()
                    {
                        Description = "entity not found"
                    };
                }

                return new StandartResponse<bool>()
                {
                    Data = await _repository.DeleteAsync(entity),
                    StatusCode = StatusCode.EntityDelete
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Delete] : {ex.Message}");
                return new StandartResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<T>>> GetAll()
        {
            try
            {
                var contents = await _repository.GetAll().ToListAsync();
                if (contents == null)
                {
                    return new StandartResponse<IEnumerable<T>>()
                    {
                        Description = "entity not found"
                    };
                }
                return new StandartResponse<IEnumerable<T>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.EntityRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetAll] : {ex.Message}");
                return new StandartResponse<IEnumerable<T>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<T>> GetOne(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await _repository.GetAll().SingleOrDefaultAsync(expression);
                if (entity == null)
                {
                    return new StandartResponse<T>()
                    {
                        Description = "entity not found"
                    };
                }
                return new StandartResponse<T>()
                {
                    Data = entity,
                    StatusCode = StatusCode.EntityRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetOne] : {ex.Message}");
                return new StandartResponse<T>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<T>>> GetAllSatisfactory(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entites = await _repository.GetAll().Where(expression).ToListAsync();
                if (entites == null)
                {
                    return new StandartResponse<IEnumerable<T>>()
                    {
                        Description = "satisfactory entity not found"
                    };
                }
                return new StandartResponse<IEnumerable<T>>()
                {
                    Data = entites,
                    StatusCode = StatusCode.EntityRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetAllSatisfactory] : {ex.Message}");
                return new StandartResponse<IEnumerable<T>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<T>> Update(T entity)
        {
            try
            {
                return new StandartResponse<T>()
                {
                    Data = await _repository.updateAsync(entity),
                    StatusCode = StatusCode.EntityUpdate,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Create] : {ex.Message}");
                return new StandartResponse<T>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
