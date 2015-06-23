namespace Ctrl_GraphWindow
{
    partial class Frm_FlyingChannelList
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_FlyingChannelList));
        	this.Ctrl_ChanList = new Ctrl_GraphWindow.Ctrl_GW_ChannelList();
        	this.SuspendLayout();
        	// 
        	// Ctrl_ChanList
        	// 
        	this.Ctrl_ChanList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.Ctrl_ChanList.Location = new System.Drawing.Point(1, 3);
        	this.Ctrl_ChanList.Name = "Ctrl_ChanList";
        	this.Ctrl_ChanList.Size = new System.Drawing.Size(176, 381);
        	this.Ctrl_ChanList.TabIndex = 0;
        	// 
        	// Frm_FlyingChannelList
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(176, 381);
        	this.Controls.Add(this.Ctrl_ChanList);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Frm_FlyingChannelList";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        	this.Text = "Channel list";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_FlyingChannelList_FormClosing);
        	this.ResumeLayout(false);
        }
        private Ctrl_GraphWindow.Ctrl_GW_ChannelList Ctrl_ChanList;

        #endregion


    }
}