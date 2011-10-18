using System;
using System.Collections.Generic;
using BoxedIce.ServerDensity.Agent.PluginSupport;

namespace PluginExample
{
    public class Hats : ICheck
    {
        #region ICheck Members

        public string Key
        {
            get { return "plugin1"; }
        }

        public object DoCheck()
        {
            IDictionary<string, object> values = new Dictionary<string, object>();
            values.Add("hats", 5);
            values.Add("Dinosaur Rex", 25.4);
            return values;
        }

        #endregion
    }
}
