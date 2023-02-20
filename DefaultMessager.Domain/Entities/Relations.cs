using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.Entities
{
    public class Relations
    {
        public Guid? Id { get; set; }
        public Guid AccountId1 { get; set; }
        public Guid AccountId2 { get; set; }
        public StatusRelation Status { get; set; }
        public Account? Account1 { get; set; }
        public Account? Account2 { get; set; }
        public Relations(Guid guidId, Guid guid, StatusRelation status)
        {
            AccountId1 = guidId;
            AccountId2 = guid;
            Status = status;
        }
        public Relations() { }
    }

}
