using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace crudOperation.Models
{
    public class UniversityDBContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
    }
}