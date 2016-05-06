using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface IAllergyService
    {
        string GetPatientAllergies(long patient_id);

         string GetAllAllergies();
    }
}
