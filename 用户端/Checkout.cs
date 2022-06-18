using Com.Alipay;
using Com.Alipay.Business;
using Com.Alipay.Domain;
using Com.Alipay.Model;
using Spire.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 支付宝c接口;

namespace Kojiro_ordering_management_system.用户端
{
    public partial class Checkout : Form
    {
        public Checkout()
        {
            InitializeComponent();
        }
        IAlipayTradeService serviceClient = F2FBiz.CreateClientInstance(Config.serverUrl, Config.appId, Config.merchant_private_key, Config.version,
                                            Config.sign_type, Config.alipay_public_key, Config.charset);

        public void Barcode(string url)
        {
            //创建BarcodeSettings对象

            BarcodeSettings settings = new BarcodeSettings();

            //设置条码类型为二维码

            settings.Type = BarCodeType.QRCode;

            //设置二维码数据

            settings.Data = url;

            //设置显示文本

            settings.Data2D = "请使用支付宝扫码支付";

            //设置数据类型为数字

            settings.QRCodeDataMode = QRCodeDataMode.Numeric;

            //设置二维码错误修正级别

            settings.QRCodeECL = QRCodeECL.H;

            //设置宽度

            settings.X = 3.0f;

            //实例化BarCodeGenerator类的对象

            BarCodeGenerator generator = new BarCodeGenerator(settings);

            //生成二维码图片并保存为PNG格式

            Image image = generator.GenerateImage();
            pictureBox1.Image = image;
            //image.Save("QRCode.png");
        }


        private void QrCodeShow()//显示支付二维码
        {
            AlipayTradePrecreateContentBuilder builder = BuildPrecreateContent();//接口
            string out_trade_no = builder.out_trade_no;
            AlipayF2FPrecreateResult precreateResult = serviceClient.tradePrecreate(builder);
            //payResponse.QrCode即二维码对于的链接
            //将链接用二维码工具生成二维码打印出来，顾客可以用支付宝钱包扫码支付。
            string result = "";

            switch (precreateResult.Status)
            {
                case ResultEnum.SUCCESS:
                    DoWaitProcess(precreateResult);
                    Barcode(precreateResult.response.QrCode.ToString());
                    ParameterizedThreadStart ParStart = new ParameterizedThreadStart(LoopQuery);//轮询支付状态
                    Thread myThread = new Thread(ParStart);
                    object o = precreateResult.response.OutTradeNo;
                    myThread.Start(o);
                    break;
                case ResultEnum.FAILED:
                    result = precreateResult.response.Body;
                    //Response.Redirect("result.aspx?Text=" + result);
                    break;

                case ResultEnum.UNKNOWN:
                    if (precreateResult.response == null)
                    {
                        result = "配置或网络异常，请检查后重试";
                    }
                    else
                    {
                        result = "系统异常，请更新外部订单后重新发起请求";
                    }
                    //Response.Redirect("result.aspx?Text=" + result);
                    break;
            }
        }


        

        private AlipayTradePrecreateContentBuilder BuildPrecreateContent()
        {
            //线上联调时，请输入真实的外部订单号。
            string out_trade_no = "";
            if (String.IsNullOrEmpty(WIDout_request_no.Text.Trim()))
            {
                out_trade_no = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "0000" + (new Random()).Next(1, 10000).ToString();
            }
            else
            {
                out_trade_no = WIDout_request_no.Text.Trim();//设置订单号
            }

            AlipayTradePrecreateContentBuilder builder = new AlipayTradePrecreateContentBuilder();
            //收款账号
            builder.seller_id = Config.pid;
            //订单编号
            builder.out_trade_no = out_trade_no;
            //订单总金额
            // builder.total_amount = ShoppingCart.shoppingCart.DiscountedPrice.ToString().Trim();//从购物车窗体控件获取金额
            builder.total_amount = WIDtotal_fee.Text.Trim();//从购物车窗体控件获取金额
            //参与优惠计算的金额
            //builder.discountable_amount = "";
            //不参与优惠计算的金额
            //builder.undiscountable_amount = "";
            //订单名称
            builder.subject = ShoppingCart.shoppingCart.DelName+ System.DateTime.Now.ToString("yyyyMMddHHmmss") + "0000" + (new Random()).Next(1, 10000).ToString().Trim();//订单名字
            //自定义超时时间
            builder.timeout_express = "60s";
            //订单描述
            builder.body = "";
            //门店编号，很重要的参数，可以用作之后的营销
            builder.store_id = "test store id";
            //操作员编号，很重要的参数，可以用作之后的营销
            builder.operator_id = "test";

            //传入商品信息详情
            List<GoodsInfo> gList = new List<GoodsInfo>();
            GoodsInfo goods = new GoodsInfo();
            goods.goods_id = "goods id";
            goods.goods_name = "goods name";
            goods.price = "0.01";
            goods.quantity = "1";
            gList.Add(goods);
            builder.goods_detail = gList;

            //系统商接入可以填此参数用作返佣
            //ExtendParams exParam = new ExtendParams();
            //exParam.sysServiceProviderId = "20880000000000";
            //builder.extendParams = exParam;

            return builder;

        }

