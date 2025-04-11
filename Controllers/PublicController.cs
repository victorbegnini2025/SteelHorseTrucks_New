using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SteelHorseTrucks.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SteelHorseTrucks.Controllers
{
    public class PublicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous] // Permite acesso sem login
        public async Task<IActionResult> Index()
        {
            var trucks = await Task.Run(() => _context.Trucks.ToList());
            return View(trucks);
        }
    }
}
