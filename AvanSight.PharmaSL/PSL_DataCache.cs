using AvanSight.Models;
using AvanSight.Models.DomainModels;

namespace AvanSight.PharmaSL
{
    public abstract class PSLDataCache : DataCacheBase
    {
        internal static int SeedStudyId = 101;
        internal static int SeedSubjectId = 101;
        internal const string AssemblyName = "AvanSight.PharmaSL";
        internal const string PharmaTicker = "PharmaSL";

        internal PSLDataCache( string RawModelNamespacePrefix) : base(AssemblyName, RawModelNamespacePrefix)
        {

        }

    }
}
