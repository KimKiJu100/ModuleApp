using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modules.ADO
{
    public class SQLCachedManager
    {
        private readonly string _targetSourcePath;
        private readonly Dictionary<string, string> _sqlCache = new Dictionary<string,string>();
        public SQLCachedManager(string targetSourcePath)
        {
            _targetSourcePath = targetSourcePath;
        }

        public void GetSqlFileLoad()
        {
            if (!Directory.Exists(_targetSourcePath))
                throw new Exception($"SQL 경로가 존재하지 않습니다: {_targetSourcePath}");

            string[] sqlFiles = Directory.GetFiles(_targetSourcePath, "*.sql", SearchOption.AllDirectories);

            foreach (string file in sqlFiles)
            {
                string fileName = Path.GetFileName(file);
                string sqlText = File.ReadAllText(file);
                _sqlCache[fileName] = sqlText;
            }
        }

        public string GetSqlCache(string keyName)
        {
            _sqlCache.TryGetValue(keyName, out string resultValue);
            return resultValue;
        }
    }
}
