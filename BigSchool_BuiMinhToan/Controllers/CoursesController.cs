using BigSchool_BuiMinhToan.Models;
using BigSchool_BuiMinhToan.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool_BuiMinhToan.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbConttext;
        public CoursesController()
        {
            _dbConttext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDaTeTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbConttext.Courses.Add(course);
            _dbConttext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}