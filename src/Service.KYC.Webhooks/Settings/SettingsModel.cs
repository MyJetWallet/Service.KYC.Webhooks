using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.KYC.Webhooks.Settings
{
    public class SettingsModel
    {
        [YamlProperty("KYC.Webhooks.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("KYC.Webhooks.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("KYC.Webhooks.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
