using Modules.Communication.Context;
using Modules.Communication.Params;
using Modules.Extensions;
using Modules.Packet;
using Modules.Parsers.Context;
using Modules.Parsers.Params;
using Modules.Protocol.Context;
using Modules.Protocol.XGT.Packet;
using Modules.Protocol.XGT.Params;
using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyModule
{
    public partial class PLC_Test : Form
    {
        private SocketParams _params = new SocketParams();
        private SerialParams _srparams = new SerialParams();
        private XGTParams xgtParam = new XGTParams();

        private ComunicationContext _comContext = new ComunicationContext();
        private ParserContext _parserContext = new ParserContext();
        private ProtocolContext _context = new ProtocolContext();

        private object[] defultComboboxItems = new object[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        private List<ComboBox> Collection;
        public PLC_Test()
        {
            InitializeComponent();

            Collection = new List<ComboBox> {   cbb_PLCInfor, cbb_CPUInfor, cbb_SourceOfFrame, 
                                                cbb_CommandType, cbb_DataType, 
                                                cbb_EthernetBaseNumber, cbb_EthernetSlotPosition, 
                                                cbb_BlockCount, cbb_VariableLength };
            
            cbb_PLCInfor.Items.AddRange(Enum.GetValues(typeof(CommunicationType)).Cast<object>().ToArray());
            cbb_CPUInfor.Items.AddRange(Enum.GetValues(typeof(CpuInfor)).Cast<object>().ToArray());
            cbb_SourceOfFrame.Items.AddRange(Enum.GetValues(typeof(CommunicationType)).Cast<object>().ToArray());
            cbb_CommandType.Items.AddRange(Enum.GetValues(typeof(CommandType)).Cast<object>().ToArray());
            cbb_DataType.Items.AddRange(Enum.GetValues(typeof(DataType)).Cast<object>().ToArray());

            cbb_EthernetBaseNumber.Items.AddRange(defultComboboxItems);
            cbb_EthernetSlotPosition.Items.AddRange(defultComboboxItems);
            cbb_BlockCount.Items.AddRange(defultComboboxItems);
            cbb_VariableLength.Items.AddRange(defultComboboxItems);

            _params.IpAddress = "127.0.0.1";
            _params.Port = 2004;
            _comContext.Configure(_params);

            Collection.ForEach(ctn => ctn.SelectedIndex = 0);
        }

        public void receiveEvent(object sender, byte[] fullFrame)
        {
            var pack = _parserContext.CreatePack(fullFrame);

            if (pack is XGTPacket xgtPack)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        txtReciveData.AppendText($"Data Type : {BitConverter.ToString(xgtPack.DataType)} Data SIze : {BitConverter.ToString(xgtPack.DataSize)}, Data : {BitConverter.ToString(xgtPack.Data)}\n");
                    }));
                }
                else
                    txtReciveData.AppendText($"Data Type : {BitConverter.ToString(xgtPack.DataType)} Data SIze : {BitConverter.ToString(xgtPack.DataSize)}, Data : {BitConverter.ToString(xgtPack.Data)}\n");
            }
        }
        private void btn_Connection_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_comContext.IsConnection)
                {
                    _comContext.Connection();
                    _comContext.AddReceivedEvent(receiveEvent);

                    var param =new XGTParserParam();
                    _parserContext.Configure(param);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //헤더 세팅 
            xgtParam.CompanyHeaderParam.CompanyID = txt_CompanyID.Text;
            xgtParam.CompanyHeaderParam.PLCInfo.targetType = (CommunicationType)cbb_PLCInfor.SelectedItem;
            xgtParam.CompanyHeaderParam.CPUInfo= (CpuInfor)cbb_CPUInfor.SelectedItem;
            xgtParam.CompanyHeaderParam.SourceOfFrame = (CommunicationType)cbb_SourceOfFrame.SelectedItem;
            xgtParam.CompanyHeaderParam.EnetPosition.EthernetBaseNumber = cbb_EthernetBaseNumber.SelectedIndex;
            xgtParam.CompanyHeaderParam.EnetPosition.EthernetSlotPosition = cbb_EthernetSlotPosition.SelectedIndex;

            //커맨드 세팅
            xgtParam.CommandParam.CommandType = (CommandType)cbb_CommandType.SelectedItem;
            xgtParam.CommandParam.DataType = (DataType)cbb_DataType.SelectedItem;
            xgtParam.CommandParam.Data.BlockCount = cbb_BlockCount.SelectedIndex;
            xgtParam.CommandParam.Data.VariableLength = cbb_VariableLength.SelectedIndex;
            xgtParam.CommandParam.Data.DataAddress = txt_DataAddress.Text;

            _context.Configure(xgtParam);
            var fullFrameData = _context.GetByteFullFrame();

            _comContext.Sender(fullFrameData);
        }

        #region 테스트용 프레임 Raw정보
        //개별 요청
        //byte[] fullframedata = new byte[]
        //{
        //    0x4c,0x53,0x49,0x53,0x2d,0x58,0x47,0x54,0x00,0x00,      //company id
        //    0x00,0x00,                                              //plc info
        //    0xa0,                                                   //cpu info
        //    0x33,                                                   //source of frame
        //    0x00,0x00,                                              //invoke id
        //    0x0e,0x00,                                              //length
        //    0x00,                                                   //이더넷 위치
        //    0x00,                                                   //예약2

        //    0x54,0x00,                                              //command
        //    0x02,0x00,                                              //datatype

        //    0x00,0x00,                                              //예약1
        //    0x01,0x00,                                              //block count
        //    0x04,0x00,                                              //variable length
        //    0x25,0x4d,0x57,0x31,0x30,                                    //변수 이름 %mw0
        //};

        //byte[] fullFrameData = new byte[]
        //{
        //    0x4C,0x53,0x49,0x53,0x2D,0x58,0x47,0x54,0x00,0x00,      //Company ID
        //    0x00,0x00,0x00,0x33,0x00,0x00,0x1d,0x00,0x00,0xab,0x54,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x04,0x00,0x25,0x47,0x57,0x30, 0x05,0x00,0x25,0x4d,0x57,0x31,0x30,0x06,0x00,0x25,0x4d,0x57,0x31,0x30,0x30,
        //};

        //개별 쓰기 요청
        //byte[] fullFrameData = new byte[]
        //{
        //    0x4C,0x53,0x49,0x53,0x2D,0x58,0x47,0x54,0x00,0x00,                                  //Company ID
        //    0x00,0x00,                                                                          //PLC INFO
        //    0xA0,                                                                               //CPU INFO
        //    0x33,                                                                               //Source of Frame
        //    0x00,0x00,                                                                          //Invoke ID
        //    0x0e,0x00,                                                                          //Length
        //    0x00,                                                                               //이더넷 위치
        //    0x00,                                                                               //예약2

        //    0x58,0x00,                                                                          //Command
        //    0x02,0x00,                                                                          //DataType

        //    0x00,0x00,                                                                          //예약1
        //    0x01,0x00,                                                                          //Block Count 2
        //    0x04,0x00,                                                                          //Variable Length
        //    0x25,0x4d,0x57,0x30,                                                                //변수 이름 %MW0
        //    0x14,0x00,                                                                                      //크기 - byte 갯수 기준
        //    0x01,0x23,0x45,0x67,0x89,0xAB,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xCD,     //데이터 
        //};

        //byte[] fullFrameData = new byte[]
        //{
        //    0x4C,0x53,0x49,0x53,0x2D,0x58,0x47,0x54,0x00,0x00,      //Company ID
        //    0x00,0x00,0x00,0x33,0x00,0x00,0x16,0x00,0x00,0xa4,0x58,0x00,0x14,0x00,0x00,0x00,0x01,0x00,0x06,0x00,0x25,0x4d,0x42,0x30,0x30,0x30,0x04,0x00,0x12,0x34,0x56,0x78
        //};
        #endregion 테스트용 프레임 Raw정보

        private void button1_Click(object sender, EventArgs e)
        {
            txtReciveData.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PLC_Test_Shown(object sender, EventArgs e)
        {
            Collection.Select(ctn => ctn.SelectedIndex = 1);
        }
    }
}
