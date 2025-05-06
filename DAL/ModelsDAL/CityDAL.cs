using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDAL
{
    public class CityDAL
    {
       [Key]
        public int CityID { get; set; }
        public string? CityName { get; set; }
        public int? Population { get; set; }
        public string? Governorate { get; set; }
        public  string? Country { get; set; }
        public  int? CityRank { get; set; }
    }
}
