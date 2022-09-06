using GMap.NET;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YuneecFX01.tool;
using static MAVLink;
using static YuneecFX01.system.sysConstant;

namespace YuneecFX01.system
{
    /// <summary>
    /// 系统全局数据模型定义
    /// </summary>
    public class sysDataModel
    {
        /// <summary>
        /// 协议的定义
        /// </summary>
        public enum PROTOCOL
        {
            MAVLINK = 1,
            ROS
        }

        /// <summary>
        /// 对应的飞控协议 1：MAVLINK 2：ROS
        /// </summary>
        public static int gProtocol;
        /// <summary>
        /// mavlink对象
        /// </summary>
        public static MAVLink.MavlinkParse mavlink = new MAVLink.MavlinkParse();
        /// <summary>
        /// 软件授权对象
        /// </summary>
        public static sysLicense gLicense;
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        public static sysDataBase gDataBase;
        /// <summary>
        /// 全局训练参数
        /// 0: 教员
        /// 1: 驾驶员
        /// 2: 机长
        /// </summary>
        public static testParam[] gTestParams = new testParam[3];
        /// <summary>
        /// 全局当前训练参数
        /// </summary>
        public static testParam gTestParam = new testParam();
        /// <summary>
        /// 系统状态 -1:系统异常 0:GPS定位中 1:系统正常
        /// </summary>
        public static SystemStatus gSystemSts = SystemStatus.Unknown;
        /// <summary>
        /// 最后一次收到GPS数据的时间戳
        /// </summary>
        public static DateTime gGpsLastTime;
        /// <summary>
        /// 最后一次收到Mavlink数据的时间戳
        /// </summary>
        public static DateTime gLastMavlinkTime;


        #region 航线和标记点的颜色
        public static ColorFlag[] gColorFlags =
        {
            ColorFlag.Blue,
            ColorFlag.Yellow,
            ColorFlag.Purple,
        };
        public static GMap.NET.WindowsForms.Markers.GMarkerGoogleType gMaker;
        public static System.Drawing.Color gColor;
        #endregion


        #region 全局场地信息，添加场地和飞行中使用
        /// <summary>
        /// 全局中心点坐标
        /// </summary>
        public static PointLatLng gCenterPoint;
        /// <summary>
        /// 全局左圆中心点坐标
        /// </summary>
        public static PointLatLng gLeftPoint;
        /// <summary>
        /// 全局右圆中心点坐标
        /// </summary>
        public static PointLatLng gRightPoint;
        /// <summary>
        /// 全局八字半径
        /// </summary>
        public static float gEightRadius;
        #endregion


        /// <summary>
        /// 全局训练类型，0：教员 1：驾驶员 2：机长
        /// </summary>
        public static TestType gTestType = TestType.Driver;
        /// <summary>
        /// 全局训练次数，最多3次
        /// </summary>
        public static int gTestCount = 0;
        /// <summary>
        /// 全局训练状态，-1：未开始 0：自由练习 1：自旋练习 2：8字练习 3：模拟考试
        /// </summary>
        public static TestSts gTestSts = TestSts.NotSelected;
        /// <summary>
        /// 全局训练状态，-1：未开始 0：自旋开始 2：  3： 
        /// </summary>
        public static RotateSts gRotateSts = RotateSts.Started;
        /// <summary>
        /// 全局训练状态，-1：未开始 0：八字开始 2：  3： 
        /// </summary>
        public static EightSts gEightSts = EightSts.Started;

        /// <summary>
        /// 用户协议信息 - 登录的用户协议名
        /// </summary>
        public static string gUserName;



        /// <summary>
        /// 自旋一周判定
        /// </summary>
        public static sysRotate gSysRouter = new sysRotate();

        #region 无人机飞行数据
        /// <summary>
        /// 无人机飞行数据
        /// </summary>
        public static FlyDataModel flyData = new FlyDataModel();
        /// <summary>
        /// 动力电压，有用
        /// </summary>
        public static float VoltageBattery { get => flyData.origin.VoltageBattery; set => flyData.origin.VoltageBattery = value; }
        /// <summary>
        /// 电池剩余电量（单位：%）
        /// </summary>
        public static float BatteryRemaining { get => flyData.origin.BatteryRemaining; set => flyData.origin.BatteryRemaining = value; }


