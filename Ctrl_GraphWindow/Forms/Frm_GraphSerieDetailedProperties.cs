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
    /// Graphic serie detailed properties form
    /// </summary>
    public partial class Frm_GraphSerieDetailedProperties : Form
    {
        #region Private constants

        private const string FORM_TITLE = "Serie properties";

        private const int REF_LINE_MODE_COL        = 0;
        private const int REF_LINE_VALUE_COL       = 1;
        private const int REF_LINE_VISIBLE_COL     = 2;
        private const int REF_LINE_STYLE_COL       = 3;
        private const int REF_LINE_COLOR_COL       = 4;
        private const int REF_LINE_WIDTH_COL       = 5;
        private const int REF_LINE_VAL_VISIBLE_COL = 6;
        private const int REF_LINE_FONT            = 7;

        #endregion

        #region Private enums

        private enum GridPropertiesTarget
        {
            HorizontalGrid = 0,
            VerticalGrid = 1,
        }

        private enum ReferenceLineMovingDirection
        {
            Up = 0,
            Down = 1,
        }

        #endregion

        #region Private members

        private GraphSerieProperties oTmpProps;

        private  GraphSerieProperties oSerieProperties;
        private  object FrmCaller;

        private Font oAxisFont;
        private Font oHorzGridFont;
        private Font oVertGridFont;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public Frm_GraphSerieDetailedProperties(GraphSerieProperties oSerie, object Caller, string StartPage)
        {
            InitializeComponent();

            oSerieProperties = oSerie;
            FrmCaller = Caller;
            oAxisFont = null;
            oTmpProps = null;

            this.Text = "Serie " + oSerie.Name + " detailed properties";
            Ctrl_RefLines.FORM_TITLE = FORM_TITLE;
            Ctrl_RefLines.DefaultLineColor = oSerieProperties.Trace.LineColor;
            Ctrl_RefLines.ReferenceLines = oSerieProperties.ReferenceLines;

            Fill_Lists();
            Show_Properties();

            if(!(StartPage.Equals("")))
            {
                if (StartPage.Equals("General"))
                {
                    tabControl1.SelectedIndex = 0;
                }
                else if (StartPage.Equals("Format"))
                {
                    tabControl1.SelectedIndex = 1;
                }
                else if (StartPage.Equals("YAxis"))
                {
                    tabControl1.SelectedIndex = 2;
                }
                else if (StartPage.Equals("Grid"))
                {
                    tabControl1.SelectedIndex = 3;
                }
                else if (StartPage.Equals("RefLines"))
                {
                    tabControl1.SelectedIndex = 4;
                }
                else
                {
                    tabControl1.SelectedIndex = 0;
                }
            }
        }

        #region Control events

        #region TS_Main

        private void TSB_Apply_Click(object sender, EventArgs e)
        {
            if(Set_Properties())
            {
                if(FrmCaller.GetType().Equals(typeof(Frm_GraphPropertiesEdtion)))
                {
                    ((Frm_GraphPropertiesEdtion)FrmCaller).UpDate_SeriesGrid();
                }
                else if(FrmCaller.GetType().Equals(typeof(Ctrl_WaveForm)))
                {
                	((Ctrl_WaveForm)FrmCaller).Refresh_Graphic();
                }

                this.Close();
            }
        }

        private void TSB_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region TabPages

        #region Tab General

        private void Chk_SerieVisible_CheckedChanged(object sender, EventArgs e)
        {
            Grp_PosScale.Enabled = Chk_SerieVisible.Checked;
            Grp_Trace.Enabled = Chk_SerieVisible.Checked;
            Grp_Markers.Enabled = Chk_SerieVisible.Checked;

            if (Chk_SerieVisible.Checked)
            {
                if (Chk_TraceVisible.Checked)
                {
                    Pic_TraceColor.BackColor = oSerieProperties.Trace.LineColor;
                }
                else
                {
                    Pic_TraceColor.BackColor = SystemColors.Control;
                }

                if (Chk_MarkerVisible.Checked)
                {
                    Pic_MarkerColor.BackColor = oSerieProperties.Markers.MarkColor;
                }
                else
                {
                    Pic_MarkerColor.BackColor = SystemColors.Control;
                }
            }
            else
            {
                Pic_TraceColor.BackColor = SystemColors.Control;
                Pic_MarkerColor.BackColor = SystemColors.Control;
            }
        }

        private void Chk_TraceVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_TraceStyle.Enabled = Chk_TraceVisible.Checked;
            Cmb_TraceStyle.Enabled = Chk_TraceVisible.Checked;

            Lbl_DrawingMode.Enabled = Chk_TraceVisible.Checked;
            Cmb_DrawingMode.Enabled = Chk_TraceVisible.Checked;

            Lbl_TraceWidth.Enabled = Chk_TraceVisible.Checked;
            Txt_TraceWidth.Enabled = Chk_TraceVisible.Checked;

            Lbl_TraceColor.Enabled = Chk_TraceVisible.Checked;
            Pic_TraceColor.Enabled = Chk_TraceVisible.Checked;

            if(Chk_TraceVisible.Checked)
            {
                Pic_TraceColor.BackColor = oSerieProperties.Trace.LineColor;
            }
            else
            {
                Pic_TraceColor.BackColor = SystemColors.Control;
            }
        }

        private void Chk_MarkerVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_MarkerStyle.Enabled = Chk_MarkerVisible.Checked;
            Cmb_MarkerStyle.Enabled = Chk_MarkerVisible.Checked;

            Lbl_MarkerSize.Enabled = Chk_MarkerVisible.Checked;
            Txt_MarkerSize.Enabled = Chk_MarkerVisible.Checked;

            Lbl_MarkerColor.Enabled = Chk_MarkerVisible.Checked;
            Pic_MarkerColor.Enabled = Chk_MarkerVisible.Checked;

            Chk_MarkInteriorEmpty.Enabled = Chk_MarkerVisible.Checked;

            if(Chk_MarkerVisible.Checked)
            {
                Pic_MarkerColor.BackColor = oSerieProperties.Markers.MarkColor;
            }
            else
            {
                Pic_MarkerColor.BackColor = SystemColors.Control;
            }
        }

        private void Pic_TraceColor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_TraceColor.BackColor = Dlg_Color.Color;
                
                if (Chk_MarkerVisible.Checked) Pic_MarkerColor.BackColor = Dlg_Color.Color;
                if (Chk_AxisVisible.Checked) Pic_AxisColor.BackColor = Dlg_Color.Color;
                if (Chk_GridVisible.Checked && Chk_HorzGridVisible.Checked) Pic_HorzGridLineColor.BackColor = Dlg_Color.Color;
                if (Chk_GridVisible.Checked && Chk_VertGridVisible.Checked) Pic_VertGridLineColor.BackColor = Dlg_Color.Color;
            }
        }

        private void Pic_MarkerBorderColor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_MarkerColor.BackColor = Dlg_Color.Color;
            }
        }

        #endregion

        #region Tab Format

        private void Cmb_Format_SelectedIndexChanged(object sender, EventArgs e)
        {
            GraphSerieLegendFormats eFormat = (GraphSerieLegendFormats)Enum.Parse(typeof(GraphSerieLegendFormats), Cmb_Format.Text);

            switch(eFormat)
            {
                case GraphSerieLegendFormats.Decimal:

                    Lbl_Decimals.Enabled = true;
                    Txt_Decimals.Enabled = true;
                    break;

                case GraphSerieLegendFormats.Enum:

                    Grp_Enum.Enabled = true;
                    break;

                default:

                    Lbl_Decimals.Enabled = false;
                    Txt_Decimals.Enabled = false;
                    Grp_Enum.Enabled = false;
                    break;
            }
        }

        #region TS_Enums

        private void TSB_AddEnum_Click(object sender, EventArgs e)
        {
            Add_Enum();
        }

        private void TSB_DelEnum_Click(object sender, EventArgs e)
        {
            Del_Enum();
        }

        private void TSB_ClearEnum_Click(object sender, EventArgs e)
        {
            Clear_Enums();
        }

        #endregion

        #endregion

        #region Tab Y Axis

        private void Chk_AxisVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_AxisStyle.Enabled=Chk_AxisVisible.Checked;
            Cmb_AxisStyle.Enabled=Chk_AxisVisible.Checked;

            Lbl_AxisWidth.Enabled=Chk_AxisVisible.Checked;
            Txt_AxisWidth.Enabled=Chk_AxisVisible.Checked;

            Lbl_AxisColor.Enabled=Chk_AxisVisible.Checked;
            Pic_AxisColor.Enabled=Chk_AxisVisible.Checked;

            Grp_AxisText.Enabled = Chk_AxisVisible.Checked;

            if(Chk_AxisVisible.Checked)
            {
                Pic_AxisColor.BackColor = oSerieProperties.YAxis.AxisLineStyle.LineColor;
            }
            else
            {
                Pic_AxisColor.BackColor = SystemColors.Control;
            }
        }

        private void Chk_AxisValueVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_AxisFont.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;
            Txt_AxisFont.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;
            Cmd_AxisFont.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;

            Lbl_AxisFontSize.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;
            Txt_AxisFontSize.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;
        }
        
        private void Chk_AxisTitleVisibleCheckedChanged(object sender, EventArgs e)
        {
        	Lbl_AxisFont.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;
            Txt_AxisFont.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;
            Cmd_AxisFont.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;

            Lbl_AxisFontSize.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;
            Txt_AxisFontSize.Enabled = Chk_AxisValueVisible.Checked | Chk_AxisTitleVisible.Checked;
        }

        private void Pic_AxisColor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_AxisColor.BackColor = Dlg_Color.Color;
            }
        }

        private void Cmd_AxisFont_Click(object sender, EventArgs e)
        {
            if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
            {
                oAxisFont = Dlg_Font.Font;

                Txt_AxisFont.Text = oAxisFont.Name;
                Txt_AxisFont.Font = oAxisFont;
                Txt_AxisFontSize.Text = oAxisFont.Size.ToString();
            }
        }

        #endregion

        #region Tab Grid

        private void Chk_GridVisible_CheckedChanged(object sender, EventArgs e)
        {
            Grp_HorzGrid.Enabled = Chk_GridVisible.Checked;
            Grp_VertGrid.Enabled = Chk_GridVisible.Checked;

            if(Chk_GridVisible.Checked)
            {
                if(Chk_HorzGridVisible.Checked)
                {
                    Pic_HorzGridLineColor.BackColor = oSerieProperties.UserGrid.HorizontalLinesStyle.LineColor;
                }
                else
                {
                    Pic_HorzGridLineColor.BackColor = SystemColors.Control;
                }

                if(Chk_VertGridVisible.Checked)
                {
                    Pic_VertGridLineColor.BackColor = oSerieProperties.UserGrid.VerticalLinesStyle.LineColor;
                }
                else
                {
                    Pic_VertGridLineColor.BackColor = SystemColors.Control;
                }
            }
            else
            {
                Pic_HorzGridLineColor.BackColor = SystemColors.Control;
                Pic_VertGridLineColor.BackColor = SystemColors.Control;
            }
        }

        private void Chk_HorzGridVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_HorzGridMode.Enabled = Chk_HorzGridVisible.Checked;
            Cmb_HorzGridMode.Enabled = Chk_HorzGridVisible.Checked;

            Lbl_HorzGridDivisions.Enabled = Chk_HorzGridVisible.Checked;
            Txt_HorzGridDivisions.Enabled = Chk_HorzGridVisible.Checked;

            if (Cmb_HorzGridMode.Text.Equals(GraphSerieUserGridModes.CustomValues.ToString()))
            {
                Grp_HorzGridCustomValues.Enabled = Chk_HorzGridVisible.Checked;
            }
            else
            {
                Grp_HorzGridCustomValues.Enabled = false;
            }

            Chk_HorzGridValuesVisible.Enabled = Chk_HorzGridVisible.Checked;

            if(Chk_HorzGridVisible.Checked)
            {
                Grp_HorzGridFont.Enabled = Chk_HorzGridValuesVisible.Checked;
            }
            else
            {
                Grp_HorzGridFont.Enabled = false;
            }

            Grp_HorzGridStyle.Enabled = Chk_HorzGridVisible.Checked;

            if(Chk_HorzGridVisible.Checked)
            {
                Pic_HorzGridLineColor.BackColor = oSerieProperties.UserGrid.HorizontalLinesStyle.LineColor;
            }
            else
            {
                Pic_HorzGridLineColor.BackColor = SystemColors.Control;
            }
        }

        private void Cmb_HorzGridMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_HorzGridMode.Text.Equals(GraphSerieUserGridModes.CustomValues.ToString()))
            {
                Grp_HorzGridCustomValues.Enabled = Chk_HorzGridVisible.Checked;
            }
            else
            {
                Grp_HorzGridCustomValues.Enabled = false;
            }
        }

        private void Pic_HorzGridLineColor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_HorzGridLineColor.BackColor = Dlg_Color.Color;
            }
        }

        private void Chk_HorzGridValuesVisible_CheckedChanged(object sender, EventArgs e)
        {
            Grp_HorzGridFont.Enabled = Chk_HorzGridValuesVisible.Checked;
        }

        private void Cmd_HorzGridFont_Click(object sender, EventArgs e)
        {
            if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
            {
                oHorzGridFont = Dlg_Font.Font;

                Txt_HorzGridFontName.Text = oHorzGridFont.Name;
                Txt_HorzGridFontName.Font = oHorzGridFont;
                Txt_HorzGridFontSize.Text = oHorzGridFont.Size.ToString();
            }
        }

        private void Chk_VertGridVisible_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_VertGridMode.Enabled = Chk_VertGridVisible.Checked;
            Cmb_VertGridMode.Enabled = Chk_VertGridVisible.Checked;

            Lbl_VertGridDivisions.Enabled = Chk_VertGridVisible.Checked;
            Txt_VertGridDivisions.Enabled = Chk_VertGridVisible.Checked;

            if (Cmb_VertGridMode.Text.Equals(GraphSerieUserGridModes.CustomValues.ToString()))
            {
                Grp_VertGridCustomValues.Enabled = Chk_VertGridVisible.Checked;
            }
            else
            {
                Grp_VertGridCustomValues.Enabled = false;
            }

            Chk_VertGridValuesVisible.Enabled = Chk_VertGridVisible.Checked;

            if(Chk_VertGridVisible.Checked)
            {
                Grp_VertGridFont.Enabled = Chk_VertGridValuesVisible.Checked;
            }
            else
            {
                Grp_VertGridFont.Enabled = false;
            }

            Grp_VertGridStyle.Enabled = Chk_VertGridVisible.Checked;

            if(Chk_VertGridVisible.Checked)
            {
                Pic_VertGridLineColor.BackColor = oSerieProperties.UserGrid.VerticalLinesStyle.LineColor;
            }
            else
            {
                Pic_VertGridLineColor.BackColor = SystemColors.Control;
            }
        }

        private void Cmb_VertGridMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_VertGridMode.Text.Equals(GraphSerieUserGridModes.CustomValues.ToString()))
            {
                Grp_VertGridCustomValues.Enabled = Chk_VertGridVisible.Checked;
            }
            else
            {
                Grp_VertGridCustomValues.Enabled = false;
            }
        }

        private void Pic_VertGridLineColor_DoubleClick(object sender, EventArgs e)
        {
            if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
            {
                Pic_VertGridLineColor.BackColor = Dlg_Color.Color;
            }
        }

        private void Chk_VertGridValuesVisible_CheckedChanged(object sender, EventArgs e)
        {
            Grp_VertGridFont.Enabled = Chk_VertGridValuesVisible.Checked;
        }

        private void Cmd_VertGridFont_Click(object sender, EventArgs e)
        {
            if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
            {
                oVertGridFont = Dlg_Font.Font;

                Txt_VertGridFontName.Text = oVertGridFont.Name;
                Txt_VertGridFontName.Font = oVertGridFont;
                Txt_VertGridFontSize.Text = oVertGridFont.Size.ToString();
            }
        }

        #region TS_HorzGridCustomValues

        private void TSB_HorzGrid_AddValue_Click(object sender, EventArgs e)
        {
            Add_GridCustomValue(GridPropertiesTarget.HorizontalGrid);
        }

        private void TSB_HorzGrid_DelValue_Click(object sender, EventArgs e)
        {
            Del_GridCustomValue(GridPropertiesTarget.HorizontalGrid);
        }

        private void TSB_HorzGrid_ClearValues_Click(object sender, EventArgs e)
        {
            Clear_GridCustomValue(GridPropertiesTarget.HorizontalGrid);
        }

        #endregion

        #region TS_VertGridCustomValues

        private void TSB_VertGrid_AddValue_Click(object sender, EventArgs e)
        {
            Add_GridCustomValue(GridPropertiesTarget.VerticalGrid);
        }

        private void TSB_VertGrid_DelValue_Click(object sender, EventArgs e)
        {
            Del_GridCustomValue(GridPropertiesTarget.VerticalGrid);
        }

        private void TSB_VertGrid_ClearValues_Click(object sender, EventArgs e)
        {
            Clear_GridCustomValue(GridPropertiesTarget.VerticalGrid);
        }

        #endregion

        #endregion

        #region Tab Reference lines

        #endregion

        #endregion

        #endregion

        #region Private methodes

        private void Fill_Lists()
        {
            string[] sLineStyles = Enum.GetNames(typeof(System.Drawing.Drawing2D.DashStyle));
            
            Cmb_TraceStyle.Items.Clear();
            Cmb_TraceStyle.Items.AddRange(sLineStyles);

            Cmb_AxisStyle.Items.Clear();
            Cmb_AxisStyle.Items.AddRange(sLineStyles);

            Cmb_HorzGridLineStyle.Items.Clear();
            Cmb_HorzGridLineStyle.Items.AddRange(sLineStyles);

            Cmb_VertGridLineStyle.Items.Clear();
            Cmb_VertGridLineStyle.Items.AddRange(sLineStyles);

            Cmb_ScaleMode.Items.Clear();
            Cmb_ScaleMode.Items.AddRange(Enum.GetNames(typeof(GraphSerieScaleModes)));

            Cmb_DrawingMode.Items.Clear();
            Cmb_DrawingMode.Items.AddRange(Enum.GetNames(typeof(GraphSerieDrawingModes)));

            Cmb_MarkerStyle.Items.Clear();
            Cmb_MarkerStyle.Items.AddRange(Enum.GetNames(typeof(GraphSerieMarkerStyles)));

            Cmb_Format.Items.Clear();
            Cmb_Format.Items.AddRange(Enum.GetNames(typeof(GraphSerieLegendFormats)));

            Cmb_HorzGridMode.Items.Clear();
            Cmb_HorzGridMode.Items.AddRange(Enum.GetNames(typeof(GraphSerieUserGridModes)));

            string[] VertGridModes = {
                                      GraphSerieUserGridModes.None.ToString(),
                                      GraphSerieUserGridModes.Even.ToString(),
                                      GraphSerieUserGridModes.CustomValues.ToString(),
                                     };

            Cmb_VertGridMode.Items.Clear();
            Cmb_VertGridMode.Items.AddRange(VertGridModes);
        }

        private void Show_Properties()
        {
            #region Tab General

            Txt_ChannelName.Text = oSerieProperties.Name;
            Txt_Label.Text = oSerieProperties.Label;
            Txt_Unit.Text = oSerieProperties.Unit;
            Txt_Description.Text = oSerieProperties.Description;
            Chk_SerieVisible.Checked = oSerieProperties.Visible;

            Txt_Top.Text = oSerieProperties.Top.ToString();
            Txt_Bottom.Text = oSerieProperties.Bottom.ToString();
            Cmb_ScaleMode.SelectedItem = oSerieProperties.ScalingMode.ToString();
            Txt_ScaleMin.Text = oSerieProperties.Min.ToString();
            Txt_ScaleMax.Text = oSerieProperties.Max.ToString();

            Cmb_TraceStyle.SelectedItem = oSerieProperties.Trace.LineStyle.ToString();
            Cmb_DrawingMode.SelectedItem = oSerieProperties.DrawingMode.ToString();
            Txt_TraceWidth.Text = oSerieProperties.Trace.LineWidth.ToString();
            Chk_TraceVisible.Checked = oSerieProperties.Trace.Visible;

            if (oSerieProperties.Trace.Visible && oSerieProperties.Visible)
            {
                Pic_TraceColor.BackColor = oSerieProperties.Trace.LineColor;
            }
            else
            {
                Pic_TraceColor.BackColor = SystemColors.Control;
            }

            Cmb_MarkerStyle.SelectedItem = oSerieProperties.Markers.Style.ToString();
            Chk_MarkerVisible.Checked = oSerieProperties.Markers.Visible;
            Chk_MarkInteriorEmpty.Checked = oSerieProperties.Markers.InteriorEmpty;
            Txt_MarkerSize.Text = oSerieProperties.Markers.Size.ToString();

            if (oSerieProperties.Markers.Visible && oSerieProperties.Visible)
            {
                Pic_MarkerColor.BackColor = oSerieProperties.Markers.MarkColor;
            }
            else
            {
                Pic_MarkerColor.BackColor = SystemColors.Control;
            }

            #endregion

            #region Tab Format

            Cmb_Format.SelectedItem = oSerieProperties.ValueFormat.Format.ToString();
            Txt_Decimals.Text = oSerieProperties.ValueFormat.Decimals.ToString();

            Grid_Enums.Rows.Clear();
            
            foreach(GraphSerieEnumValue sEnum in oSerieProperties.ValueFormat.Enums)
            {
                Grid_Enums.Rows.Add();
                DataGridViewRow oRow = Grid_Enums.Rows[Grid_Enums.Rows.Count - 1];

                oRow.Cells[0].Value = sEnum.Value.ToString();
                oRow.Cells[1].Value = sEnum.Text;
            }

            #endregion

            #region Tab Y Axis

            Cmb_AxisStyle.SelectedItem = oSerieProperties.YAxis.AxisLineStyle.LineStyle.ToString();
            Chk_AxisVisible.Checked = oSerieProperties.YAxis.Visible;
            Txt_AxisWidth.Text = oSerieProperties.YAxis.AxisLineStyle.LineWidth.ToString();
            
            if (oSerieProperties.YAxis.Visible)
            {
            	Pic_AxisColor.BackColor = oSerieProperties.YAxis.AxisLineStyle.LineColor;
            }

            Txt_AxisFont.Text = oSerieProperties.YAxis.AxisValuesFont.oFont.Name;
            Txt_AxisFont.Font = oSerieProperties.YAxis.AxisValuesFont.oFont;
            Txt_AxisFontSize.Text = oSerieProperties.YAxis.AxisValuesFont.oFont.Size.ToString();
            Chk_AxisValueVisible.Checked = oSerieProperties.YAxis.AxisValuesVisible;
            Chk_AxisTitleVisible.Checked = oSerieProperties.YAxis.AxisTitleVisible;

            FontStyle eAxisFontStyle = new FontStyle();

            eAxisFontStyle |= FontStyle.Regular;
            if (oSerieProperties.YAxis.AxisValuesFont.oFont.Bold)      eAxisFontStyle |= FontStyle.Bold;
            if (oSerieProperties.YAxis.AxisValuesFont.oFont.Italic)    eAxisFontStyle |= FontStyle.Italic;
            if (oSerieProperties.YAxis.AxisValuesFont.oFont.Strikeout) eAxisFontStyle |= FontStyle.Strikeout;
            if (oSerieProperties.YAxis.AxisValuesFont.oFont.Underline) eAxisFontStyle |= FontStyle.Underline;

            oAxisFont = new Font(oSerieProperties.YAxis.AxisValuesFont.oFont.Name,
                                    oSerieProperties.YAxis.AxisValuesFont.oFont.Size,
                                    eAxisFontStyle);

            #endregion

            #region Tab Grid

            Chk_GridVisible.Checked = oSerieProperties.UserGrid.Visible;

            Chk_HorzGridVisible.Checked = oSerieProperties.UserGrid.HorizontalLinesStyle.Visible;
            Cmb_HorzGridMode.SelectedItem = oSerieProperties.UserGrid.HorizontalGridMode.ToString();
            Txt_HorzGridDivisions.Text = oSerieProperties.UserGrid.HorizontalDivisionCount.ToString();
            Chk_HorzGridValuesVisible.Checked = oSerieProperties.UserGrid.HorizontalGridValuesVisible;

                Txt_HorzGridFontName.Text = oSerieProperties.UserGrid.HorizontalGridValueFont.oFont.Name;
                Txt_HorzGridFontName.Font = oSerieProperties.UserGrid.HorizontalGridValueFont.oFont;
                Txt_HorzGridFontSize.Text = oSerieProperties.UserGrid.HorizontalGridValueFont.oFont.Size.ToString();
                oHorzGridFont = oSerieProperties.UserGrid.HorizontalGridValueFont.oFont;

                Cmb_HorzGridLineStyle.SelectedItem = oSerieProperties.UserGrid.HorizontalLinesStyle.LineStyle.ToString();
                Txt_HorzGridLineWidth.Text = oSerieProperties.UserGrid.HorizontalLinesStyle.LineWidth.ToString();

                if (oSerieProperties.UserGrid.HorizontalLinesStyle.Visible && oSerieProperties.UserGrid.Visible)
                {
                    Pic_HorzGridLineColor.BackColor = oSerieProperties.UserGrid.HorizontalLinesStyle.LineColor;
                }
                else
                {
                    Pic_HorzGridLineColor.BackColor = SystemColors.Control;
                }

                Grid_HorzGridCustomValues.Rows.Clear();
                foreach (double Val in oSerieProperties.UserGrid.HorizontalCustomValues)
                {
                    Grid_HorzGridCustomValues.Rows.Add();
                    Grid_HorzGridCustomValues.Rows[Grid_HorzGridCustomValues.Rows.Count - 1].Cells[0].Value = Val.ToString();
                }

            Chk_VertGridVisible.Checked = oSerieProperties.UserGrid.VerticalLinesStyle.Visible;
            Cmb_VertGridMode.SelectedItem = oSerieProperties.UserGrid.VerticalGridMode.ToString();
            Txt_VertGridDivisions.Text = oSerieProperties.UserGrid.VerticalDivisionCount.ToString();
            Chk_VertGridValuesVisible.Checked = oSerieProperties.UserGrid.VerticalGridValuesVisible;

                Txt_VertGridFontName.Text = oSerieProperties.UserGrid.VerticalGridValueFont.oFont.Name;
                Txt_VertGridFontName.Font = oSerieProperties.UserGrid.VerticalGridValueFont.oFont;
                Txt_VertGridFontSize.Text = oSerieProperties.UserGrid.VerticalGridValueFont.oFont.Size.ToString();
                oVertGridFont = oSerieProperties.UserGrid.VerticalGridValueFont.oFont;

                Cmb_VertGridLineStyle.SelectedItem = oSerieProperties.UserGrid.VerticalLinesStyle.LineStyle.ToString();
                Txt_VertGridLineWidth.Text = oSerieProperties.UserGrid.VerticalLinesStyle.LineWidth.ToString();

                if (oSerieProperties.UserGrid.VerticalLinesStyle.Visible && oSerieProperties.UserGrid.Visible)
                {
                    Pic_VertGridLineColor.BackColor = oSerieProperties.UserGrid.VerticalLinesStyle.LineColor;
                }
                else
                {
                    Pic_VertGridLineColor.BackColor = SystemColors.Control;
                }

                Grid_VertGridCustomValues.Rows.Clear();
                foreach (double Val in oSerieProperties.UserGrid.VerticalCustomValues)
                {
                    Grid_VertGridCustomValues.Rows.Add();
                    Grid_VertGridCustomValues.Rows[Grid_VertGridCustomValues.Rows.Count - 1].Cells[0].Value = Val.ToString();
                }

            #endregion

            #region Tab Reference lines
            
            Ctrl_RefLines.Show_ReferenceLines();

            #endregion
        }

        private bool Set_Properties()
        {
            int iTmp = 0;
            double dTmp = 0;
            
            oTmpProps = new GraphSerieProperties();
            
            #region Tab General

            oTmpProps.Name = oSerieProperties.Name;

            //Title
            
            if(!(Txt_Label.Text.Equals("")))
            {
                oTmpProps.Label = Txt_Label.Text;
            }
            else
            {
                oTmpProps.Label = oTmpProps.Name; //Use serie's name as default label
            }

            oTmpProps.Unit = Txt_Unit.Text;
            oTmpProps.Description = Txt_Description.Text;
            oTmpProps.Visible = Chk_SerieVisible.Checked;

            //Pos & scale

            if (int.TryParse(Txt_Top.Text, out iTmp))
            {
                if ((iTmp >= 0) && (iTmp <= 100))
                {
                    oTmpProps.Top = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'StartPos' must be contains between 0 and 100 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'StartPos' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (int.TryParse(Txt_Bottom.Text, out iTmp))
            {
                if ((iTmp >= 0) && (iTmp <= 100))
                {
                    oTmpProps.Bottom = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'EndPos' must be contains between 0 and 100 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'EndPos' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if(!(oTmpProps.Bottom<oTmpProps.Top))
            {
                MessageBox.Show("Value 'StartPos' must be greater than 'EndPos' value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (!(Enum.TryParse(Cmb_ScaleMode.Text, out oTmpProps.ScalingMode)))
            {
                MessageBox.Show("Unkown scaling mode !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (double.TryParse(Txt_ScaleMin.Text, out dTmp))
            {
                oTmpProps.Min = dTmp;
            }
            else
            {
                MessageBox.Show("Value 'Min' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (double.TryParse(Txt_ScaleMax.Text, out dTmp))
            {
                oTmpProps.Max = dTmp;
            }
            else
            {
                MessageBox.Show("Value 'Max' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (oTmpProps.Min > oTmpProps.Max)
            {
                MessageBox.Show("Value 'Max' must be greater or equal to 'Min' value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            //Trace

            if (!(Enum.TryParse(Cmb_TraceStyle.Text, out oTmpProps.Trace.LineStyle)))
            {
                MessageBox.Show("Unkown trace line style !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (!(Enum.TryParse(Cmb_DrawingMode.Text, out oTmpProps.DrawingMode)))
            {
                MessageBox.Show("Unkown trace drawing mode !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (int.TryParse(Txt_TraceWidth.Text, out iTmp))
            {
                if (iTmp < 15)
                {
                    oTmpProps.Trace.LineWidth = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'Line width' must be less than 15 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'Line width' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            oTmpProps.Trace.Visible = Chk_TraceVisible.Checked;

            if(oTmpProps.Visible && oTmpProps.Trace.Visible)
            {
                oTmpProps.Trace.LineColor = Pic_TraceColor.BackColor;
            }

            //Markers

            if (!(Enum.TryParse(Cmb_MarkerStyle.Text, out oTmpProps.Markers.Style)))
            {
                MessageBox.Show("Unkown mark style !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            oTmpProps.Markers.Visible = Chk_MarkerVisible.Checked;
            oTmpProps.Markers.InteriorEmpty = Chk_MarkInteriorEmpty.Checked;

            if(int.TryParse(Txt_MarkerSize.Text,out iTmp))
            {
                if (iTmp < 30)
                {
                    oTmpProps.Markers.Size = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'Mark size' must be less than 30 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'Mark size' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if(oTmpProps.Visible && oTmpProps.Markers.Visible)
            {
                oTmpProps.Markers.MarkColor = Pic_MarkerColor.BackColor;
            }
            
            #endregion

            #region Tab Format

            if (!(Enum.TryParse(Cmb_Format.Text, out oTmpProps.ValueFormat.Format)))
            {
                MessageBox.Show("Unkown value format !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if(int.TryParse(Txt_Decimals.Text,out iTmp))
            {
                if (iTmp < 10)
                {
                    oTmpProps.ValueFormat.Decimals = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'Decimals' must be less than 10 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'Decimals' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            oTmpProps.ValueFormat.Enums = new List<GraphSerieEnumValue>();

            foreach(DataGridViewRow oRow in Grid_Enums.Rows)
            {
                GraphSerieEnumValue sEnum = new GraphSerieEnumValue();

                if (!(oRow.Cells[0].Value == null))
                {
                    if(int.TryParse(oRow.Cells[0].Value.ToString(),out iTmp))
                    {
                        sEnum.Value = iTmp;

                        if (!(oRow.Cells[1].Value == null))
                        {
                            sEnum.Text = oRow.Cells[1].Value.ToString();

                            oTmpProps.ValueFormat.Enums.Add(sEnum);
                        }
                        else
                        {
                            MessageBox.Show("Enum #" + (Grid_Enums.Rows.IndexOf(oRow) + 1).ToString() + " text is empty !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return (false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enum #" + (Grid_Enums.Rows.IndexOf(oRow) + 1).ToString() + " value must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return (false);
                    }
                }
            }

            if (oTmpProps.ValueFormat.Enums.Count > 0)
            {
                if (!(EnumListOK()))
                {
                    MessageBox.Show("At least an enum value is defined twice in the enumeration collection !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return (false);
                }
            }

            #endregion

            #region Tab Y Axis

            if (!(Enum.TryParse(Cmb_AxisStyle.Text, out oTmpProps.YAxis.AxisLineStyle.LineStyle)))
            {
                MessageBox.Show("Unkown Y axis line style !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            oTmpProps.YAxis.Visible = Chk_AxisVisible.Checked;

            if(int.TryParse(Txt_AxisWidth.Text,out iTmp))
            {
                if (iTmp < 15)
                {
                    oTmpProps.YAxis.AxisLineStyle.LineWidth = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'Y axis line width' must be less than 15 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'Y axis line width' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if(oTmpProps.YAxis.Visible)
            {
                oTmpProps.YAxis.AxisLineStyle.LineColor = Pic_AxisColor.BackColor;
            }

            oTmpProps.YAxis.AxisValuesVisible = Chk_AxisValueVisible.Checked;
            oTmpProps.YAxis.AxisTitleVisible = Chk_AxisTitleVisible.Checked;

            if(oTmpProps.YAxis.AxisValuesVisible)
            {
                if (!(oAxisFont == null))
                {
                    oTmpProps.YAxis.AxisValuesFont = new GW_Font(oAxisFont.Name, 
                                                                    oAxisFont.Size, 
                                                                    oAxisFont.Bold, 
                                                                    oAxisFont.Italic,
                                                                    true, 
                                                                    oAxisFont.Strikeout,
                                                                    oAxisFont.Underline);
                }
                else
                {
                    MessageBox.Show("Y axis value font isn't defined !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }

            #endregion

            #region Tab Grid

            oTmpProps.UserGrid.Visible = Chk_GridVisible.Checked;

            //Horizontal grid
            oTmpProps.UserGrid.HorizontalLinesStyle.Visible = Chk_HorzGridVisible.Checked;

            if (!(Enum.TryParse(Cmb_HorzGridMode.Text, out oTmpProps.UserGrid.HorizontalGridMode)))
            {
                MessageBox.Show("Unkown horizontal grid mode !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (int.TryParse(Txt_HorzGridDivisions.Text, out iTmp))
            {
                if (iTmp > 0 && iTmp <= 100)
                {
                    oTmpProps.UserGrid.HorizontalDivisionCount = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'horizontal grid divisions' must be contains between 1 and 100 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'horizontal grid divisions' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            oTmpProps.UserGrid.HorizontalGridValuesVisible = Chk_HorzGridValuesVisible.Checked;
            oTmpProps.UserGrid.HorizontalGridValueFont = new GW_Font(oHorzGridFont.Name,
                                                                        oHorzGridFont.Size,
                                                                        oHorzGridFont.Bold,
                                                                        oHorzGridFont.Italic,
                                                                        true, 
                                                                        oHorzGridFont.Strikeout,
                                                                        oHorzGridFont.Underline);

            if (!(Enum.TryParse(Cmb_HorzGridLineStyle.Text, out oTmpProps.UserGrid.HorizontalLinesStyle.LineStyle)))
            {
                MessageBox.Show("Unkown horizontal grid line style !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (int.TryParse(Txt_HorzGridLineWidth.Text, out iTmp))
            {
                if (iTmp <= 10)
                {
                    oTmpProps.UserGrid.HorizontalLinesStyle.LineWidth = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'horizontal grid line width' must be less or equal to 10 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'horizontal grid line width' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if(oTmpProps.UserGrid.Visible && oTmpProps.UserGrid.HorizontalLinesStyle.Visible)
            {
                oTmpProps.UserGrid.HorizontalLinesStyle.LineColor = Pic_HorzGridLineColor.BackColor;
            }

            //New context to limit visibility of ValuesList
            {
                List<double> ValuesList = Get_ListOfGridCustomValues(GridPropertiesTarget.HorizontalGrid);

                if (!(ValuesList == null))
                {
                    oTmpProps.UserGrid.HorizontalCustomValues = new List<double>();
                    oTmpProps.UserGrid.HorizontalCustomValues.AddRange(ValuesList);
                }
                else
                {
                    if (oTmpProps.UserGrid.HorizontalGridMode.Equals(GraphSerieUserGridModes.CustomValues))
                    {
                        return (false);
                    }
                }
            }

            //Vertical grid
            oTmpProps.UserGrid.VerticalLinesStyle.Visible = Chk_VertGridVisible.Checked;

            if (!(Enum.TryParse(Cmb_VertGridMode.Text, out oTmpProps.UserGrid.VerticalGridMode)))
            {
                MessageBox.Show("Unkown vertical grid mode !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (int.TryParse(Txt_VertGridDivisions.Text, out iTmp))
            {
                if (iTmp > 0 && iTmp <= 100)
                {
                    oTmpProps.UserGrid.VerticalDivisionCount = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'vertical grid divisions' must be contains between 1 and 100 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'vertical grid divisions' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            oTmpProps.UserGrid.VerticalGridValuesVisible = Chk_VertGridValuesVisible.Checked;
            oTmpProps.UserGrid.VerticalGridValueFont = new GW_Font(oVertGridFont.Name,
                                                                    oVertGridFont.Size,
                                                                    oVertGridFont.Bold, 
                                                                    oVertGridFont.Italic,
                                                                    true, 
                                                                    oVertGridFont.Strikeout, 
                                                                    oVertGridFont.Underline);

            if (!(Enum.TryParse(Cmb_VertGridLineStyle.Text, out oTmpProps.UserGrid.VerticalLinesStyle.LineStyle)))
            {
                MessageBox.Show("Unkown vertical grid line style !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (int.TryParse(Txt_VertGridLineWidth.Text, out iTmp))
            {
                if (iTmp <= 10)
                {
                    oTmpProps.UserGrid.VerticalLinesStyle.LineWidth = iTmp;
                }
                else
                {
                    MessageBox.Show("Value 'vertical grid line width' must be less or equal to 10 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }
            }
            else
            {
                MessageBox.Show("Value 'vertical grid line width' must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return (false);
            }

            if (oTmpProps.UserGrid.Visible && oTmpProps.UserGrid.VerticalLinesStyle.Visible)
            {
                oTmpProps.UserGrid.VerticalLinesStyle.LineColor = Pic_VertGridLineColor.BackColor;
            }

            //New context to limit visibility of ValuesList
            {
                List<double> ValuesList = Get_ListOfGridCustomValues(GridPropertiesTarget.VerticalGrid);

                if (!(ValuesList == null))
                {
                    oTmpProps.UserGrid.VerticalCustomValues = new List<double>();
                    oTmpProps.UserGrid.VerticalCustomValues.AddRange(ValuesList);
                }
                else
                {
                    if (oTmpProps.UserGrid.VerticalGridMode.Equals(GraphSerieUserGridModes.CustomValues))
                    {
                        return (false);
                    }
                }
            }

            #endregion

            #region Tab Reference lines
            
            Ctrl_RefLines.Get_ReferenceLines();
            oTmpProps.ReferenceLines = Ctrl_RefLines.ReferenceLines;

            #endregion

            Set_PropertiesObject();
            return (true);
        }

        private void Set_PropertiesObject()
        {
            if (!(oTmpProps == null))
            {
                #region General properties

                oSerieProperties.Label = oTmpProps.Label;
                oSerieProperties.Unit = oTmpProps.Unit;
                oSerieProperties.Description = oTmpProps.Description;
                oSerieProperties.Visible = oTmpProps.Visible;
                oSerieProperties.Top = oTmpProps.Top;
                oSerieProperties.Bottom = oTmpProps.Bottom;
                oSerieProperties.Min = oTmpProps.Min;
                oSerieProperties.Max = oTmpProps.Max;
                oSerieProperties.ScalingMode = oTmpProps.ScalingMode;
                oSerieProperties.DrawingMode = oTmpProps.DrawingMode;

                #endregion

                #region Trace

                oSerieProperties.Trace.Visible = oTmpProps.Trace.Visible;
                
                if(oTmpProps.Visible && oTmpProps.Trace.Visible)
                {
	                oSerieProperties.Trace.LineColor = oTmpProps.Trace.LineColor;
	                oSerieProperties.Trace.LineStyle = oTmpProps.Trace.LineStyle;
	                oSerieProperties.Trace.LineWidth = oTmpProps.Trace.LineWidth;
                }

                #endregion

                #region Markers
				
                if(oTmpProps.Visible && oTmpProps.Markers.Visible)
                {
	                oSerieProperties.Markers.MarkColor = oTmpProps.Markers.MarkColor;
	                oSerieProperties.Markers.InteriorEmpty = oTmpProps.Markers.InteriorEmpty;
	                oSerieProperties.Markers.Size = oTmpProps.Markers.Size;
	                oSerieProperties.Markers.Style = oTmpProps.Markers.Style;
                }
                
                oSerieProperties.Markers.Visible = oTmpProps.Markers.Visible;

                #endregion

                #region Value format

                oSerieProperties.ValueFormat.Decimals = oTmpProps.ValueFormat.Decimals;
                oSerieProperties.ValueFormat.Format = oTmpProps.ValueFormat.Format;

                oSerieProperties.ValueFormat.Enums.Clear();

                foreach (GraphSerieEnumValue sEnum in oTmpProps.ValueFormat.Enums)
                {
                    oSerieProperties.ValueFormat.Add_NewEnum(sEnum.Value, sEnum.Text);
                }

                #endregion

                #region Y Axis

                oSerieProperties.YAxis.Visible = oTmpProps.YAxis.Visible;
                
                if (oTmpProps.YAxis.Visible)
                {
	                oSerieProperties.YAxis.AxisLineStyle.LineColor = oTmpProps.YAxis.AxisLineStyle.LineColor;
	                oSerieProperties.YAxis.AxisLineStyle.LineStyle = oTmpProps.YAxis.AxisLineStyle.LineStyle;
	                oSerieProperties.YAxis.AxisLineStyle.LineWidth = oTmpProps.YAxis.AxisLineStyle.LineWidth;
	                oSerieProperties.YAxis.AxisLineStyle.Visible = oTmpProps.YAxis.AxisLineStyle.Visible;
                }

                oSerieProperties.YAxis.AxisValuesFont = new GW_Font(oTmpProps.YAxis.AxisValuesFont.oFont.Name,
                                                                    oTmpProps.YAxis.AxisValuesFont.oFont.Size,
                                                                    oTmpProps.YAxis.AxisValuesFont.oFont.Bold,
                                                                    oTmpProps.YAxis.AxisValuesFont.oFont.Italic,
                                                                    true,
                                                                    oTmpProps.YAxis.AxisValuesFont.oFont.Strikeout,
                                                                    oTmpProps.YAxis.AxisValuesFont.oFont.Underline);

                oSerieProperties.YAxis.AxisValuesVisible = oTmpProps.YAxis.AxisValuesVisible;
                oSerieProperties.YAxis.AxisTitleVisible = oTmpProps.YAxis.AxisTitleVisible;

                #endregion

                #region User grid

                oSerieProperties.UserGrid.Visible = oTmpProps.UserGrid.Visible;

                //Horizontal grid
                oSerieProperties.UserGrid.HorizontalLinesStyle.Visible = oTmpProps.UserGrid.HorizontalLinesStyle.Visible;
                
                if (oTmpProps.UserGrid.Visible && oTmpProps.UserGrid.HorizontalLinesStyle.Visible)
                {
                	oSerieProperties.UserGrid.HorizontalLinesStyle.LineColor = oTmpProps.UserGrid.HorizontalLinesStyle.LineColor;
                	oSerieProperties.UserGrid.HorizontalLinesStyle.LineStyle = oTmpProps.UserGrid.HorizontalLinesStyle.LineStyle;
                	oSerieProperties.UserGrid.HorizontalLinesStyle.LineWidth = oTmpProps.UserGrid.HorizontalLinesStyle.LineWidth;
                	
                	oSerieProperties.UserGrid.HorizontalDivisionCount = oTmpProps.UserGrid.HorizontalDivisionCount;
                	oSerieProperties.UserGrid.HorizontalGridMode = oTmpProps.UserGrid.HorizontalGridMode;
                	oSerieProperties.UserGrid.HorizontalGridValuesVisible = oTmpProps.UserGrid.HorizontalGridValuesVisible;
                	oSerieProperties.UserGrid.HorizontalGridValueFont = oTmpProps.UserGrid.HorizontalGridValueFont.Get_Clone();

                	oSerieProperties.UserGrid.HorizontalCustomValues = new List<double>();
                	oSerieProperties.UserGrid.HorizontalCustomValues.AddRange(oTmpProps.UserGrid.HorizontalCustomValues);
                }

                //Vertical grid
                oSerieProperties.UserGrid.VerticalLinesStyle.Visible = oTmpProps.UserGrid.VerticalLinesStyle.Visible;
                
                if (oTmpProps.UserGrid.Visible && oTmpProps.UserGrid.VerticalLinesStyle.Visible)
                {
                	oSerieProperties.UserGrid.VerticalLinesStyle.LineColor = oTmpProps.UserGrid.VerticalLinesStyle.LineColor;
                	oSerieProperties.UserGrid.VerticalLinesStyle.LineStyle = oTmpProps.UserGrid.VerticalLinesStyle.LineStyle;
                	oSerieProperties.UserGrid.VerticalLinesStyle.LineWidth = oTmpProps.UserGrid.VerticalLinesStyle.LineWidth;
                	

                	oSerieProperties.UserGrid.VerticalDivisionCount = oTmpProps.UserGrid.VerticalDivisionCount;
                	oSerieProperties.UserGrid.VerticalGridMode = oTmpProps.UserGrid.VerticalGridMode;
                	oSerieProperties.UserGrid.VerticalGridValuesVisible = oTmpProps.UserGrid.VerticalGridValuesVisible;
                	oSerieProperties.UserGrid.VerticalGridValueFont = oTmpProps.UserGrid.VerticalGridValueFont.Get_Clone();

                	oSerieProperties.UserGrid.VerticalCustomValues = new List<double>();
                	oSerieProperties.UserGrid.VerticalCustomValues.AddRange(oTmpProps.UserGrid.VerticalCustomValues);
                }

                #endregion

                #region Reference lines

                oSerieProperties.ReferenceLines = new List<GraphReferenceLine>();

                foreach(GraphReferenceLine oLine in oTmpProps.ReferenceLines)
                {
                    oSerieProperties.ReferenceLines.Add(oLine.Get_Clone());
                }

                #endregion
            }
        }

        #region Format functions

        private void Add_Enum()
        {
            Grid_Enums.Rows.Add();
            DataGridViewRow oRow = Grid_Enums.Rows[Grid_Enums.Rows.Count - 1];

            oRow.Cells[0].Value = (Grid_Enums.Rows.Count - 1).ToString();
            oRow.Cells[1].Value = "Text_" + Grid_Enums.Rows.Count.ToString();
        }

        private void Del_Enum()
        {
            if (!(Grid_Enums.SelectedRows == null))
            {
                foreach(DataGridViewRow oRow in Grid_Enums.SelectedRows)
                {
                    Grid_Enums.Rows.Remove(oRow);
                }
            }
        }

        private void Clear_Enums()
        {
            DialogResult Rep = MessageBox.Show("Do you really want clear all enums of the list ?",
                                                FORM_TITLE, 
                                                MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question);

            if(Rep.Equals(DialogResult.Yes))
            {
                Grid_Enums.Rows.Clear();
            }
        }

        private bool EnumListOK()
        {
            foreach(GraphSerieEnumValue sTestEnum in oTmpProps.ValueFormat.Enums)
            {
                foreach (GraphSerieEnumValue sEnum in oTmpProps.ValueFormat.Enums)
                {
                    if (!(sEnum.Equals(sTestEnum))) //Not sTestEnum & sEnum pointing to the same GraphSerieEnumValue structure reference
                    {
                        if (sEnum.Value == sTestEnum.Value)
                        {
                            return (false); //Two different GraphSerieEnumValue references have the same value
                        }
                    }
                }
            }

            return (true);
        }

        #endregion

        #region Grid functions

        private DataGridView Get_GridCustomValues(GridPropertiesTarget eGridTgt)
        {
            switch (eGridTgt)
            {
                case GridPropertiesTarget.HorizontalGrid:

                    return (Grid_HorzGridCustomValues);

                case GridPropertiesTarget.VerticalGrid:

                    return (Grid_VertGridCustomValues);

                default:

                    return (null);
            }
        }

        private string Get_GridCustomValuesName(GridPropertiesTarget eGridTgt)
        {
            switch(eGridTgt)
            {
                case GridPropertiesTarget.HorizontalGrid:

                    return ("horizontal grid custom values");

                case GridPropertiesTarget.VerticalGrid:

                    return ("vertical grid custom values");

                default:

                    return ("");
            }
        }

        private void Add_GridCustomValue(GridPropertiesTarget eGridTgt)
        {
            DataGridView oGrid = Get_GridCustomValues(eGridTgt);

            if (!(oGrid == null))
            {
                oGrid.Rows.Add();
                oGrid.Rows[oGrid.Rows.Count - 1].Cells[0].Value = oGrid.Rows.Count.ToString();
            }
        }

        private void Del_GridCustomValue(GridPropertiesTarget eGridTgt)
        {
            DataGridView oGrid = Get_GridCustomValues(eGridTgt);

            if (!(oGrid == null))
            {
                if (!(oGrid.SelectedRows == null))
                {
                    foreach (DataGridViewRow oRow in oGrid.SelectedRows)
                    {
                        oGrid.Rows.Remove(oRow);
                    }
                }
            }
        }

        private void Clear_GridCustomValue(GridPropertiesTarget eGridTgt)
        {
            DataGridView oGrid = Get_GridCustomValues(eGridTgt);

            if (!(oGrid == null))
            {
                string GridName = Get_GridCustomValuesName(eGridTgt);

                DialogResult Rep = MessageBox.Show("Do you really want clear all values of the " + GridName + " grid ?",
                                                    FORM_TITLE, 
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if(Rep.Equals(DialogResult.Yes))
                {
                    oGrid.Rows.Clear();
                }
            }
            
        }

        private List<double> Get_ListOfGridCustomValues(GridPropertiesTarget eGridTgt)
        {
            DataGridView oGrid = Get_GridCustomValues(eGridTgt);

            if (!(oGrid == null))
            {
                List<double> GridValues = new List<double>();

                for (int iRow = 0; iRow < oGrid.Rows.Count; iRow++)
                {
                    double Val = 0;
                    
                    if (!(oGrid.Rows[iRow].Cells[0].Value == null))
                    {
	                    if (double.TryParse(oGrid.Rows[iRow].Cells[0].Value.ToString(), out Val))
	                    {
	                        GridValues.Add(Val);
	                    }
	                    else
	                    {
	                        MessageBox.Show("Value #" + (iRow + 1).ToString() + " of grid " + Get_GridCustomValuesName(eGridTgt) + " must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                        return (null);
	                    }
                    }
                    else
                    {
                    	MessageBox.Show("Value #" + (iRow + 1).ToString() + " of grid " + Get_GridCustomValuesName(eGridTgt) + " cannot be empty !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                    return (null);
                    }
                }

                if (GridValues.Count > 0)
                {
                    return (GridValues);
                }
            }

            return (null);
        }

        #endregion

        #region Reference lines functions

        #endregion

        #endregion
    }
}
