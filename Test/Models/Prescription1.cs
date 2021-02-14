using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Models
{
    public partial class Prescription1
    {
        public Prescription1()
        {
            PrescritionMedicaments = new HashSet<PrescritionMedicament>();
        }

        public int IdPrescrition { get; set; }
        public int? IdDoctor { get; set; }
        public int? IdClient { get; set; }
        public int? ClientId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public virtual Person Client { get; set; }
        public virtual Person IdDoctorNavigation { get; set; }
        public virtual ICollection<PrescritionMedicament> PrescritionMedicaments { get; set; }
    }
}
