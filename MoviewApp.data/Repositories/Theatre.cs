using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MovieApp.Data.Repositories
{
    public class Theatre : ITheatre
    {
        MovieDbContext _movieDbContext;
        public Theatre(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string AddTheatre(TheatreModel theatremodel)
        {
            string message = "";
            _movieDbContext.theatreModel.Add(theatremodel);
            _movieDbContext.SaveChanges();
            message = "Theatre Added Successfully !!";
            return message;

        }

        public string Delete(int theatreId)
        {
            string msg = "";
            var foundTheatre = _movieDbContext.theatreModel.Find(theatreId);
            if (foundTheatre != null)
            {
                _movieDbContext.theatreModel.Remove(foundTheatre);
                _movieDbContext.SaveChanges();
                msg = "Theatre Deleted Successfully..!!";
                return msg;
            }
            else
            {
                msg = "Theatre Not Found..!!";
                return msg;

            }

          



        }

        public object FindTheatreById(int theatreId)
        {
            var foundTheatre = _movieDbContext.theatreModel.Find(theatreId);
            if (foundTheatre! == null)
            {
                return foundTheatre;
            }
            else
            {
                return "Theatre not found !!";
            }

        }

        public object SelectTheatre()
        {
            List<TheatreModel> theatreList = _movieDbContext.theatreModel.ToList();
            return theatreList;

        }

        public string Update(TheatreModel theatreModel)
        {
            _movieDbContext.Entry(theatreModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            return "Theatre Updated";
        }
    }
}
