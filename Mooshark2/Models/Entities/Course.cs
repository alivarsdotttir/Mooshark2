using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.Entities
{
    /// <summary>
    /// The class Course contains all the informations that are needed in the database table Courses
    /// </summary>
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

    }
}