using Training_App.Data;
using Trianing_App.Models;

namespace Trianing_App.Repository
{
    public class LogsRepositories
    {
        private readonly DBContext _context;
        

        public LogsRepositories(DBContext context)
        {
            _context = context;
        }

        public bool AddLog(string details)
        {
            try
            {

                var log = new Logs
                {
                    CreatedDate = DateTime.Now,
                    Details = details
                };
                try {
                    _context.Logs.Add(log);
                    int result = _context.SaveChanges();
                    return result > 0;
                }

                catch (Exception ex) {
                    return false;
                }
               
                

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "theres an error ");
                return false;
            }
        }


    }
}
