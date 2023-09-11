using DataFusionPlus.Infrastructure.Dto;

namespace DataFusionPlus.Application.Interfaces;

public interface IProductDataService
{
    IEnumerable<ProductDto> CombineData();

    IEnumerable<ProductDto> MergeData();
}
