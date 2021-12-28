using System.Runtime.Serialization;
using Service.KYC.Webhooks.Domain.Models;

namespace Service.KYC.Webhooks.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}