        /// <summary>
        /// GPS收星数
        /// </summary>
        public static int SatellitesVisible { get => flyData.origin.SatellitesVisible; set => flyData.origin.SatellitesVisible= value; }


        /// <summary>
        /// 翻滚角 kappa Roll angle （单位：度）
        /// </summary>
        public static float RollAngle { get => flyData.origin.RollAngle; set => flyData.origin.RollAngle= value; }
        /// <summary>
        /// 俯仰角 omega Pitch angle （单位：度）
        /// </summary>
        public static float PitchAngle { get => flyData.origin.PitchAngle; set => flyData.origin.PitchAngle= value; }
        /// <summary>
        /// 航向角 phi Yaw angle 单位：度，范围：[-180, 180)
        /// </summary>
        public static float YawAngle { get => flyData.origin.YawAngle; set => flyData.origin.YawAngle= value; }

        /// <summary>
        /// 陀螺Z轴角速度 （单位：度/s）
        /// </summary>
        public static float RollSpeed { get => flyData.origin.RollSpeed; set => flyData.origin.RollSpeed= value; }
        /// <summary>
        /// 陀螺X轴角速度 （单位：度/s）
        /// </summary>
        public static float PitchSpeed { get => flyData.origin.PitchSpeed; set => flyData.origin.PitchSpeed= value; }
        /// <summary>
        /// 陀螺Y轴角速度 （单位：度/s）
        /// </summary>
        public static float YawSpeed { get => flyData.origin.YawSpeed; set => flyData.origin.YawSpeed= value; }


        /// <summary>
        /// 纬度
        /// </summary>
        public static double Latitude { get => flyData.origin.Latitude; set => flyData.origin.Latitude= value; }
        /// <summary>
        /// 精度
        /// </summary>
        public static double Longtitude { get => flyData.origin.Longtitude; set => flyData.origin.Longtitude= value; }

        /// <summary>
        /// 相对起飞点高度(单位：米)
        /// </summary>
        public static float RelativeAlt { get => flyData.origin.RelativeAlt; set => flyData.origin.RelativeAlt= value; }

        /// <summary>
        /// 北向速度（单位：米/s）
        /// </summary>
        public static float Vx { get => flyData.origin.Vx; set => flyData.origin.Vx= value; }
        /// <summary>
        /// 东向速度（单位：米/s）
        /// </summary>
        public static float Vy { get => flyData.origin.Vy; set => flyData.origin.Vy= value; }
        /// <summary>
        /// 天向速度垂直（单位：米/s）
        /// </summary>
        public static float Vz { get => flyData.origin.Vz; set => flyData.origin.Vz= value; }


        /// <summary>
        /// X轴地磁（单位：高斯）
        /// </summary>
        public static float Xmag { get => flyData.origin.Xmag; set => flyData.origin.Xmag= value; }
        /// <summary>
        /// Y轴地磁（单位：高斯）
        /// </summary>
        public static float Ymag { get => flyData.origin.Ymag; set => flyData.origin.Ymag= value; }
        /// <summary>
        /// Z轴地磁（单位：高斯）
        /// </summary>
        public static float Zmag { get => flyData.origin.Zmag; set => flyData.origin.Zmag= value; }
        #endregion



        /// <summary>
        /// X轴加速度
        /// </summary>
        public static float Ax { get; set; }

        /// <summary>
        /// Y轴加速度
        /// </summary>
        public static float Ay { get; set; }

        /// <summary>
        /// Z轴加速度
        /// </summary>
        public static float Az { get; set; }

        /// <summary>
        /// GPS高度
        /// </summary>
        public static float Gpsh { get; set; }

        /// <summary>
        /// 航迹循环次数，无用
        /// </summary>
        public static float Pressure { get; set; }

        /// <summary>
        /// 油门，无用
        /// </summary>
        public static float Gas { get; set; }

