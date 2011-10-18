using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BoxedIce.ServerDensity.Agent.Checks
{
    public abstract class PerformanceCounterBasedCheck
    {
        public abstract IDictionary<string, string> Names { get; }

        public PerformanceCounterBasedCheck()
        {
        }

        protected internal PerformanceCounter PerformanceCounter
        {
            get
            {
                if (_counter != null)
                {
                    return _counter;
                }

                foreach (string key in Names.Keys)
                {
                    try
                    {
                        _counter = new PerformanceCounter(key, Names[key], "_Total");
                        return _counter;
                    }
                    catch
                    {
                    }
                }

                return null;
            }
        }

        private PerformanceCounter _counter;
    }
}
