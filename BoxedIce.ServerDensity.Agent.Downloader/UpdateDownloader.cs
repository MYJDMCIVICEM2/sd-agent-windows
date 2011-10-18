using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using log4net;

namespace BoxedIce.ServerDensity.Agent.Downloader
{
    /// <summary>
    /// Class to manage downloading updates to the agent.
    /// </summary>
    public class UpdateDownloader
    {
        #region Properties
        /// <summary>
        /// Gets the file currently being downloaded.
        /// </summary>
        public KeyValuePair<string, string> CurrentFile
        {
            get { return _currentFile; }
        }

        /// <summary>
        /// Gets the percentage completed.
        /// </summary>
        public decimal Percentage
        {
            get { return Decimal.Round(((decimal)_current / (decimal)_total * 100), 2); }
        }

        /// <summary>
        /// Gets a value indicating whether or not the downloader is running.
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initialises a new instance of the <see cref="Downloader"/> class 
        /// with the provided values.
        /// </summary>
        /// <param name="files">The files to download.</param>
        public UpdateDownloader(IDictionary<string, string> files)
        {
            _files = files;
            _current = 0;
            _total = _files.Count;
            foreach (KeyValuePair<string, string> file in files)
            {
                // Set the current file to the first one.
                _currentFile = file;
                break;
            }
        }
        #endregion

        /// <summary>
        /// Starts the download process.
        /// </summary>
        public void Start()
        {
            _isRunning = true;
            _thread = new Thread(new ThreadStart(DownloadFiles));
            _thread.Start();
        }

        /// <summary>
        /// Stops the download process.
        /// </summary>
        public void Stop()
        {
            try
            {
                _isRunning = false;
                _thread.Join(0);
                _thread.Abort();
            }
            catch (ThreadAbortException)
            {
            }
        }

        private void DownloadFiles()
        {
            foreach (KeyValuePair<string, string> file in _files)
            {
                _currentFile = file;
                try
                {
                    DownloadFile(file.Key, file.Value);
                    OnProgressUpdated(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    OnError(EventArgs.Empty);
                    _isRunning = false;
                    return;
                }
            }
            OnComplete(EventArgs.Empty);
            _isRunning = false;
        }

        private void DownloadFile(string fileName, string expectedMD5Hash)
        {
            Log.DebugFormat("Requesting {0}...", fileName);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", DefaultUrl, fileName));
            Log.Debug("done.");
            Log.Debug("Retrieving response...");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Log.Debug("done.");
            using (Stream stream = response.GetResponseStream())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int read = 0;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        memoryStream.Write(buffer, 0, read);
                    }

                    Log.DebugFormat("Downloaded {0}. Confirming MD5 hash...", fileName);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    string md5Hash = MD5Sum(memoryStream);
                    if (md5Hash != expectedMD5Hash)
                    {
                        Log.Warn("Invalid MD5 hash!");
                        OnError(EventArgs.Empty);
                        return;
                    }
                    Log.Debug("done.");
                    _current++;

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    using (FileStream fileStream = File.OpenWrite(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
                    {
                        // We can read this in chunks, but updates are small, so we'll
                        // do this for now.
                        byte[] data = memoryStream.ToArray();
                        fileStream.Write(data, 0, data.Length);
                    }
                }
            }
        }

        private string MD5Sum(Stream inputStream)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] md5Data = md5.ComputeHash(inputStream);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Data.Length; i++)
            {
                sb.Append(md5Data[i].ToString("x2"));
            }
            md5.Clear();
            return sb.ToString();
        }

        #region Event-raising methods
        private void OnError(EventArgs e)
        {
            if (Error == null)
            {
                return;
            }
            Error(this, e);
        }

        private void OnComplete(EventArgs e)
        {
            if (Complete == null)
            {
                return;
            }
            Complete(this, e);
        }

        private void OnProgressUpdated(EventArgs e)
        {
            if (ProgressUpdated == null)
            {
                return;
            }
            ProgressUpdated(this, e);
        }
        #endregion

        private static readonly ILog Log = LogManager.GetLogger(typeof(UpdateDownloader));
        private const int BUFFER_SIZE = 65536;
        private const string DefaultUrl = "http://www.serverdensity.com/downloads/sd-agent-windows/";
        
        private IDictionary<string, string> _files;
        private KeyValuePair<string, string> _currentFile;
        private Thread _thread;
        private int _current;
        private int _total;
        private bool _isRunning;

        public event EventHandler Complete;
        public event EventHandler Error;
        public event EventHandler ProgressUpdated;
    }
}
