using Microsoft.AspNetCore.Mvc;
using CRUD_Mongo.Models;
using System.Diagnostics;

namespace CRUD_Mongo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            db.insertUser(new User()
            {
                name = "Jason Thibodeax",
                email = "jason.thi@gmail.com",
                phone = 60002361,
                address = "Seattle",
                dateIn = DateTime.Now
            });

            ViewBag.UserList = db.getUsers();

            return View();
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