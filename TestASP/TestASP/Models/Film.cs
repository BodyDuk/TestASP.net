using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestASP.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDay { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public Film()
        {
            Actors = new List<Actor>();
        }
        public Director Director { get; set; }
    }
}