        /// <summary>
        /// 返航点经度，无用
        /// </summary>
        public static float LonBackpoint { get; set; }

        /// <summary>
        /// 返航点纬度，无用
        /// </summary>
        public static float LatBackpoint { get; set; }

        /// <summary>
        /// 航迹点经度，无用
        /// </summary>
        public static float LonApoint { get; set; }

        /// <summary>
        /// 航迹点纬度，无用
        /// </summary>
        public static float LatApoint { get; set; }

        /// <summary>
        /// 经度指令，无用
        /// </summary>
        public static float LonBpoint { get; set; }

        /// <summary>
        /// 纬度指令，无用
        /// </summary>
        public static float LatBpoint { get; set; }


        /// <summary>
        /// 高度指令，无用
        /// </summary>
        public static float SprayL { get; set; }

        /// <summary>
        /// 系统状态，有用
        /// </summary>
        public static ushort SystemState { get; set; }

        /// <summary>
        /// 定位精度，无用
        /// </summary>
        public static ushort GpsPrecision { get; set; }

        /// <summary>
        /// 航迹点编号，有用
        /// </summary>
        public static short RouteCode { get; set; }

        /// <summary>
        /// 无人机编号，有用
        /// </summary>
        public static short FlyCode { get; set; }

        /// <summary>
        /// 标志字，有用有用有用
        /// </summary>
        public static ushort SpecialChar { get; set; }

        /// <summary>
        /// 航迹点高度，无用
        /// </summary>
        public static float SprayV { get; set; }

        /// <summary>
        /// 雷达高度，无用
        /// </summary>
        public static float RadioH { get; set; }

