using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCcrud.Models
{
    public class Employee
    {
        public int Empid { get; set; } 
        public String Empname { get; set; }
        public String Email { get; set; }
        public String Salary { get; set; }
    }
}