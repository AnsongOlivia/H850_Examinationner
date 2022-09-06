using GMap.NET;
using System;

namespace YuneecFX01.map.MapProviders
{
    public class TianDiTuSatelliteProvider : TianDiTuProviderBase
    {
        public static readonly TianDiTuSatelliteProvider Instance;

        readonly Guid id = new Guid("E86B0385-9E56-C17F-AB46-7BC2D2692845");
        public override Guid Id => id;

        readonly string name = "天地图卫星地图";
        public override string Name => name;

        public string token = "7f6eea47f59a1585fe8771410f48dbdf";

        static TianDiTuSatelliteProvider()
        {
            Instance = new TianDiTuSatelliteProvider();
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
            var num = (pos.X + pos.Y) % 8;
            string url = $"https://t{num}.tianditu.gov.cn/img_w/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=img&STYLE=default&TILEMATRIXSET=w&FORMAT=tiles&TILECOL={pos.X}&TILEROW={pos.Y}&TILEMATRIX={zoom}&tk={token}";
            Console.WriteLine(url);
            return url;
        }
    }
}
