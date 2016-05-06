using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels.ServiceModels
{
    public class Hospital
    {
        public long HospitalId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public long Rating { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", HospitalId, Name, Address);
        }

        public void Map(HospitalDatabase.Hospital other)
        {
            HospitalId = other.hospital_id;
            Name = other.name;
            Address = other.address;
            Rating = other.rating;
        }
    }
}
