using DAL.Data;
using DAL.Interface;
using DAL.ModelsDAL;

namespace DAL.RepositoryDAL
{
    public class LogsRepositoriesDAL: ILogsRepositoriesDAL
    {
        private readonly DBContext _context;
        

        public LogsRepositoriesDAL(DBContext context)
        {
            _context = context;
        }

        public bool AddLog(string details)
        {
            try
            {

                var log = new LogsDAL
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
