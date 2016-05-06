using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels.ServiceModels
{
    public class Allergy
    {
        public long Allergy_Id { get; set; }
        public string Name { get; set; }

        public void Map(HospitalDatabase.Allergy other)
        {
            Allergy_Id = other.allergy_id;
            Name = other.allergy1;
        }
    }
}
