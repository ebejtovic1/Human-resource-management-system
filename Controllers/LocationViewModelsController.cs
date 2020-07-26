using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMSCrypto.Models;
using Microsoft.AspNetCore.Authorization;

namespace HRMSCrypto.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Admin,User")]
    public class LocationViewModelsController : Controller
    {
        private readonly MyContext _context;

        public LocationViewModelsController(MyContext context)
        {
            _context = context;
        }

        // GET: LocationViewModels
        public async Task<IActionResult> Index(string searching)
        {
                return View(await _context.LocationViewModel.Where(x => (x.Address.Contains(searching) || x.City.Contains(searching))|| searching == null).ToListAsync());
        }

        // GET: LocationViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationViewModel = await _context.LocationViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationViewModel == null)
            {
                return NotFound();
            }

            return View(locationViewModel);
        }

        // GET: LocationViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,City")] LocationViewModel locationViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationViewModel);
        }

        // GET: LocationViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationViewModel = await _context.LocationViewModel.FindAsync(id);
            if (locationViewModel == null)
            {
                return NotFound();
            }
            return View(locationViewModel);
        }

        // POST: LocationViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,City")] LocationViewModel locationViewModel)
        {
            if (id != locationViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationViewModelExists(locationViewModel.Id))
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
            return View(locationViewModel);
        }

        // GET: LocationViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationViewModel = await _context.LocationViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationViewModel == null)
            {
                return NotFound();
            }

            return View(locationViewModel);
        }

        // POST: LocationViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationViewModel = await _context.LocationViewModel.FindAsync(id);
            _context.LocationViewModel.Remove(locationViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationViewModelExists(int id)
        {
            return _context.LocationViewModel.Any(e => e.Id == id);
        }
    }
}
