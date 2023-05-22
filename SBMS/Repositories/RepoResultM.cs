using System.Collections.Generic;

namespace SBMS.Repositories
{
    public class RepoResultM
    {
        public bool IsSucess { get; set; }
        public string ErrorMsg { get; set; }
        public List<object> ResData { get; set; }
        public int EfectedRows { get; set; }
        public RepoResultM()
        {
            ResData = new List<object>();
        }
    }
}
