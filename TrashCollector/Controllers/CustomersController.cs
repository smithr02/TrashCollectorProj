using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CustomersController
        public async Task<IActionResult> Index()
        {
            Customer customer;
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); //gets your nameIdentifer
                customer = _context.Customers.Where(c => c.ApplicationUserId == userId).Single(); //gets a customer associated with the user
            }
            catch (Exception)
            {

                return RedirectToAction("create"); //if fails then creates 
            }

            var applicationDbContext = _context.Customers.Include(c => c.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustomersController/Details/5
        public  async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.Include(c => c.IdentityUser).FirstOrDefaultAsync(m => m.Id == id);
            
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            List<DayOfWeek> dayOfWeek = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            ViewData["DaysOfWeek"] = new SelectList(dayOfWeek, customer.CollectionDay);
            return View(customer);
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreetNumber,StreetName,State,ZipCode,CollectionDay,ApplicationUserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {                
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    customer.ApplicationUserId = userId;
                    _context.Customers.Add(customer);                                                  
            }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");                          
        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users,"Id","Id", customer.ApplicationUserId);

            return View(customer);

        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,StreetNumber,StreetName,State,ZipCode,CollectionDay,AnotherCollectionDay,StartDate,EndDate")]Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var customerFromDb = _context.Customers.Single(c => c.Id == customer.Id);
                    customerFromDb.FirstName = customer.FirstName;
                    customerFromDb.LastName = customer.LastName;
                    customerFromDb.StreetNumber = customer.StreetNumber;
                    customerFromDb.StreetName = customer.StreetName;
                    customerFromDb.State = customer.State;
                    customerFromDb.ZipCode = customer.ZipCode;
                    customerFromDb.CollectionDay = customer.CollectionDay;                    
                    customerFromDb.StartDate = customer.StartDate;
                    customerFromDb.EndDate = customer.EndDate;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = customer.Id.ToString() });   
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", customer.ApplicationUserId);
            return View(customer.Id);
        }

        // GET: CustomersController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.Include(c => c.IdentityUser).FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);



        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }
    
    }
}
