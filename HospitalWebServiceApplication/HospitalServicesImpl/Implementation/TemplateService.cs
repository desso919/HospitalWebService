using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class TemplateService : ITemplateService
    {
        public string GetTemplate(long id)
        {
            var resultSet = DatabaseConnection.getConnection().Templates.Where(template => template.id == id).ToList();

            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.Template template = new HospitalModels.ServiceModels.Template();
                template.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(template);
            }
            return JsonConvert.SerializeObject(new { });
        }

        public string GetAllPatientTemplates(long patient_id)
        {
            List<HospitalModels.ServiceModels.Template> templates = new List<HospitalModels.ServiceModels.Template>();
            var resultSet = DatabaseConnection.getConnection().Templates.Where(template => template.patient_id == patient_id).ToList();

            if (resultSet.Count > 0)
            {
                foreach (var visitation in resultSet)
                {
                    HospitalModels.ServiceModels.Template temp = new HospitalModels.ServiceModels.Template();
                    temp.Map(visitation);
                    templates.Add(temp);
                }
                return JsonConvert.SerializeObject(templates);
            }
            return JsonConvert.SerializeObject(new { });
        }

        public bool AddTemplate(long patient_id, long hospital_id, long doctor_id, string title, string reason, string description)
        {
            int templatesCount = DatabaseConnection.getConnection().Templates.Count();
            HospitalDatabase.Template template = new HospitalDatabase.Template();
            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            template.id = ++templatesCount;
            template.patient_id = patient_id;
            template.hospital_id = hospital_id;
            template.doctor_id = doctor_id;
            template.title = title;
            template.reson = reason;
            template.description = description;

            db.Templates.Add(template);
            int result = db.SaveChanges();

            if (result == HospitalUtill.SUCCESSFULY_ADDED_ENTRY)
            {
                return true;
            }

            return false;
        }


        public bool EditTemplate(long id, long hospital_id, long doctor_id, string title, string reason, string description)
        {
            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            var resultSet = db.Templates.Find(id);
            int result = 0;

            if (resultSet != null)
            {
                resultSet.hospital_id = hospital_id;
                resultSet.doctor_id = doctor_id;
                resultSet.title = title;
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
