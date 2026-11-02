namespace Societix.Api
{
    public class Society
    {
        public int SocietyId { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime CreatedDate { get; set; }
    }
}