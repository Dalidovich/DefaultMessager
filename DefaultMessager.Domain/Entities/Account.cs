using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Domain.Entities
{
    public class Account
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public DateTime CreateDate { get; set; }
        public StatusAccount StatusAccount { get; set; }
        public string Salt { get; set; }
        public DescriptionAccount? Description {get ;set;}
        public RefreshToken? RefreshToken{get ;set;}
        public Account(string email, string login, string password, Role role, DateTime createDate, StatusAccount statusAccount,string salt="none")
        {
            Email = email;
            Login = login;
            Password = password;
            Role = role;
            CreateDate = createDate;
            StatusAccount = statusAccount;
            Salt = salt;
        }
        public Account(RegisterAccountViewModel model,string salt,string password)
        {
            Email= model.Email;
            Login= model.Login;
            Password= password;
            Role = Role.standart;
            CreateDate=DateTime.Now;
            StatusAccount = StatusAccount.normal;
            Salt = salt;
        }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<ImageAlbum> ImageAlbum { get; set; } = new List<ImageAlbum>();
        public List<Message> SendMessages { get; set; } = new List<Message>();
        public List<Message> ReciveMessages { get; set; } = new List<Message>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Relations> RelationsFrom { get; set; } = new List<Relations>();
        public List<Relations> RelationsTo { get; set; } = new List<Relations>();
    }
}