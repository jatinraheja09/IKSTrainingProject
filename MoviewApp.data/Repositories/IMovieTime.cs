using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IMovieTime
    {
        public string AddMovieTime(ShowMovieTime movieTime);

        List<ShowMovieTime> showAllMovie();
    }
}