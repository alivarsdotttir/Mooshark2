﻿using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherIndexViewmodel
    {
        IEnumerable<Project> ungradedProjects;
        IEnumerable<Course> coursesForTeacher;

        public TeacherIndexViewmodel(IEnumerable<Project>u, IEnumerable<Course>c)
        {
            ungradedProjects = u;
            coursesForTeacher = c;
        }  
    }
}