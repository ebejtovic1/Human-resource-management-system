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
    public class JobViewModelsController : Controller
    {
        private readonly MyContext _context;

        public JobViewModelsController(MyContext context)
        {
            _context = context;
        }

        // GET: JobViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobViewModel.ToListAsync());
        }

        // GET: JobViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobViewModel = await _context.JobViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobViewModel == null)
            {
                return NotFound();
            }

            return View(jobViewModel);
        }

        // GET: JobViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] JobViewModel jobViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobViewModel);
        }

        // GET: JobViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobViewModel = await _context.JobViewModel.FindAsync(id);
            if (jobViewModel == null)
            {
                return NotFound();
            }
            return View(jobViewModel);
        }

        // POST: JobViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] JobViewModel jobViewModel)
        {
            if (id != jobViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobViewModelExists(jobViewModel.Id))
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
            return View(jobViewModel);
        }

        // GET: JobViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobViewModel = await _context.JobViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobViewModel == null)
            {
                return NotFound();
            }

            return View(jobViewModel);
        }

        // POST: JobViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobViewModel = await _context.JobViewModel.FindAsync(id);
            _context.JobViewModel.Remove(jobViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobViewModelExists(int id)
        {
            return _context.JobViewModel.Any(e => e.Id == id);
        }
    }
}
