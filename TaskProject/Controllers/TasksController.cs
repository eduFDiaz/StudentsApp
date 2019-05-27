using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskProject.Models;

namespace TaskProject.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var taskContext = _context.TaskDetails.Include(t => t.employee).Include(t => t.status);
            return View(await taskContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDetail = await _context.TaskDetails
                .Include(t => t.employee)
                .Include(t => t.status)
                .FirstOrDefaultAsync(m => m.TaskDetailId == id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            return View(taskDetail);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskDetailId,TaskName,TaskDescription,AssignedDate,EmployeeId,StatusId")] TaskDetail taskDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", taskDetail.EmployeeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", taskDetail.StatusId);
            return View(taskDetail);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDetail = await _context.TaskDetails.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", taskDetail.EmployeeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", taskDetail.StatusId);
            return View(taskDetail);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskDetailId,TaskName,TaskDescription,AssignedDate,EmployeeId,StatusId")] TaskDetail taskDetail)
        {
            if (id != taskDetail.TaskDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskDetailExists(taskDetail.TaskDetailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", taskDetail.EmployeeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", taskDetail.StatusId);
            return View(taskDetail);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDetail = await _context.TaskDetails
                .Include(t => t.employee)
                .Include(t => t.status)
                .FirstOrDefaultAsync(m => m.TaskDetailId == id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            return View(taskDetail);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskDetail = await _context.TaskDetails.FindAsync(id);
            _context.TaskDetails.Remove(taskDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskDetailExists(int id)
        {
            return _context.TaskDetails.Any(e => e.TaskDetailId == id);
        }
    }
}
