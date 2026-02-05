namespace MyModule.CommunicationUI
{
    partial class ucSerial232Params
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbb_ComPort = new System.Windows.Forms.ComboBox();
            this.lbl_Comport = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_BaudRate = new System.Windows.Forms.ComboBox();
            this.cbb_Parity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_Databit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbb_Stopbit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbb_ComPort
            // 
            this.cbb_ComPort.FormattingEnabled = true;
            this.cbb_ComPort.Location = new System.Drawing.Point(106, 22);
            this.cbb_ComPort.Name = "cbb_ComPort";
            this.cbb_ComPort.Size = new System.Drawing.Size(121, 20);
            this.cbb_ComPort.TabIndex = 0;
            // 
            // lbl_Comport
            // 
            this.lbl_Comport.AutoSize = true;
            this.lbl_Comport.Location = new System.Drawing.Point(34, 25);
            this.lbl_Comport.Name = "lbl_Comport";
            this.lbl_Comport.Size = new System.Drawing.Size(41, 12);
            this.lbl_Comport.TabIndex = 1;
            this.lbl_Comport.Text = "컴포트";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "BaudRate";
            // 
            // cbb_BaudRate
            // 
            this.cbb_BaudRate.FormattingEnabled = true;
            this.cbb_BaudRate.Location = new System.Drawing.Point(106, 53);
            this.cbb_BaudRate.Name = "cbb_BaudRate";
            this.cbb_BaudRate.Size = new System.Drawing.Size(121, 20);
            this.cbb_BaudRate.TabIndex = 3;
            // 
            // cbb_Parity
            // 
            this.cbb_Parity.FormattingEnabled = true;
            this.cbb_Parity.Location = new System.Drawing.Point(106, 79);
            this.cbb_Parity.Name = "cbb_Parity";
            this.cbb_Parity.Size = new System.Drawing.Size(121, 20);
            this.cbb_Parity.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parity";
            // 
            // cbb_Databit
            // 
            this.cbb_Databit.FormattingEnabled = true;
            this.cbb_Databit.Location = new System.Drawing.Point(106, 105);
            this.cbb_Databit.Name = "cbb_Databit";
            this.cbb_Databit.Size = new System.Drawing.Size(121, 20);
            this.cbb_Databit.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "DataBit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "StopBit";
            // 
            // cbb_Stopbit
            // 
            this.cbb_Stopbit.FormattingEnabled = true;
            this.cbb_Stopbit.Location = new System.Drawing.Point(106, 134);
            this.cbb_Stopbit.Name = "cbb_Stopbit";
            this.cbb_Stopbit.Size = new System.Drawing.Size(121, 20);
            this.cbb_Stopbit.TabIndex = 9;
            // 
            // ucSerial232Params
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbb_Stopbit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbb_Databit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbb_Parity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbb_BaudRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Comport);
            this.Controls.Add(this.cbb_ComPort);
            this.Name = "ucSerial232Params";
            this.Size = new System.Drawing.Size(257, 174);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_ComPort;
        private System.Windows.Forms.Label lbl_Comport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_BaudRate;
        private System.Windows.Forms.ComboBox cbb_Parity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_Databit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbb_Stopbit;
    }
}
