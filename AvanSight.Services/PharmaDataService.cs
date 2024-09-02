using AvanSight.Models;
using AvanSight.Models.DomainModels;
using System.Reflection;

namespace AvanSight.Services
{
    public class PharmaDataService
    {
        private readonly List<Pharma> _pharmaList;

        public PharmaDataService()
        {
            _pharmaList = new List<Pharma>();
        }

        public void PreparePharmaData()
        {
            // Use relative paths to load the assemblies
            var assembliesToSearch = new List<Assembly>
            {
                Assembly.LoadFrom(@"..\AvanSight.PharmaSL\bin\Debug\net8.0\AvanSight.PharmaSL.dll"),  // Load the assembly for PharmaSL
                //Assembly.LoadFrom(@"..\AvanSight.PharmaUSA\bin\Debug\net8.0\AvanSight.PharmaUSA.dll")  // Load the assembly for PharmaUSA
            };

            foreach (var assembly in assembliesToSearch)
            {
                var pharmaDataTypes = assembly.GetTypes()
                   .Where(t => t.IsSubclassOf(typeof(PharmaDataBase)) && !t.IsAbstract);

                foreach (var pharmaDataType in pharmaDataTypes)
                {
                    var pharmaDataInstance = (PharmaDataBase)Activator.CreateInstance(pharmaDataType);
                    pharmaDataInstance.InitializeData();
                    _pharmaList.AddRange(pharmaDataInstance.GetPharmaList());
                }
            }
        }


        public List<Pharma> GetPharmaList()
        {
            return _pharmaList;
        }
    }

}
