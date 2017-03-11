using Senparc.Weixin.MP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTestDemo.Ashx
{
    /// <summary>
    /// WeiXinApiTest 的摘要说明
    /// </summary>
    public class WeiXinApiTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            InterfaceTest();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        //成为开发者url测试，返回echoStr
        public void InterfaceTest()
        {
            string token = "WeiXin";
            if (string.IsNullOrEmpty(token))
            {
                return;
            }
            string echoString = HttpContext.Current.Request.QueryString["echoStr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];
            if (CheckSignature.Check(signature, timestamp, nonce, token))
            {
                HttpContext.Current.Response.Write(echoString);
            }
            else
            {
                HttpContext.Current.Response.Write(echoString);
            }
            HttpContext.Current.Response.End();
        }

    }
}