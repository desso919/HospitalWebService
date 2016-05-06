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

        Boolean AddNewVisitation(long id, long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description);

    }
}
