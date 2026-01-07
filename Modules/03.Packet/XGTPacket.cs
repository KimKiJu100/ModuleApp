using Modules.Packet.Base;
using System;
using System.Text;

namespace Modules.Packet
{
    public class XGTPacket : PacketBase
    {
        public byte[] CompanyID { get; set; }
        public byte[] PLCInfo { get; set; }
        public byte[] CPUInfo { get; set; }
        public byte[] SourceOfFrame { get; set; }
        public byte[] InvokeID { get; set; }
        public byte[] length { get; set; }
        public byte[] EthernetPosition { get; set; }
        public byte[] Reverse2 { get; set; }
        public byte[] CommandType { get; set; }
        public byte[] DataType { get; set; }
        public byte[] Reverse1 { get; set; }
        public byte[] ErrorState { get; set; }
        public byte[] BlockCount { get; set; }
        public byte[] DataSize { get; set; }
        public byte[] Data { get; set; }

    }
}
