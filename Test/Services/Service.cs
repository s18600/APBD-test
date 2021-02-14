using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.DTOs;

namespace Test.Services
{
    public class Service : IService
    {
        public Patient DeletePatient(int id)
        {
            var db = new s18600Context();
            Patient pat = db.Patients.First(p => p.IdPatient==id);
            if(pat == null)
            {
                return null;
            }
            var prescriptions = db.Prescriptions.Where(p => p.IdPatient == id);
            var query =
               from prescription in prescriptions
               join prsmed in db.PrescriptionMedicaments on prescription.IdPrescription equals prsmed.IdPrescription
               select prsmed;

            var list = query.Select(p => p).ToList();
            foreach (var e in list)
            {
                db.PrescriptionMedicaments.Remove(e);
            }
            var list2 = prescriptions.Select(p => p).ToList();
            foreach (var e in list2)
            {
                db.Prescriptions.Remove(e);
            }
            db.Patients.Remove(pat);
            db.SaveChanges();
            return null;
        }

        public MedicamentResponse GetMedicament(int id)
        {
            var db = new s18600Context();
            Medicament med = db.Medicaments.First(m=> m.IdMedicament == id);
            IQueryable<PrescriptionMedicament> prscptMeds = db.PrescriptionMedicaments.Where(pm => pm.IdMedicament == id);
            var query =
                from medicament in db.Medicaments
                join prsmed in db.PrescriptionMedicaments on medicament.IdMedicament equals prsmed.IdMedicament
                where medicament.IdMedicament == id
                select new { Medicament = medicament, PrescriptionMedicament = prsmed };
            var prescriptions = from prescription in db.Prescriptions
                                join prsmed in query on prescription.IdPrescription equals prsmed.PrescriptionMedicament.IdPrescription
                                select prescription;
            var prsrc =prescriptions.OrderBy(p=>p.Date).Select(s=>s).ToList();
            MedicamentResponse response = new MedicamentResponse(med, prsrc);
            return response;
        }

    }
}
