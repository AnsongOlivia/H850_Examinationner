using GMap.NET;
using GMap.NET.Projections;
using System;

namespace YuneecFX01.map.MapProviders
{
	public class MercatorProjectionGCJ : MercatorProjection
	{
		public override GPoint FromLatLngToPixel(double lat, double lng, int zoom)
		{
			double[] latlng = new double[2];
			this.transform(lat, lng, latlng);
			lat = latlng[0];
			lng = latlng[1];
			GPoint empty = GPoint.Empty;
			lat = PureProjection.Clip(lat, MercatorProjectionGCJ.MinLatitude, MercatorProjectionGCJ.MaxLatitude);
			lng = PureProjection.Clip(lng, MercatorProjectionGCJ.MinLongitude, MercatorProjectionGCJ.MaxLongitude);
			double num = (lng + 180.0) / 360.0;
			double num2 = Math.Sin(lat * 3.141592653589793 / 180.0);
			double num3 = 0.5 - Math.Log((1.0 + num2) / (1.0 - num2)) / 12.566370614359172;
			GSize tileMatrixSizePixel = this.GetTileMatrixSizePixel(zoom);
			long width = tileMatrixSizePixel.Width;
			long height = tileMatrixSizePixel.Height;
			empty.X = (long)PureProjection.Clip(num * (double)width + 0.5, 0.0, (double)(width - 1L));
			empty.Y = (long)PureProjection.Clip(num3 * (double)height + 0.5, 0.0, (double)(height - 1L));
			return empty;
		}

		public override PointLatLng FromPixelToLatLng(long x, long y, int zoom)
		{
			PointLatLng empty = PointLatLng.Empty;
			GSize tileMatrixSizePixel = this.GetTileMatrixSizePixel(zoom);
			double width = (double)tileMatrixSizePixel.Width;
			double height = (double)tileMatrixSizePixel.Height;
			double num3 = PureProjection.Clip((double)x, 0.0, width - 1.0) / width - 0.5;
			double num4 = 0.5 - PureProjection.Clip((double)y, 0.0, height - 1.0) / height;
			empty.Lat = 90.0 - 360.0 * Math.Atan(Math.Exp(-num4 * 2.0 * 3.141592653589793)) / 3.141592653589793;
			empty.Lng = 360.0 * num3;
			PointLatLng lng2 = default(PointLatLng);
			double[] latlng = new double[2];
			this.transform(empty.Lat, empty.Lng, latlng);
			lng2.Lat = latlng[0];
			lng2.Lng = latlng[1];
			empty.Lat -= lng2.Lat - empty.Lat;
			empty.Lng -= lng2.Lng - empty.Lng;
			return empty;
		}

		public override GSize GetTileMatrixMaxXY(int zoom)
		{
			long num = 1L << (zoom & 31);
			return new GSize(num - 1L, num - 1L);
		}

        public override GSize GetTileMatrixMinXY(int zoom)
		{
			return new GSize(0L, 0L);
		}

		private static bool outOfChina(double lat, double lon)
		{
			bool flag = lon >= 72.004 && lon <= 137.8347 && lat >= 0.8293 && lat <= 55.8271;
			return !flag;
		}

		private void transform(double wgLat, double wgLon, double[] latlng)
		{
			bool flag = MercatorProjectionGCJ.outOfChina(wgLat, wgLon);
			if (flag)
			{
				latlng[0] = wgLat;
				latlng[1] = wgLon;
			}
			else
			{
				double num = this.transformLat(wgLon - 105.0, wgLat - 35.0);
				double num2 = this.transformLon(wgLon - 105.0, wgLat - 35.0);
				double a = wgLat / 180.0 * 3.141592653589793;
				double d = Math.Sin(a);
				d = 1.0 - this.ee * d * d;
				double num3 = Math.Sqrt(d);
				num = num * 180.0 / (this.a * (1.0 - this.ee) / (d * num3) * 3.141592653589793);
				num2 = num2 * 180.0 / (this.a / num3 * Math.Cos(a) * 3.141592653589793);
				latlng[0] = wgLat + num;
				latlng[1] = wgLon + num2;
			}
		}

		private double transformLat(double x, double y)
		{
			double num = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * Math.Sqrt(Math.Abs(x));
			num += (20.0 * Math.Sin(6.0 * x * 3.141592653589793) + 20.0 * Math.Sin(2.0 * x * 3.141592653589793)) * 2.0 / 3.0;
			num += (20.0 * Math.Sin(y * 3.141592653589793) + 40.0 * Math.Sin(y / 3.0 * 3.141592653589793)) * 2.0 / 3.0;
			return num + (160.0 * Math.Sin(y / 12.0 * 3.141592653589793) + 320.0 * Math.Sin(y * 3.141592653589793 / 30.0)) * 2.0 / 3.0;
		}

		private double transformLon(double x, double y)
		{
			double num = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(Math.Abs(x));
			num += (20.0 * Math.Sin(6.0 * x * 3.141592653589793) + 20.0 * Math.Sin(2.0 * x * 3.141592653589793)) * 2.0 / 3.0;
			num += (20.0 * Math.Sin(x * 3.141592653589793) + 40.0 * Math.Sin(x / 3.0 * 3.141592653589793)) * 2.0 / 3.0;
			return num + (150.0 * Math.Sin(x / 12.0 * 3.141592653589793) + 300.0 * Math.Sin(x / 30.0 * 3.141592653589793)) * 2.0 / 3.0;
		}

        public override double Axis => 6378137.0;

        public override RectLatLng Bounds => RectLatLng.FromLTRB(MercatorProjectionGCJ.MinLongitude, MercatorProjectionGCJ.MaxLatitude, MercatorProjectionGCJ.MaxLongitude, MercatorProjectionGCJ.MinLatitude);

        public override double Flattening => 0.0033528106647474805;

        public override GSize TileSize => this.tileSize;

        internal double a = 6378245.0;

		internal double ee = 0.006693421622965943;

		public static new readonly MercatorProjectionGCJ Instance = new MercatorProjectionGCJ();

		private static readonly double MaxLatitude = 85.05112878;

		private static readonly double MaxLongitude = 180.0;

		private static readonly double MinLatitude = -85.05112878;

		private static readonly double MinLongitude = -180.0;

		private readonly GSize tileSize = new GSize(256L, 256L);
	}
}
