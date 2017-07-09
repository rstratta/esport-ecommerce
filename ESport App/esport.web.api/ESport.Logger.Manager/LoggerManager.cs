using ESport.Logger.Data;
using System;
using System.Collections.Generic;

namespace ESport.Logger.Manager
{
    public class LoggerManager : ILoggerManager
    {
        private ILoggerRepository loggerRepository;

        public LoggerManager(ILoggerRepository repository)
        {
            loggerRepository = repository;
        }

        public void AddLog(string action, string userId, string userName)
        {
            Log log = new Log(action, userId, userName);
            loggerRepository.AddLog(log);
        }

        public ICollection<Log> GetAllLogs()
        {
            return loggerRepository.GetAllLogs();
        }

        public ICollection<Log> GetAllLogsByDate(DateTime initDate, DateTime finishDate)
        {
            ValidateDates(initDate, finishDate);
            return loggerRepository.GetAllLogsByDate(initDate, finishDate);
        }

        private void ValidateDates(DateTime initDate, DateTime finishDate)
        {
            if (initDate == null || finishDate == null)
            {
                throw new LoggerException("Verifique las fechas ingresadas");
            }
            if(initDate > finishDate)
            {
                throw new LoggerException("La fecha de inicio debe ser menor a la final");
            }
        }
    }
}