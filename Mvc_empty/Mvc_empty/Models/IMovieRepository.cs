namespace Mvc_empty.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> AllMovies { get; }
        IEnumerable<Movie> BlockBusterMovies { get; }

        Movie? SingleMovie(int id);


    }
}
