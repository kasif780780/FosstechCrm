using FossTechCrm.Models;
using FossTechCrm.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FossTechCrm.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UsersController()
        {
        }

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Users
        public ActionResult Index(string searchTerm, int? page, string roleID)
        {
            int recordSize = 5;
            page = page ?? 1;
          UserListingModels model = new UserListingModels();
            model.SearchTerm = searchTerm;
            model.RoleID = roleID;
            //model.Roles = accomodationService.GetAllAccomodation();

            model.Users = SearchUsers(searchTerm,roleID,page.Value,recordSize);

          
           
          
            
             var totalRecords = SearchUsersCount(searchTerm, roleID);
             model.Pager = new Pager(totalRecords, page, recordSize);
            return View(model);


           // return View(myuser.ToPagedList(pageNumber, pageSize));
        }

        public IEnumerable<ApplicationUser> SearchUsers(string searchTerm, string roleID, int page, int recordSize)
        {
            var users = UserManager.Users.AsQueryable();
            if(!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrEmpty(roleID))
            {
                //users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));
            }
            //if (accPacid.HasValue && accpacid.value>0)

            //{
            //    acc = acc.where(a => a.AccomdID == accpacid.Value);
            //}
            var skip = (page - 1) * recordSize;
            return users.OrderBy(x=>x.Email).Skip(skip).Take(recordSize).ToList();
        }
        public int SearchUsersCount(string searchTerm, string roleID)
        {
            var users = UserManager.Users.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrEmpty(roleID))
            {
                //users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));
            }
            //if (accPacid.HasValue && accpacid.value>0)

            //{
            //    acc = acc.where(a => a.AccomdID == accpacid.Value);
            //}

            return users.Count();
        }
    }
}