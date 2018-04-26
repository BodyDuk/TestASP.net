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
        //[Display(Name = "Назва")]
        //[Required(ErrorMessage = "Поле Має бути заповнене")]
      //  [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина назви має бути віж 2 до 50 символів")]
        public string Name { get; set; }
        [Display(Name = "Назва")]
        public string Description { get; set; }
        [Display(Name = "Дата виходу")]
        public DateTime ReleaseDay { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public Film()
        {
            Actors = new List<Actor>();
        }
        public Director Director { get; set; }
    }
}