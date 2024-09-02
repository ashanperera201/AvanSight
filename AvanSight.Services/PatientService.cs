using AvanSight.Models.DomainModels;
using AvanSight.DAL;
using System.Data;
using System.Data.SqlClient;

namespace AvanSight.Services
{
    public class PatientService
    {
        private readonly IDapperContext _dapperContext;

        public PatientService(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public void SavePatients(List<Patient> patients)
        {
          throw new NotImplementedException();
        }

    

        private DataTable ConvertToDataTable(List<Patient> patients)
        {
            throw new NotImplementedException();
        }
    }
}
