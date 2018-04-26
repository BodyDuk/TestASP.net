using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWebPortal.Models
{
    public class Director
    {
        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Поле Має бути заповнене")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина імені має бути віж 2 до 50 символів")]
        public string Name { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public Director()
        {
            Films = new List<Film>();
        }
    }
}