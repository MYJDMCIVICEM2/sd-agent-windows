using System;
using BoxedIce.ServerDensity.Agent;

namespace BoxedIce.ServerDensity.Agent.Tasks
{
    public class WriteAgentConfigurationTask : ITask
    {
        public WriteAgentConfigurationTask(AgentConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Run()
        {
            _configuration.Write();
        }

        private readonly AgentConfiguration _configuration;
    }
}
