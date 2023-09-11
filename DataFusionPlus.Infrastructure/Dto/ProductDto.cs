namespace DataFusionPlus.Infrastructure.Dto
{
    public record ProductDto
    {
        public int Ean { get; set; }

        public required string Name { get; set; }

        public required string CdnUrl { get; set; }
    }
}
