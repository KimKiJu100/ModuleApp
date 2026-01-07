
namespace MyModule
{
    partial class PLC_Test
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Connection = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtReciveData = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_CompanyID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_PLCInfor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_CPUInfor = new System.Windows.Forms.ComboBox();
            this.cbb_SourceOfFrame = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbb_EthernetBaseNumber = new System.Windows.Forms.ComboBox();
            this.cbb_EthernetSlotPosition = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbb_VariableLength = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbb_BlockCount = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbb_DataType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbb_CommandType = new System.Windows.Forms.ComboBox();
            this.txt_DataAddress = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Connection
            // 
            this.btn_Connection.Location = new System.Drawing.Point(660, 12);
            this.btn_Connection.Name = "btn_Connection";
            this.btn_Connection.Size = new System.Drawing.Size(128, 36);
            this.btn_Connection.TabIndex = 0;
            this.btn_Connection.Text = "Connection";
            this.btn_Connection.UseVisualStyleBackColor = true;
            this.btn_Connection.Click += new System.EventHandler(this.btn_Connection_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(660, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtReciveData
            // 
            this.txtReciveData.Location = new System.Drawing.Point(327, 12);
            this.txtReciveData.Name = "txtReciveData";
            this.txtReciveData.Size = new System.Drawing.Size(327, 426);
            this.txtReciveData.TabIndex = 2;
            this.txtReciveData.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_EthernetSlotPosition);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbb_EthernetBaseNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbb_SourceOfFrame);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbb_CPUInfor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbb_PLCInfor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_CompanyID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 206);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company Header";
            // 
            // txt_CompanyID
            // 
            this.txt_CompanyID.Location = new System.Drawing.Point(167, 26);
            this.txt_CompanyID.Name = "txt_CompanyID";
            this.txt_CompanyID.Size = new System.Drawing.Size(121, 21);
            this.txt_CompanyID.TabIndex = 5;
            this.txt_CompanyID.Text = "LSIS-XGT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "CompanyID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "PLCInfo";
            // 
            // cbb_PLCInfor
            // 
            this.cbb_PLCInfor.FormattingEnabled = true;
            this.cbb_PLCInfor.Location = new System.Drawing.Point(167, 58);
            this.cbb_PLCInfor.Name = "cbb_PLCInfor";
            this.cbb_PLCInfor.Size = new System.Drawing.Size(121, 20);
            this.cbb_PLCInfor.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "CPUInfo";
            // 
            // cbb_CPUInfor
            // 
            this.cbb_CPUInfor.FormattingEnabled = true;
            this.cbb_CPUInfor.Location = new System.Drawing.Point(167, 89);
            this.cbb_CPUInfor.Name = "cbb_CPUInfor";
            this.cbb_CPUInfor.Size = new System.Drawing.Size(121, 20);
            this.cbb_CPUInfor.TabIndex = 10;
            // 
            // cbb_SourceOfFrame
            // 
            this.cbb_SourceOfFrame.FormattingEnabled = true;
            this.cbb_SourceOfFrame.Location = new System.Drawing.Point(167, 115);
            this.cbb_SourceOfFrame.Name = "cbb_SourceOfFrame";
            this.cbb_SourceOfFrame.Size = new System.Drawing.Size(121, 20);
            this.cbb_SourceOfFrame.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "SourceOfFrame";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "EthernetBaseNumber";
            // 
            // cbb_EthernetBaseNumber
            // 
            this.cbb_EthernetBaseNumber.FormattingEnabled = true;
            this.cbb_EthernetBaseNumber.Location = new System.Drawing.Point(167, 141);
            this.cbb_EthernetBaseNumber.Name = "cbb_EthernetBaseNumber";
            this.cbb_EthernetBaseNumber.Size = new System.Drawing.Size(121, 20);
            this.cbb_EthernetBaseNumber.TabIndex = 14;
            // 
            // cbb_EthernetSlotPosition
            // 
            this.cbb_EthernetSlotPosition.FormattingEnabled = true;
            this.cbb_EthernetSlotPosition.Location = new System.Drawing.Point(167, 167);
            this.cbb_EthernetSlotPosition.Name = "cbb_EthernetSlotPosition";
            this.cbb_EthernetSlotPosition.Size = new System.Drawing.Size(121, 20);
            this.cbb_EthernetSlotPosition.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "EthernetSlotPosition";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_DataAddress);
            this.groupBox2.Controls.Add(this.cbb_CommandType);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbb_VariableLength);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbb_BlockCount);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbb_DataType);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 177);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command Setting";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "DataAddress";
            // 
            // cbb_VariableLength
            // 
            this.cbb_VariableLength.FormattingEnabled = true;
            this.cbb_VariableLength.Location = new System.Drawing.Point(167, 115);
            this.cbb_VariableLength.Name = "cbb_VariableLength";
            this.cbb_VariableLength.Size = new System.Drawing.Size(121, 20);
            this.cbb_VariableLength.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "VariableLength";
            // 
            // cbb_BlockCount
            // 
            this.cbb_BlockCount.FormattingEnabled = true;
            this.cbb_BlockCount.Location = new System.Drawing.Point(167, 89);
            this.cbb_BlockCount.Name = "cbb_BlockCount";
            this.cbb_BlockCount.Size = new System.Drawing.Size(121, 20);
            this.cbb_BlockCount.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "BlockCount";
            // 
            // cbb_DataType
            // 
            this.cbb_DataType.FormattingEnabled = true;
            this.cbb_DataType.Location = new System.Drawing.Point(167, 58);
            this.cbb_DataType.Name = "cbb_DataType";
            this.cbb_DataType.Size = new System.Drawing.Size(121, 20);
            this.cbb_DataType.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "DataType";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "CommandType";
            // 
            // cbb_CommandType
            // 
            this.cbb_CommandType.FormattingEnabled = true;
            this.cbb_CommandType.Location = new System.Drawing.Point(167, 29);
            this.cbb_CommandType.Name = "cbb_CommandType";
            this.cbb_CommandType.Size = new System.Drawing.Size(121, 20);
            this.cbb_CommandType.TabIndex = 17;
            // 
            // txt_DataAddress
            // 
            this.txt_DataAddress.Location = new System.Drawing.Point(167, 141);
            this.txt_DataAddress.Name = "txt_DataAddress";
            this.txt_DataAddress.Size = new System.Drawing.Size(121, 21);
            this.txt_DataAddress.TabIndex = 18;
            this.txt_DataAddress.Text = "%MW0";
            // 
            // PLC_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtReciveData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Connection);
            this.Name = "PLC_Test";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.PLC_Test_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Connection;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox txtReciveData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CompanyID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_CPUInfor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_PLCInfor;
        private System.Windows.Forms.ComboBox cbb_EthernetSlotPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_EthernetBaseNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbb_SourceOfFrame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_DataAddress;
        private System.Windows.Forms.ComboBox cbb_CommandType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbb_VariableLength;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbb_BlockCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbb_DataType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

