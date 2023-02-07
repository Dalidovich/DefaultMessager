using DefaultMessager.DAL;
using DefaultMessager.Domain.Entities;
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
            using (var db = new MessagerDbContext())
            {
                
                db.UpdateDatabase();
            }
        }

        [Test]
        public void TestUser()
        {
            using (var db = new MessagerDbContext())
            {
                db.Users.Add(new User("email1", "login", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That(db.Users.AsNoTracking().Any(x => x.StatusAccount == 1), Is.True);
            }
        }

        [Test]
        public void TestDescription()
        {
            long? idUser;
            using (var db = new MessagerDbContext())
            {
                db.Users.Add(new User("email1", "login", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
                idUser = db.Users.OrderBy(x => x.UserId).Last().UserId;

                db.DescriptionUsers.Add(new DescriptionUser((long)idUser,"dima","surname","pathronomic","1","s","path"));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That( db.DescriptionUsers.AsNoTracking().Any(x => x.Name == "dima"), Is.True);
            }
        }

        [Test]
        public void TestImageAlbum()
        {
            long? idUser;
            using (var db = new MessagerDbContext())
            {
                db.Users.Add(new User("email1", "login", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
                idUser = db.Users.OrderBy(x => x.UserId).Last().UserId;

                db.ImageAlbums.Add(new ImageAlbum((long)idUser, Array.Empty<string>(),"one"));
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
            long? idUser;
            using (var db = new MessagerDbContext())
            {
                db.Users.Add(new User("email1", "login", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
                idUser = db.Users.OrderBy(x => x.UserId).Last().UserId;

                db.Posts.Add(new Post((long)idUser, new string[0], "text", "title", new string[0], DateTime.Now));
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
            long? idUser;
            using (var db = new MessagerDbContext())
            {
                db.Users.Add(new User("email1", "login", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
                idUser = db.Users.OrderBy(x => x.UserId).Last().UserId;

                db.Posts.Add(new Post((long)idUser, new string[0], "text", "title", new string[0], DateTime.Now));
                db.SaveChanges();
                long? idPost = db.Posts.OrderBy(x => x.PostId).Last().PostId;

                db.Comments.Add(new Comment((long)idPost, (long)idUser, "1", DateTime.Now, 1));
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
            long? idPost, idUser;
            using (var db = new MessagerDbContext())
            {
                db.Users.Add(new User("email1", "login", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
                idUser = db.Users.OrderBy(x => x.UserId).Last().UserId;

                db.Posts.Add(new Post((long)idUser, new string[0], "text", "title", new string[0], DateTime.Now));
                db.SaveChanges();
                idPost = db.Posts.OrderBy(x => x.PostId).Last().PostId;

                db.Likes.Add(new Like((long)idPost,(long)idUser));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.That(db.Likes.Any(x => x.PostId == (long)idPost), Is.True);
            }
        }

        [Test]
        public void TestMessage()
        {
            long? idSender, idReciever;
            using (var db = new MessagerDbContext())
            {
                db.Users.Add(new User("email1", "login", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
                idSender = db.Users.OrderBy(x => x.UserId).Last().UserId;

                db.Users.Add(new User("email1", "login1", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
                idReciever = db.Users.OrderBy(x => x.UserId).Last().UserId;

                db.Messages.Add(new Message((long)idReciever,(long)idSender, Array.Empty<string>(), Array.Empty<string>(), DateTime.Now,1,"text"));
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