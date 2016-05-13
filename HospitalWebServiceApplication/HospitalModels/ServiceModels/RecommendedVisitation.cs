using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels.ServiceModels
{
    public class RecommendedVisitation
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Reason { get; set; }

        public string Recurrency { get; set; }

        public string Description { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public void Map(HospitalDatabase.Recommended_Visitations other)
        {
            Id = other.visitation_Id;
            Title = other.title;
            Reason = other.reason;
            Recurrency = other.recurrency;
            Description = other.description; ;
            MinAge = (int) other.min_recommended_age;
            MaxAge = (int) other.max_recommended_age;
        }
    }
}
