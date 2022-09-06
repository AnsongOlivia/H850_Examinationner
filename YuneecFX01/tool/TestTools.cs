using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using YuneecFX01.map.GMap;
using YuneecFX01.system;

namespace YuneecFX01.tool
{
    public class GetObstacPoints
    {
        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }
        public double Distance
        {
            get
            {
                return this.distance;
            }
            set
            {
                this.distance = value;
            }
        }

        public int[] GetArray()
        {
            int[] arr = new int[this.plist.Count];
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = 1;
            }
            return arr;
        }

        private int index;

        private double distance;

        public List<PointLatLng> plist = new List<PointLatLng>();
    }

    public class TestArea
    {
        [ReadOnly(true)]
        [DisplayName("标号")]
        public byte Index { get; set; }
        [DisplayName("经度")]
        public double Lonx { get; set; }

        [DisplayName("纬度")]
        public double Laty { get; set; }

        private byte index;

        private double lonx;

        private double laty;
    }

    [Serializable]
    public class TestPoint
    {
        public TestPoint()
        {
            TestPoint.titleCrow[0] = "标号";
            TestPoint.titleCrow[1] = "经度";
            TestPoint.titleCrow[2] = "纬度";
            TestPoint.titleCrow[3] = "高度";
            TestPoint.titleCrow[4] = "水平速度";
            TestPoint.titleCrow[5] = "垂直速度";
            TestPoint.titleCrow[6] = "转弯模式";
            TestPoint.titleCrow[7] = "路径模式";
            TestPoint.titleCrow[8] = "机头朝向";
            TestPoint.titleCrow[9] = "悬停时间";
            TestPoint.titleCrowEnglish[0] = "Index";
            TestPoint.titleCrowEnglish[1] = "Lon";
            TestPoint.titleCrowEnglish[2] = "Lat";
            TestPoint.titleCrowEnglish[3] = "Height";
            TestPoint.titleCrowEnglish[4] = "LevelV";
            TestPoint.titleCrowEnglish[5] = "VerticalV";
            TestPoint.titleCrowEnglish[6] = "TurnM";
            TestPoint.titleCrowEnglish[7] = "RouteM";
            TestPoint.titleCrowEnglish[8] = "Yaw";
            TestPoint.titleCrowEnglish[9] = "HoverT";
        }
        
        [Category("位置属性")]
        [ReadOnly(true)]
        [DisplayName("标号")]
        [Description("显示标号")]
        public ushort TIndex
        {
            get
            {
                return this.tindex;
            }
            set
            {
                this.tindex = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("经度")]
        [Description("设置经度")]
        public double TPx
        {
            get
            {
                return this.tmappoint.Lng;
            }
            set
            {
                this.tmappoint.Lng = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("纬度")]
        [Description("设置纬度")]
        public double TPy
        {
            get
            {
                return this.tmappoint.Lat;
            }
            set
            {
                this.tmappoint.Lat = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("高度")]
        [Description("设置高度(m)")]
        public float TSeaHigh
        {
            get
            {
                return this.tseahigh;
            }
            set
            {
                this.tseahigh = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("水平速度")]
        [Description("设置水平速度(m/s)")]
        public float TLevelSpeed
        {
            get
            {
                return this.tlevelspeed;
            }
            set
            {
                this.tlevelspeed = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("垂直速度")]
        [Description("设置垂直速度(m/s)")]
        [Browsable(true)]
        public float Tverticalspeed
        {
            get
            {
                return this.tverticalspeed;
            }
            set
            {
                this.tverticalspeed = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("直线速度")]
        [Description("设置直线速度(m/s)")]
        [Browsable(false)]
        public float Tlinespeed
        {
            get
            {
                return this.tlinespeed;
            }
            set
            {
                this.tlinespeed = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("转弯模式")]
        [Description("设置转弯模式")]
        [Browsable(true)]
        public byte Tswervemode
        {
            get
            {
                return this.tswervemode;
            }
            set
            {
                this.tswervemode = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("路径模式")]
        [Description("设置路径模式")]
        [Browsable(true)]
        public byte Troutemode
        {
            get
            {
                return this.troutemode;
            }
            set
            {
                this.troutemode = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("机头朝向")]
        [Description("设置机头朝向")]
        [Browsable(true)]
        public float Tflyheading
        {
            get
            {
                return this.tflyheading;
            }
            set
            {
                this.tflyheading = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("云台俯仰")]
        [Description("设置云台俯仰")]
        [Browsable(false)]
        public float Tyuntaipitch
        {
            get
            {
                return this.tyuntaipitch;
            }
            set
            {
                this.tyuntaipitch = value;
            }
        }
        
        [Category("位置属性")]
        [DisplayName("云台偏航")]
        [Description("设置云台偏航")]
        [Browsable(false)]
        public float Tyuntaiyaw
        {
            get
            {
                return this.tyuntaiyaw;
            }
            set
            {
                this.tyuntaiyaw = value;
            }
        }

        [Category("位置属性")]
        [DisplayName("悬停时间")]
        [Description("设置悬停时间(m/s)")]
        [Browsable(true)]
        public byte Tstoptime
        {
            get
            {
                return this.tstoptime;
            }
            set
            {
                this.tstoptime = value;
            }
        }
        
        [Browsable(false)]
        public PointLatLng Tmpoint
        {
            get
            {
                return this.tmappoint;
            }
        }
        
        public byte[] Tobytes()
        {
            byte[] result = new byte[32];
            byte[] c = new byte[4];
            c = BitConverter.GetBytes(this.tindex);
            result[0] = c[1];
            result[1] = c[0];
            result[2] = this.tswervemode;
            result[3] = this.troutemode;
            short num = Convert.ToInt16(this.tseahigh * 5f);
            c = BitConverter.GetBytes(num);
            result[4] = c[0];
            result[5] = c[1];
            ushort unum = Convert.ToUInt16(this.tflyheading * 100f);
            c = BitConverter.GetBytes(unum);
            result[6] = c[0];
            result[7] = c[1];
            double[] tmp = new double[]
            {
                this.tmappoint.Lng,
                this.tmappoint.Lat
            };
            //lijinfeng
            //Array.Copy(Package.DoublesToBytes(tmp), 0, result, 8, tmp.Length * 8);
            num = Convert.ToInt16(this.tyuntaipitch * 100f);
            c = BitConverter.GetBytes(num);
            result[24] = c[0];
            result[25] = c[1];
            num = Convert.ToInt16(this.tyuntaiyaw * 100f);
            c = BitConverter.GetBytes(num);
            result[26] = c[0];
            result[27] = c[1];
            result[28] = this.Tstoptime;
            result[29] = Convert.ToByte(this.tverticalspeed * 5f);
            result[30] = Convert.ToByte(this.tlevelspeed * 5f);
            result[31] = Convert.ToByte(this.tlinespeed * 5f);
            return result;
        }
        
        public void clear()
        {
            this.tindex = 0;
            this.tmappoint.Lng = 0.0;
            this.tmappoint.Lat = 0.0;
            this.tseahigh = 0f;
            this.tlevelspeed = 0f;
        }
        
        public TestPoint copy()
        {
            return new TestPoint
            {
                tindex = this.tindex,
                tmappoint = this.tmappoint,
                tseahigh = this.tseahigh,
                tswervemode = this.tswervemode,
                troutemode = this.troutemode,
                tflyheading = this.tflyheading,
                tyuntaipitch = this.tyuntaipitch,
                tyuntaiyaw = this.tyuntaiyaw,
                tstoptime = this.tstoptime,
                tlevelspeed = this.tlevelspeed,
                tverticalspeed = this.tverticalspeed,
                tlinespeed = this.tlinespeed
            };
        }

        private ushort tindex;
        private PointLatLng tmappoint = default(PointLatLng);
        private float tseahigh = 0f;
        private byte tswervemode = 0;
        private byte troutemode = 0;
        private float tflyheading = 0f;
        private float tyuntaipitch = 0f;
        private float tyuntaiyaw = 0f;
        private byte tstoptime = 0;
        private float tlevelspeed = 0f;
        private float tverticalspeed = 0f;
        private float tlinespeed = 0f;
        public static string[] titleCrow = new string[10];
        public static string[] titleCrowEnglish = new string[10];
    }

    internal class TestTools
	{
		public static PointLatLng[] TaskLinePlan(PointLatLng[] parea, ref List<int> sparypoint, int index, double with, byte type, double reducelenth, double reduceobstacle)
		{
			PointLatLng potstart = parea[index];
			PointLatLng[] ptmp = new PointLatLng[parea.Length];
			List<PointLatLng> potreturn = new List<PointLatLng>();
			List<PointLatLng> potright = new List<PointLatLng>();
			List<PointLatLng> potleft = new List<PointLatLng>();
			int ct = 0;
			for (int i = 0; i < parea.Length; i++)
			{
				bool flag = index + i < parea.Length;
				if (flag)
				{
					ptmp[i] = parea[index + i];
					ct = i;
				}
				else
				{
					ptmp[i] = parea[i - (ct + 1)];
				}
			}
			ptmp = TestTools.PolygonRduce(ptmp, reducelenth);
			int ctype = TestTools.convex(ptmp);
			bool flag2 = ctype != 1;
			PointLatLng[] result;
			if (flag2)
			{
				result = null;
			}
			else
			{
				bool flag3 = type == 2;
				if (flag3)
				{
					PointLatLng[] ptmp2 = new PointLatLng[parea.Length];
					ptmp2[0] = ptmp[0];
					for (int j = 1; j < ptmp.Length; j++)
					{
						ptmp2[j] = ptmp[ptmp.Length - j];
					}
					ptmp = ptmp2;
				}
				potreturn.Add(ptmp[0]);
				potreturn.Add(ptmp[1]);
				double[] lenthlist = new double[ptmp.Length - 2];
				for (int k = 0; k < ptmp.Length - 2; k++)
				{
					lenthlist[k] = TestTools.PointToLine(ptmp[k + 2].Lng, ptmp[k + 2].Lat, ptmp[0].Lng, ptmp[0].Lat, ptmp[1].Lng, ptmp[1].Lat);
				}
				double lenmax = 0.0;
				int islenmax = 0;
				for (int l = 0; l < lenthlist.Length; l++)
				{
					bool flag4 = lenmax < lenthlist[l];
					if (flag4)
					{
						lenmax = lenthlist[l];
						islenmax = l;
					}
				}
				double kwith = with;
				bool flag5 = ptmp[0].Lng - ptmp[1].Lng == 0.0;
				if (flag5)
				{
					PointLatLng[] array = ptmp;
					int num = 1;
					array[num].Lng = array[num].Lng + 1E-07;
				}
				double k2 = (ptmp[1].Lat - ptmp[0].Lat) / (ptmp[1].Lng - ptmp[0].Lng);
				bool flag6 = ptmp[0].Lat - ptmp[1].Lat > 0.0;
				double suz;
				if (flag6)
				{
					suz = TestTools.s3point(ptmp[1], ptmp[0], ptmp[2]);
				}
				else
				{
					bool flag7 = ptmp[0].Lat - ptmp[1].Lat < 0.0;
					if (flag7)
					{
						suz = TestTools.s3point(ptmp[0], ptmp[1], ptmp[2]);
					}
					else
					{
						suz = ptmp[2].Lat - ptmp[0].Lat;
					}
				}
				bool flag8 = suz > 0.0 && k2 < 0.0;
				if (flag8)
				{
					kwith = -kwith;
				}
				else
				{
					bool flag9 = suz < 0.0 && k2 > 0.0;
					if (flag9)
					{
						kwith = -kwith;
					}
				}
				bool flag10 = k2 == 0.0 && suz < 0.0;
				if (flag10)
				{
					kwith = -kwith;
				}
				int inc = 0;
				for (int m = 0; m < (int)(lenthlist[islenmax] / with); m++)
				{
					bool flag11 = inc > islenmax;
					if (flag11)
					{
						break;
					}
					bool flag12 = (double)(m + 1) * with < lenthlist[inc];
					if (flag12)
					{
						decimal[] lin = TestTools.lineb(ptmp[0], ptmp[1], (double)(m + 1) * kwith);
						PointLatLng tx = TestTools.klpoint(lin[0], lin[1], ptmp[1 + inc], ptmp[2 + inc]);
						potright.Add(tx);
					}
					else
					{
						inc++;
						m--;
					}
				}
				inc = 0;
				for (int n = 0; n < (int)(lenthlist[islenmax] / with); n++)
				{
					bool flag13 = lenthlist.Length - inc < islenmax;
					if (flag13)
					{
						break;
					}
					bool flag14 = (double)(n + 1) * with < lenthlist[lenthlist.Length - 1 - inc];
					if (flag14)
					{
						decimal[] lin2 = TestTools.lineb(ptmp[0], ptmp[1], (double)(n + 1) * kwith);
						PointLatLng tx2 = default(PointLatLng);
						bool flag15 = inc == 0;
						if (flag15)
						{
							tx2 = TestTools.klpoint(lin2[0], lin2[1], ptmp[0], ptmp[ptmp.Length - inc - 1]);
						}
						else
						{
							tx2 = TestTools.klpoint(lin2[0], lin2[1], ptmp[ptmp.Length - inc], ptmp[ptmp.Length - inc - 1]);
						}
						potleft.Add(tx2);
					}
					else
					{
						inc++;
						n--;
					}
				}
				potreturn.AddRange(potright);
				for (int i2 = 0; i2 < potleft.Count; i2++)
				{
					bool flag16 = i2 % 2 == 0;
					if (flag16)
					{
						potreturn.Insert(3 + i2 * 2, potleft[i2]);
					}
					else
					{
						potreturn.Insert(2 + i2 * 2, potleft[i2]);
					}
				}
				sparypoint.AddRange(new int[potreturn.Count]);
				bool flag17 = sysFunction.obstaccircles.Count <= 0 && sysFunction.obstaclists.Count <= 0;
				if (flag17)
				{
					result = potreturn.ToArray();
				}
				else
				{
					List<List<PointLatLng>> obslists = new List<List<PointLatLng>>();
					for (int i3 = 0; i3 < sysFunction.obstaclists.Count; i3++)
					{
						obslists.Add(new List<PointLatLng>());
						List<PointLatLng> tlist = new List<PointLatLng>();
						for (int j2 = 0; j2 < sysFunction.obstaclists[i3].Count; j2++)
						{
							double lat = (TestTools.rad(sysFunction.obstaclists[i3][j2].Lat) - TestTools.invpoint.Lat) / TestTools.invDisLat;
							double lng = (TestTools.rad(sysFunction.obstaclists[i3][j2].Lng) - TestTools.invpoint.Lng) / TestTools.invDisLon;
							PointLatLng pts = new PointLatLng(lat, lng);
							tlist.Add(pts);
						}
						bool flag18 = tlist.Count > 2;
						if (flag18)
						{
							obslists[i3].AddRange(TestTools.PolygonRduce(tlist.ToArray(), reduceobstacle));
							obslists[i3].Add(obslists[i3][0]);
						}
					}
					for (int i4 = 0; i4 < sysFunction.obstaccircles.Count; i4++)
					{
						PointLatLng[] pob = TestTools.ObstaclCirclTOPoint(sysFunction.obstaccircles[i4]);
						obslists.Add(new List<PointLatLng>(TestTools.PolygonRduce(pob, reduceobstacle)));
						obslists[obslists.Count - 1].Add(obslists[obslists.Count - 1][0]);
					}
					PointLatLng[] potlist = new PointLatLng[potreturn.Count + 1];
					Array.Copy(potreturn.ToArray(), 0, potlist, 0, potlist.Length - 1);
					potlist[potlist.Length - 1] = potreturn[0];
					inc = 0;
					bool flag19 = obslists.Count > 0;
					if (flag19)
					{
						List<GetObstacPoints> getobstacpoints = new List<GetObstacPoints>();
						for (int i5 = 0; i5 < potlist.Length - 2; i5++)
						{
							for (int j3 = 0; j3 < obslists.Count; j3++)
							{
								double lentmp = 0.0;
								PointLatLng[] tmp = TestTools.PointLineObstacle(obslists[j3].ToArray(), potlist[i5], potlist[i5 + 1], ref lentmp);
								bool flag20 = tmp.Length != 0;
								if (flag20)
								{
									GetObstacPoints getobstacpoint = new GetObstacPoints();
									getobstacpoint.Distance = lentmp;
									getobstacpoint.plist.AddRange(tmp);
									getobstacpoints.Add(getobstacpoint);
								}
							}
							getobstacpoints.Sort((GetObstacPoints a, GetObstacPoints b) => a.Distance.CompareTo(b.Distance));
							for (int n2 = 0; n2 < getobstacpoints.Count; n2++)
							{
								potreturn.InsertRange(i5 + 1 + inc, getobstacpoints[n2].plist.ToArray());
								sparypoint.InsertRange(i5 + 1 + inc, getobstacpoints[n2].GetArray());
								inc += getobstacpoints[n2].plist.Count;
							}
							getobstacpoints.Clear();
						}
					}
					result = potreturn.ToArray();
				}
			}
			return result;
		}
        
		public static PointLatLng[] ObstaclCirclTOPoint(GMapMarkerCircle gmcircle)
		{
			PointLatLng midpoint = new PointLatLng(gmcircle.Position.Lat, gmcircle.Position.Lng);
			double r = (double)gmcircle.Radius;
			List<PointLatLng> result = new List<PointLatLng>();
			midpoint.Lat = (TestTools.rad(midpoint.Lat) - TestTools.invpoint.Lat) / TestTools.invDisLat;
			midpoint.Lng = (TestTools.rad(midpoint.Lng) - TestTools.invpoint.Lng) / TestTools.invDisLon;
			double midlen = r * Math.Tan(0.5235987755982988);
			double maxlen = 2.0 * midlen;
			result.Add(new PointLatLng(midpoint.Lat, midpoint.Lng - maxlen));
			result.Add(new PointLatLng(midpoint.Lat + r, midpoint.Lng - midlen));
			result.Add(new PointLatLng(midpoint.Lat + r, midpoint.Lng + midlen));
			result.Add(new PointLatLng(midpoint.Lat, midpoint.Lng + maxlen));
			result.Add(new PointLatLng(midpoint.Lat - r, midpoint.Lng + midlen));
			result.Add(new PointLatLng(midpoint.Lat - r, midpoint.Lng - midlen));
			return result.ToArray();
		}
        
		public static PointLatLng potcal(PointLatLng sourcepoint1, PointLatLng sourcepoint2, PointLatLng despoint1, PointLatLng despoint2, double with)
		{
			double k2 = (sourcepoint2.Lat - sourcepoint1.Lat) / (sourcepoint2.Lng - sourcepoint1.Lng);
			double angle = Math.Atan((sourcepoint2.Lat - sourcepoint1.Lat) / (sourcepoint2.Lng - sourcepoint1.Lng));
			double angle2 = Math.Atan((despoint2.Lat - despoint1.Lat) / (despoint2.Lng - despoint1.Lng));
			double anglesub = angle - angle2;
			double len12 = with / Math.Sin(anglesub);
			double dx = len12 * Math.Sin(angle2);
			double dy = len12 * Math.Cos(angle2);
			PointLatLng midpot = new PointLatLng(despoint1.Lat + dx, despoint1.Lng + dy);
			return midpot;
		}
        
		public static PointLatLng[] PolygonRduce(PointLatLng[] pointsSource, double lenthRduce)
		{
			int pointLen = pointsSource.Length;
			double[,] lineKb = new double[pointLen, 2];
			PointLatLng[] resultPoint = new PointLatLng[pointLen];
			PointLatLng[] arrsource = new PointLatLng[pointLen + 2];
			Array.Copy(pointsSource, 0, arrsource, 0, pointLen);
			arrsource[pointLen] = new PointLatLng(pointsSource[0].Lat, pointsSource[0].Lng);
			arrsource[pointLen + 1] = new PointLatLng(pointsSource[1].Lat, pointsSource[1].Lng);
			bool flag = lenthRduce == 0.0;
			PointLatLng[] result;
			if (flag)
			{
				result = pointsSource;
			}
			else
			{
				for (int i = 0; i < pointLen; i++)
				{
					bool flag2 = arrsource[i + 1].Lng - arrsource[i].Lng == 0.0;
					if (flag2)
					{
						PointLatLng[] array = arrsource;
						int num = i;
						array[num].Lng = array[num].Lng + 1E-07;
					}
					double ldirect = TestTools.LineDirect(arrsource[i], arrsource[i + 1], arrsource[i + 2]);
					bool flag3 = ldirect >= 0.0;
					if (flag3)
					{
						decimal[] tmp = TestTools.lineb(arrsource[i], arrsource[i + 1], lenthRduce);
						lineKb[i, 0] = (double)tmp[0];
						lineKb[i, 1] = (double)tmp[1];
					}
					else
					{
						decimal[] tmp2 = TestTools.lineb(arrsource[i], arrsource[i + 1], -lenthRduce);
						lineKb[i, 0] = (double)tmp2[0];
						lineKb[i, 1] = (double)tmp2[1];
					}
				}
				for (int j = 0; j < pointLen; j++)
				{
					bool flag4 = j + 1 == pointLen;
					if (flag4)
					{
						resultPoint[0] = TestTools.klpoint(lineKb[j, 0], lineKb[j, 1], lineKb[0, 0], lineKb[0, 1]);
					}
					else
					{
						resultPoint[j + 1] = TestTools.klpoint(lineKb[j, 0], lineKb[j, 1], lineKb[j + 1, 0], lineKb[j + 1, 1]);
					}
				}
				result = resultPoint;
			}
			return result;
		}
        
		public static double LineDirect(PointLatLng A, PointLatLng B, PointLatLng C)
		{
			bool flag = A.Lat > B.Lat;
			double isLeftOrRight;
			if (flag)
			{
				isLeftOrRight = TestTools.s3point(B, A, C);
			}
			else
			{
				bool flag2 = A.Lat - B.Lat == 0.0;
				if (flag2)
				{
					bool flag3 = A.Lng - B.Lng > 0.0;
					if (flag3)
					{
						isLeftOrRight = TestTools.s3point(B, A, C);
					}
					else
					{
						isLeftOrRight = TestTools.s3point(A, B, C);
					}
				}
				else
				{
					isLeftOrRight = TestTools.s3point(A, B, C);
				}
			}
			bool flag4 = A.Lng - B.Lng == 0.0;
			double result;
			if (flag4)
			{
				result = -isLeftOrRight;
			}
			else
			{
				double kAB = (A.Lat - B.Lat) / (A.Lng - B.Lng);
				bool flag5 = kAB >= 0.0;
				if (flag5)
				{
					result = isLeftOrRight;
				}
				else
				{
					result = -isLeftOrRight;
				}
			}
			return result;
		}
        
		public static decimal[] lineb(PointLatLng linp1, PointLatLng linp2, double with)
		{
			decimal[] tc = new decimal[2];
			bool flag = linp2.Lng - linp1.Lng == 0.0;
			decimal[] result;
			if (flag)
			{
				tc[0] = 0.0m;
				tc[1] = (decimal)with;
				result = tc;
			}
			else
			{
				decimal i = (decimal)((linp2.Lat - linp1.Lat) / (linp2.Lng - linp1.Lng));
				decimal b = (decimal)linp1.Lat - i * (decimal)linp1.Lng;
				decimal angle = (decimal)Math.Atan((double)i);
				decimal tp = (decimal)(with / Math.Cos((double)angle));
				tc[0] = i;
				tc[1] = b + tp;
				result = tc;
			}
			return result;
		}
        
		public static PointLatLng klpoint(PointLatLng pota1, PointLatLng pota2, PointLatLng potb1, PointLatLng potb2)
		{
			double ka = (pota2.Lat - pota1.Lat) / (pota2.Lng - pota1.Lng);
			double kb = (potb2.Lat - potb1.Lat) / (potb2.Lng - potb1.Lng);
			double pa = pota1.Lat - ka * pota1.Lng;
			double pb = potb1.Lat - kb * potb1.Lng;
			PointLatLng resultpoint = default(PointLatLng);
			bool flag = object.Equals(ka, kb);
			if (!flag)
			{
				resultpoint.Lng = (pa - pb) / (kb - ka);
				resultpoint.Lat = ka * resultpoint.Lng + pa;
			}
			return resultpoint;
		}
        
		public static PointLatLng klpoint(decimal k1, decimal b1, PointLatLng potb1, PointLatLng potb2)
		{
			PointLatLng resultpoint = default(PointLatLng);
			bool flag = double.IsNaN((double)k1);
			if (flag)
			{
				resultpoint.Lng = (double)b1;
				bool flag2 = potb2.Lng - potb1.Lng != 0.0;
				if (flag2)
				{
					double kb = (potb2.Lat - potb1.Lat) / (potb2.Lng - potb1.Lng);
					double pb = potb1.Lat - kb * potb1.Lng;
					resultpoint.Lat = kb * resultpoint.Lng + pb;
				}
			}
			bool flag3 = potb2.Lng - potb1.Lng != 0.0;
			PointLatLng result;
			if (flag3)
			{
				double kb = (potb2.Lat - potb1.Lat) / (potb2.Lng - potb1.Lng);
				double pb = potb1.Lat - kb * potb1.Lng;
				bool flag4 = object.Equals(k1, kb);
				if (flag4)
				{
					resultpoint.Lng = potb1.Lng;
					resultpoint.Lat = potb1.Lat;
					result = resultpoint;
				}
				else
				{
					resultpoint.Lng = (double)((b1 - (decimal)pb) / ((decimal)kb - k1));
					resultpoint.Lat = kb * resultpoint.Lng + pb;
					result = resultpoint;
				}
			}
			else
			{
				resultpoint.Lng = potb1.Lng;
				resultpoint.Lat = (double)(k1 * (decimal)resultpoint.Lng + b1);
				result = resultpoint;
			}
			return result;
		}
        
		public static PointLatLng klpoint(double k1, double b1, double k2, double b2)
		{
			PointLatLng resultpoint = default(PointLatLng);
			resultpoint.Lng = (b1 - b2) / (k2 - k1);
			resultpoint.Lat = k2 * resultpoint.Lng + b2;
			return resultpoint;
		}
        
		public static double LineDistance(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
		}
        
		public static double LineListDistance(PointLatLng[] linelist)
		{
			double result = 0.0;
			for (int i = 0; i < linelist.Length - 1; i++)
			{
				result += TestTools.LineDistance(linelist[i].Lng, linelist[i].Lat, linelist[i + 1].Lng, linelist[i + 1].Lat);
			}
			return result;
		}
        
		public static double LinePlaneDistance(PointLatLng[] linelist, PointLatLng start, PointLatLng end)
		{
			List<PointLatLng> plist = new List<PointLatLng>();
			plist.Add(start);
			plist.AddRange(linelist);
			plist.Add(end);
			return TestTools.LineListDistance(plist.ToArray());
		}
        
		private static double rad(double d)
		{
			return d * 3.141592653589793 / 180.0;
		}
        
		private static double revrad(double d)
		{
			return d * 180.0 / 3.141592653589793;
		}
        
		public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
		{
			double ln = TestTools.rad(lng1);
			double ln2 = TestTools.rad(lng2);
			double la = TestTools.rad(lat1);
			double la2 = TestTools.rad(lat2);
			double s = Math.Cos(1.5707963267948966 - la2) * Math.Cos(1.5707963267948966 - la) + Math.Sin(1.5707963267948966 - la2) * Math.Sin(1.5707963267948966 - la) * Math.Cos(ln2 - ln);
			bool flag = s > 1.0;
			if (flag)
			{
				s = 1.0;
			}
			else
			{
				bool flag2 = s < -1.0;
				if (flag2)
				{
					s = -1.0;
				}
			}
			return 6378140.0 * Math.Acos(s);
		}
        
		public static double GetDistance(PointLatLng p1, PointLatLng p2)
		{
			double ln = TestTools.rad(p1.Lng);
			double ln2 = TestTools.rad(p2.Lng);
			double la = TestTools.rad(p1.Lat);
			double la2 = TestTools.rad(p2.Lat);
			double s = Math.Cos(1.5707963267948966 - la2) * Math.Cos(1.5707963267948966 - la) + Math.Sin(1.5707963267948966 - la2) * Math.Sin(1.5707963267948966 - la) * Math.Cos(ln2 - ln);
			bool flag = s > 1.0;
			if (flag)
			{
				s = 1.0;
			}
			else
			{
				bool flag2 = s < -1.0;
				if (flag2)
				{
					s = -1.0;
				}
			}
			return 6378140.0 * Math.Acos(s);
		}

        /// <summary>
        /// 得到三个点的夹角角度
        /// </summary>
        public static double get3PointAngle(PointLatLng cen, PointLatLng first, PointLatLng second)
        {
            const double M_PI = 3.1415926535897;
            int quadrant = 0;//象限

            double ma_x = first.Lng - cen.Lng;
            double ma_y = first.Lat - cen.Lat;
            double mb_x = second.Lng - cen.Lng;
            double mb_y = second.Lat - cen.Lat;
            double v1 = (ma_x * mb_x) + (ma_y * mb_y);
            double ma_val = Math.Sqrt(ma_x * ma_x + ma_y * ma_y);
            double mb_val = Math.Sqrt(mb_x * mb_x + mb_y * mb_y);
            double cosM = v1 / (ma_val * mb_val);
            double angleAMB = Math.Acos(cosM) * 180 / M_PI;
            
            return angleAMB;
        }

        public static double PointToLine(double x0, double y0, double x1, double y1, double x2, double y2)
		{
			double a = TestTools.LineDistance(x1, y1, x2, y2);
			double b = TestTools.LineDistance(x1, y1, x0, y0);
			double c = TestTools.LineDistance(x2, y2, x0, y0);
			bool flag = c <= 1E-05 || b <= 1E-05;
			double result;
			if (flag)
			{
				double length = 1E-05;
				result = length;
			}
			else
			{
				bool flag2 = a <= 1E-05;
				if (flag2)
				{
					double length = b;
					result = length;
				}
				else
				{
					double p = (a + b + c) / 2.0;
					double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
					double length = 2.0 * s / a;
					result = length;
				}
			}
			return result;
		}
        
		public static PointLatLng CrossLinePoint(double pX, double pY, double lineAX, double lineAY, double lineBX, double lineBY, double len)
		{
			PointLatLng resultPoint = new PointLatLng(0.0, 0.0);
			bool flag = lineAY - lineBY == 0.0;
			PointLatLng result;
			if (flag)
			{
				resultPoint.Lng = pX;
				bool flag2 = pY < lineAY;
				if (flag2)
				{
					resultPoint.Lng = lineAY + len;
				}
				else
				{
					resultPoint.Lng = lineAY - len;
				}
				result = resultPoint;
			}
			else
			{
				bool flag3 = lineAX - lineBX == 0.0;
				if (flag3)
				{
					resultPoint.Lat = pY;
					bool flag4 = pX < lineAX;
					if (flag4)
					{
						resultPoint.Lng = lineAX + len;
					}
					else
					{
						resultPoint.Lng = lineAX - len;
					}
					result = resultPoint;
				}
				else
				{
					double kLine = (lineAY - lineBY) / (lineAX - lineBX);
					double kVline = -1.0 / kLine;
					double distance = TestTools.PointToLine(pX, pY, lineAX, lineAY, lineBX, lineBY);
					distance += len;
					double angle = Math.Atan(kVline);
					double dlenx = distance * Math.Cos(angle);
					double dleny = distance * Math.Sin(angle);
					double rightleft = TestTools.s3point(new PointLatLng(lineAY, lineAX), new PointLatLng(lineBY, lineBX), new PointLatLng(pX, pY));
					bool flag5 = rightleft > 0.0;
					if (flag5)
					{
						resultPoint.Lat = pY + dleny;
						resultPoint.Lng = pX + dlenx;
					}
					else
					{
						resultPoint.Lat = pY - dleny;
						resultPoint.Lng = pX - dlenx;
					}
					result = resultPoint;
				}
			}
			return result;
		}
        
		public static int JudgePointToLine(PointLatLng LinePntA, PointLatLng LinePntB, PointLatLng PntM)
		{
			int nResult = 0;
			double ax = LinePntB.Lng - LinePntA.Lng;
			double ay = LinePntB.Lat - LinePntA.Lat;
			double bx = PntM.Lng - LinePntA.Lng;
			double by = PntM.Lat - LinePntA.Lat;
			double judge = ax * by - ay * bx;
			bool flag = judge > 0.0;
			if (flag)
			{
				nResult = 1;
			}
			else
			{
				bool flag2 = judge < 0.0;
				if (flag2)
				{
					nResult = -1;
				}
			}
			return nResult;
		}
        
		public static double s2point(double k, double b, PointLatLng C)
		{
			PointLatLng pa = new PointLatLng(116.0 * k + b, 116.0);
			PointLatLng pb = new PointLatLng(118.0 * k + b, 118.0);
			return TestTools.s3point(pa, pb, C);
		}
        
		public static double s3point(PointLatLng A, PointLatLng B, PointLatLng C)
		{
			return (A.Lng - C.Lng) * (B.Lat - C.Lat) - (A.Lat - C.Lat) * (B.Lng - C.Lng);
		}
        
		public static int convex(PointLatLng[] plist)
		{
			int num = plist.Length;
			int flag = 0;
			bool flag2 = num < 3;
			int result;
			if (flag2)
			{
				result = 0;
			}
			else
			{
				for (int i = 0; i < num; i++)
				{
					int j = (i + 1) % num;
					int k = (i + 2) % num;
					double z = (plist[j].Lng - plist[i].Lng) * (plist[k].Lat - plist[j].Lat);
					z -= (plist[j].Lat - plist[i].Lat) * (plist[k].Lng - plist[j].Lng);
					bool flag3 = z < 0.0;
					if (flag3)
					{
						flag |= 1;
					}
					else
					{
						bool flag4 = z > 0.0;
						if (flag4)
						{
							flag |= 2;
						}
					}
					bool flag5 = flag == 3;
					if (flag5)
					{
						return -1;
					}
				}
				bool flag6 = flag != 0;
				if (flag6)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}
        
		public static bool IsIntersect(PointLatLng p1, PointLatLng p2, PointLatLng q1, PointLatLng q2)
		{
			bool flag = Math.Max(p1.Lng, p2.Lng) < Math.Min(q1.Lng, q2.Lng);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = Math.Min(p1.Lng, p2.Lng) > Math.Max(q1.Lng, q2.Lng);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = Math.Max(p1.Lat, p2.Lat) < Math.Min(q1.Lat, q2.Lat);
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = Math.Min(p1.Lat, p2.Lat) > Math.Max(q1.Lat, q2.Lat);
						if (flag4)
						{
							result = false;
						}
						else
						{
							double crossP1P2Q = TestTools.VectorKitsCross(p1, p2, q1);
							double crossP1Q2P2 = TestTools.VectorKitsCross(p1, q2, p2);
							double crossQ1Q2P = TestTools.VectorKitsCross(q1, q2, p1);
							double crossQ1P2Q2 = TestTools.VectorKitsCross(q1, p2, q2);
							bool isIntersect = crossP1P2Q * crossP1Q2P2 >= 0.0 && crossQ1Q2P * crossQ1P2Q2 >= 0.0;
							result = isIntersect;
						}
					}
				}
			}
			return result;
		}
        
		public static double VectorKitsCross(PointLatLng p1, PointLatLng p2, PointLatLng p3)
		{
			return (p1.Lng - p3.Lng) * (p2.Lat - p3.Lat) - (p2.Lng - p3.Lng) * (p1.Lat - p3.Lat);
		}
        
		public static int IsPointAvaliable(List<PointLatLng> plist, PointLatLng p1, PointLatLng p2)
		{
			int len = plist.Count<PointLatLng>() + 1;
			List<PointLatLng> ptm = new List<PointLatLng>();
			ptm.AddRange(plist.ToArray());
			ptm.Add(plist[0]);
			bool flag = len < 3;
			int result;
			if (flag)
			{
				MessageBox.Show("多边形必须大于等于三个点");
				result = 0;
			}
			else
			{
				for (int i = 1; i < len; i++)
				{
					bool flag2 = TestTools.IsIntersect(p1, p2, ptm[i], ptm[i - 1]);
					if (flag2)
					{
						return 1;
					}
				}
				result = 0;
			}
			return result;
		}
        
		public static bool isAvaliableAll(List<List<PointLatLng>> pplist, PointLatLng p1, PointLatLng p2)
		{
			int len = pplist.Count;
			bool flag = p2.Lat == 0.0 && p2.Lng == 0.0;
			if (flag)
			{
				for (int i = 0; i < len; i++)
				{
					bool flag2 = TestTools.isPointInPolygon(pplist[i].ToArray(), p1.Lng, p1.Lat);
					if (flag2)
					{
						return false;
					}
				}
			}
			else
			{
				for (int j = 0; j < len; j++)
				{
					bool flag3 = TestTools.IsPointAvaliable(pplist[j], p1, p2) == 1;
					if (flag3)
					{
						return false;
					}
				}
			}
			return true;
		}
        
		public static void isAvaliableArea()
		{
			double lzoom = GMapManager.gMapControl.Zoom;
			int minlen = 20000;
			switch ((int)lzoom)
			{
			case 15:
				minlen = 7000;
				break;
			case 16:
				minlen = 5000;
				break;
			case 17:
				minlen = 5000;
				break;
			case 18:
				minlen = 5000;
				break;
			case 19:
				minlen = 5000;
				break;
			}
			bool flag = sysFunction.isnotflyareas.Count > 0;
			if (flag)
			{
				bool flag2 = lzoom > 12.0;
				if (flag2)
				{
					int airlen = sysFunction.isnotflyareas.Count;
					PointLatLng pl = new PointLatLng(GMapManager.gMapControl.Position.Lat, GMapManager.gMapControl.Position.Lng);
					sysFunction.isnotflyarea.Clear();
					for (int i = 0; i < airlen; i++)
					{
						for (int j = 0; j < 12; j++)
						{
							double distance = TestTools.GetDistance(pl.Lat, pl.Lng, sysFunction.isnotflyareas[i][j].Lat, sysFunction.isnotflyareas[i][j].Lng);
							bool flag3 = distance < (double)minlen;
							if (flag3)
							{
								sysFunction.isnotflyarea.Add(sysFunction.isnotflyareas[i]);
								break;
							}
						}
					}
				}
				else
				{
					bool flag4 = sysFunction.isnotflyarea.Count < sysFunction.isnotflyareas.Count;
					if (flag4)
					{
						sysFunction.isnotflyarea.Clear();
						sysFunction.isnotflyarea.AddRange(sysFunction.isnotflyareas.ToArray());
					}
				}
				bool flag5 = GMapManager.NoFlyArea.Polygons.Count != sysFunction.isnotflyarea.Count;
				if (flag5)
				{
					GMapManager.NoFlyArea.Clear();
					for (int k = 0; k < sysFunction.isnotflyarea.Count; k++)
					{
						sysFunction.MapPloyNoFlyNone(GMapManager.NoFlyArea, sysFunction.isnotflyarea[k], sysFunction.isnotflyarea[k][0], 0);
					}
				}
			}
		}
        
		public static bool isPointInPolygon(PointLatLng[] pla, double x, double y)
		{
			int polySides = pla.Length;
			double[] polyX = new double[pla.Length];
			double[] polyY = new double[pla.Length];
			for (int i = 0; i < pla.Length; i++)
			{
				polyX[i] = pla[i].Lng;
				polyY[i] = pla[i].Lat;
			}
			int j = polySides - 1;
			bool result = false;
			for (int k = 0; k < polySides; k++)
			{
				bool flag = (polyY[k] < y && polyY[j] >= y) || (polyY[j] < y && polyY[k] >= y);
				if (flag)
				{
					bool flag2 = polyX[k] + (y - polyY[k]) / (polyY[j] - polyY[k]) * (polyX[j] - polyX[k]) < x;
					if (flag2)
					{
						result = !result;
					}
				}
				j = k;
			}
			return result;
		}
        
		public static PointLatLng[] CircleTo2D(PointLatLng[] plist)
		{
			double Dislat = 6352956.03096;
			double Dislon = TestTools.CalLon(TestTools.rad(plist[0].Lat)) * 57.2957795;
			TestTools.invDisLat = 1.0 / Dislat;
			TestTools.invDisLon = 1.0 / Dislon;
			TestTools.invpoint.Lat = TestTools.rad(plist[0].Lat);
			TestTools.invpoint.Lng = TestTools.rad(plist[0].Lng);
			PointLatLng[] result = new PointLatLng[plist.Length];
			for (int i = 0; i < plist.Length; i++)
			{
				result[i].Lng = TestTools.rad(plist[i].Lng) - TestTools.rad(plist[0].Lng);
				result[i].Lat = TestTools.rad(plist[i].Lat) - TestTools.rad(plist[0].Lat);
				result[i].Lng = result[i].Lng * Dislon;
				result[i].Lat = result[i].Lat * Dislat;
			}
			return result;
		}
        
		public static PointLatLng CircleTo2D(PointLatLng plist)
		{
			double Dislat = 6352956.03096;
			double Dislon = TestTools.CalLon(TestTools.rad(plist.Lat)) * 57.2957795;
			TestTools.invDisLat = 1.0 / Dislat;
			TestTools.invDisLon = 1.0 / Dislon;
			TestTools.invpoint.Lat = TestTools.rad(plist.Lat);
			TestTools.invpoint.Lng = TestTools.rad(plist.Lng);
			PointLatLng result = new PointLatLng(0.0, 0.0);
			return result;
		}
        
		public static PointLatLng[] D2ToCricle(PointLatLng[] plist)
		{
			PointLatLng[] result = new PointLatLng[plist.Length];
			for (int i = 0; i < plist.Length; i++)
			{
				result[i].Lng = plist[i].Lng * TestTools.invDisLon;
				result[i].Lat = plist[i].Lat * TestTools.invDisLat;
				PointLatLng[] array = result;
				int num = i;
				array[num].Lng = array[num].Lng + TestTools.invpoint.Lng;
				PointLatLng[] array2 = result;
				int num2 = i;
				array2[num2].Lat = array2[num2].Lat + TestTools.invpoint.Lat;
				result[i].Lng = TestTools.revrad(result[i].Lng);
				result[i].Lat = TestTools.revrad(result[i].Lat);
			}
			return result;
		}
        
		public static PointLatLng D2ToCricle(PointLatLng plist)
		{
			PointLatLng result = default(PointLatLng);
			result.Lng = plist.Lng * TestTools.invDisLon;
			result.Lat = plist.Lat * TestTools.invDisLat;
			result.Lng += TestTools.invpoint.Lng;
			result.Lat += TestTools.invpoint.Lat;
			result.Lng = TestTools.revrad(result.Lng);
			result.Lat = TestTools.revrad(result.Lat);
			return result;
		}
        
		public static double CalLon(double CalLon_W)
		{
			return (111.413 * Math.Cos(CalLon_W) - 0.094 * Math.Cos(3.0 * CalLon_W)) * 1000.0;
		}
        
		public static double CalLat(double CalLat_W)
		{
			return (111.133 - 0.559 * Math.Cos(2.0 * CalLat_W)) * 1000.0;
		}
        
		public static void AreaWorkMove(double lon, double lat)
		{
			PointLatLng[] potara = new PointLatLng[sysFunction.taskarea.Count - 1];
			for (int i = 0; i < sysFunction.taskarea.Count - 1; i++)
			{
				potara[i] = new PointLatLng(sysFunction.taskarea[i].Laty, sysFunction.taskarea[i].Lonx);
			}
			potara = TestTools.CircleTo2D(potara);
			for (int j = 0; j < potara.Length; j++)
			{
				PointLatLng[] array = potara;
				int num = j;
				array[num].Lng = array[num].Lng + lon;
				PointLatLng[] array2 = potara;
				int num2 = j;
				array2[num2].Lat = array2[num2].Lat + lat;
			}
			potara = TestTools.D2ToCricle(potara);
			for (int k = 0; k < potara.Length; k++)
			{
				sysFunction.taskarea[k].Lonx = potara[k].Lng;
				sysFunction.taskarea[k].Laty = potara[k].Lat;
			}
            //lijinfeng
            //sysFunction.MapPloyLine2(GMapManager.areaOverlay, sysFunction.taskarea);
        }
        
        public static PointLatLng[] AreaMove(PointLatLng[] spoint, double lon, double lat)
		{
			PointLatLng[] potara = TestTools.CircleTo2D(spoint);
			for (int i = 0; i < potara.Length; i++)
			{
				PointLatLng[] array = potara;
				int num = i;
				array[num].Lng = array[num].Lng + lon;
				PointLatLng[] array2 = potara;
				int num2 = i;
				array2[num2].Lat = array2[num2].Lat + lat;
			}
			return TestTools.D2ToCricle(potara);
		}
        
		public static PointLatLng[] PointLineObstacle(PointLatLng[] potObstacles, PointLatLng A, PointLatLng B, ref double lennear)
		{
			List<PointLatLng> resultpoint = new List<PointLatLng>();
			List<PointLatLng> point = new List<PointLatLng>();
			List<int> bindex = new List<int>();
			for (int i = 0; i < potObstacles.Length - 1; i++)
			{
				bool flag = TestTools.IsIntersect(A, B, potObstacles[i], potObstacles[i + 1]);
				if (flag)
				{
					point.Add(TestTools.klpoint(A, B, potObstacles[i], potObstacles[i + 1]));
					bindex.Add(i);
				}
			}
			bool flag2 = point.Count > 0;
			if (flag2)
			{
				double dis = TestTools.LineDistance(point[0].Lng, point[0].Lat, A.Lng, A.Lat);
				bool flag3 = point.Count > 1;
				double dis2;
				if (flag3)
				{
					dis2 = TestTools.LineDistance(point[1].Lng, point[1].Lat, A.Lng, A.Lat);
				}
				else
				{
					dis2 = dis;
				}
				bool flag4 = dis - dis2 == 0.0;
				if (flag4)
				{
					resultpoint.Add(point[0]);
					lennear = dis;
				}
				else
				{
					bool flag5 = dis > dis2;
					if (flag5)
					{
						lennear = dis2;
						PointLatLng[] tmp = TestTools.ObstacleDistanceShort(bindex.ToArray(), potObstacles, point.ToArray());
						Array.Reverse(tmp);
						resultpoint.AddRange(tmp);
					}
					else
					{
						lennear = dis;
						PointLatLng[] tmp2 = TestTools.ObstacleDistanceShort(bindex.ToArray(), potObstacles, point.ToArray());
						resultpoint.AddRange(tmp2);
					}
				}
			}
			return resultpoint.ToArray();
		}
        
		public static PointLatLng[] ObstacleDistanceShort(int[] bindex, PointLatLng[] potObstacles, PointLatLng[] point)
		{
			PointLatLng[] arr = new PointLatLng[bindex[1] - bindex[0]];
			PointLatLng[] arr2 = new PointLatLng[potObstacles.Length - 1 - arr.Length];
			List<PointLatLng> resultpoint = new List<PointLatLng>();
			resultpoint.AddRange(point);
			for (int i = 0; i < bindex[1] - bindex[0]; i++)
			{
				arr[i] = potObstacles[bindex[0] + i + 1];
			}
			for (int j = 0; j < bindex[0] + 1; j++)
			{
				arr2[j] = potObstacles[bindex[0] - j];
			}
			for (int k = 0; k < potObstacles.Length - 1 - bindex[1]; k++)
			{
				bool flag = k + bindex[0] + 1 < arr2.Length;
				if (flag)
				{
					arr2[k + bindex[0] + 1] = potObstacles[potObstacles.Length - 2 - k];
				}
			}
			double s = TestTools.LinePlaneDistance(arr, point[0], point[1]);
			double s2 = TestTools.LinePlaneDistance(arr2, point[0], point[1]);
			bool flag2 = s <= s2;
			if (flag2)
			{
				resultpoint.InsertRange(1, arr);
			}
			else
			{
				resultpoint.InsertRange(1, arr2);
			}
			return resultpoint.ToArray();
		}
        
		public static double GetPolygonArea(PointLatLng[] sdata)
		{
			int plen = sdata.Length;
			bool flag = plen < 3;
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				PointLatLng[] plist = TestTools.CircleTo2D(sdata);
				double s = plist[0].Lat * (plist[plen - 1].Lng - plist[1].Lng);
				for (int i = 1; i < plen; i++)
				{
					s += plist[i].Lat * (plist[i - 1].Lng - plist[(i + 1) % plen].Lng);
				}
				result = Math.Abs(s / 2.0);
			}
			return result;
		}
        
		public static PointLatLng GetNextPoint(double angle, float lenth, PointLatLng sourcepoint)
		{
			PointLatLng spoint = TestTools.CircleTo2D(sourcepoint);
			PointLatLng resultpoint = default(PointLatLng);
			double radian = TestTools.rad(angle);
			resultpoint.Lng = spoint.Lng + (double)lenth * Math.Sin(radian);
			resultpoint.Lat = spoint.Lat + (double)lenth * Math.Cos(radian);
			resultpoint = TestTools.D2ToCricle(resultpoint);
			PointLatLng testp = TestTools.D2ToCricle(spoint);
			return resultpoint;
		}
        
		public static double GetAngle(PointLatLng cen, PointLatLng p1, PointLatLng p2)
		{
			PointLatLng[] cpoint = TestTools.CircleTo2D(new List<PointLatLng>
			{
				cen,
				p1,
				p2
			}.ToArray());
			double px = cpoint[1].Lng - cpoint[0].Lng;
			double py = cpoint[1].Lat - cpoint[0].Lat;
			double px2 = cpoint[2].Lng - cpoint[0].Lng;
			double py2 = cpoint[2].Lat - cpoint[0].Lat;
			double v = px * px2 + py * py2;
			double m = Math.Sqrt(px * px + py * py);
			double m2 = Math.Sqrt(px2 * px2 + py2 * py2);
			bool flag = m == 0.0;
			if (flag)
			{
				m = 1E-09;
			}
			bool flag2 = m2 == 0.0;
			if (flag2)
			{
				m2 = 1E-09;
			}
			double cosa = v / (m * m2);
			double angle = Math.Acos(cosa) * 180.0 / 3.141592653589793;
			PointLatLng A = new PointLatLng(cen.Lat - p1.Lat, cen.Lng - p1.Lng);
			PointLatLng B = new PointLatLng(p2.Lat - cen.Lat, p2.Lng - cen.Lng);
			double z = A.Lng * B.Lat - B.Lng * A.Lat;
			bool flag3 = z < 0.0;
			if (flag3)
			{
				angle = 360.0 - angle;
			}
			return angle;
		}
        
		public static TestPoint[] TrackFlyRevolve(TestPoint[] tlist, double angel)
		{
			int count = tlist.Length - 1;
			List<PointLatLng> pa = new List<PointLatLng>();
			for (int i = 0; i < count; i++)
			{
				pa.Add(new PointLatLng(tlist[i].TPy, tlist[i].TPx));
			}
			PointLatLng[] plist = TestTools.CircleTo2D(pa.ToArray());
			double left = plist[0].Lng;
			double right = plist[0].Lng;
			double up = plist[0].Lat;
			double down = plist[0].Lat;
			for (int j = 0; j < plist.Length; j++)
			{
				bool flag = left - plist[j].Lng > 0.0;
				if (flag)
				{
					left = plist[j].Lng;
				}
				bool flag2 = right - plist[j].Lng < 0.0;
				if (flag2)
				{
					right = plist[j].Lng;
				}
				bool flag3 = up - plist[j].Lat < 0.0;
				if (flag3)
				{
					up = plist[j].Lat;
				}
				bool flag4 = down - plist[j].Lat > 0.0;
				if (flag4)
				{
					down = plist[j].Lat;
				}
			}
			PointLatLng cp = new PointLatLng((up + down) / 2.0, (left + right) / 2.0);
			PointLatLng[] result = TestTools.PointRevolve(plist, angel, cp);
			result = TestTools.D2ToCricle(result);
			for (int k = 0; k < count; k++)
			{
				tlist[k].TPx = result[k].Lng;
				tlist[k].TPy = result[k].Lat;
			}
			return tlist;
		}
        
		public static PointLatLng[] PointRevolve(PointLatLng[] plist, double angel, PointLatLng cenpoint)
		{
			int len = plist.Length;
			PointLatLng[] presult = new PointLatLng[len];
			for (int i = 0; i < len; i++)
			{
				double lng = (plist[i].Lng - cenpoint.Lng) * Math.Cos(angel / 180.0 * 3.141592653589793) + (plist[i].Lat - cenpoint.Lat) * Math.Sin(angel / 180.0 * 3.141592653589793) + cenpoint.Lng;
				double lat = -(plist[i].Lng - cenpoint.Lng) * Math.Sin(angel / 180.0 * 3.141592653589793) + (plist[i].Lat - cenpoint.Lat) * Math.Cos(angel / 180.0 * 3.141592653589793) + cenpoint.Lat;
				plist[i].Lng = lng;
				plist[i].Lat = lat;
			}
			return plist;
		}
        
		public static TestPoint[] TrackMoveGcs(TestPoint[] task, double x, double y)
		{
			int len = task.Length;
			for (int i = 0; i < len - 1; i++)
			{
				task[i].TPx += x;
				task[i].TPy += y;
			}
			return task;
		}
        
		public static void MouldSelect(GMapOverlay overlay, byte drawtype, double drawquantity, List<PointLatLng> rectlist, List<PointLatLng> pointlist, bool CircularClickwise = true, int startnum = 0, double scanlen = 0.0)
		{
			bool flag = rectlist.Count == 0;
			if (flag)
			{
                //lijinfeng
                bool flag2 = false;
                if (flag2)
				{
					MessageBox.Show("请选择区域", "操作提示");
				}
				else
				{
                    //lijinfeng
				}
			}
			else
			{
				PointLatLng[] plist = TestTools.CircleTo2D(rectlist.ToArray());
				List<PointLatLng> flypointlist = new List<PointLatLng>();
				PointLatLng center = new PointLatLng((plist[0].Lat + plist[2].Lat) / 2.0, (plist[0].Lng + plist[2].Lng) / 2.0);
				double hlat = plist[0].Lat - plist[3].Lat;
				double hlng = plist[0].Lng - plist[3].Lng;
				double rectwith = Math.Sqrt((plist[0].Lng - plist[1].Lng) * (plist[0].Lng - plist[1].Lng) + (plist[0].Lat - plist[1].Lat) * (plist[0].Lat - plist[1].Lat));
				switch (drawtype)
				{
				case 1:
					flypointlist.Add(new PointLatLng((plist[0].Lat + plist[2].Lat) / 2.0, (plist[0].Lng + plist[2].Lng) / 2.0));
					break;
				case 2:
				{
					double tlng = plist[1].Lng - plist[0].Lng;
					double tlat = plist[1].Lat - plist[0].Lat;
					double mlat = (plist[0].Lat + plist[3].Lat) / 2.0;
					double mlng = (plist[0].Lng + plist[3].Lng) / 2.0;
					int i = 0;
					while ((double)i < drawquantity)
					{
						flypointlist.Add(new PointLatLng(mlat + (double)i / (drawquantity - 1.0) * tlat, mlng + (double)i / (drawquantity - 1.0) * tlng));
						i++;
					}
					break;
				}
				case 3:
				{
					double tlon = (plist[1].Lng + plist[0].Lng) / 2.0;
					flypointlist.Add(new PointLatLng((plist[0].Lat + plist[1].Lat) / 2.0, tlon));
					flypointlist.Add(plist[2]);
					flypointlist.Add(plist[3]);
					break;
				}
				case 4:
					for (int j = 0; j < 4; j++)
					{
						flypointlist.Add(plist[j]);
					}
					break;
				case 5:
				{
					double with = Math.Sqrt((plist[0].Lng - plist[1].Lng) * (plist[0].Lng - plist[1].Lng) + (plist[0].Lat - plist[1].Lat) * (plist[0].Lat - plist[1].Lat));
					double heigh = Math.Sqrt((plist[0].Lng - plist[3].Lng) * (plist[0].Lng - plist[3].Lng) + (plist[0].Lat - plist[3].Lat) * (plist[0].Lat - plist[3].Lat));
					bool flag3 = with > heigh;
					double r;
					if (flag3)
					{
						r = heigh / 2.0;
					}
					else
					{
						r = with / 2.0;
					}
					PointLatLng midpoint = new PointLatLng((plist[0].Lat + plist[1].Lat) / 2.0, (plist[0].Lng + plist[1].Lng) / 2.0);
					double direct = Math.Sqrt((plist[0].Lat - plist[3].Lat) * (plist[0].Lat - plist[3].Lat) + (plist[0].Lng - plist[3].Lng) * (plist[0].Lng - plist[3].Lng)) / 2.0;
					PointLatLng point = new PointLatLng(center.Lat + (midpoint.Lat - center.Lat) * r / direct, center.Lng + (midpoint.Lng - center.Lng) * r / direct);
					flypointlist.Add(point);
					int k = 1;
					while ((double)k < drawquantity)
					{
						if (CircularClickwise)
						{
							double plng = (flypointlist[k - 1].Lng - center.Lng) * Math.Cos(6.283185307179586 / drawquantity) + (flypointlist[k - 1].Lat - center.Lat) * Math.Sin(6.283185307179586 / drawquantity) + center.Lng;
							double plat = -(flypointlist[k - 1].Lng - center.Lng) * Math.Sin(6.283185307179586 / drawquantity) + (flypointlist[k - 1].Lat - center.Lat) * Math.Cos(6.283185307179586 / drawquantity) + center.Lat;
							flypointlist.Add(new PointLatLng(plat, plng));
						}
						else
						{
							double plng2 = (flypointlist[k - 1].Lng - center.Lng) * Math.Cos(6.283185307179586 / drawquantity) - (flypointlist[k - 1].Lat - center.Lat) * Math.Sin(6.283185307179586 / drawquantity) + center.Lng;
							double plat2 = (flypointlist[k - 1].Lng - center.Lng) * Math.Sin(6.283185307179586 / drawquantity) + (flypointlist[k - 1].Lat - center.Lat) * Math.Cos(6.283185307179586 / drawquantity) + center.Lat;
							flypointlist.Add(new PointLatLng(plat2, plng2));
						}
						k++;
					}
					break;
				}
				case 6:
				{
					List<int> spraypoint = new List<int>();
					double reducelen = (rectwith - scanlen) / 2.0;
					bool flag4 = scanlen == 0.0;
					if (flag4)
					{
						reducelen = 0.0;
					}
					byte way = 0;
					bool flag5 = !CircularClickwise;
					if (flag5)
					{
						way = 2;
					}
					flypointlist.AddRange(TestTools.TaskLinePlan(plist, ref spraypoint, startnum, drawquantity, way, reducelen, 0.0));
					break;
				}
				case 7:
					break;
				default:
					if (drawtype != 33)
					{
						if (drawtype == 97)
						{
							bool flag6 = drawquantity >= 2.0;
							if (flag6)
							{
								hlng = plist[1].Lng - plist[0].Lng;
								hlat = plist[1].Lat - plist[0].Lat;
								int l = 0;
								while ((double)l < drawquantity)
								{
									bool flag7 = l % 2 == 1;
									if (flag7)
									{
										flypointlist.Add(new PointLatLng(plist[3].Lat + (double)l / (drawquantity - 1.0) * hlat, plist[3].Lng + (double)l / (drawquantity - 1.0) * hlng));
										flypointlist.Add(new PointLatLng(plist[0].Lat + (double)l / (drawquantity - 1.0) * hlat, plist[0].Lng + (double)l / (drawquantity - 1.0) * hlng));
									}
									else
									{
										flypointlist.Add(new PointLatLng(plist[0].Lat + (double)l / (drawquantity - 1.0) * hlat, plist[0].Lng + (double)l / (drawquantity - 1.0) * hlng));
										flypointlist.Add(new PointLatLng(plist[3].Lat + (double)l / (drawquantity - 1.0) * hlat, plist[3].Lng + (double)l / (drawquantity - 1.0) * hlng));
									}
									l++;
								}
							}
						}
					}
					else
					{
						double tlng2 = plist[3].Lng - plist[0].Lng;
						double tlat2 = plist[3].Lat - plist[0].Lat;
						double mlat2 = (plist[0].Lat + plist[1].Lat) / 2.0;
						double mlng2 = (plist[0].Lng + plist[1].Lng) / 2.0;
						int m = 0;
						while ((double)m < drawquantity)
						{
							flypointlist.Add(new PointLatLng(mlat2 + (double)m / (drawquantity - 1.0) * tlat2, mlng2 + (double)m / (drawquantity - 1.0) * tlng2));
							m++;
						}
					}
					break;
				}
				pointlist.Clear();
				pointlist.AddRange(TestTools.D2ToCricle(flypointlist.ToArray()));
			}
		}
        
		public static void RectangleGet(GMapOverlay lyr, List<PointLatLng> list)
		{
			lyr.Polygons.Clear();
			GMapPolygon polygon = new GMapPolygon(list, "ploy1");
			polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
			polygon.Stroke = new Pen(Color.Blue, 2f);
			polygon.IsHitTestVisible = true;
			polygon.ToString();
			lyr.Polygons.Add(polygon);
		}
        
		public static double HOffset(PointLatLng curr, PointLatLng fpoint)
		{
			double clng = TestTools.rad(curr.Lng);
			double clat = TestTools.rad(curr.Lat);
			double flng = TestTools.rad(fpoint.Lng);
			double flat = TestTools.rad(fpoint.Lat);
			double pi = 3.141592653589793;
			double tmp = Math.Cos(pi / 2.0 - clat) * Math.Cos(pi / 2.0 - flat);
			double tmp2 = Math.Sin(pi / 2.0 - clat) * Math.Sin(pi / 2.0 - flat) * Math.Cos(clng - flng);
			double tmp3 = tmp + tmp2;
			bool flag = tmp3 > 1.0;
			if (flag)
			{
				tmp3 = 1.0;
			}
			bool flag2 = tmp3 < -1.0;
			if (flag2)
			{
				tmp3 = -1.0;
			}
			return 6378140.0 * Math.Acos(tmp3);
		}
        
		public static PointLatLng[] GetCirclePosition(double Atheta, double lng, double lat, double r)
		{
			double airtheta = TestTools.rad(Atheta);
			double airlng = TestTools.rad(lng);
			double airlat = TestTools.rad(lat);
			double lr = r * 2.0;
			double DisLat = TestTools.CalLat(airlat) * 57.2957795;
			double DisLon = TestTools.CalLon(airlat) * 57.2957795;
			double invDisLat = 1.0 / DisLat;
			double invDisLon = 1.0 / DisLon;
			double cleft = airtheta - 1.5707963267948966;
			bool flag = cleft < 0.0;
			if (flag)
			{
				cleft += 6.283185307179586;
			}
			double leftlng = airlng + 0.5 * lr * Math.Sin(cleft) * invDisLon;
			double leftlat = airlat + 0.5 * lr * Math.Cos(cleft) * invDisLat;
			double t = 0.5 * Math.Cos(cleft) * invDisLon * lr + airlng;
			double cright = airtheta + 1.5707963267948966;
			bool flag2 = cright > 6.283185307179586;
			if (flag2)
			{
				cright -= 6.283185307179586;
			}
			double rightlng = airlng + 0.5 * lr * Math.Sin(cright) * invDisLon;
			double rightlat = airlat + 0.5 * lr * Math.Cos(cright) * invDisLat;
			double t2 = 0.5 * Math.Cos(cright) * invDisLon * lr + airlng;
			PointLatLng[] result = new PointLatLng[2];
			result[0].Lng = TestTools.revrad(leftlng);
			result[0].Lat = TestTools.revrad(leftlat);
			result[1].Lng = TestTools.revrad(rightlng);
			result[1].Lat = TestTools.revrad(rightlat);
			return result;
		}
        
		public static double getLeftPhiOffset1(double circlelng, double circlelat, double airlng, double airlat, double atheta)
		{
			double cmlng = TestTools.rad(circlelng);
			double cmlat = TestTools.rad(circlelat);
			double cplng = TestTools.rad(airlng);
			double cplat = TestTools.rad(airlat);
			double airtheta = TestTools.rad(atheta);
			double theta = Math.Atan2((cplng - cmlng) * Math.Cos(cplat), cplat - cmlat);
			bool flag = theta < 0.0 && theta >= -3.141592653589793;
			if (flag)
			{
				theta += 6.283185307179586;
			}
			theta -= 1.5707963267948966;
			bool flag2 = theta < 0.0;
			if (flag2)
			{
				theta += 6.283185307179586;
			}
			theta = airtheta - theta;
			bool flag3 = theta > 3.141592653589793;
			if (flag3)
			{
				theta -= 6.283185307179586;
			}
			else
			{
				bool flag4 = theta < -3.141592653589793;
				if (flag4)
				{
					theta += 6.283185307179586;
				}
			}
			return TestTools.revrad(theta);
		}
        
		public static double getRightPhiOffset1(double circlelng, double circlelat, double airlng, double airlat, double atheta)
		{
			double cmlng = TestTools.rad(circlelng);
			double cmlat = TestTools.rad(circlelat);
			double cplng = TestTools.rad(airlng);
			double cplat = TestTools.rad(airlat);
			double airtheta = TestTools.rad(atheta);
			double theta = Math.Atan2((cplng - cmlng) * Math.Cos(cplat), cplat - cmlat);
			bool flag = theta < 0.0 && theta >= -3.141592653589793;
			if (flag)
			{
				theta += 6.283185307179586;
			}
			double theta2 = theta + 1.5707963267948966;
			bool flag2 = theta2 > 6.283185307179586;
			if (flag2)
			{
				theta2 -= 6.283185307179586;
			}
			double theta3 = airtheta - theta2;
			bool flag3 = theta3 > 3.141592653589793;
			if (flag3)
			{
				theta3 -= 6.283185307179586;
			}
			else
			{
				bool flag4 = theta3 < -3.141592653589793;
				if (flag4)
				{
					theta3 += 6.283185307179586;
				}
			}
			return TestTools.revrad(theta3);
		}
        
		public static double getLeftPhiOffset2(double circlelng, double circlelat, double airlng, double airlat, double atheta)
		{
			double cmlng = TestTools.rad(circlelng);
			double cmlat = TestTools.rad(circlelat);
			double cplng = TestTools.rad(airlng);
			double cplat = TestTools.rad(airlat);
			double airtheta = TestTools.rad(atheta);
			double theta = Math.Atan2((cplng - cmlng) * Math.Cos(cplat), cplat - cmlat);
			bool flag = theta < 0.0 && theta > -3.141592653589793;
			if (flag)
			{
				theta += 6.283185307179586;
			}
			double theta2 = theta + 1.5707963267948966;
			bool flag2 = theta2 > 6.283185307179586;
			if (flag2)
			{
				theta2 -= 6.283185307179586;
			}
			double theta3 = airtheta + 3.141592653589793;
			bool flag3 = theta3 > 6.283185307179586;
			if (flag3)
			{
				theta3 -= 6.283185307179586;
			}
			double theta4 = theta3 - theta2;
			bool flag4 = theta4 > 3.141592653589793;
			if (flag4)
			{
				theta4 -= 6.283185307179586;
			}
			else
			{
				bool flag5 = theta4 < -3.141592653589793;
				if (flag5)
				{
					theta4 += 6.283185307179586;
				}
			}
			return TestTools.revrad(theta4);
		}
        
		public static double getRightPhiOffset2(double circlelng, double circlelat, double airlng, double airlat, double atheta)
		{
			double cmlng = TestTools.rad(circlelng);
			double cmlat = TestTools.rad(circlelat);
			double cplng = TestTools.rad(airlng);
			double cplat = TestTools.rad(airlat);
			double airtheta = TestTools.rad(atheta);
			double theta = Math.Atan2((cplng - cmlng) * Math.Cos(cplat), cplat - cmlat);
			bool flag = theta < 0.0 && theta >= -3.141592653589793;
			if (flag)
			{
				theta += 6.283185307179586;
			}
			double theta2 = theta - 1.5707963267948966;
			bool flag2 = theta2 < 0.0;
			if (flag2)
			{
				theta2 += 6.283185307179586;
			}
			double theta3 = airtheta + 3.141592653589793;
			bool flag3 = theta3 > 6.283185307179586;
			if (flag3)
			{
				theta3 -= 6.283185307179586;
			}
			double theta4 = theta3 - theta2;
			bool flag4 = theta4 > 3.141592653589793;
			if (flag4)
			{
				theta4 -= 6.283185307179586;
			}
			else
			{
				bool flag5 = theta4 < -3.141592653589793;
				if (flag5)
				{
					theta4 += 6.283185307179586;
				}
			}
			return TestTools.revrad(theta4);
		}
        
		public static PointLatLng[] EightMidPointLine(PointLatLng left, PointLatLng right, double cr)
		{
			double r = cr + 1.0;
			return TestTools.LocCalcu(left.Lng, left.Lat, right.Lng, right.Lat, r);
		}
        
		public static PointLatLng[] LocCalcu(double lngleft, double latleft, double lngright, double latright, double cr)
		{
			double[] lon = new double[6];
			double[] lat = new double[6];
			double[] rlon = new double[4];
			double[] rlat = new double[4];
			lon[0] = TestTools.rad(lngleft);
			lat[0] = TestTools.rad(latleft);
			lon[1] = TestTools.rad(lngright);
			lat[1] = TestTools.rad(latright);
			double DisLat = TestTools.CalLat(lat[0]) * 57.2957795;
			double DisLon = TestTools.CalLon(lat[0]) * 57.2957795;
			TestTools.invDisLat = 1.0 / DisLat;
			TestTools.invDisLon = 1.0 / DisLon;
			double detaTheta = Math.Atan2((lon[1] - lon[0]) * Math.Cos(lat[1]), lat[1] - lat[0]);
			bool flag = detaTheta < 0.0 && detaTheta >= -3.141592653589793;
			if (flag)
			{
				detaTheta += 6.283185307179586;
			}
			double thetaPre = detaTheta - 1.5707963267948966;
			bool flag2 = thetaPre < 0.0;
			if (flag2)
			{
				thetaPre += 6.283185307179586;
			}
			double detaPreE = cr * Math.Sin(thetaPre);
			double detaPreN = cr * Math.Cos(thetaPre);
			rlon[0] = (lon[1] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[0] = (lat[1] + detaPreN * TestTools.invDisLat) * 57.2957795;
			rlon[1] = (lon[0] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[1] = (lat[0] + detaPreN * TestTools.invDisLat) * 57.2957795;
			double thetaNext = detaTheta + 1.5707963267948966;
			bool flag3 = thetaNext > 6.283185307179586;
			if (flag3)
			{
				thetaNext -= 6.283185307179586;
			}
			double detaNextE = cr * Math.Sin(thetaNext);
			double detaNextN = cr * Math.Cos(thetaNext);
			rlon[2] = (lon[1] + detaNextE * TestTools.invDisLon) * 57.2957795;
			rlat[2] = (lat[1] + detaNextN * TestTools.invDisLat) * 57.2957795;
			rlon[3] = (lon[0] + detaNextE * TestTools.invDisLon) * 57.2957795;
			rlat[3] = (lat[0] + detaNextN * TestTools.invDisLat) * 57.2957795;
			return new PointLatLng[]
			{
				new PointLatLng(rlat[0], rlon[0]),
				new PointLatLng(rlat[1], rlon[1]),
				new PointLatLng(rlat[2], rlon[2]),
				new PointLatLng(rlat[3], rlon[3])
			};
		}
        
		public static PointLatLng[] AB_Loc_Calcu(double lngleft, double latleft, double lngright, double latright, double cr)
		{
			double[] lon = new double[6];
			double[] lat = new double[6];
			double[] rlon = new double[8];
			double[] rlat = new double[8];
			lon[0] = TestTools.rad(lngleft);
			lat[0] = TestTools.rad(latleft);
			lon[1] = TestTools.rad(lngright);
			lat[1] = TestTools.rad(latright);
			double DisLat = TestTools.CalLat(lat[0]) * 57.2957795;
			double DisLon = TestTools.CalLon(lat[0]) * 57.2957795;
			TestTools.invDisLat = 1.0 / DisLat;
			TestTools.invDisLon = 1.0 / DisLon;
			double detaTheta = Math.Atan2((lon[1] - lon[0]) * Math.Cos(lat[1]), lat[1] - lat[0]);
			bool flag = detaTheta < 0.0 && detaTheta >= -3.141592653589793;
			if (flag)
			{
				detaTheta += 6.283185307179586;
			}
			double thetaPre = detaTheta - 1.5707963267948966;
			bool flag2 = thetaPre < 0.0;
			if (flag2)
			{
				thetaPre += 6.283185307179586;
			}
			double detaPreE = cr * Math.Sin(thetaPre);
			double detaPreN = cr * Math.Cos(thetaPre);
			rlon[5] = (lon[1] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[5] = (lat[1] + detaPreN * TestTools.invDisLat) * 57.2957795;
			rlon[1] = (lon[0] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[1] = (lat[0] + detaPreN * TestTools.invDisLat) * 57.2957795;
			thetaPre = detaTheta;
			bool flag3 = thetaPre < 0.0;
			if (flag3)
			{
				thetaPre += 6.283185307179586;
			}
			detaPreE = cr * Math.Sin(thetaPre);
			detaPreN = cr * Math.Cos(thetaPre);
			rlon[6] = (lon[1] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[6] = (lat[1] + detaPreN * TestTools.invDisLat) * 57.2957795;
			rlon[0] = (lon[0] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[0] = (lat[0] + detaPreN * TestTools.invDisLat) * 57.2957795;
			thetaPre = detaTheta + 1.5707963267948966;
			bool flag4 = thetaPre > 6.283185307179586;
			if (flag4)
			{
				thetaPre -= 6.283185307179586;
			}
			detaPreE = cr * Math.Sin(thetaPre);
			detaPreN = cr * Math.Cos(thetaPre);
			rlon[7] = (lon[1] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[7] = (lat[1] + detaPreN * TestTools.invDisLat) * 57.2957795;
			rlon[3] = (lon[0] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[3] = (lat[0] + detaPreN * TestTools.invDisLat) * 57.2957795;
			thetaPre = detaTheta + 3.141592653589793;
			bool flag5 = thetaPre < 6.283185307179586;
			if (flag5)
			{
				thetaPre -= 6.283185307179586;
			}
			detaPreE = cr * Math.Sin(thetaPre);
			detaPreN = cr * Math.Cos(thetaPre);
			rlon[4] = (lon[1] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[4] = (lat[1] + detaPreN * TestTools.invDisLat) * 57.2957795;
			rlon[2] = (lon[0] + detaPreE * TestTools.invDisLon) * 57.2957795;
			rlat[2] = (lat[0] + detaPreN * TestTools.invDisLat) * 57.2957795;
			PointLatLng[] result = new PointLatLng[8];
			for (int i = 0; i < result.Length; i++)
			{
				result[i].Lng = rlon[i];
				result[i].Lat = rlat[i];
			}
			return result;
		}
        
		private const double EARTH_RADIUS = 6378.137;
        
		private const double R2D = 57.2957795;
        
		public static double invDisLat = 0.0;
        
		public static double invDisLon = 0.0;

		public static PointLatLng invpoint = new PointLatLng(0.0, 0.0);
	}
}
