using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crudOperation.Models
{
    public class DepartmentModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual List<StudentModels> Students { get; set; }

    }
}