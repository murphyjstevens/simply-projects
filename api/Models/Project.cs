namespace Api.Models
{
    public class Project
    {
        public Project(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public string Description { get; set; }
    }
}