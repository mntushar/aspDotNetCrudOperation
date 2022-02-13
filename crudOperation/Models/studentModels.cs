using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crudOperation.Models
{
    public class StudentModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string Email { get; set; }  
        public int DepartmentId { get; set; }
        public virtual DepartmentModels Department { get; set; }
        


    }
}