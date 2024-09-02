using CsvHelper.Configuration;

namespace AvanSight.PharmaSL.PSL_102.RAW_Models
{
    /// <summary>
    /// Auto-generated class for PSL_102_DM_RAW
    /// Date created: 9/2/2024 10:59:24 AM
    /// DO NOT modify this class manually.
    /// </summary>
    public partial class PSL_102_DM_RAW
    {
        public string ProjectID { get; set; }
        public string Subject { get; set; }
        public string DataPageName { get; set; }
        public string YOB { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
    }

    /// <summary>
    /// CsvHelper Mapper for PSL_102_DM_RAW
    /// </summary>
    public partial class PSL_102_DM_RAWCsvMapper : ClassMap<PSL_102_DM_RAW>
    {
        public PSL_102_DM_RAWCsvMapper()
        {
            Map(m => m.ProjectID).Name("ProjectID");
            Map(m => m.Subject).Name("Subject");
            Map(m => m.DataPageName).Name("DataPageName");
            Map(m => m.YOB).Name("YOB");
            Map(m => m.Age).Name("Age");
            Map(m => m.Sex).Name("Sex");
            Map(m => m.Race).Name("Race");
        }
    }
}
