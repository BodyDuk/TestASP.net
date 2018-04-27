using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWebPortal.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Дата виходу")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDay { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Actor> ActorsAll { get; set; }
        public Film()
        {
            Actors = new List<Actor>();
        }
        public Director Director { get; set; }
    }
}