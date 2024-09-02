using CsvHelper.Configuration;

namespace AvanSight.PharmaSL.PSL_101.RAW_Models
{
    /// <summary>
    /// Auto-generated class for PSL_101_IE_RAW
    /// Date created: 9/2/2024 11:08:37 AM
    /// DO NOT modify this class manually.
    /// </summary>
    public partial class PSL_101_IE_RAW
    {
        public string Project { get; set; }
        public string Subject_name_or_identifier { get; set; }
        public string DataPageName { get; set; }
        public string RecordDate { get; set; }
        public string SreenFail { get; set; }
        public string ScreenFail_Date { get; set; }
        public string ScreenFailReason { get; set; }
    }

    /// <summary>
    /// CsvHelper Mapper for PSL_101_IE_RAW
    /// </summary>
    public partial class PSL_101_IE_RAWCsvMapper : ClassMap<PSL_101_IE_RAW>
    {
        public PSL_101_IE_RAWCsvMapper()
        {
            Map(m => m.Project).Name("Project");
            Map(m => m.Subject_name_or_identifier).Name("Subject name or identifier");
            Map(m => m.DataPageName).Name("DataPageName");
            Map(m => m.RecordDate).Name("RecordDate");
            Map(m => m.SreenFail).Name("SreenFail");
            Map(m => m.ScreenFail_Date).Name("ScreenFail Date");
            Map(m => m.ScreenFailReason).Name("ScreenFailReason");
        }
    }
}
