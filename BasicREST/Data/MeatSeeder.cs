using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasicREST.Models;

namespace BasicREST.Data
{
    public class MeatSeeder
    {
        public static void SeedMeat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meat>().HasData(
                new Meat { Id = 22, SourceAnimal = SourceAnimal.Pig, Mass = 1, NameOfCut = "Blade Chop", Notes = "none" },
                new Meat { Id = 23, SourceAnimal = SourceAnimal.Cow, Mass = 3, NameOfCut = "Brisket", Notes = null },
                new Meat { Id = 24, SourceAnimal = SourceAnimal.Chicken, Mass = 51, NameOfCut = "Wing", Notes = "yummy" },
                new Meat { Id = 25, SourceAnimal = SourceAnimal.Pig, Mass = 13, NameOfCut = "Sirloin", Notes = String.Empty },
                new Meat { Id = 26, SourceAnimal = SourceAnimal.Cow, Mass = 122, NameOfCut = "Chuck Blade", Notes = "none" },
                new Meat { Id = 27, SourceAnimal = SourceAnimal.Chicken, Mass = 41, NameOfCut = "Breast", Notes = String.Empty }
                );
        }
    }
}
