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
                LogInV.GetInstance().Close();
                new AdminHomeVPres((UserM)repoResult.ResData[0]);
            }
            else
            {
                iLogInV.Message = repoResult.ErrorMsg;
            }
        }
    }
}
