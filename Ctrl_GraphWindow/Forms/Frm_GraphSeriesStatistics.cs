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
using System.Drawing;
using System.Windows.Forms;

namespace Ctrl_GraphWindow
{
	/// <summary>
	/// Description of Frm_GraphSeriesStatistics.
	/// </summary>
	public partial class Frm_GraphSeriesStatistics : Form
	{
		#region Private members
		
		private SerieStatistics[] Statistics;
		private Color WindowBackColor;
		
		#endregion
		
		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="Stats">Statistics to display</param>
		/// <param name="BackColor">Grid cells back color</param>
		public Frm_GraphSeriesStatistics(SerieStatistics[] Stats, Color BackColor)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			Statistics = Stats;
			WindowBackColor = BackColor;
			
			for (int iCol = 1; iCol < Grid_Statistics.Columns.Count; iCol ++)
			{
				Grid_Statistics.Columns[iCol].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
		}

        #region Control events

        private void Frm_GraphSeriesStatistics_Load(object sender, EventArgs e)
        {
            if (Statistics.Length > 0)
            {
                Show_Statistics();

                this.Height = ((Statistics.Length + 1) * Grid_Statistics.Rows[0].Height) + Grid_Statistics.ColumnHeadersHeight + 35;
                
            }
        }

        private void Frm_GraphSeriesStatistics_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private methodes

        private void Show_Statistics()
		{
			foreach (SerieStatistics oStat in Statistics)
			{
				Grid_Statistics.Rows.Add();
				DataGridViewRow oRow = Grid_Statistics.Rows[Grid_Statistics.Rows.Count - 1];
				
				oRow.Cells[0].Value = oStat.Title;
				oRow.Cells[0].Style.BackColor = WindowBackColor;
				oRow.Cells[0].Style.ForeColor = oStat.SerieColor;
				
				oRow.Cells[1].Value = Math.Round(oStat.MinX, 3).ToString();
				oRow.Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				oRow.Cells[1].Style.BackColor = WindowBackColor;
				oRow.Cells[1].Style.ForeColor = oStat.SerieColor;
				
				oRow.Cells[2].Value = Math.Round(oStat.Min, 3).ToString();
				oRow.Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				oRow.Cells[2].Style.BackColor = WindowBackColor;
				oRow.Cells[2].Style.ForeColor = oStat.SerieColor;
				
				oRow.Cells[3].Value = Math.Round(oStat.Max, 3).ToString();
				oRow.Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				oRow.Cells[3].Style.BackColor = WindowBackColor;
				oRow.Cells[3].Style.ForeColor = oStat.SerieColor;
				
				oRow.Cells[4].Value = Math.Round(oStat.MaxX, 3).ToString();
				oRow.Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				oRow.Cells[4].Style.BackColor = WindowBackColor;
				oRow.Cells[4].Style.ForeColor = oStat.SerieColor;
				
				oRow.Cells[5].Value = Math.Round(oStat.Avg, 3).ToString();
				oRow.Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				oRow.Cells[5].Style.BackColor = WindowBackColor;
				oRow.Cells[5].Style.ForeColor = oStat.SerieColor;
				
				oRow.Cells[6].Value = Math.Round(oStat.AvgAbs, 3).ToString();
				oRow.Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				oRow.Cells[6].Style.BackColor = WindowBackColor;
				oRow.Cells[6].Style.ForeColor = oStat.SerieColor;
				
				oRow.Cells[7].Value = Math.Round(oStat.StdDev, 3).ToString();
				oRow.Cells[7].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				oRow.Cells[7].Style.BackColor = WindowBackColor;
				oRow.Cells[7].Style.ForeColor = oStat.SerieColor;
				
				oRow.Cells[8].Value = oStat.SampleCount.ToString();
				oRow.Cells[8].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				oRow.Cells[8].Style.BackColor = WindowBackColor;
				oRow.Cells[8].Style.ForeColor = oStat.SerieColor;
			}
		}

        #endregion

        
    }
}
