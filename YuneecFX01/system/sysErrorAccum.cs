using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuneecFX01.tool;
using static YuneecFX01.system.sysConstant;

namespace YuneecFX01.system
{
    public class sysErrorAccum : sysErrorChecker
    {
        private bool inOccur;
        private long lastOccurTime;
        private long totalOccurTime;
        public sysErrorAccum(ErrorFlag errorFlag, Invoke0 onFirst, Action onRepet) : base(errorFlag, onFirst, onRepet)
        {
        }

        public new void Judge(bool flag)
        {
            throw new NotImplementedException();
        }

        public void Judge(bool flag, long totleFlyTime)
        {
            if ((sysDataModel.ErrorFlag & errorFlag) != errorFlag)
            {
                if (flag)
                {
                    if (lastOccurTime == 0)
                    {
                        lastOccurTime = TimeHelper.Timestamp;
                    }
                }
                else
                {
                    if (lastOccurTime != 0)
                    {
                        totalOccurTime += TimeHelper.Timestamp - lastOccurTime;
                        lastOccurTime = 0;
                    }
                }
                if (totalOccurTime > totleFlyTime * 0.3)
                {
                    flyData = (FlyDataModel)sysDataModel.flyData.Clone();
                    sysLog.Debug("{error} judge at {time}", errorFlag, TimeHelper.Timestamp);
                    sysLog.Debug("judge location {Latitude} {Longtitude}", flyData.origin.Latitude, flyData.origin.Longtitude);
                    this.onFirst.Invoke(flyData);
                }
            }
        }

        public new void Reset()
        {
            lastOccurTime = 0;
            totalOccurTime = 0;
            flyData = null;
        }
    }
}
