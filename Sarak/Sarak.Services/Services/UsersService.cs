using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sarak.Data.DbContexts;
using Sarak.Data.Entities;
using Sarak.Services.Base;
using System.Linq;

namespace Sarak.Services.Services
{
    public class UsersService : ServiceBase
    {
        public SarakDbContext Db { get; }
        public UsersService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager,
            SarakDbContext db)
            : base(userManager)
        {
            this.Db = db;
        }

        public User GetByUsername(string username)
        {
            return Db.Set<User>().Where(item => item.UserName == username).Single();
        }
    }
}