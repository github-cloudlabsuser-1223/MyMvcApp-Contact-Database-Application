using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }

// Add this action to your UserController.cs

    [HttpGet]
    [Route("api/user/search")]
    public IActionResult Search(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            // Return all users if no name is provided
            var allUsers = userlist
                .Select(u => new { id = u.Id, name = u.Name, email = u.Email })
                .ToList();
            return Json(allUsers);
        }

        var users = userlist
            .Where(u => u.Name.Contains(name))
            .Select(u => new { id = u.Id, name = u.Name, email = u.Email })
            .ToList();

        return Json(users);
    }
        // GET: User/Index or User
        /*public ActionResult Index(string searchString)
        {
            var users = userlist;
            if (!string.IsNullOrEmpty(searchString))
            {
            users = userlist
                .Where(u => u.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) 
                     || u.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .ToList();
            }
            ViewBag.SearchString = searchString;
            return View(users);
        }*/
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
            // Assign a new Id (auto-increment)
            user.Id = userlist.Count > 0 ? userlist.Max(u => u.Id) + 1 : 1;
            userlist.Add(user);
            return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                //existingUser.Phone = user.Phone;
                // Add other properties as needed
                // If successful, it redirects to the Index action to display the updated list of users.
                return RedirectToAction(nameof(Index));
            }
            return View(user);
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            userlist.Remove(user);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            userlist.Remove(user);
            return RedirectToAction(nameof(Index));
        }
}
