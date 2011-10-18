using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using BoxedIce.ServerDensity.Agent.PluginSupport;
using log4net;

namespace BoxedIce.ServerDensity.Agent.Checks
{
    public class NetworkTrafficCheck : ICheck
    {
        #region ICheck Members

        public string Key
        {
            get { return "networkTraffic"; }
        }

        public object DoCheck()
        {
            IDictionary<string, Dictionary<string, long>> results = new Dictionary<string, Dictionary<string, long>>();
            Log.InfoFormat("Hash code: {0}", _networkTrafficStore.GetHashCode());
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var nic in interfaces)
            {

                if (nic.OperationalStatus != OperationalStatus.Up)
                {
                    continue;
                }

                var stats = nic.GetIPv4Statistics();
                long received = stats.BytesReceived;
                long sent = stats.BytesSent;
                var key = nic.Name;

                Log.InfoFormat("{0} - Received: {1}", key, received);
                Log.InfoFormat("{0} - Sent: {1}", key, sent);
        
                if (!_networkTrafficStore.ContainsKey(key))
                {
                    _networkTrafficStore.Add(key, new Dictionary<string, long>());
                    _networkTrafficStore[key]["recv_bytes"] = received;
                    _networkTrafficStore[key]["trans_bytes"] = sent;

                    if (!results.ContainsKey(key))
                    {
                        results.Add(key, new Dictionary<string, long>());
                        results[key]["recv_bytes"] = received;
                        results[key]["trans_bytes"] = sent;
                    }

                }
                else
                {

                    if (!results.ContainsKey(key))
                    {
                        results.Add(key, new Dictionary<string, long>());
                        results[key]["recv_bytes"] = received - _networkTrafficStore[key]["recv_bytes"];
                        results[key]["trans_bytes"] = sent - _networkTrafficStore[key]["trans_bytes"];

                        // Store now for calculation next time.
                        _networkTrafficStore[key]["recv_bytes"] = received;
                        _networkTrafficStore[key]["trans_bytes"] = sent;
                    }

                }

            }
            return results;
        }

        #endregion

        private static Dictionary<string, Dictionary<string, long>> _networkTrafficStore = new Dictionary<string, Dictionary<string, long>>();
        private static ILog Log = LogManager.GetLogger(typeof(NetworkTrafficCheck));
    }
}
