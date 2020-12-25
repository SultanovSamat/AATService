using System;


namespace XRoadModels
{
    public enum ResponseStatus
    {
        RuntimeError,
        NotFound,
        Incorrect,
        Success,
        ManyFound,
        PingFailedCD,
        PingFailedTunduk,
    }
}