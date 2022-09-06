using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.map.MapProviders
{
    class MapProviders
    {
        static MapProviders()
        {
            List = new List<GMapProvider>();

            var type = typeof(MapProviders);

            foreach (var p in type.GetFields())
            {
                var v = p.GetValue(null) as GMapProvider; // static classes cannot be instanced, so use null...
                if (v != null)
                {
                    List.Add(v);
                }
            }

            Hash = new Dictionary<Guid, GMapProvider>();

            foreach (var p in List)
            {
                Hash.Add(p.Id, p);
            }

            DbHash = new Dictionary<int, GMapProvider>();

            foreach (var p in List)
            {
                DbHash.Add(p.DbId, p);
            }
        }

        MapProviders()
        {
        }

        public static readonly AMapSatelliteProvider AMapSatellite = AMapSatelliteProvider.Instance;

        public static readonly ArcGISSatelliteProvider ArcGISSatellite = ArcGISSatelliteProvider.Instance;

        public static readonly TianDiTuSatelliteProvider TianDiTuSatellite = TianDiTuSatelliteProvider.Instance;

        //百度地图坐标换算有问题
        //public static readonly BaiduSatelliteMapProvider BaiduSatellite = BaiduSatelliteMapProvider.Instance;

        //腾讯地图偏移有问题
        //public static readonly TencentSatelliteMapProvider TencentSatellite = TencentSatelliteMapProvider.Instance;

        /// <summary>
        ///     get all instances of the supported providers
        /// </summary>
        public static List<GMapProvider> List
        {
            get;
        }

        //public static OpenStreetMapGraphHopperProvider OpenStreetMapGraphHopperProvider => openStreetMapGraphHopperProvider;

        static Dictionary<Guid, GMapProvider> Hash;

        public static GMapProvider TryGetProvider(Guid id)
        {
            GMapProvider ret;

            if (Hash.TryGetValue(id, out ret))
            {
                return ret;
            }

            return null;
        }

        static Dictionary<int, GMapProvider> DbHash;

        public static GMapProvider TryGetProvider(int dbId)
        {
            GMapProvider ret;

            if (DbHash.TryGetValue(dbId, out ret))
            {
                return ret;
            }

            return null;
        }

        public static GMapProvider TryGetProvider(string providerName)
        {
            if (List.Exists(x => x.Name == providerName))
            {
                return List.Find(x => x.Name == providerName);
            }
            else
            {
                return null;
            }
        }
    }
}
