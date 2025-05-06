using Microsoft.EntityFrameworkCore;

namespace Trianing_App.Models
{
    public class City
    {
        
        public int CityID { get; set; }
        public string? CityName { get; set; }
        public int? Population { get; set; }
        public string? Governorate { get; set; }
        public  string? Country { get; set; }
        public  int? CityRank { get; set; }
    }
}
