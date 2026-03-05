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
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using System.Text.RegularExpressions;


namespace MyModule
{
    public partial class PdfLoadTest : Form
    {
        public PdfLoadTest()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test();
            //test2();
        }
        private void test2()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var pdfPath = openFileDialog.FileName;

                using (var pdf = PdfDocument.Open(pdfPath))
                {
                    foreach (Page page in pdf.GetPages())
                    {
                        string fixedText = page.Text.Replace("Write", "\r\nWrite");
                        //richTextBox1.AppendText(fixedText + "\r\n");

                        var lines = fixedText.Split('\n', '\r')
                            .Where(x => x.StartsWith("Write"))
                            .ToList();

                        foreach (var line in lines)
                        {
                            richTextBox1.AppendText(line);
                        }

                        richTextBox1.AppendText("===========================================================\r\n");
                    }
                }
            }
        }
        private void Test()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var pdfPath = openFileDialog.FileName;

                using (var pdf = PdfDocument.Open(pdfPath))
                {
                    foreach (Page page in pdf.GetPages())
                    {
                        // 1) Write 앞에 줄바꿈 삽입
                        string fixedText = page.Text.Replace("Write", "\r\nWrite");

                        // 2) 줄 단위로 분해 + Write로 시작하는 것만
                        var lines = fixedText
                            .Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .Where(x => x.StartsWith("Write"))
                            .ToList();

                        // 3) 각 줄에서 Write + 헥사 부분만 파싱
                        foreach (var line in lines)
                        {
                            // Write 뒤에 붙은 연속된 헥사 부분만 추출
                            var match = Regex.Match(line, @"^Write([0-9A-Fa-f]+)");

                            if (!match.Success)
                                continue;   // 헥사가 아니면(헤더 같은 줄) 스킵

                            string hexPart = match.Groups[1].Value;   // 예: "E02892146" 같은 부분

                            richTextBox1.AppendText(hexPart.Substring(2, 2) + "\t" + hexPart.Substring(4, 2) + "\r\n");
                            richTextBox2.AppendText(hexPart.Substring(4, 2) + "\r\n");
                        }

                        richTextBox1.AppendText("===========================================================\r\n");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // 텍스트 파일 전체 읽기
                string text = File.ReadAllText(filePath, Encoding.UTF8);

                // RichTextBox에 출력
                richTextBox3.Clear();
                richTextBox3.AppendText(text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fileLines = richTextBox3.Lines; // 파일 데이터
            var actualLines = richTextBox2.Lines; // 실제 데이터

            var sb = new StringBuilder();

            int max = Math.Max(fileLines.Length, actualLines.Length);

            for (int i = 0; i < max; i++)
            {
                string left = i < fileLines.Length ? fileLines[i] : string.Empty;
                string right = i < actualLines.Length ? actualLines[i] : string.Empty;

                // 탭 기준으로 두 데이터를 머지
                sb.Append(left);

                if (!string.IsNullOrEmpty(right))
                {
                    sb.Append("\t");
                    sb.Append(right);
                }

                sb.AppendLine();
            }

            // 결과를 어디에 뿌릴지: richTextBox3 덮어쓰기 또는 새 컨트롤
            richTextBox4.Text = sb.ToString();
            // 또는 richTextBox4.Text = sb.ToString(); 같은 식으로 별도 출력
        }
    }
}
