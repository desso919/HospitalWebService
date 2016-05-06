using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface IRatingService
    {
        bool RatingHospital(long patient_id, long hospital_id, int rating);

        bool RatingDoctor(long patient_id, long doctor_id, int rating);

    }
}
