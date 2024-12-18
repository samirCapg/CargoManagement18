﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementDataAccess.Entity.Models
{
    public class Employee : EmployeeLoginModel
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string UserName { get; set; }

        public string EmpName { get; set; }

        [Range(1000000000, 9999999999,
           ErrorMessage = "Mobile no should be 10 digits")]
        public string EmpPhNo { get; set; }
        [Required]
        [EmailAddress]
        public string EmpEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [DefaultValue("Empl@123")]
        public string Password { get; set; }
        // [Required]

    }

    public class EmployeeLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DefaultValue("Empl@123")]
        public string Password { get; set; }
        [DefaultValue(-1)]
        public int IsApproved { get; set; }
    }
}
