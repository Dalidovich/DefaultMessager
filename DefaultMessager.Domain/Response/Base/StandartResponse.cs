using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.Response.Base
{
    public class StandartResponse<T> : BaseResponse<T>
    {
        public override string Description { get; set; } = null!;
        public override StatusCode StatusCode { get; set; }
        public override T Data { get; set; }
    }
}
