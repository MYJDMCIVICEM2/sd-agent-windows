using System;
using System.ServiceProcess;

namespace BoxedIce.ServerDensity.Agent.Tasks
{
    public class StopServiceTask : ITask
    {
        public void Run()
        {
            try
            {
                ServiceController service = new ServiceController("Server Density Monitoring Agent");
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
