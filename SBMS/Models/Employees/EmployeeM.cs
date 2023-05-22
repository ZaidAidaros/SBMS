using SBMS.Models.General;
using System;

namespace SBMS.Models.Employees
{
    class EmployeeM:IEmployeeM
    {
        public GenderM Genderm { get; set; }
        public JobM Jobm { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int NIC { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public string Note { get; set; }
        public string Gender { get => this.Genderm.Name; set => this.Genderm.Name = value; }
        public string Job { get => this.Jobm.Name; set => this.Jobm.Name = value; }
        
        public EmployeeM()
        {
            Genderm = new GenderM();
            Jobm = new JobM();
        }
    }
    public interface IEmployeeM
    {
        int Id { get; set; }
        string Name { get; set; }
        int NIC { get; set; }
        DateTime BirthDate { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        decimal Salary { get; set; }
        string Note { get; set; }
        string Gender { get; set; }
        string Job { get; set; }
    }
}
