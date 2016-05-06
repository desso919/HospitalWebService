using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class PatientHistoryService : IPatientHistoryService
    {
        public string GetHistory(long history_id)
        {
            var ResultSet = DatabaseConnection.getConnection().Histories.Where(history => history.history_Id == history_id).ToList();

            HospitalModels.ServiceModels.PatientHistory requestedHistory = new HospitalModels.ServiceModels.PatientHistory();
            if (ResultSet.Count == 1)
            {
                requestedHistory.Map(ResultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(requestedHistory);
            }

            return JsonConvert.SerializeObject(new { });
        }

        public string GetHistoryByPatientId(long patient_id)
        {
            List<HospitalModels.ServiceModels.PatientHistory> histories = new List<HospitalModels.ServiceModels.PatientHistory>();
            var resultSet = DatabaseConnection.getConnection().Histories.Where(history => history.patient_Id == patient_id).ToList();

            if (resultSet.Count > 0)
            {
                foreach (var history in resultSet)
                {
                    HospitalModels.ServiceModels.PatientHistory temp = new HospitalModels.ServiceModels.PatientHistory();
                    temp.Map(history);
                    histories.Add(temp);
                }
                return JsonConvert.SerializeObject(histories);
            }
            return JsonConvert.SerializeObject(new { });
        }
    }
}
