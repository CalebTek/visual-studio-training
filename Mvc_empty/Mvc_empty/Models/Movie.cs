using System.ComponentModel;

namespace Mvc_empty.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public int PG { get; set; }
        public int Rating { get; set; } = 1;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
