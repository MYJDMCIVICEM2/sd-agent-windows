using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;
using System.Text;
using BoxedIce.ServerDensity.Agent.PluginSupport;

namespace BoxedIce.ServerDensity.Agent.Checks
{
    /// <summary>
    /// Class for checking disk usage.
    /// </summary>
    public class DiskUsageCheck : ICheck
    {
        #region ICheck Members

        public string Key
        {
            get { return "diskUsage"; }
        }

        public object DoCheck()
        {
            var results = new ArrayList();
            // A DriveType of 3 indicates a local disk.
            using (var query = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE DriveType = 3"))
            {
                var list = query.Get();
                using (list)
                {
                    foreach (var drive in list)
                    {
                        object fileSystemValue = drive.GetPropertyValue("FileSystem");
                        object availableValue = drive.GetPropertyValue("FreeSpace");
                        object totalSizeValue = drive.GetPropertyValue("Size");
                        object mountedOnValue = drive.GetPropertyValue("DeviceID");

                        string fileSystem = fileSystemValue == null ? string.Empty : (string)fileSystemValue;
                        ulong available = availableValue == null ? 0 : (ulong)availableValue;
                        ulong totalSize = totalSizeValue == null ? 0 : (ulong)totalSizeValue;
                        ulong used = totalSize - available;
                        var mountedOn = mountedOnValue == null ? string.Empty : (string)mountedOnValue;
                        int percentUsed = 0;
                        if (totalSize > 0)
                        {
                            percentUsed = (int)(((float)used / (float)totalSize) * 100);
                        }
                        results.Add(new object[] { fileSystem, "", Gigabytes(used), Gigabytes(totalSize), percentUsed, mountedOn });
                    }
                    return results;
                }
            }
        }

        #endregion

        private object GetPropertyValue(ManagementBaseObject drive, string propertyName)
        {
            return drive.GetPropertyValue(propertyName);
        }

        protected ulong Gigabytes(ulong value)
        {
            return value / 1024 / 1024 / 1024;
        }
    }
}
