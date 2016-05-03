using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    public class ProjectGroup
    {
        public int ID { get; set; }
        public int GroupID { get; set; }

        [ForeignKey("GroupID")]
        public Group Group { get; set; }

        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
    }
}