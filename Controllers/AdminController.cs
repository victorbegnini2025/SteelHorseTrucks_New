using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SteelHorseTrucks.Data;
using System;
using System.Linq;

namespace SteelHorseTrucks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); // Admin dashboard
        }

        public IActionResult Trucks()
        {
            return RedirectToAction("Index", "Trucks");
        }

        public IActionResult UserManagement()
        {
            return RedirectToAction("Index", "UserManagement");
        }

        public IActionResult LoginLogs(string? email, DateTime? startDate, DateTime? endDate)
        {
            var logs = _context.LoginLogs.AsQueryable();

            if (!string.IsNullOrEmpty(email))
                logs = logs.Where(l => l.Email.Contains(email));

            if (startDate.HasValue)
                logs = logs.Where(l => l.AttemptTime >= startDate.Value);

            if (endDate.HasValue)
                logs = logs.Where(l => l.AttemptTime <= endDate.Value);

            var result = logs.OrderByDescending(l => l.AttemptTime).ToList();
            return View(result);
        }
    }
}
