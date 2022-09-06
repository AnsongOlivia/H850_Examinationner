using GMap.NET;
using System;
using System.Diagnostics;

namespace YuneecFX01.tool
{
	internal class Calculate
    {
        /// <summary>
        /// 转换角度到 [0, 360) 范围
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static double toDegress360(double deg)
        {
            while (true)
            {
                if (deg < 0)
                    deg += 360;
                else if (deg >= 360)
                    deg -= 360;
                else
                    return deg;
            }
        }

        /// <summary>
        /// 转换角度到 [-180, 180) 范围
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static double toDegress180(double deg)
        {
            while (true)
            {
                if (deg < -180)
                    deg += 360;
                else if (deg >= 180)
                    deg -= 360;
                else
                    return deg;
            }
        }


        public static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 已知x y坐标计算角度
        /// </summary>
        private static double getAngle(double lng1, double lat1, double lng2, double lat2)
        {
            double dRotateAngle = Math.Atan2(Math.Abs(lng1 - lng2), Math.Abs(lat1 - lat2));
            if (lng2 >= lng1)
            {
                if (lat2 >= lat1)
                {
                }
                else
                {
                    dRotateAngle = Math.PI - dRotateAngle;
                }
            }
            else
            {
                if (lat2 >= lat1)
                {
                    dRotateAngle = 2 * Math.PI - dRotateAngle;
                }
                else
                {
                    dRotateAngle = Math.PI + dRotateAngle;
                }
            }
            dRotateAngle = dRotateAngle * 180 / Math.PI;
            return dRotateAngle;
        }

        public static double getDistance(double lat1,double lng1,double lat2,double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);

            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * 6378.137;// EARTH_RADIUS
            s = Math.Round(s * 10000)/10000;

            return s*1000;
		}

		/// <summary>
		/// 根据两点的经纬度计算角度
		/// </summary>
		/// <param name="A">第一点</param>
		/// <param name="B">第二点</param>
		/// <returns>角度</returns>
		public static double getAngle(CustomLatLng A, CustomLatLng B)
		{
			double dRotateAngle = Math.Atan2(B.m_lng - A.m_lng, B.m_lat - A.m_lat);
			dRotateAngle = dRotateAngle * 180 / Math.PI;
			return dRotateAngle < 0 ? dRotateAngle + 360 : dRotateAngle;
		}

