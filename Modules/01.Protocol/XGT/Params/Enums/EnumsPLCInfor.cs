namespace Modules.Protocol.XGT.Params.Enums
{
    public enum CpuInfor { XGK = 0, XGB_MK, XGI, XGB_IEC, XGR }
    public enum CommunicationType { Client = 0, Server }
    public enum CpuType { CPU_H = 0, CPU_S, CPU_A, CPU_E, CPU_U, CPU_HN, CPU_SN, CPU_UN }
    public enum CpuRedundancyType { Master = 0, Slave }
    public enum CpuState { Normal = 0, Error }
    public enum SystemState { Run = 0, Stop, Error, Debug }

    public enum CommandType { ReadRequest = 0, ReadResponse, WriteRequest, WriteResponse }          //0: 읽기 요구 //1: 읽기 응답 //2:쓰기 요구 //3:쓰기 응답
    public enum DataType { Bit = 0, Byte, Word, DWord, LWord, ByteBlock }                           //0: 개별 Bit //1: 개별 Byte //2:개별 Word //4:DWord //3:개별 Lword // 4:연속 Byte
}
