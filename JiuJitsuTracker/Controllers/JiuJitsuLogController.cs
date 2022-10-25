﻿using JiuJitsuTracker.DataAccess;
using JiuJitsuTracker.DataAccess.Repository.IRepository;
using JiuJitsuTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace JiuJitsuTracker.Controllers
{
    public class JiuJitsuLogController : Controller
    {
        private readonly IClassInfoRepository _db;
        public JiuJitsuLogController(IClassInfoRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Go to database, retrieve classes, convert them to a list
            IEnumerable<ClassInfo> objectClassList = _db.GetAll();
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
                _db.Add(obj);
                _db.Save();
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

            var classFromDbFirst = _db.GetFirstOrDefault(x => x.Id == id);

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
            // Server side validation
            if (ModelState.IsValid)
            {
                // Updates properties in DB when user uses the update button
                _db.Update(obj);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        // Get action method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                // if ID is null or is = 0 it's invalid
                return NotFound();
            }

            var classFromDbFirst = _db.GetFirstOrDefault(x => x.Id == id);

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
            var obj = _db.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            // Delete DB entry
            _db.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
