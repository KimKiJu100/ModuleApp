using Modules.Devices.Motors.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Devices.Motors
{
    /// <summary>
    /// 모터 상태 관련 추상화
    /// </summary>
    public interface IMotionState
    {
        MotionState GetState();
    }
}
