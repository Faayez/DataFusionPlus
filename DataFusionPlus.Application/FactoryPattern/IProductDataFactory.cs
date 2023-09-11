using DataFusionPlus.Application.Interfaces;

namespace DataFusionPlus.Application.FactoryPattern;

public interface IProductDataFactory
{
    IProductDataService CreateProductDataService();
}
