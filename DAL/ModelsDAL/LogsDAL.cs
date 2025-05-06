using System.ComponentModel.DataAnnotations;

namespace DAL.ModelsDAL
{
    public class LogsDAL
    {
        [Key]
        public int LogsId { get; set; }
        public DateTime CreatedDate { get; set; }
        public String? Details { get; set; }
    }
}