        /// <summary>
        /// 气压高度，无用
        /// </summary>
        public static float PressureH { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public static ushort FCTimeYear { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        public static float Temperature { get; set; }

        public enum WorkType
        {
            WorkComm,
            WorkSpecial
        }
        public static WorkType mWorkType;
        public static ErrorFlag ErrorFlag;
        public static Dictionary<ErrorFlag, long> ErrorCount = new Dictionary<ErrorFlag, long>()
        {
            [ErrorFlag.BadHeight] = 0,
            [ErrorFlag.VOffsetOR] = 0,
            [ErrorFlag.HOffsetOR] = 0,
            [ErrorFlag.YawAngleOR] = 0,
            [ErrorFlag.YawSpeedOR] = 0,
            [ErrorFlag.FlightSpeedOR] = 0,
        };
        public static FlyDataModel[] flyErrorInfo = new FlyDataModel[0];
        public static Dictionary<ErrorFlag, FlyDataModel> FlyErrorTmp = new Dictionary<ErrorFlag, FlyDataModel>()
        {
            [ErrorFlag.BadHeight] = null,
            [ErrorFlag.VOffsetOR] = null,
            [ErrorFlag.HOffsetOR] = null,
            [ErrorFlag.YawAngleOR] = null,
            [ErrorFlag.YawSpeedOR] = null,
            [ErrorFlag.FlightSpeedOR] = null,
        };

        /// <summary>
        /// 无人机飞行数据--->可读文本
        /// </summary>
        public static string ToText()
        {
            StringBuilder sr = new StringBuilder();
            sr.Append(SatellitesVisible.ToString());
            sr.Append('\t');
            sr.Append(((double)PitchSpeed).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)YawSpeed).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)RollSpeed).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Ax).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Ay).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Az).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Xmag).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Ymag).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Zmag).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)YawAngle).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)PitchAngle).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)RollAngle).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(Latitude.ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(Longtitude.ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Gpsh).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Vx).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Vy).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)Vz).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(Pressure);
            sr.Append('\t');
            sr.Append(RelativeAlt);
            sr.Append('\t');
            sr.Append('\t');
            sr.Append(Gas);
            sr.Append('\t');
            sr.Append(((double)LonBackpoint).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)LatBackpoint).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)LonApoint).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)LatApoint).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)LonBpoint).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(((double)LatBpoint).ToString("0.0000000"));
            sr.Append('\t');
            sr.Append(BatteryRemaining);
            sr.Append('\t');
            sr.Append(SprayL);
            sr.Append('\t');
            sr.Append(SystemState);
            sr.Append('\t');
            sr.Append(GpsPrecision);
            sr.Append('\t');
            sr.Append(RouteCode);
            sr.Append('\t');
            sr.Append(FlyCode);
            sr.Append('\t');
            sr.Append(SpecialChar);
            sr.Append('\t');
            sr.Append(SprayV);
            sr.Append('\t');
            sr.Append(RadioH);
            sr.Append('\t');
            sr.Append(PressureH);
            sr.Append('\t');
            sr.Append(VoltageBattery);
            sr.Append('\t');
            string stime = string.Concat(new string[]
            {
                FCTimeYear.ToString(),
                //FCTimeHour[0].ToString(),
                //FCTimeHour[1].ToString(),
                //FCTimeHour[2].ToString(),
                //FCTimeHour[3].ToString()
            });
            sr.Append(stime);
            sr.Append('\t');
            sr.Append(Temperature);
            sr.Append('\t');
            return sr.ToString();

        }

        /// <summary>
        /// 串口二进制数据，解析出结构化数据
        /// </summary>
        public static void decodePlaneData(byte[] datas)
        {
            SatellitesVisible = (int)datas[3];//收星数
            PitchSpeed = (float)BitConverter.ToInt16(datas, 4) / 10f;//陀螺X轴角速度
            YawSpeed = (float)BitConverter.ToInt16(datas, 6) / 10f;//陀螺Y轴角速度
            RollSpeed = (float)BitConverter.ToInt16(datas, 8) / 10f;//陀螺Z轴角速度
            Ax = (float)BitConverter.ToInt16(datas, 10) / 100f;//X轴加速度
            Ay = (float)BitConverter.ToInt16(datas, 12) / 100f;//Y轴加速度
            Az = (float)BitConverter.ToInt16(datas, 14) / 100f;//Z轴加速度
            Xmag = (float)BitConverter.ToInt16(datas, 16) / 10f;//X轴地磁
            Ymag = (float)BitConverter.ToInt16(datas, 18) / 10f;//Y轴地磁
            Zmag = (float)BitConverter.ToInt16(datas, 20) / 10f;//Z轴地磁
            YawAngle = (float)BitConverter.ToInt16(datas, 22) / 10f;//航向角 phi
            PitchAngle = (float)BitConverter.ToInt16(datas, 24) / 10f;//俯仰角 omega
            RollAngle = (float)BitConverter.ToInt16(datas, 26) / 10f;//翻滚角 kappa
            Latitude = BitConverter.ToDouble(datas, 72);//纬度
            Longtitude = BitConverter.ToDouble(datas, 80);//精度
            Gpsh = (float)BitConverter.ToInt16(datas, 36) / 10f;//GPS高度
            Vx = (float)BitConverter.ToInt16(datas, 38) / 100f;//北向速度
            Vy = (float)BitConverter.ToInt16(datas, 40) / 100f;//东向速度
            Vz = (float)BitConverter.ToInt16(datas, 42) / 100f;//天向速度
            Pressure = (float)BitConverter.ToInt16(datas, 44) / 10f;//航迹循环次数，无用
            RelativeAlt = (float)BitConverter.ToInt16(datas, 46) / 100f;//高度，有用
            Gas = (float)BitConverter.ToUInt16(datas, 62);//油门，无用
            LonBackpoint = BitConverter.ToSingle(datas, 64);//返航点经度，无用
            LatBackpoint = BitConverter.ToSingle(datas, 68);//返航点纬度，无用
            LonApoint = BitConverter.ToSingle(datas, 72);//航迹点经度，无用
            LatApoint = BitConverter.ToSingle(datas, 76);//航迹点纬度，无用
            LonBpoint = BitConverter.ToSingle(datas, 80);//经度指令，无用
            LatBpoint = BitConverter.ToSingle(datas, 84);//纬度指令，无用
            BatteryRemaining = (float)BitConverter.ToUInt16(datas, 88) / 100f;//飞控电压，有用
            SprayL = (float)BitConverter.ToInt16(datas, 90) / 10f;//高度指令，无用
            SystemState = BitConverter.ToUInt16(datas, 92);//系统状态，有用
            GpsPrecision = BitConverter.ToUInt16(datas, 94);//定位精度，无用
            RouteCode = (short)datas[96];//航迹点编号，有用
            FlyCode = (short)datas[97];//无人机编号，有用
            SpecialChar = BitConverter.ToUInt16(datas, 98);//标志字，有用有用有用
            SprayV = (float)BitConverter.ToUInt16(datas, 100) / 10f;//航迹点高度，无用
            RadioH = (float)BitConverter.ToUInt16(datas, 102) / 1000f;//雷达高度，有用
            PressureH = (float)BitConverter.ToInt16(datas, 116) / 10f;//气压高度，无用
            VoltageBattery = (float)BitConverter.ToUInt16(datas, 118) / 100f;//动力电压，有用
            FCTimeYear = BitConverter.ToUInt16(datas, 120);
            Temperature = (float)BitConverter.ToInt16(datas, 126) / 10f;//温度
            return;
        }

        /// <summary>
        /// 文本数据，解析出结构化数据
        /// </summary>
        public static void decodePlaneData2(string[] datas)
        {
            //star = (int)datas[3];//收星数
            PitchSpeed = (float)Convert.ToDouble(datas[0]);//陀螺X轴角速度
            YawSpeed = (float)Convert.ToDouble(datas[1]);//陀螺Y轴角速度
            RollSpeed = (float)Convert.ToDouble(datas[2]);//陀螺Z轴角速度
            Ax = (float)Convert.ToDouble(datas[3]);//X轴加速度
            Ay = (float)Convert.ToDouble(datas[4]);//Y轴加速度
            Az = (float)Convert.ToDouble(datas[5]);//Z轴加速度
            Xmag = (float)Convert.ToDouble(datas[6]);//X轴地磁
            Ymag = (float)Convert.ToDouble(datas[7]);//Y轴地磁
            Zmag = (float)Convert.ToDouble(datas[8]);//Z轴地磁
            YawAngle = (float)Convert.ToDouble(datas[9]);//航向角 phi
            PitchAngle = (float)Convert.ToDouble(datas[10]);//俯仰角 omega
            RollAngle = (float)Convert.ToDouble(datas[11]);//翻滚角 kappa
            Latitude = Convert.ToDouble(datas[12]);//纬度
            Longtitude = Convert.ToDouble(datas[13]);//精度
            Gpsh = (float)Convert.ToDouble(datas[14]);//GPS高度
            Vx = (float)Convert.ToDouble(datas[15]);//北向速度
            Vy = (float)Convert.ToDouble(datas[16]);//东向速度
            Vz = (float)Convert.ToDouble(datas[17]);//天向速度
            Pressure = (float)Convert.ToDouble(datas[18]);//航迹循环次数，无用
            RelativeAlt = (float)Convert.ToDouble(datas[19]);//高度，有用
            BatteryRemaining = (float)Convert.ToDouble(datas[34]);//飞控电压，有用
            return;
        }

        /// <summary>
        /// 返回是否可以进行练习
        /// </summary>
        public static bool isTestEnable()
        {
            if (gCenterPoint.Lng == 0.0 || gCenterPoint.Lat == 0.0 ||
                gLeftPoint.Lng == 0.0 || gLeftPoint.Lat == 0.0 ||
                gRightPoint.Lng == 0.0 || gRightPoint.Lat == 0.0)
            {
                return false;
            }
            else
                return true;
        }
    }

    public class OriginData : ICloneable
    {
        /// <summary>
        /// 动力电压，有用
        /// </summary>
        public float VoltageBattery { get; set; }
        /// <summary>
        /// 电池剩余电量（单位：%）
        /// </summary>
        public float BatteryRemaining { get; set; }


        /// <summary>
        /// GPS 定位类型
        /// </summary>
        public GPS_FIX_TYPE FixType { get; set; }
        /// <summary>
        /// GPS 卫星数量
        /// </summary>
        public int SatellitesVisible { get; set; }


        /// <summary>
        /// 翻滚角 kappa Roll angle （单位：度）
        /// </summary>
        public float RollAngle { get; set; }
        /// <summary>
        /// 俯仰角 omega Pitch angle （单位：度）
        /// </summary>
        public float PitchAngle { get; set; }
        /// <summary>
        /// 航向角 phi Yaw angle （单位：度）
        /// </summary>
        public float YawAngle { get; set; }

        /// <summary>
        /// 陀螺Z轴角速度 （单位：度/s）
        /// </summary>
        public float RollSpeed { get; set; }
        /// <summary>
        /// 陀螺X轴角速度 （单位：度/s）
        /// </summary>
        public float PitchSpeed { get; set; }
        /// <summary>
        /// 陀螺Y轴角速度 （单位：度/s）
        /// </summary>
        public float YawSpeed { get; set; }


        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 精度
        /// </summary>
        public double Longtitude { get; set; }

        /// <summary>
        /// 相对起飞点高度(单位：米)
        /// </summary>
        public float RelativeAlt { get; set; }

        /// <summary>
        /// 北向速度（单位：米/s）
        /// </summary>
        public float Vx { get; set; }
        /// <summary>
        /// 东向速度（单位：米/s）
        /// </summary>
        public float Vy { get; set; }
        /// <summary>
        /// 天向速度垂直（单位：米/s）
        /// </summary>
        public float Vz { get; set; }


        /// <summary>
        /// X轴地磁（单位：高斯）
        /// </summary>
        public float Xmag { get; set; }
        /// <summary>
        /// Y轴地磁（单位：高斯）
        /// </summary>
        public float Ymag { get; set; }
        /// <summary>
        /// Z轴地磁（单位：高斯）
        /// </summary>
        public float Zmag { get; set; }

        public object Clone()
        {
            OriginData clone = new OriginData();
            clone.RollAngle = RollAngle;
            clone.PitchAngle = PitchAngle;
            clone.YawAngle = YawAngle;
            clone.RollSpeed = RollSpeed;
            clone.PitchSpeed = PitchSpeed;
            clone.YawSpeed = YawSpeed;
            clone.Latitude = Latitude;
            clone.Longtitude = Longtitude;
            clone.RelativeAlt = RelativeAlt;
            clone.Vx = Vx;
            clone.Vy = Vy;
            clone.Vz = Vz;
            clone.Xmag = Xmag;
            clone.Ymag = Ymag;
            clone.Zmag = Zmag;
            return clone;
        }
    }

    public class JudgeData : ICloneable
    {
        /// <summary>
        /// 中心点距离
        /// </summary>
        internal double distance;
        /// <summary>
        /// 垂直偏差
        /// </summary>
        internal double vOffset;
        /// <summary>
        /// 水平偏差
        /// </summary>
        internal double hOffset;
        /// <summary>
        /// 角速度绝对值
        /// </summary>
        internal double yawSpeed;
        /// <summary>
        /// 航向偏差
        /// </summary>
        internal double angleOffset;
        /// <summary>
        /// 水平航速
        /// </summary>
        internal double flightSpeed;

        public object Clone()
        {
            JudgeData clone = new JudgeData();
            clone.distance = distance;
            clone.vOffset = vOffset;
            clone.hOffset = hOffset;
            clone.yawSpeed = yawSpeed;
            clone.angleOffset = angleOffset;
            clone.flightSpeed = flightSpeed;
            return clone;
        }
    }

    public class FlyDataModel : ICloneable
    {
        public OriginData origin;
        public JudgeData judge;
        public FlyDataModel()
        {
            origin = new OriginData();
            judge = new JudgeData();
        }

        public object Clone()
        {
            FlyDataModel clone = new FlyDataModel();
            clone.origin = (OriginData)origin.Clone();
            clone.judge = (JudgeData)judge.Clone();
            return clone;
        }
    }
}
