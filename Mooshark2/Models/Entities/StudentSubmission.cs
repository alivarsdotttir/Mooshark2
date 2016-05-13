using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class StudentSubmission contains all the informations that are needed in the database table StudentSubmissions,
    /// wich connects the table Students with the table Submissions
    /// </summary>
    public class StudentSubmission
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }

        public int SubmissionID { get; set; }

        [ForeignKey("SubmissionID")]
        public Submission Submission { get; set; }

    }
}