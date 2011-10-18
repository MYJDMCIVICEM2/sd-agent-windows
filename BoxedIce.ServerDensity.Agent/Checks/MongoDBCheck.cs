using System;
using System.Collections.Generic;
using System.Text;
using BoxedIce.ServerDensity.Agent.PluginSupport;
using MongoDB.Driver;
using log4net;

namespace BoxedIce.ServerDensity.Agent.Checks
{
    public class MongoDBCheck : ICheck
    {
        #region ICheck Members

        public string Key
        {
            get { return "mongoDB"; }
        }

        public virtual object DoCheck()
        {
            Document commandResults = null;
            Mongo mongo = null;
            
            try
            {
                mongo = new Mongo(_connectionString);
                mongo.Connect();

                // In the Linux agent, we get all database names and use the first
                // one found, but no such functionality exists with this .NET
                // MongoDB library.
                Database database = mongo.GetDatabase(DatabaseName);
                commandResults = database.SendCommand("serverStatus");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return null;
            }
            finally
            {

                if (mongo != null)
                {
                    mongo.Disconnect();
                }

            }

            if (commandResults == null)
            {
                Log.Warn("MongoDB returned no results for serverStatus command.");
                Log.Warn("This is possible on older versions of MongoDB.");
                return null;
            }

            Document indexCounters = (Document)commandResults["indexCounters"];
            Document btree = null;

            // Index counters are currently not supported on Windows.
            if (indexCounters["note"] == null)
            {
                btree = (Document)indexCounters["btree"];
            }
            else
            {
                // We add a blank document, since the server is expecting
                // these btree index values to be present.
                btree = new Document();
                indexCounters.Add("btree", btree);
                btree.Add("accesses", 0);
                btree.Add("accessesPS", 0);
                btree.Add("hits", 0);
                btree.Add("hitsPS", 0);
                btree.Add("misses", 0);
                btree.Add("missesPS", 0);
                btree.Add("missRatio", 0D);
                btree.Add("missRatioPS", 0);
            }

            Document opCounters = (Document)commandResults["opcounters"];
            Document asserts = (Document)commandResults["asserts"];

            if (_mongoDBStore == null)
            {
                Log.Debug("No cached data, so storing for the first time.");

                btree["accessesPS"] = 0;
                btree["hitsPS"] = 0;
                btree["missesPS"] = 0;
                btree["missRatioPS"] = 0;

                opCounters.Add("insertPS", 0);
                opCounters.Add("queryPS", 0);
                opCounters.Add("updatePS", 0);
                opCounters.Add("deletePS", 0);
                opCounters.Add("getmorePS", 0);
                opCounters.Add("commandPS", 0);

                asserts.Add("regularPS", 0);
                asserts.Add("warningPS", 0);
                asserts.Add("msgPS", 0);
                asserts.Add("userPS", 0);
                asserts.Add("rolloversPS", 0);
            }
            else
            {
                Log.Debug("Cached data exists, so calculating per sec metrics.");

                Document cachedBtree = (Document)((Document)_mongoDBStore["indexCounters"])["btree"];
                Document cachedOpCounters = (Document)_mongoDBStore["opcounters"];
                Document cachedAsserts = (Document)commandResults["asserts"];

                btree["accessesPS"] = (float)(((int)btree["accesses"] - (int)cachedBtree["accesses"]) / 60);
                btree["hitsPS"] = (float)(((int)btree["hits"] - (int)cachedBtree["hits"]) / 60);
                btree["missesPS"] = (float)(((int)btree["misses"] - (int)cachedBtree["misses"]) / 60);
                btree["missRatioPS"] = (float)(((double)btree["missRatio"] - (double)cachedBtree["missRatio"]) / 60);

                opCounters.Add("insertPS", (float)(((int)opCounters["insert"] - (int)cachedOpCounters["insert"]) / 60));
                opCounters.Add("queryPS", (float)(((int)opCounters["query"] - (int)cachedOpCounters["query"]) / 60));
                opCounters.Add("updatePS", (float)(((int)opCounters["update"] - (int)cachedOpCounters["update"]) / 60));
                opCounters.Add("deletePS", (float)(((int)opCounters["delete"] - (int)cachedOpCounters["delete"]) / 60));
                opCounters.Add("getmorePS", (float)(((int)opCounters["getmore"] - (int)cachedOpCounters["getmore"]) / 60));
                opCounters.Add("commandPS", (float)(((int)opCounters["command"] - (int)cachedOpCounters["command"]) / 60));

                asserts.Add("regularPS", (float)(((int)asserts["regular"] - (int)cachedAsserts["regular"]) / 60));
                asserts.Add("warningPS", (float)(((int)asserts["warning"] - (int)cachedAsserts["warning"]) / 60));
                asserts.Add("msgPS", (float)(((int)asserts["msg"] - (int)cachedAsserts["msg"]) / 60));
                asserts.Add("userPS", (float)(((int)asserts["user"] - (int)cachedAsserts["user"]) / 60));
                asserts.Add("rolloversPS", (float)(((int)asserts["rollovers"] - (int)cachedAsserts["rollovers"]) / 60));
            }

            _mongoDBStore = commandResults;

            return _mongoDBStore;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="MongoDBCheck"/> class with the provided values.
        /// </summary>
        /// <param name="connectionString">The connection string of the MongoDB instance to check.</param>
        public MongoDBCheck(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        protected readonly string _connectionString;
        private Document _mongoDBStore;
        private const string DatabaseName = "local";
        private readonly static ILog Log = LogManager.GetLogger(typeof(MongoDBCheck));
    }
}
