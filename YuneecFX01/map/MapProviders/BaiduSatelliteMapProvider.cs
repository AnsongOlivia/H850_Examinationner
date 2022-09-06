using GMap.NET;
using System;

namespace YuneecFX01.map.MapProviders
{
    public class BaiduSatelliteMapProvider : BaiduMapProviderBase
    {
        public static readonly BaiduSatelliteMapProvider Instance;

        readonly Guid id = new Guid("4F4DA77D-9F72-9DD2-F30C-1211F5626270");
        public override Guid Id => id;

        readonly string name = "百度卫星地图";
        public override string Name => name;

        static BaiduSatelliteMapProvider()
        {
            Instance = new BaiduSatelliteMapProvider();
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
            var num = (pos.X + pos.Y) % 8 + 1;

            // // 计算当前层级下瓦片总数的一半，用于定位整个地图的中心点
            // var halfTileNum = Math.Pow(2, zoom - 1);
            // // 原点移到中心点后，计算xy方向上新的坐标位置
            // var baiduX = pos.X - halfTileNum;
            // var baiduY = pos.Y + halfTileNum;

            // // 百度瓦片服务url将负数使用M前缀来标识
            // if (baiduX < 0)
            // {
            //     baiduX = 'M' + (-baiduX);
            // }
            // if (baiduY < 0)
            // {
            //     baiduY = 'M' + (-baiduY);
            // }


            var offsetX = Math.Pow(2, zoom - 1); 
            var offsetY = offsetX - 1; 
            var numX = pos.X - offsetX;
            var numY = -pos.Y + offsetY; 
            var baiduX = numX.ToString().Replace("-", "M");
            var baiduY = numY.ToString().Replace("-", "M");

            string url = $"https://maponline{num}.bdimg.com/starpic/?qt=satepc&u=x={baiduX};y={baiduY};z={zoom};v=009;type=sate&fm=46&udt=20220830";
            Console.WriteLine(url);
            return url;
        }
    }
}
