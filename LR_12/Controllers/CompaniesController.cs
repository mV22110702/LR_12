using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LR_12.Data;
using LR_12.Models;
using System.Text.Json;

namespace LR_12.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<CompaniesController> _logger;

        public CompaniesController(ApplicationContext context, ILogger<CompaniesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (_context.Users != null)
            {
                var companies = await _context.Companies.ToListAsync();
                _logger.LogInformation(JsonSerializer.Serialize(companies));

                return View(companies);
            }
            return Problem("Entity set 'ApplicationContext.Companies'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(company => company.Users)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                var targetCompany = new Company() { Name = company.Name, EstablishedDate = company.EstablishedDate};
                _context.Add(targetCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var targetCompany = await _context.Companies.FindAsync(id);
                    if (targetCompany == null)
                    {
                        return NotFound();
                    }
                    targetCompany.Name = company.Name;
                    targetCompany.EstablishedDate = company.EstablishedDate;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {

                    ModelState.AddModelError("", "Unable to save changes. " +
                     "Try again, and if the problem persists " +
                     "see your system administrator.");
                }
            }
            return RedirectToAction(nameof(Delete), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Companies == null)
            {
                return Problem("Entity set 'ApplicationContext.Companies'  is null.");
            }
            var company = await _context.Companies.Include(company => company.Users).Where(company => company.ID == id).FirstAsync();
            if (company != null)
            {
                company.Users.ForEach(user => user.Company = null);
                _context.Companies.Remove(company);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
