using System;

namespace ESport.Logger.Data
{
    public class Log
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public DateTime LoggerDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public Log() { }
        public Log(string action, string userId, string userName)
        {
            Id = Guid.NewGuid();
            Action = action;
            UserId = userId;
            UserName = userName;
            LoggerDate = DateTime.Now;
        }

        
        public override string ToString()
        {
            return LoggerDate.ToString() + " - Acción: " + Action + " - Id de usuario: " + UserId + " - Nombre: " + UserName;
        }
    }
}
