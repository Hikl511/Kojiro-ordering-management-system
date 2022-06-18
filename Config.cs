using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 支付宝c接口
{
    class Config
    {
        //支付宝公钥   后台可获取
        public static string alipay_public_key = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgSFbJySXs8CeWZjTnRQ9CX6+vTvRGFrFXrSKpsuXBZpsfP8fcfUMNHxs9jYPXKiV3Y8ZIp4SELjfO7TIc6S1AaW+o4EfTZ8+7AhldDOuDFzhD0CIlmo8tZh0cJisSZ0jlkcV8+Jya+ANT2nLr6If2IfXbXgy7gBUGCGw0a8lMmYMT8Mqx87Cndh5qW7/Dq07cYQ2+KKDn478RJwcRwbcKdzg/jJei3VDl1QR8l8USe92Vu+YoE19/vCuOrhJP7QYe/LtI/tYVpo1hjegLenuDdvgTOg7Vje/7JaXuXC7Fd9G6h3f+pq+RlooLI2ilNDX+e8A8Ujkj0k3HoTavfcN9wIDAQAB";

        //这里要配置没有经过的原始私钥

        //支付宝私钥
        public static string merchant_private_key = @"MIIEpQIBAAKCAQEA0LI9Z/VXDB2q1SKNfdpXzfN/xiO3BsSC6oUEdrtMSyTuZjnFctC2Nvac8rDT9OZgYY3d8aoGoHrRkh9T7SGKA6xjIPCS2jm3hBasQ3LOp2pR2ZxmUJweF/mufsNvuw9UpaX+EuzRg0aEPzjQBPGeFSR8Cx+f/nFv9RnJw50rI+HfAjxpaWLU20RMz5bo1ahjK2sFRQ2rMTA8BlfPnafZZv9pHrnXUPskQFniwKyNmnXlGNJ+3WDxy3hXPg2C4+7q6eriPzAJ6d5KcullaJcCtNg3epM8546EfHyo0tBpfTdrSFWAKKvKUM4XTOlOXLTd8APuPbKC+9Mn1ISD9FJJ7QIDAQABAoIBAQCHpJHM0+Vz9oRma0LTneqb7bwKqIP5XhhJHZO9KBd6b9KTltECwyzrpHZ2NwBMmL/kKDUtMXmFLM6xzrLZ2Ya+xHjZnAOW2xSwQZxNan1uyufQLJtDoXTd2GbV9WjViC1YTP9KhanXTSn/fYmW7QP2cfQ9tpxi4JAIGm7NOYYklylEN8zDxYLoZmZP6ngG6ByoAxDhmbhjal9hmOQUlU2ayQa11ZoVr87foVkLTcQmU22Okaf+Kelp5SfIpI0W3lmOPdu864TkwHXBjof5E0qAr6y5Scjib8PVu3K+RqT68sVtaYSi/NdBpec0gkSk0WPd6iRRWSFwozjeWSaylANxAoGBAPUSFJZ5NsIkMXHvPWfEEEYHEf0UNZTHb0zbb4BIGFMCT161fo+PAZZxUl0odnxhey+SerwFR9Cg0ohlLAK46skuI529PTLgQ8kpXvVtnQLVO3EckMqByq553FDXSE7vKV93jj+FwIGGNeLZzYW4fcmuEttUR1j3NWXc7LlSLembAoGBANoA4YBpfMhfXlkF/cTBr1zrOxjYrKjhgOAYRmRDmDbYU9CgTg5OjFyaQrpVggMoooH4rlAmuJBsjKb6dmSS5UMY41u2n9HRuhQJyRN0F/Slo6pzgpcOkZRAmvS2N246WYdnM6jk4B3LEYExvERCeyfg1TLEgj/oXY/0dKOYJjcXAoGALheWc66ck+sGua0LWYbQoLsXsQeqBC92SXhEAlaM7J/UmbV89jcpT0hE+2xuzHnxF0NvfgloNl7o+eo9Ws24qtnYrQQ4jGcNmLoFOBfDnhLIuT9sJApBOouE2leDLAVjPKdZw6y+Rh4d6Gqacvn9/n6U4Vd6i8sC6gOhKkHAjN0CgYEAn3wvfOsvT8N9WXFpoqzzpu2sUVQKlI5M4yS/MpDE5bLDNohgMlVCmGh+UqVFtRvgL2eH1rlNItNW3r2zKYbR1JF7m1fyeeSN1iUGhoXTFLatEoDo06vj0uqkskwwJyLm5okYoQG39/PcvYBuNB3SzWzNbBOZGjnbYPo87oXbx0cCgYEA3X0fOjASS+d25Yy4UEuMzItKM6wkPg9jWKqySAgAH9HVQjwxbMXrFzg6EUYFySH5dEY5cA23joVRzel7hZXAXrlsnabJPH+gq3uYswLM1cbuLiq1hGjG3yqHdHlzIZ8b9C4E83Egbhsm4Chdeqigc5w3vHv4edJraGAKxJuBqdU=";   //QGJ   1.0

        //支付宝公钥
        public static string merchant_public_key = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA0LI9Z/VXDB2q1SKNfdpXzfN/xiO3BsSC6oUEdrtMSyTuZjnFctC2Nvac8rDT9OZgYY3d8aoGoHrRkh9T7SGKA6xjIPCS2jm3hBasQ3LOp2pR2ZxmUJweF/mufsNvuw9UpaX+EuzRg0aEPzjQBPGeFSR8Cx+f/nFv9RnJw50rI+HfAjxpaWLU20RMz5bo1ahjK2sFRQ2rMTA8BlfPnafZZv9pHrnXUPskQFniwKyNmnXlGNJ+3WDxy3hXPg2C4+7q6eriPzAJ6d5KcullaJcCtNg3epM8546EfHyo0tBpfTdrSFWAKKvKUM4XTOlOXLTd8APuPbKC+9Mn1ISD9FJJ7QIDAQAB";

        //应用ID
        public static string appId = "2021003131681203"; 

        //合作伙伴ID：partnerID
        public static string pid = "2088332481380677";


        //支付宝网关
        public static string serverUrl = "https://openapi.alipay.com/gateway.do";
        public static string mapiUrl = "https://mapi.alipay.com/gateway.do";
        public static string monitorUrl = "http://mcloudmonitor.com/gateway.do";

        //编码，无需修改
        public static string charset = "utf-8";
        //签名类型，支持RSA2（推荐！）、RSA
        //public static string sign_type = "RSA2";
        public static string sign_type = "RSA2";
        //版本号，无需修改
        public static string version = "1.0";
    }
}
