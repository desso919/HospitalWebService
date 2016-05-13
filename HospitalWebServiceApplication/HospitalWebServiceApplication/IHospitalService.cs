using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HospitalWebServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMedicalClinicService" in both code and config file together.
    [ServiceContract]
    public interface IHospitalService
    {

        #region Patient Services

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "patient/{id}")]
        string GetPatient(long id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "patient/{username}/password{password}")]
        string GetPatientByUsernameAndPassword(string username, string password);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "patient/egn/{egn}/password{password}")]
        string GetPatientByEGNAndPassword(string egn, string password);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "patient/{username}/{password}/{first_name}/{second_name}/{last_name}/{egn}/{gender}/{age}/{birth_date}")]
        bool AddNewPatient(string username, string password, string first_name, string second_name, string last_name, string egn, string gender, int age, string birth_date);
        #endregion


        #region Hospital Services
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "hospital/{id}")]
        string GetHospital(long id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "hospitals")]
        string GetAllHospitals();
        #endregion


        #region Doctor Services
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "doctor/{id}")]
        string GetDoctor(long id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "doctor/hospital/{hospital_id}")]
        string GetDoctorsByHospitalId(long hospital_id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "doctors")]
        string GetAllDoctors();
        #endregion


        #region Allergy Service
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "allergies/patient/{id}")]
        string GetPatientAllergies(long patient_id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "allergies")]
        string GetAllAllergies();

        #endregion


        #region History Services
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "record/{id}")]
        string GetHospitalRecord(long id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "record/patient/{patient_id}")]
        string GetHospitalRecordByPatientID(long patient_id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "record/{id}/{patient_id}/{hospital_id}/{doctor_id}/{reason}/{diagnose}/{date}/{description}")]
        bool AddNewHospitalRecord(long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description);

        #endregion


        #region Scheduled Visitations Services
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "visitation/{id}")]
        string GetVisitation(long id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "visitation/patient/{patient_id}")]
        string GetVisitationByPatientID(long patient_id);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "makeHistory/{id}/{patient_id}/{diagnose}")]
        bool MakeVisitationHistory(long id, long patient_id, string diagnose);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "visitation/{patient_id}/{hospital_id}/{doctor_id}/{date}/{reason}/{description}")]
        bool AddNewVisitation(long patient_id, long hospital_id, long doctor_id, string date, string reason, string description);
        #endregion


        #region Rating Services


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "rating/hospital/{patient_id}/{hospital_id}/{rating}")]
        bool RatingHospital(long patient_id, long hospital_id, int rating);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "rating/doctor/{patient_id}/{hospital_id}/{rating}")]
        bool RatingDoctor(long patient_id, long doctor_id, int rating);

        #endregion


        #region Template Services

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "template/{id}")]
        string GetTemplate(long id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "template/patient/{id}")]
        string GetAllPatientTemplates(long patient_id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "template/{patient_id}/{hospital_id}/{doctor_id}/{title}/{reason}/{description}")]
        bool AddTemplate(long patient_id, long hospital_id, long doctor_id, string title, string reason, string description);

        #endregion

        #region Recommended Visitations Servcies

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "recommended/{id}")]
        string GetRecommendedVisitation(long id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "recommended/patient/{age}")]
        string GetRecommendedVisitationForPatient(int age);

        #endregion
    }
}
