using System;
using NLog;

namespace XRoadModels
{
    public static partial class Util
    {
        public static readonly Logger _logger = LogManager.GetLogger("*");
        public static readonly Logger _loggerOut = LogManager.GetLogger("logOut");

        public static Logger GetCurLog(string service = "")
        {
            if (string.IsNullOrEmpty(service)) return _logger;
            return LogManager.GetLogger(service);
        }

        public static void Info(this string msg, string service = "")
        {
            GetCurLog(service).Info(msg);
        }
        public static void InfoOut(this string msg)
        {
            _loggerOut.Info(msg);
        }
        public static void Warn(string msg, string service = "")
        {
            GetCurLog(service).Warn(msg);
        }
        public static void ErrorOut(this Exception ex)
        {
            _loggerOut.Error(ex);
        }
        public static void ErrorOut(this string msg)
        {
            _loggerOut.Error(msg);
        }
        public static void Error(this Exception ex, string service = "")
        {
            GetCurLog(service).Error(ex);
        }
        public static void Error(this string msg, string service = "")
        {
            GetCurLog(service).Error(msg);
        }
        public static void ErrorDataOut(this Exception ex, string requestData)
        {
            $"{requestData}".ErrorOut();
            ex.ErrorOut();
        }
        public static void ErrorData(this Exception ex, string requestData, string service = "")
        {
            $"{requestData}".Error(service);
            ex.Error(service);
        }
        public static void WriteInfo(this ResponseBase item)
        {
            $"{item.GetResponseData()}".InfoOut();
        }
    }
}
