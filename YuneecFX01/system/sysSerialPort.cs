using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MAVLink;
using static YuneecFX01.system.sysConstant;

namespace YuneecFX01.system
{
    class sysSerialPort
    {
        //串口信息
        public static SerialPort mSerialPort;        //串口访问对象
        public static SerialPort mRTKSerialPort;     //RTK串口访问对象
        public static int mComStatus;         //串口状态 0：未连接 1：已连接（收发数据）        
        public static int lPacketNo = 0;
        public static byte gcssysid = 255;
        private static byte mMessageNo;         //消息序列号，自增
        private static List<byte> mDataBuf = new List<byte>();
        private static List<byte> mCmdList = new List<byte>();
        private static Thread mComSendThread;     //串口发送线程
        private static Thread mComRecvThread;     //串口接收线程
        private static Thread mComRTKRecvThread;  //RTK串口接收线程
        private static bool mComRecvThreadFlag;
        private static bool mComRTKRecvThreadFlag;
        private static byte[] byResize = new byte[256];//串口mavlink数据组包用,已有内容
        private static int lResize;                 //串口mavlink数据组包用,已有长度

        private static byte[] s0 = { 0xFD, 0x1E, 0xCA, 0x01, 0x01, 0x18, 0x94, 0x28, 0xDE, 0x2D, 0x04, 0x00, 0x00, 0x00, 0x4A, 0x26, 0x7B, 0x12, 0xE8, 0x56, 0x4D, 0x48, 0xED, 0x21, 0x00, 0x00, 0x3F, 0x00, 0x69, 0x00, 0x01, 0x00, 0x70, 0x4E, 0x04, 0x1D, 0x28, 0xF2 };
        private static byte[] s1 = { 0xFD, 0x24, 0xAB, 0x01, 0x01, 0x08, 0x43, 0x8B, 0xBD, 0x2D, 0x04, 0x00, 0x00, 0x00, 0xA0, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xA8, 0x28, 0x04, 0x00, 0x92, 0x16, 0x00, 0x00, 0x7F, 0x48, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x26, 0xC5, 0xFD, 0x33, 0xAC, 0x01, 0x01, 0x55, 0xE9, 0xDA, 0x11, 0x01, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC8, 0x42, 0xFD, 0xAA, 0xA7, 0xBF, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x01, 0xE6, 0xCA, 0xFD, 0x1C, 0xAD, 0x01, 0x01, 0x1E, 0xF7, 0xDA, 0x11, 0x01, 0x98, 0xAF, 0x57, 0x3E, 0x1D, 0x38, 0x0E, 0x3D, 0xE5, 0xAA, 0xA7, 0xBF, 0x8A, 0xCB, 0x3E, 0x3B, 0xE1, 0x6E, 0xAF, 0x3B, 0x17, 0x13, 0x81, 0xB9, 0xAC, 0x2B, 0xFD, 0x1C, 0xAE, 0x01, 0x01, 0x1E, 0xA1, 0xDB, 0x11, 0x01, 0x0E, 0xC2, 0x57, 0x3E, 0x82, 0x58, 0x0E, 0x3D, 0xC6, 0xAB, 0xA7, 0xBF, 0x51, 0xA9, 0x5E, 0x3B, 0x0A, 0x20, 0x4B, 0x3B, 0xEE, 0x24, 0xD2, 0xB9, 0x3E, 0x34, 0xFD, 0x1C, 0xAF, 0x01, 0x01, 0x21, 0xA7, 0xDB, 0x11, 0x01, 0x4C, 0x26, 0x7B, 0x12, 0xEB, 0x56, 0x4D, 0x48, 0x02, 0x1A, 0x00, 0x00, 0xC1, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4E, 0x6F, 0x82, 0x9D };
        private static byte[] s2 = { 0xFD, 0x1C, 0xB2, 0x01, 0x01, 0x1E, 0xF6, 0xDC, 0x11, 0x01, 0x27, 0xC7, 0x57, 0x3E, 0x6B, 0x0D, 0x0E, 0x3D, 0xB0, 0xAC, 0xA7, 0xBF, 0x15, 0xCD, 0x5C, 0xBB, 0xE9, 0x0C, 0x8C, 0xBB, 0xA6 };
        private static byte[] s3 = { 0xFD, 0x1C, 0xB4, 0x01, 0x01, 0x1E, 0xA4, 0xDD, 0x11, 0x01, 0x2E, 0xC1, 0x57, 0x3E, 0xB1, 0xBE, 0x0D, 0x3D, 0xBF, 0xAC, 0xA7, 0xBF, 0xFC, 0x4E, 0xDF, 0xBA, 0xA4, 0x7F, 0x80, 0xBA, 0x00, 0x19, 0x0B, 0xB9, 0x07, 0xCD, 0xFD, 0x1C, 0xB5, 0x01, 0x01, 0x21, 0xAF, 0xDD, 0x11, 0x01, 0x4C, 0x26, 0x7B, 0x12, 0xEB, 0x56, 0x4D, 0x48, 0x00, 0x1A };
        private static byte[] s4 = { 0xFD, 0x25, 0xB3, 0x01, 0x01, 0x53, 0x5F, 0xDD, 0x11, 0x01, 0xE5, 0x06, 0x4B, 0x3F, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0xA4, 0xEF, 0x1B, 0xBF, 0xBC, 0xEA, 0xAE, 0xBF, 0x6E, 0xBB, 0x66, 0xBE, 0xE4, 0x9B, 0x26, 0x3C, 0x6F, 0x12, 0x83, 0x3A, 0x00, 0x2E, 0x0D };
        private static byte[] s5 = { 0xFD, 0x1C, 0xB4, 0x01, 0x01, 0x1E, 0xA4, 0xDD, 0x11, 0x01, 0x2E, 0xC1, 0x57, 0x3E, 0xB1, 0xBE, 0x0D, 0x3D, 0xBF, 0xAC, 0xA7, 0xBF, 0xFC, 0x4E, 0xDF, 0xBA, 0xA4, 0x7F, 0x80, 0xBA, 0x00, 0x19, 0x0B, 0xB9, 0x07, 0xCD, 0xFD, 0x1C, 0xB5, 0x01, 0x01, 0x21, 0xAF, 0xDD, 0x11, 0x01, 0x4C, 0x26, 0x7B, 0x12, 0xEB, 0x56, 0x4D, 0x48, 0x00, 0x1A };
        private static byte[] s6 = { 0xFD, 0x09, 0xB7, 0x01, 0x01, 0x00, 0x00, 0x00, 0x04, 0x03, 0x0E, 0x0C, 0x1D, 0x03, 0x03, 0x72, 0xB0 };
        private static byte[] s7 = { 0xFD, 0x1C, 0xBA, 0x01, 0x01, 0x1E, 0xF8, 0xDE, 0x11, 0x01, 0x81, 0xCF, 0x57, 0x3E, 0xFC, 0x37, 0x0E, 0x3D, 0xA7, 0xAF, 0xA7, 0xBF, 0x22, 0x3F, 0x69, 0x3B, 0xB1, 0x13, 0x98, 0x3B, 0x4A, 0x7A, 0x83, 0xBA, 0xCF, 0xC3 };
        private static byte[] s8 = { 0xFD, 0x1C, 0xBB, 0x01, 0x01, 0x1E, 0xA2, 0xDF, 0x11, 0x01, 0x5F, 0xE1, 0x57, 0x3E, 0x2A, 0x2E, 0x0E, 0x3D, 0x8B, 0xB1, 0xA7, 0xBF, 0x09, 0xBD, 0x29, 0x3B, 0xEA, 0xAF, 0x2C, 0x3B, 0x75, 0x15, 0xA8, 0xB9, 0x31, 0x10 };
        private static byte[] s9 = { 0xFD, 0x24, 0xC0, 0x01, 0x01, 0x93, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF };
        private static byte[] s10 = { 0xFF, 0xFF, 0xFF, 0x7F, 0x31, 0x64, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x01, 0x01, 0x64, 0xC6, 0xFC, 0xFD, 0x2A, 0xC1, 0x01, 0x01, 0xE6, 0x4E, 0x70, 0xD8, 0x2D, 0x04, 0x00, 0x00, 0x00, 0xB6, 0x05, 0x83, 0x3C, 0x12, 0x50, 0xEF, 0x3B, 0x27, 0x90, 0xA0, 0x3B, 0xDE, 0x77, 0x88, 0x3A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB9, 0x9F, 0x28, 0x3E, 0x80, 0xB9, 0xAB, 0x3E, 0x7F, 0x03, 0x0C, 0x19, 0xFD };
        private static byte[] s11 = { 0x33, 0xC2, 0x01, 0x01, 0x55, 0x96, 0xE1, 0x11, 0x01, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0xC0, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC8, 0x42, 0x24, 0xB2, 0xA7, 0xBF, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x01, 0xFF, 0x02, 0xFD, 0x1C, 0xC3, 0x01, 0x01, 0x1E, 0xAA, 0xE1, 0x11, 0x01, 0x63, 0xED, 0x57, 0x3E, 0xD7, 0xE1, 0x0D, 0x3D, 0xE2, 0xB1, 0xA7, 0xBF, 0x28, 0xAF, 0xC2, 0x38, 0x6C, 0x51, 0x95, 0x3A, 0xCB, 0x56, 0x4A, 0x39, 0xD1, 0x79, 0xFD, 0x1C, 0xC4, 0x01, 0x01, 0x21, 0xAA, 0xE1, 0x11, 0x01, 0x4B, 0x26, 0x7B, 0x12, 0xE9, 0x56, 0x4D, 0x48, 0x0A, 0x1A, 0x00, 0x00, 0xC9, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x4D, 0x6F, 0x80, 0x72, 0xFD, 0x34, 0xC5, 0x01, 0x01, 0xF2, 0x5C, 0x26, 0x7B, 0x12, 0xF3, 0x56, 0x4D, 0x48, 0x42, 0x1A, 0x00, 0x00, 0x91, 0xFB, 0x84, 0x3F, 0x40, 0x96, 0x16, 0xBF, 0xE9, 0x2D, 0x4B, 0x40, 0x90, 0xF9, 0x4A, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFD, 0x00, 0x1C, 0xBF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5E, 0x43 };
        private static byte[] s12 = { 0xFD, 0x09, 0xC6, 0x01, 0x01, 0x00, 0x00, 0x00, 0x04, 0x03, 0x0E, 0x0C, 0x1D, 0x03, 0x03, 0x9F, 0xFD };
        private static byte[] s13 = { 0xFD };
        private static byte[] s14 = { 0x1C, 0xC7, 0x01, 0x01, 0x1E, 0x4F, 0xE2, 0x11, 0x01, 0x3A, 0xED, 0x57, 0x3E, 0x40, 0xFC, 0x0D, 0x3D, 0x0A, 0xB1, 0xA7, 0xBF, 0x56, 0xCF, 0x74, 0x3B, 0xC9, 0x96, 0x9C, 0x3B, 0x5E, 0x4C, 0xC0, 0xB9, 0x58, 0x49, 0xFD, 0x25, 0xC8, 0x01, 0x01, 0x53, 0x5E, 0xE2, 0x11, 0x01, 0xBC, 0x03, 0x4B, 0x3F, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0xC2, 0xF3, 0x1B, 0xBF, 0xD6, 0x1F, 0xAF, 0xBF, 0x0F, 0x77, 0x67, 0xBE, 0x03, 0x00, 0x28, 0x3C, 0x6F, 0x12, 0x83, 0x3A, 0x00, 0x65, 0xED };
        private static byte[] s15 = { 0xFD, 0x1E, 0xCA, 0x01, 0x01, 0x18, 0x94, 0x28, 0xDE, 0x2D, 0x04, 0x00, 0x00, 0x00, 0x4A, 0x26, 0x7B, 0x12, 0xE8, 0x56, 0x4D, 0x48, 0xED, 0x21, 0x00, 0x00, 0x3F, 0x00, 0x69, 0x00, 0x01, 0x00, 0x70, 0x4E, 0x04, 0x1D, 0x28, 0xF2 };
        private static byte[] s16 = { 0xFD, 0x20, 0xCF };
        private static byte[] s17 = { 0x01, 0x01, 0x8D, 0xDF, 0xAD, 0xE4, 0x2D, 0x04, 0x00, 0x00, 0x00, 0xC5, 0x27, 0x7D, 0x40, 0x98, 0x04, 0xD5, 0x40, 0xA9, 0x5C, 0x4F, 0xC0, 0x00, 0xD8, 0x85, 0xBD, 0x28, 0x24, 0x56, 0xC0, 0xE0, 0xEF, 0xD8, 0x3D, 0x0C, 0xFD, 0xFD, 0x02, 0xD0, 0x01, 0x01, 0xF5, 0x00, 0x01, 0xE0, 0x2B, 0xFD, 0x15, 0xD1, 0x01, 0x01, 0x24, 0xD8, 0xA7, 0xE4, 0x2D, 0x84, 0x03, 0x84, 0x03, 0x84, 0x03, 0x84, 0x03, 0x84, 0x03, 0x84, 0x03, 0x84, 0x03, 0x84, 0x03, 0x00, 0x1C, 0x49, 0xFD, 0x1F, 0xD2, 0x01, 0x01, 0x01, 0x2C, 0x80, 0x28, 0x12, 0x0C, 0x80, 0x21, 0x12, 0x2F, 0x80, 0x2E, 0x02, 0xAB, 0x02, 0x2B, 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x64, 0xDD, 0x6D, 0xFD, 0x24, 0xD3, 0x01, 0x01, 0x08, 0x38, 0xB0, 0xE4, 0x2D, 0x04, 0x00, 0x00, 0x00, 0x72, 0x02, 0x00, 0x00, 0x13, 0x16, 0x00, 0x00, 0xD0, 0x28, 0x04, 0x00, 0xF6, 0x16, 0x00, 0x00, 0x68, 0x49, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x73, 0xD6 };
        private static byte[] s18 = { };
        private static byte[] s19 = { };
        private static byte[] s20 = { };

