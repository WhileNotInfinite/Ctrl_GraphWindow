/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 9/14/2014
 * Time: 12:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SD_Ctrl_GraphWindow
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.ctrl_WaveForm1 = new Ctrl_GraphWindow.Ctrl_WaveForm();
			this.SuspendLayout();
			// 
			// ctrl_WaveForm1
			// 
			this.ctrl_WaveForm1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.ctrl_WaveForm1.Location = new System.Drawing.Point(0, 1);
			this.ctrl_WaveForm1.Name = "ctrl_WaveForm1";
			this.ctrl_WaveForm1.Size = new System.Drawing.Size(663, 472);
			this.ctrl_WaveForm1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 473);
			this.Controls.Add(this.ctrl_WaveForm1);
			this.Name = "MainForm";
			this.Text = "SD_Ctrl_GraphWindow";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.ResumeLayout(false);
		}
		private Ctrl_GraphWindow.Ctrl_WaveForm ctrl_WaveForm1;
	}
}
