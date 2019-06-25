using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPS.Model
{
    public class RecModel<T>
    {
        /// <summary>
        /// 成功标识 成功为0
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string signtime { get; set; }
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