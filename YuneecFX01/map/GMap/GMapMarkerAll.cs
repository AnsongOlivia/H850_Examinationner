using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using YuneecFX01.system;
using YuneecFX01.tool;

namespace YuneecFX01.map.GMap
{
    public class GMapMarker1 : GMarkerGoogle
    {
        public GMapMarker1(PointLatLng p, string wpno, GMarkerGoogleType color = GMarkerGoogleType.green) : base(p, color)
        {
            this.wpno1 = wpno;
        }

        public override void OnRender(Graphics g)
        {
            bool flag = this.selected1;
            if (flag)
            {
                g.FillEllipse(Brushes.Red, new Rectangle(base.LocalPosition, base.Size));
                g.DrawArc(Pens.Red, new Rectangle(base.LocalPosition, base.Size), 0f, 360f);
            }
            base.OnRender(g);
            int midw = base.LocalPosition.X + 11;
            int midh = base.LocalPosition.Y + 3;
            bool flag2 = TextRenderer.MeasureText(this.wpno1, SystemFonts.DefaultFont).Width > 15;
            if (flag2)
            {
                midw -= 4;
            }
            g.DrawString(this.wpno1, SystemFonts.DefaultFont, Brushes.Black, new PointF((float)midw, (float)midh));
        }

        private string wpno1 = "";

        public bool selected1 = false;
    }

    public class GMapMarkerAll : GMarkerGoogle
	{
		public GMapMarkerAll(PointLatLng p, string wpno, GMarkerGoogleType color, sysDataModel.WorkType type) : base(p, color)
		{
			this.wpno = wpno;
			this.mWorkType = sysDataModel.WorkType.WorkComm;
		}

		public override void OnRender(Graphics g)
		{
			bool flag = this.selected;
			if (flag)
			{
				g.FillEllipse(Brushes.Red, new Rectangle(base.LocalPosition, base.Size));
				g.DrawArc(Pens.Red, new Rectangle(base.LocalPosition, base.Size), 0f, 360f);
			}
			base.OnRender(g);
			int midw = base.LocalPosition.X + 11 + (base.Size.Width - 32) / 3;
			int midh = base.LocalPosition.Y + 6 + (base.Size.Height - 32) / 3;
			bool flag2 = TextRenderer.MeasureText(this.wpno, SystemFonts.DefaultFont).Width > 15;
			if (flag2)
			{
				midw -= 4;
			}
			Font ft = new Font("宋体", 10.5f + (float)((base.Size.Width - 32) / 4), FontStyle.Regular, GraphicsUnit.Point, 134);
			g.DrawString(this.wpno, ft, Brushes.Black, new PointF((float)midw, (float)midh));
		}

		private string wpno = "";

		private bool selected = false;

        public sysDataModel.WorkType mWorkType;
	}

    public class GMapOverlayAll : GMapOverlay
    {
        public GMapOverlayAll(string ostr) : base(ostr)
        {
        }

        public override void OnRender(Graphics g)
        {
            try
            {
                base.OnRender(g);
                bool flag = base.Control != null;
                if (flag)
                {
                    bool routesEnabled = base.Control.RoutesEnabled;
                    if (routesEnabled)
                    {
                        for (int i = 0; i < this.Routes.Count; i++)
                        {
                            bool isVisible = this.Routes[i].IsVisible;
                            if (isVisible)
                            {
                                this.Routes[i].OnRender(g);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        internal void ForceUpdate()
        {
            for (int i = 0; i < this.Routes.Count; i++)
            {
                bool isVisible = this.Routes[i].IsVisible;
                if (isVisible)
                {
                    base.Control.UpdateRouteLocalPosition(this.Routes[i]);
                }
            }
        }
    }

    //用于在GMAP上绘制图标并根据轨迹移动，比如：无人机图标
    public class GMapMarkerImage : GMapMarker
    {
        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
                bool flag = this.image != null;
                if (flag)
                {
                    base.Size = new Size(this.image.Width, this.image.Height);
                }
            }
        }

        public int Angle
        {
            get
            {
                return this.angle;
            }
            set
            {
                this.angle = value;
            }
        }
        public Pen Pen { get; set; }

        public Pen OutPen { get; set; }

        public GMapMarkerImage(PointLatLng p, Image image, int angle) : base(p)
        {
            base.Size = new Size(image.Width, image.Height);
            base.Offset = new Point(-base.Size.Width / 2, -base.Size.Height / 2);
            this.image = image;
            this.imageConst = image;
            this.angle = angle;
            this.Pen = null;
            this.OutPen = null;
        }

        public override void OnRender(Graphics g)
        {
            this.image = MyImageTools.GetRotateImage(this.imageConst, this.angle);
            this.lastangle = this.angle;
            base.Size = new Size(this.image.Width, this.image.Height);
            base.Offset = new Point(-base.Size.Width / 2, -base.Size.Height / 2);
            bool flag = this.image == null;
            if (!flag)
            {
                Rectangle rect = new Rectangle(base.LocalPosition.X, base.LocalPosition.Y, base.Size.Width, base.Size.Height);
                g.DrawImage(this.image, rect);
                bool flag2 = this.Pen != null;
                if (flag2)
                {
                    g.DrawRectangle(this.Pen, rect);
                }
                bool flag3 = this.OutPen != null;
                if (flag3)
                {
                    g.DrawEllipse(this.OutPen, rect);
                }
                base.OnRender(g);
            }
        }

        public override void Dispose()
        {
            bool flag = this.Pen != null;
            if (flag)
            {
                this.Pen.Dispose();
                this.Pen = null;
            }
            bool flag2 = this.OutPen != null;
            if (flag2)
            {
                this.OutPen.Dispose();
                this.OutPen = null;
            }
            base.Dispose();
        }
        
        private Image image;
        
        private Image imageConst;
        
        private int angle;

        private int lastangle;
    }
}
