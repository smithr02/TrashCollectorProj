using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
        
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            Employee employee;
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); //gets your nameIdentifer
                employee = _context.Employees.Where(c => c.ApplicationUserId == userId).Single(); //gets a customer associated with the user
            }
            catch (Exception)
            {

                return RedirectToAction("create"); //if fails then creates 
            }
            List<Customer> customers = _context.Customers.Where(c => c.CollectionDay == DateTime.Now.DayOfWeek && c.StartDate > DateTime.Now.Date && c.EndDate < DateTime.Now.Date && c.ZipCode == employee.ZipCode).ToList();
            List<Customer> customers1 = _context.Customers.Where(c => c.ConfirmPickupDate == DateTime.Now.Date && c.ZipCode == employee.ZipCode).ToList();
            customers.AddRange(customers1);
            // add a viewbag of select list of days
            //in employee index add a div that uses the selectlist to choose a day to show of a list of pickups for that day
            return View(customers);
        }

        public ActionResult Index(DayOfWeek day)
        {
            Employee employee;
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); //gets your nameIdentifer
                employee = _context.Employees.Where(c => c.ApplicationUserId == userId).Single(); //gets a customer associated with the user
            }
            catch (Exception)
            {

                return RedirectToAction("create"); //if fails then creates 
            }
            List<Customer> customers = _context.Customers.Where(c => c.CollectionDay == DateTime.Now.DayOfWeek && c.StartDate > DateTime.Now.Date && c.EndDate < DateTime.Now.Date && c.ZipCode == employee.ZipCode).ToList();
            List<Customer> customers1 = _context.Customers.Where(c => c.ConfirmPickupDate == DateTime.Now.Date && c.ZipCode == employee.ZipCode).ToList();
            customers.AddRange(customers1);
            // add a viewbag of select list of days
            //in employee index add a div that uses the selectlist to choose a day to show of a list of pickups for that day
            return View(customers);
        }
        public void ConfirmPickUp(int id)
        {
            Customer customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            PickUp pickup = new PickUp();
            pickup.CustomerId = customer.Id;
            _context.PickUps.Add(pickup);
            _context.SaveChanges();
        }
        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            var employees = _context.Customers.Where(e => e.Id == id).SingleOrDefault();
            return View(employees);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); //associates the user with the employee
                employee.ApplicationUserId = userId;

                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var employees = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employees);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                var employeeFromDb = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
                employeeFromDb.FirstName = employee.FirstName;
                employeeFromDb.LastName = employee.LastName;
                employeeFromDb.ZipCode = employee.ZipCode;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            var employees = _context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employees);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                _context.Employees.Remove(employee);
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
