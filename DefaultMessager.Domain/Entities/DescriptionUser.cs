namespace DefaultMessager.Domain.Entities
{
    public class DescriptionUser
    {
        public long? DescriptionId { get; set; }
        public long UserId { get; set; }
        public string? Name { get; set; } 
        public string? Surname { get; set; } 
        public string? Patronymic { get; set; }
        public string? Describe { get; set; }
        public string? UserStatus { get; set; } 
        public string? PathAvatar { get; set; }
        public User? User{get; set;} 
        public DescriptionUser(long userId)
        {
            UserId = userId;
        }
        public DescriptionUser(long userId, string name, string surnames, string patronymic, string? describe, string status, string? pathAvatar)
        {
            UserId = userId;
            Name = name;
            Surname = surnames;
            Patronymic = patronymic;
            Describe = describe;
            UserStatus = status;
            PathAvatar = pathAvatar;
        }
    }
}
