using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Models.DAL;
using Mooshark2.Services;


namespace Mooshark2.Controllers
{
    public class BaseController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public CourseService courseService = new CourseService();
        public UserService userService = new UserService();
        public ProjectService projectService = new ProjectService();



    }
}