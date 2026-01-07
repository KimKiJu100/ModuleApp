using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Intefaces
{
    public interface ITypeBasedInjectable
    {
        void SetInstance(TypeBase Type);    // 인스턴스 주입
    }
}
