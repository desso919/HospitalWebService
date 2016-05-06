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
    }
}
