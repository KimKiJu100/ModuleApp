using App.CoreModules.Thread;
using App.CoreModules.Thread.interfaces;
using Modules.Communication.Context;
using Modules.Communication.Params;
using MyModule.Actions;
using MyModule.CommunicationUI;
using MyModule.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyModule
{
    public partial class ScannerTest : Form
    {
        private ComunicationContext comContext;
        private CommParamBase _params;
        private WorkerManager _workerMenager;

        public ScannerTest()
        {
            InitializeComponent();
            comContext = new ComunicationContext();
            _workerMenager = new WorkerManager();
        }


        private void CreateStateWorker()
        {
            var con = new ConnectionRule(comContext);
            //var retry = new RetryConnection(comContext);
            var work = new StateCheckWorker(con,null, null, new TimeSpan(1000));
            work.OnStateChanged += OnStateChange;
            _workerMenager.SetWorker("ConnectionCheckingWorker", work);
        }

        private void OnStateChange(object sender, bool state)
        {
            if (state) {
                pnl_ConnectionState.BackColor = Color.Lime;
            }
            else {
                comContext.DisConnection();
                pnl_ConnectionState.BackColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var dlg = new CommunicationParamForm())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _params = dlg.Tag as CommParamBase;
                    comContext.Configure(_params);
                }
            }
        }

        private void btn_Connection_Click(object sender, EventArgs e)
        {
            try
            {
                var ConnectionFlg = comContext.Connection();
                comContext.AddReceivedEvent(receiveFramePacket);

                if (ConnectionFlg)
                {
                    receivedMemo.AppendText($"연결 성공 상태  : {ConnectionFlg}");
                    CreateStateWorker();
                    TargetWorkerStartAsync("ConnectionCheckingWorker");
                }
                else
                {
                    receivedMemo.AppendText($"연결 성공 실패  : {ConnectionFlg}");
                    TargetWorkerStopAsync("ConnectionCheckingWorker");
                }
            }
            catch (Exception ex)
            {
                receivedMemo.AppendText($"연결 성공 실패  : {ex.Message}");
            }
            
        }

        private void receiveFramePacket(object sender,string receiveData)
        {
           
            if (receivedMemo.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => {
                    receivedMemo.AppendText(receiveData);
                }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            receivedMemo.Clear();
        }

        private void btn_Sender_Click(object sender, EventArgs e)
        {
            string message = txt_SendMessage.Text + "\r\n";
            comContext.Sender(message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                comContext.DisConnection();
                TargetWorkerStopAsync("ConnectionCheckingWorker");
            }
            catch (Exception ex) 
            {
                receivedMemo.AppendText($"{ex.Message}");
            }
        }

        #region
        private void TargetWorkerStartAsync(string workerKey)
        {
            if (_workerMenager.GetWorker(workerKey) != null)
                _workerMenager.TargetWorkerStart(workerKey);
        }
        private void TargetWorkerStopAsync(string workerKey)
        {
            if (_workerMenager.GetWorker(workerKey) != null)
                _workerMenager.TargetWorkerStop(workerKey);
        }
        #endregion

        private void ScannerTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            comContext.Dispose();
        }
    }
}
