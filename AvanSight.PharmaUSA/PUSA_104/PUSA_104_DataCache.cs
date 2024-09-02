using AvanSight.Models.DomainModels;

namespace AvanSight.PharmaUSA.PUSA_104
{
    public class PUSA_104_DataCache : PUSA_DataCache
    {
        private const string StudyIdentifier = "PUSA-104";
        private const string RawModelNamespacePrefix = "AvanSight.PharmaSL.PUSA_104.RAW_Models.";


        #region RAW DATA LISTS




        #endregion


        public PUSA_104_DataCache():base(RawModelNamespacePrefix)
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
