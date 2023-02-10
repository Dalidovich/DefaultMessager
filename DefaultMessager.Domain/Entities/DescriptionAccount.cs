namespace DefaultMessager.Domain.Entities
{
    public class DescriptionAccount
    {
        public Guid? Id { get; set; }
        public Guid AccountId { get; set; }
        public string? Name { get; set; } 
        public string? Surname { get; set; } 
        public string? Patronymic { get; set; }
        public string? Describe { get; set; }
        public string? UserStatus { get; set; } 
        public string? PathAvatar { get; set; }
        public Account? User{get; set;} 
        public DescriptionAccount(Guid accountId, string name, string surnames, string patronymic, string? describe, string status, string? pathAvatar)
        {
            AccountId = accountId;
            Name = name;
            Surname = surnames;
            Patronymic = patronymic;
            Describe = describe;
            UserStatus = status;
            PathAvatar = pathAvatar;
        }
        public DescriptionAccount(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
