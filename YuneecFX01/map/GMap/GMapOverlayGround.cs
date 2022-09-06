using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuneecFX01.tool;

namespace YuneecFX01.map.GMap
{
    /// <summary>
    /// 训练场地图层
    /// </summary>
    public class GMapOverlayGround : GMapOverlay
    {
        /// <summary>
        /// 中心点圆
        /// </summary>
        private GMapMarkerCircle GroundCenteCircle;
        /// <summary>
        /// 八字底纹
        /// </summary>
        private GMapMarkerCircle[] EightBackground = new GMapMarkerCircle[2];
        /// <summary>
        /// 八字圆心
        /// </summary>
        private GMapMarkerCircle[] EightCircleCenter = new GMapMarkerCircle[2];
        /// <summary>
        /// 八字基准
        /// </summary>
        private GMapMarkerCircle[] EightCircleBase = new GMapMarkerCircle[2];
        /// <summary>
        /// 八字边界
        /// </summary>
        private GMapMarkerCircle[] EightCircleBorder = new GMapMarkerCircle[4];
        /// <summary>
        /// 八字桩桶
        /// </summary>
        private GMapMarkerCircle[] EightYawPoint = new GMapMarkerCircle[8];

        /// <summary>
        /// 中心点
        /// </summary>
        public PointLatLng CentePoint = default;
        /// <summary>
        /// 左圆心
        /// </summary>
        public PointLatLng LeftPoint = default;
        /// <summary>
        /// 右圆心
        /// </summary>
        public PointLatLng RightPoint = default;
        /// <summary>
        /// 中心点半径
        /// </summary>
        public float CenterRadius = default;
        /// <summary>
        /// 八字飞行半径
        /// </summary>
        public float EightRadius = default;
        /// <summary>
        /// 八字水平偏移
        /// </summary>
        public float EightOffset = default;

        public GMapOverlayGround(string id, PointLatLng pos) : base(id)
        {
            CentePoint = pos;

            // 中心点圆
            GroundCenteCircle = new GMapMarkerCircle(pos, 1f, Color.OrangeRed);
            this.Markers.Add(GroundCenteCircle);

            // 八字底纹
            for (int i = 0; i < EightBackground.Length; i++)
            {
                EightBackground[i] = new GMapMarkerCircle(pos, 6f, Color.DodgerBlue);
                EightBackground[i].Stroke.Color = Color.FromArgb(48, Color.White);
                EightBackground[i].IsBackGround = true;
                this.Markers.Add(EightBackground[i]);
            }
            // 八字圆心
            for (int i = 0; i < EightCircleCenter.Length; i++)
            {
                EightCircleCenter[i] = new GMapMarkerCircle(pos, 0.5f, Color.OrangeRed);
                this.Markers.Add(EightCircleCenter[i]);
            }
            EightCircleCenter[0].Fill = new SolidBrush(Color.FromArgb(255, Color.OrangeRed));
            EightCircleCenter[0].IsFilled = true;
            // 八字基准
            for (int i = 0; i < EightCircleBase.Length; i++)
            {
                EightCircleBase[i] = new GMapMarkerCircle(pos, 6f, Color.OrangeRed);
                this.Markers.Add(EightCircleBase[i]);
            }
            // 八字边界
            for (int i = 0; i < EightCircleBorder.Length; i++)
            {
                EightCircleBorder[i] = new GMapMarkerCircle(pos, 6f, Color.LightBlue);
                this.Markers.Add(EightCircleBorder[i]);
            }
            // 八字桩桶
            for (int i = 0; i < EightYawPoint.Length; i++)
            {
                EightYawPoint[i] = new GMapMarkerCircle(pos, 0.5f, Color.DodgerBlue);
                this.Markers.Add(EightYawPoint[i]);
            }
        }

        public void UpdateCircleStyle()
        {
            // 中心点圆
            GroundCenteCircle.Position = CentePoint;
            GroundCenteCircle.Radius = CenterRadius;

            // 左圆底纹
            EightBackground[0].Position = LeftPoint;
            EightBackground[0].Radius = EightRadius;
            EightBackground[0].BackGroundWidth = EightOffset * 2;
            // 左圆圆心
            EightCircleCenter[0].Position = LeftPoint;
            // 左基准圆
            EightCircleBase[0].Position = LeftPoint;
            EightCircleBase[0].Radius = EightRadius;

            // 右圆底纹
            EightBackground[1].Position = RightPoint;
            EightBackground[1].Radius = EightRadius;
            EightBackground[1].BackGroundWidth = EightOffset * 2;
            // 右圆圆心
            EightCircleCenter[1].Position = RightPoint;
            // 右基准圆
            EightCircleBase[1].Position = RightPoint;
            EightCircleBase[1].Radius = EightRadius;

            // 左内边界
            EightCircleBorder[0].Position = LeftPoint;
            EightCircleBorder[0].Radius = EightRadius - EightOffset / 2;
            // 左外边界
            EightCircleBorder[1].Position = LeftPoint;
            EightCircleBorder[1].Radius = EightRadius + EightOffset / 2;
            // 右内边界
            EightCircleBorder[2].Position = RightPoint;
            EightCircleBorder[2].Radius = EightRadius - EightOffset / 2;
            // 右外边界
            EightCircleBorder[3].Position = RightPoint;
            EightCircleBorder[3].Radius = EightRadius + EightOffset / 2;

            // 八字桩点
            PointLatLng[] plYawPoint;
            plYawPoint = TestTools.AB_Loc_Calcu(
                EightCircleBase[0].Position.Lng, EightCircleBase[0].Position.Lat,
                EightCircleBase[1].Position.Lng, EightCircleBase[1].Position.Lat,
                (double)EightCircleBase[0].Radius);
            for (int j = 0; j < 8; j++)
            {
                EightYawPoint[j].Position = plYawPoint[j];
            }

            Control.Refresh();
        }

        public override void OnRender(Graphics g)
        {
            if (!IsVisibile) return;
            foreach (var circle in EightBackground)
            {
                circle.OnRender(g);
            }
            foreach (var circle in EightCircleCenter)
            {
                circle.OnRender(g);
            }
            foreach (var circle in EightCircleBorder)
            {
                circle.OnRender(g);
            }
            foreach (var circle in EightCircleBase)
            {
                circle.OnRender(g);
            }
            foreach (var circle in EightYawPoint)
            {
                circle.OnRender(g);
            }
            GroundCenteCircle.OnRender(g);
        }
    }
}
