﻿using Mooshark2.Models;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Services
{
    public class ProjectService
    {
        private ApplicationDbContext db;


        public ProjectService()
        {
            db = new ApplicationDbContext();
        }
    }
}