using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using XRoadStructure;
using XRoadModels.ExternalService;

namespace XRoadModels
{
    public class RequestParam
    {
        public string Data { get; set; }
        public bool IsData { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public string Number { get; set; }
        public string Series { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }

        public RequestParam(string data)
        {
            Data = data;
        }
        public RequestParam(string data, string code)
        {
            Data = data;
            Number = code;
        }
        public RequestParam(string data, string bodyNo, string engineNo, string chassisNo)
        {
            Data = data;
            Number = bodyNo;
            EngineNo = engineNo;
            ChassisNo = chassisNo;
        }

        public RequestParam(string data, bool isData = true, DateTime? start = null, DateTime? end = null)
        {
            Data = data;
            IsData = isData;
            Start = start;
            End = end;
        }

        public RequestParam(string data, string number, string series)
        {
            Data = data;
            Number = number;
            Series = series;
        }
        public RequestParam(string name, string surname, string patronymic, DateTime date)
        {
            Data = name;
            Surname = surname;
            Patronymic = patronymic;
            Start = date;
        }
    }
}
