using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime Deadline { get; set; }
        public bool Graded { get; set; }
        public bool Visibility { get; set; }
        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }
    }
}