using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;
using DefaultMessager.Domain.ViewModel.ImageAlbumModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using DefaultMessager.Domain.ViewModel.RelationModel;
using Mapster;
using System.Linq.Expressions;

namespace DefaultMessager.DAL.Repositories.AccountRepositores
{
    public class AccountNavRepository
    {

        private readonly MessagerDbContext _db;

        public AccountNavRepository(MessagerDbContext db)
        {
            _db = db;
        }
        public IQueryable<AccountAuthenticateViewModel> GetIncludeDescribeAndRefreshToken(Expression<Func<AccountAuthenticateViewModel, bool>> whereExpression)
        {
            return _db.Accounts.ProjectToType<AccountAuthenticateViewModel>().Where(whereExpression);
        }
        public IQueryable<AccountProfileViewModel> GetProfiles(Expression<Func<AccountProfileViewModel, bool>>? whereExpression = null)
        {
            var content = _db.Accounts.Select(c => new AccountProfileViewModel()
            {
                Id = c.Id,
                Email = c.Email,
                Login = c.Login,
                CreateDate = c.CreateDate,
                Description = new DescriptionAccountViewModel(c.Description),
                Posts = new List<PostIconViewModel>(c.Posts.Select(c2 => new PostIconViewModel()
                {
                    Id = c2.Id,
                    PathPictures = c2.PathPictures,
                    Title = c2.Title,
                    SendDateTime = c2.SendDateTime,
                    AccountViewModel = new AccountIconViewModel()
                    {
                        Id = c2.Account.Id,
                        Login = c2.Account.Login,
                        PathAvatar = new DescriptionPathAvatarAccountViewModel(c2.Account.Description.PathAvatar)
                    }
                }).OrderBy(x => x.SendDateTime).Take(2).ToList()),
                RelationsFrom = new List<RelationViewModel>(c.RelationsTo.Select(c2 => new RelationViewModel()
                {
                    AccountId1 = c2.AccountId1,
                    AccountId2 = c2.AccountId2,
                    Status = c2.Status,
                })),
                ImageAlbums = new List<ImageAlbumViewModel>(c.ImageAlbum.Select(c2 => new ImageAlbumViewModel()
                {
                    Id = c2.Id,
                    PathPictures = c2.PathPictures,
                    Title = c2.Title
                }).Take(2).ToList()),
            });
            return whereExpression is null ? content : content.Where(whereExpression);
        }
    }
}
