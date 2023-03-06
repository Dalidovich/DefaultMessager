using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Interfaces
{
    public interface ICommentService
    {
        public Task<BaseResponse<IEnumerable<Comment>>> GetFullComments(int skipCount = 0
            , Expression<Func<Comment, bool>>? whereExpression = null, int countComments = StandartConst.countCommentsOnOneLoad);
    }
}
