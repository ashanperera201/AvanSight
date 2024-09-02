using AvanSight.Models.DomainModels;
using AvanSight.Models.Enums;
using AvanSight.PharmaSL.PSL_101.RAW_Models;

//using AvanSight.PharmaSL.PSL_101.RAW_Models;
using System;

namespace AvanSight.PharmaSL.PSL_101
{
    public class PSL_101_DataCache : PSLDataCache
    {
        private const string StudyIdentifier = "PSL_101";
        private const string RawModelNamespacePrefix = "AvanSight.PharmaSL.PSL_101.RAW_Models.";
        

        #region RAW DATA LISTS
        public List<PSL_101_DM_RAW> PSL_101_DM_RAW_ITEMS { get; private set; }
        public List<PSL_101_IC_RAW> PSL_101_IC_RAW_ITEMS { get; private set; }
        public List<PSL_101_IE_RAW> PSL_101_IE_RAW_ITEMS { get; private set; }
        #endregion

        public PSL_101_DataCache() : base(RawModelNamespacePrefix)
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

            foreach (var icRecord in PSL_101_IC_RAW_ITEMS)
            {
                var dmRecord = PSL_101_DM_RAW_ITEMS.FirstOrDefault(d => d.Subject_name_or_identifier == icRecord.Subject);
                var ieRecord = PSL_101_IE_RAW_ITEMS.FirstOrDefault(e => e.Subject_name_or_identifier == icRecord.Subject);

                if (dmRecord != null && ieRecord != null)
                {
                    var patient = new Patient
                    {
                        PatientIdentifier = icRecord.Subject,
                        Age = string.IsNullOrEmpty(dmRecord.AGE) ? 0 : int.Parse(dmRecord.AGE),
                        Gender = Enum.TryParse<Gender>(dmRecord.SEX, true, out var gender) ? gender : Gender.Unknown,
                        Race = Enum.TryParse<Race>(dmRecord.RACE, true, out var race) ? race : Race.Unknown,
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
