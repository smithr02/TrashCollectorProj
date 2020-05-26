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
            ;

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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(customer);
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreetNumber,StreetName,State,ZipCode,CollectionDay, ApplicationUserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Id == 0)
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    customer.ApplicationUserId = userId;
                    _context.Customers.Add(customer);
                }
                else
                {
                    var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                    customerInDB.FirstName = customer.FirstName;
                    customerInDB.LastName = customer.LastName;
                    customerInDB.StreetNumber = customer.StreetNumber;
                    customerInDB.StreetName = customer.StreetName;
                    customerInDB.ZipCode = customer.ZipCode;
                    customerInDB.CollectionDay = customer.CollectionDay;
                    
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = customer.Id.ToString() });
            }

            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", customer.ApplicationUserId);
            return View(customer.Id);
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
            ViewData["IdentityUser"] = new SelectList(_context.Users,"Id","Id", customer.IdentityUser);

            return View(customer);

        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                var customerFromDb = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
                customerFromDb.FirstName = customer.FirstName;
                customerFromDb.LastName = customer.LastName;
                customerFromDb.StreetNumber = customer.StreetNumber;
                customerFromDb.StreetName = customer.StreetName;
                customerFromDb.State = customer.State;
                customerFromDb.ZipCode = customer.ZipCode;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var customers = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            return View(customers);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
