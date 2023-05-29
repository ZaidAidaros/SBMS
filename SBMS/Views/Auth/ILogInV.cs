using SBMS.Models.Users;
using System;

namespace SBMS.Views.Auth
{
    public interface ILogInV
    {
         string UName { get; set; }
         string UPassword { get; set; }
         string Message { get; set; }

        //Events
        event EventHandler LogIn;
        event EventHandler OnDisposed;
    }
}
