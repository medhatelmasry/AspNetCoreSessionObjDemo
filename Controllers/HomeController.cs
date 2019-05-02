using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionTest.Models;
using Newtonsoft.Json;

namespace SessionTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student()
            {
                StudentId = 1,
                FirstName = "Fred",
                LastName = "Smith",
                DateOfBirth = new DateTime(2010, 10, 22)
            };
            HttpContext.Session.SetString("student", JsonConvert.SerializeObject(student));
            return View();
        }

        public IActionResult Privacy()
        {
            string strStudent = HttpContext.Session.GetString("student");
            var student = JsonConvert.DeserializeObject<Student>(strStudent);
            return View(student);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
