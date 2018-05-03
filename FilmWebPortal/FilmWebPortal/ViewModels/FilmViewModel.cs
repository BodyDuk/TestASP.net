using FilmWebPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWebPortal.ViewModels
{
    public class FilmViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Опис")]
        public string Description { get; set; }
        public ICollection<int> SelectedActors { get; set; } = new List<int>();
        [Display(Name = "Дата виходу")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDay { get; set; }
        public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public virtual IEnumerable<Actor> ActorsAll { get; set; } = new List<Actor>();        
        public Director Director { get; set; }
        public static explicit operator Film(FilmViewModel model)
        {
            return new Film {
                Id=model.Id,
                Name= model.Name,
                Description=model.Description,
                Actors = model.Actors,
                Director=model.Director,
                ReleaseDay=model.ReleaseDay
            };
        }
    }
}