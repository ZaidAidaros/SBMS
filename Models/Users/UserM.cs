using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.Models.Users
{
    class UserM
    {
        internal int Id { get; set; }
        internal int EmpId { get; set; }
        internal int PermissionId { get; set; }
        internal string Name { get; set; }
        internal string Password { get; set; }
    }
}
