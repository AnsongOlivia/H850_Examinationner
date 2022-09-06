using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.map.GMap
{
    public class GMapOverlayMapScale : GMapOverlay
    {
        /// <summary>
        /// pen for scale info
        /// </summary>
        private Pen ScalePen = new Pen(Color.Black, 3);
        private Pen ScalePenBorder = new Pen(Color.WhiteSmoke, 6);
        private Font ScaleFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);

        /// <summary>
        /// 记录当前图像状态
        /// </summary>
        private Matrix OriTransform;

        private int PxRes10M; // 10 meters
        private int PxRes100M; // 100 meters
        private int PxRes1000M; // 1km  
        private int PxRes10Km; // 10km
        private int PxRes100Km; // 100km
        private int PxRes1000Km; // 1000km
        private int PxRes5000Km; // 5000km

        public GMapOverlayMapScale(string id) : base(id) { }

        public override void OnRender(Graphics g)
        {
            OriTransform = g.Transform;
            g.ResetTransform();

            int top = Control.Bottom - 30;
            int left = 10;
            int bottom = top + 7;
            int Zoom = (int)Control.Zoom;

            double rez = Control.MapProvider.Projection.GetGroundResolution(Zoom, Control.Position.Lat);
            PxRes10M = (int)(10.0 / rez); // 10 meters
            PxRes100M = (int)(100.0 / rez); // 100 meters
            PxRes1000M = (int)(1000.0 / rez); // 1km  
            PxRes10Km = (int)(10000.0 / rez); // 10km
            PxRes100Km = (int)(100000.0 / rez); // 100km
            PxRes1000Km = (int)(1000000.0 / rez); // 1000km
            PxRes5000Km = (int)(5000000.0 / rez); // 5000km

            if (Control.Width / 2 > PxRes5000Km)
            {
                DrawScale(g, top, left + PxRes5000Km, bottom, left, "5000 km");
            }
            else if (Control.Width / 2 > PxRes1000Km)
            {
                DrawScale(g, top, left + PxRes1000Km, bottom, left, "1000 km");
            }
            else if (Control.Width / 2 > PxRes100Km && Zoom > 2)
            {
                DrawScale(g, top, left + PxRes100Km, bottom, left, "100 km");
            }
            else if (Control.Width / 2 > PxRes10Km && Zoom > 5)
            {
                DrawScale(g, top, left + PxRes10Km, bottom, left, "10 km");
            }
            else if (Control.Width / 2 > PxRes1000M && Zoom >= 10)
            {
                DrawScale(g, top, left + PxRes1000M, bottom, left, "1000 m");
            }
            else if (Control.Width / 2 > PxRes100M && Zoom > 11)
            {
                DrawScale(g, top, left + PxRes100M, bottom, left, "100 m");
            }
            else if (Control.Width / 2 > PxRes10M && Zoom > 14)
            {
                DrawScale(g, top, left + PxRes10M, bottom, left, "10 m");
            }

            g.MultiplyTransform(OriTransform);
        }

        private void DrawScale(Graphics g, int top, int right, int bottom, int left, string caption)
        {
            g.DrawLine(ScalePenBorder, left, top, left, bottom);
            g.DrawLine(ScalePenBorder, left, bottom, right, bottom);
            g.DrawLine(ScalePenBorder, right, bottom, right, top);

            g.DrawLine(ScalePen, left, top, left, bottom);
            g.DrawLine(ScalePen, left, bottom, right, bottom);
            g.DrawLine(ScalePen, right, bottom, right, top);

            // g.DrawString(caption, ScaleFont, Brushes.Black, right + 3, top - 5);

            GraphicsPath path = new GraphicsPath();
            path.AddString(caption, ScaleFont.FontFamily, (int)ScaleFont.Style, g.DpiY * ScaleFont.SizeInPoints / 72, new Point(right + 3, top - 5), StringFormat.GenericTypographic);
            g.SmoothingMode = SmoothingMode.AntiAlias; //设置字体质量
            g.DrawPath(Pens.White, path); //绘制轮廓（描边）
            g.FillPath(Brushes.Black, path); //填充轮廓（填充）
        }
    }
}
