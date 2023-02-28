using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IDescriptionAccountService
    {
        public Task<BaseResponse<bool>> updateAvatarPath(string login, MemoryStream content);
    }
}
