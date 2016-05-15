using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface ISheduledVisitationService
    {
        string GetVisitation(long id);

        string GetVisitationByPatientID(long patient_id);

        bool MakeVisitationHistory(long id, string diagnose);

        Boolean AddNewVisitation(long patient_id, long hospital_id, long doctor_id, string date, string reason, string description);

        bool EditVisitation(long id, long patient_id, long hospital_id, long doctor_id, string date, string reason, string description);

    }
}
