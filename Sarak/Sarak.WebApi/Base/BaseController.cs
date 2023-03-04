using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sarak.Data.Entities;
using System;

namespace Sarak.WebAPI.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        protected const string ERRORMESSAGE = "عملیات با خطا مواجه شد!";

        public UserManager<User> UserManager { get; }

        public string CurrentUserId => this.HttpContext.User.Identity.IsAuthenticated ? UserManager.GetUserId(this.HttpContext.User) : null;
        public User CurrentUser => string.IsNullOrEmpty(CurrentUserId) ? null : UserManager.FindByIdAsync(CurrentUserId).Result;

        public BaseController(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        protected string GetErrorMessage(Exception ex)
        {
            return ERRORMESSAGE;
        }
    }
}