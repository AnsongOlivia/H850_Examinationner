using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.map.MapProviders
{
    public abstract class ArcGISProviderBase : GMapProvider
    {
        public ArcGISProviderBase()
        {
            MinZoom = 1;
            MaxZoom = 18;
            RefererUrl = "https://www.arcgis.com/";
            Copyright = string.Format("©{0} ArcGIS Corporation", DateTime.Today.Year);
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

        public override PureProjection Projection => MercatorProjection.Instance;
    }
}
