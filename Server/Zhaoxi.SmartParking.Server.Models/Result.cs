using System;
using System.Collections.Generic;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    /// <summary>
    /// PaginationResult最终的数据返回对象
    /// </summary>
    public class PaginationResult
    {
        /// <summary>
        /// 数据处理的状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 异常的消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 分页信息
        /// </summary>
        public PageInfo PageInfo { get; set; }
        /// <summary>
        /// 最终需要显示在页面上的数据
        /// List<AutoRegister>
        /// List<DeiviceRegister>
        /// PaginationResult<List<DeiviceRegister>>
        /// </summary>
        public string Data { get; set; }
    }
    public class PageInfo
    {
        /// <summary>
        /// 请求的页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; set; }
    }
}
