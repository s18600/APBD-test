using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Models
{
    public partial class Person
    {
        public Person()
        {
            Prescription1Clients = new HashSet<Prescription1>();
            Prescription1IdDoctorNavigations = new HashSet<Prescription1>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Discriminator { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Prescription1> Prescription1Clients { get; set; }
        public virtual ICollection<Prescription1> Prescription1IdDoctorNavigations { get; set; }
    }
}
