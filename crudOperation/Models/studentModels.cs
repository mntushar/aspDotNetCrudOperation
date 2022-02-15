using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudOperation.Models
{
    public class StudentModels
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RegNo { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public virtual DepartmentModels Department { get; set; }
        


    }
}