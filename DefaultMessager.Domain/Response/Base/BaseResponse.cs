using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.Response.Base
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; } = null!;
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
