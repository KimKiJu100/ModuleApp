using Modules.Communication.Params;
using MyModule.CommunicationUI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyModule.CommunicationUI
{
    public enum BourateSpeed
    {
        Baud1200 = 1200,
        Baud2400 = 2400,
        Baud4800 = 4800,
        Baud9600 = 9600,
        Baud19200 = 19200,
        Baud38400 = 38400,
        Baud57600 = 57600,
        Baud115200 = 115200
    }

    public partial class ucSerial232Params : UserControl, IParamUserControl
    {
        public EventHandler excpetionHandler;

        List<ComboBoxItem<string>> bindingPortitems = new List<ComboBoxItem<string>>();
        List<ComboBoxItem<BourateSpeed>> bindingBaudRateitems = new List<ComboBoxItem<BourateSpeed>>();
        List<ComboBoxItem<Parity>> bindingParityitems = new List<ComboBoxItem<Parity>>();
        List<ComboBoxItem<int>> bindingDatabititems = new List<ComboBoxItem<int>>();
        List<ComboBoxItem<StopBits>> bindingStopbititems = new List<ComboBoxItem<StopBits>>();

        public ucSerial232Params()
        {
            InitializeComponent();
            initClear();
            ItemsSet();
        }

        private void initClear()
        {
            cbb_ComPort.Items.Clear();
            cbb_BaudRate.Items.Clear();
            cbb_Parity.Items.Clear();
            cbb_Databit.Items.Clear();
            cbb_Stopbit.Items.Clear();

            bindingPortitems.Clear();
            bindingBaudRateitems.Clear();
            bindingParityitems.Clear();
            bindingDatabititems.Clear();
            bindingStopbititems.Clear();

            cbb_ComPort.DisplayMember = "Name";
            cbb_ComPort.ValueMember = "TypeCode";

            cbb_BaudRate.DisplayMember = "Name";
            cbb_BaudRate.ValueMember = "TypeCode";

            cbb_Parity.DisplayMember = "Name";
            cbb_Parity.ValueMember = "TypeCode";

            cbb_Databit.DisplayMember = "Name";
            cbb_Databit.ValueMember = "TypeCode";

            cbb_Stopbit.DisplayMember = "Name";
            cbb_Stopbit.ValueMember = "TypeCode";
        }

        private void ItemsSet()
        {
            var ports = SerialPort.GetPortNames();

            foreach (var port in ports) {
                bindingPortitems.Add(new ComboBoxItem<string> { Name = port, TypeCode = port });
            }
            foreach (Parity p in Enum.GetValues(typeof(Parity))) {
                bindingParityitems.Add(new ComboBoxItem<Parity> { Name = p.ToString(), TypeCode = p });
            }
            foreach (StopBits sb in Enum.GetValues(typeof(StopBits))){
                bindingStopbititems.Add(new ComboBoxItem<StopBits> { Name = sb.ToString(), TypeCode = sb });
            }
            foreach (BourateSpeed bs in Enum.GetValues(typeof(BourateSpeed))) {
                bindingBaudRateitems.Add(new ComboBoxItem<BourateSpeed> { Name = bs.ToString(), TypeCode = bs });
            }
            for (int bitCount = 0; bitCount <= 8; bitCount++) {
                bindingDatabititems.Add(new ComboBoxItem<int> { Name = bitCount.ToString(), TypeCode = bitCount });
            }

            SetComboBoxBinding();
        }

        private void SetComboBoxBinding()
        {
            cbb_ComPort.DataSource = bindingPortitems;
            cbb_Parity.DataSource = bindingParityitems;
            cbb_Stopbit.DataSource = bindingStopbititems;
            cbb_BaudRate.DataSource = bindingBaudRateitems;
            cbb_Databit.DataSource = bindingDatabititems;
        }

        public CommParamBase GetParams()
        {
            try
            {
                return new SerialParams
                {
                    PortName = (string)cbb_ComPort.SelectedValue,
                    baudRate = (int)cbb_BaudRate.SelectedValue,
                    DataBits = (int)cbb_Databit.SelectedValue,
                    Parity = (Parity)cbb_Parity.SelectedValue,
                    StopBits = (StopBits)cbb_Stopbit.SelectedValue,
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SetParams(CommParamBase param)
        {
            if (param is SerialParams srParam)
            {
                if (cbb_ComPort.SelectedValue.ToString().Contains(srParam.PortName))
                {
                    cbb_ComPort.SelectedValue = srParam.PortName;
                }
                if (Enum.IsDefined(typeof(BourateSpeed), srParam.baudRate))
                {
                    cbb_BaudRate.SelectedValue = (BourateSpeed)srParam.baudRate;
                }
                if (Enum.IsDefined(typeof(Parity), srParam.Parity))
                {
                    cbb_Parity.SelectedValue = (Parity)srParam.Parity;
                }
                if (Enum.IsDefined(typeof(StopBits), srParam.StopBits))
                {
                    cbb_Stopbit.SelectedValue = (StopBits)srParam.StopBits;
                }

                cbb_Databit.SelectedValue = srParam.DataBits;
            }
        }
    }
}
