using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.system
{
    /// <summary>
    /// 训练参数相关数据模型
    /// 1、通用参数
    /// 2、自旋参数
    /// 3、8字参数
    /// </summary>
    public class testParam
    {
        #region 通用参数
        /// <summary>
        /// 名称
        /// </summary>
        public string txtTestTypeName = "";
        /// <summary>
        /// 训练开始 起始速度 StartOverSpeed 8字需要，自旋不需要
        /// </summary>
        public double txtTestStartSpeed = 0.5;
        /// <summary>
        /// 训练开始 中心点距离 LenMidPoint 8字不需要，自旋需要
        /// </summary>
        public double txtTestRadOffset = 1.5;
        /// <summary>
        /// 训练开始 起始角度 StartAngle
        /// </summary>
        public double txtTestStartAngle = 15.0;
        /// <summary>
        /// 进入中心时间 TotalTime
        /// </summary>
        public double txtTestTimeout = 60;
        #endregion

        #region 自旋参数
        /// <summary>
        /// 自旋水平偏差
        /// </summary>
        public double txtRotateHOffset = 2.0;
        /// <summary>
        /// 自旋垂直偏差
        /// </summary>
        public double txtRotateVOffset = 1.0;
        /// <summary>
        /// 最小高度 StartMinHeight
        /// </summary>
        public double txtRotateMinHeight = 0.5;
        /// <summary>
        /// 最大高度 StartMaxHeight
        /// </summary>
        public double txtRotateMaxHeight = 5.0;
        /// <summary>
        /// 最小时间 RevolveTimeMax
        /// </summary>
        public double txtRotateMinTime = 30;
        /// <summary>
        /// 最大时间 RevolveTimeMin
        /// </summary>
        public double txtRotateMaxTime = 5;
        /// <summary>
        /// 最小角速度 rYawAngleVMin
        /// </summary>
        public double txtRotateMinAngleSpeed = 10.0;
        /// <summary>
        /// 最大角速度 rYawAngleVMax
        /// </summary>
        public double txtRotateMaxAngleSpeed = 50.0;
        //评判时间 YawStopTime
        //public double YawStopTime = 1.0;
        #endregion

        #region 8字参数
        /// <summary>
        /// 8字水平偏差
        /// </summary>
        public double txtEightHOffset = 2.0;
        /// <summary>
        /// 8字垂直偏差
        /// </summary>
        public double txtEightVOffset = 1.0;
        /// <summary>
        /// 8字航向偏差
        /// </summary>
        public double txtEightPhiOffset = 2.0;
        /// <summary>
        /// 8字航向统计范围
        /// </summary>
        public double YawAngleLowScal = 0.8;
        /// <summary>
        /// 8字航向统计结果
        /// </summary>
        public double YawAngleResultScal = 0.3;

        public double txtEightPhiCount = 0;
        /// <summary>
        /// 8字最小高度 StartMinHeight
        /// </summary>
        public double txtEightMinHeight = 1.5;
        /// <summary>
        /// 8字最大高度 StartMaxHeight
        /// </summary>
        public double txtEightMaxHeight = 5.0;
        /// <summary>
        /// 8字最小速度 FlyMinSpeed
        /// </summary>
        public double txtEightMinSpeed = 0.2;
        /// <summary>
        /// 8字最大速度 FlyMaxSpeed
        /// </summary>
        public double txtEightMaxSpeed = 3.0;
        /// <summary>
        /// 8字最小角速度 YawAngleSpeed
        /// </summary>
        public double txtEightMinAngleSpeed = 0.0;
        /// <summary>
        /// 8字最大角速度 YawAngleSpeed
        /// </summary>
        public double txtEightMaxAngleSpeed = 0.0;
        /// <summary>
        /// 8字判定时间 EightStartTime
        /// </summary>
        public double EightStartTime = 1.0;
        /// <summary>
        /// 8字总时间 TotalTime
        /// </summary>
        public double txtEightTimeout = 180;
        #endregion
    }
}
