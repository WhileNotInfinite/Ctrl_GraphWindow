/*
 *	This file is part of Ctrl_GraphWindow.
 *
 *	Ctrl_GraphWindow program is free software: you can redistribute it and/or modify
 *	it under the terms of the GNU General Public License as published by
 *	the Free Software Foundation, either version 3 of the License, or
 *	(at your option) any later version.
 *
 *	This program is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *	GNU General Public License for more details.
 *
 *	You should have received a copy of the GNU General Public License
 *	along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 *	Ctrl_GraphWindow Copyright © 2014-2016 whilenotinfinite@gmail.com
 */

namespace Ctrl_GraphWindow
{
	partial class Frm_GraphPrinting
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GraphPrinting));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.TSB_Print = new System.Windows.Forms.ToolStripButton();
			this.TSB_Cancel = new System.Windows.Forms.ToolStripButton();
			this.Grp_Details = new System.Windows.Forms.GroupBox();
			this.Cmd_PageSettings = new System.Windows.Forms.Button();
			this.Txt_Margin_Right = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.Txt_Margin_Left = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.Txt_Margin_Bottom = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.Txt_Margin_Top = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.Txt_PaperSource = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Txt_Orientation = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Cmd_PrinterSettings = new System.Windows.Forms.Button();
			this.Txt_Paper = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.NumUpDown_PrintCopies = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.Txt_PrinterName = new System.Windows.Forms.TextBox();
			this.Lbl_Printer = new System.Windows.Forms.Label();
			this.PrintDoc = new System.Drawing.Printing.PrintDocument();
			this.Dlg_Printer = new System.Windows.Forms.PrintDialog();
			this.Dlg_PageSetup = new System.Windows.Forms.PageSetupDialog();
			this.Grp_Preview = new System.Windows.Forms.GroupBox();
			this.Ctrl_Preview = new System.Windows.Forms.PrintPreviewControl();
			this.toolStrip1.SuspendLayout();
			this.Grp_Details.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumUpDown_PrintCopies)).BeginInit();
			this.Grp_Preview.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.TSB_Print,
									this.TSB_Cancel});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(759, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// TSB_Print
			// 
			this.TSB_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Print.Image = global::Ctrl_GraphWindow.Icones.accepter_check_ok_oui_icone_4851;
			this.TSB_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Print.Name = "TSB_Print";
			this.TSB_Print.Size = new System.Drawing.Size(23, 22);
			this.TSB_Print.Text = "toolStripButton1";
			this.TSB_Print.ToolTipText = "Print";
			this.TSB_Print.Click += new System.EventHandler(this.TSB_PrintClick);
			// 
			// TSB_Cancel
			// 
			this.TSB_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Cancel.Image = global::Ctrl_GraphWindow.Icones.arreter_icone_6430;
			this.TSB_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Cancel.Name = "TSB_Cancel";
			this.TSB_Cancel.Size = new System.Drawing.Size(23, 22);
			this.TSB_Cancel.Text = "toolStripButton2";
			this.TSB_Cancel.ToolTipText = "Cancel";
			this.TSB_Cancel.Click += new System.EventHandler(this.TSB_CancelClick);
			// 
			// Grp_Details
			// 
			this.Grp_Details.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.Grp_Details.Controls.Add(this.Cmd_PageSettings);
			this.Grp_Details.Controls.Add(this.Txt_Margin_Right);
			this.Grp_Details.Controls.Add(this.label8);
			this.Grp_Details.Controls.Add(this.Txt_Margin_Left);
			this.Grp_Details.Controls.Add(this.label9);
			this.Grp_Details.Controls.Add(this.Txt_Margin_Bottom);
			this.Grp_Details.Controls.Add(this.label7);
			this.Grp_Details.Controls.Add(this.Txt_Margin_Top);
			this.Grp_Details.Controls.Add(this.label6);
			this.Grp_Details.Controls.Add(this.label5);
			this.Grp_Details.Controls.Add(this.Txt_PaperSource);
			this.Grp_Details.Controls.Add(this.label4);
			this.Grp_Details.Controls.Add(this.Txt_Orientation);
			this.Grp_Details.Controls.Add(this.label3);
			this.Grp_Details.Controls.Add(this.Cmd_PrinterSettings);
			this.Grp_Details.Controls.Add(this.Txt_Paper);
			this.Grp_Details.Controls.Add(this.label2);
			this.Grp_Details.Controls.Add(this.NumUpDown_PrintCopies);
			this.Grp_Details.Controls.Add(this.label1);
			this.Grp_Details.Controls.Add(this.Txt_PrinterName);
			this.Grp_Details.Controls.Add(this.Lbl_Printer);
			this.Grp_Details.Location = new System.Drawing.Point(0, 28);
			this.Grp_Details.Name = "Grp_Details";
			this.Grp_Details.Size = new System.Drawing.Size(262, 372);
			this.Grp_Details.TabIndex = 1;
			this.Grp_Details.TabStop = false;
			this.Grp_Details.Text = "Printing details";
			// 
			// Cmd_PageSettings
			// 
			this.Cmd_PageSettings.Location = new System.Drawing.Point(6, 292);
			this.Cmd_PageSettings.Name = "Cmd_PageSettings";
			this.Cmd_PageSettings.Size = new System.Drawing.Size(250, 23);
			this.Cmd_PageSettings.TabIndex = 21;
			this.Cmd_PageSettings.Text = "Change page settings";
			this.Cmd_PageSettings.UseVisualStyleBackColor = true;
			this.Cmd_PageSettings.Click += new System.EventHandler(this.Cmd_PageSettingsClick);
			// 
			// Txt_Margin_Right
			// 
			this.Txt_Margin_Right.Location = new System.Drawing.Point(181, 256);
			this.Txt_Margin_Right.Name = "Txt_Margin_Right";
			this.Txt_Margin_Right.ReadOnly = true;
			this.Txt_Margin_Right.Size = new System.Drawing.Size(51, 20);
			this.Txt_Margin_Right.TabIndex = 20;
			this.Txt_Margin_Right.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(133, 259);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 18);
			this.label8.TabIndex = 19;
			this.label8.Text = "Right";
			// 
			// Txt_Margin_Left
			// 
			this.Txt_Margin_Left.Location = new System.Drawing.Point(76, 256);
			this.Txt_Margin_Left.Name = "Txt_Margin_Left";
			this.Txt_Margin_Left.ReadOnly = true;
			this.Txt_Margin_Left.Size = new System.Drawing.Size(51, 20);
			this.Txt_Margin_Left.TabIndex = 18;
			this.Txt_Margin_Left.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(35, 259);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 16);
			this.label9.TabIndex = 17;
			this.label9.Text = "Left";
			// 
			// Txt_Margin_Bottom
			// 
			this.Txt_Margin_Bottom.Location = new System.Drawing.Point(181, 230);
			this.Txt_Margin_Bottom.Name = "Txt_Margin_Bottom";
			this.Txt_Margin_Bottom.ReadOnly = true;
			this.Txt_Margin_Bottom.Size = new System.Drawing.Size(51, 20);
			this.Txt_Margin_Bottom.TabIndex = 16;
			this.Txt_Margin_Bottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(133, 233);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 18);
			this.label7.TabIndex = 15;
			this.label7.Text = "Bottom";
			// 
			// Txt_Margin_Top
			// 
			this.Txt_Margin_Top.Location = new System.Drawing.Point(76, 230);
			this.Txt_Margin_Top.Name = "Txt_Margin_Top";
			this.Txt_Margin_Top.ReadOnly = true;
			this.Txt_Margin_Top.Size = new System.Drawing.Size(51, 20);
			this.Txt_Margin_Top.TabIndex = 14;
			this.Txt_Margin_Top.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(35, 233);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 16);
			this.label6.TabIndex = 13;
			this.label6.Text = "Top";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 206);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 18);
			this.label5.TabIndex = 11;
			this.label5.Text = "Margins";
			// 
			// Txt_PaperSource
			// 
			this.Txt_PaperSource.Location = new System.Drawing.Point(76, 177);
			this.Txt_PaperSource.Name = "Txt_PaperSource";
			this.Txt_PaperSource.ReadOnly = true;
			this.Txt_PaperSource.Size = new System.Drawing.Size(180, 20);
			this.Txt_PaperSource.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 180);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 18);
			this.label4.TabIndex = 9;
			this.label4.Text = "Source";
			// 
			// Txt_Orientation
			// 
			this.Txt_Orientation.Location = new System.Drawing.Point(76, 151);
			this.Txt_Orientation.Name = "Txt_Orientation";
			this.Txt_Orientation.ReadOnly = true;
			this.Txt_Orientation.Size = new System.Drawing.Size(180, 20);
			this.Txt_Orientation.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 154);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 18);
			this.label3.TabIndex = 7;
			this.label3.Text = "Orientation";
			// 
			// Cmd_PrinterSettings
			// 
			this.Cmd_PrinterSettings.Location = new System.Drawing.Point(6, 87);
			this.Cmd_PrinterSettings.Name = "Cmd_PrinterSettings";
			this.Cmd_PrinterSettings.Size = new System.Drawing.Size(250, 23);
			this.Cmd_PrinterSettings.TabIndex = 6;
			this.Cmd_PrinterSettings.Text = "Change printer settings";
			this.Cmd_PrinterSettings.UseVisualStyleBackColor = true;
			this.Cmd_PrinterSettings.Click += new System.EventHandler(this.Cmd_PrinterSettingsClick);
			// 
			// Txt_Paper
			// 
			this.Txt_Paper.Location = new System.Drawing.Point(76, 125);
			this.Txt_Paper.Name = "Txt_Paper";
			this.Txt_Paper.ReadOnly = true;
			this.Txt_Paper.Size = new System.Drawing.Size(180, 20);
			this.Txt_Paper.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Paper";
			// 
			// NumUpDown_PrintCopies
			// 
			this.NumUpDown_PrintCopies.Location = new System.Drawing.Point(76, 51);
			this.NumUpDown_PrintCopies.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.NumUpDown_PrintCopies.Name = "NumUpDown_PrintCopies";
			this.NumUpDown_PrintCopies.Size = new System.Drawing.Size(51, 20);
			this.NumUpDown_PrintCopies.TabIndex = 3;
			this.NumUpDown_PrintCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NumUpDown_PrintCopies.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Copies";
			// 
			// Txt_PrinterName
			// 
			this.Txt_PrinterName.Location = new System.Drawing.Point(76, 25);
			this.Txt_PrinterName.Name = "Txt_PrinterName";
			this.Txt_PrinterName.ReadOnly = true;
			this.Txt_PrinterName.Size = new System.Drawing.Size(180, 20);
			this.Txt_PrinterName.TabIndex = 1;
			// 
			// Lbl_Printer
			// 
			this.Lbl_Printer.Location = new System.Drawing.Point(6, 28);
			this.Lbl_Printer.Name = "Lbl_Printer";
			this.Lbl_Printer.Size = new System.Drawing.Size(50, 17);
			this.Lbl_Printer.TabIndex = 0;
			this.Lbl_Printer.Text = "Printer";
			// 
			// PrintDoc
			// 
			this.PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocPrintPage);
			// 
			// Dlg_Printer
			// 
			this.Dlg_Printer.UseEXDialog = true;
			// 
			// Dlg_PageSetup
			// 
			this.Dlg_PageSetup.Document = this.PrintDoc;
			// 
			// Grp_Preview
			// 
			this.Grp_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Grp_Preview.Controls.Add(this.Ctrl_Preview);
			this.Grp_Preview.Location = new System.Drawing.Point(268, 28);
			this.Grp_Preview.Name = "Grp_Preview";
			this.Grp_Preview.Size = new System.Drawing.Size(491, 372);
			this.Grp_Preview.TabIndex = 2;
			this.Grp_Preview.TabStop = false;
			this.Grp_Preview.Text = "Preview";
			// 
			// Ctrl_Preview
			// 
			this.Ctrl_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Ctrl_Preview.AutoZoom = false;
			this.Ctrl_Preview.Document = this.PrintDoc;
			this.Ctrl_Preview.Location = new System.Drawing.Point(6, 19);
			this.Ctrl_Preview.Name = "Ctrl_Preview";
			this.Ctrl_Preview.Size = new System.Drawing.Size(479, 347);
			this.Ctrl_Preview.TabIndex = 0;
			this.Ctrl_Preview.Zoom = 0.31D;
			this.Ctrl_Preview.SizeChanged += new System.EventHandler(this.Ctrl_PreviewSizeChanged);
			// 
			// Frm_GraphPrinting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 402);
			this.Controls.Add(this.Grp_Preview);
			this.Controls.Add(this.Grp_Details);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Frm_GraphPrinting";
			this.Text = "Print graphic";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_GraphPrintingFormClosing);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.Grp_Details.ResumeLayout(false);
			this.Grp_Details.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumUpDown_PrintCopies)).EndInit();
			this.Grp_Preview.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button Cmd_PageSettings;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox Txt_Margin_Top;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox Txt_Margin_Bottom;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox Txt_Margin_Left;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox Txt_Margin_Right;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox Txt_PaperSource;
		private System.Windows.Forms.Button Cmd_PrinterSettings;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Txt_Orientation;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Txt_Paper;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NumUpDown_PrintCopies;
		private System.Windows.Forms.Label Lbl_Printer;
		private System.Windows.Forms.TextBox Txt_PrinterName;
		private System.Windows.Forms.GroupBox Grp_Preview;
		private System.Windows.Forms.PageSetupDialog Dlg_PageSetup;
		private System.Windows.Forms.PrintDialog Dlg_Printer;
		private System.Drawing.Printing.PrintDocument PrintDoc;
		private System.Windows.Forms.ToolStripButton TSB_Cancel;
		private System.Windows.Forms.ToolStripButton TSB_Print;
		private System.Windows.Forms.PrintPreviewControl Ctrl_Preview;
		private System.Windows.Forms.GroupBox Grp_Details;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
