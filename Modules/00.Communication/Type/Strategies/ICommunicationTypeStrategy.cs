using Modules._00.Communication.State;
using Modules.Communication.Params;

namespace Modules.Communication.Type.Strategies
{
    public interface ICommunicationTypeStrategy
    {
        bool CanHandle(CommParamBase param);
        TypeBase Create();
    }
}
