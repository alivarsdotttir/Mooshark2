using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.Entities
{
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