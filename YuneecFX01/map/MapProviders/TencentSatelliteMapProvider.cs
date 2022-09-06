using GMap.NET;
using System;

namespace YuneecFX01.map.MapProviders
{
    public class TencentSatelliteMapProvider : TencentMapProviderBase
    {
        public static readonly TencentSatelliteMapProvider Instance;

        readonly Guid id = new Guid("6C589B7C-0933-6222-7E82-55CEDE4C3DD4");
        public override Guid Id => id;

        readonly string name = "TencentSatellite";
        public override string Name => name;

        static TencentSatelliteMapProvider()
        {
            Instance = new TencentSatelliteMapProvider();
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
            var num = (pos.X + pos.Y) % 4;
            var reverseY = (1 << zoom) - pos.Y;
            string url = $"https://p{num}.map.gtimg.com/sateTiles/{zoom}/{pos.X >> 4}/{reverseY >> 4}/{pos.X}_{reverseY}.jpg?version=256";
            Console.WriteLine(url);
            return url;
        }
    }
}
