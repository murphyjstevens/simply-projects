namespace Api.Models {
    public class ProjectModel {
        public ProjectModel(int id, string name, int userId, decimal totalCost, string description) {
            Id = id;
            Name = name;
            UserId = userId;
            TotalCost = totalCost;
            Description = description;
        }
        
        public int Id { get; }
        public string Name { get; }
        public int UserId { get; }
        public decimal TotalCost { get; }
        public string Description { get; }
    }
}