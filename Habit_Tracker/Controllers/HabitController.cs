using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Habit_Tracker.Data;
using Habit_Tracker.Models;

namespace Habit_Tracker.Controllers
{
    public class HabitController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HabitController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Habit> habitsList = _db.Habit;
            ResetCount(habitsList);
            return View(habitsList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Habit habit)
        {
            if (ModelState.IsValid)
            {
                habit.NextReset = DateTime.Now.AddDays(7 - (int)DateTime.Now.DayOfWeek);
                _db.Habit.Add(habit);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(habit);
        }

        //GET - TRACK
        public IActionResult Track(int? id)
        {

            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Habit.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            obj.CurrentCount++;

            if(obj.CurrentCount >= obj.WeeklyGoal)
            {
                obj.IsGoalMet = true;
            }

            _db.Habit.Update(obj);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Habit.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Habit habit)
        {
            if(ModelState.IsValid)
            {
                _db.Habit.Update(habit);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(habit);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Habit.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Habit.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Habit.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        public void ResetCount(IEnumerable<Habit> habitsList)
        {
            var date = DateTime.Today.Date;
            foreach (Habit habit in habitsList)
            {
                if(DateTime.Compare(date, habit.NextReset) >=0 )
                { 
                    habit.NextReset = DateTime.Now.AddDays(7 - (int)date.DayOfWeek);
                    habit.CurrentCount = 0;
                    _db.Habit.Update(habit);
                }
            }
            _db.SaveChanges();
        }
    }
}
