using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Mooshark2.Models.DAL;

namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class Submission contains all the informations that are needed in the database table Submissions
    /// </summary>
    public class Submission
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public bool Accepted { get; set; }
        public int SubprojectID { get; set; }

        [ForeignKey("SubprojectID")]
        public Subproject Subproject { get; set; }

        public int SubmissionNr { get; set; }

        public int Grade { get; set; }

        public string CppFileName { get; set; }

        public string FilePath { get; set; }
        public string Output { get; set; }
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}