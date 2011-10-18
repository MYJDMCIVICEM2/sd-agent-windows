using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;

namespace BoxedIce.ServerDensity.Agent
{
    public class AgentConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("url", IsRequired = true)]
        public string ServerDensityUrl
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string AgentKey
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("debugMode", DefaultValue = false, IsRequired = false)]
        public bool DebugMode
        {
            get { return (bool)this["debugMode"]; }
            set { this["debugMode"] = value; }
        }

        [ConfigurationProperty("checkInterval", DefaultValue = 60000, IsRequired = false)]
        public int CheckInterval
        {
            get { return (int)this["checkInterval"]; }
            set { this["checkInterval"] = value; }
        }

        [ConfigurationProperty("iisStatus", DefaultValue = false, IsRequired = false)]
        public bool IISStatus
        {
            get { return (bool)this["iisStatus"]; }
            set { this["iisStatus"] = value; }
        }

        [ConfigurationProperty("pluginDirectory", DefaultValue = null, IsRequired = false)]
        public string PluginDirectory
        {
            get 
            {

                try
                {
                    return (string)this["pluginDirectory"];
                }
                catch(NullReferenceException)
                {
                    return String.Empty;
                }

            }
            set { this["pluginDirectory"] = value; }
        }

        [ConfigurationProperty("sqlServerConnectionString", DefaultValue = null, IsRequired = false)]
        public string SqlServerConnectionString
        {
            get
            {

                try
                {
                    return (string)this["sqlServerConnectionString"];
                }
                catch (NullReferenceException)
                {
                    return String.Empty;
                }

            }
            set { this["sqlServerConnectionString"] = value; }
        }

        [ConfigurationProperty("mongoDBConnectionString", DefaultValue = null, IsRequired = false)]
        public string MongoDBConnectionString
        {
            get
            {

                try
                {
                    return (string)this["mongoDBConnectionString"];
                }
                catch (NullReferenceException)
                {
                    return String.Empty;
                }

            }
            set { this["mongoDBConnectionString"] = value; }
        }

        [ConfigurationProperty("mongoDBDBStats", DefaultValue = false, IsRequired = false)]
        public bool MongoDBDBStats
        {
            get
            {
                try
                {
                    return (bool)this["mongoDBDBStats"];
                }
                catch (NullReferenceException)
                {
                    return false;
                }
            }
            set { this["mongoDBDBStats"] = value; }
        }

        [ConfigurationProperty("mongoDBReplSet", DefaultValue = false, IsRequired = false)]
        public bool MongoDBReplSet
        {
            get
            {
                try
                {
                    return (bool)this["mongoDBReplSet"];
                }
                catch (NullReferenceException)
                {
                    return false;
                }
            }
            set { this["mongoDBReplSet"] = value; }
        }

        [ConfigurationProperty("sqlServerStatus", DefaultValue = false, IsRequired = false)]
        public bool SQLServerStatus
        {
            get 
            {

                try
                {
                    return (bool)this["sqlServerStatus"];
                }
                catch (NullReferenceException)
                {
                    return false;
                }

            }
            set { this["sqlServerStatus"] = value; }
        }

        [ConfigurationProperty("customPrefix", DefaultValue = null, IsRequired = false)]
        public string CustomPrefix
        {
            get
            {

                try
                {
                    return (string)this["customPrefix"];
                }
                catch (NullReferenceException)
                {
                    return null;
                }

            }
            set { this["customPrefix"] = value; }
        }

        [ConfigurationProperty("eventViewer", DefaultValue = true, IsRequired = false)]
        public bool EventViewer
        {
            get { return (bool)this["eventViewer"]; }
            set { this["eventViewer"] = value; }
        }
    }
}
