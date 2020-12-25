using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using XRoadStructure;
using XRoadModels.ExternalService;

namespace XRoadModels
{
    [DataContract(IsReference = false)]
    [KnownType(typeof(ResponseVehicleWeight))]
    [KnownType(typeof(ResponseCheckpointWeight))]
    [KnownType(typeof(ResponseCheckpoint))]
    [KnownType(typeof(ResponseCountry))]
    [KnownType(typeof(ResponseCarrier))]
    public class ResponseBase
    {
        [DataMember]
        public ResponseStatus State { get; set; }
        public ResponseBase()
        {
            State = ResponseStatus.Success; 
        }

        public virtual string GetResponseData() => State.ToString();
    }
}
