namespace Api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public string Description { get; set; }
    }
}