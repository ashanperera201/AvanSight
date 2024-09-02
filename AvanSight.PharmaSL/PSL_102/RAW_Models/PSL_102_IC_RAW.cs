using CsvHelper.Configuration;

namespace AvanSight.PharmaSL.PSL_102.RAW_Models
{
    /// <summary>
    /// Auto-generated class for PSL_102_IC_RAW
    /// Date created: 9/2/2024 10:59:24 AM
    /// DO NOT modify this class manually.
    /// </summary>
    public partial class PSL_102_IC_RAW
    {
        public string ProjectID { get; set; }
        public string Subject_ID { get; set; }
        public string DataPageName { get; set; }
        public string Consent_Date { get; set; }
    }

    /// <summary>
    /// CsvHelper Mapper for PSL_102_IC_RAW
    /// </summary>
    public partial class PSL_102_IC_RAWCsvMapper : ClassMap<PSL_102_IC_RAW>
    {
        public PSL_102_IC_RAWCsvMapper()
        {
            Map(m => m.ProjectID).Name("ProjectID");
            Map(m => m.Subject_ID).Name("Subject ID");
            Map(m => m.DataPageName).Name("DataPageName");
            Map(m => m.Consent_Date).Name("Consent Date");
        }
    }
}
