using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApICoreLearn.Model
{
    public class EployeeContext : DbContext
    {
        public EployeeContext(DbContextOptions<EployeeContext> options) : base(options)
        {

        }
        public DbSet<TblEmployee> TblEmployees { get; set; }
        public DbSet<TblDesignation> TblDesignations { get; set; }
    }
}
