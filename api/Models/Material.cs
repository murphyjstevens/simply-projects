namespace Api.Models
{
    public class Material
    {
        public Material(int id, int projectId, string name, decimal cost, int quantity)
        {
            Id = id;
            ProjectId = projectId;
            Name = name;
            Cost = cost;
            Quantity = quantity;
        }
        
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
    }
}