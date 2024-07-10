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
            var data = _context.Expenses.Find(id);
            _context.Expenses.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

    public IActionResult EditExpense(int id)
        {
            var data = _context.Expenses.Find(id);
            return View("CreateEditExpense", data);
        }
        public IActionResult CreateEditExpense()
        {
            return View();
        }
        public IActionResult SaveExpense(Expence model)
        {
           _context.Expenses.Add(model);
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
