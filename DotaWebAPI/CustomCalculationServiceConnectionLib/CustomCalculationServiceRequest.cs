using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomCalculationServiceConnectionLib
{
    public class CustomCalculationServiceRequest
    {
        private const string ServerAdress = "http://localhost:13816/api/";

        public enum RequestTypeEnum
        {
            GET,
            POST
        }
        public CustomCalculationServiceRequest()
        {
            
        }

        public string ToRequestString()
        {
            return ServerAdress + MethodController + "/" + (!string.IsNullOrEmpty(MethodName)? MethodName + "/" : "") + string.Join("/", URLParameters);
        }
        public string MethodName { get; set; }
        public string MethodController { get; set; }
        public RequestTypeEnum MethodType { get; set; }
        public IEnumerable<string> URLParameters { get; set; }
        public object Body { get; set; }
    }
}
