using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.MVP.View
{
    public interface IPresenterView
    {
        bool Visible { get; set; }
        bool IsDisposed { get; }
        void PresenterInjection(object presenter);
        void Show();
    }
}
