using GMap.NET;
using System;

namespace YuneecFX01.map.MapProviders
{
    public class ArcGISSatelliteProvider : ArcGISProviderBase
    {
        public static readonly ArcGISSatelliteProvider Instance;

        readonly Guid id = new Guid("86B89784-BD13-14B7-BAC4-F17E98D9775D");
        public override Guid Id => id;

        readonly string name = "ArcGIS卫星地图";
        public override string Name => name;

        static ArcGISSatelliteProvider()
        {
            Instance = new ArcGISSatelliteProvider();
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
            string url = $"https://services.arcgisonline.com/arcgis/rest/services/World_Imagery/MapServer/tile/{zoom}/{pos.Y}/{pos.X}";
            Console.WriteLine(url);
            return url;
        }
    }
}
