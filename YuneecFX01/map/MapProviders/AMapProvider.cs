using System;
using GMap.NET;
using GMap.NET.MapProviders;

namespace YuneecFX01.map.MapProviders
{
	public class AMapProvider : AMapProviderBase
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

		static AMapProvider()
		{
			AMapProvider.Instance = new AMapProvider();
		}

		public override PureImage GetTileImage(GPoint pos, int zoom)
		{
            try
            {
                string url = this.MakeTileImageUrl(pos, zoom, GMapProvider.LanguageStr);
                return base.GetTileImageUsingHttp(url);
            }
            catch (Exception ex)
            {
                return null;
            }
            
		}

		private string MakeTileImageUrl(GPoint pos, int zoom, string language)
		{
			string url = string.Format(AMapProvider.UrlFormat, pos.X, pos.Y, zoom);
			Console.WriteLine("url:" + url);
			return url;
		}

		public static readonly AMapProvider Instance;

		private readonly Guid id = new Guid("e841ce4562511d8dbb3162c33804cf2d");

		private readonly string name = "AMap";

		private static readonly string UrlFormat = "http://webst04.is.autonavi.com/appmaptile?x={0}&y={1}&z={2}&lang=zh_cn&size=1&scale=1&style=7";
	}
}
