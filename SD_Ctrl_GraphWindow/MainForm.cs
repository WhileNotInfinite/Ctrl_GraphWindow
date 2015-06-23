/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 9/14/2014
 * Time: 12:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Ctrl_GraphWindow;

namespace SD_Ctrl_GraphWindow
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			#if DEBUG
			
			GraphWindowProperties oProperties = new GraphWindowProperties();
			oProperties.Open_Properties(Application.StartupPath + "\\GraphConfigTest_Overlay.xgw");
			
			GW_DataFile oData = new GW_DataFile();
			//oData.Load_DataFile(Application.StartupPath + "\\DataTest.csv");	//FR: Decimal separator ','
			oData.Load_DataFile(Application.StartupPath + "\\DataTest2.csv");	//US: Decimal separator '.'
			
			this.ctrl_WaveForm1.Properties = oProperties;
			this.ctrl_WaveForm1.Set_DataFile(oData);
			
			#endif
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
			this.ctrl_WaveForm1.Refresh_Graphic();
		}
	}
}
