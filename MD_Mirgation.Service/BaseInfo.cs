using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_DataMigration.Service
{
    /// <summary>
    /// 데이터변환 기본정보
    /// </summary>
    public class BaseInfo
    {
        /// <summary>
        /// 병원코드
        /// </summary>
        public string HosCd { get; set; }

        public string HosName { get; set; }
    }
}
