using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Management;
using log4net;
using BoxedIce.ServerDensity.Agent.PluginSupport;

namespace BoxedIce.ServerDensity.Agent.Checks
{
    public class IISCheck : PerformanceCounterBasedCheck, ICheck
    {
        #region ICheck Members

        public string Key
        {
            get { return "iisReqPerSec"; }
        }

        public override IDictionary<string, string> Names
        {
            get { return _names; }
        }

        public IISCheck() : base()
        {
            _names = new Dictionary<string, string>();
            _names.Add("Web Service", "Total Method Requests/sec");
            _names.Add("Servizio Web", "Totale richieste metodo/sec");
        }

        public object DoCheck()
        {
            if (PerformanceCounter == null)
            {
                Log.Warn("Performance counter is null.");
                return null;
            }

            float requestsPerSecond = PerformanceCounter.NextValue();
            Log.DebugFormat("IIS req/s is: {0}", requestsPerSecond);
            return string.Format("{0:0.00}", requestsPerSecond);
        }

        #endregion

        private readonly ILog Log = LogManager.GetLogger(typeof(IISCheck));
        private readonly IDictionary<string, string> _names;
    }
}
