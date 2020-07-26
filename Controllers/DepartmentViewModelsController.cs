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
    public class DepartmentViewModelsController : Controller
    {
        private readonly MyContext _context;

        public DepartmentViewModelsController(MyContext context)
        {
            _context = context;
        }

        // GET: DepartmentViewModels
        public async Task<IActionResult> Index(string searching)
        {
            var myContext = _context.DepartmentViewModel.Include(d => d.Location);
                return View(await myContext.Where(x => (x.Name.Contains(searching) || x.Location.Address.Contains(searching)) || searching == null).ToListAsync());
           
        }

        // GET: DepartmentViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentViewModel = await _context.DepartmentViewModel
                .Include(d => d.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentViewModel == null)
            {
                return NotFound();
            }

            return View(departmentViewModel);
        }

        // GET: DepartmentViewModels/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.LocationViewModel, "Id", "Address");
            return View();
        }

        // POST: DepartmentViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LocationId")] DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.LocationViewModel, "Id", "Address", departmentViewModel.LocationId);
            return View(departmentViewModel);
        }

        // GET: DepartmentViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentViewModel = await _context.DepartmentViewModel.FindAsync(id);
            if (departmentViewModel == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.LocationViewModel, "Id", "Address", departmentViewModel.LocationId);
            return View(departmentViewModel);
        }

        // POST: DepartmentViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LocationId")] DepartmentViewModel departmentViewModel)
        {
            if (id != departmentViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentViewModelExists(departmentViewModel.Id))
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
            ViewData["LocationId"] = new SelectList(_context.LocationViewModel, "Id", "Address", departmentViewModel.LocationId);
            return View(departmentViewModel);
        }

        // GET: DepartmentViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentViewModel = await _context.DepartmentViewModel
                .Include(d => d.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentViewModel == null)
            {
                return NotFound();
            }

            return View(departmentViewModel);
        }

        // POST: DepartmentViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentViewModel = await _context.DepartmentViewModel.FindAsync(id);
            _context.DepartmentViewModel.Remove(departmentViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentViewModelExists(int id)
        {
            return _context.DepartmentViewModel.Any(e => e.Id == id);
        }
    }
}
