using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace BoxedIce.ServerDensity.Agent.WindowsService
{
    [RunInstallerAttribute(true)]
    public class AgentServiceInstaller : Installer
    {
        public AgentServiceInstaller()
        {
            ServiceInstaller si = new ServiceInstaller();
            ServiceProcessInstaller spi = new ServiceProcessInstaller();

            si.ServiceName = "Server Density Monitoring Agent";
            si.DisplayName = "Server Density Monitoring Agent";
            si.Description = "The lightweight, open source monitoring agent for Server Density (serverdensity.com).";
            si.StartType = ServiceStartMode.Automatic;
            this.Installers.Add(si);

            spi.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            spi.Password = null;
            spi.Username = null;
            this.Installers.Add(spi);
        }
    }
}
