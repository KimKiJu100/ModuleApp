using Modules.Communication.Params;

namespace Modules.Communication.Type.Strategies
{
    public interface ICommunicationTypeStrategy
    {
        bool CanHandle(CommParamBase param);
        TypeBase Create();
    }
}
