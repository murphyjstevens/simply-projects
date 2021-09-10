namespace Api.Models {
    public class MaterialModel {
        public MaterialModel(int id, int projectId, string name, decimal cost, int quantity) {
            Id = id;
            ProjectId = projectId;
            Name = name;
            Cost = cost;
            Quantity = quantity;
        }
        
        public int Id { get; }
        public int ProjectId { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public int Quantity { get; }
    }
}