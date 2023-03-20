using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using DefaultMessager.Domain.ViewModel.RelationModel;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DefaultMessager.DAL.Repositories.RelationsRepositories
{
    public class RelationsNavRepository
    {

        private readonly MessagerDbContext _db;

        public RelationsNavRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public IQueryable<RelationsViewModel> GetRelationViewModel(Expression<Func<RelationsViewModel, bool>> expression)
        {
            return _db.Relations.ProjectToType<RelationsViewModel>().Where(expression);
        }
        public IQueryable<AccountIconViewModel>? GetAccountIconsForCorrespondenceWith(Guid authId)
        {
            var contentFrom = _db.Relations.Join(_db.Accounts
                , r => r.AccountId1
                , a => a.Id,
                (r, a) => new
                {
                    Id = a.Id,
                    Login = a.Login,
                    PathAvatar = a.Description.PathAvatar,
                    id2 = r.AccountId2
                }).Where(x => x.id2 == authId);

            var contentTo = _db.Relations.Join(_db.Accounts
                , r => r.AccountId2
                , a => a.Id,
                (r, a) => new
                {
                    Id = a.Id,
                    Login = a.Login,
                    PathAvatar = a.Description.PathAvatar,
                    id2 = r.AccountId1
                }).Where(x => x.id2 == authId);
            var result = contentFrom.Union(contentTo).Select(a => new AccountIconViewModel()
            {
                Id = a.Id,
                Login = a.Login,
                PathAvatar = new DescriptionPathAvatarAccountViewModel(a.PathAvatar),
            });
            return result;
        }
    }
}
