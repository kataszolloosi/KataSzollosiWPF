using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataSzöllösiWPF.Models
{
    internal class SuperheroDBContext2 :DbContext
    {
        public DbSet<Superhero> Superheroes { get; set; }
    }
}
