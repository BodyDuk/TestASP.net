using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestASP.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public Actor()
        {
            Films = new List<Film>();
        }
    }
}