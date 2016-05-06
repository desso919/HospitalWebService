using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels.ServiceModels
{
    public class PatientHistory
    {
        public long HistoryId { get; set; }

        public long PatientId { get; set; }

        public long HospitalId { get; set; }

        public long DoctorId { get; set; }

        public string Reason { get; set; }

        public string Diagnose { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }

        public void Map(HospitalDatabase.History other)
        {
            HistoryId = other.history_Id;
            PatientId = other.patient_Id;
            HospitalId = other.hospital_Id;
            DoctorId = other.doctor_Id;
            Reason = other.reson;
            Diagnose = other.dignose;
            Description = other.description;
            Date = other.date.ToString();
        }
    }
}
