using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;


namespace MovieApp.Data.DataConnection
{
    public class MovieDbContext : DbContext
    {
       // internal object theatreModel;

        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }
        public DbSet<UserModel> userModel { get; set; }
        public DbSet<MovieModel> movieModel { get; set; }
        public DbSet<TheatreModel> theatreModel { get; set; }
        public DbSet<MovieShowTimeModel> movieShowTimeModel { get; set; }

        public DbSet<BookingModel> bookingModel { get; set; }

    }
}

//public class MovieDbContext : DbContext
//{
//    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
//    {

//    }
//    public DbSet<Movie> movie { get; set; }

//    public DbSet<MovieShowTimings> movieShowTimings { get; set; }
//    public DbSet<UserInfo> userInfo { get; set; }
//}
