using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface ITemplateService
    {
        string GetTemplate(long id);

        string GetAllPatientTemplates(long patient_id);

        bool AddTemplate(long patient_id, long hospital_id, long doctor_id, string title, string reason, string description);

    }
}
