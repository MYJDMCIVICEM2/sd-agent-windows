using System;
using System.ServiceProcess;

namespace BoxedIce.ServerDensity.Agent.Tasks
{
    public class StartServiceTask : ITask
    {
        public void Run()
        {
            ServiceController service = new ServiceController("Server Density Monitoring Agent");
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
        }
    }
}
