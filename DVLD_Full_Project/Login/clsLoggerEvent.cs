using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Full_Project.Login
{
    public class clsLoggerEvent
    {

        private static string SourceName = "DVLD";
        static clsLoggerEvent()
        {
            // if exist return false
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
        }
        public static void LogEvent(Exception ex, EventLogEntryType enType = EventLogEntryType.Error)
        {
            EventLog.WriteEntry(SourceName, HandelMessage(ex), enType);
        }
        public static void InfoThatUserEnter()
        {
            EventLog.WriteEntry(SourceName, $"------------\nTime : {DateTime.Now} \nUserName : {clsGlobal.CurrentUser.UserName}\n" +
                $"NationalNo : {clsGlobal.CurrentUser.PersonInfo.NationalNo}\n--------------",EventLogEntryType.SuccessAudit);
        }
        private static string HandelMessage(Exception ex)
        {
            return "------Exception Log--------\n" +
                $"Time / Date   : {DateTime.Now}\n" +
                $"Message       : {ex.Message}\n" +
                $"Inner Exeption: {(ex.InnerException != null ? ex.InnerException.Message : "N/A")}\n" +
                $"Stack Trace   : {ex.StackTrace}\n" +
                $"source        : {ex.Source}\n" +
                "-------------------------------";
        }
    }
}
