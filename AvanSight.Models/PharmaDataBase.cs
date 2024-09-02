using AvanSight.Models.DomainModels;

namespace AvanSight.Models
{
    public abstract class PharmaDataBase
    {
        private readonly List<Pharma> _pharmaList;

        protected PharmaDataBase()
        {
            _pharmaList = new List<Pharma>();
        }

        protected void AddPharma(Pharma pharma)
        {
            _pharmaList.Add(pharma);
        }

        public List<Pharma> GetPharmaList()
        {
            return _pharmaList;
        }

        public abstract void InitializeData();

    }
}
