using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Models
{
    public partial class PrescritionMedicament
    {
        public int Id { get; set; }
        public int? IdMedicament { get; set; }
        public int? IdPrescrtiption { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }

        public virtual Medicament1 IdMedicamentNavigation { get; set; }
        public virtual Prescription1 IdPrescrtiptionNavigation { get; set; }
    }
}
