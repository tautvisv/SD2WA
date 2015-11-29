using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace CustomCalculationServiceConnectionLib
{
    public class CustomCalculationServiceRequest
    {
        private string _key;
        private IDictionary<string,string> _urlParameters;
        private const string ServerAdress = Globals.CalculationService + Globals.ApiPrefix + "/";

        public enum RequestTypeEnum
        {
            GET,
            POST
        }
        public CustomCalculationServiceRequest()
        {
            _urlParameters = new Dictionary<string, string>();
        }

        public string ToRequestString()
        {
            var parameters = _urlParameters.Aggregate("", (current, parameter) => current + string.Format("{0}/{1}/", parameter.Key, parameter.Value));
            return ServerAdress + MethodController + "/" + Key + (!string.IsNullOrEmpty(MethodName) ? MethodName + "/": "") + parameters;
        }

        public string Key
        {
            get { return _key; }
            set { _key = Globals.CalculationServiceKey + value + "/"; }
        }

        public string MethodName { get; set; }
        public string MethodController { get; set; }
        public RequestTypeEnum MethodType { get; set; }

        public void AddParamater(string name, string value)
        {
            _urlParameters.Add(name, value);
        }

        public object Body { get; set; }
    }
}
