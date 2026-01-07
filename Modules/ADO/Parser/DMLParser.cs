using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modules.ADO.Parser
{
    /// <summary>
    /// 동적 파라미터를 추출하는 역할을 하는 파서
    /// </summary>
    public class DMLParser
    {
        private string[] SplitString = { " ", "\n", "\r", "\t", ",", "(', ')", "=", ";" };
        public DMLParser()
        {

        }
        /// <summary>
        /// SQL 데이터에서 동적파라미터를 분석하여 피드해준다.
        /// </summary>
        /// <param name="sqlStirng"></param>
        public Dictionary<string, object> GetSqlParameters(string sqlStirng)
        {
            var stringSlices = sqlStirng.Split(SplitString, StringSplitOptions.RemoveEmptyEntries);
            var paramDic = stringSlices
                                .Where(str => str.StartsWith("@") && str.Length > 1)
                                .Select(part => part.TrimStart('@'))
                                .Distinct(StringComparer.OrdinalIgnoreCase)
                                .ToDictionary(key => key, key => (object)DBNull.Value);
            return paramDic;
        }

        public Dictionary<string, object> GetRegexSqlParameters(string sqlStirng)
        {
            var matches = Regex.Matches(sqlStirng, @"@\w+");
            return matches
                    .Cast<Match>()
                    .Select(part => part.Value.TrimStart('@'))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(key => key, key => (object)DBNull.Value);
        }
    }
}
