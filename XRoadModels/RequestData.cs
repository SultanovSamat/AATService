using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using XRoadStructure;
using XRoadModels.ExternalService;

namespace XRoadModels
{
    public interface RequestData
    {
        void SetData(RequestParam param);
        ResponseData GetData(IXRoadService client, string member);
    }
}
