namespace SBMS.Models.Stores
{
    public class ProdUnitM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbole { get; set; }
        public string SubUnitName { get; set; }
        public string SubUnitSymbole { get; set; }
        public string Description { get; set; }
        public int RateMainBranch { get; set; }
        public bool IsEqualTo(ProdUnitM prodUnitM)
        {
            if (this.Id == prodUnitM.Id
                && this.Name == prodUnitM.Name
                && this.SubUnitName == prodUnitM.SubUnitName
                && this.Description == prodUnitM.Description
                && this.Symbole == prodUnitM.Symbole
                && this.SubUnitSymbole == prodUnitM.SubUnitSymbole
                && this.RateMainBranch == prodUnitM.RateMainBranch
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
