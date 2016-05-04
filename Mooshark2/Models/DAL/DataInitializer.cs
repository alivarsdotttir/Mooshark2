using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.DAL
{
    public class DataInitializer  : System.Data.Entity.CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
     
        }
    }
}