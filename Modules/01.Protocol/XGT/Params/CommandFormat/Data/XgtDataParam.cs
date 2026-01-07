using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Params.CommandFormat.Data
{
    public class XgtDataParam
    {
        public int BlockCount { get; set; } = 0;                            //블럭 수 
        public int VariableLength { get; set; } = 0;                        //변수 이름 길이 
        public string DataAddress { get; set; } = string.Empty;             //변수 주소 
        public int DataByteCount { get; set; } = 0;                         //쓰기 데이터 갯수
        public List<byte> Value { get; private set; } = new List<byte>();   //쓰기 데이터 값
    }
}
