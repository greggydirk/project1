﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using project1.Models;

namespace project1.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<Pengguna>pengguna { get; set; }
    }
}