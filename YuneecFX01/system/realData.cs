using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.system
{
    /// <summary>
    /// RealTimeData
    /// </summary>
    public class realData
    {

        /// <summary>
        /// 
        /// </summary>
        public static DateTime timeTag { get; set; }

        //纬度
        public static double lat { get; set; }

        //精度
        public static double lng { get; set; }

        //高度，有用
        public static float height { get; set; }

        //航向角 phi
        public static float phi { get; set; }

        //飞行速度
        public static double speed { get; set; }

        //垂直偏移超时
        public static long vOffsetTimeOut = 0;
        //水平偏移超时
        public static long hOffsetTimeOut = 0;
        //角速度超时
        public static long angleSpeedTimeOut = 0;
        //飞行速度超时
        public static long flySpeedTimeOut = 0;
        //航向偏移超时
        public static long phiOffsetTimeOut = 0;

        //航向偏移统计
        public static long phiOffsetCnt = 0;

    }
}
