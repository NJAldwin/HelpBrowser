namespace ShakenSW.HelpBrowser
{
    partial class HelpBrowser
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
            this.uxWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // uxWebBrowser
            // 
            this.uxWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.uxWebBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.uxWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.uxWebBrowser.Name = "uxWebBrowser";
            this.uxWebBrowser.Size = new System.Drawing.Size(624, 442);
            this.uxWebBrowser.TabIndex = 0;
            this.uxWebBrowser.DocumentTitleChanged += new System.EventHandler(uxWebBrowser_DocumentTitleChanged);
            // 
            // HelpBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.uxWebBrowser);
            this.MinimumSize = new System.Drawing.Size(30, 38);
            this.Name = "HelpBrowser";
            this.ShowIcon = false;
            this.Text = "Help Browser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser uxWebBrowser;
    }
}