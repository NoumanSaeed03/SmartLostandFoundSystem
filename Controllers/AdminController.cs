using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLostandFoundSystem.Data;
using SmartLostandFoundSystem.Models;
using SmartLostandFoundSystem.Models.ViewModel;

namespace SmartLostandFoundSystem.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly AppDbContext db;
        private readonly UserManager<ApplicationUser> um;

        public AdminController(AppDbContext context, UserManager<ApplicationUser> user)
        {
            db= context;
            um= user;
        }

        public async Task<IActionResult> AdminDashboard()
        {
            //will count the users
            var totaluser = await um.Users.CountAsync();
            //count total lost item
            var lostitem = await db.Items.Where(i => i.IsLost).CountAsync();
            var activeUsers = await um.Users
    .CountAsync(u => u.LastActivityTime >= DateTime.Now.AddMinutes(-10));
            //count total found item in database
            var founditem = await db.Items.Where(i => !i.IsLost).CountAsync();
            //total no. of items in database 
            var allItems = await db.Items
                                        .OrderByDescending(i => i.Date)
                                        .ToListAsync();
            var model = new AdminViewModel
            {
                TotalUser = totaluser,
                ActiveUser = activeUsers,
                TotalLostItem = lostitem,
                TotalFoundItem = founditem,
                Items = allItems
            };

            return View(model);


        }

        public IActionResult Index()
        {
            return View();
        }
    }
}