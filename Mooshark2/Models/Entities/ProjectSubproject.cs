using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class ProjectSubproject conteins all the informations that are needed in the database table ProjectSubprojects,
    /// wich conects the table Projects with the table Subproject
    /// </summary>
    public class ProjectSubproject
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
        public int SubprojectID { get; set; }

        [ForeignKey("SubprojectID")]
        public Subproject Subproject { get; set; }
    }
}