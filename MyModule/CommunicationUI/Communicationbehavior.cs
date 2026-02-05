using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Forms;

namespace MyModule.CommunicationUI
{
    public enum CommunicationType
    {
        None,
        SerrialType,
        TCPClientType,
    }
    public class Communicationbehavior
    {

        public Communicationbehavior()
        {
                
        }

        public UserControl GetComunicationParamsFormType(CommunicationType type)
        {
            switch (type)
            {
                case CommunicationType.SerrialType: 
                    return new ucSerial232Params();
                case CommunicationType.TCPClientType: 
                    return new ucTCPClientParams();
                default:
                    return new ucTCPClientParams();
            }
        }
        public UserControl ActiveUCParamChecked(Control sourceControl)
        {
            if (sourceControl.Controls.Count == 0)
                return null;

            return sourceControl.Controls[0] as UserControl;
        }
    }
}
