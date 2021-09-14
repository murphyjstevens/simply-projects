namespace Api.Models
{
    public class Material
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public int SortOrder { get; set; }
    }
}