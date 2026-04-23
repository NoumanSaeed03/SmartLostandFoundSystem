using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLostAndFound.Models;
using SmartLostandFoundSystem.Data;
using SmartLostandFoundSystem.Models;

namespace SmartLostAndFound.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> um;

        public ItemsController(AppDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            um = user;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_context.Items.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            if (!ModelState.IsValid)
                return View(item);

            var userId = um.GetUserId(User);

            if (userId == null)
                return RedirectToAction("Login", "Account");

            item.UserId = userId;

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyItem");
        }

        public IActionResult Matches(int id)
        {
            // Selected item ko database se nikal li
            var selectedItem = _context.Items.FirstOrDefault(i => i.Id == id);
            if (selectedItem == null) return NotFound();

            // Pehle database se values nikali wo wali jahan Id alag ho aur Lost/Found opposite ho
            // mltb item apny sth match na ho 
            var allItems = _context.Items
                .Where(i => i.Id != selectedItem.Id && i.IsLost != selectedItem.IsLost)
                .ToList(); // Database se data nikal ke list me convert kar dia

            var matches = allItems
        .Where(i =>
        // Category check kar rahe hain, lowercase me convert karke
        i.Category.ToLower() == selectedItem.Category.ToLower() &&

        // Location bhi match honi chahiye
        i.Location.ToLower() == selectedItem.Location.ToLower() &&

        // Color optional hai, agar selected item ka color empty ho to ignore karo
        (string.IsNullOrEmpty(selectedItem.Color) || i.Color.ToLower() == selectedItem.Color.ToLower()) &&

        // Date difference 7 din ke andar honi chahiye
        Math.Abs((i.Date - selectedItem.Date).Days) <= 7
        ).ToList();

            return View(matches);
        }
        public async Task<IActionResult> MyItem()
        {
            var userId = um.GetUserId(User);

            var items = await _context.Items
                                      .Where(i => i.UserId == userId)
                                      .ToListAsync();
            return View(items);
        }
    }
}