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
        public int ID { get; set; }
        public string RoleID { get; set; }
        public IdentityRole Role { get; set; }
        public string Name { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}