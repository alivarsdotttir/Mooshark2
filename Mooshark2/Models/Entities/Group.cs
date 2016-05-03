using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mooshark2.Models.Entities
{
    public class Group
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}