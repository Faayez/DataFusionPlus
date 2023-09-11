using DataFusionPlus.Infrastructure.Dto;
using OfficeOpenXml;

namespace DataFusionPlus.Infrastructure.DataAccess;

public class ExcelDataAccess
{
    public IEnumerable<ProductXlsxDto> ReadDataFromExcel(string filePath)
    {

        // Initialize a list to store the parsed products
        var products = new List<ProductXlsxDto>();

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            // Get the first worksheet in the Excel file
            var worksheet = package.Workbook.Worksheets[0];

            // Determine the number of rows in the worksheet
            var rowCount = worksheet.Dimension.Rows;

            for (var row = 2; row <= rowCount; row++) // Assuming the header is in the first row
            {
                // Parse data from each column in the current row
                var ean = worksheet.Cells[row, 1].Text;
                var name = worksheet.Cells[row, 2].Text;
                var description = worksheet.Cells[row, 3].Text;

                // Create a Product object and add it to the list
                var product = new ProductXlsxDto
                {
                    Ean = Convert.ToInt32(ean),
                    Name = name,
                    Description = description
                };

                products.Add(product);
            }
        }

        return products;
    }
}