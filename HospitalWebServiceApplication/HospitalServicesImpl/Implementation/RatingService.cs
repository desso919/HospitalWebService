using HospitalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class RatingService : IRatingService
    {
        public bool RatingHospital(long patient_id, long hospital_id, int rating)
        {
            throw new NotImplementedException();
        }

        public bool RatingDoctor(long patient_id, long doctor_id, int rating)
        {
            throw new NotImplementedException();
        }
    }
}
