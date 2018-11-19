using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentityCore.Data;
using IdentityCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCore.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UsersController(ApplicationDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        /// <summary>
        /// Returns the Home.cshtml view.
        /// </summary>
        /// <returns>Home.cshtml</returns>
        [AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// Gets a user from the Database by the supplied ID in the parameter
        /// </summary>
        /// <param name="ID">Unique user Id , used to find the user in the DB</param>
        /// <returns>returns the user profile partial view</returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetUser(string ID)
        {
            var res = from x in _context.Users where x.Id == ID select x;
            User user = res.ToList()[0];

            return PartialView("NEEDS VIEW", user);
        }

        [HttpGet]
        public ContentResult GetUserTypes()
        {
            var types = from x in _context.Roles select x;
            string result = "";
            foreach (var u in types.ToList())
            {
                result += u.Name + "\n";
            }
            return Content(result);
        }

        public IActionResult ChangeRole(string userEmail, string roleName)
        {
            User oldUserQuery = _context.Users.Where(u => u.UserName == userEmail).First();
           

            var roleIDQuery = from x in _context.UserRoles where x.UserId == oldUserQuery.Id select x.RoleId;
            var oldRoleName = from y in _context.Roles where y.Id == roleIDQuery.ToList()[0] select y.Name;
            Console.WriteLine(oldRoleName.Count() + "COUNT ..........................");
            foreach(var uf in oldRoleName)
            {
                Console.WriteLine(uf.ToList()[0]);
            }

            Console.WriteLine("---------------------->" + oldRoleName.ToList()[0]);
            _userManager.RemoveFromRoleAsync(oldUserQuery, oldRoleName.ToList()[0]);

            _userManager.AddToRoleAsync(oldUserQuery, roleName);

            return View("Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Gestao()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }


    }
}