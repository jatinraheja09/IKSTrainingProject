using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace MovieApp.Data.Repositories
{
   public  class Movie : IMovie
    {
        MovieDbContext _movieDbContext;

        public Movie(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public string AddMovie(MovieModel movieModel)
        {
            string message = "";
            _movieDbContext.movieModel.Add(movieModel);
            _movieDbContext.SaveChanges();
            message = "Movie Inserted Successfully..!!";
            return message;
        }

        public object SelectMovie()
        {
            List<MovieModel> movieList = _movieDbContext.movieModel.ToList();
            return movieList;
        }

        public string DeleteMovie(int MovieId)
        {
            string message = "";
            var foundMovie = _movieDbContext.movieModel.Find(MovieId);
            if (foundMovie != null)
            {
                _movieDbContext.movieModel.Remove(foundMovie);
                _movieDbContext.SaveChanges();
                message = "Movie Deleted Successfully..!!";
                return message;
            }
            else
            {
                message = "Movie Not Found!!";
                return message;
            }
        }
        public string EditMovie(MovieModel movieModel)
        {
            _movieDbContext.Entry(movieModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Movie Updated Successfully...!!";
        }

        public object findMovieById(int movieid)
        {
            MovieModel foundmovieModel = _movieDbContext.movieModel.Find(movieid);
            if (foundmovieModel != null)
            {
                return foundmovieModel;
            }
            else
            {
                return "User Not Found";
            }
        }

    }

}
