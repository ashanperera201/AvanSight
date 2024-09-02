namespace AvanSight.Models.DomainModels
{
    public class Pharma
    {
        public string PharmaName { get; set; }
        public string Country { get; set; }
        public List<Study> Studies { get; set; }

        public Pharma()
        {
            PharmaName = string.Empty;
            Country = string.Empty;
            Studies = [];
        }
    }
}
