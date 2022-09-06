using GMap.NET;
using System;

namespace YuneecFX01.map.MapProviders
{
    public class AMapSatelliteProvider : AMapProviderBase
    {
        public static readonly AMapSatelliteProvider Instance;

        readonly Guid id = new Guid("61208E90-A111-E0C9-7044-D52D656A6FCB");
        public override Guid Id => id;

        readonly string name = "高德卫星地图";
        public override string Name => name;

        static AMapSatelliteProvider()
        {
            Instance = new AMapSatelliteProvider();
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            try
            {
                string url = MakeTileImageUrl(pos, zoom, LanguageStr);
                return GetTileImageUsingHttp(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            var num = (pos.X + pos.Y) % 4 + 1;
            string url = $"http://webst0{num}.is.autonavi.com/appmaptile?style=6&x={pos.X}&y={pos.Y}&z={zoom}";
            Console.WriteLine(url);
            return url;
        }
    }
}
