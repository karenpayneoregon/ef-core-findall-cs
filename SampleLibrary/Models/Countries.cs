using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleLibrary.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Customers = new HashSet<Customers>();
        }

        [Key]
        public int CountryIdentifier { get; set; }
        public string Name { get; set; }

        [InverseProperty("CountryIdentifierNavigation")]
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
