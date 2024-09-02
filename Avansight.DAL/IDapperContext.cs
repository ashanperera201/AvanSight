using System.Data;

namespace AvanSight.DAL
{
    public interface IDapperContext
    {
        void SavePatients(DataTable patients);
    }
}
