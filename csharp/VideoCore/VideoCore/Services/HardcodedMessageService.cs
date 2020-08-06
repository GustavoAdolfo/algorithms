
using VideoCore.Services.Interfaces;

namespace VideoCore.Services
{
    public class HardcodedMessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hardcoded message from a service.";
        }
    }
}
