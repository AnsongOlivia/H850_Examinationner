using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.system
{
    public class sysConstant
    {
        public enum TestType
        {
            /// <summary>
            /// 驾驶员
            /// </summary>
            Driver = 0,
            /// <summary>
            /// 机长
            /// </summary>
            Captain = 1,
            /// <summary>
            /// 教员
            /// </summary>
            Teacher = 2,
        }

        public enum SystemStatus
        {
            /// <summary>
            /// 未知状态
            /// </summary>
            Unknown,
            /// <summary>
            /// 系统正常
            /// </summary>
            Normal,
            /// <summary>
            /// 一段时间没有收到MAVLink数据
            /// </summary>
            DataTimedOut,
            /// <summary>
            /// 串口断开
            /// </summary>
            ConnectionLost,
        }

        public enum TestSts
        {
            /// <summary>
            /// 未开始
            /// </summary>
            NotSelected = -1,
            /// <summary>
            /// 自由练习
            /// </summary>
            FeedomTrain = 0,
            /// <summary>
            /// 自旋练习
            /// </summary>
            RotateTrain = 1,
            /// <summary>
            /// 8字练习
            /// </summary>
            EightTrain = 2,
            /// <summary>
            /// 模拟考试
            /// </summary>
            ShamTest = 3,
        }

        public enum RotateSts
        {
            /// <summary>
            /// 未开始
            /// </summary>
            UnStart = -1,
            /// <summary>
            /// 自旋开始
            /// </summary>
            Started = 0,
            /// <summary>
            /// 提示进入中心圈提示
            /// </summary>
            EnterCenterCircleNotice = 1,
            /// <summary>
            /// 检测是否进入中心圈
            /// </summary>
            EnterCenterCircleCheck = 2,
            /// <summary>
            /// 进入中心圈内准备开始自旋
            /// </summary>
            PrepareForRotate = 3,
            /// <summary>
            /// 正在进行自旋测试
            /// </summary>
            RotateInProgress = 4,
            /// <summary>
            /// 自旋测试成功
            /// </summary>
            RotateSuccess = 5,
            /// <summary>
            /// 自旋测试失败
            /// </summary>
            RotateFailed = 6,
        }

        public enum EightSts
        {
            /// <summary>
            /// 未开始
            /// </summary>
            UnStart = -1,
            /// <summary>
            /// 自旋开始
            /// </summary>
            Started = 0,
            /// <summary>
            /// 提示进入中心圈提示
            /// </summary>
            EnterCenterCircleNotice = 1,
            /// <summary>
            /// 检测是否进入中心圈
            /// </summary>
            EnterCenterCircleCheck = 2,
            /// <summary>
            /// 进入中心圈内准备开始8字
            /// </summary>
            PrepareForEight = 3,
            /// <summary>
            /// 正在进行8字测试
            /// </summary>
            EightInProgress = 4,
            /// <summary>
            /// 8字测试成功
            /// </summary>
            EightPass = 5,
            /// <summary>
            /// 8字测试失败
            /// </summary>
            EightFail = 6,
        }

        [Flags]
        public enum ErrorFlag
        {
            None = 0b_0000_0000,
            /// <summary>
            /// 项目超时
            /// </summary>
            TimeOut   = 0b_0000_0001,
            /// <summary>
            /// 飞行高度不对
            /// </summary>
            BadHeight = 0b_0000_0010,
            /// <summary>
            /// 垂直偏移超出范围
            /// </summary>
            VOffsetOR = 0b_0000_0100,
            /// <summary>
            /// 水平偏移超出范围
            /// </summary>
            HOffsetOR = 0b_0000_1000,
            /// <summary>
            /// 航向角超出范围
            /// </summary>
            YawAngleOR = 0b_0001_0000,
            /// <summary>
            /// 航向角统计错误
            /// </summary>
            YawAngleAccumOR = 0b_0010_0000,
            /// <summary>
            /// 偏航角速度超出范围
            /// </summary>
            YawSpeedOR = 0b_0100_0000,
            /// <summary>
            /// 飞行速度超出范围
            /// </summary>
            FlightSpeedOR = 0b_1000_0000,
        }
    }
}
