using Modules.Protocol.Base;
using Modules.Protocol.XGT.Packet.CommandFormat;
using Modules.Protocol.XGT.Packet.CompanyHeader.Mapper;
using Modules.Protocol.XGT.Packet.Mapper.CPUInfors;
using Modules.Protocol.XGT.Packet.Mapper.EthernetPositions;
using Modules.Protocol.XGT.Packet.Mapper.PLCInfor;
using Modules.Protocol.XGT.Packet.Mapper.SourceOfFrame;
using Modules.Protocol.XGT.Params;
using System.Collections.Generic;
using System;

namespace Modules.Protocol.XGT.Packet
{
    public class XGTPacketBuild : PacketBase
    {
        //전체 RawData
        private byte[] _rawFullPacket;
        public byte[] RawFullPacket { get => _rawFullPacket; }

        private readonly List<IPacketSectionBuilder> _buildersCollection;

        private readonly List<IPacketSectionBuilder> _optionalBuilders;

        public XGTPacketBuild()
        {
            _buildersCollection = new List<IPacketSectionBuilder>
            {
                new CompanyIDPacketBuilder(),           //[1] CommanyID
                new ParameterPacketBuilder(),           //[2] PLC Info 
                new CpuInforPacketMapper(),             //[3] Cpu Info 
                new SourceOfFramePacketMapper(),        //[4] Source
                new NoneDataPacketBuilder(),            //[5] invoke ID
                new NoneDataPacketBuilder(),            //[6] Length Placeholder (추후 수정) << 커맨드 파라미터로 연산 예정
                new EthernetPositionPacketBuilder(),    //[7] Ethernet Position
                new OneByteNoneDataPacketBuilder(),     //[8] Reserved2
                new CommandTypePacketMapper(),          //[9] Command
                new DataTypePacketMapper(),             //[10] Data
                new NoneDataPacketBuilder(),            //[11] reserved
                new BlockCountPacketConverter(),        //[12] Block Count
                new VariableLengthPacketConverter(),    //[13] Variable Length
                new VariableNameConverter(),            //[14] Variable Name
            };

            _optionalBuilders = new List<IPacketSectionBuilder>
            {
                //[15] Data Count
                //[16] Data Value
            };
        }

        public override byte[] BuildPacket(ProtocolParamBase param)
        {
            if (param is XGTParams xgtParam)
            {
                //Frame을 만드는 로직
                var bytes = new List<byte>();

                foreach (var builder in _buildersCollection) {
                    bytes.AddRange(builder.Build(xgtParam));
                }

                // [15] Data Count
                // [16] Data Value

                _rawFullPacket = bytes.ToArray();
                return RawFullPacket;
            }
            else 
                throw new Exception($"param 변환이 되지 않습니다. {param.GetType().Name}");
        }

        public override bool CanParams(ProtocolParamBase paramBase)
        {
            if (paramBase is XGTParams) return true;
            else return false;
        }
    }
}
