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
using Microsoft.AspNetCore.Identity;


namespace AuslinkOperatingSupport.Controllers
{
    [Authorize]
    public class ContainerClasses1Controller : Controller
    {
        private readonly MvcAuslinkContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContainerClasses1Controller(MvcAuslinkContext context,UserManager<ApplicationUser> um)
        {
            _context = context;
            _userManager = um;
        }

        // GET: ContainerClasses1
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContainerClasses.ToListAsync());
        }

        // GET: ContainerClasses1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerClass = await _context.ContainerClasses
                .FirstOrDefaultAsync(m => m.ContainerNumber == id);
            if (containerClass == null)
            {
                return NotFound();
            }

            return View(containerClass);
        }

        // GET: ContainerClasses1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContainerClasses1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContainerNumber,OceanFreightETA,TimeToYard,ClientCompanyName,HandlerName,IfCartageOnly,IfRequireDelivery,IfRequireStorage,IfBookedCartage,IfEnteredCartonCloud,ChargeFrom,IfExtraLeg,IfInvoiced")] ContainerClass containerClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(containerClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(containerClass);
        }

        // GET: ContainerClasses1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerClass = await _context.ContainerClasses.FindAsync(id);
            if (containerClass == null)
            {
                return NotFound();
            }
            return View(containerClass);
        }

        // POST: ContainerClasses1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ContainerNumber,OceanFreightETA,TimeToYard,ClientCompanyName,HandlerName,IfCartageOnly,IfRequireDelivery,IfRequireStorage,IfBookedCartage,IfEnteredCartonCloud,ChargeFrom,IfExtraLeg,IfInvoiced")] ContainerClass containerClass)
        {
            if (id != containerClass.ContainerNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(containerClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainerClassExists(containerClass.ContainerNumber))
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
            return View(containerClass);
        }

        // GET: ContainerClasses1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containerClass = await _context.ContainerClasses
                .FirstOrDefaultAsync(m => m.ContainerNumber == id);
            if (containerClass == null)
            {
                return NotFound();
            }

            return View(containerClass);
        }

        // POST: ContainerClasses1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var containerClass = await _context.ContainerClasses.FindAsync(id);
            _context.ContainerClasses.Remove(containerClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContainerClassExists(string id)
        {
            return _context.ContainerClasses.Any(e => e.ContainerNumber == id);
        }
    }
}
