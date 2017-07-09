using System.Windows.Forms;
using ESport.Logger.Manager;
using System.Collections.Generic;
using ESport.Logger.Data;
using System;

namespace ESport.DesktopAppUI
{
    public partial class ConsultLog : UserControl
    {
        private ILoggerManager loggerManager;
        public ConsultLog(ILoggerManager loggerManager)
        {
            InitializeComponent();
            this.loggerManager = loggerManager;
        }

        private void allLogButton_Click(object sender, System.EventArgs e)
        {
            logListBox.Items.Clear();
            try
            {
                ICollection<Log> allLogs = loggerManager.GetAllLogs();
                FillList(allLogs);
            }
            catch (LoggerException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillList(ICollection<Log> logList)
        {

            foreach (var log in logList)
            {
                logListBox.Items.Add(log);
            }
        }

        private void filterLogButton_Click(object sender, EventArgs e)
        {
            logListBox.Items.Clear();
            DateTime initDate = DateTime.Parse(initDateFilter.Value.ToShortDateString().Trim() + " 0:00:00");
            DateTime finishDate = DateTime.Parse(finishDateFilter.Value.ToShortDateString().Trim() + " 23:59:59");
            try
            {
                ICollection<Log> filterLogList = loggerManager.GetAllLogsByDate(initDate, finishDate);
                FillList(filterLogList);
            }
            catch (LoggerException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
