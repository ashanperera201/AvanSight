using AvanSight.Models.DomainModels;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Reflection;

namespace AvanSight.Models
{
    // Abstract base class for managing and loading data caches.
    public abstract class DataCacheBase
    {
        // Constants for directory structure and naming conventions
        private const string RawDataRootFolder = @"C:\AvanSight\";
        private const string RawListPropertySuffix = "_ITEMS";  // Suffix for the property holding the list of items
        private const string CsvMapperSuffix = "CsvMapper";    // Suffix for the CSV mapper class name

        // Property to hold the study object
        public Study Study { get; set; }

        // Abstract methods to be implemented by derived classes
        protected abstract Study SetUpStudy();           // Method to set up and return a Study object
        protected abstract List<Patient> LoadPatients(); // Method to load and return a list of patients

        // Fields for model assembly information
        protected string _assemblyName;
        protected string _rawModelNamespacePrefix;
        protected Type _type;

        // Constructor that initializes the assembly name, namespace prefix, and type of the derived class
        protected DataCacheBase(string assemblyName, string rawModelNamespacePrefix)
        {
            _assemblyName = assemblyName;
            _rawModelNamespacePrefix = rawModelNamespacePrefix;
            _type = this.GetType(); // Captures the runtime type of the derived class     
        }

        // Method to load raw data from CSV files and map them to the corresponding objects
        protected void LoadRawData(string ticker, string studyIdentifier)
        {
            Study = SetUpStudy();

            var innerUrl = Path.Combine(ticker, studyIdentifier, "DataSet");
            var fullPath = Path.Combine(RawDataRootFolder, innerUrl);
            var csvFiles = Directory.GetFiles(fullPath, "*.csv");

            foreach (var csvFilePath in csvFiles)
            {
                var className = Path.GetFileNameWithoutExtension(csvFilePath);
                var listPropertyName = className + RawListPropertySuffix;

                var listProperty = _type.GetProperty(listPropertyName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (listProperty != null)
                {
                    var listGenericType = listProperty.PropertyType.GetGenericArguments()[0];
                    var mapperTypeName = $"{listGenericType.FullName}{CsvMapperSuffix}";

                    var mapperType = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .SelectMany(a => a.GetTypes())
                                    .FirstOrDefault(t => t.FullName == mapperTypeName);

                    var method = typeof(DataCacheBase).GetMethod("ReadCsvItems", BindingFlags.Static | BindingFlags.NonPublic);

                    var genericMethod = method.MakeGenericMethod(listGenericType, mapperType);

                    var csvItems = genericMethod.Invoke(this, new object[] { csvFilePath });
                    listProperty.SetValue(this, csvItems);
                }
            }

            var patients = LoadPatients();
            Study.Patients = patients;
        }

        // Configuration for reading CSV files with CsvHelper
        private static readonly CsvConfiguration SingleHeaderRowConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,      // Indicates that the CSV file has a header row
            HeaderValidated = null,      // Disables header validation to avoid issues with non-standard headers
            PrepareHeaderForMatch = args => args.Header.Trim().ToLower(),  // Converts headers to lowercase for matching
        };

        // Static generic method to read and map CSV data to objects
        private static List<T> ReadCsvItems<T, TMap>(string rawDataFilePath) where TMap : ClassMap<T>
        {
            using (var reader = new StreamReader(rawDataFilePath))
            using (var csv = new CsvReader(reader, SingleHeaderRowConfig))
            {
                csv.Context.RegisterClassMap<TMap>();
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
