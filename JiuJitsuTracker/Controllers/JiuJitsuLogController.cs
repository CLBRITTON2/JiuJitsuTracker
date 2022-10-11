using JiuJitsuTracker.Data;
using JiuJitsuTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace JiuJitsuTracker.Controllers
{
    public class JiuJitsuLogController : Controller
    {
        private readonly ApplicationDbContext _db;
        public JiuJitsuLogController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Go to database, retrieve classes, convert them to a list
            IEnumerable<ClassInfo> objectCategoryList = _db.Classes;
            return View(objectCategoryList);
        }
    }
}
