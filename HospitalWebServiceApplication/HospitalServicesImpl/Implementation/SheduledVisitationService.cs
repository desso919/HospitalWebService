using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class SheduledVisitationService : ISheduledVisitationService
    {   
        public string GetVisitation(long id)
        {
            var resultSet = DatabaseConnection.getConnection().Visitations.Where(visitation => visitation.id == id && visitation.isHistory == 0).ToList();

            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.Visitation visitation = new HospitalModels.ServiceModels.Visitation();
                visitation.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(visitation);
            }
            return JsonConvert.SerializeObject(new { });
        }

        public string GetVisitationByPatientID(long patient_id)
        {
            List<HospitalModels.ServiceModels.Visitation> visitations = new List<HospitalModels.ServiceModels.Visitation>();
            var resultSet = DatabaseConnection.getConnection().Visitations.Where(visitation => visitation.patient_id == patient_id && visitation.isHistory == 0).ToList();

            if (resultSet.Count > 0)
            {
                foreach (var visitation in resultSet)
                {
                    HospitalModels.ServiceModels.Visitation temp = new HospitalModels.ServiceModels.Visitation();
                    temp.Map(visitation);
                    visitations.Add(temp);
                }
                return JsonConvert.SerializeObject(visitations);
            }
            return JsonConvert.SerializeObject(new { });
        }

        public bool AddNewVisitation(long patient_id, long hospital_id, long doctor_id, string date, string reason, string description)
        {
            int visitationsCount = DatabaseConnection.getConnection().Visitations.Count();
            HospitalDatabase.Visitation visitation = new HospitalDatabase.Visitation();
            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            visitation.id = ++visitationsCount;
            visitation.patient_id = patient_id;
            visitation.hospital_id = hospital_id;
            visitation.doctor_id = doctor_id;
            visitation.date = Convert.ToDateTime(date);
            visitation.reson = reason;
            visitation.description = description;

            db.Visitations.Add(visitation);
            int result = db.SaveChanges();

            if (result == HospitalUtill.SUCCESSFULY_ADDED_ENTRY)
            {
                return true;
            }

            return false;
        }

        public bool MakeVisitationHistory(long id, string diagnose)
        {
            if(id <= 0 || diagnose == null) {
                return false;
            }

            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            var resultSet = db.Visitations.Find(id);
            int result = 0;

            if (resultSet != null)
            {
                resultSet.dignose = diagnose;
                resultSet.isHistory = 1;
                result = db.SaveChanges();
            }

            if (result == HospitalUtill.SUCCESSFULY_ADDED_ENTRY)
            {
                return true;
            }

            return false;
        }


        public bool EditVisitation(long id, long hospital_id, long doctor_id, string date, string reason, string description)
        {          
            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            var resultSet = db.Visitations.Find(id);
            int result = 0;

            if (resultSet != null)
            {
                resultSet.hospital_id = hospital_id;
                resultSet.doctor_id = doctor_id;
                resultSet.date = Convert.ToDateTime(date); ;
                resultSet.reson = reason;
                resultSet.description = description;
                result = db.SaveChanges();
            }

            if (result == HospitalUtill.SUCCESSFULY_ADDED_ENTRY)
            {
                return true;
            }

            return false;
        }
    }
}
