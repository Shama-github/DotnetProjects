using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetFramwrkmvc.Models
{
    public class EmpDbcontext:IdentityDbContext
    {
        public EmpDbcontext(DbContextOptions<EmpDbcontext> options) : base(options)
        {

        }
        public DbSet<Emp> Emps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
