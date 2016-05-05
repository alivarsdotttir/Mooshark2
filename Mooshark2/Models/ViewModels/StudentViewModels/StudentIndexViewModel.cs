﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.Entities;


namespace Mooshark2.Models.ViewModels
{
    public class StudentIndexViewModel
    {
        private IEnumerable<Project> upcomingProjects;
        private IEnumerable<Course> coursesForStudents;

        public StudentIndexViewModel(IEnumerable<Project> p, IEnumerable<Course> c)
        {
            upcomingProjects = p;
            coursesForStudents = c; 
        }
    }
}