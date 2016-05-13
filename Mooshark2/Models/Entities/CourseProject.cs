using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class CourseProject conteins all the informations that are needed in the database join table CourseProjects,
    /// wich conects the table Courses with the table Projects 
    /// </summary>
    public class CourseProject
    {
        public int ID { get; set; }

        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }

    }
}