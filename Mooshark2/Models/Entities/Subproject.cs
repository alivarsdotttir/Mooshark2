﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class Subproject contains all the informations that are needed in the database table Subprojects
    /// </summary>
    public class Subproject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }

        public int Weight { get; set; }
        public int Grade { get; set; }

        public string Input { get; set; }
        public string Output { get; set; }
    }
}