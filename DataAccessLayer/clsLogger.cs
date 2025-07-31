using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsLogger
    {
        private static string SourceName = "DVLD";
        static clsLogger() {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
        }
        public static void LogEvent(Exception ex, EventLogEntryType enType = EventLogEntryType.Error)
        {
            EventLog.WriteEntry(SourceName, HandelMessage(ex), enType);
        }
        private static string HandelMessage(Exception ex) {
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
