using ESport.Logger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Logger.Manager
{
    public interface ILoggerRepository
    {

        void AddLog(Log log);

        ICollection<Log> GetAllLogs();

        ICollection<Log> GetAllLogsByDate(DateTime initDate, DateTime finishDate);
    }
}