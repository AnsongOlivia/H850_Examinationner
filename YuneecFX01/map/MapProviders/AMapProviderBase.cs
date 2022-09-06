using System;
using GMap.NET;
using GMap.NET.MapProviders;

namespace YuneecFX01.map.MapProviders
{
    public abstract class AMapProviderBase : GMapProvider
    {
        public AMapProviderBase()
        {
            MinZoom = 1;
            MaxZoom = 18;
            RefererUrl = "http://www.amap.com/";
            Copyright = string.Format("©{0} 高德地图 Corporation", DateTime.Today.Year);    
        }


        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }

        public override PureProjection Projection => MercatorProjectionGCJ.Instance;
    }
}
