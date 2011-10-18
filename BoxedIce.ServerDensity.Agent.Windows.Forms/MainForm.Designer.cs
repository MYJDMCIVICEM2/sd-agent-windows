namespace BoxedIce.ServerDensity.Agent.Windows.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this._menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._preferences = new System.Windows.Forms.ToolStripMenuItem();
            this._exit = new System.Windows.Forms.ToolStripMenuItem();
            this._serverInfo = new System.Windows.Forms.GroupBox();
            this._agentKey = new System.Windows.Forms.TextBox();
            this._url = new System.Windows.Forms.TextBox();
            this._agentKeyLabel = new System.Windows.Forms.Label();
            this._urlLabel = new System.Windows.Forms.Label();
            this._other = new System.Windows.Forms.GroupBox();
            this._eventViewer = new System.Windows.Forms.CheckBox();
            this._replSet = new System.Windows.Forms.CheckBox();
            this._dbStats = new System.Windows.Forms.CheckBox();
            this._customPrefixValue = new System.Windows.Forms.TextBox();
            this._customPrefix = new System.Windows.Forms.CheckBox();
            this._sqlServer = new System.Windows.Forms.CheckBox();
            this._mongoDBConnectionString = new System.Windows.Forms.TextBox();
            this._mongoDBConnectionStringLabel = new System.Windows.Forms.Label();
            this._mongoDB = new System.Windows.Forms.CheckBox();
            this._browse = new System.Windows.Forms.Button();
            this._pluginDirectory = new System.Windows.Forms.TextBox();
            this._pluginLabel = new System.Windows.Forms.Label();
            this._plugins = new System.Windows.Forms.CheckBox();
            this._iis = new System.Windows.Forms.CheckBox();
            this._cancel = new System.Windows.Forms.Button();
            this._ok = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this._installPlugin = new System.Windows.Forms.Button();
            this._menu.SuspendLayout();
            this._serverInfo.SuspendLayout();
            this._other.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _notifyIcon
            // 
            this._notifyIcon.ContextMenuStrip = this._menu;
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "Server Density Monitoring Agent";
            this._notifyIcon.Visible = true;
            this._notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_Click);
            // 
            // _menu
            // 
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._preferences,
            this._exit});
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(145, 48);
            this._menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Item_Clicked);
            // 
            // _preferences
            // 
            this._preferences.Name = "_preferences";
            this._preferences.Size = new System.Drawing.Size(144, 22);
            this._preferences.Text = "Preferences...";
            // 
            // _exit
            // 
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(144, 22);
            this._exit.Text = "Exit";
            // 
            // _serverInfo
            // 
            this._serverInfo.Controls.Add(this._agentKey);
            this._serverInfo.Controls.Add(this._url);
            this._serverInfo.Controls.Add(this._agentKeyLabel);
            this._serverInfo.Controls.Add(this._urlLabel);
            this._serverInfo.Location = new System.Drawing.Point(12, 12);
            this._serverInfo.Name = "_serverInfo";
            this._serverInfo.Size = new System.Drawing.Size(416, 92);
            this._serverInfo.TabIndex = 0;
            this._serverInfo.TabStop = false;
            this._serverInfo.Text = "Server Information";
            // 
            // _agentKey
            // 
            this._agentKey.Location = new System.Drawing.Point(152, 56);
            this._agentKey.Name = "_agentKey";
            this._agentKey.Size = new System.Drawing.Size(248, 21);
            this._agentKey.TabIndex = 2;
            this._agentKey.Validating += new System.ComponentModel.CancelEventHandler(this.AgentKey_Validating);
            // 
            // _url
            // 
            this._url.Location = new System.Drawing.Point(152, 24);
            this._url.Name = "_url";
            this._url.Size = new System.Drawing.Size(248, 21);
            this._url.TabIndex = 1;
            this._url.Validating += new System.ComponentModel.CancelEventHandler(this.URL_Validating);
            // 
            // _agentKeyLabel
            // 
            this._agentKeyLabel.AutoSize = true;
            this._agentKeyLabel.Location = new System.Drawing.Point(16, 60);
            this._agentKeyLabel.Name = "_agentKeyLabel";
            this._agentKeyLabel.Size = new System.Drawing.Size(121, 13);
            this._agentKeyLabel.TabIndex = 1;
            this._agentKeyLabel.Text = "Your server\'s agent key";
            // 
            // _urlLabel
            // 
            this._urlLabel.AutoSize = true;
            this._urlLabel.Location = new System.Drawing.Point(16, 28);
            this._urlLabel.Name = "_urlLabel";
            this._urlLabel.Size = new System.Drawing.Size(125, 13);
            this._urlLabel.TabIndex = 0;
            this._urlLabel.Text = "Your Server Density URL";
            // 
            // _other
            // 
            this._other.Controls.Add(this._eventViewer);
            this._other.Controls.Add(this._replSet);
            this._other.Controls.Add(this._dbStats);
            this._other.Controls.Add(this._customPrefixValue);
            this._other.Controls.Add(this._customPrefix);
            this._other.Controls.Add(this._sqlServer);
            this._other.Controls.Add(this._mongoDBConnectionString);
            this._other.Controls.Add(this._mongoDBConnectionStringLabel);
            this._other.Controls.Add(this._mongoDB);
            this._other.Controls.Add(this._browse);
            this._other.Controls.Add(this._pluginDirectory);
            this._other.Controls.Add(this._pluginLabel);
            this._other.Controls.Add(this._plugins);
            this._other.Controls.Add(this._iis);
            this._other.Location = new System.Drawing.Point(12, 120);
            this._other.Name = "_other";
            this._other.Size = new System.Drawing.Size(416, 393);
            this._other.TabIndex = 2;
            this._other.TabStop = false;
            // 
            // _eventViewer
            // 
            this._eventViewer.AutoSize = true;
            this._eventViewer.Location = new System.Drawing.Point(16, 359);
            this._eventViewer.Name = "_eventViewer";
            this._eventViewer.Size = new System.Drawing.Size(151, 17);
            this._eventViewer.TabIndex = 18;
            this._eventViewer.Text = "Log errors to Event Viewer";
            this._eventViewer.UseVisualStyleBackColor = true;
            // 
            // _replSet
            // 
            this._replSet.AutoSize = true;
            this._replSet.Enabled = false;
            this._replSet.Location = new System.Drawing.Point(40, 252);
            this._replSet.Name = "_replSet";
            this._replSet.Size = new System.Drawing.Size(151, 17);
            this._replSet.TabIndex = 17;
            this._replSet.Text = "Advanced replica set stats";
            this._replSet.UseVisualStyleBackColor = true;
            // 
            // _dbStats
            // 
            this._dbStats.AutoSize = true;
            this._dbStats.Enabled = false;
            this._dbStats.Location = new System.Drawing.Point(40, 224);
            this._dbStats.Name = "_dbStats";
            this._dbStats.Size = new System.Drawing.Size(147, 17);
            this._dbStats.TabIndex = 16;
            this._dbStats.Text = "Advanced database stats";
            this._dbStats.UseVisualStyleBackColor = true;
            // 
            // _customPrefixValue
            // 
            this._customPrefixValue.Enabled = false;
            this._customPrefixValue.Location = new System.Drawing.Point(40, 128);
            this._customPrefixValue.Name = "_customPrefixValue";
            this._customPrefixValue.Size = new System.Drawing.Size(280, 21);
            this._customPrefixValue.TabIndex = 15;
            // 
            // _customPrefix
            // 
            this._customPrefix.AutoSize = true;
            this._customPrefix.Enabled = false;
            this._customPrefix.Location = new System.Drawing.Point(40, 96);
            this._customPrefix.Name = "_customPrefix";
            this._customPrefix.Size = new System.Drawing.Size(190, 17);
            this._customPrefix.TabIndex = 13;
            this._customPrefix.Text = "Custom performance counter prefix";
            this._customPrefix.UseVisualStyleBackColor = true;
            this._customPrefix.CheckedChanged += new System.EventHandler(this.CustomPrefix_CheckStateChanged);
            // 
            // _sqlServer
            // 
            this._sqlServer.AutoSize = true;
            this._sqlServer.Location = new System.Drawing.Point(16, 64);
            this._sqlServer.Name = "_sqlServer";
            this._sqlServer.Size = new System.Drawing.Size(168, 17);
            this._sqlServer.TabIndex = 12;
            this._sqlServer.Text = "Enable SQL Server monitoring";
            this._sqlServer.UseVisualStyleBackColor = true;
            this._sqlServer.CheckStateChanged += new System.EventHandler(this.SqlServer_CheckStateChanged);
            // 
            // _mongoDBConnectionString
            // 
            this._mongoDBConnectionString.Enabled = false;
            this._mongoDBConnectionString.Location = new System.Drawing.Point(128, 192);
            this._mongoDBConnectionString.Name = "_mongoDBConnectionString";
            this._mongoDBConnectionString.Size = new System.Drawing.Size(192, 21);
            this._mongoDBConnectionString.TabIndex = 11;
            // 
            // _mongoDBConnectionStringLabel
            // 
            this._mongoDBConnectionStringLabel.AutoSize = true;
            this._mongoDBConnectionStringLabel.Location = new System.Drawing.Point(32, 192);
            this._mongoDBConnectionStringLabel.Name = "_mongoDBConnectionStringLabel";
            this._mongoDBConnectionStringLabel.Size = new System.Drawing.Size(91, 13);
            this._mongoDBConnectionStringLabel.TabIndex = 10;
            this._mongoDBConnectionStringLabel.Text = "Connection string";
            // 
            // _mongoDB
            // 
            this._mongoDB.AutoSize = true;
            this._mongoDB.Location = new System.Drawing.Point(16, 160);
            this._mongoDB.Name = "_mongoDB";
            this._mongoDB.Size = new System.Drawing.Size(161, 17);
            this._mongoDB.TabIndex = 9;
            this._mongoDB.Text = "Enable MongoDB monitoring";
            this._mongoDB.UseVisualStyleBackColor = true;
            this._mongoDB.CheckStateChanged += new System.EventHandler(this.MongoDB_CheckStateChanged);
            // 
            // _browse
            // 
            this._browse.Enabled = false;
            this._browse.Location = new System.Drawing.Point(328, 317);
            this._browse.Name = "_browse";
            this._browse.Size = new System.Drawing.Size(75, 23);
            this._browse.TabIndex = 5;
            this._browse.Text = "&Browse...";
            this._browse.UseVisualStyleBackColor = true;
            this._browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // _pluginDirectory
            // 
            this._pluginDirectory.Enabled = false;
            this._pluginDirectory.Location = new System.Drawing.Point(128, 317);
            this._pluginDirectory.Name = "_pluginDirectory";
            this._pluginDirectory.Size = new System.Drawing.Size(192, 21);
            this._pluginDirectory.TabIndex = 4;
            this._pluginDirectory.Validating += new System.ComponentModel.CancelEventHandler(this.PluginDirectory_Validating);
            // 
            // _pluginLabel
            // 
            this._pluginLabel.AutoSize = true;
            this._pluginLabel.Location = new System.Drawing.Point(40, 317);
            this._pluginLabel.Name = "_pluginLabel";
            this._pluginLabel.Size = new System.Drawing.Size(81, 13);
            this._pluginLabel.TabIndex = 3;
            this._pluginLabel.Text = "Plugin directory";
            // 
            // _plugins
            // 
            this._plugins.AutoSize = true;
            this._plugins.Location = new System.Drawing.Point(16, 285);
            this._plugins.Name = "_plugins";
            this._plugins.Size = new System.Drawing.Size(95, 17);
            this._plugins.TabIndex = 2;
            this._plugins.Text = "Enable plugins";
            this._plugins.UseVisualStyleBackColor = true;
            this._plugins.CheckStateChanged += new System.EventHandler(this.Plugins_CheckStateChanged);
            // 
            // _iis
            // 
            this._iis.AutoSize = true;
            this._iis.Location = new System.Drawing.Point(16, 32);
            this._iis.Name = "_iis";
            this._iis.Size = new System.Drawing.Size(126, 17);
            this._iis.TabIndex = 0;
            this._iis.Text = "Enable IIS monitoring";
            this._iis.UseVisualStyleBackColor = true;
            // 
            // _cancel
            // 
            this._cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cancel.Location = new System.Drawing.Point(356, 532);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 3;
            this._cancel.Text = "&Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            this._cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // _ok
            // 
            this._ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ok.Location = new System.Drawing.Point(276, 532);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 4;
            this._ok.Text = "&OK";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // _folderBrowser
            // 
            this._folderBrowser.Description = "Please choose a folder that contains your plugins.";
            // 
            // _installPlugin
            // 
            this._installPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._installPlugin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._installPlugin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._installPlugin.Location = new System.Drawing.Point(12, 532);
            this._installPlugin.Name = "_installPlugin";
            this._installPlugin.Size = new System.Drawing.Size(96, 23);
            this._installPlugin.TabIndex = 5;
            this._installPlugin.Text = "&Install Plugin...";
            this._installPlugin.UseVisualStyleBackColor = true;
            this._installPlugin.Click += new System.EventHandler(this.InstallPlugin_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this._ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(446, 566);
            this.Controls.Add(this._installPlugin);
            this.Controls.Add(this._ok);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._other);
            this.Controls.Add(this._serverInfo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Density Monitoring Agent";
            this._menu.ResumeLayout(false);
            this._serverInfo.ResumeLayout(false);
            this._serverInfo.PerformLayout();
            this._other.ResumeLayout(false);
            this._other.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.GroupBox _serverInfo;
        private System.Windows.Forms.Label _agentKeyLabel;
        private System.Windows.Forms.Label _urlLabel;
        private System.Windows.Forms.TextBox _agentKey;
        private System.Windows.Forms.TextBox _url;
        private System.Windows.Forms.GroupBox _other;
        private System.Windows.Forms.CheckBox _iis;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.ContextMenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem _preferences;
        private System.Windows.Forms.ToolStripMenuItem _exit;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.Label _pluginLabel;
        private System.Windows.Forms.CheckBox _plugins;
        private System.Windows.Forms.Button _browse;
        private System.Windows.Forms.TextBox _pluginDirectory;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowser;
        private System.Windows.Forms.TextBox _mongoDBConnectionString;
        private System.Windows.Forms.Label _mongoDBConnectionStringLabel;
        private System.Windows.Forms.CheckBox _mongoDB;
        private System.Windows.Forms.CheckBox _sqlServer;
        private System.Windows.Forms.TextBox _customPrefixValue;
        private System.Windows.Forms.CheckBox _customPrefix;
        private System.Windows.Forms.CheckBox _replSet;
        private System.Windows.Forms.CheckBox _dbStats;
        private System.Windows.Forms.CheckBox _eventViewer;
        private System.Windows.Forms.Button _installPlugin;
    }
}