        /// <summary>
        /// 构造函数
        /// </summary>
        public sysSerialPort()
        {
            mComStatus = 0;
        }

        /// <summary>
        /// 开始串口接收线程
        /// </summary>
        public static void startRecvThread()
        {
            mComRecvThreadFlag = false;
            mComRecvThread = new Thread(recvThread);
            mComRecvThread.Start();
        }

        /// <summary>
        /// 停止串口接收线程
        /// </summary>
        public static void stopRecvThread()
        {
            mComRecvThreadFlag = false;
            //mComRecvThread.Abort();
        }

        /// <summary>
        /// 串口接收线程函数
        /// </summary>
        private static void recvThread()
        {
            mComRecvThreadFlag = true;
            while (mComRecvThreadFlag)
            {
                try
                {
                    if (sysDataModel.gProtocol == 1)
                    {
                        //串口读取MAVLINK数据
                        sysSerialPort.recvMavLinkData();
                        //sysSerialPort.dealMavLinkData();
                    }
                    else
                    if (sysDataModel.gProtocol == 2)
                    {
                        //串口读取ROS数据
                    }
                }
                catch (Exception ex)
                {
                    sysLog.Error(ex, "处理串口数据错误");
                    sysDataModel.gSystemSts = SystemStatus.Unknown;
                }
                lPacketNo = lPacketNo + 1;
                Thread.Sleep(20);
            }
        }

