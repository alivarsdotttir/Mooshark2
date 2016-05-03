using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    public class Submission
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public bool Accepted { get; set; }
        public int SubprojectID { get; set; }

        [ForeignKey("SubprojectID")]
        public Subproject Subproject { get; set; }

    }
}