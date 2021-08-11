using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entityframeworkcoremvc.Models
{
    public class EmpDbContext : DbContext
    {

        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {

        }
        public DbSet<Emp> Emps { get; set; }
    }
}
