namespace MyModule
{
    partial class ScannerTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.receivedMemo = new System.Windows.Forms.RichTextBox();
            this.btn_Connection = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Sender = new System.Windows.Forms.Button();
            this.txt_SendMessage = new System.Windows.Forms.TextBox();
            this.pnl_ConnectionState = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Communication Parameter Setting";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // receivedMemo
            // 
            this.receivedMemo.Location = new System.Drawing.Point(12, 41);
            this.receivedMemo.Name = "receivedMemo";
            this.receivedMemo.Size = new System.Drawing.Size(585, 344);
            this.receivedMemo.TabIndex = 3;
            this.receivedMemo.Text = "";
            // 
            // btn_Connection
            // 
            this.btn_Connection.Location = new System.Drawing.Point(610, 41);
            this.btn_Connection.Name = "btn_Connection";
            this.btn_Connection.Size = new System.Drawing.Size(86, 23);
            this.btn_Connection.TabIndex = 4;
            this.btn_Connection.Text = "Connection";
            this.btn_Connection.UseVisualStyleBackColor = true;
            this.btn_Connection.Click += new System.EventHandler(this.btn_Connection_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Sender
            // 
            this.btn_Sender.Location = new System.Drawing.Point(671, 415);
            this.btn_Sender.Name = "btn_Sender";
            this.btn_Sender.Size = new System.Drawing.Size(117, 23);
            this.btn_Sender.TabIndex = 6;
            this.btn_Sender.Text = "Test Sender";
            this.btn_Sender.UseVisualStyleBackColor = true;
            this.btn_Sender.Click += new System.EventHandler(this.btn_Sender_Click);
            // 
            // txt_SendMessage
            // 
            this.txt_SendMessage.Location = new System.Drawing.Point(12, 415);
            this.txt_SendMessage.Name = "txt_SendMessage";
            this.txt_SendMessage.Size = new System.Drawing.Size(653, 21);
            this.txt_SendMessage.TabIndex = 7;
            // 
            // pnl_ConnectionState
            // 
            this.pnl_ConnectionState.BackColor = System.Drawing.Color.Gray;
            this.pnl_ConnectionState.Location = new System.Drawing.Point(734, 70);
            this.pnl_ConnectionState.Name = "pnl_ConnectionState";
            this.pnl_ConnectionState.Size = new System.Drawing.Size(54, 16);
            this.pnl_ConnectionState.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(608, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "연결 상태";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(702, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "DisConnec";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(610, 362);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Worker Manager View";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(610, 292);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "ActionWorker";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ScannerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_ConnectionState);
            this.Controls.Add(this.txt_SendMessage);
            this.Controls.Add(this.btn_Sender);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Connection);
            this.Controls.Add(this.receivedMemo);
            this.Controls.Add(this.button2);
            this.Name = "ScannerTest";
            this.Text = "ScannerTest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScannerTest_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox receivedMemo;
        private System.Windows.Forms.Button btn_Connection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Sender;
        private System.Windows.Forms.TextBox txt_SendMessage;
        private System.Windows.Forms.Panel pnl_ConnectionState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}