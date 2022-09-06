using GMap.NET;
using GMap.NET.MapProviders;
using System;

namespace YuneecFX01.map.MapProviders
{
	public class BaiduMapProvider : BaiduMapProviderBase
	{
		public override Guid Id
		{
			get
			{
				return this.id;
			}
		}
		public override string Name
		{
			get
			{
				return this.name;
			}
		}
		static BaiduMapProvider()
		{
			BaiduMapProvider.Instance = new BaiduMapProvider();
		}
		public override PureImage GetTileImage(GPoint pos, int zoom)
		{
			string url = this.MakeTileImageUrl(pos, zoom, GMapProvider.LanguageStr);
			return base.GetTileImageUsingHttp(url);
		}
		private string MakeTileImageUrl(GPoint pos, int zoom, string language)
		{
			zoom--;
			double offsetX = Math.Pow(2.0, (double)zoom);
			double offsetY = offsetX - 1.0;
			double numX = (double)pos.X - offsetX;
			double numY = (double)(-(double)pos.Y) + offsetY;
			zoom++;
			long num = (pos.X + pos.Y) % 8L + 1L;
			string x = numX.ToString().Replace("-", "M");
			string y = numY.ToString().Replace("-", "M");
			string url = string.Format(BaiduMapProvider.UrlFormat, new object[]
			{
				num,
				x,
				y,
				zoom,
				"pl",
				"20140522"
			});
			Console.WriteLine("url:" + url);
			return url;
		}
		public static readonly BaiduMapProvider Instance;
		private readonly Guid id = new Guid("608748FC-5FDD-4d3a-9027-356F24A755E5");
		private readonly string name = "BaiduMap";
		private static readonly string UrlFormat = "http://online{0}.map.bdimg.com/tile/?qt=tile&x={1}&y={2}&z={3}&styles={4}&udt={5}";
	}
}
