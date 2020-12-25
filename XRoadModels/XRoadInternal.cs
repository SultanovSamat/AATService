
namespace XRoadModels
{
    public class XRoadInternal : IXRoadInternal
    {
        public ResponsePaymentDebtSF GetPaymentDebtInfo(RequestPaymentDebtSF request) => ResponsePaymentDebtSF.GetData(request);
        public ResponsePaymentDebtGNS taxpayerDataByInn(RequestPaymentDebtGNS request) => ResponsePaymentDebtGNS.GetData(request);
        public ResponseRegGNS tpDataByINNforBusinessActivity(RequestRegGNS request) => ResponseRegGNS.GetData(request);
        public ResponseGTSWeightAct RequestWeightAct(RequestGTSWeightAct request) => ResponseGTSWeightAct.GetData(request);
        public ResponseGTSCheckpoint RequestPost(RequestGTSCheckpoint request) => ResponseGTSCheckpoint.GetData(request);
        public ResponseGTSBrand RequestTradeCars(RequestGTSBrand request) => ResponseGTSBrand.GetData(request);
        public ResponsePassportByPSN passportDataByPSN(RequestPassportByPSN request) => ResponsePassportByPSN.GetData(request);
        public ResponsePhotoByPin passportLastPhotoByPin(RequestPhotoByPin request) => ResponsePhotoByPin.GetData(request);
        public ResponseAddress asbAddress(RequestAddress request) => ResponseAddress.GetData(request);
        public ResponseTransportCurrent transportCurrentInfo(RequestTransportCurrent request) => ResponseTransportCurrent.GetData(request);
        public ResponseTransportPin transportByPin(RequestTransportPin request) => ResponseTransportPin.GetData(request);
        public ResponseZags zagsPinsByNSPDate(RequestZags request) => ResponseZags.GetData(request);
        public ResponseForeign foreignByDoc(RequestForeign request) => ResponseForeign.GetData(request);
        public ResponseDriver driverLicenseStatus(RequestDriver request) => ResponseDriver.GetData(request);
        public ResponseTinSubject getSubjectByTin(RequestTinSubject request) => ResponseTinSubject.GetData(request);
        public ResponseGTSCountry RequestCountry(RequestGTSCountry request) => ResponseGTSCountry.GetData(request);
        public ResponseMeta serviceInfo(RequestMeta request) => ResponseMeta.GetData(request);
        public ResponseFile DownloadLog(RequestFile request) => ResponseFile.GetData(request);
    }
}