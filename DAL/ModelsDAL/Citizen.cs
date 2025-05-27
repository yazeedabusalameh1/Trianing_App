using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelsDAL
{
     public class Citizen
    {
        [Key]
        public int CitizenID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string BirthDay { get; set; }
        public CirizenDetails Details  { get; set; }
    }
    public class CirizenDetails
    {
        public string Major { get; set; }
        public string adress { get; set; }
        public List<Nots> citizenNots { get; set; }
    }
    public class Nots
    {
        public string noteText { get; set; }
        public string noteDate { get; set; }
    }
}
