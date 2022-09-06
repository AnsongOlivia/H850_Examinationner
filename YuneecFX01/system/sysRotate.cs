using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.system
{
    public class sysRotate
    {
        int angle = 0b00_0000_0000;
        int angleEmpty = 0b00_0000_0000;
        int angleFull = 0b11_1111_1111;

        internal void Reset()
        {
            angle = angleEmpty;
        }

        /// <summary>
        /// 更新角度数据
        /// </summary>
        /// <param name="yawAngle">角度范围：[0°, 360°)或[-180°, +180°)</param>
        internal void Update(float yawAngle)
        {
            yawAngle = yawAngle < 0 ? yawAngle + 360 : yawAngle;
            int bitLocation = (int)(yawAngle / 36.0);
            angle |= 1 << bitLocation;
        }

        /// <summary>
        /// 判断是否完成
        /// </summary>
        /// <returns></returns>
        internal bool Done()
        {
            return angle == angleFull;
        }
    }
}
