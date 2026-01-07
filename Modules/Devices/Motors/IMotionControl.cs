using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Devices.Motors
{
    /// <summary>
    /// 모터 장치 추상화
    /// </summary>
    public interface IMotionControl : IMotionState, IMotionAction, IMotionAlarm
    {
        string keyName { set; get; }
    }
}
