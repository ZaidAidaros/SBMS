using SBMS.Models.Employees;

namespace SBMS.Models.Users
{
    public class UserM:IUserM
    {
        
        internal PermissionM Permissionm { get; set; }
        public IEmployeeM Employeem { get; set; }
        internal string Password { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Employee { get => this.Employeem.Name; set => this.Employeem.Name = value; }
        public string Permission { get => this.Permissionm.Name; set => this.Permissionm.Name = value; }

        public UserM()
        {
            Permissionm = new PermissionM();
            Employeem = new EmployeeM();
        }
    }
    interface IUserM
    {
        int Id { get; set; }
        string Name { get; set; }
        string Employee { get; set; }
        string Permission { get; set; }
    }
}
