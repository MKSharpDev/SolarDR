using SolarDR.MVC.Models.ImageModel;

namespace SolarDR.MVC.Models.PersonModel
{
    public class PersonWithImagesResponce
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly Date { get; set; }
        public ICollection<ImageSimpleModel> Images { get; set; }
    }
}
