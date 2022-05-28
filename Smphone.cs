//项目需要添加System.web引用
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Kojiro_ordering_management_system
{
    public class Smphone
    {


        public static void Setphone(string args)
        {
            //账号
            string account = "18077292842 ";
            //密码
            string pswd = "Qq2721355357";
              
            // 短信发送接口的http地址，请咨询客服
            string url = "xxxxxxxxxxxxxxxxx";

            // 发验短信调用示例
            // 发送内容
            string msg = "【小次郎】您的验证码是：1234";
            string data = "account=" + account + "&pswd=" + pswd + "&mobile=" + args + "&msg=" + msg + "&needstatus=true";
            HttpPost(url, data);
        }
        public static void HttpPost(string Url, string postDataStr)
        {
            byte[] dataArray = Encoding.UTF8.GetBytes(postDataStr);
            // Console.Write(Encoding.UTF8.GetString(dataArray));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataArray.Length;
            //request.CookieContainer = cookie;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String res = reader.ReadToEnd();
                reader.Close();
                Console.Write(" Response Content: " + res + " ");
            }
            catch (Exception e)
            {
                Console.Write(e.Message + e.ToString());
            }
        }
    }
}

