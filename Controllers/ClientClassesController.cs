using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuslinkOperatingSupport.Data;
using AuslinkOperatingSupport.Models;
using Microsoft.AspNetCore.Authorization;


namespace AuslinkOperatingSupport.Controllers
{
    
    public class ClientClassesController : Controller
    {
        private readonly MvcAuslinkContext _context;

        public ClientClassesController(MvcAuslinkContext context)
        {
            _context = context;
        }

        // GET: ClientClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientClasses.ToListAsync());
        }

        // GET: ClientClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.ClientClasses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientClass == null)
            {
                return NotFound();
            }

            return View(clientClass);
        }

        // GET: ClientClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClientContactPerson,ClientContactNumber,ClientCompanyName,ClientRateSheetID,LastUpdateDate")] ClientClass clientClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientClass);
        }

        // GET: ClientClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.ClientClasses.FindAsync(id);
            if (clientClass == null)
            {
                return NotFound();
            }
            return View(clientClass);
        }

        // POST: ClientClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClientContactPerson,ClientContactNumber,ClientCompanyName,ClientRateSheetID,LastUpdateDate")] ClientClass clientClass)
        {
            if (id != clientClass.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientClassExists(clientClass.ID))
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
            return View(clientClass);
        }

        // GET: ClientClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientClass = await _context.ClientClasses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientClass == null)
            {
                return NotFound();
            }

            return View(clientClass);
        }

        // POST: ClientClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientClass = await _context.ClientClasses.FindAsync(id);
            _context.ClientClasses.Remove(clientClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientClassExists(int id)
        {
            return _context.ClientClasses.Any(e => e.ID == id);
        }
    }
}
