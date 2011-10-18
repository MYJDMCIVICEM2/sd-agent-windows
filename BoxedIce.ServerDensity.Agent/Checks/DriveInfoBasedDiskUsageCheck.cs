using System;
using System.Collections;
using System.Diagnostics;
using log4net;
using System.IO;

namespace BoxedIce.ServerDensity.Agent.Checks
{
    public class DriveInfoBasedDiskUsageCheck : DiskUsageCheck
    {
        public new object DoCheck()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            ArrayList results = new ArrayList();

            foreach (DriveInfo info in drives)
            {
                try
                {
                    string fileSystem = info.DriveFormat;
                    ulong available = (ulong)info.TotalFreeSpace;
                    ulong totalSize = (ulong)info.TotalSize;
                    string mountedOn = info.Name;
                    ulong used = totalSize - available;

                    results.Add(new object[] { fileSystem, "", Gigabytes(used), Gigabytes(totalSize), (int)(((float)used / (float)totalSize) * 100), mountedOn });
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }

            return results;
        }

        private static readonly ILog Log = LogManager.GetLogger(typeof(DriveInfoBasedDiskUsageCheck));
    }
}
