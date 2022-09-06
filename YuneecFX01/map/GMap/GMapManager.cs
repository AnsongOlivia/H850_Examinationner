using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace YuneecFX01.map.GMap
{
    //GMap管理类
	internal class GMapManager
	{
        public GMapManager(GMapControl gmapcontrol)
        {
            GMapManager.gMapControl = gmapcontrol;
        }
        
        public void init()
		{
			GMapManager.GroundLayout.IsVisibile = false;

			GMapManager.m_MenuStrip = new ContextMenuStrip();
			ToolStripMenuItem item = new ToolStripMenuItem();

			GMapManager.gMapControl.MouseUp -= this.gMapControl_MouseUp;
			GMapManager.gMapControl.MouseDown -= this.gMapControl_MouseDown;
			GMapManager.gMapControl.MouseMove -= this.gMapControl_MouseMove;
			GMapManager.gMapControl.OnMarkerClick -= this.gMapControl_OnMarkerClick;
			GMapManager.gMapControl.OnMarkerEnter -= this.gMapControl_OnMarkerEnter;
			GMapManager.gMapControl.OnMarkerLeave -= this.gMapControl_OnMarkerLeave;
			GMapManager.gMapControl.MouseUp += this.gMapControl_MouseUp;
			GMapManager.gMapControl.MouseDown += this.gMapControl_MouseDown;
			GMapManager.gMapControl.MouseMove += this.gMapControl_MouseMove;
			GMapManager.gMapControl.OnMarkerClick += this.gMapControl_OnMarkerClick;
			GMapManager.gMapControl.OnMarkerEnter += this.gMapControl_OnMarkerEnter;
			GMapManager.gMapControl.OnMarkerLeave += this.gMapControl_OnMarkerLeave;
			GMapManager.gMapControl.MouseWheel += this.gMapControl_MouseWheel;
		}

		private void gMapControl_MouseWheel(object sender, MouseEventArgs e)
		{
            //lijinfeng
			//TaskPlanFunc.isAvaliableArea();
		}
		public static double[] CalTwoPointMsg(int inde)
		{
			double angle = 0.0;
			double distance = 0.0;
			
			return new double[]
			{
				distance,
				angle
			};
		}

		private void gMapControl_MouseMove(object sender, MouseEventArgs e)
		{
			this.gmmCount++;
			PointLatLng point = GMapManager.gMapControl.FromLocalToLatLng(e.X, e.Y);
		}

		private void gMapControl_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = GMapManager.mouseflg;
			if (flag)
			{
				GMapManager.ismouseuse = true;
				PointLatLng point = GMapManager.gMapControl.FromLocalToLatLng(e.X, e.Y);
				this.NowPoint = point;
				GPoint gp = GMapManager.gMapControl.FromLatLngToLocal(point);
				bool flag2 = e.Button == MouseButtons.Left && !this.isRightButtonDown;
				if (flag2)
				{
					this.isLeftButtonDown = true;
				}
				else
				{
					bool flag3 = e.Button == MouseButtons.Right;
					if (flag3)
					{
						this.isRightButtonDown = true;
						Point pp = new Point(e.X, e.Y);
						GMapManager.m_MenuStrip.Show(GMapManager.gMapControl, pp);
					}
				}
				GMapManager.ismouseuse = false;
			}
		}

		private void gMapControl_MouseUp(object sender, MouseEventArgs e)
		{
			
		}

		private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
		{
		}

		
        //lijinfeng
		private void gMapControl_OnMarkerEnter(GMapMarker item)
		{
		}

		
		private void gMapControl_OnMarkerLeave(GMapMarker item)
		{
		}

		private void mouse_FlgInit()
		{
			this.isRightButtonDown = false;
		}
        //主画面的GMAP控件
		public static GMapControl gMapControl;

        //GMAP控件的菜单
		public static ContextMenuStrip m_MenuStrip;

		/// <summary>
		/// 训练场地图层
		/// </summary>
		public static GMapOverlayGround GroundLayout = new GMapOverlayGround("ground", default(PointLatLng));
		/// <summary>
		/// 训练场地图层
		/// </summary>
		public static GMapOverlayMapScale MapScaleLayout = new GMapOverlayMapScale("MapScale");


		public static GMapOverlay[] markersOverlay = new GMapOverlay[6];

		//各种覆盖对象定义
		//public static GMapOverlay areaOverlay = new GMapOverlay("Area");

		//public static GMapOverlay ObstacleOverlay = new GMapOverlay("Obstacle");

		//public static GMapOverlay ObsCircleOverlay = new GMapOverlay("ObsCircle");

		/// <summary>
		/// 用途未知
		/// </summary>
		public static GMapOverlay flytransOverlay = new GMapOverlay("plane");

		/// <summary>
		/// 训练时无人机飞行的历史轨迹覆盖(非常重要)
		/// </summary>
        public static GMapOverlay flybackOverlay = new GMapOverlay("flyback");

		//public static GMapOverlay RectangleOverlay = new GMapOverlay("Rectangle");

        /// <summary>
		/// 用途未知
		/// </summary>
		public static GMapOverlay NoFlyArea = new GMapOverlay("NoFlyArea");

		/// <summary>
		/// 无人机实时飞行轨迹图层
		/// 非常重要，训练时无人机飞行的实时轨迹覆盖
		/// </summary>
		public static GMapOverlayAll flytransOverlay2 = new GMapOverlayAll("plane2");

		/// <summary>
		/// 训练场地绘制图层
		/// </summary>
		public static GMapOverlay TestSysOverlay = new GMapOverlay("testsys");

		/// <summary>
		/// 飞行犯规标志图层
		/// </summary>
		public static GMapOverlay ViolationOverlay = new GMapOverlay("Violation");


		private PointLatLng NowPoint = default(PointLatLng);

		public static PointLatLng RevolveFollowPoint = default(PointLatLng);

		public static PointLatLng[] FlyCurrentPosition = new PointLatLng[5];
        
		public static GMapMarkerAll[] FlyBackMarker = new GMapMarkerAll[6];

		public static GMapMarkerCircle FlyBackMarkerCircle;

		public static GMapMarker LocationMarker;

		public static GMapMarker1[] RevolveMarker = new GMapMarker1[6];

		public static GMapMarkerAll[] FollowMarker = new GMapMarkerAll[6];

		public static GMapMarker1[] WorkBreakMarker = new GMapMarker1[6];

		public static GMapMarker StartPointMarker;

		public static GMapMarker ReferenceMarker;

		public static GMapMarker RangeMarker1;

		public static GMapMarker RangeMarker2;
        
		public static bool mouseflg = true;

		private bool isRightButtonDown = false;

        private bool isLeftButtonDown = false;

        public static bool ismouseuse = false;
        
		public static bool isLeftButtonClick = false;

		public static int flyMoveNum = -1;

		public static PointLatLng OldPoint = new PointLatLng(0.0, 0.0);

		public static GMapMarkerCircle FlyStartCircle;

		public static GMapMarkerCircle[] EightCircle = new GMapMarkerCircle[8];

		public static GMapMarkerCircle RevolveOutsideCircle;

		public static GMapMarkerCircle RevolveMidCircle;

        public static GMapMarkerCircle RevolveFlyCircle;

        public static GMapMarkerCircle EightMidCircle;

		public static GMapMarkerCircle[] EightYawPoint = new GMapMarkerCircle[8];

		private int gmmCount = 0;
	}
}
