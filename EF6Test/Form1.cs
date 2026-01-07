using EF6Test.DbContexts;
using EF6Test.Entitys;
using Modules.ADO;
using Modules.ADO.DataBase;
using Modules.ADO.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EF6Test
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private int index = 0;
        private int deleteIndex = 0;
        private BindingList<DbModels> sourceModel = new BindingList<DbModels>();

        private readonly SQLCachedManager TestManger;
        private readonly SqlExecutor databaseExecutor;
        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = sourceModel;
            string path = "D:\\test\\Module\\MyModule\\EF6Test\\";
            TestManger = new SQLCachedManager(path);
            TestManger.GetSqlFileLoad();
            databaseExecutor = new SqlExecutor("Data Source=localhost;Initial Catalog=ALCData;Integrated Security=True");
        }

        private void btn_Connection_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new TestDbContext())
                {
                    // (1) DB가 없으면 자동 생성
                    db.Database.CreateIfNotExists();

                    // (2) INSERT
                    var product = new DbModels { BODY_NO = $"Test{index++}", VIN_NO = "1", SEQ_NO = "2", DATETIME = "3", DATA_219 = "4" };
                    db.Products.Add(product);
                    db.SaveChanges();

                    sourceModel.Add(product);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using (var db = new TestDbContext())
            {
                db.Database.CreateIfNotExists();
                var list = db.Products.ToList();
                sourceModel.Clear();
                list.ForEach(product => sourceModel.Add(product));
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var db = new TestDbContext())
            {
                // (1) DB가 없으면 자동 생성
                db.Database.CreateIfNotExists();

                // (4) UPDATE
                var first = db.Products.FirstOrDefault();
                if (first != null)
                {
                    first.DATA_219 = "Changed";
                    db.SaveChanges();

                    var target = sourceModel.FirstOrDefault(x => x.BODY_NO == first.BODY_NO);
                    if (target != null)
                    {
                        target.DATA_219 = first.DATA_219;
                        gridControl1.RefreshDataSource();
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (var db = new TestDbContext())
            {
                // (1) DB가 없으면 자동 생성
                db.Database.CreateIfNotExists();

                // (5) DELETE
                string id = $"Test{deleteIndex++}";
                var last = db.Products
                                .OrderByDescending(x => x.BODY_NO == id)
                                .FirstOrDefault();
                if (last != null)
                {
                    var target = sourceModel.FirstOrDefault(x => x.BODY_NO == last.BODY_NO);

                    db.Products.Remove(last);
                    db.SaveChanges();

                    if (target != null) {
                        sourceModel.Remove(target);
                    }
                }
            }

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var sql = TestManger.GetSqlCache("Select.sql");
            DMLParser dynamicParam = new DMLParser();
            var value = dynamicParam.GetRegexSqlParameters(sql);

            BindParametersFromObject(ref value, new BindSchema { BODY_NO = "test11", DATETIME = "test2", SEQ_NO = "test3", VIN_NO ="test4", DATA_219 ="test5" });
            var DataTable = databaseExecutor.ExecuteQuery(sql, value);
        }

        public void BindParametersFromObject(ref Dictionary<string, object> dict, object source)
        {
            var props = source.GetType().GetProperties();
            foreach (var prop in props)
            {
                string name = prop.Name;
                if (dict.ContainsKey(name))
                    dict[name] = prop.GetValue(source) ?? DBNull.Value;
            }
        }
    }
    public class BindSchema
    {
        public string BODY_NO { get; set; }
        public string DATETIME { get; set; }
        public string SEQ_NO { get; set; }
        public string VIN_NO { get; set; }
        public string DATA_219 { get; set; }
    }
}
