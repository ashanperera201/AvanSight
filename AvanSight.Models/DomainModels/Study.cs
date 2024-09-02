namespace AvanSight.Models.DomainModels
{
    public class Study
    {
        public int Id { get; set; }
        public string StudyIdentifier { get; set; }
        public string ProjectNumber { get; set; }
        public string StudyName { get; set; }
        public List<Patient> Patients { get; set; }

    }
}
