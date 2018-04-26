using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestASP.Models
{
    public class FilmsDbInitializer : DropCreateDatabaseAlways<FilmsContextcs>
    {
        protected override void Seed(FilmsContextcs context)
        {
            Director director1 = new Director { Id = 1, Name = "Брати Вачовські" };
            Director director2 = new Director { Id = 2, Name = "Стівен Спілберг" };
            Director director3 = new Director { Id = 3, Name = "Джордж Лукас" };
            Director director4 = new Director { Id = 4, Name = "Джеймс Кемерон " };

            Actor actor1 = new Actor { Id = 1, Name = "Кіано Рівз " };
            Actor actor2 = new Actor { Id = 2, Name = "Харісон Форд " };
            Actor actor3 = new Actor { Id = 3, Name = "Арнольд Шварцьнегер " };
            Actor actor4 = new Actor { Id = 4, Name = "Кемерон Діаз " };

            Film s1 = new Film
            {
                Id = 1,
                Name = "Matrix",
                Description = "«Ма́триця» — американсько-австралійський науково-фантастичний фільм, який зняли в 1999 році сестри Вачовські. ",
                ReleaseDay = new DateTime(1999, 3, 31),
                Actors = new List<Actor>() { actor1, actor2 },
                Director = director1
            };
            Film s2 = new Film
            {
                Id = 2,
                Name = "Зоряні війни",
                Description = "Зо́ряні ві́йни — культова епічна фантастична медіафраншиза, яка розповідає про різні конфлікти і війни в «далекій-далекій галактиці».",
                ReleaseDay = new DateTime(1977, 5, 25),
                Actors = new List<Actor>() { actor1, actor2, actor3 },
                Director = director3
            };
            Film s3 = new Film
            {
                Id = 3,
                Name = "Індіана Джонс",
                Description = "Доктор Генрі «Індіана» Джонс-молодший — вигаданий персонаж, герой серії пригодницьких фільмів, книг та комп'ютерних ігор, створений Стівеном Спілбергом ",
                ReleaseDay = new DateTime(1986, 7, 23),
                Actors = new List<Actor>() { actor1, actor2 , actor3 },
                Director = director4
            };
            Film s4 = new Film
            {
                Id = 4,
                Name = "Терміна́тор",
                Description = "«Терміна́тор» — американський культовий фантастичний бойовик Джеймса Кемерона знятий у 1984 році. Це перший фільм із серії про Термінатора",
                ReleaseDay = new DateTime(1999, 3, 31),
                Actors = new List<Actor>() { actor1, actor2, actor3, actor4},
                Director = director4
            };

            context.Actors.Add(actor1);
            context.Actors.Add(actor2);
            context.Actors.Add(actor3);
            context.Actors.Add(actor4);
            
            context.Directors.Add(director1);
            context.Directors.Add(director2);
            context.Directors.Add(director3);
            context.Directors.Add(director4);

            context.Films.Add(s1);
            context.Films.Add(s2);
            context.Films.Add(s3);
            context.Films.Add(s4);

            base.Seed(context);
        }
    }
}