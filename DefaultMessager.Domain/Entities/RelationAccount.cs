namespace DefaultMessager.Domain.Entities
{
    public enum Relation
    { 
        Positive,
        Negative
    }
    public class RelationAccount
    {
        public Guid? Id { get; set; }
        public Guid AccountId1 { get; set; }
        public Guid AccountId2 { get; set; }
        public Relation Status { get; set; }
        public Account? Account1 { get; set; }
        public Account? Account2 { get; set; }
        public RelationAccount(Guid guidId, Guid guid, Relation status)
        {
            AccountId1 = guidId;
            AccountId2 = guid;
            Status = status;
        }
        public RelationAccount() { }
    }

}
