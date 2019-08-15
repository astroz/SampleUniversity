using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleUniversity.Models {
    public class SchoolContext : DbContext {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options) {
        }

        public DbSet<SampleUniversity.Models.Student> Student { get; set; }
    }
}