using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Models
{
    public partial class Medicament1
    {
        public Medicament1()
        {
            PrescritionMedicaments = new HashSet<PrescritionMedicament>();
        }

        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual ICollection<PrescritionMedicament> PrescritionMedicaments { get; set; }
    }
}
