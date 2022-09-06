using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YuneecFX01.map.GMap;
using YuneecFX01.tool;

namespace YuneecFX01.system
{
    class sysFunction
    {
        public static void initApplication()
        {
            sysDataModel.gDataBase = new sysDataBase("data source=yuneec");
            sysDataModel.gDataBase.CreateTable("table_user", new string[] { "user_id", "user_name" }, new string[] { "INTEGER", "TEXT" });
            sysDataModel.gDataBase.CreateTable("table_com", new string[] { "com_port", "com_rate" }, new string[] { "TEXT", "TEXT" });

            //用户信息
            sysDataModel.gUserName = "";

            //串口信息
            sysSerialPort.mSerialPort    = new SerialPort();
            sysSerialPort.mRTKSerialPort = new SerialPort();
        }

        public static void exitApplication()
        {
            sysDataModel.gDataBase.CloseConnection();
            //Environment.Exit(0);
        }

        public static void TestDataInit()
        {
            taskarea = taskarea0;
            taskpoint = taskpoint0;
            istaskupload.Add(0, false);
            istaskupload.Add(1, false);
            istaskupload.Add(2, false);
            istaskupload.Add(3, false);
            istaskupload.Add(4, false);
            istaskupload.Add(5, false);
            //lijinfeng
            TestPoint tmtask = new TestPoint();
            tmtask.TSeaHigh = 20f;
            tmtask.TLevelSpeed = 3f;
            tmtask.Tverticalspeed = 2f;
            tmtask.Tswervemode = 0;
            tmtask.Tstoptime = 5;
            taskpointdefault.Add(0, tmtask);
            TestPoint tmtask2 = tmtask.copy();
            taskpointdefault.Add(1, tmtask);
            tmtask2 = tmtask.copy();
            taskpointdefault.Add(2, tmtask2);
            tmtask2 = tmtask.copy();
            taskpointdefault.Add(3, tmtask2);
            tmtask2 = tmtask.copy();
            taskpointdefault.Add(4, tmtask2);
            tmtask2 = tmtask.copy();
            taskpointdefault.Add(5, tmtask2);
            tmtask = new TestPoint();
            TestPoint tmppoint = new TestPoint();
            tmppoint.TIndex = 1;
            taskpoint0.Add(tmppoint);
            tmppoint = new TestPoint();
            taskpoint1.Add(tmppoint);
            tmppoint = new TestPoint();
            taskpoint2.Add(tmppoint);
            tmppoint = new TestPoint();
            taskpoint3.Add(tmppoint);
            tmppoint = new TestPoint();
            taskpoint4.Add(tmppoint);
            tmppoint = new TestPoint();
            taskpoint5.Add(tmppoint);
            TestArea tmparea = new TestArea();
            taskarea0.Add(tmparea);
            tmparea = new TestArea();
            taskarea1.Add(tmparea);
            tmparea = new TestArea();
            taskarea2.Add(tmparea);
            tmparea = new TestArea();
            taskarea3.Add(tmparea);
            tmparea = new TestArea();
            taskarea4.Add(tmparea);
            tmparea = new TestArea();
            taskarea5.Add(tmparea);
            Debug.WriteLine("初始化GLOBAL变量。。。。。。。。。。。。。");
            obstaclists.Add(new List<PointLatLng>());
        }

        public static void MapPloyLine(GMapOverlay lyr, List<PointLatLng> pointlist)
        {
            int index = 0;
            lyr.Routes.Clear();
            foreach (PointLatLng tpoint in pointlist)
            {
                GMapMarkerAll marker = new GMapMarkerAll(tpoint, index.ToString(), GMarkerGoogleType.green, sysDataModel.WorkType.WorkComm);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = string.Format("经度：{0:f5},纬度:{1:f5}", tpoint.Lng, tpoint.Lat);
                lyr.Markers.Add(marker);
                index++;
            }
            GMapRoute route = new GMapRoute(pointlist, "route1");
            route.Stroke = new Pen(Color.Red, 2f);
            lyr.Routes.Add(route);
        }

