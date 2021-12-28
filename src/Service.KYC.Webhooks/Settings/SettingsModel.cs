using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.KYC.Webhooks.Settings
{
    public class SettingsModel
    {
        [YamlProperty("KycWebhooks.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("KycWebhooks.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("KycWebhooks.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
