using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels
{
    public class StudentCourseViewModel
    {
        List<Project> projectsForCourse;
        List<ApplicationUser> teacherForCourse;
    }
}