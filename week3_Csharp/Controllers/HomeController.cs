using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ProjectC.Models;

namespace ProjectC.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]               //define url
    public ActionResult Index() //send class with two strings to Hello.cshtml
    {
      return View();
    }
  }
}
