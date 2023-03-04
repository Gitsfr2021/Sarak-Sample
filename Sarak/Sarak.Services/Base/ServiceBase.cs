using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sarak.Data.Entities;
using System;
using System.Data;
using System.Linq;

namespace Sarak.Services.Base
{
    public abstract class ServiceBase
    {
        public UserManager<User> UserManager { get; set; }
        public ServiceBase(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }
        
    }
}
