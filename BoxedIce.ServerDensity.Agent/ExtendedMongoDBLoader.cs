using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using BoxedIce.ServerDensity.Agent.PluginSupport;
using log4net;

namespace BoxedIce.ServerDensity.Agent
{
    public class ExtendedMongoDBLoader
    {
        public ExtendedMongoDBLoader(string connectionString, bool isReplSet, bool dbStats)
        {
            _connectionString = connectionString;
            _isReplSet = isReplSet;
            _dbStats = dbStats;
        }

        public ICheck Load()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mongodb");

            if (!Directory.Exists(path))
            {
                return null;
            }

            foreach (string fileName in Directory.GetFiles(path))
            {
                Assembly asm = Assembly.LoadFrom(fileName);
                _assemblies.Add(asm);
            }

            foreach (Assembly asm in _assemblies)
            {
                if (asm.FullName.IndexOf("BoxedIce.ServerDensity.Agent.MongoDB") != -1)
                {
                    object[] args = new object[] { _connectionString, _isReplSet, _dbStats };
                    ICheck check = (ICheck)asm.CreateInstance("BoxedIce.ServerDensity.Agent.MongoDB.ExtendedMongoDBCheck", false, BindingFlags.CreateInstance, null, args, null, null);
                    return check;
                }
            }
            
            return null;
        }

        public static bool AdvancedStatsSupported()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mongodb");
                return Directory.Exists(path);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return false;
            }
        }
        
        private string _connectionString;
        private bool _isReplSet;
        private bool _dbStats;
        private IList<Assembly> _assemblies = new List<Assembly>();
        private static readonly ILog Log = LogManager.GetLogger(typeof(ExtendedMongoDBLoader));
    }
}
