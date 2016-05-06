using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface IDoctorService
    {
        string GetDoctor(long doctor_id);

        string GetDoctorsByHospitalId(long hospital_id);

        string GetAllDoctors();
    }
}
