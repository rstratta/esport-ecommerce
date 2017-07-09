using ESport.Logger.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Logger.DataAccess
{
    public class LoggerDbContext : DbContext
    {
        public LoggerDbContext() : base("LoggerDb") { }
        public virtual DbSet<Log> LogSystem { get; set; }
    }

}