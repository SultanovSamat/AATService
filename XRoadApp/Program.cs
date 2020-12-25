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
    static class Program
    {
        static void Main()
        {
            if (!Environment.UserInteractive)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new ServiceMain()
                }; 
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                "Begin".Info();
                ServiceHost host = null;
                ServiceHost hostInternal = null;
                try
                {
                    host = new ServiceHost(typeof(XRoadService), Util.ServiceUri);
                    var smb = new ServiceMetadataBehavior { HttpGetEnabled = true, MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }, };
                    host.Description.Behaviors.Add(smb);
                    host.Open();
                    host.DisplayServiceInfo();

                    hostInternal = new ServiceHost(typeof(XRoadInternal), Util.InternalUri);
                    var smbInternal = new ServiceMetadataBehavior { HttpGetEnabled = true, MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }, };
                    hostInternal.Description.Behaviors.Add(smbInternal);
                    hostInternal.Open();
                    hostInternal.DisplayServiceInfo();
                    $"Press <Enter> to stop the service.".Info();
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    ex.Error();
                }
                finally
                {
                    if (host != null)
                    {
                        if (host.State != CommunicationState.Faulted)
                            host.Close();
                        else
                            host.Abort();
                    }
                    if (hostInternal != null)
                    {
                        if (hostInternal.State != CommunicationState.Faulted)
                            hostInternal.Close();
                        else
                            hostInternal.Abort();
                    }
                }
                "End".Info();
            }
        }
    }
}
