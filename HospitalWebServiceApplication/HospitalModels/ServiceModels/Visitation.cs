using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels.ServiceModels
{
    public class Visitation
    {
        public long Id { get; set; }

        public long PatientId { get; set; }

        public long HospitalId { get; set; }

        public long DoctorId { get; set; }

        public int IsHistory { get; set; }

        public string Reason { get; set; }

        public string Diagnose { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }

        public void Map(HospitalDatabase.Visitation other)
        {
            Id = other.id;
            PatientId = other.patient_id;
            HospitalId = other.hospital_id;
            DoctorId = other.doctor_id;
            IsHistory = other.isHistory;
            Reason = other.reson;
            Diagnose = other.dignose;
            Description = other.description;
            Date = other.date.ToString();
        }
    }
}
