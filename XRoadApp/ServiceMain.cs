using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using XRoadModels;

namespace XRoadApp
{
    public class ServiceMain: ServiceBase
    {
        private ServiceHost m_svcHost = null;
        private ServiceHost m_svcInternal = null;
        public ServiceMain()
        {
            ServiceName = nameof(XRoadService);
        }

        protected override void OnStart(string[] args)
        {
            "Start service".Info();
            try
            {
                if (m_svcHost != null) m_svcHost.Close();
                if (m_svcInternal != null) m_svcInternal.Close();

                m_svcHost = GetService(args);
                m_svcInternal = GetInternal(args);
            }
            catch (Exception ex)
            {
                ex.Error();
            }
        }

        private static ServiceHost GetService(string[] args)
        {
            try
            {
                var host = new ServiceHost(typeof(XRoadService), Util.ServiceUri);
                var smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true,
                    MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
                };
                host.Description.Behaviors.Add(smb);
                host.Open();
                host.DisplayServiceInfo();
                return host;
            }
            catch (Exception ex)
            {
                ex.Error();
                return null;
            }
        }

        private static ServiceHost GetInternal(string[] args)
        {
            try
            {
                var uri = Util.InternalUri;
                var host = new ServiceHost(typeof(XRoadInternal), uri);
                var smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true,
                    MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
                };
                host.Description.Behaviors.Add(smb);
                host.Open();
                return host;
            }
            catch (Exception ex)
            {
                ex.Error();
                return null;
            }
        }

        protected override void OnStop()
        {
            "Stop service".Info();
            if (m_svcHost != null)
            {
                m_svcHost.Close();
                m_svcHost = null;
            }

            if (m_svcInternal != null)
            {
                m_svcInternal.Close();
                m_svcInternal = null;
            }
        }
    }
}
