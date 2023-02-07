using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Service.Interfaces
{
    public interface IPostService
    {
        Task<IBaseResponse<Post>> GetOne(long id);
        Task<IBaseResponse<IEnumerable<Post>>> GetAll();
        Task<IBaseResponse<bool>> Delete(long id);
        Task<IBaseResponse<bool>> Create(Post post);
    }
}
