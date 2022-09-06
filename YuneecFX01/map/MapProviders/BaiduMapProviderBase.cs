using System;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using YuneecFX01.map.Projections;

namespace YuneecFX01.map.MapProviders
{
	public abstract class BaiduMapProviderBase : GMapProvider
	{
		public BaiduMapProviderBase()
		{
			this.MaxZoom = null;
			this.RefererUrl = "http://map.baidu.com";
			this.Copyright = string.Format("©{0} Baidu Corporation, ©{0} NAVTEQ, ©{0} Image courtesy of NASA", DateTime.Today.Year);
		}

		public override PureProjection Projection
		{
			get
			{
				return BaiduProjection.Instance;
			}
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
						this
					};
				}
				return this.overlays;
			}
		}
		private string ClientKey = "1308e84a0e8a1fc2115263a4b3cf87f1";
		private GMapProvider[] overlays;
	}
}