        private static void dealMavLinkData()
        {
            MAVLink.MAVLinkMessage packet;
            if (!mSerialPort.IsOpen) return;
            packet = sysDataModel.mavlink.ReadPacket(mSerialPort.BaseStream);
            //检查是否有效 check its valid
            if (packet == null || packet.data == null) return;
            if (packet.data.GetType() == typeof(MAVLink.mavlink_heartbeat_t))
            {
                var hb = (MAVLink.mavlink_heartbeat_t)packet.data;
            }
            // from here we should check the the message is addressed to us
            // if (sysid != packet.sysid || compid != packet.compid) return;
            sysLog.Trace("[MAVLink] {@data}", packet);
            sysLog.Trace("[MAVLink] {@data}", packet.data);
            switch (packet.msgid)
            {
                case (byte)MAVLink.MAVLINK_MSG_ID.SYS_STATUS:
                    var sta = (MAVLink.mavlink_sys_status_t)packet.data;
                    //if (sta.voltage_battery > 3000 && sta.voltage_battery < 35535)
                    //    sysDataModel.VoltageBattery = sta.voltage_battery;
                    sysDataModel.VoltageBattery = sta.voltage_battery == UInt16.MaxValue ? 0 : sta.voltage_battery;
                    sysDataModel.BatteryRemaining = sta.battery_remaining == -1 ? 0 : sta.battery_remaining;
                    break;
                case (byte)MAVLink.MAVLINK_MSG_ID.GPS_RAW_INT:
                    var gps = (MAVLink.mavlink_gps_raw_int_t)packet.data;
                    sysDataModel.SatellitesVisible = gps.satellites_visible == 255 ? 0 : gps.satellites_visible;
                    break;
                case (byte)MAVLink.MAVLINK_MSG_ID.ATTITUDE:
                    var att = (MAVLink.mavlink_attitude_t)packet.data;
                    sysDataModel.RollAngle = (att.roll * 180.0f) / (float)Math.PI;
                    sysDataModel.PitchAngle = ((att.pitch * 180.0f) / (float)Math.PI) / 3.6f;
                    sysDataModel.YawAngle = (att.yaw * 180.0f) / (float)Math.PI;
                    sysDataModel.RollSpeed = (att.rollspeed * 180.0f) / (float)Math.PI;
                    sysDataModel.PitchSpeed = (att.pitchspeed * 180.0f) / (float)Math.PI;
                    sysDataModel.YawSpeed = (att.yawspeed * 180.0f) / (float)Math.PI;
                    break;
                case (byte)MAVLink.MAVLINK_MSG_ID.GLOBAL_POSITION_INT:
                    var pos = (MAVLink.mavlink_global_position_int_t)packet.data;
                    sysDataModel.Latitude = (double)pos.lat / 10000000.0d;
                    sysDataModel.Longtitude = (double)pos.lon / 10000000.0d;
                    sysDataModel.RelativeAlt = (float)pos.relative_alt / 1000.0f;
                    sysDataModel.Vx = (float)pos.vx / 100.0f;
                    sysDataModel.Vy = (float)pos.vy / 100.0f;
                    sysDataModel.Vz = (float)pos.vz / 100.0f;
                    break;
                case (byte)MAVLink.MAVLINK_MSG_ID.HIGHRES_IMU:
                    var hig = (MAVLink.mavlink_highres_imu_t)packet.data;
                    sysDataModel.Xmag = hig.xmag;
                    sysDataModel.Ymag = hig.ymag;
                    sysDataModel.Zmag = hig.zmag;
                    break;
            }
        }



