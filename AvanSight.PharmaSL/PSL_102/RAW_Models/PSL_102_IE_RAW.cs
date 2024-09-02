using CsvHelper.Configuration;

namespace AvanSight.PharmaSL.PSL_102.RAW_Models
{
    /// <summary>
    /// Auto-generated class for PSL_102_IE_RAW
    /// Date created: 9/2/2024 10:59:24 AM
    /// DO NOT modify this class manually.
    /// </summary>
    public partial class PSL_102_IE_RAW
    {
        public string Project { get; set; }
        public string Subject_name_or_identifier { get; set; }
        public string DataPageName { get; set; }
        public string RecordDate { get; set; }
        public string SreenFail { get; set; }
        public string ScreenFailDat { get; set; }
        public string ScreenFailReason { get; set; }
    }

    /// <summary>
    /// CsvHelper Mapper for PSL_102_IE_RAW
    /// </summary>
    public partial class PSL_102_IE_RAWCsvMapper : ClassMap<PSL_102_IE_RAW>
    {
        public PSL_102_IE_RAWCsvMapper()
        {
            Map(m => m.Project).Name("Project");
            Map(m => m.Subject_name_or_identifier).Name("Subject name or identifier");
            Map(m => m.DataPageName).Name("DataPageName");
            Map(m => m.RecordDate).Name("RecordDate");
            Map(m => m.SreenFail).Name("SreenFail");
            Map(m => m.ScreenFailDat).Name("ScreenFailDat");
            Map(m => m.ScreenFailReason).Name("ScreenFailReason");
        }
    }
}
