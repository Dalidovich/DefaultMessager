using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.ChattingModel;
using DefaultMessager.Domain.ViewModel.MessageModel;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IChattingService 
    {
        public Task<BaseResponse<ChattingViewModel>> GetChattingViewModel(Guid accountId);
    }
}