        /// <summary>
        /// 接收无人机发送的Mavlink数据（通过电台）
        /// 
        /// </summary>
        public static int recvMavLinkConnect()
        {
            int lRet = -1;
            int dataLen = 0;

            mDataBuf.Clear();

            MAVLink.MAVLinkMessage byPacket;

            while (lRet < 100)
            {
                if (mSerialPort.IsOpen)
                {
                    //读取串口数据ReadPacket
                    //串口读取的Mavlink数据，有可能组包，也有可能拆包，都要处理
                    byte[] byMessage = new byte[mSerialPort.BytesToRead];

                    dataLen = mSerialPort.Read(byMessage, 0, byMessage.Length);

                    //MAVLINK1头部6字节+校验位2字节
                    //MAVLINK1头部10字节+校验位2字节
                    if (byMessage.Length < (10 + 2))
                        return 0;


                    //读取串口数据
                    byPacket = sysDataModel.mavlink.ReadPacket(mSerialPort.BaseStream);

                    //判断数据有效性
                    if (byPacket == null || byPacket.data == null)
                        continue;

                    sysLog.Info(byPacket.msgtypename + "[" + byPacket.msgid.ToString() + "]");

                    if (byPacket.msgid == (byte)MAVLink.MAVLINK_MSG_ID.SYS_STATUS)
                    {
                        //MAVLink.mavlink_sys_status_t val1 = (MAVLink.mavlink_sys_status_t)byPacket.data;
                        //sysLog.Info("MAVLINK_MSG_ID.SYS_STATUS 1 ["+
                        //             val1.voltage_battery + "]"+
                        //             "[" + val1.current_battery + "]" +
                        //             "[" + val1.battery_remaining + "]");
                        lRet = 0;
                        goto END;
                    }
                }
                else
                {
                    lRet = -1;
                    goto END;
                }
                lRet++;
                Thread.Sleep(50);
            }
        END:
            if (lRet < 0)
            {
                sysLog.Error("串口接收失败，串口未打开！");
            }
            else
            if (lRet > 0)
            {
                sysLog.Error("串口接收MAVLINK失败，尝试超过5次！");
            }
            else
            {
                sysLog.Info("串口接收MAVLINK成功！");
            }
            return lRet;
        }

