using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using BoxedIce.ServerDensity.Agent.PluginSupport;

namespace BoxedIce.ServerDensity.Agent.Checks
{
    public class SwapMemoryUsedCheck : ICheck
    {
        #region ICheck Members

        public string Key
        {
            get { return "memSwapUsed"; }
        }

        public object DoCheck()
        {
            using (var query = new ManagementObjectSearcher("SELECT CurrentUsage FROM Win32_PageFileUsage"))
            {
                foreach (ManagementBaseObject obj in query.Get())
                {
                    using (obj)
                    {
                        uint used = (uint)obj.GetPropertyValue("CurrentUsage");
                        return used;
                    }
                }
            }
            return 0;
        }

        #endregion
    }
}
