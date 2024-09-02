using AvanSight.Models;
using AvanSight.Models.DomainModels;
using AvanSight.PharmaSL.PSL_101;
using AvanSight.PharmaSL.PSL_102;

namespace AvanSight.PharmaSL
{ 
    public class PSL_Study_Data : PharmaDataBase
    {
        public override void InitializeData()
        {
            var psl101DataCache = new PSL_101_DataCache();
            var psl102DataCache = new PSL_102_DataCache();

            var pharma = new Pharma
            {
                PharmaName = "Hemas",
                Country = "Sri Lanka",
                Studies = new List<Study> { psl101DataCache.Study, psl102DataCache.Study }
            };

            AddPharma(pharma);
        }
    }
}

