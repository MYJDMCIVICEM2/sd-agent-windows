namespace BoxedIce.ServerDensity.Agent.ConfigWriter
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
            this._label = new System.Windows.Forms.Label();
            this._progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.AutoSize = true;
            this._label.Location = new System.Drawing.Point(16, 16);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(178, 13);
            this._label.TabIndex = 0;
            this._label.Text = "Saving configuration, please wait...";
            // 
            // _progress
            // 
            this._progress.Location = new System.Drawing.Point(16, 40);
            this._progress.Name = "_progress";
            this._progress.Size = new System.Drawing.Size(256, 23);
            this._progress.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 74);
            this.Controls.Add(this._progress);
            this.Controls.Add(this._label);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saving Configuration...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label;
        private System.Windows.Forms.ProgressBar _progress;
    }
}