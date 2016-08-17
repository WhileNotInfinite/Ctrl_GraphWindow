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
