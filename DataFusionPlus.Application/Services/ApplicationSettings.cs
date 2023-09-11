namespace DataFusionPlus.Application.Services;

public record ApplicationSettings
{
    public string ExcelFilePath { get; private set; }

    public string CsvFilePath { get; private set; }

    public ApplicationSettings(string excelFilePath, string csvFilePath)
    {
        ExcelFilePath = excelFilePath;
        CsvFilePath = csvFilePath;
    }
}
