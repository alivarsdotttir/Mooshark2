using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    public class Subproject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }

        public int Weight { get; set; }

    }
}