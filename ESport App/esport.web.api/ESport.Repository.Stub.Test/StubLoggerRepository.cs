using System;
using System.Collections.Generic;
using System.Linq;
using ESport.Logger.Data;
using ESport.Logger.Manager;

namespace ESport.Repository.Stub.Test
{
    public class StubLoggerRepository : ILoggerRepository
    {
        private ICollection<Log> logs = new List<Log>();
        public void AddLog(Log log)
        {
            logs.Add(log);
        }

        public ICollection<Log> GetAllLogs()
        {
            return logs;
        }

        public ICollection<Log> GetAllLogsByDate(DateTime initDate, DateTime finishDate)
        {
            return logs.Where(log => log.LoggerDate >= initDate && log.LoggerDate <= finishDate).ToList();
        }
    }
}
