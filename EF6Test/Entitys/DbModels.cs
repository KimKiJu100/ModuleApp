using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Test.Entitys
{
    /// <summary>
    /// Required, atrribute 는 Not null 속성
    /// </summary>
    [Table("ALCData")] // DB 테이블명 지정
    public class DbModels
    {
        [Key, MaxLength(25)]                       // Primary Key
        public string BODY_NO { get; set; }

        [MaxLength(20)]
        public string DATETIME { get; set; }

        [MaxLength(20)]
        public string SEQ_NO { get; set; }
        [MaxLength(25)]
        public string VIN_NO { get; set; }
        [MaxLength(255)]
        public string DATA_219 { get; set; }
    }
}
