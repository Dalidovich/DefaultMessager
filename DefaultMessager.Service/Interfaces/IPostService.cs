using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.PostModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Service.Interfaces
{
    public interface IPostService
    {
        Task<IBaseResponse<IEnumerable<PostIconViewModel>>> GetAllPostIconRandom();
    }
}
