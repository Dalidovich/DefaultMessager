using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Domain.ViewModel.PostModel
{
    public class PostIconView
    {
        public Guid? Id { get; set; }
        public Guid AccountId { get; set; }
        public string? Title { get; set; }
        public string[]? PathPictures { get; set; }
        public string PathAvatar { get; set; }
        public string Login { get; set; }
        public PostIconView(Guid? id, Guid accountId, string? title, string[]? pathPictures)
        {
            Id = id;
            AccountId = accountId;
            Title = title;
            PathPictures = pathPictures;
        }
    }
}
