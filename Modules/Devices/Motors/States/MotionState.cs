using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Devices.Motors.States
{
    /// <summary>
    /// 모션 상태데이터를 관리 합니다.
    /// 축이 아닌 디바이스 기준으로 관리 합니다.
    /// </summary>
    public class MotionState
    {
        public List<AxisState> axisStates = new List<AxisState>();

        public bool ServoOn { get; set; }               //서보 전원 상태
        public bool AlarmOn { get; set; }               //알람 상태
        public bool HomeSensorOn { get; set; }          //원점 상태
        public bool LimitPositiveOn { get; set; }       //리밋 센서 + 상태
        public bool LimitNegativeOn { get; set; }       //리밋 센서 - 상태
        public bool EmergencyOn { get; set; }           //비상 정지 상태
    }
}
