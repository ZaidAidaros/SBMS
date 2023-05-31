using SBMS.Models.Users;
using SBMS.Presenters.PurchasesPres;
using SBMS.Presenters.SalesPres;
using SBMS.Repositories;
using SBMS.Views.Auth;
using SBMS.Views.Sales;
using System.Threading.Tasks;

namespace SBMS.Presenters
{
    class LogInVPres
    {
       private ILogInV iLogInV;

        private LogInVPres()
        {

            iLogInV = LogInV.GetInstance();
            iLogInV.LogIn += async delegate { await LogInAsync(); };
            iLogInV.OnDisposed +=  delegate { Dispose(); };

        }
        public static void Dispose()
        {
            instance = null;
        }
        private static LogInVPres instance;
        public static LogInVPres GetInstance()
        {
            if (instance == null) instance = new LogInVPres();
            return instance;
        }
        private async Task LogInAsync()
        {
            RepoResultM repoResult = await UsersRepo.LogInAsync(iLogInV.UName,iLogInV.UPassword);
            
            if (repoResult.IsSucess)
            {
                iLogInV.Message = "Log In Successfully...";
                GoHome((UserM)repoResult.ResData[0]);
                LogInV.GetInstance().Hide();
            }
            else
            {
                iLogInV.Message = repoResult.ErrorMsg;
            }
        }
        private void GoHome(UserM user)
        {
            if (user.PermissionId == 1)
            {
                AdminHomeVPres.GetInstance(user);
            }
            else if(user.PermissionId == 2)
            {
                SalesHVPres.GetInstance(user);
            }
            else if (user.PermissionId == 3)
            {
                PurchasesHVPres.GetInstance(user);
            }
            else
            {
                iLogInV.Message ="Access Denaid";
            }

        }
    }
}
