using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmWebPortal.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public Director()
        {
            Films = new List<Film>();
        }
    }
}