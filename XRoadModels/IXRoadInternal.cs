using System.ServiceModel;
using XRoadModels;
using XRoadStructure;

namespace XRoadModels
{
    [XmlSerializerFormat]
    //[XmlObjectSerializer]
    [ServiceContract(Name = "XRoadInternal")]
    public interface IXRoadInternal
    {
        [OperationContract]
        ResponsePaymentDebtSF GetPaymentDebtInfo(RequestPaymentDebtSF request);
        [OperationContract]
        ResponsePaymentDebtGNS taxpayerDataByInn(RequestPaymentDebtGNS request);
        [OperationContract]
        ResponseRegGNS tpDataByINNforBusinessActivity(RequestRegGNS request);
        [OperationContract]
        ResponseGTSWeightAct RequestWeightAct(RequestGTSWeightAct request);
        [OperationContract]
        ResponseGTSCheckpoint RequestPost(RequestGTSCheckpoint request);
        [OperationContract]
        ResponseGTSBrand RequestTradeCars(RequestGTSBrand request);
        [OperationContract]
        ResponseGTSCountry RequestCountry(RequestGTSCountry request);
        [OperationContract]
        ResponsePassportByPSN passportDataByPSN(RequestPassportByPSN request);
        [OperationContract]
        ResponsePhotoByPin passportLastPhotoByPin(RequestPhotoByPin request);
        [OperationContract]
        ResponseAddress asbAddress(RequestAddress request);
        [OperationContract]
        ResponseTransportCurrent transportCurrentInfo(RequestTransportCurrent request);
        [OperationContract]
        ResponseTransportPin transportByPin(RequestTransportPin request);
        [OperationContract]
        ResponseZags zagsPinsByNSPDate(RequestZags request); 
        [OperationContract]
        ResponseDriver driverLicenseStatus(RequestDriver request);
        [OperationContract]
        ResponseForeign foreignByDoc(RequestForeign request);
        [OperationContract]
        ResponseTinSubject getSubjectByTin(RequestTinSubject request);
        [OperationContract]
        ResponseMeta serviceInfo(RequestMeta request);
        [OperationContract]
        ResponseFile DownloadLog(RequestFile request);
    }
}