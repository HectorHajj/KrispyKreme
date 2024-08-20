using KrispyKreme1.Models;
using KrispyKreme1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace KrispyKreme1.Controllers
{
    public class HomeController : Controller
    {
        private readonly KrispyKremeNetFrameworkEntities db = new KrispyKremeNetFrameworkEntities();

        /// <summary>
        /// Displays the home page.
        /// </summary>
        /// <returns>The home page view.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays the successful sale page.
        /// </summary>
        /// <returns>The successful sale view.</returns>
        public ActionResult SuccessfulSale()
        {
            return View();
        }

        /// <summary>
        /// Displays the store page with a list of donuts.
        /// </summary>
        /// <returns>The store view with a sale view model.</returns>
        public ActionResult Store()
        {
            PopulateDonutsViewBag();
            return View(new SaleViewModel());
        }

        /// <summary>
        /// Displays the dashboard with sales data.
        /// </summary>
        /// <returns>The dashboard view.</returns>
        public ActionResult Dashboard()
        {
            var sales = GetSalesData();
            ViewBag.Sales = sales;
            PopulateDonutsViewBag();
            return View();
        }

        /// <summary>
        /// Retrieves donut sales with quantity greater than 10 for a specific donut.
        /// </summary>
        /// <param name="donutId">The ID of the donut.</param>
        /// <returns>A JSON result containing the sales data.</returns>
        public JsonResult GetDonutSales(int donutId)
        {
            var sales = db.Sales
                .Where(s => s.DonutId == donutId && s.Quantity > 10)
                .AsEnumerable()
                .Select(s => new
                {
                    CustomerName = s.Customer.Name,
                    s.Quantity,
                    SaleDate = s.SaleDate.ToString("dd/MM/yyyy")
                })
                .ToList();

            return Json(sales, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Submits a sale and redirects to the successful sale page if valid.
        /// </summary>
        /// <param name="model">The sale view model containing sale data.</param>
        /// <returns>The successful sale view or the store view with validation errors.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitSale(SaleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDonutsViewBag();
                return View("Store", model);
            }

            var customer = GetOrCreateCustomer(model.CustomerName, model.CustomerAddress);
            CreateAndSaveSale(model, customer.Id);

            return RedirectToAction("SuccessfulSale");
        }

        /// <summary>
        /// Retrieves sales data including customer and donut information, ordered by sale date.
        /// </summary>
        /// <returns>A list of sales data.</returns>
        private List<Sale> GetSalesData()
        {
            return db.Sales
                .Include(s => s.Customer)
                .Include(s => s.Donut)
                .OrderByDescending(s => s.SaleDate)
                .ToList();
        }

        /// <summary>
        /// Retrieves an existing customer or creates a new one.
        /// </summary>
        /// <param name="customerName">The name of the customer.</param>
        /// <param name="customerAddress">The address of the customer.</param>
        /// <returns>The existing or new customer.</returns>
        private Customer GetOrCreateCustomer(string customerName, string customerAddress)
        {
            var existingCustomer = db.Customers
                .FirstOrDefault(c => c.Name == customerName && c.Address == customerAddress);

            if (existingCustomer != null)
            {
                return existingCustomer;
            }

            return CreateNewCustomer(customerName, customerAddress);
        }

        /// <summary>
        /// Creates a new customer and saves it to the database.
        /// </summary>
        /// <param name="customerName">The name of the customer.</param>
        /// <param name="customerAddress">The address of the customer.</param>
        /// <returns>The newly created customer.</returns>
        private Customer CreateNewCustomer(string customerName, string customerAddress)
        {
            var newCustomer = new Customer
            {
                Name = customerName,
                Address = customerAddress
            };

            db.Customers.Add(newCustomer);
            db.SaveChanges();

            return newCustomer;
        }

        /// <summary>
        /// Creates and saves a sale.
        /// </summary>
        /// <param name="model">The sale view model containing sale data.</param>
        /// <param name="customerId">The ID of the customer.</param>
        private void CreateAndSaveSale(SaleViewModel model, int customerId)
        {
            var sale = new Sale
            {
                CustomerId = customerId,
                DonutId = model.DonutId,
                Quantity = model.Quantity,
                SaleDate = DateTime.Now
            };

            db.Sales.Add(sale);
            db.SaveChanges();
        }

        /// <summary>
        /// Populates the ViewBag with a list of donuts.
        /// </summary>
        private void PopulateDonutsViewBag()
        {
            ViewBag.Donuts = db.Donuts.ToList();
        }
    }
}
