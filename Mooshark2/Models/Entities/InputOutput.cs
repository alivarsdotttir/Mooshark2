using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class InputOutput conteins all the informations that are needed in the database table InputOutputs
    /// wich conects to the table Subprojects
    /// </summary>
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