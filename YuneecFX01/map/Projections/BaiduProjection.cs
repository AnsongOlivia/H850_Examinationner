using GMap.NET;
using System;

namespace YuneecFX01.map.Projections
{
	public class BaiduProjection : PureProjection
	{
		public override GSize TileSize
		{
			get
			{
				return this.tileSize;
			}
		}

		public override double Axis
		{
			get
			{
				return 6378137.0;
			}
		}

		public override double Flattening
		{
			get
			{
				return 0.0033528106647474805;
			}
		}

		public override GPoint FromLatLngToPixel(double lat, double lng, int zoom)
		{
			GPoint ret = GPoint.Empty;
			lat -= 14.865;
			lng -= 46.895;
			lat = PureProjection.Clip(lat, BaiduProjection.MinLatitude, BaiduProjection.MaxLatitude);
			lng = PureProjection.Clip(lng, BaiduProjection.MinLongitude, BaiduProjection.MaxLongitude);
			double x = (lng + 180.0) / 360.0;
			double sinLatitude = Math.Sin(lat * 3.141592653589793 / 180.0);
			double y = 0.5 - Math.Log((1.0 + sinLatitude) / (1.0 - sinLatitude)) / 12.566370614359172;
			GSize s = this.GetTileMatrixSizePixel(zoom);
			long mapSizeX = s.Width;
			long mapSizeY = s.Height;
			ret.X = (long)PureProjection.Clip(x * (double)mapSizeX + 0.5, 0.0, (double)(mapSizeX - 1L));
			ret.Y = (long)PureProjection.Clip(y * (double)mapSizeY + 0.5, 0.0, (double)(mapSizeY - 1L));
			return ret;
		}

		public override PointLatLng FromPixelToLatLng(long x, long y, int zoom)
		{
			PointLatLng ret = PointLatLng.Empty;
			GSize s = this.GetTileMatrixSizePixel(zoom);
			double mapSizeX = (double)s.Width;
			double mapSizeY = (double)s.Height;
			double xx = PureProjection.Clip((double)x, 0.0, mapSizeX - 1.0) / mapSizeX - 0.5;
			double yy = 0.5 - PureProjection.Clip((double)y, 0.0, mapSizeY - 1.0) / mapSizeY;
			ret.Lat = 90.0 - 360.0 * Math.Atan(Math.Exp(-yy * 2.0 * 3.141592653589793)) / 3.141592653589793 + 14.865;
			ret.Lng = 360.0 * xx + 46.895;
			return ret;
		}

		public override GSize GetTileMatrixMinXY(int zoom)
		{
			return new GSize(0L, 0L);
		}

		public override GSize GetTileMatrixMaxXY(int zoom)
		{
			long xy = 1L << (zoom & 31);
			return new GSize(xy - 1L, xy - 1L);
		}

		public static readonly BaiduProjection Instance = new BaiduProjection();

		private static readonly double MinLatitude = -74.0;

		private static readonly double MaxLatitude = 74.0;

		private static readonly double MinLongitude = -180.0;

		private static readonly double MaxLongitude = 180.0;

		private readonly GSize tileSize = new GSize(256L, 256L);
	}
}
