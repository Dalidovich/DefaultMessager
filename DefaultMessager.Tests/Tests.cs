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
            using (var db = new MessagerDbContext())
            {
                db.DropDatabase();
                db.CreateDatabase();
            }
        }

        [Test]
        public void Test1()
        {
            using (var db = new MessagerDbContext())
            {
                db.Users.Add(new User("email1", "login", "password", 1, DateTime.Now, 1));
                db.SaveChanges();
            }
            using (var db = new MessagerDbContext())
            {
                Assert.IsTrue(db.Users.AsNoTracking().Any(x => x.StatusAccount == 1));
            }
            using (var db = new MessagerDbContext())
            {
                db.Users.RemoveRange(db.Users);
                db.SaveChanges();
            }
        }
        public void Dispose()
        {

        }
    }
}