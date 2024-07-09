using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Domain
{
    public class Pet
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public double Price { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Phone { get; set; }
        public string Owner { get; set; }
    }
}
