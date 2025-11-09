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
            ComParams = new SocketParams() { IpAddress = "127.0.0.1", Port = 5002 };
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
    }
}
