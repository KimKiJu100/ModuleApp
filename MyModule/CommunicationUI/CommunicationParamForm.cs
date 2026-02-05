using Modules.Communication.Params;
using MyModule.CommunicationUI.Interface;
using MyModule.Event;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyModule.CommunicationUI
{
    public partial class CommunicationParamForm : Form
    {
        private readonly Communicationbehavior _behavior;
        public List<ComboBoxItem<CommunicationType>> bindingitems = new List<ComboBoxItem<CommunicationType>>();

        private CommParamBase _bufferParam = null;

        public EventHandler<ComunicationParamOKEventArgs> OnClickParameter;
        
        public CommunicationParamForm(CommParamBase bufferParam)
        {
            InitializeComponent();
            this.Shown += CommunicationParamForm_Shown;
            _behavior = new Communicationbehavior();

            _bufferParam = bufferParam;
        }
        public CommunicationParamForm()
        {
            InitializeComponent();
            this.Shown += CommunicationParamForm_Shown;
            _behavior = new Communicationbehavior();
        }

        #region 생성에 관련된 이벤트 정의
        private void CommunicationParamForm_Shown(object sender, EventArgs e)
        {
            Lazyinitialize();
        }
        private void Lazyinitialize()
        {
            cbb_CommunicationType.SelectedValueChanged -= cbb_CommunicationType_SelectedValueChanged;

            cbb_CommunicationType.Items.Clear();
            cbb_CommunicationType.DisplayMember = "Name";
            cbb_CommunicationType.ValueMember = "TypeCode";

            bindingitems.Add(new ComboBoxItem<CommunicationType> { Name = "NONE", TypeCode = CommunicationType.None });
            bindingitems.Add(new ComboBoxItem<CommunicationType> { Name = "Serrial", TypeCode = CommunicationType.SerrialType });
            bindingitems.Add(new ComboBoxItem<CommunicationType> { Name = "TCPClient", TypeCode = CommunicationType.TCPClientType });

            cbb_CommunicationType.DataSource = bindingitems;

            cbb_CommunicationType.SelectedValueChanged += cbb_CommunicationType_SelectedValueChanged;
            btn_OK.Click+= btn_OK_Click;
            btn_Cancel.Click += btn_Cancel_Click;


            if (_bufferParam is SerialParams)
                cbb_CommunicationType.SelectedValue = CommunicationType.SerrialType;
            else
                cbb_CommunicationType.SelectedValue = CommunicationType.TCPClientType;
        }
        #endregion 생성에 관련된 이벤트 정의

        private void cbb_CommunicationType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox cbb)
            {
                var type = (CommunicationType)cbb.SelectedValue;
                var uc = _behavior.GetComunicationParamsFormType(type);

                if (pnl_Content.Controls.Count >= 1)
                {
                    foreach (Control control in pnl_Content.Controls)
                    {
                        control.Dispose();
                    }

                    if (uc is ucSerial232Params ucSerial &&
                        _bufferParam != null &&
                        _bufferParam is SerialParams param)
                    {
                        ucControlTypeCheckAndSetParam(ucSerial, param);
                    }
                    else if (uc is ucTCPClientParams ucTCP &&
                        _bufferParam != null &&
                        _bufferParam is SocketParams socParam)
                    {
                        ucControlTypeCheckAndSetParam(ucTCP, socParam);
                    }

                    pnl_Content.Controls.Add(uc);
                }
                else
                {
                    if (uc is ucSerial232Params ucSerial &&
                        _bufferParam != null &&
                        _bufferParam is SerialParams param)
                    {
                        ucControlTypeCheckAndSetParam(ucSerial, param);
                    }
                    else if (uc is ucTCPClientParams ucTCP &&
                        _bufferParam != null &&
                        _bufferParam is SocketParams socParam)
                    {
                        ucControlTypeCheckAndSetParam(ucTCP, socParam);
                    }

                    pnl_Content.Controls.Add(uc);
                }
               
            }
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            var activeUserControl = _behavior.ActiveUCParamChecked(pnl_Content);

            //파라미터 세팅
            _bufferParam = ucControlTypeCheckAndGetParam(activeUserControl);

            if(_bufferParam != null)
            {
                this.Tag = _bufferParam;      
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private CommParamBase ucControlTypeCheckAndGetParam(UserControl userControl)
        {
            if (userControl is IParamUserControl uc)
            {
                return uc.GetParams();
            }
            else
            {
                throw new Exception($"User Control Type Miss Matching{nameof(userControl)}");
            }
        }

        private void ucControlTypeCheckAndSetParam(UserControl userControl,CommParamBase @param)
        {
            if (userControl is IParamUserControl uc)
            {
                uc.SetParams(@param);
            }
            else
            {
                throw new Exception($"User Control Type Miss Matching{nameof(userControl)}");
            }
        }
    }
}
