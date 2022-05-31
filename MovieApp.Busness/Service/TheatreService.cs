using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Service
{
    public class TheatreService
    {
        ITheatre _iTheatre;
        public TheatreService(ITheatre iTheatre)
        {
            _iTheatre = iTheatre;
        }

        public string AddTheatre(TheatreModel theatreModel)
        {
            return _iTheatre.AddTheatre(theatreModel);

        }

        public Object SelectTheatre()
        {
            return _iTheatre.SelectTheatre();
        }

           
        public object FindTheatreById(int theatreId)
        {
            return _iTheatre.FindTheatreById(theatreId);
           
        }

        public string UpdateTheatre(TheatreModel theatreModel)
        {
            return _iTheatre.Update(theatreModel);
        }


        public string DeleteTheatre(int theatreId)
        {
            return _iTheatre.Delete(theatreId);
        }

    }
}
