using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Devices.Motors.States
{
    /// <summary>
    /// 모션 축 상태를 나타 냅니다.
    /// </summary>
    public class AxisState
    {
        public int AxisNo { get; set; }
        public double CommandPosition { get; set; }     //명령 위치
        public double ActualPosition { get; set; }      //모터 실제 위치
    }
}
