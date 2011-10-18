using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using BoxedIce.ServerDensity.Agent.PluginSupport;

namespace BoxedIce.ServerDensity.Agent.Checks
{
    public class SwapMemoryFreeCheck : ICheck
    {
        #region ICheck Members

        public string Key
        {
            get { return "memSwapFree"; }
        }

        public object DoCheck()
        {
            using (var query = new ManagementObjectSearcher("SELECT AllocatedBaseSize, CurrentUsage FROM Win32_PageFileUsage"))
            {
                uint total = 0;
                uint used = 0;
                foreach (ManagementBaseObject obj in query.Get())
                {
                    using (obj)
                    {
                        total += (uint)obj.GetPropertyValue("AllocatedBaseSize");
                        used += (uint)obj.GetPropertyValue("CurrentUsage");
                    }
                }
                return total - used;
            }
            return 0;
        }

        #endregion
    }
}
