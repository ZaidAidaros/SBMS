using SBMS.Models.Users;
using SBMS.Repositories;
using SBMS.Views.Auth;
using System.Threading.Tasks;

namespace SBMS.Presenters
{
    class LogInVPres
    {
       private ILogInV iLogInV;

        private LogInVPres()
        {

            iLogInV = LogInV.GetInstance();
            iLogInV.LogIn += async delegate { await this.LogInAsync(); };

        }
        /// <summary>
        /// 
        /// </summary>
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
                LogInV.GetInstance().Close();
            }
            else
            {
                iLogInV.Message = repoResult.ErrorMsg;
            }
        }
        private void GoHome(UserM user)
        {
            if (user.PermissionId == 1 || user.PermissionId==2)
            {
                AdminHomeVPres.GetInstance(user);
            }
            else if(user.PermissionId == 3)
            {

            }
            else if (user.PermissionId == 4)
            {

            }
            else
            {
                iLogInV.Message ="Access Denaid";
            }

        }
    }
}
