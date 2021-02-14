using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.DTOs
{
    public class MedicamentResponse
    {
        public MedicamentResponse(Medicament medicament, List<Prescription> pres)
        {
            this.medicament = medicament;
            this.Prescriptions = pres;
        }

        public Medicament medicament { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}
