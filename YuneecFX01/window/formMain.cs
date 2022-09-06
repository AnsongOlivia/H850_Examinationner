using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MaterialSkin;
using MaterialSkin.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using YuneecFX01.map.GMap;
using YuneecFX01.map.MapProviders;
using YuneecFX01.system;
using YuneecFX01.tool;
using static MAVLink;
using static YuneecFX01.system.sysConstant;

namespace YuneecFX01.Window
{
    /// <summary>
    /// 主画面串口类
    /// 继承materialSkinManager
    /// </summary>
    public partial class formMain : MaterialForm
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        private MaterialSkinManager materialSkinManager;
        private int mMessageNo = 0;
        private string[] sData;
        private int sDataIndex;

        private bool tabPageTestGroundFlag = false;//初次加载标识
        private bool tabPageTestParamFlag  = false;//初次加载标识
        private bool tabPageTestOneFlag    = false;//初次加载标识     

        private int  mCenterDistance = 2;//距离中心点距离
        /// <summary>
        /// 数据判别时长，1秒
        /// </summary>
        private int  mTimeOut        = 1 * 10_000_000;
        private bool mLeftFlag = true;
        private int  mPointIndex = 0;

        public object DevExpress { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public formMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主画面加载方法
        /// 主画面显示前，首先启动用户登录窗口
        /// 如果登录成功，显示出窗口
        /// 主窗口各种资源初始化
        /// </summary>
        private void formMain_Load(object sender, EventArgs e)
        {
            labBuildVersion.Text = VersionHelper.GetInformationalVersion();
            labBuildTime.Text = VersionHelper.GetBuildTime().ToString("yyyy-MM-ddTHH:mm:ss");
#if DEBUG
            labBuildTime.Text = labBuildTime.Text + "-DEBUG";
            window.formDebug mformDebug = new window.formDebug();
            mformDebug.Owner = this;
            mformDebug.Show();
#endif

            //首先启动用户登录窗口
            formLogin mformLogin = new formLogin();
            mformLogin.ShowDialog();

#if DEBUG
            //TEST-S----------------------------------------------
            mformLogin.DialogResult = DialogResult.OK;
            sysDataModel.FlyCode = 1;
            sysDataModel.gProtocol = 1;
            //TEST-E----------------------------------------------
#else
            // 指定飞机号为 1
            sysDataModel.FlyCode = 1;
#endif

            if (mformLogin.DialogResult != DialogResult.OK)
            {
                //串口检测失败，退出软件                
                sysFunction.exitApplication();
                Application.Exit();
            }
            else
            {
                //如果用户登录成功，出现主画面
                this.Opacity = 100;
                materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.EnforceBackcolorOnAllComponents = true;
                materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                            Primary.BlueGrey800,
                            Primary.BlueGrey900,
                            Primary.BlueGrey500,
                            Accent.LightBlue200,
                            TextShade.WHITE);

                //显示登录的用户名
                //btnUserName.Text = "欢迎：" + sysDataModel.gUserName;
                sysDataModel.gSystemSts = SystemStatus.Normal;
                sysDataModel.gGpsLastTime = DateTime.Now;
                sysDataModel.gLastMavlinkTime = DateTime.Now;

                //初始化GMapManager对象
                initGMapManager();

                //初始化数据，加载数据库数据
                initTestData();

                initChecker();

                //frmFlyRoutes frmfly = new frmFlyRoutes(this.gMapControl1, frmain.spFlyData);
                GMapManager gmapset = new GMapManager(this.gMapControl);
                gmapset.init();

                //加载地图底图服务
                loadMapProviders();

                // 保证地图上的控件背景透明
                headingIndicatorInstrumentControl1.Parent = gMapControl;
                attitudeIndicatorInstrumentControl1.Parent = gMapControl;
                btnRotate.Parent = gMapControl;
                labGroundName.Parent = gMapControl;
                labGroundName.FillColor = Color.FromArgb(150, 200, 200, 200);
                btnPositioningAircraft.Parent = gMapControl;
                btnMapZoomUp.Parent = gMapControl;
                btnMapZoomDn.Parent = gMapControl;

                //MAVLINK
                if (sysDataModel.gProtocol == 1)
                {
                    //电台串口读取飞控数据，解析到全局数据模型中
                    sysSerialPort.startRecvThread();

                    //RTK串口读取RTCM数据
                    //sysSerialPort.startRTKRecvThread();

                    //定时器3启动(全局数据处理)
                    timer.Interval = 30;
                    timer.Enabled = true;
                    timer.AutoReset = true;
                    timer.Elapsed += timer_Elapsed;
                }

#if !DEBUG
                this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
                this.WindowState = FormWindowState.Maximized;
#endif
            }
        }

