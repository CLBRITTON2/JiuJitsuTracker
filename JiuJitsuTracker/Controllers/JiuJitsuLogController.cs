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
        // Get action method
        public IActionResult Create()
        {
            return View();
        }

        // Post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassInfo obj)
        {
            // Server side validation
            if (ModelState.IsValid)
            {
                // Adds user input class info to the database then saves info to the db
                _db.Classes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
