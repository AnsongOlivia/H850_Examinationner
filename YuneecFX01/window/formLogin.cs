using Sunny.UI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Windows.Forms;
using YuneecFX01.system;

namespace YuneecFX01.Window
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        /// <summary>
        /// 设置窗体的Region
        /// </summary>
        public void SetWindowRegion()
        {
            GraphicsPath FormPath;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 6);
            this.Region = new Region(FormPath);

        }

        /// <summary>
        /// 绘制圆角路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
        }

        /// <summary>
        /// 登录画面加载事件处理
        /// </summary>
        private void formLogin_Load(object sender, EventArgs e)
        {
            Boolean ret = true;

            //软件License检查
            ret = sysLicense.chkLicense();
            if (!ret)
            {
                //软件License检查失败，退出软件
                MessageBox.Show("软件启动失败！请检查License！", "错误信息");
                Environment.Exit(0);
            }

            //用户协议信息加载,从sqlite数据库中获得
            string[] aUsers = sysDataModel.gDataBase.getUserInfo();
            mComBoxProtocol.Items.Clear();
            foreach (string user in aUsers)
            {
                if(user != null) mComBoxProtocol.Items.Add(user);
            }
            if (mComBoxProtocol.Items.Count > 0)
            {
                mComBoxProtocol.SelectedIndex = 0;
            }

            //串口检查
            //获取已连接的串口的信息
            string[] aComs = SerialPort.GetPortNames();
            foreach (string com in aComs)
            {
                mComBoxNum.Items.Add(com);
            }
            if(mComBoxNum.Items.Count >= 1)
            {
                mComBoxNum.SelectedIndex = 0;
                mComBoxRate.SelectedIndex = 6;
            }
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        private void mButtonOK_Click(object sender, EventArgs e)
        {
            int lRet = -1;

            //用户协议检查
            if(mComBoxProtocol.Text == "")
            {
                MessageBox.Show("请输入用户协议！", "错误信息");
                return;
            }
            //电台串口检查
            if (mComBoxNum.Text == "")
            {
                MessageBox.Show("请输入电台的串口号！", "错误信息");
                return;
            }
            //电台波特率检查
            if (mComBoxRate.Text == "")
            {
                MessageBox.Show("请输入电台的波特率！", "错误信息");
                return;
            }

            //登录协议检查完成
            if (mComBoxProtocol.Text == "MAVLINK")
                sysDataModel.gProtocol = (int)sysDataModel.PROTOCOL.MAVLINK;
            if (mComBoxProtocol.Text == "ROS")
                sysDataModel.gProtocol = (int)sysDataModel.PROTOCOL.ROS;

            //电台的串口设置
            sysSerialPort.mSerialPort.PortName = mComBoxNum.Text;
            sysSerialPort.mSerialPort.BaudRate = mComBoxRate.Text.ToInt();
            sysSerialPort.mSerialPort.DataBits = 8;

            //电台串口连接检查
            try
            {
                sysSerialPort.mSerialPort.Open();
                sysSerialPort.mSerialPort.DiscardInBuffer();
                lRet = 0;
            }
            catch (Exception ex)
            {
                sysLog.Error(ex, "打开串口失败");
                sysSerialPort.mComStatus = 0;
                sysSerialPort.mSerialPort.Close();
                sysLog.Error("电台串口："+ sysSerialPort.mSerialPort.PortName +"打开失败！");
                MessageBox.Show("电台串口：" + sysSerialPort.mSerialPort.PortName + "打开失败！","错误信息");                
                return;
            }

            if (lRet == 0)
            {
                //成功
                sysSerialPort.mComStatus = 1;//串口已连接，可收发数据
                sysDataModel.gUserName = mComBoxProtocol.SelectedText;
                this.Close();
                base.DialogResult = DialogResult.OK;
                sysLog.Info("软件启动，连接成功！");
            }
            else
            {
                //失败
                sysSerialPort.mComStatus = 0;
                sysSerialPort.mSerialPort.Close();
                //sysSerialPort.mRTKSerialPort.Close();
                MessageBox.Show("串口：" + sysSerialPort.mSerialPort.PortName + "串口接收失败！" + lRet.ToString(), "错误信息");
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        private void mButtonExit_Click(object sender, EventArgs e)
        {
            //软件退出            
            base.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        #region 登录窗口拖动
        Point p = new Point(0, 0);  //记录鼠标按下去的坐标
        private static bool IsDrag = false;
        private void formLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            IsDrag = true;
            p.X = e.X;
            p.Y = e.Y;
        }
        private void formLogin_MouseUp(object sender, MouseEventArgs e)
        {
            IsDrag = false;
            p.X = 0;
            p.Y = 0;
        }
        private void formLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrag)
            {
                this.Left += e.X - p.X;
                this.Top += e.Y - p.Y;
            }
        }
        #endregion
    }
}
