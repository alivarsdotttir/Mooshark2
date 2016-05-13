using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class Group conteins all the informations that are needed in the database table Groups
    /// </summary>
    public class Group
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}