using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using MyJetWallet.Sdk.ServiceBus;
using Service.KYC.Domain.Models.Messages;

namespace Service.KYC.Webhooks.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceBus =
                builder.RegisterMyServiceBusTcpClient(Program.ReloadedSettings(t => t.SpotServiceBusHostPort),
                    Program.LogFactory);
            builder.RegisterMyServiceBusPublisher<KycVerificationResultMessage>(serviceBus, KycVerificationResultMessage.TopicName, true);
        }
    }
}