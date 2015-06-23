using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ctrl_GraphWindow
{
    /// <summary>
    /// Graphic window reference lines management control
    /// </summary>
    public partial class Ctrl_ReferenceLines : UserControl
    {
        #region Private constants

        private const int REF_LINE_MODE_COL = 0;
        private const int REF_LINE_VALUE_COL = 1;
        private const int REF_LINE_TITLE_COL = 2;
        private const int REF_LINE_VISIBLE_COL = 3;
        private const int REF_LINE_STYLE_COL = 4;
        private const int REF_LINE_COLOR_COL = 5;
        private const int REF_LINE_WIDTH_COL = 6;
        private const int REF_LINE_VALUE_POS_COL = 7;
        private const int REF_LINE_TITLE_POS_COL = 8;
        private const int REF_LINE_FONT = 9;

        #endregion

        #region Private enums

        private enum ReferenceLineMovingDirection
        {
            Up = 0,
            Down = 1,
        }

        #endregion

        #region Public members

        /// <summary>
        /// Control reference lines collection
        /// </summary>
        public List<GraphReferenceLine> ReferenceLines;

        /// <summary>
        /// Reference line default color
        /// </summary>
        public Color DefaultLineColor;

        /// <summary>
        /// Title of the form hosting the control
        /// </summary>
        public string FORM_TITLE;

        #endregion

        #region Private members

        private int NextRefLineKey;
        private List<DataGridViewRow> RefLinesClipboard;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public Ctrl_ReferenceLines()
        {
            InitializeComponent();
        }

        #region Control events

        #region TS_RefLines

        private void TSB_AddRefLine_Click(object sender, EventArgs e)
        {
            Add_ReferenceLine();
        }

        private void TSB_DelRefLine_Click(object sender, EventArgs e)
        {
            Del_ReferenceLine();
        }

        private void TSB_ClearRefLines_Click(object sender, EventArgs e)
        {
            Clear_ReferenceLines();
        }

        private void TSB_MoveUpRefLine_Click(object sender, EventArgs e)
        {
            Move_ReferenceLine(ReferenceLineMovingDirection.Up);
        }

        private void TSB_MoveDownRefLine_Click(object sender, EventArgs e)
        {
            Move_ReferenceLine(ReferenceLineMovingDirection.Down);
        }

        private void TSB_CopyReferenceLines_Click(object sender, EventArgs e)
        {
            Copy_ReferenceLine();
        }

        private void TSB_PasteReferenceLines_Click(object sender, EventArgs e)
        {
            Paste_ReferenceLine();
        }

        #endregion

        #region Grid_RefLines

        private void Grid_RefLines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == REF_LINE_MODE_COL && (!(e.RowIndex == -1)))
            {
                if (Grid_RefLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals(GraphSerieReferenceLineModes.Custom.ToString()))
                {
                    GraphReferenceLine oLine = Get_ReferenceLineAtKey((int)Grid_RefLines.Rows[e.RowIndex].Tag);

                    if (!(oLine == null))
                    {
                        Grid_RefLines.Rows[e.RowIndex].Cells[REF_LINE_VALUE_COL].Value = oLine.ReferenceValue.ToString();
                        Grid_RefLines.Rows[e.RowIndex].Cells[REF_LINE_VALUE_COL].ReadOnly = false;
                    }
                }
                else
                {
                    Grid_RefLines.Rows[e.RowIndex].Cells[REF_LINE_VALUE_COL].Value = "-";
                    Grid_RefLines.Rows[e.RowIndex].Cells[REF_LINE_VALUE_COL].ReadOnly = true;
                }
            }
        }

        private void Grid_RefLines_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case REF_LINE_COLOR_COL:

                    if (Dlg_Color.ShowDialog().Equals(DialogResult.OK))
                    {
                        Grid_RefLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Dlg_Color.Color;
                    }
                    break;

                case REF_LINE_FONT:

                    if (Dlg_Font.ShowDialog().Equals(DialogResult.OK))
                    {
                        Grid_RefLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = Dlg_Font.Font;

                        Grid_RefLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Dlg_Font.Font.Name + ", " + Dlg_Font.Font.Size.ToString();
                        Grid_RefLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = Dlg_Font.Font;
                    }

                    break;
            }
        }

        private void Grid_RefLines_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:

                    Del_ReferenceLine();
                    break;

                case Keys.PageUp:

                    Move_ReferenceLine(ReferenceLineMovingDirection.Up);
                    break;

                case Keys.PageDown:

                    Move_ReferenceLine(ReferenceLineMovingDirection.Down);
                    break;

                case Keys.C:

                    if (e.Control)
                    {
                        Copy_ReferenceLine();
                    }
                    break;

                case Keys.V:

                    if (e.Control)
                    {
                        Paste_ReferenceLine();
                    }
                    break;
            }
        }

        #endregion

        #endregion

        #region Private methodes

        private GraphReferenceLine Get_ReferenceLineAtKey(int LineKey)
        {
            foreach (GraphReferenceLine oLine in ReferenceLines)
            {
                if (oLine.iKey == LineKey)
                {
                    return (oLine);
                }
            }

            return (null);
        }

        private void Add_Grid_RefLines_Row()
        {
            Grid_RefLines.Rows.Add();
            DataGridViewRow oRow = Grid_RefLines.Rows[Grid_RefLines.Rows.Count - 1];

            oRow.Tag = NextRefLineKey;
            NextRefLineKey++;

            DataGridViewComboBoxCell oCmbModesCell = oRow.Cells[REF_LINE_MODE_COL] as DataGridViewComboBoxCell;
            oCmbModesCell.Items.AddRange(Enum.GetNames(typeof(GraphSerieReferenceLineModes)));

            DataGridViewComboBoxCell oCmbStyleCell = oRow.Cells[REF_LINE_STYLE_COL] as DataGridViewComboBoxCell;
            oCmbStyleCell.Items.AddRange(Enum.GetNames(typeof(System.Drawing.Drawing2D.DashStyle)));

            DataGridViewComboBoxCell oCmbValuePosCell = oRow.Cells[REF_LINE_VALUE_POS_COL] as DataGridViewComboBoxCell;
            oCmbValuePosCell.Items.AddRange(Enum.GetNames(typeof(ScreenPositions)));

            DataGridViewComboBoxCell oCmbTitlePosCell = oRow.Cells[REF_LINE_TITLE_POS_COL] as DataGridViewComboBoxCell;
            oCmbTitlePosCell.Items.AddRange(Enum.GetNames(typeof(ScreenPositions)));

            Font LineFont = new Font("Arial", 8);
            oRow.Cells[REF_LINE_FONT].Tag = LineFont;
            oRow.Cells[REF_LINE_FONT].Value = LineFont.Name + ", " + LineFont.Size.ToString();
        }

        private void Add_ReferenceLine()
        {
            Add_Grid_RefLines_Row();
            DataGridViewRow oRow = Grid_RefLines.Rows[Grid_RefLines.Rows.Count - 1];

            oRow.Cells[REF_LINE_MODE_COL].Value = GraphSerieReferenceLineModes.Custom.ToString();
            oRow.Cells[REF_LINE_VALUE_COL].Value = "0";
            oRow.Cells[REF_LINE_TITLE_COL].Value = "";
            oRow.Cells[REF_LINE_VISIBLE_COL].Value = true;
            oRow.Cells[REF_LINE_STYLE_COL].Value = System.Drawing.Drawing2D.DashStyle.DashDot.ToString();
            oRow.Cells[REF_LINE_COLOR_COL].Style.BackColor = DefaultLineColor;
            oRow.Cells[REF_LINE_VALUE_POS_COL].Value = ScreenPositions.Center.ToString();
            oRow.Cells[REF_LINE_TITLE_POS_COL].Value = ScreenPositions.Invisible.ToString();
            oRow.Cells[REF_LINE_WIDTH_COL].Value = "1";
        }

        private void Del_ReferenceLine()
        {
            if (!(Grid_RefLines.SelectedRows == null))
            {
                foreach (DataGridViewRow oRow in Grid_RefLines.SelectedRows)
                {
                    Grid_RefLines.Rows.Remove(oRow);
                }
            }
        }

        private void Clear_ReferenceLines()
        {
            DialogResult Rep = MessageBox.Show("Do you really want clear all reference lines ?",
                                                FORM_TITLE,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (Rep.Equals(DialogResult.Yes))
            {
                Grid_RefLines.Rows.Clear();
            }
        }

        private void Move_ReferenceLine(ReferenceLineMovingDirection eDirection)
        {
            if (!(Grid_RefLines.SelectedRows == null))
            {
                foreach (DataGridViewRow oRow in Grid_RefLines.SelectedRows)
                {
                    int OldIndex = Grid_RefLines.Rows.IndexOf(oRow);
                    int NewIndex = OldIndex;

                    switch (eDirection)
                    {
                        case ReferenceLineMovingDirection.Up:

                            if (!(OldIndex == 0))
                            {
                                NewIndex -= 1;
                            }

                            break;

                        case ReferenceLineMovingDirection.Down:

                            if (!(OldIndex == Grid_RefLines.Rows.Count - 1))
                            {
                                NewIndex += 2;
                            }

                            break;
                    }

                    DataGridViewRow oDgbRow = Grid_RefLines.Rows[OldIndex];

                    if (!(NewIndex == OldIndex))
                    {
                        Grid_RefLines.Rows.InsertCopy(OldIndex, NewIndex);

                        if (eDirection.Equals(ReferenceLineMovingDirection.Up))
                        {
                            OldIndex++;
                        }

                        for (int iCell = 0; iCell < Grid_RefLines.Rows[OldIndex].Cells.Count; iCell++)
                        {
                            Grid_RefLines.Rows[NewIndex].Cells[iCell].Value = Grid_RefLines.Rows[OldIndex].Cells[iCell].Value;

                            if (iCell == REF_LINE_COLOR_COL)
                            {
                                Grid_RefLines.Rows[NewIndex].Cells[iCell].Style.BackColor = Grid_RefLines.Rows[OldIndex].Cells[iCell].Style.BackColor;
                            }
                        }

                        Grid_RefLines.Rows.RemoveAt(OldIndex);
                    }
                }
            }
        }

        private void Copy_ReferenceLine()
        {
            if (!(Grid_RefLines.SelectedRows == null))
            {
                RefLinesClipboard = new List<DataGridViewRow>();

                foreach (DataGridViewRow oRow in Grid_RefLines.SelectedRows)
                {
                    DataGridViewRow CopiedRow = (DataGridViewRow)oRow.Clone();

                    for (int iCell = 0; iCell < oRow.Cells.Count; iCell++)
                    {
                        CopiedRow.Cells[iCell].Value = oRow.Cells[iCell].Value;
                    }

                    RefLinesClipboard.Add(CopiedRow);

                }
            }
        }

        private void Paste_ReferenceLine()
        {
            if (!(RefLinesClipboard == null))
            {
                Grid_RefLines.Rows.AddRange(RefLinesClipboard.ToArray());
                RefLinesClipboard = null;
            }
        }

        private List<GraphReferenceLine> Set_ReferenceLines()
        {
            double dTmp = 0;
            int iTmp = 0;

            List<GraphReferenceLine> oTmpLines = new List<GraphReferenceLine>();

            foreach (DataGridViewRow oRow in Grid_RefLines.Rows)
            {
                GraphReferenceLine oLine = new GraphReferenceLine();

                oLine.iKey = (int)oRow.Tag;

                if (!(Enum.TryParse(oRow.Cells[REF_LINE_MODE_COL].Value.ToString(), out oLine.ReferenceMode)))
                {
                    MessageBox.Show("Unkown reference mode for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (null);
                }

                if (oLine.ReferenceMode.Equals(GraphSerieReferenceLineModes.Custom))
                {
                	if (!(oRow.Cells[REF_LINE_VALUE_COL].Value == null))
                	{
	                	if (double.TryParse(oRow.Cells[REF_LINE_VALUE_COL].Value.ToString(), out dTmp))
	                    {
	                        oLine.ReferenceValue = dTmp;
	                    }
	                    else
	                    {
	                        MessageBox.Show("Reference value for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                        return (null);
	                    }
                	}
                	else
                	{
                		MessageBox.Show("Reference value for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " cannot be empty !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                    return (null);
                	}
                }

                oLine.ReferenceTitle = oRow.Cells[REF_LINE_TITLE_COL].Value.ToString();

                oLine.Visible = (bool)oRow.Cells[REF_LINE_VISIBLE_COL].Value;

                if (!(Enum.TryParse(oRow.Cells[REF_LINE_STYLE_COL].Value.ToString(), out oLine.ReferenceStyle.LineStyle)))
                {
                    MessageBox.Show("Unkown line style for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (null);
                }

                oLine.ReferenceStyle.LineColor = oRow.Cells[REF_LINE_COLOR_COL].Style.BackColor;
                
                if (!(oRow.Cells[REF_LINE_WIDTH_COL].Value == null))
                {
	                if (int.TryParse(oRow.Cells[REF_LINE_WIDTH_COL].Value.ToString(), out iTmp))
	                {
	                    if (iTmp < 20)
	                    {
	                        oLine.ReferenceStyle.LineWidth = iTmp;
	                    }
	                    else
	                    {
	                        MessageBox.Show("Line width for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " must be less than 20 !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                        return (null);
	                    }
	                }
	                else
	                {
	                    MessageBox.Show("Line width for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " must be a numeric value !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                    return (null);
	                }
                }
                else
                {
                	MessageBox.Show("Line width for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " cannot be empty !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	                return (null);
                }

                if (!(Enum.TryParse(oRow.Cells[REF_LINE_VALUE_POS_COL].Value.ToString(), out oLine.ReferenceValuePosition)))
                {
                    MessageBox.Show("Unkown value position for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (null);
                }

                if (!(Enum.TryParse(oRow.Cells[REF_LINE_TITLE_POS_COL].Value.ToString(), out oLine.ReferenceTitlePosition)))
                {
                    MessageBox.Show("Unkown title position for reference line #" + (Grid_RefLines.Rows.IndexOf(oRow) + 1).ToString() + " !", FORM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (null);
                }

                Font CellTag = (Font)oRow.Cells[REF_LINE_FONT].Tag;
                oLine.ReferenceValueFont = new GW_Font(CellTag.Name,
                                                        CellTag.Size,
                                                        CellTag.Bold,
                                                        CellTag.Italic,
                                                        true,
                                                        CellTag.Strikeout,
                                                        CellTag.Underline);

                oTmpLines.Add(oLine);
            }

            return (oTmpLines);
        }

        #endregion

        #region Public methodes

        /// <summary>
        /// Show the reference lines collection hosted by the control
        /// </summary>
        public void Show_ReferenceLines()
        {
            Grid_RefLines.Rows.Clear();

            foreach (GraphReferenceLine oRefLine in ReferenceLines)
            {

                Add_Grid_RefLines_Row();
                DataGridViewRow oRow = Grid_RefLines.Rows[Grid_RefLines.Rows.Count - 1];

                NextRefLineKey = oRefLine.iKey;
                oRow.Tag = NextRefLineKey;

                oRow.Cells[REF_LINE_MODE_COL].Value = oRefLine.ReferenceMode.ToString();
                oRow.Cells[REF_LINE_VALUE_COL].Value = oRefLine.ReferenceValue.ToString();
                oRow.Cells[REF_LINE_TITLE_COL].Value = oRefLine.ReferenceTitle;
                oRow.Cells[REF_LINE_VISIBLE_COL].Value = oRefLine.Visible;
                oRow.Cells[REF_LINE_STYLE_COL].Value = oRefLine.ReferenceStyle.LineStyle.ToString();
                oRow.Cells[REF_LINE_COLOR_COL].Style.BackColor = oRefLine.ReferenceStyle.LineColor;
                oRow.Cells[REF_LINE_WIDTH_COL].Value = oRefLine.ReferenceStyle.LineWidth.ToString();
                oRow.Cells[REF_LINE_VALUE_POS_COL].Value = oRefLine.ReferenceValuePosition.ToString();
                oRow.Cells[REF_LINE_TITLE_POS_COL].Value = oRefLine.ReferenceTitlePosition.ToString();
                oRow.Cells[REF_LINE_FONT].Value = oRefLine.ReferenceValueFont.oFont.Name
                                                    + ", " + oRefLine.ReferenceValueFont.oFont.Size.ToString();

                oRow.Cells[REF_LINE_FONT].Tag = oRefLine.ReferenceValueFont.oFont;
                oRow.Cells[REF_LINE_FONT].Style.Font = oRefLine.ReferenceValueFont.oFont;
            }

            NextRefLineKey++;
        }
        
        /// <summary>
        /// Update the reference lines collection of the control with properties set by the user
        /// </summary>
        /// <remarks>Updated reference lines is accessible by the 'ReferenceLines' member</remarks>
        public void Get_ReferenceLines()
        {
            List<GraphReferenceLine> oTmpLines = Set_ReferenceLines();

            if(!(oTmpLines==null))
            {
                ReferenceLines.Clear();

                foreach(GraphReferenceLine oLine in oTmpLines)
                {
                    ReferenceLines.Add(oLine.Get_Clone());
                }
            }
        }

        #endregion
    }
}
