using System.ServiceModel;
using XRoadModels;
using XRoadStructure;

namespace XRoadModels
{
    [XmlSerializerFormat]
    [ServiceContract(Name = "XRoadService", Namespace = "http://tunduk-aat.x-road.fi/producer")]
    [WsdlDocumentation("mtd-services")]
    public interface IXRoadService
    {
        [OperationContract]
        [WsdlDocumentation("GetCarrier method for getting info on Carrier and his licenses")]
        [return: WsdlParamOrReturnDocumentation("Carrier and his licenses info")]
        XRoadResponse<ResponseCarrier> GetCarrier([WsdlParamOrReturnDocumentation("Carrier request data")]
                                           XRoadRequest<RequestCarrier> request);

        [OperationContract]
        [WsdlDocumentation("GetVehicleWeight method for getting info on vehicle weight control.")]
        [return: WsdlParamOrReturnDocumentation("Vehicle weight control info")]
        XRoadResponse<ResponseVehicleWeight> GetVehicleWeight([WsdlParamOrReturnDocumentation("Vehicle request data")]
                                           XRoadRequest<RequestVehicleWeight> request);

        [OperationContract]
        [WsdlDocumentation("GetCheckpointWeight method for getting info on checkpoint weight control.")]
        [return: WsdlParamOrReturnDocumentation("Checkpoint weight control info")]
        XRoadResponse<ResponseCheckpointWeight> GetCheckpointWeight([WsdlParamOrReturnDocumentation("Checkpoint request data")]
                                           XRoadRequest<RequestCheckpointWeight> request);

        [OperationContract]
        [WsdlDocumentation("GetCheckpoint method for getting info on checkpoint.")]
        [return: WsdlParamOrReturnDocumentation("Checkpoint info")]
        XRoadResponse<ResponseCheckpoint> GetCheckpoint([WsdlParamOrReturnDocumentation("Checkpoint request data")]
                                           XRoadRequest<RequestCheckpoint> request);

        [OperationContract]
        [WsdlDocumentation("GetCountry method for getting info on country.")]
        [return: WsdlParamOrReturnDocumentation("Country info")]
        XRoadResponse<ResponseCountry> GetCountry([WsdlParamOrReturnDocumentation("Country request data")]
                                           XRoadRequest<RequestCountry> request);
        [OperationContract]
        [WsdlDocumentation("GetCheckpoints method for getting info on weight control checkpoints.")]
        [return: WsdlParamOrReturnDocumentation("Checkpoints info")]
        XRoadResponse<ResponseCheckpointsData> GetCheckpoints([WsdlParamOrReturnDocumentation("Checkpoints request data")]
                                           XRoadRequest<RequestCheckpointsData> request);
    }
}