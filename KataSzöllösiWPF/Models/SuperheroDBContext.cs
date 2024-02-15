using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataSzöllösiWPF.Models
{
    internal class SuperheroDBContext :DbContext
    {
        public DbSet<Superhero> Superheroes { get; set; }
    }
}
