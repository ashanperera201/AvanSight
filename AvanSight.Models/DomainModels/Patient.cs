using AvanSight.Models.Enums;

namespace AvanSight.Models.DomainModels
{
    public class Patient
    {
        public string PatientIdentifier { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public Race Race { get; set; }

        public DateTime DateOfConcent { get; set; }

        public string? ScreenFailiureReason { get; set; }

        public DateTime? ScreenFailedDate { get; set; }

        public string StudyIdentifier { get; set; }

        public Patient()
        {
            PatientIdentifier = string.Empty;
            Age = 0;
            Gender = Gender.Unknown;
            Race = Race.Unknown;
            DateOfConcent = DateTime.MinValue;
            StudyIdentifier = string.Empty;
        }

    }
}
