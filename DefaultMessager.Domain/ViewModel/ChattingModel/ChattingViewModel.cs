using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.MessageModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.ChattingModel
{
    public class ChattingViewModel
    {
        public List<AccountIconViewModel> AccountIconInCorrespondenceViewsModels { get; set; }=new List<AccountIconViewModel>();
        public List<MessageViewModel> MessageOfCurrentCorrespondenceViewModels { get; set; } = new List<MessageViewModel>();
        public AccountIconViewModel? Companion { get; set; }
    }
}
