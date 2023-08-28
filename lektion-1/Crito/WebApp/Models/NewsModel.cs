namespace WebApp.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public List<string> Tags { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime Created { get; set; }
    }
}
