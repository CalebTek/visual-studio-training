namespace Mvc_empty.Models
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new CategoryRepository();
        public IEnumerable<Movie> AllMovies
        {
            get
            {
                return new List<Movie>
                {
                   new Movie {
                    MovieId = 1, Name = "Shaolin Temple",
                    Category = _categoryRepository.AllCategories.ToList()[1],
                    Price = 10M, InStock = true, Rating = 5
                    },
                    new Movie
                    {
                        MovieId = 2,
                        Name = "The God's Must be crazy",
                        Category = _categoryRepository.AllCategories.ToList()[2],
                        Price = 8M,
                        InStock = true,
                        Rating = 4
                    },
                    new Movie
                    {
                        MovieId = 3,
                        Name = "Love train",
                        Category = _categoryRepository.AllCategories.ToList()[0],
                        Price = 8M,
                        InStock = true,
                        Rating = 4
                    },
                    new Movie
                    {
                        MovieId = 4,
                        Name = "Extraction",
                        Category = _categoryRepository.AllCategories.ToList()[1],
                        Price = 15M,
                        InStock = true,
                        Rating = 5
                    }
                };
            }
        }

        public IEnumerable<Movie> BlockBusterMovies
        {
            get
            {
                var movies = AllMovies.Where(m => m.Rating == 5);
                return movies.ToList();
            }
        }

        public Movie? SingleMovie(int id)
        {
            var movie = AllMovies.FirstOrDefault(m => m.MovieId == id);
            return movie;
        }
    }
}
