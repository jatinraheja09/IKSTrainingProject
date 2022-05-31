using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;

namespace MovieApp.Business.Service
{
    public class MovieServices
    {
        //MovieDbContext _movieDbContext;
        IMovie _movie;

        public MovieServices(IMovie movie)
        {
            _movie = movie;
        }
        public string AddMovie(MovieModel movieModel)
        {
            return _movie.AddMovie(movieModel);
        }

        public object SelectMovie()
        {
            return _movie.SelectMovie();
        }

        public string DeleteMovie(int id)
        {
            return _movie.DeleteMovie(id);
        }

        public string EditMovie(MovieModel movieModel)
        {
            return _movie.EditMovie(movieModel);
        }

        public object FindMovieById(int id)
        {
            return _movie.findMovieById(id);
        }

    }
}

/* public  MovieModel etMovieById(int movieId)
 {
     _movie.getMovieById(movieId);
 }

public IEnumerable<MovieModel> GetMovies()
        {
            return _movie.GetMovies();
        }

        public void UpdateMovie(MovieModel movieModel)
        {
            _movie.UpdateMovie(movieModel);
        }
    }
}*/
