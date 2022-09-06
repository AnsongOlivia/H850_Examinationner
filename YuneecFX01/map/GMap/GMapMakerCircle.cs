using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuneecFX01.map.GMap
{
    /// <summary>
    /// 用于在GMAP上，绘制各种圆
    /// </summary>
    public class GMapMarkerCircle : GMapMarker
    {
        /// <summary>
        /// 圆半径
        /// </summary>
        public float Radius = default;
        /// <summary>
        /// 画笔颜色
        /// </summary>
        public Pen Stroke = default;
        /// <summary>
        /// 填充颜色
        /// </summary>
        public Brush Fill = default;
        /// <summary>
        /// 是否内部填充颜色
        /// </summary>
        public bool IsFilled = true;
        /// <summary>
        /// 是否启用背景模式，线宽度随着缩放变化，此模式下填充设置会被忽略
        /// </summary>
        public bool IsBackGround = false;
        /// <summary>
        /// 背景模式下的实际宽度（米）
        /// </summary>
        public float BackGroundWidth = -1;

        /// <summary>
        /// 圆形标记
        /// </summary>
        /// <param name="p">位置</param>
        /// <param name="r">半径</param>
        /// <param name="penColor">画笔</param>
        public GMapMarkerCircle(PointLatLng p, float r, Color penColor) : base(p)
        {
            this.Radius = r;
            this.Stroke = new Pen(penColor, 2f);
            this.Stroke.DashStyle = DashStyle.Solid;
            this.IsFilled = false;
        }

        /// <summary>
        /// 绘制圆形标记
        /// </summary>
        /// <param name="p">位置</param>
        /// <param name="opno"></param>
        /// <param name="r">半径</param>
        /// <param name="penColor">画笔</param>
        /// <param name="brushColor">填充</param>
        /// <param name="alpha">透明度</param>
        public GMapMarkerCircle(PointLatLng p, string opno, float r, Color penColor, Color brushColor, int alpha) : base(p)
        {
            this.Radius = r;
            this.Stroke = new Pen(penColor, 2f);
            this.Stroke.DashStyle = DashStyle.Solid;
            this.Fill = new SolidBrush(Color.FromArgb(alpha, brushColor));
            this.IsHitTestVisible = false;
        }

        /// <summary>
        /// GMap绘制圆的方法
        /// PointLatLng p    :圆心坐标
        /// string opno      :无用
        /// float r          :圆半径
        /// Color penColor   :圆圈边框颜色
        /// Color brushColor :圆心坐标
        /// int alpha        :透明度
        /// </summary>
        public GMapMarkerCircle(PointLatLng p, string opno, float r, Color penColor, Color brushColor, int alpha, int dot) : base(p)
        {
            this.Radius = r;
            this.Stroke = new Pen(penColor, 2f);
            this.Stroke.DashStyle = DashStyle.Dot;
            this.Fill = new SolidBrush(Color.FromArgb(alpha, brushColor));
            this.IsHitTestVisible = false;
        }

        public override void OnRender(Graphics g)
        {
            double ratio = Overlay.Control.MapProvider.Projection.GetGroundResolution((int)Overlay.Control.Zoom, Position.Lat);
            int r = (int)Math.Round(Radius / ratio);

            if (IsBackGround && BackGroundWidth >= 0)
            {
                Stroke.Width = (int)Math.Round(BackGroundWidth / ratio);
            }
            else if (IsFilled)
            {
                g.FillEllipse(Fill, new Rectangle(LocalPosition.X - r, LocalPosition.Y - r, r * 2, r * 2));
            }
            g.DrawEllipse(Stroke, new Rectangle(LocalPosition.X - r, LocalPosition.Y - r, r * 2, r * 2));
        }

        public override void Dispose()
        {
            if (Stroke != null)
            {
                Stroke.Dispose();
                Stroke = null;
            }

            if (Fill != null)
            {
                Fill.Dispose();
                Fill = null;
            }

            base.Dispose();
        }
    }
}
