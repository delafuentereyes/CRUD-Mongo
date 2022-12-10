using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoBackend.Models;
using System.Diagnostics;

namespace MongoBackend.Controllers
{
    public class DeleteController : Controller
    {
        private readonly ILogger<DeleteController> _logger;

        public DeleteController(ILogger<DeleteController> logger)
        {
            _logger = logger;
        }

        public IActionResult deleteUser()
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            User user = new User();

            db.deleteUser(user);

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
