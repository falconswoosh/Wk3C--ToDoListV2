using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]               //define url
    public ActionResult Index() //send class with two strings to Hello.cshtml
    {

      return View();
    }
    [HttpGet("/categories")]
    public ActionResult Categories()
    {
      return View(Category.GetAll());
      //returns list obj of all categories in database
      //user can click on <li> entry in html to get specifics
    }

    [HttpGet("/categories/{id}")]
    public ActionResult CategoriesDetailed(int id)
    {
      Category myCategory  = Category.Find(id);
      return View(myCategory);
    }

    [HttpGet("/categories/new")]
    public ActionResult CategoriesNew()
    {
      return View();
    }
    [HttpPost("/categories")]
    public ActionResult CategoriesAdd()
    {
      Category latestCategory = new Category(Request.Form["CategoryName"]);
      latestCategory.Save();

      return View("Categories",Category.GetAll());
      //returns list obj of all categories in database
      //user can click on <li> entry in html to get specifics
    }
    [HttpGet("/categories/clear")]
    public ActionResult CategoriesClear()
    {
      Category.DeleteAll();
      return View();
    }

    [HttpGet("/tasks")]
    public ActionResult Tasks()
    {
      return View(Task.GetAll());
      //returns list obj of all categories in database
      //user can click on <li> entry in html to get specifics
    }

    [HttpGet("/tasks/{id}")]
    public ActionResult TasksDetailed(int id)
    {
      Task myTask  = Task.Find(id);
      return View(myTask);
    }

    [HttpGet("/tasks/new")]
    public ActionResult TasksNew()
    {
      return View();
    }
    [HttpPost("/tasks")]
    public ActionResult TasksAdd()
    {
      Console.WriteLine(Convert.ToDateTime(Request.Form["dueDate"]));
      Console.WriteLine();

      Task latestTask = new Task(Request.Form["taskDescription"], Convert.ToDateTime(Request.Form["dueDate"]).ToString("yyyy-MM-dd HH:mm:ss"));
      latestTask.Save();

      return View("Tasks",Task.GetAll());
      //returns list obj of all tasks in selected category
      //user can click on <li> entry in html to get specifics
    }

  }
}
