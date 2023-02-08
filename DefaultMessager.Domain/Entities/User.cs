namespace DefaultMessager.Domain.Entities
{
    public class User
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public short Role { get; set; }
        public DateTime CreateDate { get; set; }
        public short StatusAccount { get; set; }
        public DescriptionUser? Description {get ;set;}
        public User(string email, string login, string password, short role, DateTime createDate, short statusAccount)
        {
            Email = email;
            Login = login;
            Password = password;
            Role = role;
            CreateDate = createDate;
            StatusAccount = statusAccount;
        }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<ImageAlbum> ImageAlbum { get; set; } = new List<ImageAlbum>();
        public List<Message> SendMessages { get; set; } = new List<Message>();
        public List<Message> ReciveMessages { get; set; } = new List<Message>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}