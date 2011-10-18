namespace BoxedIce.ServerDensity.Agent.Plugins.Windows.Forms
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
            this._close = new System.Windows.Forms.Button();
            this._progress = new System.Windows.Forms.ProgressBar();
            this._label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _close
            // 
            this._close.Enabled = false;
            this._close.Location = new System.Drawing.Point(280, 72);
            this._close.Name = "_close";
            this._close.Size = new System.Drawing.Size(75, 23);
            this._close.TabIndex = 5;
            this._close.Text = "&Close";
            this._close.UseVisualStyleBackColor = true;
            this._close.Click += new System.EventHandler(this.Close_Clicked);
            // 
            // _progress
            // 
            this._progress.Location = new System.Drawing.Point(16, 40);
            this._progress.Name = "_progress";
            this._progress.Size = new System.Drawing.Size(344, 23);
            this._progress.TabIndex = 4;
            // 
            // _label
            // 
            this._label.AutoSize = true;
            this._label.Location = new System.Drawing.Point(16, 16);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(229, 13);
            this._label.TabIndex = 3;
            this._label.Text = "Downloading plugin information, please wait...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 112);
            this.Controls.Add(this._close);
            this.Controls.Add(this._progress);
            this.Controls.Add(this._label);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Density Plugin Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _close;
        private System.Windows.Forms.ProgressBar _progress;
        private System.Windows.Forms.Label _label;
    }
}