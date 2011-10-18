namespace BoxedIce.ServerDensity.Agent.Windows.Forms
{
    partial class PluginForm
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
            this._pluginInstallation = new System.Windows.Forms.GroupBox();
            this._label = new System.Windows.Forms.Label();
            this._installKey = new System.Windows.Forms.TextBox();
            this._ok = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this._pluginInstallation.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pluginInstallation
            // 
            this._pluginInstallation.Controls.Add(this._label);
            this._pluginInstallation.Controls.Add(this._installKey);
            this._pluginInstallation.Location = new System.Drawing.Point(12, 12);
            this._pluginInstallation.Name = "_pluginInstallation";
            this._pluginInstallation.Size = new System.Drawing.Size(314, 52);
            this._pluginInstallation.TabIndex = 0;
            this._pluginInstallation.TabStop = false;
            this._pluginInstallation.Text = "Plugin Installation";
            // 
            // _label
            // 
            this._label.AutoSize = true;
            this._label.Location = new System.Drawing.Point(15, 22);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(56, 13);
            this._label.TabIndex = 1;
            this._label.Text = "Install key";
            // 
            // _installKey
            // 
            this._installKey.Location = new System.Drawing.Point(75, 19);
            this._installKey.Name = "_installKey";
            this._installKey.Size = new System.Drawing.Size(224, 21);
            this._installKey.TabIndex = 0;
            // 
            // _ok
            // 
            this._ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._ok.Location = new System.Drawing.Point(170, 70);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 1;
            this._ok.Text = "&OK";
            this._ok.UseVisualStyleBackColor = true;
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(251, 70);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 2;
            this._cancel.Text = "&Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // PluginForm
            // 
            this.AcceptButton = this._ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(338, 105);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._ok);
            this.Controls.Add(this._pluginInstallation);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Install Plugin";
            this._pluginInstallation.ResumeLayout(false);
            this._pluginInstallation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _pluginInstallation;
        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.Label _label;
        private System.Windows.Forms.TextBox _installKey;
    }
}

