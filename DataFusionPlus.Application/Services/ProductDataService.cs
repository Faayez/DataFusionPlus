using DataFusionPlus.Application.Interfaces;
using DataFusionPlus.Infrastructure.Dto;

namespace DataFusionPlus.Application.Services;

public class ProductDataService : IProductDataService
{
    private readonly IEnumerable<ProductXlsxDto> _xlsxProduct;
    private readonly IEnumerable<ProductCsvDto> _csvProduct;

    public ProductDataService(IEnumerable<ProductXlsxDto> xlsxProduct, IEnumerable<ProductCsvDto> csvProduct)
    {
        _xlsxProduct = xlsxProduct;
        _csvProduct = csvProduct;
    }

    public IEnumerable<ProductDto> CombineData()
    {
        // Pass the file paths to the CombineData method
        var data = from x in _xlsxProduct
                   join c in _csvProduct on x.Ean equals c.UniqueIdentifier
                   select new ProductDto
                   {
                       Ean = x.Ean,
                       Name = x.Name,
                       CdnUrl = c.CdnUrl
                   };

        return data;
    }

    public IEnumerable<ProductDto> MergeData()
    {
        // Pass the file paths to the MergeData method
        var data = from x in _xlsxProduct
                   join c in _csvProduct on x.Ean equals c.UniqueIdentifier
                   group new { x, c } by x.Ean into g
                   select new ProductDto
                   {
                       Ean = g.Key,
                       Name = g.First(p => !string.IsNullOrEmpty(p.x.Name)).x.Name,
                       CdnUrl = g.First(p => !string.IsNullOrEmpty(p.c.CdnUrl)).c.CdnUrl
                   };

        return data;
    }
}

