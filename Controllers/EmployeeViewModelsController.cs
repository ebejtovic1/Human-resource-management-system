using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMSCrypto.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using System.Web;
using HRMSCrypto.Reports;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;

namespace HRMSCrypto.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Admin,User")]
    public class EmployeeViewModelsController : Controller
    {
        private readonly MyContext _context;
        private IWebHostEnvironment _pdfWebHostEnvironment;

        public EmployeeViewModelsController(MyContext context)
        {
            _context = context;
        }

        // GET: EmployeeViewModels
        public async Task<IActionResult> Index(string searching, string selected)
        {
            //Regex regexValidation = new Regex("^[#.0-9a-zA-ZćčšđžĆČŠĐŽ\\s,-]+$");
            var myContext = _context.EmployeeViewModel.Include(e => e.Department).Include(e => e.Job);

            
                if (selected == "name")
                {
                    return View(await myContext.Where(x => (x.EndDate == null && (x.Name.Contains(searching) || searching == null))).ToListAsync());
                }
                else if (selected == "lastname")
                {
                    return View(await myContext.Where(x => (x.EndDate == null && (x.LastName.Contains(searching) || searching == null))).ToListAsync());
                }

                else if (selected == "department")
                {
                    return View(await myContext.Where(x => (x.EndDate == null && (x.Department.Name.Contains(searching) || searching == null))).ToListAsync());

                }
                else
                {
                    return View(await myContext.Where(x => (x.EndDate == null && (x.Job.Name.Contains(searching) || searching == null))).ToListAsync());
                    
                }
            //ovako je bilo i ranije?
            //nmg, nema sanse
            //else
            //{
            //    if (searching != null)
            //    {
            //        searching.Remove(0);
            //        searching.Insert(0, "Invalid search!");
            //    }
            //    return View(await myContext.Where(x => x.EndDate == null).ToListAsync());
            //}


        }

        // GET: EmployeeViewModels
        public async Task<IActionResult> FormerEmployees(string searching, string selected)
        {
            var myContext = _context.EmployeeViewModel.Include(e => e.Department).Include(e => e.Job);


            if (selected == "name")
            {
                return View(await myContext.Where(x => (x.EndDate != null && (x.Name.Contains(searching) || searching == null))).ToListAsync());
            }
            else if (selected == "lastname")
            {
                return View(await myContext.Where(x => (x.EndDate != null && (x.LastName.Contains(searching) || searching == null))).ToListAsync());
            }

            else if (selected == "department")
            {
                return View(await myContext.Where(x => (x.EndDate != null && (x.Department.Name.Contains(searching) || searching == null))).ToListAsync());

            }
            else
            {
                return View(await myContext.Where(x => (x.EndDate != null && (x.Job.Name.Contains(searching) || searching == null))).ToListAsync());

            }




        }

        // GET: EmployeeViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeViewModel = await _context.EmployeeViewModel
                .Include(e => e.Department)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeViewModel == null)
            {
                return NotFound();
            }

            //var myContext = _context.EmployeeViewModel.Include(e => e.Department).Include(e => e.Job);
            //return myContext.ToList();

            return View(employeeViewModel);
        }

       
        public async Task<IActionResult> Report(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _context.EmployeeViewModel.Find(id);
            ReportEmployee rep = new ReportEmployee(_pdfWebHostEnvironment, employee);


            return File(rep.Report(), "application/pdf");
        }
       

        // GET: EmployeeViewModels/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentViewModel, "Id", "Name");
            ViewData["JobId"] = new SelectList(_context.JobViewModel, "Id", "Name");
            return View();
        }

        // POST: EmployeeViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,DateOfBirth,Address,StartDate,PhoneNumber,EndDate,Email,Salary,BrojRacuna,JobId,DepartmentId")] EmployeeViewModel employeeViewModel)
        {
            //employeeViewModel.EndDate = null;
            if (ModelState.IsValid)
            {
                _context.Add(employeeViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentViewModel, "Id", "Name", employeeViewModel.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.JobViewModel, "Id", "Name", employeeViewModel.JobId);
            return View(employeeViewModel);
        }


        // GET: EmployeeViewModels/Edit/5
        public async Task<IActionResult> Resign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeViewModel = await _context.EmployeeViewModel.FindAsync(id);
            if (employeeViewModel == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentViewModel, "Id", "Name", employeeViewModel.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.JobViewModel, "Id", "Name", employeeViewModel.JobId);
            return View(employeeViewModel);
        }


        // GET: EmployeeViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeViewModel = await _context.EmployeeViewModel.FindAsync(id);
            if (employeeViewModel == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentViewModel, "Id", "Name", employeeViewModel.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.JobViewModel, "Id", "Name", employeeViewModel.JobId);
            return View(employeeViewModel);
        }

        // POST: EmployeeViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,DateOfBirth,Address,StartDate,PhoneNumber,EndDate,Email,Salary,BrojRacuna,JobId,DepartmentId")] EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeViewModelExists(employeeViewModel.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentViewModel, "Id", "Name", employeeViewModel.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.JobViewModel, "Id", "Name", employeeViewModel.JobId);
            return View(employeeViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resign(int id, [Bind("Id,Name,LastName,DateOfBirth,Address,StartDate,PhoneNumber,EndDate,Email,Salary,BrojRacuna,JobId,DepartmentId")] EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeViewModelExists(employeeViewModel.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.DepartmentViewModel, "Id", "Name", employeeViewModel.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.JobViewModel, "Id", "Name", employeeViewModel.JobId);
            return View(employeeViewModel);
        }




        // GET: EmployeeViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeViewModel = await _context.EmployeeViewModel
                .Include(e => e.Department)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeViewModel == null)
            {
                return NotFound();
            }

            return View(employeeViewModel);
        }

        // POST: EmployeeViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeViewModel = await _context.EmployeeViewModel.FindAsync(id);
            _context.EmployeeViewModel.Remove(employeeViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeViewModelExists(int id)
        {
            return _context.EmployeeViewModel.Any(e => e.Id == id);
        }
    }
}
