namespace SolarDR.Domain
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly Date { get; set; }
    }
}
