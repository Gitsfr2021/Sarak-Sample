using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sarak.Data.DbContexts;
using Sarak.Data.Entities;
using Sarak.Services.Base;
using System.Collections.Generic;
using System.Linq;

namespace Sarak.Services.Services
{
    public class RolesService : ServiceBase
    {
        public SarakDbContext Db { get; }
        public RolesService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager,
            SarakDbContext db)
            : base(userManager)
        {
            this.Db = db;
        }

        public Role GetByName(string name)
        {
            return Db.Set<Role>().FirstOrDefault(p => p.Name == name);
        }

        string UserId;
        public string[] GetUserRoles(string userId = "")
        {
            userId = string.IsNullOrEmpty(userId) ? UserId.ToString() : userId;
            var roles = (from userRole in Db.UserRoles
                         join role in Db.Roles on userRole.RoleId equals role.Id
                         where userRole.UserId == userId
                         select role.Name).ToArray();

            return roles;
        }

        public string[] GetUserRoleIds(string userId = "")
        {
            userId = string.IsNullOrEmpty(userId) ? UserId.ToString() : userId;
            var roles = (from userRole in Db.UserRoles
                         join role in Db.Roles on userRole.RoleId equals role.Id
                         where userRole.UserId == userId
                         select role.Id).ToArray();

            return roles;
        }
    }
}
