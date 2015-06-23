/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/7/2014
 * Time: 14:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Ctrl_GraphWindow
{
	/// <summary>
	/// Graphic printing form
	/// </summary>
	public partial class Frm_GraphPrinting : Form
	{
		#region Private members
		
		private Image GraphImage;
		private bool Preview;
		
		#endregion
		
		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="GraphImg">Image of the graphic to be printed out</param>
		public Frm_GraphPrinting(Image GraphImg)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			GraphImage = GraphImg;
			Preview = true;
			
			//Set Printdocument default properties
			PrintDoc.DefaultPageSettings.Landscape = true;
			
			Show_PrintingProperties();
		}
		
		#region Control events
		
		#region Form
		
		private void Frm_GraphPrintingFormClosing(object sender, FormClosingEventArgs e)
		{
			GraphImage.Dispose();
		}
		
		#endregion
		
		#region ToolBar
		
		private void TSB_PrintClick(object sender, EventArgs e)
		{
			Preview = false;
			PrintDoc.Print();
			Preview = true;
		}
		
		private void TSB_CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		#endregion
		
		#region PrintDocument
		
		private void PrintDocPrintPage(object sender, PrintPageEventArgs e)
		{
			if (!(GraphImage == null))
			{
				PrintDocument Doc = (PrintDocument)sender;
				PointF p = new PointF(Doc.DefaultPageSettings.Margins.Left, Doc.DefaultPageSettings.Margins.Top);
				
				RectangleF ImgRect = new RectangleF(0, 0, GraphImage.Width, GraphImage.Height);
				
				SizeF PageSize = SizeF.Empty;
				PointF PageOrigin = new PointF(Doc.DefaultPageSettings.Margins.Left, Doc.DefaultPageSettings.Margins.Top);
				
				if (Doc.DefaultPageSettings.Landscape)
				{
					PageSize.Width = Doc.DefaultPageSettings.PaperSize.Height - Doc.DefaultPageSettings.Margins.Left - Doc.DefaultPageSettings.Margins.Right;
					PageSize.Height = Doc.DefaultPageSettings.PaperSize.Width - Doc.DefaultPageSettings.Margins.Top - Doc.DefaultPageSettings.Margins.Bottom;
				}
				else
				{
					PageSize.Width = Doc.DefaultPageSettings.PaperSize.Width - Doc.DefaultPageSettings.Margins.Left - Doc.DefaultPageSettings.Margins.Right;
					PageSize.Height = Doc.DefaultPageSettings.PaperSize.Height - Doc.DefaultPageSettings.Margins.Top - Doc.DefaultPageSettings.Margins.Bottom;
				}
				
				RectangleF PageRect = new RectangleF(PageOrigin, PageSize);
				
				e.Graphics.DrawImage(GraphImage, PageRect, ImgRect, GraphicsUnit.Pixel);
				
				e.Cancel = Preview;
			}
			else
			{
				e.Cancel = true;
			}
		}
		
		#endregion
		
		#region Ctrl_Preview
		
		private void Ctrl_PreviewSizeChanged(object sender, EventArgs e)
		{			
			Zoom_WholePage();
		}
		
		#endregion
		
		#region Option buttons
		
		private void Cmd_PrinterSettingsClick(object sender, EventArgs e)
		{
			if (Dlg_Printer.ShowDialog().Equals(DialogResult.OK))
			{
				PrintDoc.PrinterSettings = Dlg_Printer.PrinterSettings;
				Show_PrintingProperties();
				PrintDoc.Print();
				Ctrl_Preview.Document = PrintDoc;
			}
		}
		
		private void Cmd_PageSettingsClick(object sender, EventArgs e)
		{
			if (Dlg_PageSetup.ShowDialog().Equals(DialogResult.OK))
			{
				PrintDoc.DefaultPageSettings = Dlg_PageSetup.PageSettings;
				Show_PrintingProperties();
				PrintDoc.Print();
				Ctrl_Preview.Document = PrintDoc;
			}
		}
		
		#endregion
		
		#endregion
		
		#region Private methodes
		
		private void Show_PrintingProperties()
		{
			Txt_PrinterName.Text = PrintDoc.PrinterSettings.PrinterName;
			NumUpDown_PrintCopies.Value = PrintDoc.PrinterSettings.Copies;
			Txt_Paper.Text = PrintDoc.DefaultPageSettings.PaperSize.PaperName;
			Txt_PaperSource.Text = PrintDoc.DefaultPageSettings.PaperSource.SourceName;
			Txt_Margin_Top.Text = (PrintDoc.DefaultPageSettings.Margins.Top / 100).ToString();
			Txt_Margin_Bottom.Text = (PrintDoc.DefaultPageSettings.Margins.Bottom / 100).ToString();
			Txt_Margin_Left.Text = (PrintDoc.DefaultPageSettings.Margins.Left / 100).ToString();
			Txt_Margin_Right.Text = (PrintDoc.DefaultPageSettings.Margins.Right / 100).ToString();
			
			if (PrintDoc.DefaultPageSettings.Landscape)
			{
				Txt_Orientation.Text = "Landscape";
			}
			else
			{
				Txt_Orientation.Text = "Portrait";
			}
		}
		
		private void Zoom_WholePage()
		{
			double wRatio = 1;
			double hRatio = 1;
			
			if (PrintDoc.DefaultPageSettings.Landscape)
			{
				wRatio = (double)Ctrl_Preview.Width / (double) PrintDoc.DefaultPageSettings.PaperSize.Height;
				hRatio = (double)Ctrl_Preview.Height / (double) PrintDoc.DefaultPageSettings.PaperSize.Width;
			}
			else
			{
				wRatio = (double)Ctrl_Preview.Width / (double) PrintDoc.DefaultPageSettings.PaperSize.Width;
				hRatio = (double)Ctrl_Preview.Height / (double) PrintDoc.DefaultPageSettings.PaperSize.Height;
			}
			
			Ctrl_Preview.Zoom = Math.Min(wRatio, hRatio);
		}
		
		#endregion
	}
}
