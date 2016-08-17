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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ctrl_GraphWindow
{
    /// <summary>
    /// Graphic properties edition form
    /// </summary>
    public partial class Frm_GraphPropertiesEdtion : Form
    {
        #region Private constants

        private const string FORM_NAME = "Graphic Properties";

        private const int SerieNameColId    = 0;
        private const int SerieLabelColId   = 1;
        private const int SerieUnitColId    = 2;
        private const int SerieColorColId   = 3;
        private const int SerieVisibleColId = 4;
        private const int SerieFormatColId  = 5;
        private const int SerieTopColId     = 6;
        private const int SerieBottomColId  = 7;
        private const int SerieScaleColId   = 8;
        private const int SerieMinColId     = 9;
        private const int SerieMaxColId     = 10;
        private const int SerieYAxisColId   = 11;
        private const int SerieGridColId    = 12;
        private const int SerieRefLineColId = 13;
        private const int SerieDetailsColId = 14;

        #endregion

        #region Private members

        private GraphWindowProperties GraphProperties;
        private GraphWindowProperties GraphPropertiesBackUp;

        private Ctrl_WaveForm Ctrl_Parent;

        private Frm_FlyingChannelList FlyingChannelList;
        private Ctrl_GW_ContextualChannelList oContextChanList;

        private string[] ChannelList;
        bool bGridSerieEdition;
        bool bModificationsConfirmed;

        private List<GraphSerieProperties> SerieClipBoard;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Caller">Form calling the Frm_GraphPropertiesEdtion</param>
        /// <param name="DataChannelList">List of channels of the data loaded</param>
        public Frm_GraphPropertiesEdtion(Ctrl_WaveForm Caller, string[] DataChannelList)
        {
            InitializeComponent();

            Ctrl_Parent = Caller;
            GraphProperties = Ctrl_Parent.Properties;
            GraphPropertiesBackUp = GraphProperties.Get_Clone();

            ChannelList = DataChannelList;
            bGridSerieEdition = false;
            bModificationsConfirmed = false;

            SerieClipBoard = null;

            //Flying and contextual channel list init
            FlyingChannelList = new Frm_FlyingChannelList(DataChannelList, this);
			oContextChanList = null;
            
            Ctrl_AbcisseRefLines.FORM_TITLE = FORM_NAME;
            Ctrl_AbcisseRefLines.DefaultLineColor = GraphProperties.AbscisseAxis.AxisLineStyle.LineColor;
            Ctrl_AbcisseRefLines.ReferenceLines = GraphProperties.AbscisseAxis.ReferenceLines;

            //Filling of lists
            Cmb_MHGrid_Style.Items.Clear();
            Cmb_MVGrid_Style.Items.Clear();
            Cmb_MVGrid_Style.Items.Clear();
            Cmb_SVGrid_Style.Items.Clear();
            Cmb_AbscisseStyle.Items.Clear();
            Cmb_CursorLineStyle.Items.Clear();
            Cmb_RefCursorLineStyle.Items.Clear();

            string[] LineStyles = {
                                 System.Drawing.Drawing2D.DashStyle.Dash.ToString(),
                                 System.Drawing.Drawing2D.DashStyle.DashDot.ToString(),
                                 System.Drawing.Drawing2D.DashStyle.DashDotDot.ToString(),
                                 System.Drawing.Drawing2D.DashStyle.Dot.ToString(),
                                 System.Drawing.Drawing2D.DashStyle.Solid.ToString(),
                                 };
            
            for (int i = 0; i < LineStyles.Length; i++)
            {
                Cmb_MHGrid_Style.Items.Add(LineStyles[i]);
                Cmb_MVGrid_Style.Items.Add(LineStyles[i]);
                Cmb_SHGrid_Style.Items.Add(LineStyles[i]);
                Cmb_SVGrid_Style.Items.Add(LineStyles[i]);
                Cmb_AbscisseStyle.Items.Add(LineStyles[i]);
                Cmb_CursorLineStyle.Items.Add(LineStyles[i]);
                Cmb_RefCursorLineStyle.Items.Add(LineStyles[i]);
            }

            Cmb_GraphLayoutMode.Items.Clear();
            string[] LayoutModes = Enum.GetNames(typeof(GraphicWindowLayoutModes));

            for (int i=0; i<LayoutModes.Length; i++)
            {
                Cmb_GraphLayoutMode.Items.Add(LayoutModes[i]);
            }

            Cmb_AbscisseChannel.Items.Clear();
            
            if (!(ChannelList == null))
            {
	            foreach (string sChan in ChannelList)
	            {
	                Cmb_AbscisseChannel.Items.Add(sChan);
	            }
            }

            ChkLst_LegendInformations.Items.Clear();
            string[] LegendInfos = Enum.GetNames(typeof(GraphicLegendInformations));

            for (int i = 0; i < LegendInfos.Length; i++)
            {
                ChkLst_LegendInformations.Items.Add(LegendInfos[i]);
            }
            
            Cmb_MainCursorMode.Items.Clear();
            Cmb_MainCursorMode.Items.AddRange(Enum.GetNames(typeof(GraphicCursorMode)));
            
            Cmb_CursorAbsValLocation.Items.Clear();
            Cmb_CursorAbsValLocation.Items.AddRange(Enum.GetNames(typeof(ScreenPositions)));
            
            Cmb_CursorOrdValLocation.Items.Clear();
            Cmb_CursorOrdValLocation.Items.AddRange(Enum.GetNames(typeof(ScreenPositions)));

            Cmb_CursorTitleLocation.Items.Clear();
            Cmb_CursorTitleLocation.Items.AddRange(Enum.GetNames(typeof(ScreenPositions)));

            string[] RefCursorModes = {
            							GraphicCursorMode.None.ToString(),
            							GraphicCursorMode.VerticalLine.ToString(),
            							GraphicCursorMode.HorizontalLine.ToString(),
            						  };
            
            Cmb_RefCursorMode.Items.Clear();
            Cmb_RefCursorMode.Items.AddRange(RefCursorModes);
            
            Cmb_RefCursorAbsValLocation.Items.Clear();
            Cmb_RefCursorAbsValLocation.Items.AddRange(Enum.GetNames(typeof(ScreenPositions)));
            
            Cmb_RefCursorOrdValLocation.Items.Clear();
            Cmb_RefCursorOrdValLocation.Items.AddRange(Enum.GetNames(typeof(ScreenPositions)));

            //Grid series properties init
            for (int i = 0; i < Grid_SeriesProperties.Columns.Count; i++)
            {
                Grid_SeriesProperties.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            Show_Properties();
        }

        #region Control events

        #region Form

        private void Frm_GraphPropertiesEdtion_Shown(object sender, EventArgs e)
        {
            //Grid series properties columns resizing
            Resize_GridColumns();
        }

        private void Frm_GraphPropertiesEdtion_ResizeEnd(object sender, EventArgs e)
        {
            //Grid series properties columns resizing
            Resize_GridColumns();
        }

        private void Frm_GraphPropertiesEdtion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(bModificationsConfirmed))
            {
                Set_BackupProperties();
            }

            if (FlyingChannelList.Visible)
            {
                FlyingChannelList.Close();
            }

            for (int iForm = 0; iForm < Application.OpenForms.Count; iForm++)
            {
                if (Application.OpenForms[iForm].GetType().Equals(typeof(Frm_GraphSerieDetailedProperties)))
                {
                    Application.OpenForms[iForm].Close();
                    iForm--;
                }
            }
        }

        #endregion

        #region Toolbar

        private void TSB_Apply_Click(object sender, EventArgs e)
        {
            if (Set_Properties())
            {
                Ctrl_Parent.Refresh_Graphic();
                this.Close();
            }
        }

        private void TSB_Cancel_Click(object sender, EventArgs e)
        {
            Set_BackupProperties();
            this.Close();
        }

        private void TSB_New_Click(object sender, EventArgs e)
        {
            New_PropertiesConfiguration();
        }

        private void TSB_Open_Click(object sender, EventArgs e)
        {
            Load_PropertiesConfiguration();
        }

        private void TSB_Save_Click(object sender, EventArgs e)
        {
            Save_PropertiesConfiguration();
        }

        private void TSB_ChannelList_Click(object sender, EventArgs e)
        {
            ShowChannelList();
        }

        private void TSB_NewSerie_Click(object sender, EventArgs e)
        {
            Create_NewSerie();
        }

        private void TSB_DelSerie_Click(object sender, EventArgs e)
        {
            Delete_SelectedSeries();
        }

        private void TSB_CopySerie_Click(object sender, EventArgs e)
        {
            Copy_SelectedSeries();
        }

        private void TSB_PasteSerie_Click(object sender, EventArgs e)
        {
            Paste_Series();
        }

        private void TSB_MoveUp_Click(object sender, EventArgs e)
        {
            Move_SelectedSeries("Up");
        }

        private void TSB_MoveDown_Click(object sender, EventArgs e)
        {
            Move_SelectedSeries("Down");
        }

        #endregion

        #region TabControl1

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                TSB_ChannelList.Enabled = true;
                TSB_NewSerie.Enabled    = true;
                TSB_DelSerie.Enabled    = true;
                TSB_CopySerie.Enabled   = true;
                TSB_PasteSerie.Enabled  = true;
                TSB_MoveUp.Enabled      = true;
                TSB_MoveDown.Enabled    = true;
            }
            else
            {
                TSB_ChannelList.Enabled = false;
                TSB_NewSerie.Enabled    = false;
                TSB_DelSerie.Enabled    = false;
                TSB_CopySerie.Enabled   = false;
                TSB_PasteSerie.Enabled  = false;
                TSB_MoveUp.Enabled      = false;
                TSB_MoveDown.Enabled    = false;
            }
        }

        #endregion

        #region Tab Series

        #region Cmb_GraphLayoutMode

        private void Cmb_GraphLayoutMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!(Cmb_GraphLayoutMode.SelectedIndex==-1))
            {
                GraphProperties.GraphLayoutMode = (GraphicWindowLayoutModes)Enum.Parse(typeof(GraphicWindowLayoutModes), Cmb_GraphLayoutMode.Text);

                foreach (DataGridViewRow oRow in Grid_SeriesProperties.Rows)
                {
                    GraphSerieProperties oSerie = GraphProperties.Get_SerieAtKey((int)oRow.Tag);

                    if (!(oSerie == null))
                    {
                        if (GraphProperties.GraphLayoutMode.Equals(GraphicWindowLayoutModes.Custom))
                        {
                            oRow.Cells[SerieTopColId].Value = oSerie.Top.ToString();
                            oRow.Cells[SerieTopColId].ReadOnly = false;

                            oRow.Cells[SerieBottomColId].Value = oSerie.Bottom.ToString();
                            oRow.Cells[SerieBottomColId].ReadOnly = false;
                        }
                        else
                        {
                            oRow.Cells[SerieTopColId].Value = "-";
                            oRow.Cells[SerieTopColId].ReadOnly = true;

                            oRow.Cells[SerieBottomColId].Value = "-";
                            oRow.Cells[SerieBottomColId].ReadOnly = true;
                        }
                    }
                }
            }
        }

        #endregion

        #region Grid_SeriesProperties

        private void Grid_SeriesProperties_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Grid_SeriesProperties_DragDrop(object sender, DragEventArgs e)
        {
            ListView.SelectedListViewItemCollection Items = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

            if(!(Items==null))
            {
                foreach(ListViewItem ItChannel in Items)
                {
                    Add_Channel(ItChannel.Text);
                }

                Show_SeriesProperties();
            }
        }

        private void Grid_SeriesProperties_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Delete:

                    Delete_SelectedSeries();
                    break;

                case Keys.C:

                    if(e.Control)
                    {
                        Copy_SelectedSeries();
                    }
                    break;

                case Keys.V:

                    if(e.Control)
                    {
                        Paste_Series();
                    }
                    break;

                case Keys.PageUp:

                    Move_SelectedSeries("Up");
                    break;

                case Keys.PageDown:

                    Move_SelectedSeries("Down");
                    break;
            }
        }

        private void Grid_SeriesProperties_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch(e.ColumnIndex)
            {
                case SerieColorColId:

                    Set_SerieColor(e.RowIndex);
                    break;

                case SerieFormatColId:

                    Show_SerieDetailedProperties((int)Grid_SeriesProperties.Rows[e.RowIndex].Tag, "Format");
                    break;

                case SerieYAxisColId:

                    Show_SerieDetailedProperties((int)Grid_SeriesProperties.Rows[e.RowIndex].Tag, "YAxis");
                    break;

                case SerieGridColId:

                    Show_SerieDetailedProperties((int)Grid_SeriesProperties.Rows[e.RowIndex].Tag, "Grid");
                    break;

                case SerieRefLineColId:

                    Show_SerieDetailedProperties((int)Grid_SeriesProperties.Rows[e.RowIndex].Tag, "RefLines");
                    break;
            }
        }

        private void Grid_SeriesProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == SerieDetailsColId && (!(e.RowIndex == -1)))
            {
                Show_SerieDetailedProperties((int)Grid_SeriesProperties.Rows[e.RowIndex].Tag, "General");
            }
        }

        private void Grid_SeriesProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int iTmp = 0;
            double dTmp = 0;
            
            if ((!bGridSerieEdition) && (e.RowIndex >= 0))
            {
                GraphSerieProperties oSerie = GraphProperties.Get_SerieAtKey((int)Grid_SeriesProperties.Rows[e.RowIndex].Tag);

                if (!(oSerie == null))
                {
                    switch (e.ColumnIndex)
                    {
                        case SerieNameColId:

                            if(!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                            {
                                oSerie.Name = Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                                oSerie.Label = oSerie.Name;

                                Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieLabelColId].Value = oSerie.Label;

                                if (ChannelList.Contains(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                                {
                                    //New channel exists in the channel list
                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = SystemColors.ActiveCaptionText;
                                }
                                else
                                {
                                    //New channel doesn't exist in the channel list
                                    MessageBox.Show("This channel doesn't exist in the data loaded !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Channel name cannot be empty !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Name;
                            }

                            break;

                        case SerieLabelColId:

                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                            {
                                oSerie.Label = Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Legend serie label cannot be empty !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Name;
                            }

                            break;

                        case SerieUnitColId:

                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                            {
                           		oSerie.Unit = Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                            }
                            else
                            {
                            	oSerie.Unit = "";
                            }

                            break;
                        
                        case SerieVisibleColId:

                            oSerie.Visible = (bool)Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                            break;
                        
                        case SerieTopColId:

                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                            {
	                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("-")))
	                            {
	                                if (int.TryParse(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out iTmp))
	                                {
	                                    if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieBottomColId].Value.ToString().Equals("-")))
	                                    {
	                                        if (iTmp > (int.Parse(Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieBottomColId].Value.ToString())))
	                                        {
	                                            oSerie.Top = iTmp;
	                                        }
	                                        else
	                                        {
	                                            MessageBox.Show("StartPos value must be greater than 'bottom' value !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                                            Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Top.ToString();
	                                        }
	                                    }
	                                }
	                                else
	                                {
	                                    MessageBox.Show("StartPos value must be a numeric value !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Top.ToString();
	                                }
	                            }
                            }
                            else
                            {
                            	if (GraphProperties.GraphLayoutMode.Equals(GraphicWindowLayoutModes.Custom))
                            	{
                            		Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Top.ToString();
                            	}
                            	else
                            	{
                            		Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-";
                            	}
                            }

                            break;

                        case SerieBottomColId:

                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                            {
	                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("-")))
	                            {
	                                if (int.TryParse(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out iTmp))
	                                {
	                                    if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieTopColId].Value.ToString().Equals("-")))
	                                    {
	                                        if (iTmp < (int.Parse(Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieTopColId].Value.ToString())))
	                                        {
	                                            oSerie.Bottom = iTmp;
	                                        }
	                                        else
	                                        {
	                                            MessageBox.Show("EndPos value must be lower than 'top' value !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                                            Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Bottom.ToString();
	                                        }
	                                    }
	                                }
	                                else
	                                {
	                                    MessageBox.Show("EndPos value must be a numeric value !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Bottom.ToString();
	                                }
	                            }
                            }
                            else
                            {
                            	if (GraphProperties.GraphLayoutMode.Equals(GraphicWindowLayoutModes.Custom))
                            	{
                            		Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Bottom.ToString();
                            	}
                            	else
                            	{
                            		Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-";
                            	}
                            }

                            break;

                        case SerieScaleColId:

                            oSerie.ScalingMode = (GraphSerieScaleModes)Enum.Parse(typeof(GraphSerieScaleModes), Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                            switch (oSerie.ScalingMode)
                            {
                                case GraphSerieScaleModes.Auto:

                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMinColId].Value = "-";
                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMinColId].ReadOnly = true;

                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMaxColId].Value = "-";
                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMaxColId].ReadOnly = true;

                                    break;

                                case GraphSerieScaleModes.Custom:

                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMinColId].Value = oSerie.Min.ToString();
                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMinColId].ReadOnly = false;

                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMaxColId].Value = oSerie.Max.ToString();
                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMaxColId].ReadOnly = false;

                                    break;
                            }

                            break;

                        case SerieMinColId:
                            
                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                            {
	                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("-")))
	                            {
	                                if (double.TryParse(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out dTmp))
	                                {
	                                    if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMaxColId].Value.ToString().Equals("-")))
	                                    {
	                                        if (dTmp <= (double.Parse(Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMaxColId].Value.ToString())))
	                                        {
	                                            oSerie.Min = dTmp;
	                                        }
	                                        else
	                                        {
	                                            MessageBox.Show("Min value must be smaller than 'max' value !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                                            Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Min.ToString();
	                                        }
	                                    }
	                                }
	                                else
	                                {
	                                    MessageBox.Show("Min value must be a numeric value !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Min.ToString();
	                                }
	                            }
                            }
                            else
                            {
                            	if (oSerie.ScalingMode.Equals(GraphSerieScaleModes.Auto))
                            	{
                            		Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-";
                            	}
                            	else
                            	{
                            		Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Min.ToString();
                            	}
                            }

                            break;

                        case SerieMaxColId:

                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                            {
	                            if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("-")))
	                            {
	                                if (double.TryParse(Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out dTmp))
	                                {
	                                    if (!(Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMinColId].Value.ToString().Equals("-")))
	                                    {
	                                        if (dTmp >= (double.Parse(Grid_SeriesProperties.Rows[e.RowIndex].Cells[SerieMinColId].Value.ToString())))
	                                        {
	                                            oSerie.Max = dTmp;
	                                        }
	                                        else
	                                        {
	                                            MessageBox.Show("Max value must be smaller than 'min' value !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                                            Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Max.ToString();
	                                        }
	                                    }
	                                }
	                                else
	                                {
	                                    MessageBox.Show("Max value must be a numeric value !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                                    Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Max.ToString();
	                                }
	                            }
                            }
                            else
                            {
                            	if (oSerie.ScalingMode.Equals(GraphSerieScaleModes.Auto))
                            	{
                            		Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-";
                            	}
                            	else
                            	{
                            		Grid_SeriesProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oSerie.Max.ToString();
                            	}
                            }

                            break;
                    }
                }
            }
        }
		
        private void Grid_SeriesPropertiesCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        	if(!(oContextChanList == null))
        	{
        		Close_ContextualChannelList();
        	}
        }
        
        private void Grid_SeriesPropertiesEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        	TextBox EditTxt = e.Control as TextBox;
        	
        	if (!(EditTxt == null))
        	{
        		EditTxt.TextChanged -= new EventHandler(GridCellEditText_TextChanged);
        		
	        	if (Grid_SeriesProperties.CurrentCell.ColumnIndex == SerieNameColId)
	        	{
	        		EditTxt.TextChanged += new EventHandler(GridCellEditText_TextChanged);	
	        		Show_ContextualChannelList(((DataGridView)sender).CurrentCell.RowIndex, EditTxt);
	        	}
        	}
        }
        
        private void GridCellEditText_TextChanged(object sender, EventArgs e)
        {
        	TextBox EditText = sender as TextBox;
        	
        	/*
        	if (EditText.Focused)
        	{
        		if (!(oContextChanList == null))
        		{
        			oContextChanList.FilterItems(EditText.Text);
        			
        		}
        	}
        	*/
        	
        	if (!(oContextChanList == null))
    		{
    			oContextChanList.FilterItems(EditText.Text);
    			
    		}
        }
        
        #region Grid contextual channel list
        
        private void Grid_SeriesPropertiesContextChanList_MouseDoubleClick(object sender, EventArgs e)
        {
        	Ctrl_GW_ContextualChannelList oContextChanList = (Ctrl_GW_ContextualChannelList)sender;
        	
        	if (!(oContextChanList.SelectedItems.Count == 0))
        	{
        		Set_ContextualChannelListSelection(oContextChanList);
        	}
        }
         
        #endregion
        
        #endregion

        #endregion

        #region Tab General

        private void Pic_GraphBackColor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_GraphBackColor.BackColor = Dlg_Color.Color;
            }
        }

        private void Pic_FrameLineColor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_FrameLineColor.BackColor = Dlg_Color.Color;
            }
        }

        private void Chk_SubSamplingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_MaxSampleCount.Enabled = Chk_SubSamplingEnabled.Checked;
            Txt_SampleMax.Enabled = Chk_SubSamplingEnabled.Checked;
            TrackBar_SampleMax.Enabled = Chk_SubSamplingEnabled.Checked;
            Lbl_TrackMinVal.Enabled = Chk_SubSamplingEnabled.Checked;
            Lbl_TrackMaxVal.Enabled = Chk_SubSamplingEnabled.Checked;
            Lbl_TrackMinValComment.Enabled = Chk_SubSamplingEnabled.Checked;
            Lbl_TrackMaxValComment.Enabled = Chk_SubSamplingEnabled.Checked;
        }

        private void TrackBar_SampleMax_Scroll(object sender, EventArgs e)
        {
            Txt_SampleMax.Text = ((int)((double)(TrackBar_SampleMax.Value / 100)) * 100).ToString();
        }

        private void Txt_SampleMax_Leave(object sender, EventArgs e)
        {
            if(!(Txt_SampleMax.Text.Equals(TrackBar_SampleMax.Value.ToString())))
            {
                int Val = 0;

                if (int.TryParse(Txt_SampleMax.Text, out Val))
                {
                    if (Val >= TrackBar_SampleMax.Minimum && Val <= TrackBar_SampleMax.Maximum)
                    {
                        TrackBar_SampleMax.Value = Val;
                    }
                    else
                    {
                        MessageBox.Show("Max sample count must be contained between "
                                        + TrackBar_SampleMax.Minimum.ToString()
                                        + " and " + TrackBar_SampleMax.Maximum.ToString() + " !",
                                        FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Txt_SampleMax.Text = GraphProperties.nGraphicSampleMax.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Sub sampling max sample value must be a numeric value !",
                                    FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    Txt_SampleMax.Text = GraphProperties.nGraphicSampleMax.ToString();
                }
            }
        }

        private void Chk_LegendVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_LegendFont.Enabled = Chk_LegendVisible.Checked;
            Txt_LegendFont.Enabled = Chk_LegendVisible.Checked;
            Cmd_LegendFont.Enabled = Chk_LegendVisible.Checked;
            Lbl_LegendFontSize.Enabled = Chk_LegendVisible.Checked;
            Txt_LegendFontSize.Enabled = Chk_LegendVisible.Checked;
            Lbl_LegendInformations.Enabled = Chk_LegendVisible.Checked;
            ChkLst_LegendInformations.Enabled = Chk_LegendVisible.Checked;
            Chk_LegendHeaderVisible.Enabled = Chk_LegendVisible.Checked;
            Chk_LegendGridLinesVisible.Enabled = Chk_LegendVisible.Checked;
        }

        private void Cmd_LegendFont_Click(object sender, EventArgs e)
        {
            if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
            {
                Txt_LegendFont.Font = Dlg_Font.Font;
                Txt_LegendFont.Text = Dlg_Font.Font.Name;
                Txt_LegendFontSize.Text = Dlg_Font.Font.Size.ToString();
            }
        }

        #endregion

        #region Tab Grid

        private void Chk_MHGrid_Visible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_MHGrid_Width.Enabled = Chk_MHGrid_Visible.Checked;
            Txt_MHGrid_Width.Enabled = Chk_MHGrid_Visible.Checked;
            Lbl_MHGrid_Style.Enabled = Chk_MHGrid_Visible.Checked;
            Cmb_MHGrid_Style.Enabled = Chk_MHGrid_Visible.Checked;
            Lbl_MHGrid_Color.Enabled = Chk_MHGrid_Visible.Checked;
            Pic_MHGrid_Color.Enabled = Chk_MHGrid_Visible.Checked;

            if (Chk_MHGrid_Visible.Checked)
            {
                Pic_MHGrid_Color.BackColor = GraphProperties.Grid.MainHorizontalGrid.LineColor;
            }
            else
            {
                Pic_MHGrid_Color.BackColor = SystemColors.Control;
            }
        }

        private void Chk_MVGrid_Visible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_MVGrid_Width.Enabled = Chk_MVGrid_Visible.Checked;
            Txt_MVGrid_Width.Enabled = Chk_MVGrid_Visible.Checked;
            Lbl_MVGrid_Style.Enabled = Chk_MVGrid_Visible.Checked;
            Cmb_MVGrid_Style.Enabled = Chk_MVGrid_Visible.Checked;
            Lbl_MVGrid_Color.Enabled = Chk_MVGrid_Visible.Checked;
            Pic_MVGrid_Color.Enabled = Chk_MVGrid_Visible.Checked;

            if (Chk_MVGrid_Visible.Checked)
            {
                Pic_MVGrid_Color.BackColor = GraphProperties.Grid.MainVerticalGrid.LineColor;
            }
            else
            {
                Pic_MVGrid_Color.BackColor = SystemColors.Control;
            }
        }

        private void Chk_SHGrid_Visible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_SHGrid_Width.Enabled = Chk_SHGrid_Visible.Checked;
            Txt_SHGrid_Width.Enabled = Chk_SHGrid_Visible.Checked;
            Lbl_SHGrid_Style.Enabled = Chk_SHGrid_Visible.Checked;
            Cmb_SHGrid_Style.Enabled = Chk_SHGrid_Visible.Checked;
            Lbl_SHGrid_Color.Enabled = Chk_SHGrid_Visible.Checked;
            Pic_SHGrid_Color.Enabled = Chk_SHGrid_Visible.Checked;

            if (Chk_SHGrid_Visible.Checked)
            {
                Pic_SHGrid_Color.BackColor = GraphProperties.Grid.SecondaryHorizontalGrid.LineColor;
            }
            else
            {
                Pic_SHGrid_Color.BackColor = SystemColors.Control;
            }
        }

        private void Chk_SVGrid_Visible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_SVGrid_Width.Enabled = Chk_SVGrid_Visible.Checked;
            Txt_SVGrid_Width.Enabled = Chk_SVGrid_Visible.Checked;
            Lbl_SVGrid_Style.Enabled = Chk_SVGrid_Visible.Checked;
            Cmb_SVGrid_Style.Enabled = Chk_SVGrid_Visible.Checked;
            Lbl_SVGrid_Color.Enabled = Chk_SVGrid_Visible.Checked;
            Pic_SVGrid_Color.Enabled = Chk_SVGrid_Visible.Checked;

            if (Chk_SVGrid_Visible.Checked)
            {
                Pic_SVGrid_Color.BackColor = GraphProperties.Grid.SecondaryVerticalGrid.LineColor;
            }
            else
            {
                Pic_SVGrid_Color.BackColor = SystemColors.Control;
            }
        }

        private void Pic_MHGrid_Color_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_MHGrid_Color.BackColor = Dlg_Color.Color;
            }
        }

        private void Pic_MVGrid_Color_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_MVGrid_Color.BackColor = Dlg_Color.Color;
            }
        }

        private void Pic_SHGrid_Color_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_SHGrid_Color.BackColor = Dlg_Color.Color;
            }
        }

        private void Pic_SVGrid_Color_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_SVGrid_Color.BackColor = Dlg_Color.Color;
            }
        }

        #endregion

        #region Tab Abscisse

        private void Chk_AbscisseTimeMode_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_AbscisseChannel.Enabled = !Chk_AbscisseTimeMode.Checked;
            Cmb_AbscisseChannel.Enabled = !Chk_AbscisseTimeMode.Checked;
        }

        private void Chk_AbscisseVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_AbscisseStyle.Enabled = Chk_AbscisseVisible.Checked;
            Cmb_AbscisseStyle.Enabled = Chk_AbscisseVisible.Checked;
            Lbl_AbscisseWidth.Enabled = Chk_AbscisseVisible.Checked;
            Txt_AbscisseWidth.Enabled = Chk_AbscisseVisible.Checked;
            Lbl_AbscisseColor.Enabled = Chk_AbscisseVisible.Checked;
            Pic_AbscisseColor.Enabled = Chk_AbscisseVisible.Checked;
            Chk_AbscisseValueVisible.Enabled = Chk_AbscisseVisible.Checked;

            if (Chk_AbscisseVisible.Checked)
            {
                Lbl_AbscisseFont.Enabled = Chk_AbscisseValueVisible.Checked;
                Txt_AbscisseFont.Enabled = Chk_AbscisseValueVisible.Checked;
                Cmd_AbscisseFont.Enabled = Chk_AbscisseValueVisible.Checked;
                Lbl_AbscisseFontSize.Enabled = Chk_AbscisseValueVisible.Checked;
                Txt_AbscisseFontSize.Enabled = Chk_AbscisseValueVisible.Checked;
                Pic_AbscisseColor.BackColor = GraphProperties.AbscisseAxis.AxisLineStyle.LineColor;
            }
            else
            {
                Lbl_AbscisseFont.Enabled = false;
                Txt_AbscisseFont.Enabled = false;
                Cmd_AbscisseFont.Enabled = false;
                Lbl_AbscisseFontSize.Enabled = false;
                Txt_AbscisseFontSize.Enabled = false;
                Pic_AbscisseColor.BackColor = SystemColors.Control;
            }
        }

        private void Chk_AbscisseValueVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_AbscisseFont.Enabled = Chk_AbscisseValueVisible.Checked;
            Txt_AbscisseFont.Enabled = Chk_AbscisseValueVisible.Checked;
            Cmd_AbscisseFont.Enabled = Chk_AbscisseValueVisible.Checked;
            Lbl_AbscisseFontSize.Enabled = Chk_AbscisseValueVisible.Checked;
            Txt_AbscisseFontSize.Enabled = Chk_AbscisseValueVisible.Checked;
        }

        private void Pic_AbscisseColor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_AbscisseColor.BackColor = Dlg_Color.Color;
            }
        }

        private void Cmd_AbscisseFont_Click(object sender, EventArgs e)
        {
            if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
            {
                Txt_AbscisseFont.Font = Dlg_Font.Font;
                Txt_AbscisseFont.Text = Dlg_Font.Font.Name;
                Txt_AbscisseFontSize.Text = Dlg_Font.Font.Size.ToString();
            }
        }

        #endregion
        
        #region Tab Cursors
        
        #region Main cursor
        
        private void Cmb_MainCursorModeSelectedIndexChanged(object sender, EventArgs e)
        {
        	GraphicCursorMode eCursorMode = GraphicCursorMode.None;
        	
        	if (Enum.TryParse(Cmb_MainCursorMode.Text, out eCursorMode))
        	{
        		switch (eCursorMode)
        		{
        			case GraphicCursorMode.Circle:
        				
        				Lbl_CursorLineStyle.Enabled = true;
        				Cmb_CursorLineStyle.Enabled = true;
        				Lbl_CursorLineWidth.Enabled = true;
        				Txt_CursorLineWidth.Enabled = true;
        				Lbl_CursorSize.Enabled = true;
        				Txt_CursorSize.Enabled = true;
        				Lbl_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.BackColor = GraphProperties.Cursor.Style.LineColor;
        				
        				Chk_CursorAbsValVisible.Enabled = false;
        				Lbl_CursorAbsValLocation.Enabled = false;
        				Cmb_CursorAbsValLocation.Enabled = false;
        				
        				Chk_CursorOrdValVisible.Enabled = false;
        				Lbl_CursorOrdValLocation.Enabled = false;
        				Cmb_CursorOrdValLocation.Enabled = false;
        				
        				Lbl_CursorValFont.Enabled = false;
        				Txt_CursorValFont.Enabled = false;
        				Cmd_CursorValFont.Enabled = false;
        				Lbl_CursorValFontSize.Enabled = false;
        				Txt_CursorValFontSize.Enabled = false;
                        Lbl_CursorValueForecolor.Enabled = false;
                        Pic_CursorValueForecolor.Enabled = false;

                        Lbl_CursorTitle.Enabled = false;
                        Txt_CursorTitle.Enabled = false;
                        Lbl_CursorTitleFont.Enabled = false;
                        Txt_CursorTitleFont.Enabled = false;
                        Cmd_CursorTitleFont.Enabled = false;
                        Lbl_CursorTitleFontSize.Enabled = false;
                        Txt_CursorTitleFontSize.Enabled = false;
                        Lbl_CursorTitleForecolor.Enabled = false;
                        Pic_CursorTitleForecolor.Enabled = false;
                        Lbl_CursorTitleLocation.Enabled = false;
                        Cmb_CursorTitleLocation.Enabled = false;

                        break;
        				
        			case GraphicCursorMode.Cross:
        				
        				Lbl_CursorLineStyle.Enabled = true;
        				Cmb_CursorLineStyle.Enabled = true;
        				Lbl_CursorLineWidth.Enabled = true;
        				Txt_CursorLineWidth.Enabled = true;
        				Lbl_CursorSize.Enabled = false;
        				Txt_CursorSize.Enabled = false;
        				Lbl_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.BackColor = GraphProperties.Cursor.Style.LineColor;
        				
        				Chk_CursorAbsValVisible.Enabled = true;
        				Lbl_CursorAbsValLocation.Enabled = true;
        				Cmb_CursorAbsValLocation.Enabled = true;
        				
        				Chk_CursorOrdValVisible.Enabled = true;
        				Lbl_CursorOrdValLocation.Enabled = true;
        				Cmb_CursorOrdValLocation.Enabled = true;
        				
        				if (Chk_CursorAbsValVisible.Checked || Chk_CursorOrdValVisible.Checked)
        				{
	        				Lbl_CursorValFont.Enabled = true;
	        				Txt_CursorValFont.Enabled = true;
	        				Cmd_CursorValFont.Enabled = true;
	        				Lbl_CursorValFontSize.Enabled = true;
	        				Txt_CursorValFontSize.Enabled = true;
                            Lbl_CursorValueForecolor.Enabled = true;
                            Pic_CursorValueForecolor.Enabled = true;
                        }
        				else
        				{
        					Lbl_CursorValFont.Enabled = false;
	        				Txt_CursorValFont.Enabled = false;
	        				Cmd_CursorValFont.Enabled = false;
	        				Lbl_CursorValFontSize.Enabled = false;
	        				Txt_CursorValFontSize.Enabled = false;
                            Lbl_CursorValueForecolor.Enabled = false;
                            Pic_CursorValueForecolor.Enabled = false;
                        }

                        Lbl_CursorTitle.Enabled = true;
                        Txt_CursorTitle.Enabled = true;
                        Lbl_CursorTitleFont.Enabled = true;
                        Txt_CursorTitleFont.Enabled = true;
                        Cmd_CursorTitleFont.Enabled = true;
                        Lbl_CursorTitleFontSize.Enabled = true;
                        Txt_CursorTitleFontSize.Enabled = true;
                        Lbl_CursorTitleForecolor.Enabled = true;
                        Pic_CursorTitleForecolor.Enabled = true;
                        Lbl_CursorTitleLocation.Enabled = true;
                        Cmb_CursorTitleLocation.Enabled = true;

                        break;
        				
        			case GraphicCursorMode.Graticule:
        				
        				Lbl_CursorLineStyle.Enabled = true;
        				Cmb_CursorLineStyle.Enabled = true;
        				Lbl_CursorLineWidth.Enabled = true;
        				Txt_CursorLineWidth.Enabled = true;
        				Lbl_CursorSize.Enabled = true;
        				Txt_CursorSize.Enabled = true;
        				Lbl_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.BackColor = GraphProperties.Cursor.Style.LineColor;
        				
        				Chk_CursorAbsValVisible.Enabled = false;
        				Lbl_CursorAbsValLocation.Enabled = false;
        				Cmb_CursorAbsValLocation.Enabled = false;
        				
        				Chk_CursorOrdValVisible.Enabled = false;
        				Lbl_CursorOrdValLocation.Enabled = false;
        				Cmb_CursorOrdValLocation.Enabled = false;
        				
        				Lbl_CursorValFont.Enabled = false;
        				Txt_CursorValFont.Enabled = false;
        				Cmd_CursorValFont.Enabled = false;
        				Lbl_CursorValFontSize.Enabled = false;
        				Txt_CursorValFontSize.Enabled = false;
                        Lbl_CursorValueForecolor.Enabled = false;
                        Pic_CursorValueForecolor.Enabled = false;

                        Lbl_CursorTitle.Enabled = false;
                        Txt_CursorTitle.Enabled = false;
                        Lbl_CursorTitleFont.Enabled = false;
                        Txt_CursorTitleFont.Enabled = false;
                        Cmd_CursorTitleFont.Enabled = false;
                        Lbl_CursorTitleFontSize.Enabled = false;
                        Txt_CursorTitleFontSize.Enabled = false;
                        Lbl_CursorTitleForecolor.Enabled = false;
                        Pic_CursorTitleForecolor.Enabled = false;
                        Lbl_CursorTitleLocation.Enabled = false;
                        Cmb_CursorTitleLocation.Enabled = false;

                        break;
        				
        			case GraphicCursorMode.HorizontalLine:
        				
        				Lbl_CursorLineStyle.Enabled = true;
        				Cmb_CursorLineStyle.Enabled = true;
        				Lbl_CursorLineWidth.Enabled = true;
        				Txt_CursorLineWidth.Enabled = true;
        				Lbl_CursorSize.Enabled = false;
        				Txt_CursorSize.Enabled = false;
        				Lbl_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.BackColor = GraphProperties.Cursor.Style.LineColor;
        				
        				Chk_CursorAbsValVisible.Enabled = false;
        				Lbl_CursorAbsValLocation.Enabled = false;
        				Cmb_CursorAbsValLocation.Enabled = false;
        				
        				Chk_CursorOrdValVisible.Enabled = true;
        				Lbl_CursorOrdValLocation.Enabled = true;
        				Cmb_CursorOrdValLocation.Enabled = true;
        				
        				if (Chk_CursorOrdValVisible.Checked)
        				{
	        				Lbl_CursorValFont.Enabled = true;
	        				Txt_CursorValFont.Enabled = true;
	        				Cmd_CursorValFont.Enabled = true;
	        				Lbl_CursorValFontSize.Enabled = true;
	        				Txt_CursorValFontSize.Enabled = true;
                            Lbl_CursorValueForecolor.Enabled = true;
                            Pic_CursorValueForecolor.Enabled = true;
                        }
        				else
        				{
        					Lbl_CursorValFont.Enabled = false;
	        				Txt_CursorValFont.Enabled = false;
	        				Cmd_CursorValFont.Enabled = false;
	        				Lbl_CursorValFontSize.Enabled = false;
	        				Txt_CursorValFontSize.Enabled = false;
                            Lbl_CursorValueForecolor.Enabled = false;
                            Pic_CursorValueForecolor.Enabled = false;
                        }

                        Lbl_CursorTitle.Enabled = true;
                        Txt_CursorTitle.Enabled = true;
                        Lbl_CursorTitleFont.Enabled = true;
                        Txt_CursorTitleFont.Enabled = true;
                        Cmd_CursorTitleFont.Enabled = true;
                        Lbl_CursorTitleFontSize.Enabled = true;
                        Txt_CursorTitleFontSize.Enabled = true;
                        Lbl_CursorTitleForecolor.Enabled = true;
                        Pic_CursorTitleForecolor.Enabled = true;
                        Lbl_CursorTitleLocation.Enabled = true;
                        Cmb_CursorTitleLocation.Enabled = true;

                        break;
        				
        			case GraphicCursorMode.None:
        				
        				Lbl_CursorLineStyle.Enabled = false;
        				Cmb_CursorLineStyle.Enabled = false;
        				Lbl_CursorLineWidth.Enabled = false;
        				Txt_CursorLineWidth.Enabled = false;
        				Lbl_CursorSize.Enabled = false;
        				Txt_CursorSize.Enabled = false;
        				Lbl_CursorLineColor.Enabled = false;
        				Pic_CursorLineColor.Enabled = false;
        				Pic_CursorLineColor.BackColor = SystemColors.Control;
        				
        				Chk_CursorAbsValVisible.Enabled = false;
        				Lbl_CursorAbsValLocation.Enabled = false;
        				Cmb_CursorAbsValLocation.Enabled = false;
        				
        				Chk_CursorOrdValVisible.Enabled = false;
        				Lbl_CursorOrdValLocation.Enabled = false;
        				Cmb_CursorOrdValLocation.Enabled = false;
        				
        				Lbl_CursorValFont.Enabled = false;
        				Txt_CursorValFont.Enabled = false;
        				Cmd_CursorValFont.Enabled = false;
        				Lbl_CursorValFontSize.Enabled = false;
        				Txt_CursorValFontSize.Enabled = false;
                        Lbl_CursorValueForecolor.Enabled = false;
                        Pic_CursorValueForecolor.Enabled = false;

                        Lbl_CursorTitle.Enabled = false;
                        Txt_CursorTitle.Enabled = false;
                        Lbl_CursorTitleFont.Enabled = false;
                        Txt_CursorTitleFont.Enabled = false;
                        Cmd_CursorTitleFont.Enabled = false;
                        Lbl_CursorTitleFontSize.Enabled = false;
                        Txt_CursorTitleFontSize.Enabled = false;
                        Lbl_CursorTitleForecolor.Enabled = false;
                        Pic_CursorTitleForecolor.Enabled = false;
                        Lbl_CursorTitleLocation.Enabled = false;
                        Cmb_CursorTitleLocation.Enabled = false;

                        break;
        				
        			case GraphicCursorMode.Square:
        				
        				Lbl_CursorLineStyle.Enabled = true;
        				Cmb_CursorLineStyle.Enabled = true;
        				Lbl_CursorLineWidth.Enabled = true;
        				Txt_CursorLineWidth.Enabled = true;
        				Lbl_CursorSize.Enabled = true;
        				Txt_CursorSize.Enabled = true;
        				Lbl_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.BackColor = GraphProperties.Cursor.Style.LineColor;
        				
        				Chk_CursorAbsValVisible.Enabled = false;
        				Lbl_CursorAbsValLocation.Enabled = false;
        				Cmb_CursorAbsValLocation.Enabled = false;
        				
        				Chk_CursorOrdValVisible.Enabled = false;
        				Lbl_CursorOrdValLocation.Enabled = false;
        				Cmb_CursorOrdValLocation.Enabled = false;
        				
        				Lbl_CursorValFont.Enabled = false;
        				Txt_CursorValFont.Enabled = false;
        				Cmd_CursorValFont.Enabled = false;
        				Lbl_CursorValFontSize.Enabled = false;
        				Txt_CursorValFontSize.Enabled = false;
                        Lbl_CursorValueForecolor.Enabled = false;
                        Pic_CursorValueForecolor.Enabled = false;

                        Lbl_CursorTitle.Enabled = false;
                        Txt_CursorTitle.Enabled = false;
                        Lbl_CursorTitleFont.Enabled = false;
                        Txt_CursorTitleFont.Enabled = false;
                        Cmd_CursorTitleFont.Enabled = false;
                        Lbl_CursorTitleFontSize.Enabled = false;
                        Txt_CursorTitleFontSize.Enabled = false;
                        Lbl_CursorTitleForecolor.Enabled = false;
                        Pic_CursorTitleForecolor.Enabled = false;
                        Lbl_CursorTitleLocation.Enabled = false;
                        Cmb_CursorTitleLocation.Enabled = false;

                        break;
        				
        			case GraphicCursorMode.VerticalLine:
        				
        				Lbl_CursorLineStyle.Enabled = true;
        				Cmb_CursorLineStyle.Enabled = true;
        				Lbl_CursorLineWidth.Enabled = true;
        				Txt_CursorLineWidth.Enabled = true;
        				Lbl_CursorSize.Enabled = false;
        				Txt_CursorSize.Enabled = false;
        				Lbl_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.Enabled = true;
        				Pic_CursorLineColor.BackColor = GraphProperties.Cursor.Style.LineColor;
        				
        				Chk_CursorAbsValVisible.Enabled = true;
        				Lbl_CursorAbsValLocation.Enabled = true;
        				Cmb_CursorAbsValLocation.Enabled = true;
        				
        				Chk_CursorOrdValVisible.Enabled = false;
        				Lbl_CursorOrdValLocation.Enabled = false;
        				Cmb_CursorOrdValLocation.Enabled = false;
        				
        				if (Chk_CursorAbsValVisible.Checked)
        				{
	        				Lbl_CursorValFont.Enabled = true;
	        				Txt_CursorValFont.Enabled = true;
	        				Cmd_CursorValFont.Enabled = true;
	        				Lbl_CursorValFontSize.Enabled = true;
	        				Txt_CursorValFontSize.Enabled = true;
                            Lbl_CursorValueForecolor.Enabled = true;
                            Pic_CursorValueForecolor.Enabled = true;
                        }
        				else
        				{
        					Lbl_CursorValFont.Enabled = false;
	        				Txt_CursorValFont.Enabled = false;
	        				Cmd_CursorValFont.Enabled = false;
	        				Lbl_CursorValFontSize.Enabled = false;
	        				Txt_CursorValFontSize.Enabled = false;
                            Lbl_CursorValueForecolor.Enabled = false;
                            Pic_CursorValueForecolor.Enabled = false;
                        }

                        Lbl_CursorTitle.Enabled = true;
                        Txt_CursorTitle.Enabled = true;
                        Lbl_CursorTitleFont.Enabled = true;
                        Txt_CursorTitleFont.Enabled = true;
                        Cmd_CursorTitleFont.Enabled = true;
                        Lbl_CursorTitleFontSize.Enabled = true;
                        Txt_CursorTitleFontSize.Enabled = true;
                        Lbl_CursorTitleForecolor.Enabled = true;
                        Pic_CursorTitleForecolor.Enabled = true;
                        Lbl_CursorTitleLocation.Enabled = true;
                        Cmb_CursorTitleLocation.Enabled = true;

                        break;
        		}
        	}
        	else
        	{
        		MessageBox.Show("Unknown cursor mode !", FORM_NAME, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        	}
        }
        
        private void Pic_CursorLineColorDoubleClick(object sender, EventArgs e)
        {
        	if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
        	{
        		Pic_CursorLineColor.BackColor = Dlg_Color.Color;
        	}
        }
        
        private void Chk_CursorAbsValVisibleCheckedChanged(object sender, EventArgs e)
        {
        	Lbl_CursorAbsValLocation.Enabled = Chk_CursorAbsValVisible.Checked;
			Cmb_CursorAbsValLocation.Enabled = Chk_CursorAbsValVisible.Checked;
			
			bool bFontEnabled = false;
			
			if (Chk_CursorOrdValVisible.Enabled && Chk_CursorOrdValVisible.Checked)
			{
				bFontEnabled = true;
			}
			else
			{
				bFontEnabled = Chk_CursorAbsValVisible.Checked;
			}
			
			Lbl_CursorValFont.Enabled = bFontEnabled;
			Txt_CursorValFont.Enabled = bFontEnabled;
			Cmd_CursorValFont.Enabled = bFontEnabled;
			Lbl_CursorValFontSize.Enabled = bFontEnabled;
			Txt_CursorValFontSize.Enabled = bFontEnabled;
            Lbl_CursorValueForecolor.Enabled = bFontEnabled;
            Pic_CursorValueForecolor.Enabled = bFontEnabled;
        }
        
        private void Chk_CursorOrdValVisibleCheckedChanged(object sender, EventArgs e)
        {
        	Lbl_CursorOrdValLocation.Enabled = Chk_CursorOrdValVisible.Checked;
			Cmb_CursorOrdValLocation.Enabled = Chk_CursorOrdValVisible.Checked;
			
			bool bFontEnabled = false;
			
			if (Chk_CursorAbsValVisible.Enabled && Chk_CursorAbsValVisible.Checked)
			{
				bFontEnabled = true;
			}
			else
			{
				bFontEnabled = Chk_CursorOrdValVisible.Checked;
			}
			
			Lbl_CursorValFont.Enabled = bFontEnabled;
			Txt_CursorValFont.Enabled = bFontEnabled;
			Cmd_CursorValFont.Enabled = bFontEnabled;
			Lbl_CursorValFontSize.Enabled = bFontEnabled;
			Txt_CursorValFontSize.Enabled = bFontEnabled;
            Lbl_CursorValueForecolor.Enabled = bFontEnabled;
            Pic_CursorValueForecolor.Enabled = bFontEnabled;
        }
        
        private void Cmd_CursorValFontClick(object sender, EventArgs e)
        {
        	if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
        	{
        		Txt_CursorValFont.Text = Dlg_Font.Font.Name;
        		Txt_CursorValFont.Font = Dlg_Font.Font;
        		Txt_CursorValFontSize.Text = Dlg_Font.Font.Size.ToString();
        	}
        }

        private void Pic_CursorValueForecolor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_CursorValueForecolor.BackColor = Dlg_Color.Color;
            }
        }

        private void Cmd_CursorTitleFont_Click(object sender, EventArgs e)
        {
            if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
            {
                Txt_CursorTitleFont.Text = Dlg_Font.Font.Name;
                Txt_CursorTitleFont.Font = Dlg_Font.Font;
                Txt_CursorTitleFontSize.Text = Dlg_Font.Font.Size.ToString();
            }
        }

        private void Pic_CursorTitleForecolor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_CursorTitleForecolor.BackColor = Dlg_Color.Color;
            }
        }

        #endregion

        #region Reference cursor

        private void Cmb_RefCursorModeSelectedIndexChanged(object sender, EventArgs e)
        {
        	GraphicCursorMode eCursorMode = GraphicCursorMode.None;
        	
        	if (Enum.TryParse(Cmb_RefCursorMode.Text, out eCursorMode))
        	{
        		switch (eCursorMode)
        		{
        			case GraphicCursorMode.VerticalLine:
        				
        				Lbl_RefCursorLineStyle.Enabled = true;
        				Cmb_RefCursorLineStyle.Enabled = true;
        				Lbl_RefCursorLineWidth.Enabled = true;
        				Txt_RefCursorLineWidth.Enabled = true;
        				Lbl_RefCursorLineColor.Enabled = true;
        				Pic_RefCursorLineColor.Enabled = true;
        				Pic_RefCursorLineColor.BackColor = GraphProperties.ReferenceCursor.Style.LineColor;
        				
        				Chk_RefCursorAbsValVisible.Enabled = true;
        				Lbl_RefCursorAbsValLocation.Enabled = true;
        				Cmb_RefCursorAbsValLocation.Enabled = true;
        				
        				Chk_RefCursorOrdValVisible.Enabled = false;
        				Lbl_RefCursorOrdValLocation.Enabled = false;
        				Cmb_RefCursorOrdValLocation.Enabled = false;
        				
        				if (Chk_RefCursorAbsValVisible.Checked)
        				{
	        				Lbl_RefCursorValFont.Enabled = true;
	        				Txt_RefCursorValFont.Enabled = true;
	        				Cmd_RefCursorValFont.Enabled = true;
	        				Lbl_RefCursorValFontSize.Enabled = true;
	        				Txt_RefCursorValFontSize.Enabled = true;
        				}
        				else
        				{
        					Lbl_RefCursorValFont.Enabled = false;
	        				Txt_RefCursorValFont.Enabled = false;
	        				Cmd_RefCursorValFont.Enabled = false;
	        				Lbl_RefCursorValFontSize.Enabled = false;
	        				Txt_RefCursorValFontSize.Enabled = false;
        				}
        				
        				break;
        				
        			case GraphicCursorMode.HorizontalLine:
        				
        				Lbl_RefCursorLineStyle.Enabled = true;
        				Cmb_RefCursorLineStyle.Enabled = true;
        				Lbl_RefCursorLineWidth.Enabled = true;
        				Txt_RefCursorLineWidth.Enabled = true;
        				Lbl_RefCursorLineColor.Enabled = true;
        				Pic_RefCursorLineColor.Enabled = true;
        				Pic_RefCursorLineColor.BackColor = GraphProperties.ReferenceCursor.Style.LineColor;
        				
        				Chk_RefCursorAbsValVisible.Enabled = false;
        				Lbl_RefCursorAbsValLocation.Enabled = false;
        				Cmb_RefCursorAbsValLocation.Enabled = false;
        				
        				Chk_RefCursorOrdValVisible.Enabled = true;
        				Lbl_RefCursorOrdValLocation.Enabled = true;
        				Cmb_RefCursorOrdValLocation.Enabled = true;
        				
        				if (Chk_RefCursorOrdValVisible.Checked)
        				{
	        				Lbl_RefCursorValFont.Enabled = true;
	        				Txt_RefCursorValFont.Enabled = true;
	        				Cmd_RefCursorValFont.Enabled = true;
	        				Lbl_RefCursorValFontSize.Enabled = true;
	        				Txt_RefCursorValFontSize.Enabled = true;
        				}
        				else
        				{
        					Lbl_RefCursorValFont.Enabled = false;
	        				Txt_RefCursorValFont.Enabled = false;
	        				Cmd_RefCursorValFont.Enabled = false;
	        				Lbl_RefCursorValFontSize.Enabled = false;
	        				Txt_RefCursorValFontSize.Enabled = false;
        				}
        				
        				break;
        				
        			default:
        				
        				Lbl_RefCursorLineStyle.Enabled = false;
        				Cmb_RefCursorLineStyle.Enabled = false;
        				Lbl_RefCursorLineWidth.Enabled = false;
        				Txt_RefCursorLineWidth.Enabled = false;
        				Lbl_RefCursorLineColor.Enabled = false;
        				Pic_RefCursorLineColor.Enabled = false;
        				Pic_RefCursorLineColor.BackColor = SystemColors.Control;
        				
        				Chk_RefCursorAbsValVisible.Enabled = false;
        				Lbl_RefCursorAbsValLocation.Enabled = false;
        				Cmb_RefCursorAbsValLocation.Enabled = false;
        				
        				Chk_RefCursorOrdValVisible.Enabled = false;
        				Lbl_RefCursorOrdValLocation.Enabled = false;
        				Cmb_RefCursorOrdValLocation.Enabled = false;
        				
        				Lbl_RefCursorValFont.Enabled = false;
        				Txt_RefCursorValFont.Enabled = false;
        				Cmd_RefCursorValFont.Enabled = false;
        				Lbl_RefCursorValFontSize.Enabled = false;
        				Txt_RefCursorValFontSize.Enabled = false;
        				
        				break;
        		}
        	}
        	else
        	{
        		MessageBox.Show("Unknown reference cursor mode !", FORM_NAME, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        	}
        }
        
        private void Pic_RefCursorLineColorDoubleClick(object sender, EventArgs e)
        {
        	if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
        	{
        		Pic_RefCursorLineColor.BackColor = Dlg_Color.Color;
        	}
        }
        
        private void Chk_RefCursorAbsValVisibleCheckedChanged(object sender, EventArgs e)
        {
        	Lbl_RefCursorAbsValLocation.Enabled = Chk_RefCursorAbsValVisible.Checked;
			Cmb_RefCursorAbsValLocation.Enabled = Chk_RefCursorAbsValVisible.Checked;
			
			bool bFontEnabled = false;
			
			if (Chk_RefCursorOrdValVisible.Enabled && Chk_RefCursorOrdValVisible.Checked)
			{
				bFontEnabled = true;
			}
			else
			{
				bFontEnabled = Chk_RefCursorAbsValVisible.Checked;
			}
			
			Lbl_RefCursorValFont.Enabled = bFontEnabled;
			Txt_RefCursorValFont.Enabled = bFontEnabled;
			Cmd_RefCursorValFont.Enabled = bFontEnabled;
			Lbl_RefCursorValFontSize.Enabled = bFontEnabled;
			Txt_RefCursorValFontSize.Enabled = bFontEnabled;
        }
        
        private void Chk_RefCursorOrdValVisibleCheckedChanged(object sender, EventArgs e)
        {
        	Lbl_RefCursorOrdValLocation.Enabled = Chk_RefCursorOrdValVisible.Checked;
			Cmb_RefCursorOrdValLocation.Enabled = Chk_RefCursorOrdValVisible.Checked;
			
			bool bFontEnabled = false;
			
			if (Chk_RefCursorAbsValVisible.Enabled && Chk_RefCursorAbsValVisible.Checked)
			{
				bFontEnabled = true;
			}
			else
			{
				bFontEnabled = Chk_RefCursorOrdValVisible.Checked;
			}
			
			Lbl_RefCursorValFont.Enabled = bFontEnabled;
			Txt_RefCursorValFont.Enabled = bFontEnabled;
			Cmd_RefCursorValFont.Enabled = bFontEnabled;
			Lbl_RefCursorValFontSize.Enabled = bFontEnabled;
			Txt_RefCursorValFontSize.Enabled = bFontEnabled;
        }
        
        private void Cmd_RefCursorValFontClick(object sender, EventArgs e)
        {
        	if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
        	{
        		Txt_RefCursorValFont.Text = Dlg_Font.Font.Name;
        		Txt_RefCursorValFont.Font = Dlg_Font.Font;
        		Txt_RefCursorValFontSize.Text = Dlg_Font.Font.Size.ToString();
        	}
        }
        
        #endregion
        
        #endregion

        #region Context_Grid_SeriesProperties

        private void addSerieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create_NewSerie();
        }

        private void deleteSelectedSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_SelectedSeries();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy_SelectedSeries();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste_Series();
        }

        private void moveSelectionUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move_SelectedSeries("Up");
        }

        private void moveSelectionDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move_SelectedSeries("Down");
        }

        #endregion

        #endregion

        #region Private methodes

        #region Whole properties management

        private void Show_Properties()
        {
            //Serie
            Cmb_GraphLayoutMode.SelectedItem = GraphProperties.GraphLayoutMode.ToString();
            Chk_AllowOverScaling.Checked = GraphProperties.bAllowOverScaling;

            Show_SeriesProperties();
            
            //General
            Pic_GraphBackColor.BackColor = GraphProperties.WindowBackColor;
            
            Txt_FrameLineWidth.Text = GraphProperties.Frame.BorderWidth.ToString();
            Pic_FrameLineColor.BackColor = GraphProperties.Frame.BorderColor;
            
            Chk_SubSamplingEnabled.Checked = GraphProperties.bSubSamplingEnabled;
            Txt_SampleMax.Text = GraphProperties.nGraphicSampleMax.ToString();
            TrackBar_SampleMax.Value = GraphProperties.nGraphicSampleMax;
            
            Chk_LegendVisible.Checked = GraphProperties.LegendProperties.Visible;
            Txt_LegendFont.Font = GraphProperties.LegendProperties.LegendFont.oFont;
            Txt_LegendFont.Text = GraphProperties.LegendProperties.LegendFont.oFont.Name;
            Txt_LegendFontSize.Text = GraphProperties.LegendProperties.LegendFont.oFont.Size.ToString();
            ShowLegendInformations(GraphProperties.LegendProperties.Informations);
            Chk_LegendHeaderVisible.Checked = GraphProperties.LegendProperties.LegendHeaderVisible;
            Chk_LegendGridLinesVisible.Checked = GraphProperties.LegendProperties.LegendGridLinesVisible;

            //Grids
            Chk_MHGrid_Visible.Checked = GraphProperties.Grid.MainHorizontalGrid.Visible;
            Txt_MHGrid_Width.Text = GraphProperties.Grid.MainHorizontalGrid.LineWidth.ToString();
            Cmb_MHGrid_Style.Text = GraphProperties.Grid.MainHorizontalGrid.LineStyle.ToString();
            Pic_MHGrid_Color.BackColor = GraphProperties.Grid.MainHorizontalGrid.LineColor;

            Chk_MVGrid_Visible.Checked = GraphProperties.Grid.MainVerticalGrid.Visible;
            Txt_MVGrid_Width.Text = GraphProperties.Grid.MainVerticalGrid.LineWidth.ToString();
            Cmb_MVGrid_Style.Text = GraphProperties.Grid.MainVerticalGrid.LineStyle.ToString();
            Pic_MVGrid_Color.BackColor = GraphProperties.Grid.MainVerticalGrid.LineColor;

            Chk_SHGrid_Visible.Checked = GraphProperties.Grid.SecondaryHorizontalGrid.Visible;
            Txt_SHGrid_Width.Text = GraphProperties.Grid.SecondaryHorizontalGrid.LineWidth.ToString();
            Cmb_SHGrid_Style.Text = GraphProperties.Grid.SecondaryHorizontalGrid.LineStyle.ToString();
            Pic_SHGrid_Color.BackColor = GraphProperties.Grid.SecondaryHorizontalGrid.LineColor;

            Chk_SVGrid_Visible.Checked = GraphProperties.Grid.SecondaryVerticalGrid.Visible;
            Txt_SVGrid_Width.Text = GraphProperties.Grid.SecondaryVerticalGrid.LineWidth.ToString();
            Cmb_SVGrid_Style.Text = GraphProperties.Grid.SecondaryVerticalGrid.LineStyle.ToString();
            Pic_SVGrid_Color.BackColor = GraphProperties.Grid.SecondaryVerticalGrid.LineColor;

            //Abscisse
            Chk_AbscisseTimeMode.Checked = GraphProperties.AbscisseAxis.TimeMode;
            Cmb_AbscisseChannel.Text = GraphProperties.AbscisseAxis.AbscisseChannelName;

            Chk_AbscisseVisible.Checked = GraphProperties.AbscisseAxis.Visible;
            Cmb_AbscisseStyle.SelectedItem = GraphProperties.AbscisseAxis.AxisLineStyle.LineStyle.ToString();
            Txt_AbscisseWidth.Text = GraphProperties.AbscisseAxis.AxisLineStyle.LineWidth.ToString();

            if(GraphProperties.AbscisseAxis.Visible)
            {
                Pic_AbscisseColor.BackColor = GraphProperties.AbscisseAxis.AxisLineStyle.LineColor;
            }

            Chk_AbscisseValueVisible.Checked = GraphProperties.AbscisseAxis.AxisValuesVisible;
            Txt_AbscisseFont.Text = GraphProperties.AbscisseAxis.AxisValuesFont.oFont.Name;
            Txt_AbscisseFont.Font = GraphProperties.AbscisseAxis.AxisValuesFont.oFont;
            Txt_AbscisseFontSize.Text = GraphProperties.AbscisseAxis.AxisValuesFont.oFont.Size.ToString();
            
            Ctrl_AbcisseRefLines.Show_ReferenceLines();
            
            //Cursors
            Cmb_MainCursorMode.SelectedItem = GraphProperties.Cursor.Mode.ToString();
            
            Cmb_CursorLineStyle.SelectedItem = GraphProperties.Cursor.Style.LineStyle.ToString();
            Txt_CursorLineWidth.Text = GraphProperties.Cursor.Style.LineWidth.ToString();
            Txt_CursorSize.Text = GraphProperties.Cursor.CursorSize.ToString();
            
            if (!(GraphProperties.Cursor.Mode.Equals(GraphicCursorMode.None)))
            {
            	Pic_CursorLineColor.BackColor = GraphProperties.Cursor.Style.LineColor;
            }
            else
            {
            	Pic_CursorLineColor.BackColor = SystemColors.Control;
            }
            
            Chk_CursorAbsValVisible.Checked = GraphProperties.Cursor.ShowCursorAbscisseValue;
            Cmb_CursorAbsValLocation.SelectedItem = GraphProperties.Cursor.AbscisseValuePostion.ToString();
            
            Chk_CursorOrdValVisible.Checked = GraphProperties.Cursor.ShowCursorOrdinatesValue;
            Cmb_CursorOrdValLocation.SelectedItem = GraphProperties.Cursor.OrdinateValuesPosition.ToString();
            
            Txt_CursorValFont.Font = GraphProperties.Cursor.CursorValueFont.oFont;
            Txt_CursorValFont.Text = GraphProperties.Cursor.CursorValueFont.oFont.Name;
            Txt_CursorValFontSize.Text = GraphProperties.Cursor.CursorValueFont.oFont.Size.ToString();

            if (GraphProperties.Cursor.CursorValueForeColor == Color.Empty)
            {
                Pic_CursorValueForecolor.BackColor = SystemColors.Control;
            }
            else
            {
                Pic_CursorValueForecolor.BackColor = GraphProperties.Cursor.CursorValueForeColor;
            }

            Txt_CursorTitle.Text = GraphProperties.Cursor.CursorTitle;
            Txt_CursorTitleFont.Font = GraphProperties.Cursor.CursorTitleFont.oFont;
            Txt_CursorTitleFont.Text = GraphProperties.Cursor.CursorTitleFont.oFont.Name;
            Txt_CursorTitleFontSize.Text = GraphProperties.Cursor.CursorTitleFont.oFont.Size.ToString();
            Pic_CursorTitleForecolor.BackColor = GraphProperties.Cursor.CursorTitleForeColor;
            Cmb_CursorTitleLocation.SelectedItem = GraphProperties.Cursor.CursorTitlePosition.ToString();

            //Reference cursor
            Cmb_RefCursorMode.SelectedItem = GraphProperties.ReferenceCursor.Mode.ToString();
            
            Cmb_RefCursorLineStyle.SelectedItem = GraphProperties.ReferenceCursor.Style.LineStyle.ToString();
            Txt_RefCursorLineWidth.Text = GraphProperties.ReferenceCursor.Style.LineWidth.ToString();
            
            if (!(GraphProperties.ReferenceCursor.Mode.Equals(GraphicCursorMode.None)))
            {
            	Pic_RefCursorLineColor.BackColor = GraphProperties.ReferenceCursor.Style.LineColor;
            }
            else
            {
            	Pic_RefCursorLineColor.BackColor = SystemColors.Control;
            }
            
            Chk_RefCursorAbsValVisible.Checked = GraphProperties.ReferenceCursor.ShowCursorAbscisseValue;
            Cmb_RefCursorAbsValLocation.SelectedItem = GraphProperties.ReferenceCursor.AbscisseValuePostion.ToString();
            
            Chk_RefCursorOrdValVisible.Checked = GraphProperties.ReferenceCursor.ShowCursorOrdinatesValue;
            Cmb_RefCursorOrdValLocation.SelectedItem = GraphProperties.ReferenceCursor.OrdinateValuesPosition.ToString();
            
            Txt_RefCursorValFont.Font = GraphProperties.ReferenceCursor.CursorValueFont.oFont;
            Txt_RefCursorValFont.Text = GraphProperties.ReferenceCursor.CursorValueFont.oFont.Name;
            Txt_RefCursorValFontSize.Text = GraphProperties.ReferenceCursor.CursorValueFont.oFont.Size.ToString();
            

        }

        private bool Set_Properties()
        {
            GraphWindowProperties TmpProp = new GraphWindowProperties();

            //General
            TmpProp.WindowBackColor = Pic_GraphBackColor.BackColor;
            TmpProp.Frame.BorderColor = Pic_FrameLineColor.BackColor;

            if (!(Txt_FrameLineWidth.Text.Equals("")))
            {
                if (!(int.TryParse(Txt_FrameLineWidth.Text, out TmpProp.Frame.BorderWidth)))
                {
                    MessageBox.Show("Frame line width value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return(false);
                }
            }
            else
            {
                TmpProp.Frame.BorderWidth = 2; //Default value
            }

            TmpProp.bSubSamplingEnabled = Chk_SubSamplingEnabled.Checked;

            if(!(Txt_SampleMax.Text.Equals("")))
            {
                if(!(int.TryParse(Txt_SampleMax.Text,out TmpProp.nGraphicSampleMax)))
                {
                    MessageBox.Show("Max samples count value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                TmpProp.nGraphicSampleMax = 1000;
            }

            TmpProp.LegendProperties.Visible = Chk_LegendVisible.Checked;
            TmpProp.LegendProperties.LegendFont = new GW_Font(Txt_LegendFont.Font.Name,
                                                                Txt_LegendFont.Font.Size,
                                                                Txt_LegendFont.Font.Bold, 
                                                                Txt_LegendFont.Font.Italic,
                                                                true,
                                                                Txt_LegendFont.Font.Strikeout,
                                                                Txt_LegendFont.Font.Underline);
            
            TmpProp.LegendProperties.Informations = GetLegendInformation();
            TmpProp.LegendProperties.LegendHeaderVisible = Chk_LegendHeaderVisible.Checked;
            TmpProp.LegendProperties.LegendGridLinesVisible = Chk_LegendGridLinesVisible.Checked;

            //Grid
            TmpProp.Grid.MainHorizontalGrid.Visible = Chk_MHGrid_Visible.Checked;
            
            if (TmpProp.Grid.MainHorizontalGrid.Visible)
            {
                if (!(Txt_MHGrid_Width.Text.Equals("")))
                {
                    if (!(float.TryParse(Txt_MHGrid_Width.Text, out TmpProp.Grid.MainHorizontalGrid.LineWidth)))
                    {
                        MessageBox.Show("Main horizontal grid line width value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
                else
                {
                    TmpProp.Grid.MainHorizontalGrid.LineWidth = 1; //Default value
                }

                if (!(Cmb_MHGrid_Style.Text.Equals("")))
                {
                    if (!(Enum.TryParse(Cmb_MHGrid_Style.Text, out TmpProp.Grid.MainHorizontalGrid.LineStyle)))
                    {
                        MessageBox.Show("Main horizontal grid line style value is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
                else
                {
                    TmpProp.Grid.MainHorizontalGrid.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash; //Default value
                }

                TmpProp.Grid.MainHorizontalGrid.LineColor = Pic_MHGrid_Color.BackColor;
            }

            TmpProp.Grid.MainVerticalGrid.Visible = Chk_MVGrid_Visible.Checked;

            if (TmpProp.Grid.MainVerticalGrid.Visible)
            {
                if (!(Txt_MVGrid_Width.Text.Equals("")))
                {
                    if (!(float.TryParse(Txt_MVGrid_Width.Text, out TmpProp.Grid.MainVerticalGrid.LineWidth)))
                    {
                        MessageBox.Show("Main horizontal grid line width value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
                else
                {
                    TmpProp.Grid.MainVerticalGrid.LineWidth = 1; //Default value
                }

                if (!(Cmb_MVGrid_Style.Text.Equals("")))
                {
                    if (!(Enum.TryParse(Cmb_MVGrid_Style.Text, out TmpProp.Grid.MainVerticalGrid.LineStyle)))
                    {
                        MessageBox.Show("Main horizontal grid line style value is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
                else
                {
                    TmpProp.Grid.MainVerticalGrid.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash; //Default value
                }

                TmpProp.Grid.MainVerticalGrid.LineColor = Pic_MVGrid_Color.BackColor;
            }

            TmpProp.Grid.SecondaryHorizontalGrid.Visible = Chk_SHGrid_Visible.Checked;

            if (TmpProp.Grid.SecondaryHorizontalGrid.Visible)
            {
                if (!(Txt_SHGrid_Width.Text.Equals("")))
                {
                    if (!(float.TryParse(Txt_SHGrid_Width.Text, out TmpProp.Grid.SecondaryHorizontalGrid.LineWidth)))
                    {
                        MessageBox.Show("Main horizontal grid line width value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
                else
                {
                    TmpProp.Grid.SecondaryHorizontalGrid.LineWidth = 1; //Default value
                }

                if (!(Cmb_SHGrid_Style.Text.Equals("")))
                {
                    if (!(Enum.TryParse(Cmb_SHGrid_Style.Text, out TmpProp.Grid.SecondaryHorizontalGrid.LineStyle)))
                    {
                        MessageBox.Show("Main horizontal grid line style value is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
                else
                {
                    TmpProp.Grid.SecondaryHorizontalGrid.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot; //Default value
                }

                TmpProp.Grid.SecondaryHorizontalGrid.LineColor = Pic_SHGrid_Color.BackColor;
            }

            TmpProp.Grid.SecondaryVerticalGrid.Visible = Chk_SVGrid_Visible.Checked;

            if (TmpProp.Grid.SecondaryVerticalGrid.Visible)
            {
                if (!(Txt_SVGrid_Width.Text.Equals("")))
                {
                    if (!(float.TryParse(Txt_SVGrid_Width.Text, out TmpProp.Grid.SecondaryVerticalGrid.LineWidth)))
                    {
                        MessageBox.Show("Main horizontal grid line width value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
                else
                {
                    TmpProp.Grid.SecondaryVerticalGrid.LineWidth = 1; //Default value
                }

                if (!(Cmb_SVGrid_Style.Text.Equals("")))
                {
                    if (!(Enum.TryParse(Cmb_SVGrid_Style.Text, out TmpProp.Grid.SecondaryVerticalGrid.LineStyle)))
                    {
                        MessageBox.Show("Main horizontal grid line style value is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
                else
                {
                    TmpProp.Grid.SecondaryVerticalGrid.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot; //Default value
                }

                TmpProp.Grid.SecondaryVerticalGrid.LineColor = Pic_SVGrid_Color.BackColor;
            }

            //Abscisse
            TmpProp.AbscisseAxis.TimeMode = Chk_AbscisseTimeMode.Checked;
            TmpProp.AbscisseAxis.AbscisseChannelName = Cmb_AbscisseChannel.Text;

            if ((!TmpProp.AbscisseAxis.TimeMode) && TmpProp.AbscisseAxis.AbscisseChannelName.Equals(""))
            {
                MessageBox.Show("An abscisse data source must be selected while it is not in time mode !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            TmpProp.AbscisseAxis.Visible = Chk_AbscisseVisible.Checked;

            if (TmpProp.AbscisseAxis.Visible)
            {
                if (!(Txt_AbscisseWidth.Text.Equals("")))
                {
                    if (!(float.TryParse(Txt_AbscisseWidth.Text, out TmpProp.AbscisseAxis.AxisLineStyle.LineWidth)))
                    {
                        MessageBox.Show("Abscisse line width value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return (false);
                    }
                }
                else
                {
                    TmpProp.AbscisseAxis.AxisLineStyle.LineWidth = 1;
                }

                if (!(Enum.TryParse(Cmb_AbscisseStyle.Text, out TmpProp.AbscisseAxis.AxisLineStyle.LineStyle)))
                {
                    MessageBox.Show("Abscisse line style value is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }

                TmpProp.AbscisseAxis.AxisLineStyle.LineColor = Pic_AbscisseColor.BackColor;

                TmpProp.AbscisseAxis.AxisValuesVisible = Chk_AbscisseValueVisible.Checked;

                if (TmpProp.AbscisseAxis.AxisValuesVisible)
                {
                    TmpProp.AbscisseAxis.AxisValuesFont = new GW_Font(Txt_AbscisseFont.Font.Name,
                                                                        Txt_AbscisseFont.Font.Size,
                                                                        Txt_AbscisseFont.Font.Bold,
                                                                        Txt_AbscisseFont.Font.Italic,
                                                                        true, 
                                                                        Txt_AbscisseFont.Font.Strikeout,
                                                                        Txt_AbscisseFont.Font.Underline);
                }
				
                Ctrl_AbcisseRefLines.Get_ReferenceLines();
                TmpProp.AbscisseAxis.ReferenceLines = Ctrl_AbcisseRefLines.ReferenceLines;
            }
            
            //Cursors
            if (!(Enum.TryParse(Cmb_MainCursorMode.Text, out TmpProp.Cursor.Mode)))
            {
            	MessageBox.Show("Unknown cursor mode !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return(false);
            }
            
            if (!(TmpProp.Cursor.Mode.Equals(GraphicCursorMode.None)))
            {
            	if (!(Enum.TryParse(Cmb_CursorLineStyle.Text, out TmpProp.Cursor.Style.LineStyle)))
            	{
            		MessageBox.Show("Cursor line style value is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
            	}
            	
            	if (!(Txt_CursorLineWidth.Text.Equals("")))
                {
                    if (!(float.TryParse(Txt_CursorLineWidth.Text, out TmpProp.Cursor.Style.LineWidth)))
                    {
                        MessageBox.Show("Cursor line width value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return (false);
                    }
                }
                else
                {
                    TmpProp.Cursor.Style.LineWidth = 1;
                }
                
                TmpProp.Cursor.Style.LineColor = Pic_CursorLineColor.BackColor;
                
                if (!(Txt_CursorSize.Text.Equals("")))
                {
                	if (!(int.TryParse(Txt_CursorSize.Text, out TmpProp.Cursor.CursorSize)))
                	{
                		MessageBox.Show("Cursor size value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return (false);
                	}
                }
                else
                {
                	TmpProp.Cursor.CursorSize = 2;
                }
                
                TmpProp.Cursor.ShowCursorAbscisseValue = Chk_CursorAbsValVisible.Checked;
                
                if (Chk_CursorAbsValVisible.Checked)
                {
                	if (!(Enum.TryParse(Cmb_CursorAbsValLocation.Text, out TmpProp.Cursor.AbscisseValuePostion)))
                	{
                		MessageBox.Show("Cursor X value location is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    	return (false);
                	}
                }
                
                TmpProp.Cursor.ShowCursorOrdinatesValue = Chk_CursorOrdValVisible.Checked;
                
                if (Chk_CursorOrdValVisible.Checked)
                {
                	if (!(Enum.TryParse(Cmb_CursorOrdValLocation.Text, out TmpProp.Cursor.OrdinateValuesPosition)))
                	{
                		MessageBox.Show("Cursor Y values location is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    	return (false);
                	}
                }
                
                TmpProp.Cursor.CursorValueFont = new GW_Font(Txt_CursorValFont.Font.Name, 
                                                             Txt_CursorValFont.Font.Size, 
                                                             Txt_CursorValFont.Font.Bold, 
                                                             Txt_CursorValFont.Font.Italic, 
                                                             true, 
                                                             Txt_CursorValFont.Font.Strikeout, 
                                                             Txt_CursorValFont.Font.Underline);

                if (Pic_CursorValueForecolor.BackColor == SystemColors.Control)
                {
                    TmpProp.Cursor.CursorValueForeColor = Color.Empty;
                }
                else
                {
                    TmpProp.Cursor.CursorValueForeColor = Pic_CursorValueForecolor.BackColor;
                }

                TmpProp.Cursor.CursorTitle = Txt_CursorTitle.Text;

                TmpProp.Cursor.CursorTitleFont = new GW_Font(Txt_CursorTitleFont.Font.Name,
                                                             Txt_CursorTitleFont.Font.Size,
                                                             Txt_CursorTitleFont.Font.Bold,
                                                             Txt_CursorTitleFont.Font.Italic,
                                                             true,
                                                             Txt_CursorTitleFont.Font.Strikeout,
                                                             Txt_CursorTitleFont.Font.Underline);

                TmpProp.Cursor.CursorTitleForeColor = Pic_CursorTitleForecolor.BackColor;

                if (!(Enum.TryParse(Cmb_CursorTitleLocation.Text, out TmpProp.Cursor.CursorTitlePosition)))
                {
                    MessageBox.Show("Cursor title location is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            
            //Reference cursor
            if (!(Enum.TryParse(Cmb_RefCursorMode.Text, out TmpProp.ReferenceCursor.Mode)))
            {
            	MessageBox.Show("Unknown reference cursor mode !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return(false);
            }
            
            if (!(TmpProp.ReferenceCursor.Mode.Equals(GraphicCursorMode.None)))
            {
            	if (!(Enum.TryParse(Cmb_RefCursorLineStyle.Text, out TmpProp.ReferenceCursor.Style.LineStyle)))
            	{
            		MessageBox.Show("Reference cursor line style value is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
            	}
            	
            	if (!(Txt_RefCursorLineWidth.Text.Equals("")))
                {
                    if (!(float.TryParse(Txt_RefCursorLineWidth.Text, out TmpProp.ReferenceCursor.Style.LineWidth)))
                    {
                        MessageBox.Show("Reference cursor line width value must be a number !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return (false);
                    }
                }
                else
                {
                    TmpProp.ReferenceCursor.Style.LineWidth = 2;
                }
                
                TmpProp.ReferenceCursor.Style.LineColor = Pic_RefCursorLineColor.BackColor;
                
                TmpProp.ReferenceCursor.ShowCursorAbscisseValue = Chk_RefCursorAbsValVisible.Checked;
                
                if (Chk_RefCursorAbsValVisible.Checked)
                {
                	if (!(Enum.TryParse(Cmb_RefCursorAbsValLocation.Text, out TmpProp.ReferenceCursor.AbscisseValuePostion)))
                	{
                		MessageBox.Show("Reference cursor X value location is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    	return (false);
                	}
                }
                
                TmpProp.ReferenceCursor.ShowCursorOrdinatesValue = Chk_RefCursorOrdValVisible.Checked;
                
                if (Chk_RefCursorOrdValVisible.Checked)
                {
                	if (!(Enum.TryParse(Cmb_RefCursorOrdValLocation.Text, out TmpProp.ReferenceCursor.OrdinateValuesPosition)))
                	{
                		MessageBox.Show("Reference cursor Y values location is invalid !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    	return (false);
                	}
                }
                
                TmpProp.ReferenceCursor.CursorValueFont = new GW_Font(Txt_RefCursorValFont.Font.Name, 
                                                             Txt_RefCursorValFont.Font.Size, 
                                                             Txt_RefCursorValFont.Font.Bold, 
                                                             Txt_RefCursorValFont.Font.Italic, 
                                                             true, 
                                                             Txt_RefCursorValFont.Font.Strikeout, 
                                                             Txt_RefCursorValFont.Font.Underline);
            }
            
            //Series
            if (!(Enum.TryParse(Cmb_GraphLayoutMode.Text, out TmpProp.GraphLayoutMode)))
            {
                MessageBox.Show("Unknown layout mode !", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return(false);
            }
            
            TmpProp.bAllowOverScaling = Chk_AllowOverScaling.Checked;

            //All single series properties are set run time

            //GraphProperties update
            GraphProperties.WindowBackColor = TmpProp.WindowBackColor;

            GraphProperties.bSubSamplingEnabled = TmpProp.bSubSamplingEnabled;
            GraphProperties.nGraphicSampleMax = TmpProp.nGraphicSampleMax;

            GraphProperties.Frame.BorderColor = TmpProp.Frame.BorderColor;
            GraphProperties.Frame.BorderWidth = TmpProp.Frame.BorderWidth;

            GraphProperties.LegendProperties.Visible = TmpProp.LegendProperties.Visible;
            GraphProperties.LegendProperties.LegendHeaderVisible = TmpProp.LegendProperties.LegendHeaderVisible;
            GraphProperties.LegendProperties.LegendGridLinesVisible = TmpProp.LegendProperties.LegendGridLinesVisible;
            GraphProperties.LegendProperties.Informations = TmpProp.LegendProperties.Informations;
            GraphProperties.LegendProperties.LegendFont = new GW_Font(TmpProp.LegendProperties.LegendFont.oFont.Name,
                                                                        TmpProp.LegendProperties.LegendFont.oFont.Size, 
                                                                        TmpProp.LegendProperties.LegendFont.oFont.Bold, 
                                                                        TmpProp.LegendProperties.LegendFont.oFont.Italic,
                                                                        true, 
                                                                        TmpProp.LegendProperties.LegendFont.oFont.Strikeout,
                                                                        TmpProp.LegendProperties.LegendFont.oFont.Underline);
            

            GraphProperties.Grid.MainHorizontalGrid.Visible = TmpProp.Grid.MainHorizontalGrid.Visible;
            
            if (TmpProp.Grid.MainHorizontalGrid.Visible)
            {
            	GraphProperties.Grid.MainHorizontalGrid.LineColor = TmpProp.Grid.MainHorizontalGrid.LineColor;
            	GraphProperties.Grid.MainHorizontalGrid.LineStyle = TmpProp.Grid.MainHorizontalGrid.LineStyle;
            	GraphProperties.Grid.MainHorizontalGrid.LineWidth = TmpProp.Grid.MainHorizontalGrid.LineWidth;
            }

            GraphProperties.Grid.MainVerticalGrid.Visible = TmpProp.Grid.MainVerticalGrid.Visible;
            
            if (TmpProp.Grid.MainVerticalGrid.Visible)
            {
            	GraphProperties.Grid.MainVerticalGrid.LineColor = TmpProp.Grid.MainVerticalGrid.LineColor;
            	GraphProperties.Grid.MainVerticalGrid.LineStyle = TmpProp.Grid.MainVerticalGrid.LineStyle;
           		GraphProperties.Grid.MainVerticalGrid.LineWidth = TmpProp.Grid.MainVerticalGrid.LineWidth;
            }

            GraphProperties.Grid.SecondaryHorizontalGrid.Visible = TmpProp.Grid.SecondaryHorizontalGrid.Visible;
            
            if (TmpProp.Grid.SecondaryHorizontalGrid.Visible)
            {
            	GraphProperties.Grid.SecondaryHorizontalGrid.LineColor = TmpProp.Grid.SecondaryHorizontalGrid.LineColor;
            	GraphProperties.Grid.SecondaryHorizontalGrid.LineStyle = TmpProp.Grid.SecondaryHorizontalGrid.LineStyle;
            	GraphProperties.Grid.SecondaryHorizontalGrid.LineWidth = TmpProp.Grid.SecondaryHorizontalGrid.LineWidth;
            }

            GraphProperties.Grid.SecondaryVerticalGrid.Visible = TmpProp.Grid.SecondaryVerticalGrid.Visible;
            
            if (TmpProp.Grid.SecondaryVerticalGrid.Visible)
            {
            	GraphProperties.Grid.SecondaryVerticalGrid.LineColor = TmpProp.Grid.SecondaryVerticalGrid.LineColor;
            	GraphProperties.Grid.SecondaryVerticalGrid.LineStyle = TmpProp.Grid.SecondaryVerticalGrid.LineStyle;
            	GraphProperties.Grid.SecondaryVerticalGrid.LineWidth = TmpProp.Grid.SecondaryVerticalGrid.LineWidth;
            }

            GraphProperties.AbscisseAxis.Visible = TmpProp.AbscisseAxis.Visible;

            GraphProperties.AbscisseAxis.TimeMode = TmpProp.AbscisseAxis.TimeMode;
            GraphProperties.AbscisseAxis.AbscisseChannelName = TmpProp.AbscisseAxis.AbscisseChannelName;
            
            if (TmpProp.AbscisseAxis.Visible)
            {
            	GraphProperties.AbscisseAxis.AxisLineStyle.LineColor = TmpProp.AbscisseAxis.AxisLineStyle.LineColor;
            	GraphProperties.AbscisseAxis.AxisLineStyle.LineStyle = TmpProp.AbscisseAxis.AxisLineStyle.LineStyle;
            	GraphProperties.AbscisseAxis.AxisLineStyle.LineWidth = TmpProp.AbscisseAxis.AxisLineStyle.LineWidth;
            	GraphProperties.AbscisseAxis.AxisLineStyle.Visible = TmpProp.AbscisseAxis.AxisLineStyle.Visible;
            }
            
            GraphProperties.AbscisseAxis.AxisValuesVisible = TmpProp.AbscisseAxis.AxisValuesVisible;
            
            GraphProperties.AbscisseAxis.AxisValuesFont = new GW_Font(TmpProp.AbscisseAxis.AxisValuesFont.oFont.Name,
                                                                        TmpProp.AbscisseAxis.AxisValuesFont.oFont.Size,
                                                                        TmpProp.AbscisseAxis.AxisValuesFont.oFont.Bold,
                                                                        TmpProp.AbscisseAxis.AxisValuesFont.oFont.Italic,
                                                                        true,
                                                                        TmpProp.AbscisseAxis.AxisValuesFont.oFont.Strikeout,
                                                                        TmpProp.AbscisseAxis.AxisValuesFont.oFont.Underline);

            GraphProperties.AbscisseAxis.ReferenceLines = new List<GraphReferenceLine>();
            foreach (GraphReferenceLine oLine in TmpProp.AbscisseAxis.ReferenceLines)
            {
                GraphProperties.AbscisseAxis.ReferenceLines.Add(oLine.Get_Clone());
            }
            
            //Cursors
            GraphProperties.Cursor.Mode =  TmpProp.Cursor.Mode;
            
            if (!(TmpProp.Cursor.Mode.Equals(GraphicCursorMode.None)))
            {
            	GraphProperties.Cursor.Style.LineColor = TmpProp.Cursor.Style.LineColor;
            	GraphProperties.Cursor.Style.LineStyle = TmpProp.Cursor.Style.LineStyle;
            	GraphProperties.Cursor.Style.LineWidth = TmpProp.Cursor.Style.LineWidth;
            	
            	GraphProperties.Cursor.CursorSize = TmpProp.Cursor.CursorSize;
            	
            	GraphProperties.Cursor.ShowCursorAbscisseValue = TmpProp.Cursor.ShowCursorAbscisseValue;
            	GraphProperties.Cursor.AbscisseValuePostion = TmpProp.Cursor.AbscisseValuePostion;
            	
            	GraphProperties.Cursor.ShowCursorOrdinatesValue = TmpProp.Cursor.ShowCursorOrdinatesValue;
            	GraphProperties.Cursor.OrdinateValuesPosition = TmpProp.Cursor.OrdinateValuesPosition;
            	
            	GraphProperties.Cursor.CursorValueFont = TmpProp.Cursor.CursorValueFont.Get_Clone();
                GraphProperties.Cursor.CursorValueForeColor = TmpProp.Cursor.CursorValueForeColor;

                GraphProperties.Cursor.CursorTitle = TmpProp.Cursor.CursorTitle;
                GraphProperties.Cursor.CursorTitleFont = TmpProp.Cursor.CursorTitleFont.Get_Clone();
                GraphProperties.Cursor.CursorTitleForeColor = TmpProp.Cursor.CursorTitleForeColor;
                GraphProperties.Cursor.CursorTitlePosition = TmpProp.Cursor.CursorTitlePosition;
            }
            
            //Reference cursor
            GraphProperties.ReferenceCursor.Mode =  TmpProp.ReferenceCursor.Mode;
            
            if (!(TmpProp.ReferenceCursor.Mode.Equals(GraphicCursorMode.None)))
            {
            	GraphProperties.ReferenceCursor.Style.LineColor = TmpProp.ReferenceCursor.Style.LineColor;
            	GraphProperties.ReferenceCursor.Style.LineStyle = TmpProp.ReferenceCursor.Style.LineStyle;
            	GraphProperties.ReferenceCursor.Style.LineWidth = TmpProp.ReferenceCursor.Style.LineWidth;
            	
            	GraphProperties.ReferenceCursor.CursorSize = TmpProp.ReferenceCursor.CursorSize;
            	
            	GraphProperties.ReferenceCursor.ShowCursorAbscisseValue = TmpProp.ReferenceCursor.ShowCursorAbscisseValue;
            	GraphProperties.ReferenceCursor.AbscisseValuePostion = TmpProp.ReferenceCursor.AbscisseValuePostion;
            	
            	GraphProperties.ReferenceCursor.ShowCursorOrdinatesValue = TmpProp.ReferenceCursor.ShowCursorOrdinatesValue;
            	GraphProperties.ReferenceCursor.OrdinateValuesPosition = TmpProp.ReferenceCursor.OrdinateValuesPosition;
            	
            	GraphProperties.ReferenceCursor.CursorValueFont = TmpProp.ReferenceCursor.CursorValueFont.Get_Clone();
            }
            
            //Series
            GraphProperties.GraphLayoutMode = TmpProp.GraphLayoutMode;
            GraphProperties.bAllowOverScaling = TmpProp.bAllowOverScaling;

            //All single series properties are set run time

            //Don't forget to add the possible new members in the 'Set_BackupProperties' methode as well

            GraphProperties.bModified = true;

            bModificationsConfirmed = true;
            return (true);
        }

        private void Set_BackupProperties()
        {
            GraphProperties.WindowBackColor = GraphPropertiesBackUp.WindowBackColor;

            GraphProperties.bSubSamplingEnabled = GraphPropertiesBackUp.bSubSamplingEnabled;
            GraphProperties.nGraphicSampleMax = GraphPropertiesBackUp.nGraphicSampleMax;

            GraphProperties.Frame.BorderColor = GraphPropertiesBackUp.Frame.BorderColor;
            GraphProperties.Frame.BorderWidth = GraphPropertiesBackUp.Frame.BorderWidth;

            GraphProperties.LegendProperties.Visible = GraphPropertiesBackUp.LegendProperties.Visible;
            GraphProperties.LegendProperties.Informations = GraphPropertiesBackUp.LegendProperties.Informations;
            GraphProperties.LegendProperties.LegendFont = GraphPropertiesBackUp.LegendProperties.LegendFont.Get_Clone();
            GraphProperties.LegendProperties.LegendHeaderVisible = GraphPropertiesBackUp.LegendProperties.LegendHeaderVisible;
            GraphProperties.LegendProperties.LegendGridLinesVisible = GraphPropertiesBackUp.LegendProperties.LegendGridLinesVisible;

            GraphProperties.Grid.MainHorizontalGrid.LineColor = GraphPropertiesBackUp.Grid.MainHorizontalGrid.LineColor;
            GraphProperties.Grid.MainHorizontalGrid.LineStyle = GraphPropertiesBackUp.Grid.MainHorizontalGrid.LineStyle;
            GraphProperties.Grid.MainHorizontalGrid.LineWidth = GraphPropertiesBackUp.Grid.MainHorizontalGrid.LineWidth;
            GraphProperties.Grid.MainHorizontalGrid.Visible = GraphPropertiesBackUp.Grid.MainHorizontalGrid.Visible;

            GraphProperties.Grid.MainVerticalGrid.LineColor = GraphPropertiesBackUp.Grid.MainVerticalGrid.LineColor;
            GraphProperties.Grid.MainVerticalGrid.LineStyle = GraphPropertiesBackUp.Grid.MainVerticalGrid.LineStyle;
            GraphProperties.Grid.MainVerticalGrid.LineWidth = GraphPropertiesBackUp.Grid.MainVerticalGrid.LineWidth;
            GraphProperties.Grid.MainVerticalGrid.Visible = GraphPropertiesBackUp.Grid.MainVerticalGrid.Visible;

            GraphProperties.Grid.SecondaryHorizontalGrid.LineColor = GraphPropertiesBackUp.Grid.SecondaryHorizontalGrid.LineColor;
            GraphProperties.Grid.SecondaryHorizontalGrid.LineStyle = GraphPropertiesBackUp.Grid.SecondaryHorizontalGrid.LineStyle;
            GraphProperties.Grid.SecondaryHorizontalGrid.LineWidth = GraphPropertiesBackUp.Grid.SecondaryHorizontalGrid.LineWidth;
            GraphProperties.Grid.SecondaryHorizontalGrid.Visible = GraphPropertiesBackUp.Grid.SecondaryHorizontalGrid.Visible;

            GraphProperties.Grid.SecondaryVerticalGrid.LineColor = GraphPropertiesBackUp.Grid.SecondaryVerticalGrid.LineColor;
            GraphProperties.Grid.SecondaryVerticalGrid.LineStyle = GraphPropertiesBackUp.Grid.SecondaryVerticalGrid.LineStyle;
            GraphProperties.Grid.SecondaryVerticalGrid.LineWidth = GraphPropertiesBackUp.Grid.SecondaryVerticalGrid.LineWidth;
            GraphProperties.Grid.SecondaryVerticalGrid.Visible = GraphPropertiesBackUp.Grid.SecondaryVerticalGrid.Visible;

            GraphProperties.AbscisseAxis.Visible = GraphPropertiesBackUp.AbscisseAxis.Visible;
            GraphProperties.AbscisseAxis.AbscisseChannelName = GraphPropertiesBackUp.AbscisseAxis.AbscisseChannelName;
            GraphProperties.AbscisseAxis.AxisLineStyle = GraphPropertiesBackUp.AbscisseAxis.AxisLineStyle.Get_Clone();
            GraphProperties.AbscisseAxis.AxisValuesFont = GraphPropertiesBackUp.AbscisseAxis.AxisValuesFont.Get_Clone();
            GraphProperties.AbscisseAxis.AxisValuesVisible = GraphPropertiesBackUp.AbscisseAxis.AxisValuesVisible;
            GraphProperties.AbscisseAxis.TimeMode = GraphPropertiesBackUp.AbscisseAxis.TimeMode;

            GraphProperties.AbscisseAxis.ReferenceLines = new List<GraphReferenceLine>();
            foreach (GraphReferenceLine oLine in GraphPropertiesBackUp.AbscisseAxis.ReferenceLines)
            {
                GraphProperties.AbscisseAxis.ReferenceLines.Add(oLine.Get_Clone());
            }
            
            //Cursor
            GraphProperties.Cursor.Mode =  GraphPropertiesBackUp.Cursor.Mode;
        	GraphProperties.Cursor.Style.LineColor = GraphPropertiesBackUp.Cursor.Style.LineColor;
        	GraphProperties.Cursor.Style.LineStyle = GraphPropertiesBackUp.Cursor.Style.LineStyle;
        	GraphProperties.Cursor.Style.LineWidth = GraphPropertiesBackUp.Cursor.Style.LineWidth;
        	GraphProperties.Cursor.CursorSize = GraphPropertiesBackUp.Cursor.CursorSize;
        	GraphProperties.Cursor.ShowCursorAbscisseValue = GraphPropertiesBackUp.Cursor.ShowCursorAbscisseValue;
        	GraphProperties.Cursor.AbscisseValuePostion = GraphPropertiesBackUp.Cursor.AbscisseValuePostion;
        	GraphProperties.Cursor.ShowCursorOrdinatesValue = GraphPropertiesBackUp.Cursor.ShowCursorOrdinatesValue;
        	GraphProperties.Cursor.OrdinateValuesPosition = GraphPropertiesBackUp.Cursor.OrdinateValuesPosition;
        	GraphProperties.Cursor.CursorValueFont = GraphPropertiesBackUp.Cursor.CursorValueFont.Get_Clone();
            
            
            //Reference cursor
            GraphProperties.ReferenceCursor.Mode =  GraphPropertiesBackUp.ReferenceCursor.Mode;
        	GraphProperties.ReferenceCursor.Style.LineColor = GraphPropertiesBackUp.ReferenceCursor.Style.LineColor;
        	GraphProperties.ReferenceCursor.Style.LineStyle = GraphPropertiesBackUp.ReferenceCursor.Style.LineStyle;
        	GraphProperties.ReferenceCursor.Style.LineWidth = GraphPropertiesBackUp.ReferenceCursor.Style.LineWidth;
        	GraphProperties.ReferenceCursor.CursorSize = GraphPropertiesBackUp.ReferenceCursor.CursorSize;
        	GraphProperties.ReferenceCursor.ShowCursorAbscisseValue = GraphPropertiesBackUp.ReferenceCursor.ShowCursorAbscisseValue;
        	GraphProperties.ReferenceCursor.AbscisseValuePostion = GraphPropertiesBackUp.ReferenceCursor.AbscisseValuePostion;
        	GraphProperties.ReferenceCursor.ShowCursorOrdinatesValue = GraphPropertiesBackUp.ReferenceCursor.ShowCursorOrdinatesValue;
        	GraphProperties.ReferenceCursor.OrdinateValuesPosition = GraphPropertiesBackUp.ReferenceCursor.OrdinateValuesPosition;
        	GraphProperties.ReferenceCursor.CursorValueFont = GraphPropertiesBackUp.ReferenceCursor.CursorValueFont.Get_Clone();
            
        	//Series
            GraphProperties.GraphLayoutMode = GraphPropertiesBackUp.GraphLayoutMode;
            GraphProperties.bAllowOverScaling = GraphPropertiesBackUp.bAllowOverScaling;

            GraphProperties.SeriesProperties = new List<GraphSerieProperties>();

            foreach(GraphSerieProperties oSerie in GraphPropertiesBackUp.SeriesProperties)
            {
                GraphProperties.SeriesProperties.Add(oSerie.Get_Clone());
            }


            GraphProperties.bModified = true;
        }

        private void New_PropertiesConfiguration()
        {
            if (GraphProperties.bModified)
            {
                DialogResult Rep = MessageBox.Show("The current configuration has been modified." + 
                                "\nDo you want save this configuation before creating a new one ?",
                                "Graphic window", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);

                switch (Rep)
                {
                    case DialogResult.Yes:

                        Save_PropertiesConfiguration();
                        break;

                    case DialogResult.Cancel:

                        return;
                }
            }

            //GraphProperties = new GraphWindowProperties();
            Ctrl_Parent.Reset_Properties(this);
            Show_Properties();
        }

        private void Load_PropertiesConfiguration()
        {
            if (GraphProperties.bModified)
            {
                DialogResult Rep = MessageBox.Show("The current configuration has been modified." +
                                "\nDo you want save this configuation before opening a new one ?",
                                "Graphic window", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);

                switch (Rep)
                {
                    case DialogResult.Yes:

                        Save_PropertiesConfiguration();
                        break;

                    case DialogResult.Cancel:

                        return;
                }
            }

            if (Dlg_Open.ShowDialog().Equals(DialogResult.OK))
            {
                if (GraphProperties.Open_Properties(Dlg_Open.FileName))
                {
                    Show_Properties();
                }
                else
                {
                    MessageBox.Show("Graphic window properties file reading error !", 
                                "Graphic window", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);

                    GraphProperties = new GraphWindowProperties();
                    Show_Properties();

                }
            }
        }

        private void Save_PropertiesConfiguration()
        {
            if (GraphProperties.FilePath.Equals(""))
            {
                if (Dlg_Save.ShowDialog().Equals(DialogResult.OK))
                {
                    GraphProperties.FilePath = Dlg_Save.FileName;
                }
            }

            if (!(GraphProperties.FilePath.Equals("")))
            {
                GraphProperties.Save_Properties(GraphProperties.FilePath);
            }
        }

        #endregion

        #region Grid_SeriesProperties

        private void Resize_GridColumns()
        {
            if (Grid_SeriesProperties.Rows.Count > 0)
            {
                Grid_SeriesProperties.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            else
            {
                Grid_SeriesProperties.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
            }
        }

        private void Add_Channel(string ChanName)
        {
           GraphProperties.Create_Serie(ChanName);
        }

        private void Create_NewSerie()
        {
            Add_Channel("");
            Show_SeriesProperties();
        }

        private void Delete_SelectedSeries()
        {
            foreach(DataGridViewRow oRow in Grid_SeriesProperties.SelectedRows)
            {
                GraphProperties.Remove_SerieAtKey((int)oRow.Tag);
            }

            Show_SeriesProperties();
        }

        private void Copy_SelectedSeries()
        {
            if (!(Grid_SeriesProperties.SelectedRows == null))
            {
                SerieClipBoard = new List<GraphSerieProperties>();

                foreach (DataGridViewRow oRow in Grid_SeriesProperties.SelectedRows)
                {
                    SerieClipBoard.Add(GraphProperties.Clone_Serie((int)oRow.Tag));
                }
            }
        }

        private void Paste_Series()
        {
            if(!(SerieClipBoard==null))
            {
                foreach (GraphSerieProperties CB_Serie in SerieClipBoard)
                {
                    if (!(CB_Serie == null))
                    {
                        GraphProperties.SeriesProperties.Add(CB_Serie);
                        GraphProperties.SeriesProperties[GraphProperties.SeriesProperties.Count - 1].KeyId = GraphProperties.Get_NextSerieKeyId();
                        GraphProperties.Increase_NextSerieKeyId();
                    }
                }

                Show_SeriesProperties();
                SerieClipBoard = null;
            }
        }

        private void Move_SelectedSeries(string Direction)
        {
            if (!(Grid_SeriesProperties.SelectedRows == null))
            {
                foreach (DataGridViewRow oRow in Grid_SeriesProperties.SelectedRows)
                {
                    GraphProperties.Move_Serie((int)oRow.Tag, Direction);
                }

                Show_SeriesProperties();
            }
        }

        private void Show_SeriesProperties()
        {
            Grid_SeriesProperties.SuspendLayout();
            bGridSerieEdition = true;

            Grid_SeriesProperties.Rows.Clear();

            foreach (GraphSerieProperties oSerie in GraphProperties.SeriesProperties)
            {
                Grid_SeriesProperties.Rows.Add();
                DataGridViewRow oSerieRow = Grid_SeriesProperties.Rows[Grid_SeriesProperties.Rows.Count - 1];

                oSerieRow.Tag = oSerie.KeyId;
				
                oSerieRow.Cells[SerieNameColId].Value = oSerie.Name;
                oSerieRow.Cells[SerieLabelColId].Value = oSerie.Label;
                oSerieRow.Cells[SerieUnitColId].Value = oSerie.Unit;
                oSerieRow.Cells[SerieColorColId].Style.BackColor = oSerie.Trace.LineColor;
                                
                DataGridViewCheckBoxCell oVisibleCell = oSerieRow.Cells[SerieVisibleColId] as DataGridViewCheckBoxCell;
                oVisibleCell.Value = oSerie.Visible;

                if(oSerie.ValueFormat.HasDefaultProperties())
                {
                    oSerieRow.Cells[SerieFormatColId].Value = "Auto";
                }
                else
                {
                    oSerieRow.Cells[SerieFormatColId].Value = "Custom";
                }

                if (GraphProperties.GraphLayoutMode.Equals(GraphicWindowLayoutModes.Custom))
                {
                    oSerieRow.Cells[SerieTopColId].Value = oSerie.Top.ToString();
                    oSerieRow.Cells[SerieBottomColId].Value = oSerie.Bottom.ToString();
                }
                else
                {
                    oSerieRow.Cells[SerieTopColId].Value = "-";
                    oSerieRow.Cells[SerieTopColId].ReadOnly = true;

                    oSerieRow.Cells[SerieBottomColId].Value = "-";
                    oSerieRow.Cells[SerieBottomColId].ReadOnly = true;
                }

                DataGridViewComboBoxCell oScaleCell = oSerieRow.Cells[SerieScaleColId] as DataGridViewComboBoxCell;
                
                oScaleCell.Items.Clear();
                oScaleCell.Items.Add(GraphSerieScaleModes.Auto.ToString());
                oScaleCell.Items.Add(GraphSerieScaleModes.Custom.ToString());

                if(oSerie.ScalingMode.Equals(GraphSerieScaleModes.Custom))
                {
                    oScaleCell.Value = GraphSerieScaleModes.Custom.ToString();

                    oSerieRow.Cells[SerieMinColId].Value = oSerie.Min.ToString();
                    oSerieRow.Cells[SerieMaxColId].Value = oSerie.Max.ToString();
                }
                else
                {
                    oScaleCell.Value = GraphSerieScaleModes.Auto.ToString();

                    oSerieRow.Cells[SerieMinColId].Value = "-";
                    oSerieRow.Cells[SerieMinColId].ReadOnly = true;

                    oSerieRow.Cells[SerieMaxColId].Value = "-";
                    oSerieRow.Cells[SerieMaxColId].ReadOnly = true;
                }

                if(oSerie.YAxis.HasDefaultProperties())
                {
                    oSerieRow.Cells[SerieYAxisColId].Value = "Auto";
                }
                else
                {
                    oSerieRow.Cells[SerieYAxisColId].Value = "Custom";
                }

                if (oSerie.UserGrid.HasDefaultProperties())
                {
                    oSerieRow.Cells[SerieGridColId].Value = "Auto";
                }
                else
                {
                    oSerieRow.Cells[SerieGridColId].Value = "Custom";
                }

                if(oSerie.ReferenceLines.Count == 0)
                {
                    oSerieRow.Cells[SerieRefLineColId].Value = "None";
                }
                else
                {
                    oSerieRow.Cells[SerieRefLineColId].Value = "Custom";
                }

                DataGridViewButtonCell oDetailCmdCell = oSerieRow.Cells[SerieDetailsColId] as DataGridViewButtonCell;
                oDetailCmdCell.Value = "...";
            }

            foreach(DataGridViewRow oRow in Grid_SeriesProperties.Rows)
            {
                for(int i=1;i<oRow.Cells.Count;i++)
                {
                    oRow.Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            Grid_SeriesProperties.ResumeLayout(true);
            bGridSerieEdition = false;
        }

        private void Set_SerieColor(int RowIndex)
        {
            if(Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Grid_SeriesProperties.Rows[RowIndex].Cells[SerieColorColId].Style.BackColor = Dlg_Color.Color;

                GraphSerieProperties oSerie = GraphProperties.Get_SerieAtKey((int)Grid_SeriesProperties.Rows[RowIndex].Tag);

                if (!(oSerie == null))
                {
                    oSerie.Trace.LineColor = Dlg_Color.Color;
                    oSerie.Markers.MarkColor = Dlg_Color.Color;
                    oSerie.YAxis.AxisLineStyle.LineColor = Dlg_Color.Color;
                    oSerie.UserGrid.HorizontalLinesStyle.LineColor = Dlg_Color.Color;
                    oSerie.UserGrid.VerticalLinesStyle.LineColor = Dlg_Color.Color;
                }
            }
        }

        private void Show_SerieDetailedProperties(int iKey, string Page)
        {
            GraphSerieProperties oSerie = GraphProperties.Get_SerieAtKey(iKey);

            if(!(oSerie==null))
            {
                Frm_GraphSerieDetailedProperties Frm = new Frm_GraphSerieDetailedProperties(oSerie, (object)this, Page);
                Frm.Show();
            }
        }

        private void Show_ContextualChannelList(int CellRowIndex, TextBox ctrlEditxt)
        {
        	DataGridViewCell oGridCell = Grid_SeriesProperties.Rows[CellRowIndex].Cells[SerieNameColId];
        	
        	oContextChanList = new Ctrl_GW_ContextualChannelList();
        	oContextChanList.Visible = false;
        	
        	Grid_SeriesProperties.Controls.Add(oContextChanList);
        	
        	Rectangle sCellPos = Grid_SeriesProperties.GetCellDisplayRectangle(SerieNameColId, CellRowIndex, true);
        	
        	oContextChanList.Name = "ContextChannelList";
        	oContextChanList.Tag = (object) ctrlEditxt;
        	oContextChanList.MultiSelect = false;
        	oContextChanList.View = View.Details;
        	oContextChanList.SmallImageList = Img_ContextChanList;
        	oContextChanList.Columns.Add("Channels", sCellPos.Width);
        	oContextChanList.HeaderStyle = ColumnHeaderStyle.None;
        	oContextChanList.Sorting = SortOrder.Ascending;
        	
        	oContextChanList.MouseDoubleClick += new MouseEventHandler(Grid_SeriesPropertiesContextChanList_MouseDoubleClick);
        	
        	oContextChanList.Items.Clear();
        	
        	foreach (string sChan in ChannelList)
        	{
        		oContextChanList.AddChannel(sChan);
        	}
        	
        	oContextChanList.ShowChannels();
        	oContextChanList.Sort();
        	
        	oContextChanList.Left = sCellPos.Left;
        	oContextChanList.Top = sCellPos.Bottom;
        	oContextChanList.Width = Math.Max(sCellPos.Width, oContextChanList.MaxStringWidth + 40); //40 = Icon width + margin + vertical scrollbar;
        	oContextChanList.Height = Math.Min(Grid_SeriesProperties.Height - sCellPos.Bottom -20, oContextChanList.Items.Count * 18);      	
        	oContextChanList.Visible = true;
        }
        
        private void Set_ContextualChannelListSelection(Ctrl_GW_ContextualChannelList oContextChanList)
        {
        	if (!(oContextChanList.SelectedItems.Count == 0))
        	{
        		//DataGridViewCell oTgtCell = (DataGridViewCell) oContextChanList.Tag;
        		//oTgtCell.Value = oContextChanList.SelectedItems[0].Text;
        		
        		TextBox oTgtTxt = (TextBox) oContextChanList.Tag;
        		oTgtTxt.Text = oContextChanList.SelectedItems[0].Text;
        		
        		Close_ContextualChannelList();
        		Grid_SeriesProperties.EndEdit();
        	}
        }
        
        private void Close_ContextualChannelList()
        {
        	Grid_SeriesProperties.Controls.Remove(oContextChanList);
        	oContextChanList = null;
        	
        	/*
        	foreach (Control Ctrl in Grid_SeriesProperties.Controls)
        	{
        		if (Ctrl.Name.Equals("ContextChannelList"))
        		{
        			Grid_SeriesProperties.Controls.Remove(Ctrl);
        			return;
        		}
        	}
        	*/
        }
        
        #endregion

        #region Misc

        private void ShowChannelList()
        {
            if (!(FlyingChannelList.Visible)) //Channel list showing
            {
                if(this.WindowState.Equals(FormWindowState.Maximized))
                {
                    this.WindowState = FormWindowState.Normal;
                }

                FlyingChannelList.Height = this.Height;
                FlyingChannelList.Top = this.Top;
                
                if(this.Left > FlyingChannelList.Width) //Show channel list on the left side of the form
                {
                    FlyingChannelList.Left = this.Left - FlyingChannelList.Width - 10;
                }
                else //Show channel list on the right side of the form OR resize and move the form and show the list on the left
                {
                    Rectangle ScreenSize = Screen.PrimaryScreen.Bounds;

                    if (this.Left + this.Width + FlyingChannelList.Width + 10 < ScreenSize.Width) //Show channel list on the right side of the form
                    {
                        FlyingChannelList.Left = this.Left + this.Width + 10;
                    }
                    else //Resize and move the form and show the list on the left
                    {
                        this.Width = ScreenSize.Width - FlyingChannelList.Width - 20;
                        this.Left = FlyingChannelList.Width + 10;
                        FlyingChannelList.Left = this.Left - FlyingChannelList.Width - 10;
                    }
                }

                FlyingChannelList.Show();
            }
            else //Channel list hiding
            {
                FlyingChannelList.Hide();
            }
        }
		
        private void ShowLegendInformations(GraphicLegendInformations eLegInfo)
        {
            ChkLst_LegendInformations.Items.Clear();

            Array Infos = Enum.GetValues(typeof(GraphicLegendInformations));

            for (int i = 0; i < Infos.Length; i++)
            {
                string Name = Infos.GetValue(i).ToString();
                bool bChecked = eLegInfo.HasFlag((GraphicLegendInformations)Infos.GetValue(i));
                ChkLst_LegendInformations.Items.Add(Name, bChecked);
            }
        }

        private GraphicLegendInformations GetLegendInformation()
        {
            GraphicLegendInformations eLegInfo = 0;

            for (int i = 0; i < ChkLst_LegendInformations.CheckedItems.Count; i++)
            {
                GraphicLegendInformations eSingleInfo = (GraphicLegendInformations)Enum.Parse(typeof(GraphicLegendInformations), ChkLst_LegendInformations.CheckedItems[i].ToString());
                eLegInfo |= eSingleInfo;
            }

            return (eLegInfo);
        }

        #endregion

        #endregion

        #region Public methodes

        /// <summary>
        /// Add a graphic serie for each item of the list given as argument
        /// </summary>
        /// <param name="Items">List of graphic serie to create</param>
        public void Add_SerieItems(string[] Items)
        {
            if (!(Items == null))
            {
                foreach (string Name in Items)
                {
                    Add_Channel(Name);
                }

                Show_SeriesProperties();
            }
        }

        /// <summary>
        /// Update the Grid_SeriesProperties after a single serie edition
        /// </summary>
        /// <remarks>Set the bModified flag of GraphWindowProperties to true</remarks>
        public void UpDate_SeriesGrid()
        {
            Show_SeriesProperties();
            GraphProperties.bModified = true;
        }

        /// <summary>
        /// Update the GraphWindowProperties of the current object
        /// </summary>
        /// <param name="NewProps">New GraphWindowProperties to use</param>
        public void UpDate_Properties(GraphWindowProperties NewProps)
        {
            GraphProperties = NewProps;
        }

        #endregion
    }
}
