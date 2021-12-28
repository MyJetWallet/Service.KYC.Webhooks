using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using Service.KYC.Webhooks.Grpc;

namespace Service.KYC.Webhooks.Client
{
    [UsedImplicitly]
    public class KYCWebhooksClientFactory: MyGrpcClientFactory
    {
        public KYCWebhooksClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IHelloService GetHelloService() => CreateGrpcService<IHelloService>();
    }
}
