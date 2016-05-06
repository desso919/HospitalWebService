using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels.ServiceModels
{
    public class Doctor
    {
        public long DoctorId { get; set; }
        public long HospitalId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Specialization { get; set; }

        public long Rating { get; set; } 


        public void Map(HospitalDatabase.Doctor other)
        {
            DoctorId = other.doctor_Id;
            HospitalId = other.hospital_Id;
            FirstName = other.first_name;
            SecondName = other.second_name;
            LastName = other.last_name;
            Specialization = other.specialization;
            Rating = other.rating;
        }
    }
}
