namespace Api.Models {
    public class ProjectModel {
        public ProjectModel(int id, string name, string description) {
            Id = id;
            Name = name;
            Description = description;
        }
        
        public int Id { get; }
        public string Name { get; }
        public decimal TotalCost { get; }
        public string Description { get; }
    }
}