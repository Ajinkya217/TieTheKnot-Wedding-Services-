using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TieTheKnot.Controllers
{

    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
