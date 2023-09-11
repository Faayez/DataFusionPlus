using DataFusionPlus.Application.Interfaces;
using DataFusionPlus.Application.Services;
using DataFusionPlus.Infrastructure.DataAccess;
using DataFusionPlus.Infrastructure.Dto;

namespace DataFusionPlus.Application.FactoryPattern;

public class ConcreteProductDataFactory : IProductDataFactory
{
    private readonly ExcelDataAccess _excelDataAccess;
    private readonly CsvDataAccess _csvDataAccess;
    private readonly ApplicationSettings _applicationSettings;

    public ConcreteProductDataFactory(ExcelDataAccess excelDataAccess, CsvDataAccess csvDataAccess, ApplicationSettings applicationSettings)
    {
        _excelDataAccess = excelDataAccess;
        _csvDataAccess = csvDataAccess;
        _applicationSettings = applicationSettings;
    }

    public IProductDataService CreateProductDataService()
    {
        // Instantiate and return an instance of ProductDataService
        return new ProductDataService(ReadXlsxFile(_applicationSettings.ExcelFilePath), ReadCsvFile(_applicationSettings.CsvFilePath));
    }

    private IEnumerable<ProductXlsxDto> ReadXlsxFile(string excelFilePath)
    {
        // Read data from Excel sources
        return _excelDataAccess.ReadDataFromExcel(excelFilePath);
    }

    public IEnumerable<ProductCsvDto> ReadCsvFile(string csvFilePath)
    {
        // Read data from CSV sources
        return _csvDataAccess.ReadDataFromCSV(csvFilePath);
    }
}
