using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Employees
{
    class EmployeeM
    {
        internal int Id { get; set; }
        internal int JobTItlId { get; set; }
        internal int AccountId { get; set; }
        internal int GenderId { get; set; }
        internal string Name { get; set; }
        internal int NIC { get; set; }
        internal string address { get; set; }
        internal string Note { get; set; }
        internal DateTime BirtDate { get; set; }
        internal decimal Salary { get; set; }
        
    }
}