		/// <summary>
		/// 根据两点的经纬度计算角度
		/// </summary>
		/// <param name="point1">第一点</param>
		/// <param name="point2">第二点</param>
		/// <returns>角度</returns>
		public static double GetAzimuth(PointLatLng point1, PointLatLng point2)
		{
			double lat1 = DegressToRadians(point1.Lat);
			double lat2 = DegressToRadians(point2.Lat);
			double lon1 = DegressToRadians(point1.Lng);
			double lon2 = DegressToRadians(point2.Lng);
			double azimuth = Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1)
					* Math.Cos(lat2) * Math.Cos(lon2 - lon1);
			azimuth = Math.Sqrt(1 - azimuth * azimuth);
			azimuth = Math.Cos(lat2) * Math.Sin(lon2 - lon1) / azimuth;
			azimuth = Math.Asin(azimuth) * 180 / Math.PI;
			if (Double.IsNaN(azimuth))
			{
				if (lon1 < lon2)
				{
					azimuth = 90.0;
				}
				else
				{
					azimuth = 270.0;
				}
			}
			return azimuth < 0 ? azimuth + 360 : azimuth;
		}

		/// <summary>
		/// 求一点经纬度
		/// 根据中心点和角度
		/// </summary>
		/// <param name="A">第一点</param>
		/// <param name="distance">距离（米）</param>
		/// <param name="angle">方位角</param>
		/// <returns></returns>
		public static CustomLatLng getAngleLatLng(CustomLatLng A, double distance, double angle)
        {
            double dx = distance * Math.Sin(DegressToRadians(angle));
            double dy = distance * Math.Cos(DegressToRadians(angle));

            double bjd = (dx / A.Ed + A.m_RadLo) * 180 / Math.PI;
            double bwd = (dy / A.Ec + A.m_RadLa) * 180 / Math.PI;
            return new CustomLatLng(bjd, bwd);
        }

        /// <summary>
        /// 求一点经纬度
        /// 根据中心点、左圆心和距离，求右圆心经纬度
        /// </summary>
        public static CustomLatLng getDisLatLng(CustomLatLng A, CustomLatLng B,double distance)
        {
            double angle = getAngle(A.m_lng,A.m_lat, B.m_lng, B.m_lat);

            double dx = distance * 1000 * Math.Sin(DegressToRadians(angle+180));
            double dy = distance * 1000 * Math.Cos(DegressToRadians(angle+180));

            double bjd = (dx / A.Ed + A.m_RadLo) * 180 / Math.PI;
            double bwd = (dy / A.Ec + A.m_RadLa) * 180 / Math.PI;
            return new CustomLatLng(bjd, bwd);
		}

		public static double DegressToRadians(double degress)
		{
			return degress * Math.PI / 180.0;
		}

		public static double RadiansToDegress(double radians)
		{
			return radians * 180.0 / Math.PI;
		}

		public static double Abs(double a)
		{
			return (a < 0.0) ? (-a) : a;
		}

		public static bool Equal(double a, double b)
		{
			return Calculate.Abs(a - b) < 1E-06;
		}

		public static void ResetMatrix()
		{
            Calculate.row = 0U;
			while (Calculate.row < 6U)
			{
                Calculate.column = 0U;
				while (Calculate.column < 7U)
				{
                    Calculate.m_matrix[(int)Calculate.row, (int)Calculate.column] = 0.0;
                    Calculate.column += 1U;
				}
                Calculate.row += 1U;
			}
		}

		public static void CalcData_Input(double x, double y, double z)
		{
			double[] V = new double[7];
            Calculate.N++;
			V[0] = y * y;
			V[1] = z * z;
			V[2] = x;
			V[3] = y;
			V[4] = z;
			V[5] = 1.0;
			V[6] = -x * x;
            Calculate.row = 0U;
			while (Calculate.row < 6U)
			{
                Calculate.column = 0U;
				while (Calculate.column < 7U)
				{
                    Calculate.m_matrix[(int)Calculate.row, (int)Calculate.column] += V[(int)Calculate.row] * V[(int)Calculate.column];
                    Calculate.column += 1U;
				}
                Calculate.row += 1U;
			}
		}

		public static void CalcData_Input_average()
		{
			for (int row = 0; row < 6; row++)
			{
				for (int column = 0; column < 7; column++)
				{
                    Calculate.m_matrix[row, column] /= (double)Calculate.N;
				}
			}
		}

		public static void DispMatrix()
		{
			for (int row = 0; row < 6; row++)
			{
				for (int column = 0; column < 7; column++)
				{
					bool flag = column == 5;
					if (flag)
					{
					}
				}
			}
		}

		public static void Row2_swop_Row1(int row1, int row2)
		{
			for (int column = 0; column < 7; column++)
			{
				double tmp = Calculate.m_matrix[row1, column];
                Calculate.m_matrix[row1, column] = Calculate.m_matrix[row2, column];
                Calculate.m_matrix[row2, column] = tmp;
			}
		}

		public static void k_muiltply_Row(double k, int row)
		{
			for (int column = 0; column < 7; column++)
			{
                Calculate.m_matrix[row, column] *= k;
			}
		}
		public static void Row2_add_kRow1(double k, int row1, int row2)
		{
			for (uint column = 0U; column < 7U; column += 1U)
			{
                Calculate.m_matrix[row2, (int)column] += k * Calculate.m_matrix[row1, (int)column];
			}
		}

		public static void MoveBiggestElement_to_Top(int k)
		{
			for (int row = k + 1; row < 6; row++)
			{
				bool flag = Calculate.Abs(Calculate.m_matrix[k, k]) < Calculate.Abs(Calculate.m_matrix[row, k]);
				if (flag)
				{
                    Calculate.Row2_swop_Row1(k, row);
				}
			}
		}

		public static int Matrix_GaussElimination()
		{
			for (int cnt = 0; cnt < 6; cnt++)
			{
                Calculate.MoveBiggestElement_to_Top(cnt);
				bool flag = Calculate.m_matrix[cnt, cnt] == 0.0;
				if (flag)
				{
					return 1;
				}
				for (int row = cnt + 1; row < 6; row++)
				{
					double i = -Calculate.m_matrix[row, cnt] / Calculate.m_matrix[cnt, cnt];
                    Calculate.Row2_add_kRow1(i, cnt, row);
				}
                Calculate.DispMatrix();
			}
			return 0;
		}

		public static void Matrix_RowSimplify()
		{
			for (int row = 0; row < 6; row++)
			{
				double i = 1.0 / Calculate.m_matrix[row, row];
                Calculate.k_muiltply_Row(i, row);
			}
            Calculate.DispMatrix();
		}

		public static void Matrix_Solve(ref double[] solve)
		{
			for (short row = 5; row >= 0; row -= 1)
			{
				solve[(int)row] = Calculate.m_matrix[(int)row, 6];
				for (int column = 5; column >= (int)(row + 1); column--)
				{
					solve[(int)row] -= Calculate.m_matrix[(int)row, column] * solve[column];
				}
			}
		}

		public static double[] Calc_Process(double[] sdata)
		{
			double X0 = 0.0;
			double Y0 = 0.0;
			double Z0 = 0.0;
			double A = 0.0;
			double B = 0.0;
			double C = 0.0;
			double[] result = new double[6];
            Calculate.ResetMatrix();
			for (int i = 0; i < sdata.Length / 9; i++)
			{
                Calculate.CalcData_Input(sdata[i * 9 + 6], sdata[i * 9 + 7], sdata[i * 9 + 8]);
			}
            Calculate.CalcData_Input_average();
            Calculate.DispMatrix();
			bool flag = Calculate.Matrix_GaussElimination() == 1;
			if (flag)
			{
				Debug.WriteLine("the marix could not be solved\r\n");
			}
			else
			{
                Calculate.Matrix_RowSimplify();
                Calculate.Matrix_Solve(ref Calculate.solve);
				double a = Calculate.solve[0];
				double b = Calculate.solve[1];
				double c = Calculate.solve[2];
				double d = Calculate.solve[3];
				double e = Calculate.solve[4];
				double f = Calculate.solve[5];
				X0 = -c / 2.0;
				Y0 = -d / (2.0 * a);
				Z0 = -e / (2.0 * b);
				A = Math.Sqrt(X0 * X0 + a * Y0 * Y0 + b * Z0 * Z0 - f);
				B = A / Math.Sqrt(a);
				C = A / Math.Sqrt(b);
			}
			result[0] = X0;
			result[1] = Y0;
			result[2] = Z0;
			result[3] = A;
			result[4] = B;
			result[5] = C;
			return result;
		}
		private const int MATRIX_SIZE = 6;

		public static double[,] m_matrix = new double[6, 7];

		public static double[] solve = new double[6];

		private double[] m_result = new double[6];

		public static int N = 0;

		public static uint row;

		public static uint column;
	}
}

public class CustomLatLng
{
    public double Rc = 6378137;
    public double Rj = 6356725;
    public double m_LoDeg, m_LoMin, m_LoSec;
    public double m_LaDeg, m_LaMin, m_LaSec;
    public double m_lng, m_lat;
    public double m_RadLo, m_RadLa;
    public double Ec;
    public double Ed;

    public CustomLatLng(double lng, double lat)
    {
        m_LoDeg = (int)lng;
        m_LoMin = (int)((lng - m_LoDeg) * 60);
        m_LoSec = (lng - m_LoDeg - m_LoMin / 60) * 3600;

        m_LaDeg = (int)lat;
        m_LaMin = (int)((lat - m_LaDeg) * 60);
        m_LaSec = (lat - m_LaDeg - m_LaMin / 60) * 3600;

        m_lng = lng;
        m_lat = lat;

        m_RadLo = lng * Math.PI / 180;
        m_RadLa = lat * Math.PI / 180;

        Ec = Rj + (Rc - Rj) * (90 - m_lat) / 90;
        Ed = Ec * Math.Cos(m_RadLa);
    }
}
