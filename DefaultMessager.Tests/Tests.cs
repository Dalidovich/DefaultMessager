using DefaultMessager.DAL;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DefaultMessager.Tests
{
    [TestFixture]
    public class Tests : IDisposable
    {
        [SetUp]
        public void Setup()
        {
            MessagerDbContext.ConnectionString = "Server=localhost;Database=defaultMessager;Port=5432;User Id=postgres;Password=pg";
            using var db = new MessagerDbContext();
            db.Database.EnsureDeleted();
            db.Database.Migrate();
        }

        [Test]
        public void TestUser()
        {
            using (var db = new MessagerDbContext())
            {
                var user1 = new Account("email1", "login1", "password1", Role.admin, DateTime.Now, StatusAccount.normal);
                var user3 = new Account("email3", "login2", "password2", Role.standart, DateTime.Now, StatusAccount.normal);
                db.AddRange(user1, user3);
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.Multiple(() =>
                {
                    Assert.That(db.Accounts.AsNoTracking().GroupBy(x => x.Id).Any(x=> x.Count() < 1), Is.False);
                });
            }
        }

        [Test]
        public void TestDescription()
        {
            Guid? idUser;
            using (var db = new MessagerDbContext())
            {
                db.Accounts.Add(new Account("email13", "login", "password", Role.standart, DateTime.Now, StatusAccount.normal));
                db.SaveChanges();
                idUser = db.Accounts.OrderBy(x => x.Id).Last().Id;

                db.DescriptionAccounts.Add(new DescriptionAccount((Guid)idUser,"dima","surname","pathronomic",DateTime.Now,"1","s","path"));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That( db.DescriptionAccounts.AsNoTracking().Any(x => x.Name == "dima"), Is.True);
            }
        }

        [Test]
        public void TestImageAlbum()
        {
            Guid? idUser;
            using (var db = new MessagerDbContext())
            {
                db.Accounts.Add(new Account("email14", "login", "password", Role.standart, DateTime.Now, StatusAccount.normal));
                db.SaveChanges();
                idUser = db.Accounts.OrderBy(x => x.Id).Last().Id;

                db.ImageAlbums.Add(new ImageAlbum((Guid)idUser, Array.Empty<string>(),"one"));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That( db.ImageAlbums.Any(x => x.Title == "one"), Is.True);
            }
        }

        [Test]
        public void TestPost()
        {
            Guid? idUser;
            using (var db = new MessagerDbContext())
            {
                db.Accounts.Add(new Account("email15", "login", "password", Role.standart, DateTime.Now, StatusAccount.normal));
                db.SaveChanges();
                idUser = db.Accounts.OrderBy(x => x.Id).Last().Id;

                db.Posts.Add(new Post((Guid)idUser, new string[0], "text", "title", new string[0], DateTime.Now));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That(db.Posts.Any(x => x.Title == "title"), Is.True);
            }
        }
        [Test]
        public void TestComment()
        {
            Guid? idUser;
            using (var db = new MessagerDbContext())
            {
                db.Accounts.Add(new Account("email16", "login", "password", Role.standart, DateTime.Now, StatusAccount.normal));
                db.SaveChanges();
                idUser = db.Accounts.OrderBy(x => x.Id).Last().Id;

                db.Posts.Add(new Post((Guid)idUser, new string[0], "text", "title", new string[0], DateTime.Now));
                db.SaveChanges();
                Guid? idPost = db.Posts.OrderBy(x => x.Id).Last().Id;

                db.Comments.Add(new Comment((Guid)idPost, (Guid)idUser, "1", DateTime.Now, StatusComment.normal));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That(db.Comments.Any( x => x.CommentTextContent == "1"), Is.True);
            }
        }

        [Test]
        public void TestLike()
        {
            Guid? idPost, idUser;
            using (var db = new MessagerDbContext())
            {
                db.Accounts.Add(new Account("email17", "login", "password", Role.standart, DateTime.Now, StatusAccount.normal));
                db.SaveChanges();
                idUser = db.Accounts.OrderBy(x => x.Id).Last().Id;

                db.Posts.Add(new Post((Guid)idUser, new string[0], "text", "title", new string[0], DateTime.Now));
                db.SaveChanges();
                idPost = db.Posts.OrderBy(x => x.Id).Last().Id;

                db.Likes.Add(new Like((Guid)idPost,(Guid)idUser));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That(db.Likes.Any(x => x.PostId == (Guid)idPost), Is.True);
            }
        }

        [Test]
        public void TestMessage()
        {
            Guid? idSender, idReciever;
            using (var db = new MessagerDbContext())
            {
                db.Accounts.Add(new Account("email18", "login", "password", Role.standart, DateTime.Now, StatusAccount.normal));
                db.SaveChanges();
                idSender = db.Accounts.OrderBy(x => x.Id).Last().Id;

                db.Accounts.Add(new Account("email19", "login1", "password", Role.standart, DateTime.Now, StatusAccount.normal));
                db.SaveChanges();
                idReciever = db.Accounts.OrderBy(x => x.Id).Last().Id;

                db.Messages.Add(new Message((Guid)idReciever,(Guid)idSender, Array.Empty<string>(), Array.Empty<string>(), DateTime.Now,StatusMessage.normal,"text"));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That(db.Messages.AsNoTracking().Any(x => x.MessageTextContent == "text"), Is.True);
            }
        }

        public void Dispose()
        {

        }
    }
}