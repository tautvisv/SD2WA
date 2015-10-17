using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CustomCalculationServiceConnectionLib.Helpers;
using Newtonsoft.Json;
using ServiceStack;

namespace CustomCalculationServiceConnectionLib
{
    public class CustomCalculationServiceConnection : IServiceConnection
    {
        public CustomCalculationServiceConnection()
        {
            
        }

        public object Request(CustomCalculationServiceRequest request)
        {
            using (var client = new JsonServiceClient())
            {
                switch (request.MethodType)
                {
                    case CustomCalculationServiceRequest.RequestTypeEnum.POST:
                        var json = JsonConvert.SerializeObject(request.Body);
                        return client.Post<object>(request.ToRequestString(), json);
                    case CustomCalculationServiceRequest.RequestTypeEnum.GET:
                        return client.Get<object>(request.ToRequestString());
                    default:
                        throw new NotImplementedException("Šitas metodas neimplementuotas: " + request.MethodType);
                }
            }
        }

    }
}
