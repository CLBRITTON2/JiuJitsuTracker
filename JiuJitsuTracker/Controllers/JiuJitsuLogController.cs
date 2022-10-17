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
            IEnumerable<ClassInfo> objectClassList = _db.Classes;
            return View(objectClassList);
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
        // Get action method
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                // if ID is null or is = 0 it's invalid
                return NotFound();
            }

            var classFromDb = _db.Classes.Find(id);

            if (classFromDb == null)
            {
                return NotFound();
            }

            return View(classFromDb);
        }

        // Post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClassInfo obj)
        {
            // Server side validation
            if (ModelState.IsValid)
            {
                // Updates properties in DB when user uses the update button
                _db.Classes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
