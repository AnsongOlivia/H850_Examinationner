using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.tool
{
    public enum ColorFlag
    {
        Blue = 0,
        Brown = 1,
        Gray = 2,
        Green = 3,
        Yellow = 4,
        Orange = 5,
        Purple = 6,
        Red = 7,
        Black = 8,
        White = 9,
    }
    /// <summary>
    /// 航线颜色及错误标记颜色管理
    /// </summary>
    public static class RouteColors
    {
        private static GMap.NET.WindowsForms.Markers.GMarkerGoogleType[] markers = new GMap.NET.WindowsForms.Markers.GMarkerGoogleType[] {
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.brown_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.gray_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.orange_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.black_small,
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.white_small,
            };
        private static System.Drawing.Color[] colors = new System.Drawing.Color[] {
                System.Drawing.Color.Blue,
                System.Drawing.Color.Brown,
                System.Drawing.Color.Gray,
                System.Drawing.Color.Green,
                System.Drawing.Color.Yellow,
                System.Drawing.Color.Orange,
                System.Drawing.Color.Purple,
                System.Drawing.Color.Red,
                System.Drawing.Color.Black,
                System.Drawing.Color.White,
            };

        /// <summary>
        /// 获取航线颜色
        /// </summary>
        /// <param name="index">颜色序号</param>
        /// <returns>颜色</returns>
        public static System.Drawing.Color GetColor(int index)
        {
            if (index < 0 || index > colors.Length) index = 0;
            return colors[index];
        }
        /// <summary>
        /// 获取航线颜色
        /// </summary>
        /// <param name="color">颜色枚举</param>
        /// <returns>颜色</returns>
        public static System.Drawing.Color GetColor(ColorFlag color)
        {
            return GetColor(((int)color));
        }
        /// <summary>
        /// 获取航线颜色
        /// </summary>
        /// <param name="marker">地图标记</param>
        /// <returns>颜色</returns>
        public static System.Drawing.Color GetColor(GMap.NET.WindowsForms.Markers.GMarkerGoogleType marker)
        {
            var index = Array.IndexOf(markers, marker);
            return GetColor(index);
        }
        /// <summary>
        /// 获取地图标记
        /// </summary>
        /// <param name="index">标记序号</param>
        /// <returns>标记</returns>
        public static GMap.NET.WindowsForms.Markers.GMarkerGoogleType GetMarker(int index)
        {
            if (index < 0 || index > colors.Length) index = 0;
            return markers[index];
        }
        /// <summary>
        /// 获取航线颜色
        /// </summary>
        /// <param name="color">颜色枚举</param>
        /// <returns>标记</returns>
        public static GMap.NET.WindowsForms.Markers.GMarkerGoogleType GetMarker(ColorFlag color)
        {
            return GetMarker(((int)color));
        }
        /// <summary>
        /// 获取地图标记
        /// </summary>
        /// <param name="color">航线颜色</param>
        /// <returns>标记</returns>
        public static GMap.NET.WindowsForms.Markers.GMarkerGoogleType GetMarker(System.Drawing.Color color)
        {
            var index = Array.IndexOf(colors, color);
            return GetMarker(index);
        }
    }
}