        /// <summary>
        /// 从无人机接收-飞行各种数据
        /// 使用MAVLINK
        /// 解析数据生成全局变量
        /// </summary>
        public static void recvMavLinkData()
        {
            int dataLen = 0;
            int start = 0;
            int len = 0;
            byte[] byPacket = new byte[128];
            try
            {
                if (mSerialPort.IsOpen)
                {
                    //读取串口数据ReadPacket
                    //串口读取的Mavlink数据，有可能组包，也有可能拆包，都要处理
                    byte[] byMessage = new byte[mSerialPort.BytesToRead];

                    dataLen = mSerialPort.Read(byMessage, 0, byMessage.Length);

                    //MAVLINK1头部6字节+校验位2字节
                    //MAVLINK1头部10字节+校验位2字节
                    if (byMessage.Length < (10 + 2))
                        return;

                    //打印原始串口数据
                    sysLog.Trace("[XX0] {@data}", byMessage);

                    if (lResize > 0 && byMessage[0] != 0xFD)
                    {
                        int msglen = 0;

                        //实测下来飞控发送的mavlink消息，又是会有脏数据，最后一位多了0xFD
                        if (byMessage[byMessage.Length - 1] == 0xFD)
                        {
                            msglen = byMessage.Length - 1;
                        }
                        else
                        {
                            msglen = byMessage.Length;
                        }
                        Array.Resize(ref byPacket, msglen + lResize);
                        Array.Copy(byResize, 0, byPacket, 0, lResize);
                        Array.Copy(byMessage, 0, byPacket, lResize, msglen);
                        dataLen = byPacket.Length;
                    }
                    else
                    {
                        int msglen = 0;

                        //实测下来飞控发送的mavlink消息，又是会有脏数据，最后一位多了0xFD
                        if (byMessage[byMessage.Length - 1] == 0xFD)
                        {
                            msglen = byMessage.Length - 1;
                        }
                        else
                        {
                            msglen = byMessage.Length;
                        }
                        lResize = 0;
                        Array.Resize(ref byPacket, msglen);
                        Array.Copy(byMessage, 0, byPacket, 0, byPacket.Length);
                        dataLen = msglen;
                    }

                    //合法的Mavlink消息
                    if (byPacket[0] == 0xFD)
                    {
                        //有Mavlink数据处理
                        len = 0;
                        start = 0;
                        while (dataLen > 0)
                        {
                            len = byPacket[start + 1] + 10 + 2;

                            if (dataLen == len)
                            {
                                //无组包、无拆包 正好一条mavlink消息
                                byte[] byData = new byte[len];
                                Array.Copy(byPacket, start, byData, 0, len);

                                //解析Mavlink数据
                                processMavlink(byData);

                                lResize = 0;
                            }
                            else
                            if (dataLen > len)
                            {
                                //有组包 还有一条mavlink消息
                                byte[] byData = new byte[len];
                                Array.Copy(byPacket, start, byData, 0, len);

                                //解析Mavlink数据
                                processMavlink(byData);

                                lResize = 0;
                            }
                            else
                            if (dataLen < len)
                            {
                                //有拆包 不够一条mavlink消息                                
                                lResize = dataLen;
                                Array.Resize(ref byResize, lResize);
                                Array.Copy(byPacket, start, byResize, 0, lResize);
                            }
                            dataLen = dataLen - (len);

                            start = start + len;
                        }
                        sysDataModel.gSystemSts = SystemStatus.Normal;
                    }
                    else
                    {
                        //非法Mavlink数据
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLog.Error(ex, "处理串口数据错误");
                sysDataModel.gSystemSts = SystemStatus.Unknown;
                return;
            }
        }

        /// <summary>
        /// 串口数据解析--->Mavlink--->飞行数据
        /// 使用Mavlink协议
        /// 解析数据生成全局变量
        /// </summary>
        public static void processMavlink(byte[] byMavlink)
        {
            sysDataModel.gLastMavlinkTime = DateTime.Now;

            int msglen = 0; //Mavlink数据部长度
            int msgid = 0; //Mavlink消息ID
            byte[] bymsgid = new byte[] { 0, 0, 0, 0 };
            byte[] byData;

            if (byMavlink.Length < (10 + 2))
            {
                //没有数据部
                return;
            }

            //有数据部，数据部赋值
            msglen = byMavlink[1];
            //msgid  = byMavlink[5];
            Array.Copy(byMavlink, 7, bymsgid, 0, 3);
            msgid = BitConverter.ToInt32(bymsgid, 0);

            byData = new byte[msglen];
            Array.Copy(byMavlink, 10, byData, 0, msglen);

            sysLog.Trace("[XX1] {@data}", byMavlink);

            //Mavlink消息类型判断
            if (msgid == (byte)MAVLink.MAVLINK_MSG_ID.SYS_STATUS)
            {
                //1
                //MAVLink.mavlink_sys_status_t val = (MAVLink.mavlink_sys_status_t)byPacket.data;
                MAVLink.mavlink_sys_status_t val = (MAVLink.mavlink_sys_status_t)sysFunction.BytesToStruct(byData, typeof(MAVLink.mavlink_sys_status_t));

                //飞控电压 3.0V~35.0V
                if (val.voltage_battery > 3000 && val.voltage_battery < 35535)
                    sysDataModel.VoltageBattery = val.voltage_battery;//单位mV

                sysDataModel.BatteryRemaining = val.battery_remaining;
                //Console.WriteLine("MAVLINK 飞控电压:" + val.voltage_battery.ToString());
            }

            if (msgid == (byte)MAVLink.MAVLINK_MSG_ID.ATTITUDE)
            {
                //30
                //var val = (MAVLink.mavlink_attitude_t)byPacket.data;
                MAVLink.mavlink_attitude_t val = (MAVLink.mavlink_attitude_t)sysFunction.BytesToStruct(byData, typeof(MAVLink.mavlink_attitude_t));
                sysDataModel.PitchAngle = ((val.pitch * 180) / (float)Math.PI) / 3.6f;//俯仰角 x
                sysDataModel.YawAngle = (val.yaw * 180) / (float)Math.PI;          //航向角 y
                sysDataModel.RollAngle = (val.roll * 180) / (float)Math.PI;          //横滚角 z
                sysDataModel.PitchSpeed = (val.pitchspeed * 180) / (float)Math.PI;      //x轴角速度
                sysDataModel.YawSpeed = (val.yawspeed * 180) / (float)Math.PI;        //y轴角速度
                sysDataModel.RollSpeed = (val.rollspeed * 180) / (float)Math.PI;       //z轴角速度
                sysLog.Debug("YawSpeed {YawSpeed}", sysDataModel.YawSpeed);

                //Console.WriteLine("MAVLINK 航向角:" + sysDataModel.Posai.ToString());
                //Console.WriteLine("MAVLINK 俯仰角:" + val.pitch.ToString());
                //Console.WriteLine("MAVLINK 横滚角:" + val.roll.ToString());
                //Console.WriteLine("MAVLINK y轴角速度:" + val.yawspeed.ToString());
            }

            if (msgid == (byte)MAVLink.MAVLINK_MSG_ID.GLOBAL_POSITION_INT)
            {
                //33
                //经度、纬度、高度 
                //var val = (MAVLink.mavlink_global_position_int_t)byPacket.data;
                MAVLink.mavlink_global_position_int_t val = (MAVLink.mavlink_global_position_int_t)sysFunction.BytesToStruct(byData, typeof(MAVLink.mavlink_global_position_int_t));
                sysDataModel.Latitude = (double)val.lat / 10000000;  //纬度
                sysDataModel.Longtitude = (double)val.lon / 10000000;//经度 
                sysDataModel.RelativeAlt = (float)val.relative_alt / 1000;//相对起飞点的高度 mm
                sysDataModel.Vx = (float)val.vx / 100.0f;        //北向速度
                sysDataModel.Vy = (float)val.vy / 100.0f;         //东向速度
                sysDataModel.Vz = (float)val.vz / 100.0f;          //垂直速度
                //Console.WriteLine("MAVLINK 经度:" + val.lon.ToString());
                //Console.WriteLine("MAVLINK 纬度:" + val.lat.ToString());
                //Console.WriteLine("MAVLINK 海拔高度:" + val.alt.ToString());
                //Console.WriteLine("MAVLINK 相对高度:" + val.relative_alt.ToString());
            }

            if (msgid == (byte)MAVLink.MAVLINK_MSG_ID.GPS_RAW_INT)
            {
                //24
                //飞控给的数据只有30个byte，还需要补足22个byte
                byte[] byTemp = new byte[52];
                Array.Copy(byData, 0, byTemp, 0, byData.Length);

                //MAVLink.mavlink_gps_raw_int_t val = (MAVLink.mavlink_gps_raw_int_t)byPacket.data;
                MAVLink.mavlink_gps_raw_int_t val = (MAVLink.mavlink_gps_raw_int_t)sysFunction.BytesToStruct(byTemp, typeof(MAVLink.mavlink_gps_raw_int_t));
                sysDataModel.flyData.origin.FixType = (GPS_FIX_TYPE)val.fix_type; // GPS 定位类型
                sysDataModel.SatellitesVisible = val.satellites_visible == 255 ? 0 : val.satellites_visible; // GPS 星数
                //Console.WriteLine("MAVLINK GPS 星数:" + val.satellites_visible.ToString());
                sysDataModel.gGpsLastTime = DateTime.Now;
            }

            if (msgid == (byte)MAVLink.MAVLINK_MSG_ID.HIGHRES_IMU)
            {
                //105
                //飞控给的数据只有62个byte，还需要补足1个byte，共63个数据
                byte[] byTemp = new byte[63];
                Array.Copy(byData, 0, byTemp, 0, 62);
                //MAVLink.mavlink_highres_imu_t val = (MAVLink.mavlink_highres_imu_t)byPacket.data;
                MAVLink.mavlink_highres_imu_t val = (MAVLink.mavlink_highres_imu_t)sysFunction.BytesToStruct(byTemp, typeof(MAVLink.mavlink_highres_imu_t));

                //地磁数据
                sysDataModel.Xmag = val.xmag;
                sysDataModel.Ymag = val.ymag;
                sysDataModel.Zmag = val.zmag;                   
                //Console.WriteLine("MAVLINK 地磁:" + val.ymag.ToString());
            }

            if (msgid == (byte)MAVLink.MAVLINK_MSG_ID.HOME_POSITION)
            {
                //242
                //飞控给的数据只有52个byte，还需要补足8个byte
                byte[] byTemp = new byte[60];
                Array.Copy(byData, 0, byTemp, 0, byData.Length);

                //MAVLink.mavlink_home_position_t val = (MAVLink.mavlink_home_position_t)byPacket.data;
                MAVLink.mavlink_home_position_t val = (MAVLink.mavlink_home_position_t)sysFunction.BytesToStruct(byTemp, typeof(MAVLink.mavlink_home_position_t));
                //Console.WriteLine("MAVLINK 地面高度:" + val.altitude.ToString());
            }
            return;
        }


        //校验码
        public static int checkSum(byte[] byData)
        {
            int sum = 0;
            for (int i = 0; i < byData.Length; i++)
            {
                sum += (int)byData[i];
            }
            return sum;
        }
    }
}
