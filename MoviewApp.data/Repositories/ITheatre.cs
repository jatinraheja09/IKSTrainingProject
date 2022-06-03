using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface ITheatre
    {
        string AddTheatre(TheatreModel theatremodel);
         object SelectTheatre();
        string Delete(int theatreId);
         string Update(TheatreModel theatreModel);
         object FindTheatreById(int theatreId);
    }
}
