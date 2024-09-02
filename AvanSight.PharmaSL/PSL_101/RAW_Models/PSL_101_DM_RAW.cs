using CsvHelper.Configuration;

namespace AvanSight.PharmaSL.PSL_101.RAW_Models
{
    /// <summary>
    /// Auto-generated class for PSL_101_DM_RAW
    /// Date created: 9/2/2024 11:08:37 AM
    /// DO NOT modify this class manually.
    /// </summary>
    public partial class PSL_101_DM_RAW
    {
        public string Project { get; set; }
        public string Subject_name_or_identifier { get; set; }
        public string DataPageName { get; set; }
        public string DOB { get; set; }
        public string AGE { get; set; }
        public string SEX { get; set; }
        public string RACE { get; set; }
    }

    /// <summary>
    /// CsvHelper Mapper for PSL_101_DM_RAW
    /// </summary>
    public partial class PSL_101_DM_RAWCsvMapper : ClassMap<PSL_101_DM_RAW>
    {
        public PSL_101_DM_RAWCsvMapper()
        {
            Map(m => m.Project).Name("Project");
            Map(m => m.Subject_name_or_identifier).Name("Subject name or identifier");
            Map(m => m.DataPageName).Name("DataPageName");
            Map(m => m.DOB).Name("DOB");
            Map(m => m.AGE).Name("AGE");
            Map(m => m.SEX).Name("SEX");
            Map(m => m.RACE).Name("RACE");
        }
    }
}
