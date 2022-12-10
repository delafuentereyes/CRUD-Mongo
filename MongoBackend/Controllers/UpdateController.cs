using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoBackend.Models;
using MongoDB.Bson;
using System.Diagnostics;

namespace MongoBackend.Controllers
{
    public class UpdateController : Controller
    {
        private readonly ILogger<UpdateController> _logger;

        public UpdateController(ILogger<UpdateController> logger)
        {
            _logger = logger;
        }

        public IActionResult updateUser()
        {
            User user = new User()
            {
                _id = ObjectId.Parse("6393b83b9ee8de16a797d92a"),
                name = "Jesús De la Fuente",
                address = "Santiago",
                phone = 84648776,
                email = "jesus.dlf@gmail.com"

            };

            DatabaseHelper.Database db = new DatabaseHelper.Database();

            db.updateUser(user);

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
