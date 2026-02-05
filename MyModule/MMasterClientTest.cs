using App.CoreModules.Thread;
using App.CoreModules.Thread.Base;
using Modules.Communication.Context;
using Modules.Communication.Params;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyModule
{
    public partial class MMasterClientTest : Form
    {
        private ComunicationContext comContext;
        private SocketParams ComParams;
        public MMasterClientTest()
        {
            InitializeComponent();
            comContext = new ComunicationContext();
            ComParams = new SocketParams() { IpAddress = "192.168.1.144", Port = 5002 };
            comContext.Configure(ComParams);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comContext.Connection())
            {
                string filePath = @"D:\test\testMes.txt";
                byte[] buffer;

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length]; 
                    fs.Read(buffer, 0, buffer.Length);
                }

                comContext.Sender(buffer);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comContext.DisConnection();
        }


        private WorkerManager workerManager = new WorkerManager();
        private void button3_Click(object sender, EventArgs e)
        {
            FuncWorker<string, bool> testworker = new FuncWorker<string,bool>(myTest,TimeSpan.Zero);
            workerManager.SetWorker("testWorker", testworker);
        }

        private bool myTest()
        {
            Thread.Sleep(1000);
            return true;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {

                var request = new WorkerRequest<object, bool> { Command = "Invoke", RequestPayLoad = null };
                var result = await workerManager.TargetWorkerStartRequest<object, bool>("testWorker", request);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var worker = workerManager.GetWorker("testWorker");

                if (worker is WorkerRequestBase<string, bool> workerReqeust)
                {
                    var result = await workerReqeust.RequestAsync("Invoke", null);
                    int i = 0;
                }
                else
                {
                    throw new Exception($"형식이 없습니다.\r\nworker State: {worker}");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }  
        }
    }
}
