using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories.AccountRepositores;
using DefaultMessager.DAL.Repositories.RelationsRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.Specification.CompositeSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.RelationSpecification;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.MessageModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Implementation
{
    public class RelationsService<T> : BaseService<T>, IRelationService where T : Relations
    {
        private readonly RelationsNavRepository _relationsNavRepository;
        public RelationsService(IBaseRepository<T> repository, ILogger<T> logger, RelationsNavRepository relationsNavRepository) : base(repository, logger)
        {
            _relationsNavRepository = relationsNavRepository;
        }
        public async Task<BaseResponse<Guid>> SetCorrespondence(Expression<Func<T, bool>> expression,Guid accountAuthId,Guid accountId)
        {
            try
            {
                var response = await GetOne(expression);
                if (response.Data != null)
                {
                    return new StandartResponse<Guid>()
                    {
                        Description="this relation already exist"
                    };
                }
                return new StandartResponse<Guid>()
                {
                    Data = (Guid)(await Add((T)
                        new Relations(accountAuthId, accountId, StatusRelation.InCorrespondence))).Data.Id,
                    StatusCode = StatusCode.RelationCreate
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[SetCorrespondence] : {ex.Message}");
                return new StandartResponse<Guid>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<AccountIconViewModel>>> GetListAccountIconInCorrespondence(Guid authorizedAccountId
            , int skipCount = 0, Expression<Func<AccountIconViewModel, bool>>? expression = null
            , int countPost = StandartConst.countCompanionsOnOneLoad)
        {
            try
            {
                IEnumerable<AccountIconViewModel>? contents;
                try
                {
                    if (expression != null)
                    {
                        contents = await _relationsNavRepository.GetAccountIconsForCorrespondenceWith(authorizedAccountId).OrderBy(x => x.Login)
                        .Where(expression).Skip(skipCount * countPost).Take(countPost).ToListAsync();
                    }
                    else
                    {
                        contents = await _relationsNavRepository.GetAccountIconsForCorrespondenceWith(authorizedAccountId).OrderBy(x => x.Login)
                        .Skip(skipCount * countPost).Take(countPost).ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    return new StandartResponse<IEnumerable<AccountIconViewModel>>()
                    {
                        Description = "account not found",
                        Data = new List<AccountIconViewModel>()
                    };
                }
                return new StandartResponse<IEnumerable<AccountIconViewModel>>()
                {
                    Data = contents,
                    StatusCode = StatusCode.AccountRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetListAccountIconInCorrespondence] : {ex.Message}");
                return new StandartResponse<IEnumerable<AccountIconViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
