using DAL.RepositoryDAL;

namespace Trianing_App.BL
{
    public class LogsBLService
    {
        private readonly LogsRepositoriesDAL _logsRepositoriesDAL;
        public LogsBLService(LogsRepositoriesDAL LogsRepositoriesDAL)
        {
            _logsRepositoriesDAL = LogsRepositoriesDAL;
        }
        public bool Addlog(string addLogs)
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
