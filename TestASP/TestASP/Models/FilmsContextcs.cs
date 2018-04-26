using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestASP.Models
{
    public class FilmsContextcs :  IdentityDbContext<ApplicationUser>
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public FilmsContextcs() : base("Local") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasMany(a => a.Actors).WithMany(f => f.Films)
                .Map(t => t.MapLeftKey("FilmId")
                .MapRightKey("ActorsId")
                .ToTable("ActorsFilmId"));
        }
       

    }
}