using DataFusionPlus.Application.FactoryPattern;
using DataFusionPlus.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataFusionPlus.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DataFusionController : ControllerBase
{
    private readonly IProductDataService _productDataService;

    public DataFusionController(IProductDataFactory productDataFactory)
    {
        _productDataService = productDataFactory.CreateProductDataService();
    }

    [HttpGet("CombineData")]
    public IActionResult CombineData()
    {
        try
        {
            var exportedData = _productDataService.CombineData();

            return Ok(exportedData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("MergeData")]
    public IActionResult MergeData()
    {
        try
        {
            var exportedData = _productDataService.MergeData();

            return Ok(exportedData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
