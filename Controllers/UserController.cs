using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

    // GET: User
    public ActionResult Index(string? query)
    {
        if (!string.IsNullOrWhiteSpace(query))
        {
            var results = userlist.Where(u => (u.Name != null && u.Name.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                                              (u.Email != null && u.Email.Contains(query, StringComparison.OrdinalIgnoreCase)))
                                  .ToList();
            ViewBag.Query = query;
            return View(results);
        }
        ViewBag.Query = query;
        return View(userlist);
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();
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
            user.Id = userlist.Count > 0 ? userlist.Max(u => u.Id) + 1 : 1;
            userlist.Add(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();
        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {
        var existingUser = userlist.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
            return NotFound();
        if (ModelState.IsValid)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            return RedirectToAction("Index");
        }
        return View(user);
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();
        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();
        userlist.Remove(user);
        return RedirectToAction("Index");
    }

    // GET: User/Search
    public ActionResult Search(string query)
    {
        var results = string.IsNullOrWhiteSpace(query)
            ? userlist
            : userlist.Where(u => (u.Name != null && u.Name.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                                  (u.Email != null && u.Email.Contains(query, StringComparison.OrdinalIgnoreCase)))
                      .ToList();
        ViewBag.Query = query;
        return View("Index", results);
    }
}
