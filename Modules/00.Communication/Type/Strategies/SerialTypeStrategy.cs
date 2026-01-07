using Modules.Communication.Params;

namespace Modules.Communication.Type.Strategies
{
    public class SerialTypeStrategy : ICommunicationTypeStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SerialParams;

        public TypeBase Create() => new Serial232Type();
    }
}
