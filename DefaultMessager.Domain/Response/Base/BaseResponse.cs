using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.Response.Base
{
    public abstract class BaseResponse<T>
    {
        public virtual T Data { get; set; }
        public virtual StatusCode StatusCode { get; set; }
        public virtual string Description { get; set; }
    }
}
