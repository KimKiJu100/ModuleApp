using App.CoreModules.Thread;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyModule.CommunicationUI
{
    public partial class WorkerManagerView : Form
    {
        private readonly WorkerManager _manager;
        private readonly int _msInterval;
        private Task task;
        private CancellationTokenSource _cts;

        public WorkerManagerView(WorkerManager manager, int BackgroundInterval = 10)
        {
            InitializeComponent();
            _manager = manager;

            _msInterval = BackgroundInterval;

            _cts = new CancellationTokenSource();
            if (manager != null)
            {
                try
                {
                    task = Task.Run(BackgroundLoop, _cts.Token);
                }
                finally
                {
                }
            }
            else
                throw new Exception("TaskManager를 확인해주세요.");   
        }

        public async void BackgroundLoop()
        {
            try
            {

                while (!_cts.IsCancellationRequested)
                {
                    var WorkerInforCollection = _manager.GetInoformationWorkers();

                    if (gridViewTaskManager.InvokeRequired)
                    {
                        gridViewTaskManager.BeginInvoke(new Action(() =>
                        {
                            gridViewTaskManager.DataSource = WorkerInforCollection;
                        }));
                    }
                    else
                        gridViewTaskManager.DataSource = WorkerInforCollection;

                    await Task.Delay(_msInterval,_cts.Token);
                }
            }
            catch
            {
                
            }
        }

        private void WorkerManagerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("정말로 닫으시겠습니까?", "TaskManager Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _cts.Cancel();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
