using System;
using System.Configuration;

namespace XRoadModels
{
    public static partial class Util
    {
        public static string IP { get; private set; }
        public static string Port { get; private set; }
        public static string PasswordHash { get; private set; }
        public static string MemberClass { get; set; } = "GOV";
        public static string XRoadInstance { get; set; } = "central-server";
        public static string XRoadId { get; set; } = "1";
        public static string XRoadIssue { get; set; } = "1";
        public static string XRoadProtocol { get; set; } = "4.0";
        public static string XRoadUser { get; set; } = "1";
        public static string MemberCode { get; private set; }
        public static string MemberCodeSF { get; private set; }
        public static string MemberCodeGTS { get; private set; }
        public static string MemberCodeGRS { get; private set; }
        public static string MemberCodeJur { get; private set; }
        public static string MemberCodeGNS { get; private set; }
        public static string SubsystemCode { get; private set; }
        public static string SubsystemCodeSF { get; private set; }
        public static string SubsystemCodeGTS { get; private set; }
        public static string SubsystemCodeGNS { get; private set; }
        public static string SubsystemCodePassport { get; private set; }
        public static string SubsystemCodeAddress { get; private set; }
        public static string SubsystemCodeZags { get; private set; }
        public static string SubsystemCodeForeign { get; private set; }
        public static string SubsystemCodeVehicles { get; private set; }
        public static string SubsystemCodeDriver { get; private set; }
        public static string SubsystemCodeJur { get; private set; }
        public static string ServiceVersion { get; private set; } = "v1";

        static Util()
        {
            IP = ConfigurationManager.AppSettings["ip"];
            if (IP == string.Empty)
                throw new ApplicationException($"Parameter '{nameof(IP)}' not set in config");

            Port = ConfigurationManager.AppSettings["port"];
            if (Port == string.Empty)
                throw new ApplicationException($"Parameter 'port' not set in config");

            PasswordHash = ConfigurationManager.AppSettings["pswHash"];
            if (PasswordHash == string.Empty)
                throw new ApplicationException($"Parameter 'pswHash' not set in config");

            MemberCode = ConfigurationManager.AppSettings["memberCode"];
            if (MemberCode == string.Empty)
                throw new ApplicationException($"Parameter 'memberCode' not set in config");

            MemberCodeSF = ConfigurationManager.AppSettings["memberCodeSF"];
            if (MemberCodeSF == string.Empty)
                throw new ApplicationException($"Parameter 'memberCodeSF' not set in config");

            MemberCodeGNS = ConfigurationManager.AppSettings["memberCodeGNS"];
            if (MemberCodeGNS == string.Empty)
                throw new ApplicationException($"Parameter 'memberCodeGNS' not set in config");

            MemberCodeGTS = ConfigurationManager.AppSettings["memberCodeGTS"];
            if (MemberCodeGTS == string.Empty)
                throw new ApplicationException($"Parameter 'memberCodeGTS' not set in config");

            MemberCodeGRS = ConfigurationManager.AppSettings["memberCodeGRS"];
            if (MemberCodeGRS == string.Empty)
                throw new ApplicationException($"Parameter 'memberCodeGRS' not set in config");

            MemberCodeJur = ConfigurationManager.AppSettings["memberCodeJur"];
            if (MemberCodeJur == string.Empty)
                throw new ApplicationException($"Parameter 'memberCodeJur' not set in config");

            SubsystemCode = ConfigurationManager.AppSettings["subsystemCode"];
            if (SubsystemCode == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCode' not set in config");

            SubsystemCodeSF = ConfigurationManager.AppSettings["subsystemCodeSF"];
            if (SubsystemCodeSF == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeSF' not set in config");

            SubsystemCodeGNS = ConfigurationManager.AppSettings["subsystemCodeGNS"];
            if (SubsystemCodeGNS == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeGNS' not set in config");

            SubsystemCodeGTS = ConfigurationManager.AppSettings["subsystemCodeGTS"];
            if (SubsystemCodeGTS == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeGTS' not set in config");

            SubsystemCodePassport = ConfigurationManager.AppSettings["subsystemCodeGRSPassport"];
            if (SubsystemCodePassport == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeGRSPassport' not set in config");

            SubsystemCodeAddress = ConfigurationManager.AppSettings["subsystemCodeGRSAddress"];
            if (SubsystemCodeAddress == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeGRSAddress' not set in config");

            SubsystemCodeZags = ConfigurationManager.AppSettings["subsystemCodeGRSZags"];
            if (SubsystemCodeZags == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeGRSZags' not set in config");

            SubsystemCodeForeign = ConfigurationManager.AppSettings["subsystemCodeGRSForeign"];
            if (SubsystemCodeForeign == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeGRSForeign' not set in config");

            SubsystemCodeVehicles = ConfigurationManager.AppSettings["subsystemCodeGRSVehicles"];
            if (SubsystemCodeVehicles == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeGRSVehicles' not set in config");

            SubsystemCodeDriver = ConfigurationManager.AppSettings["subsystemCodeGRSDriver"];
            if (SubsystemCodeDriver == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeGRSDriver' not set in config");

            SubsystemCodeJur = ConfigurationManager.AppSettings["subsystemCodeJur"];
            if (SubsystemCodeJur == string.Empty)
                throw new ApplicationException($"Parameter 'subsystemCodeJur' not set in config");
        }

        public static ResponseStatus ToStatus(this Enum state)
        {
            return state.ToString().ToStatus();
        }

        public static ResponseStatus ToStatus(this string state)
        {
            var result = ResponseStatus.RuntimeError;
            try
            {
                result = (ResponseStatus)Enum.Parse(typeof(ResponseStatus), state);
            }
            catch (Exception ex)
            {
                ex.Error();
            }
            return result;
        }

        public static decimal ToTon(this decimal value)
        {
            return value / 1000;
        }
    }
}