namespace SolarDR.MVC.Models.ImageModel
{
    public class ImageSimpleModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }

        public byte[] Bytes { get; set; }
    }
}
