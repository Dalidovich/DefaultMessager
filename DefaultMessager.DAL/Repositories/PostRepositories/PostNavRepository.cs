﻿using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using Mapster;
using System.Linq.Expressions;

namespace DefaultMessager.DAL.Repositories.PostRepositories
{
    public class PostNavRepository
    {

        private readonly MessagerDbContext _db;

        public PostNavRepository(MessagerDbContext db)
        {
            _db = db;
        }
        public IQueryable<PostIconViewModel> GetIncludePostIconViewModel(Expression<Func<PostIconViewModel, bool>>? whereExpression=null)
        {
            var content = _db.Posts.Select(c => new PostIconViewModel
            {
                Id = c.Id,
                PathPictures = c.PathPictures,
                Title = c.Title,
                SendDateTime= c.SendDateTime,
                AccountViewModel = new AccountIconViewModel()
                {
                    Id = c.Account.Id,
                    Login = c.Account.Login,
                    PathAvatar = new DescriptionPathAvatarAccountViewModel(c.Account.Description.PathAvatar)
                }
            });
            return whereExpression is null?content:content.Where(whereExpression);
        }
    }
}
