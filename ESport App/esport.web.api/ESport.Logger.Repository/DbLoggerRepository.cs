using ESport.Logger.DataAccess;
using ESport.Logger.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ESport.Logger.Data;

namespace ESport.Logger.Repository
{
    public class DbLoggerRepository : ILoggerRepository
    {
        public void AddLog(Log log)
        {
            using (var db = new LoggerDbContext())
                try
                {
                    db.LogSystem.Add(log);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new LoggerException("Error al agregar log al sistema", e);
                }
        }

        public ICollection<Log> GetAllLogs()
        {
            using (var db = new LoggerDbContext())
                try
                {
                    var queryResults = from l in db.LogSystem
                                       orderby l.LoggerDate descending
                                       select l;
                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new LoggerException("Error al obtener logs del sistema", e);
                }
        }

        public ICollection<Log> GetAllLogsByDate(DateTime initDate, DateTime finishDate)
        {
            using (var db = new LoggerDbContext())
                try
                {
                    var queryResults = from l in db.LogSystem
                                       where l.LoggerDate >= initDate && l.LoggerDate <= finishDate
                                       orderby l.LoggerDate descending
                                       select l;
                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new LoggerException("Error al obtener logs del sistema", e);
                }
        }
    }
}