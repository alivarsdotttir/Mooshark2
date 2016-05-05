﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.Entities
{
    public class CourseTeacher
    {
        public int ID { get; set; }

        //Foreign key for ApplicationUser
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }

        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

    }
}