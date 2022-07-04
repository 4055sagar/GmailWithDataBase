using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GmailWithDataBase.Models
{
    public class EmployeeModel
    {
        [Required]
        [Key]
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Hobby { get; set; }

        public double Salary { get; set; }
        public string EmailId { get; set; }
        public string Qualification { get; set; }
    }
}
