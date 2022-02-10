using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace crudOperation.Models.ModelsContext
{
    public class UniversityDBContext : DbContext
    {
        public DbSet<StudentModels> Student { get; set; }
    }
}