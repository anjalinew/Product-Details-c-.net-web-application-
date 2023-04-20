using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ProductDetails.Models;


namespace ProductDetails.Controllers
{
    public class UserController : Controller
    {
        private readonly ProductsContext _context;

        public UserController(ProductsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            User mobj = new User();
            return View(mobj);
        }
       
        // POST: User/Login
        [HttpPost]
        public IActionResult Login(User mobj)
        {
            ProductsContext cobj = new ProductsContext();
           
            var status = cobj.Users.Where(m => m.UserId == mobj.UserId && m.Password == mobj.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("Index", "Order");
            }
            return View(mobj);
        }

        // GET: User/register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Save the user to the database
                // Save the user to the database
                var productContext = new ProductsContext();
                productContext.Users.Add(user);
                productContext.SaveChanges();
                // Add a success message to TempData
                TempData["Message"] = "Registration successful!";

                // Redirect to the login page
                return RedirectToAction("Login");
            }
            else
            {
                // If there are validation errors, redisplay the form
                return View(user);
            }
        }


    }
}

