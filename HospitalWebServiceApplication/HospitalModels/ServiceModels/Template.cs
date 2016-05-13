using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels.ServiceModels
{
    public class Template
    {
        public long Id { get; set; }

        public long PatientId { get; set; }

        public long HospitalId { get; set; }

        public long DoctorId { get; set; }

        public string Reason { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public void Map(HospitalDatabase.Template other)
        {
            Id = other.id;
            PatientId = other.patient_id;
            HospitalId = (long) other.hospital_id;
            DoctorId = (long) other.doctor_id;
            Reason = other.reson;
            Title = other.title;
            Description = other.description;
        }
    }
}
