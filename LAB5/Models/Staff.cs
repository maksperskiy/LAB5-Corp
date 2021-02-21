using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB5.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Post { get; set; }
        public int YearOfBirth { get; set; }
        public int YearOfAdoption { get; set; }
        public string Address { get; set; }
    }
}
