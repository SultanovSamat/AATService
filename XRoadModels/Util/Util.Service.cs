using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NLog;
using System.Configuration;
using System.ComponentModel;
using System.ServiceModel;
using XRoadModels.ExternalService;
using XRoadStructure;
using System.ServiceModel.Description;
using XRoadModels.ws_ExternalSF;

namespace XRoadModels
{
    public static partial class Util
    {
        private static string ServiceName
        {
            get
            {
                var name = string.Empty;
                foreach (var elem in TypeDescriptor.GetAttributes(typeof(IXRoadService)))
                {
                    if (elem.GetType() == typeof(ServiceContractAttribute))
                    {
                        name = ((ServiceContractAttribute)elem).Name;
                    }
                }
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Service contract doesn't have a name!");
                return name;
            }
        }

        private static string InternalName
        {
            get
            {
                var name = string.Empty;
                foreach (var elem in TypeDescriptor.GetAttributes(typeof(IXRoadInternal)))
                {
                    if (elem.GetType() == typeof(ServiceContractAttribute))
                    {
                        name = ((ServiceContractAttribute)elem).Name;
                    }
                }
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Service contract doesn't have a name!");
                return name;
            }
        }

        public static Uri ServiceUri
        {
            get
            {
                return new Uri($"http://{IP}:{Port}/{ServiceName}");
            }
        }

        public static Uri InternalUri
        {
            get
            {
                return new Uri($"http://{IP}:{Port}/{InternalName}");
            }
        }

        public static void DisplayServiceInfo(this ServiceHost host)
        {
            try
            {
                foreach (var endpoint in host.Description.Endpoints)
                {
                    var security = endpoint.Binding.GetType().GetProperty(nameof(BasicHttpBinding.Security)).GetValue(endpoint.Binding);
                    $"{nameof(BasicHttpSecurity.Mode)}: {security.GetType().GetProperty(nameof(BasicHttpSecurity.Mode)).GetValue(security)}".Info();
                    var message = security.GetType().GetProperty(nameof(BasicHttpSecurity.Message)).GetValue(security);
                    $"{nameof(BasicHttpMessageSecurity.AlgorithmSuite)}: {message.GetType().GetProperty(nameof(BasicHttpMessageSecurity.AlgorithmSuite)).GetValue(message)}".Info();
                    $"{nameof(BasicHttpMessageSecurity.ClientCredentialType)}: {message.GetType().GetProperty(nameof(BasicHttpMessageSecurity.ClientCredentialType)).GetValue(message)}".Info();
                    var transport = security.GetType().GetProperty(nameof(BasicHttpSecurity.Transport)).GetValue(security);
                    $"{nameof(BasicHttpSecurity.Transport)}.{nameof(HttpTransportSecurity.ClientCredentialType)}: {transport.GetType().GetProperty(nameof(HttpTransportSecurity.ClientCredentialType)).GetValue(transport)}".Info();
                }
                $"The service is available at {host.Description.Endpoints[0].Address}".Info();
            }
            catch (Exception ex)
            {
                ex.Error();
            }
        }

        public static ws_ExternalClient WSClient
        {
            get
            {
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslpolicyerrors) => true;
                    var initClient = new ws_ExternalClient();
                    initClient.ClientCredentials.UserName.UserName = "admin";
                    initClient.ClientCredentials.UserName.Password = Util.PasswordHash;
                    return initClient;
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static void SetSecurity()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslpolicyerrors) => true;
        }

        public static PaymentDebtInfoServiceClient WSClientSF
        {
            get
            {
                try
                {
                    SetSecurity();
                    return new PaymentDebtInfoServiceClient();
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalGNSDebt.GnsServicePortTypeClient WSClientGNSDebt
        {
            get
            {
                try
                {
                    SetSecurity();
                    return new ws_ExternalGNSDebt.GnsServicePortTypeClient();
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }
        public static ws_ExternalGNSReg.GnsServicePortTypeClient WSClientGNSReg
        {
            get
            {
                try
                {
                    SetSecurity();
                    return new ws_ExternalGNSReg.GnsServicePortTypeClient();
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalPassport.InfocomServicePortTypeClient WSClientGRSPassport
        {
            get
            {
                try
                {
                    SetSecurity();
                    var cl = new ws_ExternalPassport.InfocomServicePortTypeClient();
                    //cl.Endpoint.Behaviors.Add(new InspectorBehavior());
                    return cl;
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalAddress.InfocomServicePortTypeClient WSClientGRSAddress
        {
            get
            {
                try
                {
                    SetSecurity();
                    var initClient = new ws_ExternalAddress.InfocomServicePortTypeClient();
                    return initClient;
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalVehicles.InfocomServicePortTypeClient WSClientGRSVehicle
        {
            get
            {
                try
                {
                    SetSecurity();
                    var initClient = new ws_ExternalVehicles.InfocomServicePortTypeClient();
                    return initClient;
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalZags.InfocomServicePortTypeClient WSClientGRSZags
        {
            get
            {
                try
                {
                    SetSecurity();
                    return new ws_ExternalZags.InfocomServicePortTypeClient();
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalDriver.InfocomServicePortTypeClient WSClientGRSDriver
        {
            get
            {
                try
                {
                    SetSecurity();
                    return new ws_ExternalDriver.InfocomServicePortTypeClient();
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalForeign.InfocomServicePortTypeClient WSClientGRSForeign
        {
            get
            {
                try
                {
                    SetSecurity();
                    var initClient = new ws_ExternalForeign.InfocomServicePortTypeClient();
                    return initClient;
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalGTS.MTDServiceClient WSClientGTS
        {
            get
            {
                try
                {
                    SetSecurity();
                    var initClient = new ws_ExternalGTS.MTDServiceClient();
                    return initClient;
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalJur.SubjectPortClient WSClientJur
        {
            get
            {
                try
                {
                    SetSecurity();
                    var initClient = new ws_ExternalJur.SubjectPortClient();
                    return initClient;
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }

        public static ws_ExternalMeta.metaServicesPortClient WSClientMeta
        {
            get
            {
                try
                {
                    SetSecurity();
                    var initClient = new ws_ExternalMeta.metaServicesPortClient();
                    return initClient;
                }
                catch (Exception ex)
                {
                    ex.Error();
                    throw;
                }
            }
        }
    }
}