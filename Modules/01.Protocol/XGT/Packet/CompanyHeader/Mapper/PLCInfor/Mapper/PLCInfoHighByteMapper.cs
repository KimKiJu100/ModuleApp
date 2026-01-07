using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.Mapper
{
    public class PLCInfoHighByteMapper
    {
        private readonly Dictionary<SystemState, byte> SystemTypeMap = new Dictionary<SystemState, byte>()
        {
            { SystemState.Run, 0x01 },
            { SystemState.Stop, 0x02 },
            { SystemState.Error, 0x04 },
            { SystemState.Debug, 0x08 },
        };

        public byte GetByte(SystemState state)
        {
            if(!SystemTypeMap.TryGetValue(state,out byte _byte))
                throw new Exception("지원하지 않는 System State 입니다.");

            return _byte;
        }
    }
}
