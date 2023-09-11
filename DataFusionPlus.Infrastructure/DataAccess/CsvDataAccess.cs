using CsvHelper;
using CsvHelper.Configuration;
using DataFusionPlus.Infrastructure.Dto;
using System.Globalization;

namespace DataFusionPlus.Infrastructure.DataAccess;

public class CsvDataAccess
{
    public IEnumerable<ProductCsvDto> ReadDataFromCSV(string filePath)
    {
        // Create a configuration for CsvHelper
        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);

        // Initialize a list to store the parsed products
        var products = new List<ProductCsvDto>();

        // Read the CSV file
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, csvConfiguration))
        {
            // Read and map each row to the Product class
            products = csv.GetRecords<ProductCsvDto>().ToList();
        }

        return products;
    }
}
