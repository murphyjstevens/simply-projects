namespace Api.Responses
{
    public sealed class ProjectCalculatedResponse
    {
        public ProjectCalculatedResponse(int id, string name, decimal totalCost, string description)
        {
            Id = id;
            Name = name;
            TotalCost = totalCost;
            Description = description;
        }
        
        public int Id { get; }
        public string Name { get; }
        public decimal TotalCost { get; }
        public string Description { get; }
    }
}