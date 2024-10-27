namespace bruhBruh.Models
{
    public class retailLocation
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public int FruitsId { get; set; }
        public Fruits? Fruits { get; set; } = default!;
        public int veggiesId { get; set; }
        public veggies? veggies { get; set; } = default!;
    }
}
