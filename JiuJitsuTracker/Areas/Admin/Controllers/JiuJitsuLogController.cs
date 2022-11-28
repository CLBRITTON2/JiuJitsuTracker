using JiuJitsuTracker.DataAccess;
using JiuJitsuTracker.DataAccess.Repository.IRepository;
using JiuJitsuTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JiuJitsuTracker.Controllers
{
    [Area("Admin")]
    public class JiuJitsuLogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JiuJitsuLogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public IActionResult Index(ClassInfo obj)
        {
            var claim = GetUserId(obj);

            // Go to database, retrieve classes, convert them to a list
            IEnumerable<ClassInfo> objectClassList = _unitOfWork.ClassInfo.GetAll().Where(x => x.ApplicationUserId == claim);
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
            GetUserId(obj);

            // Adds user input class info to the database then saves info to the db
            _unitOfWork.ClassInfo.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Log entry created successfully";
            return RedirectToAction("Index");
        }
        // Get action method
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                // if ID is null or is = 0 it's invalid
                return NotFound();
            }

            var classFromDbFirst = _unitOfWork.ClassInfo.GetFirstOrDefault(x => x.Id == id);

            if (classFromDbFirst == null)
            {
                return NotFound();
            }

            return View(classFromDbFirst);
        }

        // Post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClassInfo obj)
        {
            GetUserId(obj);

            // Updates properties in DB when user uses the update button
            _unitOfWork.ClassInfo.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Log entry updated successfully";
            return RedirectToAction("Index");

        }
        // Get action method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                // if ID is null or is = 0 it's invalid
                return NotFound();
            }

            var classFromDbFirst = _unitOfWork.ClassInfo.GetFirstOrDefault(x => x.Id == id);

            if (classFromDbFirst == null)
            {
                return NotFound();
            }

            return View(classFromDbFirst);
        }

        // Post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.ClassInfo.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            // Delete DB entry
            _unitOfWork.ClassInfo.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Log entry deleted successfully";
            return RedirectToAction("Index");
        }
        private string GetUserId(ClassInfo obj)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            obj.ApplicationUserId = claim.Value;
            return claim.Value;
        }
    }
}
