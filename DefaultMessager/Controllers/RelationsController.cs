using DefaultMessager.BLL.Implementation;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Specification.CompositeSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.RelationSpecification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaultMessager.Controllers
{
    public class RelationsController : Controller
    {
        private readonly ILogger<RelationsController> _logger;
        private readonly RelationsService<Relations> _relationService;

        public RelationsController(ILogger<RelationsController> logger, RelationsService<Relations> service)
        {
            _logger = logger;
            _relationService = service;
        }

        [Authorize]
        public async Task<IActionResult> SetCorrespondenceWith(Guid accountId)
        {
            var authId = new Guid(User.Identities.First().FindFirst(CustomClaimType.AccountId).Value);

            var relationByAuthId1 = new RelationByFromAccountId<Relations>(authId);
            var relationByAuthId2 = new RelationByToAccountId<Relations>(authId);
            var relationById1 = new RelationByFromAccountId<Relations>(accountId);
            var relationById2 = new RelationByToAccountId<Relations>(accountId);
            var orSpec1 = new OrSpecification<Relations>(relationByAuthId1, relationByAuthId2);
            var orSpec2 = new OrSpecification<Relations>(relationById1, relationById2);
            var andSpec = new AndSpecification<Relations>(orSpec1, orSpec2);
            var response=await _relationService.SetCorrespondence(andSpec.ToExpression(),authId,accountId);
            if (response.StatusCode == Domain.Enums.StatusCode.RelationCreate)
            {
                return RedirectToAction("Index", "Chatting");
            }
            return RedirectToAction("IndexById", "Account", new { id=accountId });
        }

        public async Task<string> getRelationId(Guid companionId)
        {
            var authId = new Guid(User.Identities.First().FindFirst(CustomClaimType.AccountId).Value);

            var relationByAuthId1 = new RelationByFromAccountId<Relations>(authId);
            var relationByAuthId2 = new RelationByToAccountId<Relations>(authId);
            var relationById1 = new RelationByFromAccountId<Relations>(companionId);
            var relationById2 = new RelationByToAccountId<Relations>(companionId);
            var orSpec1 = new OrSpecification<Relations>(relationByAuthId1, relationByAuthId2);
            var orSpec2 = new OrSpecification<Relations>(relationById1, relationById2);
            var andSpec = new AndSpecification<Relations>(orSpec1, orSpec2);
            var response = await _relationService.GetOne(andSpec.ToExpression());
            if (response.StatusCode == Domain.Enums.StatusCode.EntityRead)
            {
                return response.Data.Id.ToString();
            }
            return "___";
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetPartialCompanions(int? id)
        {
            var page = id ?? 0;
            var accountAuthId = new Guid(User.Identities.First().FindFirst(CustomClaimType.AccountId).Value);
            var response = await _relationService.GetListAccountIconInCorrespondence(accountAuthId,page);
            if (response.StatusCode == Domain.Enums.StatusCode.AccountRead)
            {
                if (response.Data.Count() != 0)
                {
                    return PartialView("~/Views/Chatting/_accountChatList.cshtml", response.Data);
                }
                else
                {
                    return PartialView("~/Views/_ViewImports.cshtml");
                }
            }
            return RedirectToAction("Error");
        }
    }
}
