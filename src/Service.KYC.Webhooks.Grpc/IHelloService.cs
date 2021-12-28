using System.ServiceModel;
using System.Threading.Tasks;
using Service.KYC.Webhooks.Grpc.Models;

namespace Service.KYC.Webhooks.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}