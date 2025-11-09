using Modules.Communication.Intefaces;
using Modules.Communication.Params;

namespace Modules.Communication.Connection.Strategies
{
    public interface ICommunicationConnectionStrategy
    {
        bool CanHandle(CommParamBase param);
        ICommunicationConnection Create();
    }
}
