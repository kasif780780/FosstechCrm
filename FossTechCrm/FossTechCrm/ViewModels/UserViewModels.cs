using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using FossTechCrm.Entities;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using FossTechCrm.Models;

namespace FossTechCrm.ViewModels
{
    public class UserListingModels
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public string RoleID { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }



    public class UserActionModel
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        //public string RoleID { get; set; }
        //public IdentityRole Role { get; set; }
        //public IEnumerable<IdentityRole> Roles { get; set; }
    }

    public class UserRolesModel
    {
        public string UserID { get; set; }
        public IEnumerable<IdentityRole> UserRoles { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }


    }
}