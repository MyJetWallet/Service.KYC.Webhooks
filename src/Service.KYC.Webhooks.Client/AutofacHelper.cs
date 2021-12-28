using Autofac;
using Service.KYC.Webhooks.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.KYC.Webhooks.Client
{
    public static class AutofacHelper
    {
        public static void RegisterKYCWebhooksClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new KYCWebhooksClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetHelloService()).As<IHelloService>().SingleInstance();
        }
    }
}
