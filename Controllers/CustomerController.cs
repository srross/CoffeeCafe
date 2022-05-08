#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeCafe.Data;
using CoffeeCafe.Models;

namespace CoffeeCafe.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerDbContext _context;
        public List<Customer> Customer { get; set; } = new List<Customer>();

        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        //GET: Customer/Details/5
        public async Task<IActionResult> CustomerDetail(Customer customer)
        {
            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                // return fresh form - Transaction.AddOrEdit.cshtml view
                return View(new Customer());
            }
            else
            {
                return View(_context.Customer.Find(id));
            }
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("CustomerId,FirstName,LastName,Email," +
                                                            "Phone,IsBrewCrew,Password,ConfirmPassword," +
                                                            "CreatedDate,UpdatedDate")] Customer customer)
        {
            if (ModelState.IsValid) // server  side validation
            {
                if (customer.CustomerId == 0)
                {
                    customer.CreatedDate = DateTime.Now;
                    _context.Add(customer);
                    Customer.Add(customer);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("CustomerDetail", customer);
                }
                else
                {
                    customer.UpdatedDate = DateTime.Now;
                    _context.Update(customer);
                    Customer.Add(customer);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer); // if validation failed
        }

        // TODO: replace hard delete logic with "isActive" property.
        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // TODO: replace hard delete logic with "isActive" property.
        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}