        /// <summary>
        /// 生成二维码并展示到页面上
        /// </summary>
        /// <param name="precreateResult">二维码串</param>
        private void DoWaitProcess(AlipayF2FPrecreateResult precreateResult)
        {
            ////打印出 preResponse.QrCode 对应的条码
            //Bitmap bt;
            //string enCodeString = precreateResult.response.QrCode;
            //QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
            //qrCodeEncoder.QRCodeScale = 3;
            //qrCodeEncoder.QRCodeVersion = 8;
            //bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            //string filename = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "0000" + (new Random()).Next(1, 10000).ToString()
            // + ".jpg";
            //bt.Save(Server.MapPath("~/images/") + filename);
            //this.Image1.ImageUrl = "~/images/" + filename;

            ////轮询订单结果
            ////根据业务需要，选择是否新起线程进行轮询
            ////ParameterizedThreadStart ParStart = new ParameterizedThreadStart(LoopQuery);
            ////Thread myThread = new Thread(ParStart);
            ////object o = precreateResult.response.OutTradeNo;
            ////myThread.Start(o);

        }

        /// <summary>
        /// 轮询
        /// </summary>
        /// <param name="o">订单号</param>
        /// 
        public void LoopQuery(object o)
        {
            AlipayF2FQueryResult queryResult = new AlipayF2FQueryResult();
            int count = 100;
            int interval = 10000;
            string out_trade_no = o.ToString();

            for (int i = 1; i <= count; i++)
            {
                Thread.Sleep(interval);//当前10000毫秒
                queryResult = serviceClient.tradeQuery(out_trade_no);//通过订单号查询
                if (queryResult != null)
                {
                    if (queryResult.Status == ResultEnum.SUCCESS)//Success为支付成功
                    {
                        DoSuccessProcess(queryResult);
                        return;
                    }
                    else
                    {
                        DoFailedProcess(queryResult);//否则弹出支付失败
                        return;//失败后退出循环
                    }
                }
            }
        }
        /// <summary>
        /// 请添加支付成功后的处理
        /// </summary>
        /// 
        private void DoSuccessProcess(AlipayF2FQueryResult queryResult)
        {
            //支付成功，请更新相应单据
            // log.WriteLine("扫码支付成功：外部订单号" + queryResult.response.OutTradeNo);
            MessageBox.Show("支付成功，订单号:" + queryResult.response.OutTradeNo,"提示");
        }
        /// <summary>
        /// 请添加支付失败后的处理
        /// </summary>
        private void DoFailedProcess(AlipayF2FQueryResult queryResult)
        {
            //支付失败，请更新相应单据
            MessageBox.Show("支付失败或超时，请重新扫码支付或重新回购物车结算，订单号:" + queryResult.response.OutTradeNo);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            User_side.user_Side.loadform(shoppingCart);
        }

        private void Checkout_Load_1(object sender, EventArgs e)
        {
            WIDtotal_fee.Text = ShoppingCart.shoppingCart.DiscountedPrice.ToString().Substring(0, 4);
            label5.Text = "￥ " + WIDtotal_fee.Text;
            QrCodeShow();
        }
    }
}
