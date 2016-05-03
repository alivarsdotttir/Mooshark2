using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    public class InputOutput
    {
        public int ID { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public int SubprojectID { get; set; }

        [ForeignKey("SubprojectID")]
        public Subproject Subproject { get; set; }
    }
}