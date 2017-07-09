using ESport.Logger.Data;
using System;
using System.Collections.Generic;

namespace ESport.Logger.Manager
{
    public interface ILoggerManager
    {
        void AddLog(string action, string userId, string userName);

        ICollection<Log> GetAllLogs();

        ICollection<Log> GetAllLogsByDate(DateTime initDate, DateTime finishDate);
    }
}
