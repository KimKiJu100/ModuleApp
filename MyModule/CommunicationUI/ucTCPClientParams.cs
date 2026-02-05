using Modules.Communication.Params;
using MyModule.CommunicationUI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyModule.CommunicationUI
{
    public partial class ucTCPClientParams : UserControl, IParamUserControl
    {
        public ucTCPClientParams()
        {
            InitializeComponent();
        }

        public CommParamBase GetParams()
        {
            try
            {
                return new SocketParams
                {
                    IpAddress = "test2",
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SetParams(CommParamBase param)
        {
            throw new NotImplementedException();
        }
    }
}
