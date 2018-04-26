using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmWebPortal.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Поле Має бути заповнене")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина імені має бути віж 2 до 50 символів")]
       // [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Некоректне ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Поле Має бути заповнене")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Некоректне прізвище")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Вік")]
        public int? Age { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public Actor()
        {
            Films = new List<Film>();
        }
    }
}