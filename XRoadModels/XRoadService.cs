using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using XRoadStructure;

namespace XRoadModels
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class XRoadService : XRoadServiceBase, IXRoadService
    {
        public XRoadResponse<ResponseCarrier> GetCarrier(XRoadRequest<RequestCarrier> request)
        {
            return CreateResponse(request, ResponseCarrier.GetData);
        }

        public XRoadResponse<ResponseVehicleWeight> GetVehicleWeight(XRoadRequest<RequestVehicleWeight> request)
        {
            return CreateResponse(request, ResponseVehicleWeight.GetData);
        }

        public XRoadResponse<ResponseCheckpointWeight> GetCheckpointWeight(XRoadRequest<RequestCheckpointWeight> request)
        {
            return CreateResponse(request, ResponseCheckpointWeight.GetData);
        }

        public XRoadResponse<ResponseCheckpoint> GetCheckpoint(XRoadRequest<RequestCheckpoint> request)
        {
            return CreateResponse(request, ResponseCheckpoint.GetData);
        }

        public XRoadResponse<ResponseCountry> GetCountry(XRoadRequest<RequestCountry> request)
        {
            return CreateResponse(request, ResponseCountry.GetData);
        }
        public XRoadResponse<ResponseCheckpointsData> GetCheckpoints(XRoadRequest<RequestCheckpointsData> request)
        {
            return CreateResponse(request, ResponseCheckpointsData.GetData);
        }
    }
}