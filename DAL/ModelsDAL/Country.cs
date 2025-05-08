using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelsDAL
{
    public class Country
    {
        [Key]
        public int countryID { get; set; }
        public string? countryName { get; set; }

        public string countryDisc { get; set; }
    }
}
