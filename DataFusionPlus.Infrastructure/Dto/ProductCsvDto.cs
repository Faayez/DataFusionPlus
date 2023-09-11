namespace DataFusionPlus.Infrastructure.Dto;

public record ProductCsvDto
{
    public int UniqueIdentifier { get; set; }

    public required string CdnUrl { get; set; }

    public DateTime LastUpdated { get; set; }
}
