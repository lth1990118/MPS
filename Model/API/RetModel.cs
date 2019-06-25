using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPS.Model
{
    public class RetModel<T>
    {
        /// <summary>
        /// 成功标识 成功为0
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 传入消息的主键
        /// </summary>
        public string messageid { get; set; }
        /// <summary>
        /// 返回的具体内容
        /// </summary>
        public T data { get; set; }
    }
}