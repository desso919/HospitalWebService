using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface IPatientHistoryService
    {
        string GetHistory(long history_id);

        string GetHistoryByPatientId(long patient_id);

        bool AddNewHospitalRecord(long id, long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description);
    }
}
