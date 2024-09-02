using CsvHelper.Configuration;

namespace AvanSight.PharmaSL.PSL_101.RAW_Models
{
    /// <summary>
    /// Auto-generated class for PSL_101_IC_RAW
    /// Date created: 9/2/2024 11:08:37 AM
    /// DO NOT modify this class manually.
    /// </summary>
    public partial class PSL_101_IC_RAW
    {
        public string Project { get; set; }
        public string Subject { get; set; }
        public string DataPageName { get; set; }
        public string Date_of_Consent { get; set; }
    }

    /// <summary>
    /// CsvHelper Mapper for PSL_101_IC_RAW
    /// </summary>
    public partial class PSL_101_IC_RAWCsvMapper : ClassMap<PSL_101_IC_RAW>
    {
        public PSL_101_IC_RAWCsvMapper()
        {
            Map(m => m.Project).Name("Project");
            Map(m => m.Subject).Name("Subject");
            Map(m => m.DataPageName).Name("DataPageName");
            Map(m => m.Date_of_Consent).Name("Date of Consent");
        }
    }
}
