using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class Project contains all the informations that are needed in the database table Projects
    /// </summary>
    public class Project
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public System.DateTime Deadline { get; set; }
        public bool Graded { get; set; }
        public int Grade { get; set; }
        [Required]
        public bool Visibility { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The group size must be at least 1")]
        [Display(Name = "Group size")]
        public int GroupSize { get; set; }
        public bool IsGroupProject { get; set; }
        public int? CourseID { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }
    }
}