namespace DataFusionPlus.Infrastructure.Dto;

public record ProductXlsxDto
{
    public int Ean { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }
}
