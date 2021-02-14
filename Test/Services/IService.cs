using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.DTOs;

namespace Test.Services
{
    public interface IService
    {
        MedicamentResponse GetMedicament(int id);
        Patient DeletePatient(int id);
    }
}
