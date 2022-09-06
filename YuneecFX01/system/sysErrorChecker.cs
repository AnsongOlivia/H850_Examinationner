using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuneecFX01.tool;
using static YuneecFX01.system.sysConstant;

namespace YuneecFX01.system
{
    public class sysErrorChecker
    {

        static List<sysErrorChecker> checkers = new List<sysErrorChecker>();

        public static void ResetAll()
        {
            foreach (var checker in checkers)
            {
                checker.Reset();
            }
        }

        public delegate void Invoke0(FlyDataModel flyData);

        internal ErrorFlag errorFlag;
        internal Invoke0 onFirst;
        internal Action onRepet;

        internal long errorOccurTime;
        internal long errorJudgeTime;
        internal FlyDataModel flyData;

        public sysErrorChecker(ErrorFlag errorFlag, Invoke0 onFirst, Action onRepet)
        {
            this.errorFlag = errorFlag;
            this.onFirst = onFirst;
            this.onRepet = onRepet;
            sysErrorChecker.checkers.Add(this);
        }

        public void Judge(bool flag)
        {
            if (flag)
            {
                if ((sysDataModel.ErrorFlag & errorFlag) != errorFlag)
                {
                    if (flyData == null) flyData = (FlyDataModel)sysDataModel.flyData.Clone();
                    if (errorOccurTime == 0)
                    {
                        errorOccurTime = TimeHelper.Timestamp;
                        sysLog.Debug("{error} occur at {time}", errorFlag, errorOccurTime);
                        sysLog.Debug("occur location {Latitude} {Longtitude}", flyData.origin.Latitude, flyData.origin.Longtitude);
                    }
                    if (TimeHelper.Timestamp - errorOccurTime > 1000)
                    {
                        sysDataModel.ErrorFlag |= errorFlag;
                        errorJudgeTime = TimeHelper.Timestamp;
                        sysLog.Debug("{error} judge at {time}", errorFlag, errorJudgeTime);
                        sysLog.Debug("judge location {Latitude} {Longtitude}", flyData.origin.Latitude, flyData.origin.Longtitude);
                        this.onFirst.Invoke(flyData);
                    }
                }
                else
                {
                    errorJudgeTime = TimeHelper.Timestamp;
                    this.onRepet.Invoke();
                }
            }
            else
            {
                errorOccurTime = 0;
                flyData = null;
                if ((sysDataModel.ErrorFlag & errorFlag) == errorFlag 
                    && errorJudgeTime > 0 
                    && TimeHelper.Timestamp - errorJudgeTime > 1000)
                {
                    sysDataModel.ErrorFlag &= ~errorFlag;
                    errorJudgeTime = 0;
                }
            }
        }

        public void Reset()
        {
            errorOccurTime = 0;
            errorJudgeTime = 0;
            flyData = null;
        }

        public bool IsHappened()
        {
            return (sysDataModel.ErrorFlag & errorFlag) == errorFlag;
        }
    }
}
