using AvanSight.Models.DomainModels;

namespace AvanSight.PharmaUSA.PUSA_103
{
    public class PUSA_103_DataCache : PUSA_DataCache
    {
        private const string StudyIdentifier = "PUSA-103";
        private const string RawModelNamespacePrefix = "AvanSight.PharmaSL.PUSA_103.RAW_Models.";


        #region RAW DATA LISTS




        #endregion


        public PUSA_103_DataCache(): base(RawModelNamespacePrefix)
        {
            LoadRawData(PharmaTicker, StudyIdentifier);
        }

        protected override Study SetUpStudy()
        {
            throw new NotImplementedException();
        }


        protected override List<Patient> LoadPatients()
        {
            throw new NotImplementedException();
        }
    }
}