        /// <summary>
        /// 退出按钮
        /// 关闭当前窗口
        /// 释放全部资源
        /// 退出应用程序
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            sysSerialPort.stopRecvThread();
            sysFunction.exitApplication();
            this.Close();
            System.Environment.Exit(0);
            //Application.Exit();
        }

        /// <summary>
        /// 重连按钮
        /// 关闭串口
        /// 打开串口
        /// 向无人机发送建立连接请求
        /// 接收建立连接响应
        /// 判断是否连接成功
        /// </summary>
        private void btnReConnect_Click(object sender, EventArgs e)
        {
            int lRet = -1;

            sysLog.Info("重新连接！");

            if (sysDataModel.gProtocol == 1)
            {
                //关闭串口
                if (sysSerialPort.mSerialPort.IsOpen)
                {
                    sysSerialPort.mComStatus = 0;
                    sysSerialPort.mSerialPort.DiscardInBuffer();
                    sysSerialPort.mSerialPort.Close();
                    txtSystemStatus.Text = "串口已关闭";
                    txtSystemStatus.FillColor = Color.Red;
                }
                try
                {
                    //打开串口
                    sysSerialPort.mSerialPort.Open();
                    if (sysSerialPort.mSerialPort.IsOpen)
                    {
                        sysLog.Info("串口打开成功！");
                    }
                }
                catch (Exception ex)
                {
                    sysSerialPort.mComStatus = 0;
                    sysSerialPort.mSerialPort.Close();
                    txtSystemStatus.Text = "系统异常";
                    txtSystemStatus.FillColor = Color.Red;
                    sysLog.Error("无人机连接失败！");
                    return;
                }
            }
        }


        #region 飞行高度不对提醒
        private void timer3_Tick(object sender, EventArgs e) { }
        /// <summary>
        /// 定时器3
        /// 从无人机接收数据响应消息
        /// 每隔30ms，判断一次系统状态
        /// 每隔30ms，读取一次全局飞行数据，并处理
        /// </summary>
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var startTime = DateTime.Now;
            //sysLog.Debug("timer tick on {time}", startTime);
            try
            {
                //超过3秒没收到Mavlink数据，认为通讯不正常
                TimeSpan dt2 = DateTime.Now - sysDataModel.gLastMavlinkTime;
                if (dt2.TotalSeconds > 3) sysDataModel.gSystemSts = SystemStatus.DataTimedOut;

                //超过10秒没收到GPS数据，认为GPS不正常
                TimeSpan dt3 = DateTime.Now - sysDataModel.gGpsLastTime;
                if (dt3.TotalSeconds > 10) sysDataModel.flyData.origin.FixType = GPS_FIX_TYPE.NO_GPS;

                //飞行数据处理、显示、训练、考试
                //最重要的方法
                if (Monitor.TryEnter(this))
                {
                    try
                    {
                        flyDataProcess();
                    }
                    finally
                    {
                        Monitor.Exit(this);
                    }
                }
            }
            catch (Exception ex)
            {
                //串口错误
                //暂不处理
                sysLog.Error(ex, "飞行数据处理异常");
            }
            //sysLog.Debug("timer tick finish on {time}", DateTime.Now - startTime);
        }


        private void invoke(Control control, Delegate method)
        {
            if (control == null || control.Disposing || control.IsDisposed)
            {
                timer.Enabled = false;
                return;
            }
            try
            {
                control.BeginInvoke(method);
            }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) { }
            catch (Exception ex)
            {
                sysLog.Error(ex, "飞行数据处理异常");
            }
        }
        private void setTextInvoke(Control control, double value)
        {
            invoke(control, new MethodInvoker(delegate
            {
                control.Text = string.Format("{0:0.00}", value);
            }));
        }
        private void setTextInvoke(Control control, string value)
        {
            invoke(control, new MethodInvoker(delegate
            {
                control.Text = value;
            }));
        }
        private void setCheckedInvoke(UIRadioButton control, bool value)
        {
            invoke(control, new MethodInvoker(delegate
            {
                control.Checked = value;
            }));
        }
        private void setFillColorInvoke(UITextBox control, Color color)
        {
            invoke(control, new MethodInvoker(delegate
            {
                control.FillColor = color;
            }));
        }
        private void appendResultInvoke(string text)
        {
            invoke(listTextResult, new MethodInvoker(delegate
            {
                listTextResult.Items.Add(text);
                listTextResult.TopIndex = listTextResult.Items.Count - 1;
            }));
        }

        /// <summary>
        /// 飞控数据处理
        /// 用于显示，处理，训练，考试
        /// </summary>
        private void flyDataProcess()
        {
            //计算航速（北向速度、东向速度综合计算）
            sysDataModel.flyData.judge.flightSpeed = Math.Sqrt((double)(sysDataModel.Vx * sysDataModel.Vx + sysDataModel.Vy * sysDataModel.Vy));
            //计算中心点距离
            double dis = Calculate.getDistance(sysDataModel.gCenterPoint.Lat, sysDataModel.gCenterPoint.Lng, sysDataModel.Latitude, sysDataModel.Longtitude);
            sysDataModel.flyData.judge.distance = dis;

            switch (sysDataModel.gTestSts)
            {
                case TestSts.NotSelected:
                    //未开始
                    uiPanel7.Text = "训练未开始";
                    break;
                case TestSts.FeedomTrain:
                    //自由练习
                    uiPanel7.Text = "自由练习开始";
                    break;
                case TestSts.RotateTrain:
                    //自旋练习
                    uiPanel7.Text = "自旋练习开始";
                    testRotate(dis);
                    if (sysDataModel.gRotateSts == RotateSts.RotateSuccess
                     || sysDataModel.gRotateSts == RotateSts.RotateFailed)
                    {
                        appendResultInvoke("⚪ 自旋练习完成");
                        tools.SpeakVoiceAppend("可以退出中心点，重新练习", 1, 100);
                        realData.phiOffsetCnt = 0;
                        setTextInvoke(txtTimeLength, "000");
                        sysDataModel.gRotateSts = RotateSts.Started;
                        break;
                    }
                    break;
                case TestSts.EightTrain:
                    //8字练习
                    uiPanel7.Text = "八字练习开始";
                    testEight(dis);
                    if (sysDataModel.gEightSts == EightSts.EightPass
                     || sysDataModel.gEightSts == EightSts.EightFail)
                    {
                        appendResultInvoke("⚪ 八字练习完成");
                        tools.SpeakVoiceAppend("可以退出中心点，重新练习", 1, 100);
                        realData.phiOffsetCnt = 0;
                        setTextInvoke(txtTimeLength, "000");
                        sysDataModel.gEightSts = EightSts.Started;
                        break;
                    }
                    break;
                case TestSts.ShamTest:
                    //模拟开始，自旋和8字共3次机会
                    //每次失败，重新开始当前科目
                    //3次采用不同的颜色轨迹
                    uiPanel7.Text = "模拟考试开始";
                    testRotate(dis);
                    if (sysDataModel.gRotateSts == RotateSts.RotateSuccess)
                    {
                        //自旋模拟考试成功
                        appendResultInvoke("⚪ 自旋科目完成");
                        tools.SpeakVoiceAppend("请退出中心点", 1, 100);
                        realData.phiOffsetCnt = 0;
                        setTextInvoke(txtTimeLength, "000");
                        setCheckedInvoke(uiTestItemEight, true);
                        sysDataModel.gTestSts = TestSts.ShamTest;
                        sysDataModel.gRotateSts = RotateSts.UnStart;
                        sysDataModel.gEightSts = EightSts.Started;
                    }
                    if (sysDataModel.gRotateSts == RotateSts.RotateFailed)
                    {
                        //自旋模拟考试失败
                        if (applyForRetryTest()) sysDataModel.gRotateSts = RotateSts.Started;
                        break;
                    }
                    //八字科目考试
                    testEight(dis);
                    if (sysDataModel.gEightSts == EightSts.EightPass)
                    {
                        //八字科目考试成功
                        appendResultInvoke("⚪ 八字科目完成!");
                        appendResultInvoke("⚪ 模拟考试成功!");
                        tools.SpeakVoiceNow("模拟考试成功", 1, 100);
                        setTextInvoke(txtTimeLength, "000");
                        sysDataModel.gTestSts = TestSts.NotSelected;
                        sysDataModel.gRotateSts = RotateSts.UnStart;
                        sysDataModel.gEightSts = EightSts.UnStart;
                        sysDataModel.gTestCount = 0;
                    }
                    if (sysDataModel.gEightSts == EightSts.EightFail)
                    {
                        //八字科目考试失败
                        if (applyForRetryTest()) sysDataModel.gEightSts = EightSts.Started;
                        break;
                    }
                    break;
                default:
                    break;
            }

            if (sysDataModel.gTestSts != TestSts.NotSelected)
            {
                //添加轨迹
                sysFunction.mFlyData.Add(new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude));
                //绘制轨迹
                sysFunction.MapPloyLine3(GMapManager.flytransOverlay2, sysFunction.mFlyData, sysDataModel.gColor, (int)sysDataModel.FlyCode);
            }
            else
            {
                sysFunction.MapPloyLine2(GMapManager.flytransOverlay2, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), Color.DimGray, (int)sysDataModel.FlyCode);
            }

            //无人机图标，随航向角转动
            sysFunction.flytransmarker[(int)(sysDataModel.FlyCode - 1)].Angle = (int)(sysDataModel.YawAngle - this.gMapControl.Bearing);
            sysFunction.flytransmarker[(int)(sysDataModel.FlyCode - 1)].IsVisible = true;
        }

        /// <summary>
        /// 自旋练习
        /// </summary>
        private void testRotate(double dis)
        {
            switch (sysDataModel.gRotateSts)
            {
                case RotateSts.UnStart://未开始
                    break;
                case RotateSts.Started://已开始-未计时
                    {
                        realData.phiOffsetCnt = 0;

                        // 自旋360°项目——无人机起飞点离中心点位置判断
                        if (dis <= sysDataModel.gTestParam.txtTestRadOffset)
                        {
                            tools.SpeakVoice("请离开中心点，距离大于" + sysDataModel.gTestParam.txtTestRadOffset + "米", 1, 100);
                            setFillColorInvoke(txtDistance, Color.OrangeRed);
                            break;
                        }

                        // 自旋360°项目——无人机飞行高度判断
                        if (sysDataModel.RelativeAlt < sysDataModel.gTestParam.txtRotateMinHeight)
                        {
                            tools.SpeakVoice("飞行高度不能小于" + sysDataModel.gTestParam.txtRotateMinHeight.ToString() + "米", 1, 100);
                            setFillColorInvoke(txtFlyHeight, Color.OrangeRed);
                            break;
                        }
                        if (sysDataModel.RelativeAlt > sysDataModel.gTestParam.txtRotateMaxHeight)
                        {
                            tools.SpeakVoice("飞行高度不能大于" + sysDataModel.gTestParam.txtRotateMaxHeight.ToString() + "米", 1, 100);
                            setFillColorInvoke(txtFlyHeight, Color.OrangeRed);
                            break;
                        }
                        
                        setFillColorInvoke(txtFlyHeight, Color.White);
                        setFillColorInvoke(txtDistance, Color.White);

                        sysLog.Debug("leave center circle {dis} > {offset}", dis, sysDataModel.gTestParam.txtTestRadOffset);
                        sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.EnterCenterCircleNotice);
                        sysDataModel.gRotateSts = RotateSts.EnterCenterCircleNotice;
                        break;
                    }
                case RotateSts.EnterCenterCircleNotice://已开始-开始计时-未进圈
                    {
                        realData.timeTag = DateTime.Now;

                        // 重置飞行错误标志
                        sysErrorChecker.ResetAll();
                        sysDataModel.ErrorFlag = ErrorFlag.None;

                        // 重置自旋一周统计
                        sysDataModel.gSysRouter.Reset();

                        tools.SpeakVoiceNow("进入中心点倒计时" + sysDataModel.gTestParam.txtTestTimeout.ToString() + "秒", 1, 100);
                        appendResultInvoke("⚪ 进入中心点倒计时：" + sysDataModel.gTestParam.txtTestTimeout.ToString() + "秒");

                        sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.EnterCenterCircleCheck);
                        sysDataModel.gRotateSts = RotateSts.EnterCenterCircleCheck;
                        break;
                    }
                case RotateSts.EnterCenterCircleCheck://已开始-开始计时-进圈中
                    {
                        TimeSpan prepareElapse = DateTime.Now - realData.timeTag;
                        // 自旋360°项目——自旋准备时间内进入中心点超时
                        if (prepareElapse.TotalSeconds >= sysDataModel.gTestParam.txtTestTimeout)
                        {
                            GMapManager.RevolveFlyCircle.IsVisible = false;
                            sysLog.Debug("enter center timeout");

                            tools.SpeakVoiceNow("进入中心点超时，请重新开始", 1, 100);
                            appendResultInvoke("╳ 进入中心点超时，请重新开始");

                            sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.Started);
                            sysDataModel.gRotateSts = RotateSts.Started;
                            break;
                        }

                        // 自旋360°项目——更新剩余准备时间倒计时
                        setTextInvoke(txtTimeLength, ((int)(sysDataModel.gTestParam.txtTestTimeout - prepareElapse.TotalSeconds)).ToString());

                        // 自旋360°项目——准备阶段圈外，无人机飞行高度判断
                        if (sysDataModel.RelativeAlt < sysDataModel.gTestParam.txtRotateMinHeight ||
                            sysDataModel.RelativeAlt > sysDataModel.gTestParam.txtRotateMaxHeight)
                        {
                            //sysLog.Debug($"bad height: {sysDataModel.RelativeAlt}m, range is {sysDataModel.gTestParam.txtRotateMinHeight}-{sysDataModel.gTestParam.txtRotateMaxHeight}");
                            this.noticeBadHeight();
                            break;
                        }
                        else
                        {
                            this.resetBadHeight();
                        }

                        //以无人机当前位置为中心，生成半径1米的圆，无人机自旋时不超过此范围
                        GMapManager.RevolveFlyCircle.IsVisible = true;
                        GMapManager.RevolveFlyCircle.Position = new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude);
                        GMapManager.RevolveFlyCircle.Radius = 1.0f;

                        //接近中心点时
                        if (dis <= sysDataModel.gTestParam.txtTestRadOffset)
                        {
                            sysLog.Debug("enter center circle {dis} <= {offset}", dis, sysDataModel.gTestParam.txtTestRadOffset);
                            realData.lng = sysDataModel.Longtitude;
                            realData.lat = sysDataModel.Latitude;
                            realData.height = sysDataModel.RelativeAlt;
                            realData.phi = sysDataModel.YawAngle;

                            tools.SpeakVoiceNow("已进入中心点，请开始水平自旋", 1, 100);

                            sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.PrepareForRotate);
                            sysDataModel.gRotateSts = RotateSts.PrepareForRotate;
                            break;
                        }
                        break;
                    }
                case RotateSts.PrepareForRotate://已开始-开始计时-已进圈-无人机旋转角度大于15°时,开始计时
                    {
                        //以无人机当前位置为中心，生成半径1米的圆，无人机自旋时不超过此范围
                        GMapManager.RevolveFlyCircle.Position = new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude);

                        TimeSpan prepareElapse = DateTime.Now - realData.timeTag;

                        // 自旋360°项目——更新项目准备倒计时
                        setTextInvoke(txtTimeLength, ((int)(sysDataModel.gTestParam.txtTestTimeout - prepareElapse.TotalSeconds)).ToString());

                        // 自旋360°项目——准备阶段圈内，飞行高度判断
                        if (sysDataModel.RelativeAlt < sysDataModel.gTestParam.txtRotateMinHeight ||
                            sysDataModel.RelativeAlt > sysDataModel.gTestParam.txtRotateMaxHeight)
                        {
                            //sysLog.Info($"bad height: {sysDataModel.RelativeAlt}m, range is {sysDataModel.gTestParam.txtRotateMinHeight}-{sysDataModel.gTestParam.txtRotateMaxHeight}");
                            this.noticeBadHeight();
                            break;
                        }
                        else
                        {
                            this.resetBadHeight();
                        }

                        double revolve = Math.Abs(Calculate.toDegress180(sysDataModel.YawAngle - realData.phi));
                        // 自旋360°项目——项目启动条件：无人机旋转角度大于15°时或准备时间结束
                        if (revolve >= 15.0f || prepareElapse.TotalSeconds >= sysDataModel.gTestParam.txtTestTimeout)
                        {
                            sysLog.Debug("rotate start revolve:{revolve}°", revolve);
                            if (prepareElapse.TotalSeconds >= sysDataModel.gTestParam.txtTestTimeout)
                            {
                                sysLog.Debug("rotate start timeout:{dis}s", prepareElapse.TotalSeconds);
                                realData.phi = sysDataModel.YawAngle; 
                            }
                            realData.timeTag = DateTime.Now;
                            realData.lng = sysDataModel.Longtitude;
                            realData.lat = sysDataModel.Latitude;
                            realData.height = sysDataModel.RelativeAlt;
                            realData.phiOffsetCnt = 0;

                            tools.SpeakVoiceNow("自旋计时开始" + sysDataModel.gTestParam.txtRotateMaxTime.ToString() + "秒", 1, 100);
                            appendResultInvoke("⚪ 自旋计时开始：" + sysDataModel.gTestParam.txtRotateMaxTime.ToString() + "秒");
                            // 自旋360°项目——更新显示水平自旋项目总时间
                            setTextInvoke(txtTimeLength, sysDataModel.gTestParam.txtRotateMaxTime.ToString());

                            sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.RotateInProgress);
                            sysDataModel.gRotateSts = RotateSts.RotateInProgress;
                            break;
                        }
                        else
                        {
                            int remainTime = (int)(sysDataModel.gTestParam.txtTestTimeout - prepareElapse.TotalSeconds);
                            if (remainTime == 30 + 2 || remainTime == 15 + 2 || remainTime == 5 + 2) { 
                                tools.SpeakVoice("请在" + (remainTime - 2) + "秒内开始水平自旋。", 1, 100);
                            }
                        }

                        break;
                    }
                case RotateSts.RotateInProgress://已开始-开始计时-已进圈-开始计时
                    {
                        #region 自旋360°项目——项目超时判断
                        TimeSpan rotateElapse = DateTime.Now - realData.timeTag;
                        if (rotateElapse.TotalSeconds >= sysDataModel.gTestParam.txtRotateMaxTime)
                        {
                            tools.SpeakVoiceNow("水平自旋超时", 1, 100);
                            appendResultInvoke("╳ 水平自旋超时");

                            sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.RotateFailed);
                            sysDataModel.gRotateSts = RotateSts.RotateFailed;
                            break;
                        }
                        #endregion

                        // 自旋360°项目——更新项目剩余时间
                        setTextInvoke(txtTimeLength, ((int)(sysDataModel.gTestParam.txtRotateMaxTime - rotateElapse.TotalSeconds)).ToString());

                        #region 自旋360°项目——垂直偏移判断规则
                        sysDataModel.flyData.judge.vOffset = Math.Abs(sysDataModel.RelativeAlt - realData.height);
                        checkerVOffsetOR.Judge(sysDataModel.flyData.judge.vOffset > sysDataModel.gTestParam.txtRotateVOffset);
                        if (checkerVOffsetOR.IsHappened())
                        {
                            sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.RotateFailed);
                            sysDataModel.gRotateSts = RotateSts.RotateFailed;
                            break;
                        }
                        #endregion

                        #region 自旋360°项目——水平偏移判断规则
                        sysDataModel.flyData.judge.hOffset = TestTools.HOffset(new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), new PointLatLng(realData.lat, realData.lng));
                        checkerHOffsetOR.Judge(sysDataModel.flyData.judge.hOffset > sysDataModel.gTestParam.txtRotateHOffset);
                        if (checkerHOffsetOR.IsHappened())
                        {
                            sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.RotateFailed);
                            sysDataModel.gRotateSts = RotateSts.RotateFailed;
                            break;
                        }
                        #endregion

                        #region 自旋360°项目——角速度判断,使用Y轴角速度
                        sysDataModel.flyData.judge.yawSpeed = Math.Abs(sysDataModel.YawSpeed);
                        checkerYawSpeedORHi.Judge(sysDataModel.flyData.judge.yawSpeed > sysDataModel.gTestParam.txtRotateMaxAngleSpeed);
                        checkerYawSpeedORLo.Judge(sysDataModel.flyData.judge.yawSpeed < sysDataModel.gTestParam.txtRotateMinAngleSpeed);
                        if (checkerYawSpeedORHi.IsHappened() || checkerYawSpeedORLo.IsHappened())
                        {
                            sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.RotateFailed);
                            sysDataModel.gRotateSts = RotateSts.RotateFailed;
                            break;
                        }
                        #endregion

                        #region 自旋360°项目——自旋一周完成判断
                        double revolve = Math.Abs(sysDataModel.YawAngle - realData.phi);
                        if (sysDataModel.gSysRouter.Done() && revolve < 10)
                        {
                            tools.SpeakVoiceNow("自旋一周完成", 1, 100);
                            appendResultInvoke("⚪ 自旋一周完成");

                            sysLog.Debug("rotate status from {old} to {new}", sysDataModel.gRotateSts, RotateSts.RotateSuccess);
                            sysDataModel.gRotateSts = RotateSts.RotateSuccess;
                            break;
                        }
                        else
                        {
                            sysDataModel.gSysRouter.Update(sysDataModel.YawAngle);
                        }
                        #endregion

                        break;
                    }
                case RotateSts.RotateSuccess://自旋成功
                    setTextInvoke(txtTimeLength, "000");
                    realData.phiOffsetCnt = 0;
                    break;
                case RotateSts.RotateFailed://自旋失败
                    setTextInvoke(txtTimeLength, "000");
                    realData.phiOffsetCnt = 0;
                    break;
            }
        }
        /// <summary>
        /// 八字练习
        /// </summary>
        private void testEight(double dis)
        {
            switch (sysDataModel.gEightSts)
            {
                case EightSts.UnStart:
                    //未开始
                    break;
                case EightSts.Started://已开始-未计时
                    {
                        //八字绕飞——无人机起飞时需要远离中心点大于设定距离
                        if (dis <= sysDataModel.gTestParam.txtTestRadOffset)
                        {
                            tools.SpeakVoice("请离开中心点，距离大于" + sysDataModel.gTestParam.txtTestRadOffset + "米", 1, 100);
                            txtDistance.FillColor = Color.OrangeRed;
                            break;
                        }

                        //八字绕飞——无人机起飞时飞行高度应在规定高度范围内
                        if (sysDataModel.RelativeAlt < sysDataModel.gTestParam.txtEightMinHeight)
                        {
                            tools.SpeakVoice("飞行高度不能小于" + sysDataModel.gTestParam.txtEightMinHeight.ToString() + "米", 1, 100);
                            txtFlyHeight.FillColor = Color.OrangeRed;
                            break;
                        }
                        else if (sysDataModel.RelativeAlt > sysDataModel.gTestParam.txtEightMaxHeight)
                        {
                            tools.SpeakVoice("飞行高度不能大于" + sysDataModel.gTestParam.txtEightMaxHeight.ToString() + "米", 1, 100);
                            txtFlyHeight.FillColor = Color.OrangeRed;
                            break;
                        }
                        
                        setFillColorInvoke(txtFlyHeight, Color.White);
                        setFillColorInvoke(txtDistance, Color.White);

                        //八字绕飞——起飞时飞机与中心点距离和飞机高度在规定范围内则开始进入中心点倒计时
                        sysLog.Debug("leave center circle {dis} > {offset}", dis, sysDataModel.gTestParam.txtTestRadOffset);
                        sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EnterCenterCircleNotice);
                        sysDataModel.gEightSts = EightSts.EnterCenterCircleNotice;
                        break;
                    }
                case EightSts.EnterCenterCircleNotice://已开始-开始计时-未进圈
                    {
                        realData.timeTag = DateTime.Now; // 记录进入中心点倒计时起始时间
                        mPointIndex = 0; // 开始"8"字绕飞前重置过桶记录

                        // 重置飞行错误标志
                        sysErrorChecker.ResetAll();
                        sysDataModel.ErrorFlag = ErrorFlag.None;

                        tools.SpeakVoiceNow("进入中心点倒计时" + sysDataModel.gTestParam.txtTestTimeout.ToString() + "秒", 1, 100);
                        appendResultInvoke("⚪ 进入中心点倒计时：" + sysDataModel.gTestParam.txtTestTimeout.ToString() + "秒");

                        sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EnterCenterCircleCheck);
                        sysDataModel.gEightSts = EightSts.EnterCenterCircleCheck;
                        break;
                    }
                case EightSts.EnterCenterCircleCheck://已开始-开始计时-进圈中
                    {
                        TimeSpan prepareElapse = DateTime.Now - realData.timeTag;
                        // 八字绕飞——进圈超时60秒判断—未超时
                        if (prepareElapse.TotalSeconds >= sysDataModel.gTestParam.txtTestTimeout)
                        {
                            sysLog.Debug("enter center timeout");

                            tools.SpeakVoiceNow("进入中心点超时，请重新开始", 1, 100);
                            appendResultInvoke("╳ 进入中心点超时，请重新开始");

                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.Started);
                            sysDataModel.gEightSts = EightSts.Started;
                            break;
                        }

                        // 八字绕飞——更新剩余准备时间倒计时
                        setTextInvoke(txtTimeLength, ((int)(sysDataModel.gTestParam.txtTestTimeout - prepareElapse.TotalSeconds)).ToString());

                        // 八字绕飞——准备阶段圈外，无人机飞行高度判断
                        if (sysDataModel.RelativeAlt < sysDataModel.gTestParam.txtEightMinHeight ||
                            sysDataModel.RelativeAlt > sysDataModel.gTestParam.txtEightMaxHeight)
                        {
                            //sysLog.Info($"bad height: {sysDataModel.RelativeAlt}m, range is {sysDataModel.gTestParam.txtEightMinHeight}-{sysDataModel.gTestParam.txtEightMaxHeight}");
                            this.noticeBadHeight();
                            break;
                        }
                        else
                        {
                            this.resetBadHeight();
                        }

                        // 八字绕飞——非常接近中心点时，八字计时开始
                        if (dis < sysDataModel.gTestParam.txtTestRadOffset)
                        {
                            sysLog.Debug("enter center circle {dis} <= {offset}", dis, sysDataModel.gTestParam.txtTestRadOffset);

                            tools.SpeakVoiceNow("已进入中心点，请开始八字飞行", 1, 100);

                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.PrepareForEight);
                            sysDataModel.gEightSts = EightSts.PrepareForEight;
                            break;
                        }
                        break;
                    }
                case EightSts.PrepareForEight://已开始-开始计时-已进圈-0秒后开始计时
                    {
                        TimeSpan prepareElapse = DateTime.Now - realData.timeTag;

                        // 八字绕飞项目——更新项目准备倒计时
                        setTextInvoke(txtTimeLength, ((int)(sysDataModel.gTestParam.txtTestTimeout - prepareElapse.TotalSeconds)).ToString());

                        // 八字绕飞项目——准备阶段圈内，飞行高度判断
                        if (sysDataModel.RelativeAlt < sysDataModel.gTestParam.txtEightMinHeight ||
                            sysDataModel.RelativeAlt > sysDataModel.gTestParam.txtEightMaxHeight)
                        {
                            //sysLog.Info($"bad height: {sysDataModel.RelativeAlt}m, range is {sysDataModel.gTestParam.txtEightMinHeight}-{sysDataModel.gTestParam.txtEightMaxHeight}");
                            this.noticeBadHeight();
                            break;
                        }
                        else
                        {
                            this.resetBadHeight();
                        }

                        if (dis > sysDataModel.gTestParam.txtTestRadOffset || prepareElapse.TotalSeconds >= sysDataModel.gTestParam.txtTestTimeout)
                        {
                            sysLog.Debug("eight start: {dis}>{offset} or timeout", dis, sysDataModel.gTestParam.txtTestRadOffset);
                            realData.timeTag = DateTime.Now; // 记录八字绕飞起始时间
                            realData.lng = sysDataModel.Longtitude;
                            realData.lat = sysDataModel.Latitude;
                            realData.height = sysDataModel.RelativeAlt;
                            realData.phi = sysDataModel.YawAngle;
                            realData.phiOffsetCnt = 0;

                            // tmp addddddddddddddddddddddddddddddd
                            mPointIndex = 1; // 开始"8"字绕飞前重置过桶记录

                            tools.SpeakVoiceNow("八字计时开始" + sysDataModel.gTestParam.txtEightTimeout.ToString() + "秒", 1, 100);
                            appendResultInvoke("⚪ 八字计时开始：" + sysDataModel.gTestParam.txtEightTimeout.ToString() + "秒");
                            // 八字绕飞项目——更新显示八字绕飞项目总时间
                            setTextInvoke(txtTimeLength, sysDataModel.gTestParam.txtEightTimeout.ToString());

                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightInProgress);
                            sysDataModel.gEightSts = EightSts.EightInProgress;
                            break;
                        }
                        else
                        {
                            int remainTime = (int)(sysDataModel.gTestParam.txtTestTimeout - prepareElapse.TotalSeconds);
                            if (remainTime == 30 + 2 || remainTime == 15 + 2 || remainTime == 5 + 2) { 
                                tools.SpeakVoice("请在" + (remainTime - 2) + "秒内开始八字飞行。", 1, 100);
                            }
                        }
                        
                        break;
                    }
                case EightSts.EightInProgress://已开始-八字-开始计时-左圆-4各点位
                    {
                        #region 八字绕飞项目——八字超时判断
                        TimeSpan eightElapse = DateTime.Now - realData.timeTag;
                        if (sysDataModel.gTestParam.txtEightTimeout <= eightElapse.TotalSeconds)
                        {
                            tools.SpeakVoiceNow("八字飞行超时", 1, 100);
                            appendResultInvoke("╳ 八字飞行超时");

                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightFail);
                            sysDataModel.gEightSts = EightSts.EightFail;
                            break;
                        }
                        #endregion
                        
                        // 八字绕飞项目——更新项目剩余时间
                        setTextInvoke(txtTimeLength, ((int)(sysDataModel.gTestParam.txtEightTimeout - eightElapse.TotalSeconds)).ToString());
                                                
                        #region 过桶检测
                        {
                            double angle;
                            switch (mPointIndex)
                            {
                                case 0://无桶
                                    angle = TestTools.get3PointAngle(sysDataModel.gLeftPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle > 0 && angle < 15)
                                    {
                                        mPointIndex = 1;
                                    }
                                    break;
                                case 1://桶一
                                    angle = TestTools.get3PointAngle(sysDataModel.gLeftPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle > 90 && angle < 100)
                                    {
                                        mPointIndex = 2;
                                        tools.SpeakVoiceNow("通过点位一", 1, 100);
                                        appendResultInvoke("⚪ 通过点位一");
                                    }
                                    break;
                                case 2://桶二
                                    angle = TestTools.get3PointAngle(sysDataModel.gLeftPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle > 170)
                                    {
                                        mPointIndex = 3;
                                        tools.SpeakVoiceNow("通过点位二", 1, 100);
                                        appendResultInvoke("⚪ 通过点位二");
                                    }
                                    break;
                                case 3://桶三
                                    angle = TestTools.get3PointAngle(sysDataModel.gLeftPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle > 90 && angle < 100)
                                    {
                                        mPointIndex = 4;
                                        tools.SpeakVoiceNow("通过点位三", 1, 100);
                                        appendResultInvoke("⚪ 通过点位三");
                                    }
                                    break;
                                case 4://桶四
                                    angle = TestTools.get3PointAngle(sysDataModel.gLeftPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle < 5)
                                    {
                                        mPointIndex = 5;
                                        tools.SpeakVoiceNow("通过点位四", 1, 100);
                                        appendResultInvoke("⚪ 通过点位四");
                                    }
                                    break;
                                case 5://桶五
                                    angle = TestTools.get3PointAngle(sysDataModel.gRightPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle > 90 && angle < 100)
                                    {
                                        mPointIndex = 6;
                                        tools.SpeakVoiceNow("通过点位五", 1, 100);
                                        appendResultInvoke("⚪ 通过点位五");
                                    }
                                    break;
                                case 6://桶六
                                    angle = TestTools.get3PointAngle(sysDataModel.gRightPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle > 170)
                                    {
                                        mPointIndex = 7;
                                        tools.SpeakVoiceNow("通过点位六", 1, 100);
                                        appendResultInvoke("⚪ 通过点位六");
                                    }
                                    break;
                                case 7://桶七
                                    angle = TestTools.get3PointAngle(sysDataModel.gRightPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle > 80 && angle < 100)
                                    {
                                        mPointIndex = 8;
                                        tools.SpeakVoiceNow("通过点位七", 1, 100);
                                        appendResultInvoke("⚪ 通过点位七");
                                    }
                                    break;
                                case 8://桶八—8字结束
                                    angle = TestTools.get3PointAngle(sysDataModel.gRightPoint, new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gCenterPoint);
                                    if (angle < 20)
                                    {
                                        mPointIndex = 9;
                                        tools.SpeakVoiceNow("通过点位八", 1, 100);
                                        appendResultInvoke("⚪ 通过点位八");
                                    }
                                    break;
                            }
                            if (mPointIndex > 4)
                            {
                                mLeftFlag = false;
                            }
                            else
                            {
                                mLeftFlag = true;
                            }
                        }
                        #endregion

                        #region 八字飞行项目——垂直偏移判断
                        sysDataModel.flyData.judge.vOffset = Math.Abs(sysDataModel.RelativeAlt - realData.height);
                        checkerVOffsetOR.Judge(sysDataModel.flyData.judge.vOffset > sysDataModel.gTestParam.txtEightVOffset);
                        if (checkerVOffsetOR.IsHappened() && sysDataModel.gTestSts == TestSts.ShamTest) // 模拟考试
                        { 
                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightFail);
                            sysDataModel.gEightSts = EightSts.EightFail;
                            break;
                        }
                        #endregion

                        #region 八字飞行项目——水平偏移判断
                        double hOffset;
                        if (mLeftFlag)
                            hOffset = TestTools.HOffset(new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gLeftPoint);
                        else
                            hOffset = TestTools.HOffset(new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude), sysDataModel.gRightPoint);
                        
                        sysDataModel.flyData.judge.hOffset = hOffset - 6; // todo: 后期修改为从场地参数获取
                        checkerHOffsetOR.Judge(Math.Abs(sysDataModel.flyData.judge.hOffset) > sysDataModel.gTestParam.txtEightHOffset);
                        if (checkerHOffsetOR.IsHappened() && sysDataModel.gTestSts == TestSts.ShamTest) // 模拟考试
                        {
                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightFail);
                            sysDataModel.gEightSts = EightSts.EightFail;
                            break;
                        }
                        #endregion

                        #region 八字飞行项目——飞行角速度：角速度判断,使用Y轴角速度,小于最小角速度，判断是否停止
                        sysDataModel.flyData.judge.yawSpeed = sysDataModel.YawSpeed;
                        checkerYawSpeedOR.Judge(Math.Abs(sysDataModel.flyData.judge.yawSpeed) < sysDataModel.gTestParam.txtEightMinAngleSpeed);
                        if (checkerYawSpeedOR.IsHappened() && sysDataModel.gTestSts == TestSts.ShamTest) // 模拟考试
                        {
                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightFail);
                            sysDataModel.gEightSts = EightSts.EightFail;
                            break;
                        }
                        #endregion

                        #region 八字飞行项目——航向角判定规则：
                        // 计算航向角偏差
                        double angleCenter, angleOffset;
                        if (mLeftFlag)
                            angleCenter = Calculate.getAngle(new CustomLatLng(sysDataModel.gLeftPoint.Lat, sysDataModel.gLeftPoint.Lng), new CustomLatLng(sysDataModel.Latitude, sysDataModel.Longtitude));
                        else
                            angleCenter = Calculate.getAngle(new CustomLatLng(sysDataModel.gRightPoint.Lat, sysDataModel.gRightPoint.Lng), new CustomLatLng(sysDataModel.Latitude, sysDataModel.Longtitude)) - 180;

                        sysDataModel.flyData.judge.angleOffset = (sysDataModel.YawAngle + angleCenter + 540) % 360 - 180;
                        angleOffset = Math.Abs(sysDataModel.flyData.judge.angleOffset);
                        checkerYawAngleOR.Judge(angleOffset > sysDataModel.gTestParam.txtEightPhiOffset);
                        if (checkerYawAngleOR.IsHappened() && sysDataModel.gTestSts == TestSts.ShamTest) // 模拟考试
                        {
                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightFail);
                            sysDataModel.gEightSts = EightSts.EightFail;
                            break;
                        }
                        #endregion

                        // 临时增加航向统计开关
                        if (cbYawAngleAccum.Checked)
                        {
                            #region 八字飞行项目——航向统计范围80%、航向统计比例30%
                            double YawAngleCumulative = sysDataModel.gTestParam.txtEightPhiOffset * 0.8;
                            long totleFlyTime = (long)eightElapse.TotalMilliseconds;
                            checkerYawAngleAccumOR.Judge(angleOffset > YawAngleCumulative && angleOffset < sysDataModel.gTestParam.txtEightPhiOffset, totleFlyTime);
                            if (checkerYawAngleAccumOR.IsHappened() && sysDataModel.gTestSts == TestSts.ShamTest) // 模拟考试
                            {
                                sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightFail);
                                sysDataModel.gEightSts = EightSts.EightFail;
                                break;
                            }
                            #endregion
                        }

                        #region 八字飞行项目——飞行速度判断
                        // sysDataModel.flyData.judge.flightSpeed = realData.speed;
                        checkerFlightSpeedORHi.Judge(sysDataModel.flyData.judge.flightSpeed > sysDataModel.gTestParam.txtEightMaxSpeed);
                        checkerFlightSpeedORLo.Judge(sysDataModel.flyData.judge.flightSpeed < sysDataModel.gTestParam.txtEightMinSpeed);
                        if ((checkerFlightSpeedORHi.IsHappened() || checkerFlightSpeedORLo.IsHappened()) && sysDataModel.gTestSts == TestSts.ShamTest)
                        {
                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightFail);
                            sysDataModel.gEightSts = EightSts.EightFail;
                            break;
                        }
                        #endregion

                        #region 八字绕飞项目——判断八字是否完成
                        if (mPointIndex >= 9 && dis < sysDataModel.gTestParam.txtTestRadOffset)
                        {
                            mPointIndex = 0;
                            setTextInvoke(txtTimeLength, "000");
                            tools.SpeakVoiceNow("八字飞行完成", 1, 100);
                            appendResultInvoke("⚪ 八字飞行完成");
                            sysLog.Debug("eight status from {old} to {new}", sysDataModel.gEightSts, EightSts.EightPass);
                            sysDataModel.gEightSts = EightSts.EightPass;
                            break;
                        }
                        #endregion

                        break;
                    }
                case EightSts.EightFail:
                    {//失败
                        mPointIndex = 0;
                        break;
                    }
                case EightSts.EightPass:
                    {//成功
                        mPointIndex = 0;
                        break;
                    }
            }
        }
        #endregion



        #region 模拟考试重试
        /// <summary>
        /// 考试模式下，失败后尝试获取下一次考试机会
        /// </summary>
        private bool applyForRetryTest()
        {
            if (sysDataModel.gTestCount >= 2)
            {
                appendResultInvoke("╳ 模拟考试失败");
                tools.SpeakVoiceNow("模拟考试失败", 1, 100);
                realData.phiOffsetCnt = 0;
                setTextInvoke(txtTimeLength, "000");
                sysDataModel.gTestSts = TestSts.NotSelected;
                sysDataModel.gRotateSts = RotateSts.UnStart;
                sysDataModel.gEightSts = EightSts.UnStart;
                sysDataModel.gTestCount = 0;
                return false;
            }
            else
            {
                sysDataModel.gTestCount++;
                sysDataModel.gMaker = RouteColors.GetMarker(sysDataModel.gColorFlags[sysDataModel.gTestCount]);
                sysDataModel.gColor = RouteColors.GetColor(sysDataModel.gColorFlags[sysDataModel.gTestCount]);
                tools.SpeakVoiceNow("考试失败，还有" + (3 - sysDataModel.gTestCount).ToString() + "次机会", 1, 100);
                tools.SpeakVoiceAppend("请退出中心点，重新考试", 1, 100);
                appendResultInvoke("╳ 模拟考试失败,还有" + (3 - sysDataModel.gTestCount).ToString() + "次机会");
                realData.phiOffsetCnt = 0;
                setTextInvoke(txtTimeLength, "000");
                return true;
            }
        }
        #endregion



        #region 飞行高度不对提醒
        private void noticeBadHeight()
        {
            txtFlyHeight.FillColor = Color.OrangeRed;
            tools.SpeakVoice("飞行高度不对", 1, 100);
            if ((sysDataModel.ErrorFlag & ErrorFlag.BadHeight) != ErrorFlag.BadHeight)
            {
                sysDataModel.ErrorFlag |= ErrorFlag.BadHeight;
                appendResultInvoke("╳ 飞行高度不对");
            }
        }
        private void resetBadHeight()
        {
            sysDataModel.ErrorFlag &= ~ErrorFlag.BadHeight;
            txtFlyHeight.FillColor = Color.White;
        }
        #endregion



        #region 错误处理
        private sysErrorChecker checkerVOffsetOR;
        private sysErrorChecker checkerHOffsetOR;
        private sysErrorChecker checkerYawAngleOR;
        private sysErrorChecker checkerFlightSpeedORHi;
        private sysErrorChecker checkerFlightSpeedORLo;
        private sysErrorChecker checkerYawSpeedOR;
        private sysErrorChecker checkerYawSpeedORHi;
        private sysErrorChecker checkerYawSpeedORLo;
        private sysErrorAccum checkerYawAngleAccumOR;
        private void initChecker()
        {
            #region 垂直偏移异常处理
            checkerVOffsetOR = new sysErrorChecker(ErrorFlag.VOffsetOR, delegate (FlyDataModel flyData)
            {
                txtVOffset.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("垂直偏移过大", 1, 100);
                markViolationLocation("垂直偏移过大", flyData);
                appendResultInvoke("╳ 垂直偏移过大：垂直偏移 " + StrFmt.strF00(sysDataModel.flyData.judge.vOffset) + "米");
            }, delegate
            {
                tools.SpeakVoice("垂直偏移过大", 1, 100);
            });
            #endregion

            #region 水平偏移异常处理
            checkerHOffsetOR = new sysErrorChecker(ErrorFlag.HOffsetOR, delegate (FlyDataModel flyData)
            {
                txtHOffset.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("水平偏移过大", 1, 100);
                markViolationLocation("水平偏移过大", flyData);
                appendResultInvoke("╳ 水平偏移过大：水平偏移 " + StrFmt.strF00(sysDataModel.flyData.judge.hOffset) + "米");
            }, delegate
            {
                tools.SpeakVoice("水平偏移过大", 1, 100);
            });
            #endregion

            #region 航向角度异常处理
            checkerYawAngleOR = new sysErrorChecker(ErrorFlag.YawAngleOR, delegate (FlyDataModel flyData)
            {
                txtPhiOffset.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("航向偏移过大", 1, 100);
                markViolationLocation("航向偏移过大", flyData);
                appendResultInvoke("╳ 航向偏移过大：航向偏移 " + StrFmt.strF00(sysDataModel.flyData.judge.angleOffset) + "°");
            }, delegate
            {
                tools.SpeakVoice("航向偏移过大", 1, 100);
            });
            #endregion

            #region 航向角度统计错误
            checkerYawAngleAccumOR = new sysErrorAccum(ErrorFlag.YawAngleAccumOR, delegate (FlyDataModel flyData)
            {
                txtPhiOffset.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("航向统计错误", 1, 100);
                markViolationLocation("航向统计错误", flyData);
                appendResultInvoke("╳ 航向统计错误");
            }, delegate { });
            #endregion

            #region 飞行速度异常处理
            checkerFlightSpeedORHi = new sysErrorChecker(ErrorFlag.FlightSpeedOR, delegate (FlyDataModel flyData)
            {
                txtSpeed.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("飞行速度过快", 1, 100);
                markViolationLocation("飞行速度过快", flyData);
                appendResultInvoke("╳ 飞行速度过快：飞行速度 " + StrFmt.strF00(sysDataModel.flyData.judge.flightSpeed) + "米");
            }, delegate
            {
                tools.SpeakVoice("飞行速度过快", 1, 100);
            });
            checkerFlightSpeedORLo = new sysErrorChecker(ErrorFlag.FlightSpeedOR, delegate (FlyDataModel flyData)
            {
                txtSpeed.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("飞行速度过慢", 1, 100);
                markViolationLocation("飞行速度过慢", flyData);
                appendResultInvoke("╳ 飞行速度过慢：飞行速度 " + StrFmt.strF00(sysDataModel.flyData.judge.flightSpeed) + "米");
            }, delegate
            {
                tools.SpeakVoice("飞行速度过慢", 1, 100);
            });
            #endregion

            #region 角速度异常处理
            checkerYawSpeedOR = new sysErrorChecker(ErrorFlag.YawSpeedOR, delegate (FlyDataModel flyData)
            {
                txtSpeed.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("角速度过小,航向停止", 1, 100);
                markViolationLocation("角速度过小,航向停止", flyData);
                appendResultInvoke("╳ 角速度过小,航向停止：错误角速度 " + StrFmt.strF00(sysDataModel.flyData.judge.yawSpeed) + "米");
            }, delegate
            {
                tools.SpeakVoice("角速度过小,航向停止", 1, 100);
            });
            checkerYawSpeedORHi = new sysErrorChecker(ErrorFlag.YawSpeedOR, delegate (FlyDataModel flyData)
            {
                txtAngleSpeed.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("角速度过大", 1, 100);
                markViolationLocation("角速度过大", flyData);
                appendResultInvoke("╳ 角速度过大：角速度 " + StrFmt.strF00(sysDataModel.flyData.judge.yawSpeed) + "米");
            }, delegate
            {
                tools.SpeakVoice("角速度过大", 1, 100);
            });
            checkerYawSpeedORLo = new sysErrorChecker(ErrorFlag.YawSpeedOR, delegate (FlyDataModel flyData)
            {
                txtAngleSpeed.FillColor = Color.OrangeRed;
                tools.SpeakVoiceNow("角速度过小", 1, 100);
                markViolationLocation("角速度过小", flyData);
                appendResultInvoke("╳ 角速度过小：角速度 " + StrFmt.strF00(sysDataModel.flyData.judge.yawSpeed) + "米");
            }, delegate
            {
                tools.SpeakVoice("角速度过小", 1, 100);
            });
            #endregion
        }
        #endregion



        #region 标记违规点、清除违规点
        private void markViolationLocation(string toolTipText, FlyDataModel flyDataModel)
        {
            sysLog.Debug("标记违规点：{lat},{lng}，原因：{reason}", flyDataModel.origin.Latitude, flyDataModel.origin.Longtitude, toolTipText);
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(flyDataModel.origin.Latitude, flyDataModel.origin.Longtitude), sysDataModel.gMaker);
            marker.ToolTipText = toolTipText;
            GMapManager.ViolationOverlay.Markers.Add(marker);
        }
        private void clearViolationMarks()
        {
            GMapManager.ViolationOverlay.Markers.Clear();
            txtVOffset.FillColor = Color.White;
            txtHOffset.FillColor = Color.White;
            txtPhiOffset.FillColor = Color.White;
            txtSpeed.FillColor = Color.White;
            txtAngleSpeed.FillColor = Color.White;
        }
        #endregion



        #region 更新场地参数
        /// <summary>
        /// 显示场地参数
        /// </summary>
        private void ShowGroundParam()
        {
            string[] strRets = new string[9];
            int index = listGround.SelectedIndex;
            if (index < 0) return;
            //获得当前选中的数据
            txtGroundName.Text = listGround.GetItemText(listGround.Items[index]);
            //更新地图上的场地名称
            btnRotate.Visible = true;
            labGroundName.Text = txtGroundName.Text;
            labGroundName.Visible = true;
            //从数据库获得训练场数据
            strRets = sysDataModel.gDataBase.queryGroundInfo(txtGroundName.Text);
            //显示训练场数据
            txtGroundName.Text = strRets[0];
            txtCenterLng.Text = strRets[1];
            txtCenterLat.Text = strRets[2];
            txtLeftLng.Text = strRets[3];
            txtLeftLat.Text = strRets[4];
            txtRightLng.Text = strRets[5];
            txtRightLat.Text = strRets[6];
            txtCenterRad.Text = strRets[7];
            txtRightRad.Text = strRets[8];


            // 设置全局中心点、左圆心、右圆心
            sysDataModel.gCenterPoint = new PointLatLng(double.Parse(txtCenterLat.Text), double.Parse(txtCenterLng.Text));
            sysDataModel.gLeftPoint = new PointLatLng(double.Parse(txtLeftLat.Text), double.Parse(txtLeftLng.Text));
            sysDataModel.gRightPoint = new PointLatLng(double.Parse(txtRightLat.Text), double.Parse(txtRightLng.Text));
            sysDataModel.gEightRadius = 6;
            float.TryParse(txtRightRad.Text, out sysDataModel.gEightRadius);
        }
        /// <summary>
        /// 更新场地图形
        /// </summary>
        private void UpdatePlayGround()
        {
            GMapManager.GroundLayout.CentePoint = sysDataModel.gCenterPoint;
            GMapManager.GroundLayout.LeftPoint = sysDataModel.gLeftPoint;
            GMapManager.GroundLayout.RightPoint = sysDataModel.gRightPoint;
            GMapManager.GroundLayout.EightRadius = sysDataModel.gEightRadius;

            GMapManager.GroundLayout.CenterRadius = (float)sysDataModel.gTestParam.txtTestRadOffset;
            GMapManager.GroundLayout.EightOffset = (float)sysDataModel.gTestParam.txtEightHOffset;
            GMapManager.GroundLayout.UpdateCircleStyle();
            GMapManager.GroundLayout.IsVisibile = true;
        }
        #endregion



        #region 场地管理界面事件处理
        /// <summary>
        /// 设置机构名称
        /// </summary>
        private void btnCompanyName_Click(object sender, EventArgs e)
        {
            //存入数据库：yuneec
            //表名：table_company
            //列名：CompanyName
            //特殊要求，只有一条记录
            sysDataModel.gDataBase.setCompanyInfo(txtCompanyName.Text);
            UINotifierHelper.ShowNotifier("设置机构名称成功！", UINotifierType.INFO, UILocalize.InfoTitle, true, 10000);
        }
        /// <summary>
        /// 训练场地列表
        /// 选择记录，显示选中记录
        /// </summary>
        private void listGround_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 显示当前选中的场地参数
            this.ShowGroundParam();
            // 更新场地显示
            this.UpdatePlayGround(); // 切换训练场地时

            //地图中心点设置，便于可视
            GMapManager.gMapControl.Position = GMapManager.GroundLayout.CentePoint;
            //地图放大级别18级
            if (GMapManager.gMapControl.Zoom < 18) GMapManager.gMapControl.Zoom = 18;

            //地图上显示训练场
            //绘制中心圆
            //drawCenterCircle(txtCenterLng.Text, txtCenterLat.Text, txtCenterRad.Text);
            //绘制8字圆
            //drawEightCircle(txtCenterLng.Text, txtCenterLat.Text, txtLeftLng.Text, txtLeftLat.Text, txtRightLng.Text, txtRightLat.Text, txtRightRad.Text,18.0,false);

        }
        /// <summary>
        /// 添加训练场
        /// </summary>
        private void btnAddGround_Click(object sender, EventArgs e)
        {
            txtGroundName.Text = "";
            txtGroundName.Enabled = true;
            txtCenterLng.Enabled = true;
            txtCenterLng.Text = "";
            txtCenterLat.Enabled = true;
            txtCenterLat.Text = "";
            txtCenterRad.Enabled = true;
            txtCenterRad.Text = "1";
            txtCenterAngle.Enabled = true;
            txtCenterAngle.Text = "";
            txtLeftLng.Enabled = true;
            txtLeftLng.Text = "";
            txtLeftLat.Enabled = true;
            txtLeftLat.Text = "";
            txtRightLng.Enabled = true;
            txtRightLng.Text = "";
            txtRightLat.Enabled = true;
            txtRightLat.Text = "";
            txtRightRad.Enabled = true;
            txtRightRad.Text = "6";
            btnCenterEnter.Enabled = true;
            btnOneEightDraw.Enabled = false;
            btnEightEnter.Enabled = false;
            btnEightClear.Enabled = true;
            btnGroundSave.Enabled = false;
            btnGroundCancel.Enabled = true;
            
            listGround.Enabled = false;
            btnAddGround.Enabled = false;
            btnEditGround.Enabled = false;
            btnDeleteGround.Enabled = false;
        }
        /// <summary>
        /// 修改训练场
        /// </summary>
        private void btnEditGround_Click(object sender, EventArgs e)
        {
            txtGroundName.Enabled = false;
            txtCenterLng.Enabled = true;
            txtCenterLat.Enabled = true;
            txtCenterRad.Enabled = true;
            txtCenterAngle.Enabled = true;
            txtLeftLng.Enabled = true;
            txtLeftLat.Enabled = true;
            txtRightLng.Enabled = true;
            txtRightLat.Enabled = true;
            txtRightRad.Enabled = true;
            btnCenterEnter.Enabled = true;
            btnOneEightDraw.Enabled = true;
            btnEightEnter.Enabled = false;
            btnEightClear.Enabled = true;
            btnGroundSave.Enabled = false;
            btnGroundCancel.Enabled = true;

            listGround.Enabled = false;
            btnAddGround.Enabled = false;
            btnEditGround.Enabled = false;
            btnDeleteGround.Enabled = false;
        }
        /// <summary>
        /// 删除训练场
        /// </summary>
        private void btnDeleteGround_Click(object sender, EventArgs e)
        {
            if (txtGroundName.Text == "")
            {
                UINotifierHelper.ShowNotifier("训练场名称不能空", UINotifierType.ERROR, UILocalize.ErrorTitle, true, 10000);
                return;
            }
            sysDataModel.gDataBase.deleteGroundInfo(txtGroundName.Text);
            if (sysDataModel.gDataBase.dbErrorMsg == "")
            {
                var delIndex = listGround.SelectedIndex;
                listGround.Items.RemoveAt(delIndex);
                listGround.SelectedIndex = listGround.Items.Count > 0 ? delIndex > 0 ? delIndex - 1 : 0 : -1;
                UINotifierHelper.ShowNotifier("删除成功！", UINotifierType.INFO, UILocalize.InfoTitle, true, 10000);
            }
            else
            {
                UINotifierHelper.ShowNotifier("删除失败!" + sysDataModel.gDataBase.dbErrorMsg, UINotifierType.ERROR, UILocalize.ErrorTitle, true, 20000);
            }
        }
        /// <summary>
        /// 采集中心点按钮
        /// 当前无人机的经纬度，添入中心点
        /// </summary>
        private void btnCenterEnter_Click(object sender, EventArgs e)
        {
            txtCenterLng.Text = string.Format("{0:0.00000000}", sysDataModel.Longtitude);
            txtCenterLat.Text = string.Format("{0:0.00000000}", sysDataModel.Latitude);

            //中心点经度\经度\半径
            //drawCenterCircle(txtCenterLng.Text, txtCenterLat.Text, txtCenterRad.Text);

            // 设置场地中心点
            sysDataModel.gCenterPoint = new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude);
            GMapManager.gMapControl.Position = sysDataModel.gCenterPoint;

            txtCenterAngle.Text = string.Format("{0:0.00000000}", sysDataModel.YawAngle);

            // 地图放大级别18级
            if (GMapManager.gMapControl.Zoom < 18) GMapManager.gMapControl.Zoom = 18;

            btnEightEnter.Enabled = true;
            btnOneEightDraw.Enabled = true;
        }
        /// <summary>
        /// 确认8字按钮
        /// 当前无人机的经纬度，添入左圆心
        /// </summary>
        private void btnEightEnter_Click(object sender, EventArgs e)
        {
            txtLeftLng.Text = string.Format("{0:0.00000000}", sysDataModel.Longtitude);
            txtLeftLat.Text = string.Format("{0:0.00000000}", sysDataModel.Latitude);

            sysDataModel.gLeftPoint = new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude);

            double angle = Calculate.GetAzimuth(sysDataModel.gCenterPoint, sysDataModel.gLeftPoint);
            txtCenterAngle.Text = string.Format("{0:0.00000000}", angle);
            btnOneEightDraw.Enabled = true;
        }
        /// <summary>
        /// 一键生成
        /// 只需输入中心点坐标，就可一键生成中心圆和8字圆
        /// </summary>
        private void btnOneEightDraw_Click(object sender, EventArgs e)
        {
            float rad = 0;
            if (!float.TryParse(txtRightRad.Text, out rad))
            {
                UINotifierHelper.ShowNotifier("未输入八字半径", UINotifierType.ERROR, UILocalize.InfoTitle, true, 10000);
                return;
            }

            btnOneEightDraw.Enabled = false;
            //中心点+角度 生成8字
            if (txtCenterAngle.Text != "")
            {
                if (txtCenterLng.Text != "" && txtCenterLat.Text != "")
                {
                    double lng = double.Parse(txtCenterLng.Text.Trim());
                    double lat = double.Parse(txtCenterLat.Text.Trim());
                    double angle = double.Parse(txtCenterAngle.Text.Trim());

                    //自动生成8字，两圆心的坐标
                    CustomLatLng left = Calculate.getAngleLatLng(new CustomLatLng(lng, lat), 6, angle);
                    sysDataModel.gLeftPoint = new PointLatLng(left.m_lat, left.m_lng);
                    txtLeftLng.Text = string.Format("{0:0.00000000}", left.m_lng);
                    txtLeftLat.Text = string.Format("{0:0.00000000}", left.m_lat);
                    CustomLatLng right = Calculate.getAngleLatLng(new CustomLatLng(lng, lat), 6, angle + 180);
                    sysDataModel.gRightPoint = new PointLatLng(right.m_lat, right.m_lng);
                    txtRightLng.Text = string.Format("{0:0.00000000}", right.m_lng);
                    txtRightLat.Text = string.Format("{0:0.00000000}", right.m_lat);
                    btnGroundSave.Enabled = true;
                }
            }
            else//中心点+左圆心 生成8字
            if (txtCenterLng.Text != "" && txtCenterLat.Text != "" &&
               txtLeftLng.Text != "" && txtLeftLat.Text != "" &&
               txtRightLng.Text != "" && txtRightLat.Text != "")
            {
                //中心点+左圆心 生成8字
                double lng = double.Parse(txtCenterLng.Text.Trim());
                double lat = double.Parse(txtCenterLat.Text.Trim());
                double leftlng = double.Parse(txtLeftLng.Text.Trim());
                double leftlat = double.Parse(txtLeftLat.Text.Trim());

                //自动生成8字，两圆心的坐标 todo:最好不要修改定位点的经纬度坐标
                double angle = Calculate.GetAzimuth(new PointLatLng(lat, lng), new PointLatLng(leftlat, leftlng));
                CustomLatLng left = Calculate.getAngleLatLng(new CustomLatLng(lng, lat), 6, angle);
                sysDataModel.gLeftPoint = new PointLatLng(left.m_lat, left.m_lng);
                txtLeftLng.Text = string.Format("{0:0.00000000}", left.m_lng);
                txtLeftLat.Text = string.Format("{0:0.00000000}", left.m_lat);
                CustomLatLng right = Calculate.getAngleLatLng(new CustomLatLng(lng, lat), 6, angle + 180);
                sysDataModel.gRightPoint = new PointLatLng(right.m_lat, right.m_lng);
                txtRightLng.Text = string.Format("{0:0.00000000}", right.m_lng);
                txtRightLat.Text = string.Format("{0:0.00000000}", right.m_lat);
                btnGroundSave.Enabled = true;
            }
            else
            {

            }

            // 更新场地显示
            this.UpdatePlayGround(); // 新建训练场地，一键生成场地时

            //地图中心点设置，便于可视
            GMapManager.gMapControl.Position = GMapManager.GroundLayout.CentePoint;
            //地图放大级别22级
            GMapManager.gMapControl.Zoom = 22;
            //绘制中心圆
            // drawCenterCircle(txtCenterLng.Text, txtCenterLat.Text, txtCenterRad.Text);
            //绘制8字圆
            // drawEightCircle(txtCenterLng.Text, txtCenterLat.Text, txtLeftLng.Text, txtLeftLat.Text, txtRightLng.Text, txtRightLat.Text, txtRightRad.Text, 18.0, false);
        }
        /// <summary>
        /// 清除8字按钮
        /// 清除中心圆
        /// 清除左右各3各圆圈
        /// 清除左右各4各桩点圆圈
        /// </summary>
        private void btnEightClear_Click(object sender, EventArgs e)
        {
            // 隐藏场地图层
            GMapManager.GroundLayout.IsVisibile = false;
            btnOneEightDraw.Enabled = true;
        }
        /// <summary>
        /// 保存训练场
        /// </summary>
        private void btnGroundSave_Click(object sender, EventArgs e)
        {
            if(txtGroundName.Text == "")
            {
                UINotifierHelper.ShowNotifier("训练场名称不能空", UINotifierType.ERROR, UILocalize.ErrorTitle, true, 10000);
                return;
            }

            if (txtGroundName.Enabled == false)
            {
                //保存修改当前训练场数据
                sysDataModel.gDataBase.updateGroundInfo(
                    txtGroundName.Text,
                    txtCenterLng.Text,
                    txtCenterLat.Text,
                    txtLeftLng.Text,
                    txtLeftLat.Text,
                    txtRightLng.Text,
                    txtRightLat.Text,
                    txtCenterRad.Text,
                    txtRightRad.Text);

                if (sysDataModel.gDataBase.dbErrorMsg == "")
                {
                    UINotifierHelper.ShowNotifier("修改成功！", UINotifierType.INFO, UILocalize.InfoTitle, true, 10000);
                }
                else
                {
                    UINotifierHelper.ShowNotifier("修改失败!" + sysDataModel.gDataBase.dbErrorMsg, UINotifierType.ERROR, UILocalize.ErrorTitle, true, 20000);
                    return;
                }
            }
            else
            {
                //保存新训练场数据到数据库
                sysDataModel.gDataBase.insertGroundInfo(
                    txtGroundName.Text,
                    txtCenterLng.Text,
                    txtCenterLat.Text,
                    txtLeftLng.Text,
                    txtLeftLat.Text,
                    txtRightLng.Text,
                    txtRightLat.Text,
                    txtCenterRad.Text,
                    txtRightRad.Text);

                if (sysDataModel.gDataBase.dbErrorMsg == "")
                {
                    UINotifierHelper.ShowNotifier("添加成功！", UINotifierType.INFO, UILocalize.InfoTitle, true, 10000);
                }
                else
                {
                    UINotifierHelper.ShowNotifier("添加失败! 训练场名称已存在!", UINotifierType.ERROR, UILocalize.ErrorTitle, true, 20000);
                    goto END;
                }
            }

            //重新加载训练场地名称列表
            listGround.Items.Clear();
            string[] strGroundName = sysDataModel.gDataBase.getGroundNameList();
            for (int i = 0; i < strGroundName.Length; i++)
            {
                if (strGroundName[i] == "")
                {
                    break;
                }
                listGround.Items.Add(strGroundName[i]);
            }

        END:
            txtGroundName.Enabled = false;
            txtCenterLng.Enabled = false;
            txtCenterLat.Enabled = false;
            txtCenterRad.Enabled = false;
            txtCenterAngle.Enabled = false;
            txtLeftLng.Enabled = false;
            txtLeftLat.Enabled = false;
            txtRightLng.Enabled = false;
            txtRightLat.Enabled = false;
            txtRightRad.Enabled = false;
            btnCenterEnter.Enabled = false;
            btnOneEightDraw.Enabled = false;
            btnEightEnter.Enabled = false;
            btnEightClear.Enabled = false;
            btnGroundSave.Enabled = false;
            btnGroundCancel.Enabled = false;

            listGround.Enabled = true;
            btnAddGround.Enabled = true;
            btnEditGround.Enabled = true;
            btnDeleteGround.Enabled = true;
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        private void btnGroundCancel_Click(object sender, EventArgs e)
        {
            txtGroundName.Enabled = false;
            txtCenterLng.Enabled = false;
            txtCenterLat.Enabled = false;
            txtCenterRad.Enabled = false;
            txtCenterAngle.Enabled = false;
            txtLeftLng.Enabled = false;
            txtLeftLat.Enabled = false;
            txtRightLng.Enabled = false;
            txtRightLat.Enabled = false;
            txtRightRad.Enabled = false;
            btnCenterEnter.Enabled = false;
            btnOneEightDraw.Enabled = false;
            btnEightEnter.Enabled = false;
            btnEightClear.Enabled = false;
            btnGroundSave.Enabled = false;
            btnGroundCancel.Enabled = false;

            listGround.Enabled = true;
            btnAddGround.Enabled = true;
            btnEditGround.Enabled = true;
            btnDeleteGround.Enabled = true;

            // 显示当前选中的场地参数
            this.ShowGroundParam();
        }
        #endregion



        /// <summary>
        /// 飞行视角和正北视角
        /// </summary>
        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (listGround.SelectedIndex < 0)
            {
                UINotifierHelper.ShowNotifier("错误!请选择训练场地", UINotifierType.ERROR, UILocalize.ErrorTitle, true, 20000);
                return;
            }
            if (btnRotate.Text == "飞行视角")
            {
                PointLatLng tmpPoint = new PointLatLng(GMapManager.GroundLayout.LeftPoint.Lat + 20, GMapManager.GroundLayout.LeftPoint.Lng);
                double angle = TestTools.GetAngle(GMapManager.GroundLayout.LeftPoint, tmpPoint, GMapManager.GroundLayout.RightPoint);
                angle -= 90.0;
                GMapManager.gMapControl.Bearing = (float)angle;

                btnRotate.Text = "正北视角";
            }
            else
            if (btnRotate.Text == "正北视角")
            {
                btnRotate.Text = "飞行视角";
                GMapManager.gMapControl.Bearing = (float)0.0;
            }
        }

        /// <summary>
        /// 初始化GMapManager对象
        /// </summary>
        private void initGMapManager()
        {
            //离线地图数据加载
            this.gMapControl.Manager.Mode = AccessMode.CacheOnly;
            GMaps.Instance.ImportFromGMDB(Application.StartupPath + "\\GMapCache\\");

            //设置地图建在模式为：服务器和本地
            this.gMapControl.Manager.Mode = AccessMode.ServerAndCache;

            //设置地图数据本地缓存目录
            this.gMapControl.CacheLocation = Application.StartupPath + "\\GMapCache\\";
            this.gMapControl.MinZoom = 1;
            this.gMapControl.MaxZoom = 22;
            this.gMapControl.Zoom = 12.0;
            this.gMapControl.ShowCenter = true;

            //设置左键拖曳地图
            this.gMapControl.DragButton = MouseButtons.Left;
            this.gMapControl.SetPositionByKeywords("苏州");

            //GMAP控件中，添加覆盖对象
            this.gMapControl.Overlays.Add(GMapManager.GroundLayout); // 训练场地图层
            this.gMapControl.Overlays.Add(GMapManager.flytransOverlay2);
            this.gMapControl.Overlays.Add(GMapManager.flybackOverlay);
            this.gMapControl.Overlays.Add(GMapManager.flytransOverlay);
            this.gMapControl.Overlays.Add(GMapManager.TestSysOverlay);
            this.gMapControl.Overlays.Add(GMapManager.NoFlyArea);
            this.gMapControl.Overlays.Add(GMapManager.ViolationOverlay);

            this.gMapControl.Overlays.Add(GMapManager.MapScaleLayout); // 地图缩放图层，最顶层

            //添加六个覆盖对象，暂时用不上
            for (int i = 0; i < GMapManager.markersOverlay.Length; i++)
            {
                GMapManager.markersOverlay[i] = new GMapOverlay("gps" + i.ToString());
                this.gMapControl.Overlays.Add(GMapManager.markersOverlay[i]);
            }

            //添加无人机图标，支持最多六个无人机-------------------------------
            //无人机图标
            Bitmap bmp = (Bitmap)MyImageTools.resizeImage(MyImageTools.imagePlane2, new Size(30, 30));
            //图标在地图上的经纬度
            PointLatLng tmpoint = new PointLatLng(double.Parse(this.txtCenterLat.Text.Trim()), double.Parse(this.txtCenterLng.Text.Trim()));
            for (int j = 0; j < sysFunction.flytransmarker.Length; j++)
            {
                sysFunction.flytransmarker[j] = new GMapMarkerImage(tmpoint, bmp, 0);
                GMapManager.flytransOverlay.Markers.Add(sysFunction.flytransmarker[j]);
                sysFunction.flytransmarker[j].IsVisible = false;
            }

            //当前地面站位置显示+图标，重要
            //使用无人机图片
            tmpoint = new PointLatLng(double.Parse(this.txtCenterLat.Text.Trim()), double.Parse(this.txtCenterLng.Text.Trim()));
            GMapManager.LocationMarker = new GMapMarkerImage(tmpoint, bmp, 0);
            GMapManager.LocationMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            GMapManager.flybackOverlay.Markers.Add(GMapManager.LocationMarker);
            GMapManager.LocationMarker.IsVisible = false;

            //自旋中心外圆，重要 外圆比内圆半径+1米
            tmpoint = new PointLatLng(0.0, 0.0);
            GMapManager.RevolveOutsideCircle = new GMapMarkerCircle(tmpoint, "", 1f, Color.OrangeRed, Color.LightGreen,0);
            GMapManager.RevolveOutsideCircle.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            GMapManager.RevolveOutsideCircle.ToolTipText = string.Format("自旋范围圆", new object[0]);
            GMapManager.TestSysOverlay.Markers.Add(GMapManager.RevolveOutsideCircle);
            GMapManager.RevolveOutsideCircle.IsVisible = false;

            //自旋中心内圆，重要
            tmpoint = new PointLatLng(0.0, 0.0);
            GMapManager.RevolveMidCircle = new GMapMarkerCircle(tmpoint, "", 1f, Color.OrangeRed, Color.LightGreen,0);
            GMapManager.RevolveMidCircle.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            GMapManager.TestSysOverlay.Markers.Add(GMapManager.RevolveMidCircle);
            GMapManager.RevolveMidCircle.IsVisible = false;

            //自旋 无人机1米圆，重要
            tmpoint = new PointLatLng(0.0, 0.0);
            GMapManager.RevolveFlyCircle = new GMapMarkerCircle(tmpoint, "", 1f, Color.DodgerBlue, Color.LightGreen, 0,1);
            GMapManager.RevolveFlyCircle.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            GMapManager.TestSysOverlay.Markers.Add(GMapManager.RevolveFlyCircle);
            GMapManager.RevolveFlyCircle.IsVisible = false;

            //8字中心点圆圈，重要
            tmpoint = new PointLatLng(0.0, 0.0);
            GMapManager.EightMidCircle = new GMapMarkerCircle(tmpoint, "", 1f, Color.OrangeRed, Color.LightGreen,0);
            GMapManager.EightMidCircle.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            GMapManager.TestSysOverlay.Markers.Add(GMapManager.EightMidCircle);
            GMapManager.EightMidCircle.IsVisible = false;

            //8字6个圆圈，左右各3个，分别为直径16，12，8重要
            for (int n = 0; n < 3; n++)
            {
                //左侧3个圆
                GMapManager.EightCircle[n] = new GMapMarkerCircle(tmpoint,"", 4f, Color.Black, Color.LightGreen,128);
                GMapManager.EightCircle[n].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                GMapManager.TestSysOverlay.Markers.Add(GMapManager.EightCircle[n]);
                GMapManager.EightCircle[n].IsVisible = false;
            }
            for (int n = 3; n < 6; n++)
            {
                //右侧3个圆
                GMapManager.EightCircle[n] = new GMapMarkerCircle(tmpoint, "", 4f, Color.Red, Color.LightGreen, 128);
                GMapManager.EightCircle[n].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                GMapManager.TestSysOverlay.Markers.Add(GMapManager.EightCircle[n]);
                GMapManager.EightCircle[n].IsVisible = false;
            }

            //左圆的圆心
            GMapManager.EightCircle[6] = new GMapMarkerCircle(tmpoint, "", 4f, Color.OrangeRed, Color.LightGreen, 128);
            GMapManager.EightCircle[6].ToolTipMode = MarkerTooltipMode.OnMouseOver;
            GMapManager.TestSysOverlay.Markers.Add(GMapManager.EightCircle[6]);
            GMapManager.EightCircle[6].IsVisible = false;

            //右圆的圆心
            GMapManager.EightCircle[7] = new GMapMarkerCircle(tmpoint, "", 4f, Color.OrangeRed, Color.LightGreen, 128);
            GMapManager.EightCircle[7].ToolTipMode = MarkerTooltipMode.OnMouseOver;
            GMapManager.TestSysOverlay.Markers.Add(GMapManager.EightCircle[7]);
            GMapManager.EightCircle[7].IsVisible = false;

            GMapManager.EightCircle[2].Stroke.DashStyle = DashStyle.Solid;
            GMapManager.EightCircle[5].Stroke.DashStyle = DashStyle.Solid;

            //8字8个桩点，左右各4个
            for (int i2 = 0; i2 < 8; i2++)
            {
                GMapManager.EightYawPoint[i2] = new GMapMarkerCircle(tmpoint,  "", 0.5f, Color.DodgerBlue, Color.LightGreen,0);
                GMapManager.EightYawPoint[i2].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                GMapManager.TestSysOverlay.Markers.Add(GMapManager.EightYawPoint[i2]);
                GMapManager.EightYawPoint[i2].IsVisible = false;
            }
        }

        /// <summary>
        /// 初始化训练数据
        /// 数据库中的数据显示到画面
        /// </summary>
        private void initTestData()
        {
            //全局变量初始化
            sysDataModel.gCenterPoint = new PointLatLng(0.0, 0.0);
            sysDataModel.gLeftPoint   = new PointLatLng(0.0, 0.0);
            sysDataModel.gRightPoint  = new PointLatLng(0.0, 0.0);
            sysDataModel.gEightRadius = 6;

            //训练场地管理
            //训练机构名称
            txtCompanyName.Text = sysDataModel.gDataBase.getCompanyInfo();
            //地图组件上的场地名称
            btnRotate.Visible = false;
            //地图组件上的场地名称
            labGroundName.Visible = false;
            //训练场地名称列表
            listGround.Items.Clear();
            string[] strGroundName = sysDataModel.gDataBase.getGroundNameList();
            for (int i = 0;i< strGroundName.Length;i++)
            {
                if(strGroundName[i] == "")
                {
                    break;
                }
                listGround.Items.Add(strGroundName[i]);
            }

            //训练参数管理

            //系统配置

            //相关控件不可用
            txtGroundName.Enabled = false;
            txtCenterLng.Enabled = false;
            txtCenterLat.Enabled = false;
            txtCenterRad.Enabled = false;
            txtCenterAngle.Enabled = false;
            txtLeftLng.Enabled = false;
            txtLeftLat.Enabled = false;
            txtRightLng.Enabled = false;
            txtRightLat.Enabled = false;
            txtRightRad.Enabled = false;
            btnCenterEnter.Enabled = false;
            btnOneEightDraw.Enabled = false;
            btnEightEnter.Enabled = false;
            btnEightClear.Enabled = false;
            btnGroundSave.Enabled = false;
            btnGroundCancel.Enabled = false;
        }

        /// <summary>
        /// 绘制自旋中心点
        /// 绘制自旋中圈
        /// 绘制自旋外圈
        /// </summary>
        private void drawCenterCircle(string mLng, string mLat, string mrad)
        {
            //中心点经度
            double lng = double.Parse(mLng.Trim());

            //中心点纬度
            double lat = double.Parse(mLat.Trim());

            //中圈圆心位置
            GMapManager.RevolveMidCircle.Position = new PointLatLng(lat, lng);
            sysDataModel.gCenterPoint = new PointLatLng(lat, lng);

            //中圈半径
            GMapManager.RevolveMidCircle.Radius = float.Parse(mrad.Trim());

            //GMapManager.RevolveMidCircle.
            //显示中圈
            GMapManager.RevolveMidCircle.IsVisible = true;

            //外圈圆心位置
            GMapManager.RevolveOutsideCircle.Position = new PointLatLng(lat, lng);

            //外圈半径
            GMapManager.RevolveOutsideCircle.Radius = float.Parse(mrad) + 1;

            //显示外圈
            GMapManager.RevolveOutsideCircle.IsVisible = true;

            //地图中心点设置，便于可视
            GMapManager.gMapControl.Position = new PointLatLng(lat, lng);

            //地图放大级别22级
            GMapManager.gMapControl.Zoom = 18;
        }

        /// <summary>
        /// 确认8字按钮
        /// 绘制8字内圈 lng1,lat1
        /// 绘制8字中圈 lng0,lat0 rad
        /// 绘制8字外圈 lng2,lat2
        /// 绘制8各桩点
        /// level:地图放大级别，17.0 22.0
        /// flag:地图是否旋转
        /// </summary>
        private void drawEightCircle(string lng0, string lat0, string lng1, string lat1, string lng2, string lat2, string rad, double level, bool rotate_flag)
        {
            float CircleR = 0f;
            PointLatLng center = default(PointLatLng);
            PointLatLng left = default(PointLatLng);
            PointLatLng right = default(PointLatLng);

            try
            {
                //中心点坐标
                //经度
                center.Lng = double.Parse(lng0.Trim());
                //纬度
                center.Lat = double.Parse(lat0.Trim());

                //右圆心坐标
                right.Lng = double.Parse(lng2.Trim());
                right.Lat = double.Parse(lat2.Trim());
                sysDataModel.gRightPoint = new PointLatLng(right.Lat, right.Lng);

                //左圆心坐标
                left.Lng = double.Parse(lng1.Trim());
                left.Lat = double.Parse(lat1.Trim());
                sysDataModel.gLeftPoint = new PointLatLng(left.Lat, left.Lng);

                //半径
                float r = float.Parse(rad.Trim());

                CircleR = r;
                float subr = 2.0f; // 水平偏差2米
                //左内圆
                GMapManager.EightCircle[0].Position = left;
                GMapManager.EightCircle[0].Radius = r - subr;

                //左中圆
                GMapManager.EightCircle[2].Position = left;
                GMapManager.EightCircle[2].Radius = r;

                //左外圆
                GMapManager.EightCircle[1].Position = left;
                GMapManager.EightCircle[1].Radius = r + subr;

                //右内圆
                GMapManager.EightCircle[3].Position = right;
                GMapManager.EightCircle[3].Radius = r - subr;

                //右中圆
                GMapManager.EightCircle[5].Position = right;
                GMapManager.EightCircle[5].Radius = r;

                //右外圆
                GMapManager.EightCircle[4].Position = right;
                GMapManager.EightCircle[4].Radius = r + subr;

                //左圆心
                GMapManager.EightCircle[6].Position = left;
                GMapManager.EightCircle[6].Radius = 0.5f;

                //右圆心
                GMapManager.EightCircle[7].Position = right;
                GMapManager.EightCircle[7].Radius = 0.5f;

                eightCircleColorSet(-1, Color.Red);

                //左圆 外、中、内
                GMapManager.EightCircle[1].Fill = new SolidBrush(Color.FromArgb(0, Color.Yellow));
                GMapManager.EightCircle[2].Fill = new SolidBrush(Color.FromArgb(0, Color.DimGray));
                GMapManager.EightCircle[0].Fill = new SolidBrush(Color.FromArgb(0, Color.Black));

                //右圆
                GMapManager.EightCircle[4].Fill = new SolidBrush(Color.FromArgb(0, Color.LightBlue));
                GMapManager.EightCircle[5].Fill = new SolidBrush(Color.FromArgb(0, SystemColors.Window));
                GMapManager.EightCircle[3].Fill = new SolidBrush(Color.FromArgb(0, Color.LightGreen));

                //左圆心
                GMapManager.EightCircle[6].Fill = new SolidBrush(Color.FromArgb(255, Color.OrangeRed));

                //右圆心
                GMapManager.EightCircle[7].Fill = new SolidBrush(Color.FromArgb(0, Color.OrangeRed));

                for (int i = 0; i < GMapManager.EightCircle.Length; i++)
                {
                    GMapManager.EightCircle[i].IsVisible = true;
                }

                //人视角
                PointLatLng m = new PointLatLng(GMapManager.EightCircle[2].Position.Lat + 20, GMapManager.EightCircle[2].Position.Lng);
                double angle = TestTools.GetAngle(GMapManager.EightCircle[2].Position, m, GMapManager.EightCircle[5].Position);
                angle -= 90.0;

                //地图视角
                //double angle = Math.Atan2((GMapManager.EightCircle[5].Position.Lat - GMapManager.EightCircle[2].Position.Lat), (GMapManager.EightCircle[5].Position.Lng - GMapManager.EightCircle[2].Position.Lng)) * 180 / Math.PI;
                //angle = 0- angle;

                bool flag = sysDataModel.FlyCode > 0;
                double flyposai;
                if (flag)
                {
                    flyposai = (double)((float)sysFunction.flytransmarker[(int)(sysDataModel.FlyCode - 1)].Angle + GMapManager.gMapControl.Bearing);
                }
                else
                {
                    flyposai = (double)(0f + GMapManager.gMapControl.Bearing);
                }
                if (rotate_flag)
                {
                    GMapManager.gMapControl.Bearing = (float)angle;
                }

                //无人机图标随飞行轨迹转动
                bool flag2 = sysDataModel.FlyCode > 0;
                if (flag2)
                {
                    sysFunction.flytransmarker[(int)(sysDataModel.FlyCode - 1)].Angle = (int)(flyposai - (double)GMapManager.gMapControl.Bearing);
                    sysFunction.flytransmarker[(int)(sysDataModel.FlyCode - 1)].IsVisible = true;
                }
                else
                {
                    sysFunction.flytransmarker[0].Angle = (int)(flyposai - (double)GMapManager.gMapControl.Bearing);
                    sysFunction.flytransmarker[0].IsVisible = true;
                }

                //绘制8字圆的中心点
                PointLatLng[] plYawPoint;
                PointLatLng EightMidPoint = new PointLatLng((left.Lat + right.Lat) / 2.0, (left.Lng + right.Lng) / 2.0);
                GMapManager.gMapControl.Position = EightMidPoint;
                GMapManager.EightMidCircle.Position = new PointLatLng(EightMidPoint.Lat, EightMidPoint.Lng);
                GMapManager.EightMidCircle.IsVisible = false;

                //绘制8各桩点
                plYawPoint = TestTools.AB_Loc_Calcu(GMapManager.EightCircle[2].Position.Lng, GMapManager.EightCircle[2].Position.Lat, GMapManager.EightCircle[5].Position.Lng, GMapManager.EightCircle[5].Position.Lat, (double)GMapManager.EightCircle[2].Radius);
                for (int j = 0; j < 8; j++)
                {
                    GMapManager.EightYawPoint[j].Position = plYawPoint[j];
                    GMapManager.EightYawPoint[j].IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                sysLog.Error(ex, "绘制确认8字图形异常");
            }
        }

        /// <summary>
        /// 自旋、8字各圆圈的颜色设置
        /// </summary>
        public void eightCircleColorSet(int num, Color clr)
        {
            bool flag = num >= 0;
            if (flag)
            {
                GMapManager.EightCircle[num].Stroke = new Pen(clr, 2f);
            }
            switch (num)
            {
                case -1:
                    //左内圆
                    GMapManager.EightCircle[0].Stroke.Color = Color.DodgerBlue;

                    //左外圆
                    GMapManager.EightCircle[1].Stroke.Color = Color.DodgerBlue;

                    //左中圆
                    GMapManager.EightCircle[2].Stroke.Color = Color.OrangeRed;

                    //右内圆
                    GMapManager.EightCircle[3].Stroke.Color = Color.DodgerBlue;

                    //右外圆
                    GMapManager.EightCircle[4].Stroke.Color = Color.DodgerBlue;

                    //右中圆
                    GMapManager.EightCircle[5].Stroke.Color = Color.OrangeRed;
                    break;
                case 0:
                    GMapManager.EightCircle[1].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[2].Stroke.Color = Color.Yellow;
                    GMapManager.EightCircle[3].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[4].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[5].Stroke.Color = Color.Yellow;
                    break;
                case 1:
                    GMapManager.EightCircle[0].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[2].Stroke.Color = Color.Yellow;
                    GMapManager.EightCircle[3].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[4].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[5].Stroke.Color = Color.Yellow;
                    break;
                case 2:
                    GMapManager.EightCircle[0].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[1].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[3].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[4].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[5].Stroke.Color = Color.Yellow;
                    break;
                case 3:
                    GMapManager.EightCircle[0].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[1].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[2].Stroke.Color = Color.Yellow;
                    GMapManager.EightCircle[4].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[5].Stroke.Color = Color.Yellow;
                    break;
                case 4:
                    GMapManager.EightCircle[0].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[1].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[2].Stroke.Color = Color.Yellow;
                    GMapManager.EightCircle[3].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[5].Stroke.Color = Color.Yellow;
                    break;
                case 5:
                    GMapManager.EightCircle[0].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[1].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[2].Stroke.Color = Color.Yellow;
                    GMapManager.EightCircle[3].Stroke.Color = Color.Red;
                    GMapManager.EightCircle[4].Stroke.Color = Color.Red;
                    break;
            }
        }



        #region TAB页面切换
        /// <summary>
        /// 进入单次训练
        /// </summary>
        private void tabPageTestOne_Enter(object sender, EventArgs e)
        {
            if (tabPageTestOneFlag == false)
            {
                tabPageTestOneFlag = true;
                tabPageTestOne.Select();

                //加载数据库数据,训练参数
                sysDataModel.gTestParams = sysDataModel.gDataBase.getTestInfo();

                //控件状态初始化
                btnTestStart.Enabled = true;
                btnTestStop.Enabled = false;

                // 选择一个默认项目
                listTestType2.SelectedIndex = 0;
                listTestProject2.SelectedIndex = 0;

                //显示数据初始化
                txtVOffset.Text = "0.0";
                txtHOffset.Text = "0.0";
                txtPhiOffset.Text = "0.0";
                txtFlyHeight.Text = "0.0";
                txtSpeed.Text = "0.0";
                txtAngleSpeed.Text = "0.0";
                setTextInvoke(txtTimeLength, "000");

                labVOffset.Text = "0.0 - 0.0";
                labHOffset.Text = "0.0 - 0.0";
                labPhiOffset.Text = "0.0 - 0.0";
                labFlyHeight.Text = "0.0 - 0.0";
                labSpeed.Text = "0.0 - 0.0";
                labAngleSpeed.Text = "0.0 - 0.0";
                labTimeLength.Text = "0 - 360";
            }
        }
        #endregion

        #region 训练参数管理页面事件处理
        /// <summary>
        /// 进入训练参数管理画面
        /// </summary>
        private void tabPageTestParam_Enter(object sender, EventArgs e)
        {
            if(tabPageTestParamFlag == false)
            {
                tabPageTestParamFlag = true;
                tabPageTestParam.Select();

                //加载数据库数据,训练参数
                sysDataModel.gTestParams = sysDataModel.gDataBase.getTestInfo();

                //默认显示"教员"类型的训练参数
                listTestType.SetSelected(Convert.ToInt32(sysDataModel.gTestType), true);

                //加载画面数据
                displayTestInfo(0);

                enbaleTestInfo(false);

                btnCancel.Enabled = false;
                btnTestDataSave.Enabled = false;
            }
        }
        /// <summary>
        /// 离开训练参数管理画面
        /// </summary>
        private void tabPageTestParam_Leave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 训练类型列表，选中变化
        /// </summary>
        private void listTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //list当前选中的对象索引
            int index = listTestType.SelectedIndex;

            if (index < 0)
            {
                return;
            }
            sysDataModel.gTestType = (TestType)index;

            displayTestInfo(index);

            // 更新场地显示
            this.UpdatePlayGround(); // 训练参数页面切换训练类型时，更新场地绘图参数
        }
        /// <summary>
        /// 训练参数修改按钮
        /// </summary>
        private void btnTestDataEdit_Click(object sender, EventArgs e)
        {
            enbaleTestInfo(true);
            btnTestDataEdit.Enabled = false;
            btnCancel.Enabled = true;
            btnTestDataSave.Enabled = true;
        }
        /// <summary>
        /// 取消修改训练参数
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            enbaleTestInfo(false);
            btnTestDataEdit.Enabled = true;
            btnCancel.Enabled = false;
            btnTestDataSave.Enabled = false;
        }
        /// <summary>
        /// 训练参数保存按钮
        /// </summary>
        private void btnTestDataSave_Click(object sender, EventArgs e)
        {
            saveTestInfo(Convert.ToInt32(sysDataModel.gTestType));

            string strError = sysDataModel.gDataBase.updateTestInfo(sysDataModel.gTestParams[Convert.ToInt32(sysDataModel.gTestType)]);

            if (strError == "")
            {
                UINotifierHelper.ShowNotifier("参数保存成功！", UINotifierType.INFO, UILocalize.InfoTitle, true, 10000);
            }
            else
            {
                UINotifierHelper.ShowNotifier("参数保存失败!" + strError, UINotifierType.ERROR, UILocalize.ErrorTitle, true, 20000);
            }

            enbaleTestInfo(false);

            btnTestDataEdit.Enabled = true;
            btnCancel.Enabled = false;
            btnTestDataSave.Enabled = false;
        }
        #endregion

        #region 训练参数管理页面
        /// <summary>
        /// 画面上显示训练参数
        /// </summary>
        public void displayTestInfo(int index)
        {
            txtTestTimeout.Text = sysDataModel.gTestParams[index].txtTestTimeout.ToString();
            txtTestStartAngle.Text = sysDataModel.gTestParams[index].txtTestStartAngle.ToString();
            txtTestStartSpeed.Text = sysDataModel.gTestParams[index].txtTestStartSpeed.ToString();
            txtTestRadOffset.Text = sysDataModel.gTestParams[index].txtTestRadOffset.ToString();
            txtRotateVOffset.Text = sysDataModel.gTestParams[index].txtRotateVOffset.ToString();
            txtRotateHOffset.Text = sysDataModel.gTestParams[index].txtRotateHOffset.ToString();
            txtRotateMinHeight.Text = sysDataModel.gTestParams[index].txtRotateMinHeight.ToString();
            txtRotateMaxHeight.Text = sysDataModel.gTestParams[index].txtRotateMaxHeight.ToString();
            txtRotateMinTime.Text = sysDataModel.gTestParams[index].txtRotateMinTime.ToString();

            txtRotateMaxTime.Text = sysDataModel.gTestParams[index].txtRotateMaxTime.ToString();
            txtRotateMinAngleSpeed.Text = sysDataModel.gTestParams[index].txtRotateMinAngleSpeed.ToString();
            txtRotateMaxAngleSpeed.Text = sysDataModel.gTestParams[index].txtRotateMaxAngleSpeed.ToString();
            txtEightVOffset.Text = sysDataModel.gTestParams[index].txtEightVOffset.ToString();
            txtEightHOffset.Text = sysDataModel.gTestParams[index].txtEightHOffset.ToString();
            txtEightMinHeight.Text = sysDataModel.gTestParams[index].txtEightMinHeight.ToString();
            txtEightMaxHeight.Text = sysDataModel.gTestParams[index].txtEightMaxHeight.ToString();
            txtEightMinSpeed.Text = sysDataModel.gTestParams[index].txtEightMinSpeed.ToString();
            txtEightMaxSpeed.Text = sysDataModel.gTestParams[index].txtEightMaxSpeed.ToString();

            txtEightMinAngleSpeed.Text = sysDataModel.gTestParams[index].txtEightMinAngleSpeed.ToString();
            txtEightMaxAngleSpeed.Text = sysDataModel.gTestParams[index].txtEightMaxAngleSpeed.ToString();
            txtEightPhiOffset.Text = sysDataModel.gTestParams[index].txtEightPhiOffset.ToString();
            txtEightPhiCount.Text = sysDataModel.gTestParams[index].txtEightPhiCount.ToString();
            txtEightTimeout.Text = sysDataModel.gTestParams[index].txtEightTimeout.ToString();

            return;
        }
        /// <summary>
        /// 画面数据保存到训练参数
        /// </summary>
        public void saveTestInfo(int index)
        {
            sysDataModel.gTestParams[index].txtTestTimeout = double.Parse(txtTestTimeout.Text.Trim());
            sysDataModel.gTestParams[index].txtTestStartAngle = double.Parse(txtTestStartAngle.Text.Trim());
            sysDataModel.gTestParams[index].txtTestStartSpeed = double.Parse(txtTestStartSpeed.Text.Trim());
            sysDataModel.gTestParams[index].txtTestRadOffset = double.Parse(txtTestRadOffset.Text.Trim());
            sysDataModel.gTestParams[index].txtRotateVOffset = double.Parse(txtRotateVOffset.Text.Trim());
            sysDataModel.gTestParams[index].txtRotateHOffset = double.Parse(txtRotateHOffset.Text.Trim());
            sysDataModel.gTestParams[index].txtRotateMinHeight = double.Parse(txtRotateMinHeight.Text.Trim());
            sysDataModel.gTestParams[index].txtRotateMaxHeight = double.Parse(txtRotateMaxHeight.Text.Trim());
            sysDataModel.gTestParams[index].txtRotateMinTime = double.Parse(txtRotateMinTime.Text.Trim());

            sysDataModel.gTestParams[index].txtRotateMaxTime = double.Parse(txtRotateMaxTime.Text.Trim());
            sysDataModel.gTestParams[index].txtRotateMinAngleSpeed = double.Parse(txtRotateMinAngleSpeed.Text.Trim());
            sysDataModel.gTestParams[index].txtRotateMaxAngleSpeed = double.Parse(txtRotateMaxAngleSpeed.Text.Trim());
            sysDataModel.gTestParams[index].txtEightVOffset = double.Parse(txtEightVOffset.Text.Trim());
            sysDataModel.gTestParams[index].txtEightHOffset = double.Parse(txtEightHOffset.Text.Trim());
            sysDataModel.gTestParams[index].txtEightMinHeight = double.Parse(txtEightMinHeight.Text.Trim());
            sysDataModel.gTestParams[index].txtEightMaxHeight = double.Parse(txtEightMaxHeight.Text.Trim());

            sysDataModel.gTestParams[index].txtEightMinSpeed = double.Parse(txtEightMinSpeed.Text.Trim());
            sysDataModel.gTestParams[index].txtEightMaxSpeed = double.Parse(txtEightMaxSpeed.Text.Trim());
            sysDataModel.gTestParams[index].txtEightMinAngleSpeed = double.Parse(txtEightMinAngleSpeed.Text.Trim());
            sysDataModel.gTestParams[index].txtEightMaxAngleSpeed = double.Parse(txtEightMaxAngleSpeed.Text.Trim());
            sysDataModel.gTestParams[index].txtEightPhiOffset = double.Parse(txtEightPhiOffset.Text.Trim());
            sysDataModel.gTestParams[index].txtEightPhiCount = double.Parse(txtEightPhiCount.Text.Trim());
            sysDataModel.gTestParams[index].txtEightTimeout = double.Parse(txtEightTimeout.Text.Trim());

            // 更新场地显示
            this.UpdatePlayGround(); // 训练参数页面保存训练类型参数时，更新场地绘图参数
            return;
        }
        /// <summary>
        /// 训练参数画面的各控件是否显示
        /// flg
        /// </summary>
        public void enbaleTestInfo(bool flg)
        {
            txtTestTimeout.Enabled         = flg;
            txtTestStartAngle.Enabled      = flg;
            txtTestStartSpeed.Enabled      = flg;
            txtTestRadOffset.Enabled       = flg;
            txtRotateVOffset.Enabled       = flg;
            txtRotateHOffset.Enabled       = flg;
            txtRotateMinHeight.Enabled     = flg;
            txtRotateMaxHeight.Enabled     = flg;
            txtRotateMinTime.Enabled       = flg;
            txtRotateMaxTime.Enabled       = flg;
            txtRotateMinAngleSpeed.Enabled = flg;
            txtRotateMaxAngleSpeed.Enabled = flg;
            txtEightVOffset.Enabled        = flg;
            txtEightHOffset.Enabled        = flg;
            txtEightMinHeight.Enabled      = flg;
            txtEightMaxHeight.Enabled      = flg;
            txtEightMinSpeed.Enabled       = flg;
            txtEightMaxSpeed.Enabled       = flg;
            txtEightMinAngleSpeed.Enabled  = flg;
            txtEightMaxAngleSpeed.Enabled  = flg;
            txtEightPhiOffset.Enabled      = flg;
            txtEightPhiCount.Enabled       = flg;
            txtEightTimeout.Enabled        = flg;

            return;
        }
        #endregion



        /// <summary>
        /// 训练开始按钮
        /// </summary>
        private void btnTestStart_Click(object sender, EventArgs e)
        {
            if (listGround.SelectedIndex < 0)
            {
                UINotifierHelper.ShowNotifier("错误!请选择训练场地", UINotifierType.ERROR, UILocalize.ErrorTitle, true, 20000);
                return;
            }

            if (listTestType2.SelectedIndex < 0)
            {
                UINotifierHelper.ShowNotifier("错误!请选择考试类型", UINotifierType.ERROR, UILocalize.ErrorTitle, true, 20000);
                return;
            }

            if (listTestProject2.SelectedIndex < 0)
            {
                UINotifierHelper.ShowNotifier("错误！请选择训练项目", UINotifierType.ERROR, UILocalize.ErrorTitle, true, 20000);
                return;
            }

            //清空错误状态
            sysErrorChecker.ResetAll();
            sysDataModel.ErrorFlag = ErrorFlag.None;

            //上次训练记录清空
            listTextResult.Items.Clear();

            sysDataModel.gTestParam = sysDataModel.gTestParams[listTestType2.SelectedIndex];
            sysDataModel.gMaker = RouteColors.GetMarker(sysDataModel.gColorFlags[0]);
            sysDataModel.gColor = RouteColors.GetColor(sysDataModel.gColorFlags[0]);

            //地图中心点设置，便于可视
            GMapManager.gMapControl.Position = GMapManager.GroundLayout.CentePoint;
            //地图放大级别18级
            if (GMapManager.gMapControl.Zoom < 22) GMapManager.gMapControl.Zoom = 22;

            //控件状态初始化
            btnTestStart.Enabled = false;
            btnTestStop.Enabled = true;
            listTestType2.Enabled = false;
            listTestProject2.Enabled = false;

            //显示数据初始化
            txtVOffset.Text = "0.0";
            txtHOffset.Text = "0.0";
            txtPhiOffset.Text = "0.0";
            txtFlyHeight.Text = "0.0";
            txtSpeed.Text = "0.0";
            txtAngleSpeed.Text = "0.0";
            setTextInvoke(txtTimeLength, "000");
            txtVOffset.FillColor = Color.White;
            txtHOffset.FillColor = Color.White;
            txtPhiOffset.FillColor = Color.White;
            txtFlyHeight.FillColor = Color.White;
            txtSpeed.FillColor = Color.White;
            txtAngleSpeed.FillColor = Color.White;

            clearFlyData();
            clearViolationMarks();
            GMapManager.RevolveFlyCircle.IsVisible = false;
            GMapManager.gMapControl.Zoom = 22;
            if (btnRotate.Text == "飞行视角") btnRotate.PerformClick();

            switch (listTestProject2.SelectedIndex)
            {
                case 0:
                    sysDataModel.gTestSts   = TestSts.FeedomTrain;//自由训练
                    sysDataModel.gRotateSts = RotateSts.UnStart;
                    sysDataModel.gEightSts  = EightSts.UnStart;
                    appendResultInvoke("⚪ 自由练习开始");
                    break;
                case 1:
                    sysDataModel.gTestSts   = TestSts.RotateTrain;//自旋训练
                    sysDataModel.gRotateSts = RotateSts.Started;//自旋开始
                    sysDataModel.gEightSts  = EightSts.UnStart;
                    appendResultInvoke("⚪ 自旋练习开始");
                    break;
                case 2:
                    sysDataModel.gTestSts   = TestSts.EightTrain;//八字训练
                    sysDataModel.gRotateSts = RotateSts.UnStart;//八字开始
                    sysDataModel.gEightSts  = EightSts.Started;
                    appendResultInvoke("⚪ 八字练习开始");
                    break;
                case 3:
                    sysDataModel.gTestSts   = TestSts.ShamTest;//模拟考试-全科目
                    sysDataModel.gRotateSts = RotateSts.Started;//模拟考试开始
                    sysDataModel.gEightSts = EightSts.UnStart;
                    sysDataModel.gTestCount = 0;//初始化考试次数
                    appendResultInvoke("⚪ 模拟考试开始");
                    break;
                default:
                    sysDataModel.gTestSts   = TestSts.NotSelected;
                    sysDataModel.gRotateSts = RotateSts.UnStart;
                    sysDataModel.gEightSts  = EightSts.UnStart;
                    break;
            }
        }

        /// <summary>
        /// 训练结束按钮
        /// </summary>
        private void btnTestStop_Click(object sender, EventArgs e)
        {
            sysDataModel.gTestSts = TestSts.NotSelected;
            sysDataModel.gRotateSts = RotateSts.UnStart;
            sysDataModel.gEightSts = EightSts.UnStart;

            btnTestStart.Enabled = true;
            btnTestStop.Enabled = false;
            listTestType2.Enabled = true;
            listTestProject2.Enabled = true;

            setTextInvoke(txtTimeLength, "000");
            //clearFlyData();
        }



        #region 训练模式切换类窗口事件处理
        /// <summary>
        /// 考试类型选择
        /// </summary>
        private void listTestType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.updateTestRules(); // 开始训练页面切换训练类型时，更新场地绘图参数
            // 更新场地显示
            this.UpdatePlayGround(); // 开始训练页面切换训练类型时，更新场地绘图参数
        }
        /// <summary>
        /// 训练方式选择
        /// </summary>
        private void listTestProject2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTestRules();
        }
        /// <summary>
        /// 训练项目切换
        /// </summary>
        private void uiTestItem_CheckedChanged(object sender, EventArgs e)
        {
            if (uiTestItemRotate.Checked)
            {
                showRotateTestRules();
            }
            else if (uiTestItemEight.Checked)
            {
                showEightTestRules();
            }
        }
        #endregion



        #region 更新界面参考值范围
        /// <summary>
        /// 更新练习参考值范围
        /// </summary>
        private void updateTestRules()
        {
            if (listTestType2.SelectedIndex == -1) return;
            testParam param = sysDataModel.gTestParams[listTestType2.SelectedIndex];
            sysDataModel.gTestParam = param;

            switch (listTestProject2.SelectedIndex)
            {
                case 0:
                    //自由练习
                    uiTestItemRotate.Enabled = false;
                    uiTestItemRotate.Checked = false;
                    uiTestItemEight.Enabled = false;
                    uiTestItemEight.Checked = false;
                    showFreeTestRules();
                    break;
                case 1:
                    //自旋练习
                    uiTestItemRotate.Enabled = true;
                    uiTestItemRotate.Checked = true;
                    uiTestItemEight.Enabled = false;
                    uiTestItemEight.Checked = false;
                    showRotateTestRules();
                    break;
                case 2:
                    //八字练习
                    uiTestItemRotate.Enabled = false;
                    uiTestItemRotate.Checked = false;
                    uiTestItemEight.Enabled = true;
                    uiTestItemEight.Checked = true;
                    showEightTestRules();
                    break;
                case 3:
                    //模拟开始-全科目
                    uiTestItemRotate.Enabled = true;
                    uiTestItemRotate.Checked = true;
                    uiTestItemEight.Enabled = true;
                    uiTestItemEight.Checked = false;
                    showRotateTestRules();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 显示自由练习参考值范围
        /// </summary>
        private void showFreeTestRules()
        {
            labVOffset.Text = "无限制";
            labHOffset.Text = "无限制";
            labPhiOffset.Text = "无限制";
            labFlyHeight.Text = "无限制";
            labSpeed.Text = "无限制";
            labAngleSpeed.Text = "无限制";
            labTimeLength.Text = "无限制";
        }
        /// <summary>
        /// 显示水平自旋参考值范围
        /// </summary>
        private void showRotateTestRules()
        {
            testParam param = sysDataModel.gTestParam;
            labVOffset.Text = tools.strF00(0.0 - param.txtRotateVOffset) + " - " + tools.strF00(param.txtRotateVOffset);
            labHOffset.Text = tools.strF00(0.0 - param.txtRotateHOffset) + " - " + tools.strF00(param.txtRotateHOffset);
            labPhiOffset.Text = "无限制";
            labFlyHeight.Text = tools.strF00(param.txtRotateMinHeight) + " - " + tools.strF00(param.txtRotateMaxHeight);
            labSpeed.Text = "无限制";
            labAngleSpeed.Text = tools.strF00(param.txtRotateMinAngleSpeed) + " - " + tools.strF00(param.txtRotateMaxAngleSpeed);
            labTimeLength.Text = tools.strF00(param.txtRotateMinTime) + " - " + tools.strF00(param.txtRotateMaxTime);
        }
        /// <summary>
        /// 显示八字绕飞参考值范围
        /// </summary>
        private void showEightTestRules()
        {
            testParam param = sysDataModel.gTestParam;
            labVOffset.Text = tools.strF00(0.0 - param.txtEightVOffset) + " - " + tools.strF00(param.txtEightVOffset);
            labHOffset.Text = tools.strF00(0.0 - param.txtEightHOffset) + " - " + tools.strF00(param.txtEightHOffset);
            labPhiOffset.Text = tools.strF00(0.0 - param.txtEightPhiOffset) + " - " + tools.strF00(param.txtEightPhiOffset);
            labFlyHeight.Text = tools.strF00(param.txtEightMinHeight) + " - " + tools.strF00(param.txtEightMaxHeight);
            labSpeed.Text = tools.strF00(param.txtEightMinSpeed) + " - " + tools.strF00(param.txtEightMaxSpeed);
            labAngleSpeed.Text = "≥" + tools.strF00(param.txtEightMinAngleSpeed);
            labTimeLength.Text = tools.strF00(0) + " - " + tools.strF00(param.txtEightTimeout);
        }
        #endregion



        /// <summary>
        /// 训练结果list，绘制方法
        /// </summary>
        private void listTextResult_DrawItem(object sender, DrawItemEventArgs e)
        {
            //先调用基类实现
            e.DrawBackground();

            //form load 的时候return
            if (e.Index < 0)
                return;

            //因为此函数每一个 listItem drawing 都要调用，
            //所以不能简单的只写e.Graphics.DrawString(listBox1.Items[e.Index].ToString(),e.Font, Brushes.Red, e.Bounds);
            //那样会造成所有item一个颜色
            //这里是用item字符串是否包含某些词决定的
            if (listTextResult.Items[e.Index].ToString().Contains("⚪"))
            {
                e.Graphics.DrawString(listTextResult.Items[e.Index].ToString(),
                e.Font, Brushes.LimeGreen, e.Bounds);
            }
            else if (listTextResult.Items[e.Index].ToString().Contains("╳"))
            {
                e.Graphics.DrawString(listTextResult.Items[e.Index].ToString(),
                    e.Font, Brushes.OrangeRed, e.Bounds);

            }
            else
            {
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                        e.Font, Brushes.Black, e.Bounds);
            }
        }

        private void clearFlyData()
        {
            //清除无人机飞行轨迹数据
            lock (sysFunction.mFlyData)
            {
                sysFunction.mFlyData.Clear();
                GMapManager.flytransOverlay2.Routes.Clear();
                sysDataModel.FlyCode = 1;
                if (sysDataModel.FlyCode >= 1)
                {
                    sysFunction.flytranscount[(int)(sysDataModel.FlyCode - 1)] = 0;
                }
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 3;
        }

        private void txtTimeLength_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnUserName.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //更新系统状态
            switch (sysDataModel.gSystemSts)
            {
                case SystemStatus.Unknown://系统异常
                    txtSystemStatus.Text = "未知状态";
                    txtSystemStatus.FillColor = Color.LightGray;
                    uiProgressIndicator1.Visible = false;
                    break;
                case SystemStatus.Normal: //系统正常
                    txtSystemStatus.Text = "系统正常";
                    txtSystemStatus.FillColor = Color.SkyBlue;
                    uiProgressIndicator1.Visible = false;
                    break;
                case SystemStatus.DataTimedOut://系统异常
                    txtSystemStatus.Text = "接收数据超时";
                    txtSystemStatus.FillColor = Color.Orange;
                    uiProgressIndicator1.Visible = true;
                    break;
                case SystemStatus.ConnectionLost: //系统正常
                    txtSystemStatus.Text = "串口连接丢失";
                    txtSystemStatus.FillColor = Color.OrangeRed;
                    uiProgressIndicator1.Visible = true;
                    break;
            }

            //更新系统状态
            switch (sysDataModel.flyData.origin.FixType)
            {
                case GPS_FIX_TYPE.NO_GPS://未定位
                    btnGpsStar.Text = "未定位";
                    btnGpsStar.FillColor = Color.OrangeRed;
                    break;
                case GPS_FIX_TYPE.DGPS: //GPS定位成功
                    btnGpsStar.Text = "DGPS";
                    btnGpsStar.FillColor = Color.Cyan;
                    btnGpsStar.TipsText = sysDataModel.SatellitesVisible.ToString();
                    if (gMapControl.Position.Lng == 0.0) this.gMapControl.Position = new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude);
                    break;
                case GPS_FIX_TYPE.RTK_FIXED: //RTK定位成功
                    btnGpsStar.Text = "RTK Fixed";
                    btnGpsStar.FillColor = Color.SpringGreen;
                    btnGpsStar.TipsText = sysDataModel.SatellitesVisible.ToString();
                    if (gMapControl.Position.Lng == 0.0) this.gMapControl.Position = new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude);
                    break;
            }

            #region 状态栏
            //无人机当前飞行经度
            labCurrentLng.Text = string.Format("{0:0.00000000}", sysDataModel.Longtitude);
            //txtCenterLng.Text = labCurrentLng.Text;
            //无人机当前飞行纬度
            labCurrentLat.Text = string.Format("{0:0.00000000}", sysDataModel.Latitude);
            //txtCenterLat.Text = labCurrentLat.Text;
            //电池电压
            labACVoltage.Text = string.Format("{0:0}", sysDataModel.BatteryRemaining) + "%";
            labVol.Text = string.Format("{0:0.0}", sysDataModel.VoltageBattery / 1000) + "V";
            //陀螺X轴角速度
            //labX.Text = string.Format("{0:0.00}", sysDataModel.PitchSpeed);
            //陀螺Y轴角速度
            //labY.Text = string.Format("{0:0.00}", sysDataModel.YawSpeed);
            //陀螺Z轴角速度
            //labZ.Text = string.Format("{0:0.00}", sysDataModel.RollSpeed);
            //航速
            //label3.Text = string.Format("{0:0.00}", sysDataModel.flyData.judge.flightSpeed);
            //航向角
            //labPhi.Text = string.Format("{0:0.0}", sysDataModel.YawAngle) + "°";
            headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters((int)(sysDataModel.YawAngle + 360) % 360);
            //俯仰角
            //labOmega.Text = string.Format("{0:0.0}", sysDataModel.PitchAngle) + "°";
            //横滚角 用航向角
            //labkappa.Text = string.Format("{0:0.0}", sysDataModel.RollAngle) + "°";
            attitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters((int)sysDataModel.PitchAngle, (int)sysDataModel.RollAngle);
            //高度
            labHeight.Text = string.Format("{0:0.00}", sysDataModel.RelativeAlt) + "m";
            #endregion

            #region 实时值
            // 中心点距离
            txtDistance.Text = string.Format("{0:0.00}", sysDataModel.flyData.judge.distance);
            // 飞行高度
            txtFlyHeight.Text = string.Format("{0:0.00}", sysDataModel.RelativeAlt);
            // 垂直偏移
            txtVOffset.Text = string.Format("{0:0.00}", sysDataModel.flyData.judge.vOffset);
            // 水平偏移
            txtHOffset.Text = string.Format("{0:0.00}", sysDataModel.flyData.judge.hOffset);
            // 飞行角速度
            txtAngleSpeed.Text = string.Format("{0:0.00}", sysDataModel.YawSpeed);
            // 航向偏移
            txtPhiOffset.Text = string.Format("{0:0.00}", sysDataModel.flyData.judge.angleOffset);
            // 水平航速
            txtSpeed.Text = string.Format("{0:0.00}", sysDataModel.flyData.judge.flightSpeed);
            #endregion
        }


        #region 地图底图服务切换
        private void loadMapProviders()
        {
            cbMapProviders.Items.Clear();
            foreach (var mapProvider in MapProviders.List)
            {
                cbMapProviders.Items.Add(mapProvider);
            }
            cbMapProviders.SelectedIndex = 0;
        }
        private void cbMapProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedItem = ((Sunny.UI.UIComboBox)sender).SelectedItem;
            if (SelectedItem != null)
            {
                GMapManager.gMapControl.MapProvider = (GMapProvider)SelectedItem;
            }
        }
        #endregion 地图底图服务切换

        #region 清理地图缓存事件处理
        /// <summary>
        /// 清理当前地图缓存
        /// </summary>
        private void btnDeleteCurrentMap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure?",
                    "Clear GMap.NET cache?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    GMapManager.gMapControl.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, GMapManager.gMapControl.MapProvider.DbId);
                    MessageBox.Show("Done. Cache is clear.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 清理所有地图缓存
        /// </summary>
        private void btnDeleteAllMap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure?",
                    "Clear All GMap.NET cache?",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    GMapManager.gMapControl.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
                    MessageBox.Show("Done. Cache is clear.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion 清理地图缓存事件处理


        #region 地图控制按钮事件处理
        /// <summary>
        /// 定位到飞机
        /// </summary>
        private void btnPositioningAircraft_Click(object sender, EventArgs e)
        {
            gMapControl.Position = new PointLatLng(sysDataModel.Latitude, sysDataModel.Longtitude);
        }
        /// <summary>
        /// 缩放+1
        /// </summary>
        private void btnMapZoomUp_Click(object sender, EventArgs e)
        {
            gMapControl.Zoom += 1;
        }
        /// <summary>
        /// 缩放-1
        /// </summary>
        private void btnMapZoomDn_Click(object sender, EventArgs e)
        {
            gMapControl.Zoom -= 1;
        }
        #endregion 地图控制按钮事件处理

    }
}