        public static void MapPloygonDraw(GMapOverlay lyr, List<PointLatLng> pointlist, int index, bool ismarker, GMarkerGoogleType markercolor = GMarkerGoogleType.orange)
        {
            int plen = pointlist.Count;
            for (int i = 0; i < lyr.Polygons.Count; i++)
            {
                bool flag = lyr.Polygons[i].Name == "ploy" + index.ToString();
                if (flag)
                {
                    lyr.Polygons.RemoveAt(i);
                    break;
                }
            }
            if (ismarker)
            {
                for (int j = 0; j < plen; j++)
                {
                    GMapMarkerAll marker = new GMapMarkerAll(pointlist[j], j.ToString(), markercolor, sysDataModel.WorkType.WorkComm);
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTipText = string.Format("障碍物：{0},{1:f5},{2:f5}", j, pointlist[j].Lng, pointlist[j].Lat);
                    lyr.Markers.Add(marker);
                }
            }
            bool flag2 = plen > 1;
            if (flag2)
            {
                GMapPolygon polygon = new GMapPolygon(pointlist, "ploy" + index.ToString());
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Gold));
                polygon.Stroke = new Pen(Color.Green, 2f);
                polygon.IsHitTestVisible = true;
                polygon.ToString();
                lyr.Polygons.Add(polygon);
            }
        }

        public static void MapPloyNoFlyNone(GMapOverlay lyr, List<PointLatLng> plist, PointLatLng centpoint, int ind)
        {
            bool flag = lyr != null && plist.Count > 1;
            if (flag)
            {
                int pcount = plist.Count<PointLatLng>();
                GMapMarker1 marker = new GMapMarker1(centpoint, ind.ToString(), GMarkerGoogleType.arrow);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = string.Format("{0},{1:f5},{2:f5}", ind, centpoint.Lng, centpoint.Lat);
                GMapPolygon polygon = new GMapPolygon(plist, "ploy" + ind.ToString());
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 0.5f);
                polygon.IsHitTestVisible = true;
                polygon.ToString();
                lyr.Polygons.Add(polygon);
            }
        }

        //非常重要，GMAP上，实时无人机当前位置
        public static void MapPloyLine2(GMapOverlay lyr, PointLatLng plg, Color col, int flynum)
        {
            flytransmarker[flynum - 1].Position = plg;
            flytranscount[flynum - 1] = 1;
        }

        //非常重要，GMAP上，实时绘制无人机轨迹
        public static void MapPloyLine3(GMapOverlay lyr, List<PointLatLng> plg, Color col, int flynum)
        {
            bool flag = plg.Count <= 0;
            if (!flag)
            {
                bool flag2 = lyr != null && plg.Count - flytranscount[flynum - 1] > 0;
                if (flag2)
                {
                    List<PointLatLng> list = new List<PointLatLng>();
                    bool flag3 = flytranscount[flynum - 1] > 0;
                    if (flag3)
                    {
                        list.Add(plg[flytranscount[flynum - 1] - 1]);
                    }
                    list.Add(plg[plg.Count - 1]);
                    GMapRoute route = new GMapRoute(list, "line3");
                    route.Stroke = new Pen(col, 2f);
                    //route.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    lyr.Routes.Add(route);
                    flytransmarker[flynum - 1].Position = plg[plg.Count - 1];
                    flytranscount[flynum - 1] = plg.Count;
                }
            }
        }

        public static bool FormCheck(string formname)
        {
            foreach (object obj in Application.OpenForms)
            {
                Form f = (Form)obj;
                bool flag = f.Name == formname;
                if (flag)
                {
                    f.WindowState = FormWindowState.Normal;
                    f.Visible = true;
                    f.Activate();
                    return true;
                }
            }
            return false;
        }

        public static string MapScaleConversion(int value)
        {
            string str = "";
            switch (value)
            {
                case 3:
                    str = "1000KM";
                    break;
                case 4:
                    str = "500KM";
                    break;
                case 5:
                    str = "250KM";
                    break;
                case 6:
                    str = "120KM";
                    break;
                case 7:
                    str = "60KM";
                    break;
                case 8:
                    str = "16KM";
                    break;
                case 9:
                    str = "15KM";
                    break;
                case 10:
                    str = "8KM";
                    break;
                case 11:
                    str = "4KM";
                    break;
                case 12:
                    str = "2KM";
                    break;
                case 13:
                    str = "1KM";
                    break;
                case 14:
                    str = "500M";
                    break;
                case 15:
                    str = "250M";
                    break;
                case 16:
                    str = "120M";
                    break;
                case 17:
                    str = "60M";
                    break;
                case 18:
                    str = "30M";
                    break;
                case 19:
                    str = "15M";
                    break;
                case 20:
                    str = "8M";
                    break;
                case 21:
                    str = "4M";
                    break;
                case 22:
                    str = "2M";
                    break;
                case 23:
                    str = "1M";
                    break;
            }
            return str;
        }

        public static void SystermTurnOff(string cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(cmd);
            string sOutput = p.StandardOutput.ReadLine();
        }

        public static void OutPorcess(string procename, string arg, string procepath)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = procename,
                    Arguments = arg,
                    WindowStyle = ProcessWindowStyle.Normal,
                    WorkingDirectory = procepath
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("进程启动失败：" + ex.Message);
            }
        }

        //lijinfeng 非常重要 地磁校准
        public static void CompassDataSend()
        {
            return;
        }

        public static List<TestPoint> taskpoint = null;
        public static List<TestPoint> taskpoint0 = new List<TestPoint>();
        public static List<TestPoint> taskpoint1 = new List<TestPoint>();
        public static List<TestPoint> taskpoint2 = new List<TestPoint>();
        public static List<TestPoint> taskpoint3 = new List<TestPoint>();
        public static List<TestPoint> taskpoint4 = new List<TestPoint>();
        public static List<TestPoint> taskpoint5 = new List<TestPoint>();
        public static TestPoint taskpointdefault1 = new TestPoint();
        public static Dictionary<int, TestPoint> taskpointdefault = new Dictionary<int, TestPoint>();
        public static int taskindexchange;
        public static List<TestArea> taskarea = null;
        public static List<TestArea> taskarea0 = new List<TestArea>();
        public static List<TestArea> taskarea1 = new List<TestArea>();
        public static List<TestArea> taskarea2 = new List<TestArea>();
        public static List<TestArea> taskarea3 = new List<TestArea>();
        public static List<TestArea> taskarea4 = new List<TestArea>();
        public static List<TestArea> taskarea5 = new List<TestArea>();
        public static List<PointLatLng> mFlyData = new List<PointLatLng>();
        public static List<PointLatLng> mFlyData1 = new List<PointLatLng>();
        public static List<PointLatLng> mFlyData2 = new List<PointLatLng>();
        public static List<PointLatLng> mFlyData3 = new List<PointLatLng>();
        public static List<PointLatLng> mFlyData4 = new List<PointLatLng>();
        public static List<PointLatLng> mFlyData5 = new List<PointLatLng>();
        public static List<PointLatLng> obstaclist = new List<PointLatLng>();
        public static List<List<PointLatLng>> obstaclists = new List<List<PointLatLng>>();
        public static int obstaclistsindex = 0;
        public static List<GMapMarkerCircle> obstaccircles = new List<GMapMarkerCircle>();
        public static bool obstacflg = false;
        public static TestPoint trackdatanow;
        public static int[] flytranscount = new int[5];
        public static GMapMarkerImage[] flytransmarker = new GMapMarkerImage[5];
        public static bool areamoveflg = false;

        public static Dictionary<int, bool> istaskupload = new Dictionary<int, bool>();
        public static int[] flightcurrentindex = new int[]
        {
            -1,
            -1,
            -1,
            -1,
            -1,
            -1
        };
        public static bool istelcal = false;
        public static string idnum = "";
        public static bool isallset = false;
        public static bool istransopen = false;
        public static bool istaskformopen = false;
        public static int downcount = 0;

        //lijinfeng
        public static string pathstrgeoma = "\\history\\";
        public static byte rangecount = 0;
        public static int test1 = 0;
        public static List<PointLatLng> offsetlist = new List<PointLatLng>();
        public static bool flgoffset = false;

        public static GMarkerGoogleType[] colorfly = new GMarkerGoogleType[]
        {
            GMarkerGoogleType.green,
            GMarkerGoogleType.red,
            GMarkerGoogleType.blue,
            GMarkerGoogleType.orange,
            GMarkerGoogleType.pink,
            GMarkerGoogleType.yellow
        };

        //byte[]转换为struct
        public static object BytesToStruct(byte[] bytes, Type strcutType)
        {
            int size = Marshal.SizeOf(strcutType);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return Marshal.PtrToStructure(buffer, strcutType);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        public static List<List<PointLatLng>> isnotflyareas = new List<List<PointLatLng>>();
        public static List<List<PointLatLng>> isnotflyarea = new List<List<PointLatLng>>();
        public static GMapControl gMap;
        public static string[,] trackMagName = new string[13, 3];
    }
}
