using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdenetityAPI.Models
{
    public class AuthBl
    {
        //userManager property
        UserManager<IdentityUser> manager;
        public AuthBl()
        {
            manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IntiteCompaney()));
        }

        //user,pass=> create
        public IdentityResult Create(string userName,string Email, string password)
        {
            IdentityUser User = new IdentityUser();

            //map userName password to identityUser
            User.UserName = userName;
            User.Email = Email;
            //save
            return manager.Create(User, password);
        }
        //user,pass=> find
        public IdentityUser find(string userName, string password)
        {
            return manager.Find(userName, password);
        }
            //user =>roles
        }
}