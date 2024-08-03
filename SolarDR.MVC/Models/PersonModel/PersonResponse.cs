namespace SolarDR.MVC.Models.PersonModel
{
    public class PersonResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly Date { get; set; }
        public IFormFile Image { get; set; }
    }
}
