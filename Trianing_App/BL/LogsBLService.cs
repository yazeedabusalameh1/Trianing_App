using DAL.Interface;
using DAL.RepositoryDAL;
using Trianing_App.BL.BLInterface;




namespace Trianing_App.BL
{
    public class LogsBLService : ILogsBLService
    {
        private readonly ILogsRepositoriesDAL _logsRepositoriesDAL;
        public LogsBLService(ILogsRepositoriesDAL LogsRepositoriesDAL)
        {
            _logsRepositoriesDAL = LogsRepositoriesDAL;
        }
        public bool AddLog(string addLogs)
        {
            try
            {
                _logsRepositoriesDAL.AddLog(addLogs);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }


        }

       
       
    }
}
