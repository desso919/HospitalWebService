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
            UriTemplate = "patient/{id}/{gender}/{username}/{password}/{first_name}/{second_name}/{last_name}/{egn}/{age}/{birth_date}")]
        bool AddNewPatient(long id, string gender, string username, string password, string first_name, string second_name, string last_name, string egn, int age, DateTime birth_date);
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

        #endregion


        #region History Services

        #endregion


        #region Scheduled Visitations Services

        #endregion
    }
}
