namespace SolarDR.MVC.Models.PersonModel
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly Date { get; set; }
    }
}

