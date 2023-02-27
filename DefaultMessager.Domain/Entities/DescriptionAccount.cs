namespace DefaultMessager.Domain.Entities
{
    public class DescriptionAccount
    {
        public Guid? Id { get; set; }
        public Guid AccountId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Describe { get; set; }
        public string? AccountStatus { get; set; }
        public string? PathAvatar { get; set; }
        public Account? Account { get; set; }

        public DescriptionAccount(Guid accountId, string? name, string? surname, string? patronymic, DateTime? birthday, string? describe, string? accountStatus, string? pathAvatar)
        {
            AccountId = accountId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Birthday = birthday;
            Describe = describe;
            AccountStatus = accountStatus;
            PathAvatar = pathAvatar;
        }
        public DescriptionAccount(Guid accountId, string pathAvatar) : this(accountId)
        {
            PathAvatar = pathAvatar;
        }
        public DescriptionAccount(Guid accountId)
        {
            AccountId = accountId;
            Name = "";
            Surname = "";
            Patronymic = "";
            Birthday = DateTime.Now;
            Describe = "";
            AccountStatus = "";
            PathAvatar = "";
        }
        public void Update(DescriptionAccount description)
        {
            Name = description.Name;
            Surname = description.Surname;
            Patronymic = description.Patronymic;
            Birthday = description.Birthday;
            Describe = description.Describe;
            AccountStatus = description.AccountStatus;
        }
        public DescriptionAccount()
        {
        }
    }
}
