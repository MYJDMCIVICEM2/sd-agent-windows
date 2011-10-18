using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BoxedIce.ServerDensity.Agent.PluginSupport;

namespace PluginExample
{
    public class ASPNet : ICheck
    {
        public string Key
        {
            get { return "ASPNET"; }
        }

        public object DoCheck()
        {
            PerformanceCounterCategory category = new PerformanceCounterCategory("ASP.NET");
            IDictionary<string, object> values = new Dictionary<string, object>();

            foreach (PerformanceCounter counter in category.GetCounters())
            {
                values.Add(counter.CounterName, counter.NextValue());
            }
            
            return values;
        }
    }
}
