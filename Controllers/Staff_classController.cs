using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuslinkOperatingSupport.Data;
using AuslinkOperatingSupport.Models;

namespace AuslinkOperatingSupport.Controllers
{
    public class Staff_classController : Controller
    {
        private readonly MvcAuslinkContext _context;

        public Staff_classController(MvcAuslinkContext context)
        {
            _context = context;
        }

        // GET: Staff_class
        public async Task<IActionResult> Index()
        {
            return View(await _context.staff_Classes.ToListAsync());
        }

        // GET: Staff_class/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_class = await _context.staff_Classes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (staff_class == null)
            {
                return NotFound();
            }

            return View(staff_class);
        }

        // GET: Staff_class/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff_class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,UserName,Password,MobileNumber,AuthorityLevel")] Staff_class staff_class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff_class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff_class);
        }

        // GET: Staff_class/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_class = await _context.staff_Classes.FindAsync(id);
            if (staff_class == null)
            {
                return NotFound();
            }
            return View(staff_class);
        }

        // POST: Staff_class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,UserName,Password,MobileNumber,AuthorityLevel")] Staff_class staff_class)
        {
            if (id != staff_class.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff_class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Staff_classExists(staff_class.ID))
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
            return View(staff_class);
        }

        // GET: Staff_class/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_class = await _context.staff_Classes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (staff_class == null)
            {
                return NotFound();
            }

            return View(staff_class);
        }

        // POST: Staff_class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff_class = await _context.staff_Classes.FindAsync(id);
            _context.staff_Classes.Remove(staff_class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Staff_classExists(int id)
        {
            return _context.staff_Classes.Any(e => e.ID == id);
        }
    }
}
