using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels.ServiceModels
{
    public class Patient
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string EGN { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string BirhtDate { get; set; }

        public  void Map(HospitalDatabase.Patient other)
        {
            Id = other.patient_Id;
            Username = other.username;
            FirstName = other.first_name;
            SecondName = other.second_name;
            LastName = other.last_name;
            EGN = other.egn;
            Age = other.age;
            if (other.gender_id == 1) { Gender = "Male"; }
            else { Gender = "Female"; }
            if (other.birth_date.HasValue)
            {
                BirhtDate = other.birth_date.Value.ToString();
            }

        }
    }
}
