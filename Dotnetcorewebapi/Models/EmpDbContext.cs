﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnetcorewebapi.Models
{
    public class EmpDbContext:DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options):base(options)
        {

        }
        public DbSet<Employees> Emps { get; set; }
    }
}
