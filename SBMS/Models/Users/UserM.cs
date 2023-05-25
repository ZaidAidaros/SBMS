using SBMS.Models.Employees;

namespace SBMS.Models.Users
{
    public class UserM
    {
        
        
        internal string Password { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Employee { get; set; }
        public int EmployeeId { get; set; }
        public string Permission { get; set; }
        public int PermissionId { get; set; }

        public UserM()
        {
        }
    }
   
}
