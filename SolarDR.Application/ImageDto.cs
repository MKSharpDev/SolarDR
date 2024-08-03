namespace SolarDR.Application
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public byte[] bytes { get; set; }
        public Guid PersonId { get; set; }
    }
}
