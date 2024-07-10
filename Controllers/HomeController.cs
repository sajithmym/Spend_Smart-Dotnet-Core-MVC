using Microsoft.AspNetCore.Mvc;
using Spend_Smart.Models;
using System.Diagnostics;

namespace Spend_Smart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // add _context for use db
        private readonly ExpenseDBContex _context;

        public HomeController(ILogger<HomeController> logger, ExpenseDBContex context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var data = _context.Expenses.ToList();
            return View(data);
        }
        public IActionResult DeleteExpense(int id)
        {
            var record = _context.Expenses.Find(id);
            _context.Expenses.Remove(record);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                var record = _context.Expenses.Find(id);
                return View(record);
            }
            return View();
        }
        public IActionResult SaveExpense(Expence model)
        {
            if (model.Id == 0) 
                _context.Expenses.Add(model);
            else
                _context.Expenses.Update(model);

            _context.SaveChanges();

           return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
