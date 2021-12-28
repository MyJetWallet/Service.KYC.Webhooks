using System;

namespace Service.KYC.Webhooks.Domain.Models
{
    public interface IHelloMessage
    {
        string Message { get; set; }
    }
}
