using SBMS.Models.General;

namespace SBMS.Models.Stores
{
    public class ProdCategoryM : ICategoryM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public bool IsEqualTo(ProdCategoryM prodCategory)
        {
            if (this.Id == prodCategory.Id
                && this.Name == prodCategory.Name
                && this.Description == prodCategory.Description
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
