using AvanSight.Models;
using AvanSight.Models.DomainModels;

namespace AvanSight.PharmaUSA
{
    public abstract class PUSA_DataCache : DataCacheBase
    {
        internal static int SeedStudyId = 101;
        internal static int SeedSubjectId = 101;
        internal const string AssemblyName = "AvanSight.PharmaUSA";
        internal const string PharmaTicker = "PharmaUSA";

        internal PUSA_DataCache(string RawModelNamespacePrefix) : base(AssemblyName, RawModelNamespacePrefix)
        {

        }

    }
}
