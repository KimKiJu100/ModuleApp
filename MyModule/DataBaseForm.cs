using Modules.ADO.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyModule
{
    public partial class DataBaseForm : Form
    {
        private SqlExecutor sqlExecutor = null;
        public DataBaseForm()
        {
            InitializeComponent();
            sqlExecutor = new SqlExecutor("Data Source=localhost;Database=6Axis_AnalayerDB;User ID=sa;Password=1234;Pooling=False;Encrypt=True;TrustServerCertificate=True;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"
                    INSERT INTO Product_Information_ACTID
                    (ACTID_Key, Product_Key, Date, ACT_ID)
                    VALUES
                    ( @ACTID_Key, @ProductKey, @Date, @ACT_ID )";

            var parameters = new Dictionary<string, object>
            {
                { "ACTID_Key", 1 },
                { "ProductKey", 1 },
                { "Date", DateTime.Now.Date },
                { "ACT_ID", "test" },
            };

            //string sql = @"
            //        INSERT INTO Product_Information
            //        (Product_Key, Date)
            //        VALUES
            //        (@ProductKey, @Date)";

            //var parameters = new Dictionary<string, object>
            //{
            //    { "ProductKey", 1 },
            //    { "Date", DateTime.Now.Date },
            //};

            sqlExecutor.ExecuteNonQuery(sql, parameters);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = @"DELETE FROM Product_Information WHERE Product_Key = @ProductKey;";
            var parameters = new Dictionary<string, object>
            {
                { "ProductKey", 1 },
            };
            sqlExecutor.ExecuteNonQuery(sql, parameters);
        }
    }
}
