using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sarak.Data.DbContexts;
using Sarak.Data.Entities;
using Sarak.Services.Base;

namespace Sarak.Services.Services
{
    public class UserRolesService : ServiceBase
    {
        public SarakDbContext Db { get; }
        public UserRolesService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager,
            SarakDbContext db)
            : base(userManager)
        {
            this.Db = db;
        }    

        public bool Insert(UserRole entity)
        {
            var result = Db.UserRoles.Add(entity);

            return Db.SaveChanges() > 0;
        }
    }
}
