namespace Mvc_empty.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => 
            new List<Category>()
            {
                new Category { CategoryId = 1, CategoryName = "Romance", Description = "Love and Romance" },
                new Category { CategoryId = 2, CategoryName = "Action", Description = "Action" },
                new Category { CategoryId = 1, CategoryName = "Comedy", Description = "Comedy and Laughter" }
            };

        //public IEnumerable<Category> Categories
        //{
        //    get
        //    {
        //        return new List<Category>()
        //    {
        //        new Category { CategoryId = 1, CategoryName = "Romance", Description = "Love and Romance" }
        //    };
        //    }
        //}
    }
}
