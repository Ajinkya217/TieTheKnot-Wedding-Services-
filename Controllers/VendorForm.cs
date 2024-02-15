using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TieTheKnot.Controllers
{
    [Authorize(Roles = "Admin")]

    public class VendorController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
