using System;
using GMap.NET;
using GMap.NET.MapProviders;

namespace YuneecFX01.map.MapProviders
{
	public class AmapStateliteAddProvider : AMapProviderBase
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

		static AmapStateliteAddProvider()
		{
			AmapStateliteAddProvider.Instance = new AmapStateliteAddProvider();
		}

		public override GMapProvider[] Overlays
		{
			get
			{
				bool flag = this.overlays == null;
				if (flag)
				{
					this.overlays = new GMapProvider[]
					{
						AmapStateliteAddProvider.Instance,
						this
					};
				}
				return this.overlays;
			}
		}
		public override PureImage GetTileImage(GPoint pos, int zoom)
		{
			string url = this.MakeTileImageUrl(pos, zoom, GMapProvider.LanguageStr);
			return base.GetTileImageUsingHttp(url);
		}
		private string MakeTileImageUrl(GPoint pos, int zoom, string language)
		{
			string url = string.Format(AmapStateliteAddProvider.UrlFormat, pos.X, pos.Y, zoom);
			Console.WriteLine("url:" + url);
			return url;
		}

		public static readonly AmapStateliteAddProvider Instance;
		private readonly Guid id = new Guid("e841ce4562511d8dbb3162c33804cf2d");
		private readonly string name = "AMapSateliteAddMap";
		private GMapProvider[] overlays;
		private static readonly string UrlFormat = "http://webst04.is.autonavi.com/appmaptile?x={0}&y={1}&z={2}&lang=zh_cn&size=1&scale=1&style=6";
	}
}
