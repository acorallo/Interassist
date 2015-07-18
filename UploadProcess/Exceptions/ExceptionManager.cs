using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadProcess.Exceptions
{
    public class ExceptionManager
    {

        #region Constants

        private static readonly string sSource = "InterassistSyncroService";
        private static readonly string sLog = "Application";

        private static readonly string sStartMsg = "Start process";
        private static readonly string sStopProcess = "Stop Process";

        #endregion Constants

        #region Methods

        private static void CheckEventLogEntry()
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);
        }


        public static void TrackError(System.Exception ex)
        {
            string errTxt = "Exception: {0}. Erromsg{1}";
            CheckEventLogEntry();
            EventLog.WriteEntry(sSource, string.Format(errTxt, ex.ToString(), ex.Message), EventLogEntryType.Error);
        }

        public static void TrackError(string msg)
        {
            CheckEventLogEntry();
            EventLog.WriteEntry(sSource, msg, EventLogEntryType.Error);
        }
        
        public static void TrackStartProcess()
        {
            CheckEventLogEntry();
            EventLog.WriteEntry(sSource, sStartMsg, EventLogEntryType.Information);
        }

        public static void TrackEndProcess()
        {
            CheckEventLogEntry();
            EventLog.WriteEntry(sSource, sStopProcess, EventLogEntryType.Information);
        }

        public static void TrackInformation(string text)
        {
            CheckEventLogEntry();
            EventLog.WriteEntry(sSource, text, EventLogEntryType.Information);
        }

        #endregion Methods

    }
}
