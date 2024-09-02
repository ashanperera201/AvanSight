using AvanSight.Models.DomainModels;
using AvanSight.Models.Enums;
using AvanSight.PharmaSL.PSL_102.RAW_Models;

namespace AvanSight.PharmaSL.PSL_102
{
    public class PSL_102_DataCache : PSLDataCache
    {
        private const string StudyIdentifier = "PSL_102";
        private const string RawModelNamespacePrefix = "AvanSight.PharmaSL.PSL_102.RAW_Models.";

        #region RAW DATA LISTS
        public List<PSL_102_DM_RAW> PSL_102_DM_RAW_ITEMS { get; private set; }
        public List<PSL_102_IC_RAW> PSL_102_IC_RAW_ITEMS { get; private set; }
        public List<PSL_102_IE_RAW> PSL_102_IE_RAW_ITEMS { get; private set; }

        #endregion


        public PSL_102_DataCache():base(RawModelNamespacePrefix)
        {
            LoadRawData(PharmaTicker, StudyIdentifier);
        }

        protected override Study SetUpStudy()
        {
            int currentStudyId = SeedStudyId++;
            return new Study
            {
                Id = currentStudyId,
                StudyIdentifier = StudyIdentifier,
            };
        }


        protected override List<Patient> LoadPatients()
        {
            var patients = new List<Patient>();

            foreach (var icRecord in PSL_102_IC_RAW_ITEMS)
            {
                var dmRecord = PSL_102_DM_RAW_ITEMS.FirstOrDefault(d => d.Subject == icRecord.Subject_ID);
                var ieRecord = PSL_102_IE_RAW_ITEMS.FirstOrDefault(e => e.Subject_name_or_identifier == icRecord.Subject_ID);

                if (dmRecord != null && ieRecord != null)
                {
                    var patient = new Patient
                    {
                        PatientIdentifier = icRecord.Subject_ID,
                        Age = string.IsNullOrEmpty(dmRecord.Age) ? 0 : int.Parse(dmRecord.Age),
                        Gender = Enum.TryParse<Gender>(dmRecord.Sex, true, out var gender) ? gender : Gender.Unknown,
                        Race = Enum.TryParse<Race>(dmRecord.Race, true, out var race) ? race : Race.Unknown,
                        StudyIdentifier = StudyIdentifier,
                        DateOfConcent = DateTime.Parse(ieRecord.RecordDate),
                        ScreenFailiureReason = ieRecord.ScreenFailReason
                    };

                    patients.Add(patient);
                }
            }
            return patients;
        }
    }
}
