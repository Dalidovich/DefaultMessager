using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Service.Base
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        private readonly IBaseRepository<T> _repository;
        private readonly ILogger<T> _logger;

        public BaseService(IBaseRepository<T> repository, ILogger<T> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IBaseResponse<bool>> Create(T entity)
        {
            try
            {
                return new BaseResponse<bool>()
                {
                    Data = await _repository.createAsync(entity),
                    StatusCode = StatusCode.EntityCreate,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Create] : {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(Expression<Func<T, bool>> expression)
        {
            try
            {
                var code = await _repository.GetAll().FirstOrDefaultAsync(expression);
                if (code == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "entity not found"
                    };
                }

                return new BaseResponse<bool>()
                {
                    Data = await _repository.deleteAsync(code),
                    StatusCode = StatusCode.EntityDelete
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Delete] : {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<T>>> GetAll()
        {
            try
            {
                var contents = await _repository.GetAll().ToListAsync();
                if (contents == null)
                {
                    return new BaseResponse<IEnumerable<T>>()
                    {
                        Description = "entity not found"
                    };
                }
                return new BaseResponse<IEnumerable<T>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.EntityRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetAll] : {ex.Message}");
                return new BaseResponse<IEnumerable<T>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<T>> GetOne(Expression<Func<T, bool>> expression)
        {
            try
            {
                var code = await _repository.GetAll().FirstOrDefaultAsync(expression);
                if (code == null)
                {
                    return new BaseResponse<T>()
                    {
                        Description = "entity not found"
                    };
                }
                return new BaseResponse<T>()
                {
                    Data = code,
                    StatusCode = StatusCode.EntityRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetOne] : {ex.Message}");
                return new BaseResponse<T>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
