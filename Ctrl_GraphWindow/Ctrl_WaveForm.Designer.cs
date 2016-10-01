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
	partial class Ctrl_WaveForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TB_Graph = new System.Windows.Forms.ToolStrip();
            this.TSB_LoadData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_ShowHide_ChannelList = new System.Windows.Forms.ToolStripButton();
            this.TSB_ShowHide_Legend = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_GraphProperties = new System.Windows.Forms.ToolStripButton();
            this.TSDdB_GraphLayoutMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSDdB_overlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_parallelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSDdB_MainGraphCursor = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSDdB_noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_verticalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_horizontalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_crossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_graticuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CursorStep = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSDdB_CurStep_01_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CurStep_02_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CurStep_05_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CurStep_1_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CurStep_2_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CurStep_5_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CurStep_10_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CurStep_20_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_CurStep_50_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDB_RefCursor = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSDB_RefCursor_Set = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDB_RefCursor_Lock = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDB_RefCursor_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDB_RefCursor_Mode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDB_RefCursor_Mode_None = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDB_RefCursor_Mode_Vertical = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDB_RefCursor_Mode_Horizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TSDdB_ZoomMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSDdB_zoomXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_zoomYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_zoomXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSDdB_zoomDisabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_ZoomFactor = new System.Windows.Forms.ToolStripDropDownButton();
            this.TSDdB_ZoomFactor_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_ZoomFactor_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_ZoomFactor_8 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_ZoomFactor_16 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDdB_ZoomFactor_32 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSB_ZoomPlus = new System.Windows.Forms.ToolStripButton();
            this.TSB_ZoomMinus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_Snapshot = new System.Windows.Forms.ToolStripButton();
            this.TSB_Print = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_RT_Play = new System.Windows.Forms.ToolStripButton();
            this.TSB_RT_Break = new System.Windows.Forms.ToolStripButton();
            this.TSB_RT_Stop = new System.Windows.Forms.ToolStripButton();
            this.TSCmb_InitialStage = new System.Windows.Forms.ToolStripComboBox();
            this.TSB_Replot = new System.Windows.Forms.ToolStripButton();
            this.TSB_SeeStep = new System.Windows.Forms.ToolStripButton();
            this.TSB_SeePrevStep = new System.Windows.Forms.ToolStripButton();
            this.TSB_SeeNextStep = new System.Windows.Forms.ToolStripButton();
            this.TSL_PlotCount = new System.Windows.Forms.ToolStripLabel();
            this.TSL_PlotLast = new System.Windows.Forms.ToolStripLabel();
            this.TSL_PlotAvg = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Ctrl_ChannelList = new Ctrl_GraphWindow.Ctrl_GW_ChannelList();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Cmd_ZoomYPosition = new System.Windows.Forms.Button();
            this.Cmd_ZoomXPosition = new System.Windows.Forms.Button();
            this.Pic_Graphic = new Ctrl_GraphWindow.GW_SelectablePictureBox();
            this.Pic_GraphFrame = new Ctrl_GraphWindow.GW_SelectablePictureBox();
            this.Grid_Legend = new System.Windows.Forms.DataGridView();
            this.Legend_Col_Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_GraphMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_GraphMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_GraphAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_RefValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_RefDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_RefDiffPerc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legend_Col_RefGradient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dlg_OpenData = new System.Windows.Forms.OpenFileDialog();
            this.Context_PicGraphic_ZoomStats = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Context_PicGraph_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RT_PlaytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RT_BreaktoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RT_StoptoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomPlustoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomMinustoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomMintoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomMaxtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomModetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomMode_X_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomMode_Y_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomMode_XY_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomMode_Disabled_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomFactortoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomFactor_2_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomFactor_4_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomFactor_8_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomFactor_16_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomFactor_32_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_verticalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_horizontalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_crossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_graticuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.cursorStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_01_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_02_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_05_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_1_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_2_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_5_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_10_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_20_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cursor_Step_50_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReferenceCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefCursor_Set_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RefCursor_Lock_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RefCursor_Clear_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RefCursor_Mode_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RefCursor_Mode_None_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RefCursor_Mode_Vertical_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RefCursor_Mode_Horizontal_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.graphLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Layout_overlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Layout_parallelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Layout_customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.snapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Context_Legend = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_Ctxt_Legend_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Hide = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Ctxt_Legend_Infos = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_Label = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_Value = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_Unit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_Min = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_Max = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_Avg = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_RefCursor = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Value = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Diff = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Gradient = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_ShowTitles = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Ctxt_Legend_ShowGridLines = new System.Windows.Forms.ToolStripMenuItem();
            this.Dlg_Save_Snapshot = new System.Windows.Forms.SaveFileDialog();
            this.TB_Graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Graphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_GraphFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Legend)).BeginInit();
            this.Context_PicGraphic_ZoomStats.SuspendLayout();
            this.Context_PicGraph_Options.SuspendLayout();
            this.Context_Legend.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Graph
            // 
            this.TB_Graph.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TB_Graph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_LoadData,
            this.toolStripSeparator1,
            this.TSB_ShowHide_ChannelList,
            this.TSB_ShowHide_Legend,
            this.toolStripSeparator5,
            this.TSB_GraphProperties,
            this.TSDdB_GraphLayoutMode,
            this.toolStripSeparator2,
            this.TSDdB_MainGraphCursor,
            this.TSDdB_CursorStep,
            this.TSDB_RefCursor,
            this.toolStripSeparator4,
            this.TSDdB_ZoomMode,
            this.TSDdB_ZoomFactor,
            this.TSB_ZoomPlus,
            this.TSB_ZoomMinus,
            this.toolStripSeparator6,
            this.TSB_Snapshot,
            this.TSB_Print,
            this.toolStripSeparator7,
            this.TSB_RT_Play,
            this.TSB_RT_Break,
            this.TSB_RT_Stop,
            this.TSCmb_InitialStage,
            this.TSB_Replot,
            this.TSB_SeeStep,
            this.TSB_SeePrevStep,
            this.TSB_SeeNextStep,
            this.TSL_PlotCount,
            this.TSL_PlotLast,
            this.TSL_PlotAvg});
            this.TB_Graph.Location = new System.Drawing.Point(0, 0);
            this.TB_Graph.Name = "TB_Graph";
            this.TB_Graph.Size = new System.Drawing.Size(814, 25);
            this.TB_Graph.TabIndex = 0;
            this.TB_Graph.Text = "toolStrip1";
            // 
            // TSB_LoadData
            // 
            this.TSB_LoadData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_LoadData.Image = global::Ctrl_GraphWindow.Icones.download_disconnect_icone_5328;
            this.TSB_LoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_LoadData.Name = "TSB_LoadData";
            this.TSB_LoadData.Size = new System.Drawing.Size(23, 22);
            this.TSB_LoadData.Text = "toolStripButton1";
            this.TSB_LoadData.ToolTipText = "Load data file";
            this.TSB_LoadData.Click += new System.EventHandler(this.TSB_LoadData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_ShowHide_ChannelList
            // 
            this.TSB_ShowHide_ChannelList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ShowHide_ChannelList.Image = global::Ctrl_GraphWindow.Icones.block_modules_icone_7434;
            this.TSB_ShowHide_ChannelList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ShowHide_ChannelList.Name = "TSB_ShowHide_ChannelList";
            this.TSB_ShowHide_ChannelList.Size = new System.Drawing.Size(23, 22);
            this.TSB_ShowHide_ChannelList.Text = "toolStripButton1";
            this.TSB_ShowHide_ChannelList.ToolTipText = "Show/Hide channel list";
            this.TSB_ShowHide_ChannelList.Click += new System.EventHandler(this.TSB_ShowHide_ChannelList_Click);
            // 
            // TSB_ShowHide_Legend
            // 
            this.TSB_ShowHide_Legend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ShowHide_Legend.Image = global::Ctrl_GraphWindow.Icones.texte_balles_liste_icone_8735_16;
            this.TSB_ShowHide_Legend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ShowHide_Legend.Name = "TSB_ShowHide_Legend";
            this.TSB_ShowHide_Legend.Size = new System.Drawing.Size(23, 22);
            this.TSB_ShowHide_Legend.Text = "toolStripButton1";
            this.TSB_ShowHide_Legend.ToolTipText = "Show/Hide legend";
            this.TSB_ShowHide_Legend.Click += new System.EventHandler(this.TSB_ShowHide_LegendClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_GraphProperties
            // 
            this.TSB_GraphProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_GraphProperties.Image = global::Ctrl_GraphWindow.Icones.coloriser_icone_5758;
            this.TSB_GraphProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_GraphProperties.Name = "TSB_GraphProperties";
            this.TSB_GraphProperties.Size = new System.Drawing.Size(23, 22);
            this.TSB_GraphProperties.Text = "toolStripButton1";
            this.TSB_GraphProperties.ToolTipText = "Edit graph properties";
            this.TSB_GraphProperties.Click += new System.EventHandler(this.TSB_GraphProperties_Click);
            // 
            // TSDdB_GraphLayoutMode
            // 
            this.TSDdB_GraphLayoutMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSDdB_GraphLayoutMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDdB_overlayToolStripMenuItem,
            this.TSDdB_parallelToolStripMenuItem,
            this.TSDdB_customToolStripMenuItem});
            this.TSDdB_GraphLayoutMode.Image = global::Ctrl_GraphWindow.Icones.graphic_curve_icone_6410_16;
            this.TSDdB_GraphLayoutMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDdB_GraphLayoutMode.Name = "TSDdB_GraphLayoutMode";
            this.TSDdB_GraphLayoutMode.Size = new System.Drawing.Size(29, 22);
            this.TSDdB_GraphLayoutMode.Text = "toolStripDropDownButton1";
            this.TSDdB_GraphLayoutMode.ToolTipText = "Graphic layout mode";
            // 
            // TSDdB_overlayToolStripMenuItem
            // 
            this.TSDdB_overlayToolStripMenuItem.Name = "TSDdB_overlayToolStripMenuItem";
            this.TSDdB_overlayToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.TSDdB_overlayToolStripMenuItem.Text = "Overlay";
            this.TSDdB_overlayToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_overlayToolStripMenuItemClick);
            // 
            // TSDdB_parallelToolStripMenuItem
            // 
            this.TSDdB_parallelToolStripMenuItem.Name = "TSDdB_parallelToolStripMenuItem";
            this.TSDdB_parallelToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.TSDdB_parallelToolStripMenuItem.Text = "Parallel";
            this.TSDdB_parallelToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_parallelToolStripMenuItemClick);
            // 
            // TSDdB_customToolStripMenuItem
            // 
            this.TSDdB_customToolStripMenuItem.Name = "TSDdB_customToolStripMenuItem";
            this.TSDdB_customToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.TSDdB_customToolStripMenuItem.Text = "Custom";
            this.TSDdB_customToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_customToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TSDdB_MainGraphCursor
            // 
            this.TSDdB_MainGraphCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSDdB_MainGraphCursor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDdB_noneToolStripMenuItem,
            this.TSDdB_verticalLineToolStripMenuItem,
            this.TSDdB_horizontalLineToolStripMenuItem,
            this.TSDdB_crossToolStripMenuItem,
            this.TSDdB_graticuleToolStripMenuItem,
            this.TSDdB_squareToolStripMenuItem,
            this.TSDdB_circleToolStripMenuItem});
            this.TSDdB_MainGraphCursor.Image = global::Ctrl_GraphWindow.Icones.hand_point_finger_icone_6880_16;
            this.TSDdB_MainGraphCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDdB_MainGraphCursor.Name = "TSDdB_MainGraphCursor";
            this.TSDdB_MainGraphCursor.Size = new System.Drawing.Size(29, 22);
            this.TSDdB_MainGraphCursor.Text = "toolStripDropDownButton1";
            this.TSDdB_MainGraphCursor.ToolTipText = "Main graph cursor type";
            // 
            // TSDdB_noneToolStripMenuItem
            // 
            this.TSDdB_noneToolStripMenuItem.Name = "TSDdB_noneToolStripMenuItem";
            this.TSDdB_noneToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.TSDdB_noneToolStripMenuItem.Text = "None";
            this.TSDdB_noneToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_noneToolStripMenuItemClick);
            // 
            // TSDdB_verticalLineToolStripMenuItem
            // 
            this.TSDdB_verticalLineToolStripMenuItem.Name = "TSDdB_verticalLineToolStripMenuItem";
            this.TSDdB_verticalLineToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.TSDdB_verticalLineToolStripMenuItem.Text = "Vertical line";
            this.TSDdB_verticalLineToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_verticalLineToolStripMenuItemClick);
            // 
            // TSDdB_horizontalLineToolStripMenuItem
            // 
            this.TSDdB_horizontalLineToolStripMenuItem.Name = "TSDdB_horizontalLineToolStripMenuItem";
            this.TSDdB_horizontalLineToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.TSDdB_horizontalLineToolStripMenuItem.Text = "Horizontal line";
            this.TSDdB_horizontalLineToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_horizontalLineToolStripMenuItemClick);
            // 
            // TSDdB_crossToolStripMenuItem
            // 
            this.TSDdB_crossToolStripMenuItem.Name = "TSDdB_crossToolStripMenuItem";
            this.TSDdB_crossToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.TSDdB_crossToolStripMenuItem.Text = "Cross";
            this.TSDdB_crossToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_crossToolStripMenuItemClick);
            // 
            // TSDdB_graticuleToolStripMenuItem
            // 
            this.TSDdB_graticuleToolStripMenuItem.Name = "TSDdB_graticuleToolStripMenuItem";
            this.TSDdB_graticuleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.TSDdB_graticuleToolStripMenuItem.Text = "Graticule";
            this.TSDdB_graticuleToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_graticuleToolStripMenuItemClick);
            // 
            // TSDdB_squareToolStripMenuItem
            // 
            this.TSDdB_squareToolStripMenuItem.Name = "TSDdB_squareToolStripMenuItem";
            this.TSDdB_squareToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.TSDdB_squareToolStripMenuItem.Text = "Square";
            this.TSDdB_squareToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_squareToolStripMenuItemClick);
            // 
            // TSDdB_circleToolStripMenuItem
            // 
            this.TSDdB_circleToolStripMenuItem.Name = "TSDdB_circleToolStripMenuItem";
            this.TSDdB_circleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.TSDdB_circleToolStripMenuItem.Text = "Circle";
            this.TSDdB_circleToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_circleToolStripMenuItemClick);
            // 
            // TSDdB_CursorStep
            // 
            this.TSDdB_CursorStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSDdB_CursorStep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDdB_CurStep_01_ToolStripMenuItem,
            this.TSDdB_CurStep_02_ToolStripMenuItem,
            this.TSDdB_CurStep_05_ToolStripMenuItem,
            this.TSDdB_CurStep_1_ToolStripMenuItem,
            this.TSDdB_CurStep_2_ToolStripMenuItem,
            this.TSDdB_CurStep_5_ToolStripMenuItem,
            this.TSDdB_CurStep_10_ToolStripMenuItem,
            this.TSDdB_CurStep_20_ToolStripMenuItem,
            this.TSDdB_CurStep_50_ToolStripMenuItem});
            this.TSDdB_CursorStep.Image = global::Ctrl_GraphWindow.Icones.fleches_a_gauche_rouge_a_droite_icone_6392_16;
            this.TSDdB_CursorStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDdB_CursorStep.Name = "TSDdB_CursorStep";
            this.TSDdB_CursorStep.Size = new System.Drawing.Size(29, 22);
            this.TSDdB_CursorStep.Text = "toolStripDropDownButton1";
            this.TSDdB_CursorStep.ToolTipText = "Main cursor step";
            // 
            // TSDdB_CurStep_01_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_01_ToolStripMenuItem.Name = "TSDdB_CurStep_01_ToolStripMenuItem";
            this.TSDdB_CurStep_01_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_01_ToolStripMenuItem.Text = "0.1 %";
            this.TSDdB_CurStep_01_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_01_ToolStripMenuItemClick);
            // 
            // TSDdB_CurStep_02_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_02_ToolStripMenuItem.Name = "TSDdB_CurStep_02_ToolStripMenuItem";
            this.TSDdB_CurStep_02_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_02_ToolStripMenuItem.Text = "0.2 %";
            this.TSDdB_CurStep_02_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_02_ToolStripMenuItemClick);
            // 
            // TSDdB_CurStep_05_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_05_ToolStripMenuItem.Name = "TSDdB_CurStep_05_ToolStripMenuItem";
            this.TSDdB_CurStep_05_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_05_ToolStripMenuItem.Text = "0.5 %";
            this.TSDdB_CurStep_05_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_05_ToolStripMenuItemClick);
            // 
            // TSDdB_CurStep_1_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_1_ToolStripMenuItem.Name = "TSDdB_CurStep_1_ToolStripMenuItem";
            this.TSDdB_CurStep_1_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_1_ToolStripMenuItem.Text = "1 %";
            this.TSDdB_CurStep_1_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_1_ToolStripMenuItemClick);
            // 
            // TSDdB_CurStep_2_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_2_ToolStripMenuItem.Name = "TSDdB_CurStep_2_ToolStripMenuItem";
            this.TSDdB_CurStep_2_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_2_ToolStripMenuItem.Text = "2 %";
            this.TSDdB_CurStep_2_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_2_ToolStripMenuItemClick);
            // 
            // TSDdB_CurStep_5_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_5_ToolStripMenuItem.Name = "TSDdB_CurStep_5_ToolStripMenuItem";
            this.TSDdB_CurStep_5_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_5_ToolStripMenuItem.Text = "5 %";
            this.TSDdB_CurStep_5_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_5_ToolStripMenuItemClick);
            // 
            // TSDdB_CurStep_10_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_10_ToolStripMenuItem.Name = "TSDdB_CurStep_10_ToolStripMenuItem";
            this.TSDdB_CurStep_10_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_10_ToolStripMenuItem.Text = "10 %";
            this.TSDdB_CurStep_10_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_10_ToolStripMenuItemClick);
            // 
            // TSDdB_CurStep_20_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_20_ToolStripMenuItem.Name = "TSDdB_CurStep_20_ToolStripMenuItem";
            this.TSDdB_CurStep_20_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_20_ToolStripMenuItem.Text = "20 %";
            this.TSDdB_CurStep_20_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_20_ToolStripMenuItemClick);
            // 
            // TSDdB_CurStep_50_ToolStripMenuItem
            // 
            this.TSDdB_CurStep_50_ToolStripMenuItem.Name = "TSDdB_CurStep_50_ToolStripMenuItem";
            this.TSDdB_CurStep_50_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.TSDdB_CurStep_50_ToolStripMenuItem.Text = "50 %";
            this.TSDdB_CurStep_50_ToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_CurStep_50_ToolStripMenuItemClick);
            // 
            // TSDB_RefCursor
            // 
            this.TSDB_RefCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSDB_RefCursor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDB_RefCursor_Set,
            this.TSDB_RefCursor_Lock,
            this.TSDB_RefCursor_Clear,
            this.TSDB_RefCursor_Mode});
            this.TSDB_RefCursor.Image = global::Ctrl_GraphWindow.Icones.tack_tack_notes_icone_5500_16;
            this.TSDB_RefCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDB_RefCursor.Name = "TSDB_RefCursor";
            this.TSDB_RefCursor.Size = new System.Drawing.Size(29, 22);
            this.TSDB_RefCursor.Text = "TSDB_RefCursor";
            this.TSDB_RefCursor.ToolTipText = "Reference cursor";
            // 
            // TSDB_RefCursor_Set
            // 
            this.TSDB_RefCursor_Set.Name = "TSDB_RefCursor_Set";
            this.TSDB_RefCursor_Set.Size = new System.Drawing.Size(105, 22);
            this.TSDB_RefCursor_Set.Text = "Set";
            this.TSDB_RefCursor_Set.Click += new System.EventHandler(this.TSDB_RefCursor_SetClick);
            // 
            // TSDB_RefCursor_Lock
            // 
            this.TSDB_RefCursor_Lock.Name = "TSDB_RefCursor_Lock";
            this.TSDB_RefCursor_Lock.Size = new System.Drawing.Size(105, 22);
            this.TSDB_RefCursor_Lock.Text = "Lock";
            this.TSDB_RefCursor_Lock.Visible = false;
            this.TSDB_RefCursor_Lock.Click += new System.EventHandler(this.TSDB_RefCursor_LockClick);
            // 
            // TSDB_RefCursor_Clear
            // 
            this.TSDB_RefCursor_Clear.Name = "TSDB_RefCursor_Clear";
            this.TSDB_RefCursor_Clear.Size = new System.Drawing.Size(105, 22);
            this.TSDB_RefCursor_Clear.Text = "Clear";
            this.TSDB_RefCursor_Clear.Click += new System.EventHandler(this.TSDB_RefCursor_ClearClick);
            // 
            // TSDB_RefCursor_Mode
            // 
            this.TSDB_RefCursor_Mode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDB_RefCursor_Mode_None,
            this.TSDB_RefCursor_Mode_Vertical,
            this.TSDB_RefCursor_Mode_Horizontal});
            this.TSDB_RefCursor_Mode.Name = "TSDB_RefCursor_Mode";
            this.TSDB_RefCursor_Mode.Size = new System.Drawing.Size(105, 22);
            this.TSDB_RefCursor_Mode.Text = "Mode";
            // 
            // TSDB_RefCursor_Mode_None
            // 
            this.TSDB_RefCursor_Mode_None.Name = "TSDB_RefCursor_Mode_None";
            this.TSDB_RefCursor_Mode_None.Size = new System.Drawing.Size(151, 22);
            this.TSDB_RefCursor_Mode_None.Text = "None";
            this.TSDB_RefCursor_Mode_None.Click += new System.EventHandler(this.TSDB_RefCursor_Mode_NoneClick);
            // 
            // TSDB_RefCursor_Mode_Vertical
            // 
            this.TSDB_RefCursor_Mode_Vertical.Name = "TSDB_RefCursor_Mode_Vertical";
            this.TSDB_RefCursor_Mode_Vertical.Size = new System.Drawing.Size(151, 22);
            this.TSDB_RefCursor_Mode_Vertical.Text = "Vertical line";
            this.TSDB_RefCursor_Mode_Vertical.Click += new System.EventHandler(this.TSDB_RefCursor_Mode_VerticalClick);
            // 
            // TSDB_RefCursor_Mode_Horizontal
            // 
            this.TSDB_RefCursor_Mode_Horizontal.Name = "TSDB_RefCursor_Mode_Horizontal";
            this.TSDB_RefCursor_Mode_Horizontal.Size = new System.Drawing.Size(151, 22);
            this.TSDB_RefCursor_Mode_Horizontal.Text = "Horizontal line";
            this.TSDB_RefCursor_Mode_Horizontal.Click += new System.EventHandler(this.TSDB_RefCursor_Mode_HorizontalClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // TSDdB_ZoomMode
            // 
            this.TSDdB_ZoomMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSDdB_ZoomMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDdB_zoomXToolStripMenuItem,
            this.TSDdB_zoomYToolStripMenuItem,
            this.TSDdB_zoomXYToolStripMenuItem,
            this.toolStripMenuItem2,
            this.TSDdB_zoomDisabledToolStripMenuItem});
            this.TSDdB_ZoomMode.Image = global::Ctrl_GraphWindow.Icones.research_zoom_icone_6545_16;
            this.TSDdB_ZoomMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDdB_ZoomMode.Name = "TSDdB_ZoomMode";
            this.TSDdB_ZoomMode.Size = new System.Drawing.Size(29, 22);
            this.TSDdB_ZoomMode.Text = "toolStripDropDownButton1";
            this.TSDdB_ZoomMode.ToolTipText = "Zoom mode";
            // 
            // TSDdB_zoomXToolStripMenuItem
            // 
            this.TSDdB_zoomXToolStripMenuItem.Name = "TSDdB_zoomXToolStripMenuItem";
            this.TSDdB_zoomXToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.TSDdB_zoomXToolStripMenuItem.Text = "Zoom X";
            this.TSDdB_zoomXToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_zoomXToolStripMenuItemClick);
            // 
            // TSDdB_zoomYToolStripMenuItem
            // 
            this.TSDdB_zoomYToolStripMenuItem.Name = "TSDdB_zoomYToolStripMenuItem";
            this.TSDdB_zoomYToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.TSDdB_zoomYToolStripMenuItem.Text = "Zoom Y";
            this.TSDdB_zoomYToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_zoomYToolStripMenuItemClick);
            // 
            // TSDdB_zoomXYToolStripMenuItem
            // 
            this.TSDdB_zoomXYToolStripMenuItem.Name = "TSDdB_zoomXYToolStripMenuItem";
            this.TSDdB_zoomXYToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.TSDdB_zoomXYToolStripMenuItem.Text = "Zoom XY";
            this.TSDdB_zoomXYToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_zoomXYToolStripMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 6);
            // 
            // TSDdB_zoomDisabledToolStripMenuItem
            // 
            this.TSDdB_zoomDisabledToolStripMenuItem.Name = "TSDdB_zoomDisabledToolStripMenuItem";
            this.TSDdB_zoomDisabledToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.TSDdB_zoomDisabledToolStripMenuItem.Text = "Zoom disabled";
            this.TSDdB_zoomDisabledToolStripMenuItem.Click += new System.EventHandler(this.TSDdB_zoomDisabledToolStripMenuItemClick);
            // 
            // TSDdB_ZoomFactor
            // 
            this.TSDdB_ZoomFactor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSDdB_ZoomFactor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDdB_ZoomFactor_2,
            this.TSDdB_ZoomFactor_4,
            this.TSDdB_ZoomFactor_8,
            this.TSDdB_ZoomFactor_16,
            this.TSDdB_ZoomFactor_32});
            this.TSDdB_ZoomFactor.Image = global::Ctrl_GraphWindow.Icones.ZoomFactor_16;
            this.TSDdB_ZoomFactor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSDdB_ZoomFactor.Name = "TSDdB_ZoomFactor";
            this.TSDdB_ZoomFactor.Size = new System.Drawing.Size(29, 22);
            this.TSDdB_ZoomFactor.Text = "toolStripDropDownButton1";
            this.TSDdB_ZoomFactor.ToolTipText = "Zoom factor";
            // 
            // TSDdB_ZoomFactor_2
            // 
            this.TSDdB_ZoomFactor_2.Name = "TSDdB_ZoomFactor_2";
            this.TSDdB_ZoomFactor_2.Size = new System.Drawing.Size(94, 22);
            this.TSDdB_ZoomFactor_2.Text = "x 2";
            this.TSDdB_ZoomFactor_2.Click += new System.EventHandler(this.TSDdB_ZoomFactor_2Click);
            // 
            // TSDdB_ZoomFactor_4
            // 
            this.TSDdB_ZoomFactor_4.Name = "TSDdB_ZoomFactor_4";
            this.TSDdB_ZoomFactor_4.Size = new System.Drawing.Size(94, 22);
            this.TSDdB_ZoomFactor_4.Text = "x 4";
            this.TSDdB_ZoomFactor_4.Click += new System.EventHandler(this.TSDdB_ZoomFactor_4Click);
            // 
            // TSDdB_ZoomFactor_8
            // 
            this.TSDdB_ZoomFactor_8.Name = "TSDdB_ZoomFactor_8";
            this.TSDdB_ZoomFactor_8.Size = new System.Drawing.Size(94, 22);
            this.TSDdB_ZoomFactor_8.Text = "x 8";
            this.TSDdB_ZoomFactor_8.Click += new System.EventHandler(this.TSDdB_ZoomFactor_8Click);
            // 
            // TSDdB_ZoomFactor_16
            // 
            this.TSDdB_ZoomFactor_16.Name = "TSDdB_ZoomFactor_16";
            this.TSDdB_ZoomFactor_16.Size = new System.Drawing.Size(94, 22);
            this.TSDdB_ZoomFactor_16.Text = "x 16";
            this.TSDdB_ZoomFactor_16.Click += new System.EventHandler(this.TSDdB_ZoomFactor_16Click);
            // 
            // TSDdB_ZoomFactor_32
            // 
            this.TSDdB_ZoomFactor_32.Name = "TSDdB_ZoomFactor_32";
            this.TSDdB_ZoomFactor_32.Size = new System.Drawing.Size(94, 22);
            this.TSDdB_ZoomFactor_32.Text = "x 32";
            this.TSDdB_ZoomFactor_32.Click += new System.EventHandler(this.TSDdB_ZoomFactor_32Click);
            // 
            // TSB_ZoomPlus
            // 
            this.TSB_ZoomPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ZoomPlus.Image = global::Ctrl_GraphWindow.Icones.zoom_icone_6603_16;
            this.TSB_ZoomPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ZoomPlus.Name = "TSB_ZoomPlus";
            this.TSB_ZoomPlus.Size = new System.Drawing.Size(23, 22);
            this.TSB_ZoomPlus.Text = "toolStripButton1";
            this.TSB_ZoomPlus.ToolTipText = "Zoom +";
            this.TSB_ZoomPlus.Click += new System.EventHandler(this.TSB_ZoomPlusClick);
            // 
            // TSB_ZoomMinus
            // 
            this.TSB_ZoomMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ZoomMinus.Image = global::Ctrl_GraphWindow.Icones.zoom_back_icone_7248_16;
            this.TSB_ZoomMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ZoomMinus.Name = "TSB_ZoomMinus";
            this.TSB_ZoomMinus.Size = new System.Drawing.Size(23, 22);
            this.TSB_ZoomMinus.Text = "toolStripButton2";
            this.TSB_ZoomMinus.ToolTipText = "Zoom -";
            this.TSB_ZoomMinus.Click += new System.EventHandler(this.TSB_ZoomMinusClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_Snapshot
            // 
            this.TSB_Snapshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Snapshot.Image = global::Ctrl_GraphWindow.Icones.camera_icone_8948_16;
            this.TSB_Snapshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Snapshot.Name = "TSB_Snapshot";
            this.TSB_Snapshot.Size = new System.Drawing.Size(23, 22);
            this.TSB_Snapshot.Text = "TSB_Snapshot";
            this.TSB_Snapshot.ToolTipText = "Make a snapshot image of the graphic";
            this.TSB_Snapshot.Click += new System.EventHandler(this.TSB_SnapshotClick);
            // 
            // TSB_Print
            // 
            this.TSB_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Print.Image = global::Ctrl_GraphWindow.Icones.printer_icone_7966_16;
            this.TSB_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Print.Name = "TSB_Print";
            this.TSB_Print.Size = new System.Drawing.Size(23, 22);
            this.TSB_Print.Text = "toolStripButton1";
            this.TSB_Print.ToolTipText = "Print graphic";
            this.TSB_Print.Click += new System.EventHandler(this.TSB_PrintClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_RT_Play
            // 
            this.TSB_RT_Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_RT_Play.Image = global::Ctrl_GraphWindow.Icones.play_icone_6427;
            this.TSB_RT_Play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_RT_Play.Name = "TSB_RT_Play";
            this.TSB_RT_Play.Size = new System.Drawing.Size(23, 22);
            this.TSB_RT_Play.Text = "toolStripButton1";
            this.TSB_RT_Play.ToolTipText = "Run";
            this.TSB_RT_Play.Click += new System.EventHandler(this.TSB_RT_Play_Click);
            // 
            // TSB_RT_Break
            // 
            this.TSB_RT_Break.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_RT_Break.Image = global::Ctrl_GraphWindow.Icones.break_icone_9058;
            this.TSB_RT_Break.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_RT_Break.Name = "TSB_RT_Break";
            this.TSB_RT_Break.Size = new System.Drawing.Size(23, 22);
            this.TSB_RT_Break.Text = "toolStripButton2";
            this.TSB_RT_Break.ToolTipText = "Break";
            this.TSB_RT_Break.Click += new System.EventHandler(this.TSB_RT_Break_Click);
            // 
            // TSB_RT_Stop
            // 
            this.TSB_RT_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_RT_Stop.Image = global::Ctrl_GraphWindow.Icones.stop_icone_5072;
            this.TSB_RT_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_RT_Stop.Name = "TSB_RT_Stop";
            this.TSB_RT_Stop.Size = new System.Drawing.Size(23, 22);
            this.TSB_RT_Stop.Text = "toolStripButton3";
            this.TSB_RT_Stop.ToolTipText = "Stop";
            this.TSB_RT_Stop.Click += new System.EventHandler(this.TSB_RT_Stop_Click);
            // 
            // TSCmb_InitialStage
            // 
            this.TSCmb_InitialStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TSCmb_InitialStage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TSCmb_InitialStage.Name = "TSCmb_InitialStage";
            this.TSCmb_InitialStage.Size = new System.Drawing.Size(121, 25);
            this.TSCmb_InitialStage.Visible = false;
            // 
            // TSB_Replot
            // 
            this.TSB_Replot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Replot.Image = global::Ctrl_GraphWindow.Icones.refresh_reload_icone_7588;
            this.TSB_Replot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Replot.Name = "TSB_Replot";
            this.TSB_Replot.Size = new System.Drawing.Size(23, 22);
            this.TSB_Replot.Text = "toolStripButton1";
            this.TSB_Replot.ToolTipText = "Re-Plot";
            this.TSB_Replot.Visible = false;
            this.TSB_Replot.Click += new System.EventHandler(this.TSB_Replot_Click);
            // 
            // TSB_SeeStep
            // 
            this.TSB_SeeStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_SeeStep.Image = global::Ctrl_GraphWindow.Icones.eye_previewer_icone_3911;
            this.TSB_SeeStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_SeeStep.Name = "TSB_SeeStep";
            this.TSB_SeeStep.Size = new System.Drawing.Size(23, 22);
            this.TSB_SeeStep.Text = "toolStripButton3";
            this.TSB_SeeStep.ToolTipText = "See graphic picture step";
            this.TSB_SeeStep.Visible = false;
            this.TSB_SeeStep.Click += new System.EventHandler(this.TSB_SeeStep_Click);
            // 
            // TSB_SeePrevStep
            // 
            this.TSB_SeePrevStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_SeePrevStep.Image = global::Ctrl_GraphWindow.Icones.precedent_icone_5813;
            this.TSB_SeePrevStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_SeePrevStep.Name = "TSB_SeePrevStep";
            this.TSB_SeePrevStep.Size = new System.Drawing.Size(23, 22);
            this.TSB_SeePrevStep.Text = "toolStripButton2";
            this.TSB_SeePrevStep.ToolTipText = "See previous graphic picture step";
            this.TSB_SeePrevStep.Visible = false;
            this.TSB_SeePrevStep.Click += new System.EventHandler(this.TSB_SeePrevStep_Click);
            // 
            // TSB_SeeNextStep
            // 
            this.TSB_SeeNextStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_SeeNextStep.Image = global::Ctrl_GraphWindow.Icones.suivant_icone_9262;
            this.TSB_SeeNextStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_SeeNextStep.Name = "TSB_SeeNextStep";
            this.TSB_SeeNextStep.Size = new System.Drawing.Size(23, 22);
            this.TSB_SeeNextStep.Text = "toolStripButton1";
            this.TSB_SeeNextStep.ToolTipText = "See next graphic picture step";
            this.TSB_SeeNextStep.Visible = false;
            this.TSB_SeeNextStep.Click += new System.EventHandler(this.TSB_SeeNextStep_Click);
            // 
            // TSL_PlotCount
            // 
            this.TSL_PlotCount.Name = "TSL_PlotCount";
            this.TSL_PlotCount.Size = new System.Drawing.Size(36, 22);
            this.TSL_PlotCount.Text = "Plots:";
            this.TSL_PlotCount.Visible = false;
            // 
            // TSL_PlotLast
            // 
            this.TSL_PlotLast.Name = "TSL_PlotLast";
            this.TSL_PlotLast.Size = new System.Drawing.Size(31, 22);
            this.TSL_PlotLast.Text = "Last:";
            this.TSL_PlotLast.Visible = false;
            // 
            // TSL_PlotAvg
            // 
            this.TSL_PlotAvg.Name = "TSL_PlotAvg";
            this.TSL_PlotAvg.Size = new System.Drawing.Size(31, 22);
            this.TSL_PlotAvg.Text = "Avg:";
            this.TSL_PlotAvg.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Ctrl_ChannelList);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(814, 374);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 1;
            // 
            // Ctrl_ChannelList
            // 
            this.Ctrl_ChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ctrl_ChannelList.Location = new System.Drawing.Point(2, 3);
            this.Ctrl_ChannelList.Name = "Ctrl_ChannelList";
            this.Ctrl_ChannelList.Size = new System.Drawing.Size(84, 368);
            this.Ctrl_ChannelList.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Cmd_ZoomYPosition);
            this.splitContainer2.Panel1.Controls.Add(this.Cmd_ZoomXPosition);
            this.splitContainer2.Panel1.Controls.Add(this.Pic_Graphic);
            this.splitContainer2.Panel1.Controls.Add(this.Pic_GraphFrame);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Grid_Legend);
            this.splitContainer2.Size = new System.Drawing.Size(721, 374);
            this.splitContainer2.SplitterDistance = 592;
            this.splitContainer2.TabIndex = 0;
            // 
            // Cmd_ZoomYPosition
            // 
            this.Cmd_ZoomYPosition.FlatAppearance.BorderSize = 0;
            this.Cmd_ZoomYPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmd_ZoomYPosition.Location = new System.Drawing.Point(491, 72);
            this.Cmd_ZoomYPosition.Margin = new System.Windows.Forms.Padding(0);
            this.Cmd_ZoomYPosition.MinimumSize = new System.Drawing.Size(5, 5);
            this.Cmd_ZoomYPosition.Name = "Cmd_ZoomYPosition";
            this.Cmd_ZoomYPosition.Size = new System.Drawing.Size(5, 75);
            this.Cmd_ZoomYPosition.TabIndex = 6;
            this.Cmd_ZoomYPosition.UseVisualStyleBackColor = true;
            this.Cmd_ZoomYPosition.Visible = false;
            this.Cmd_ZoomYPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cmd_ZoomYPositionMouseDown);
            this.Cmd_ZoomYPosition.MouseEnter += new System.EventHandler(this.Cmd_ZoomYPositionMouseEnter);
            this.Cmd_ZoomYPosition.MouseLeave += new System.EventHandler(this.Cmd_ZoomYPositionMouseLeave);
            this.Cmd_ZoomYPosition.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cmd_ZoomYPositionMouseMove);
            this.Cmd_ZoomYPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Cmd_ZoomYPositionMouseUp);
            // 
            // Cmd_ZoomXPosition
            // 
            this.Cmd_ZoomXPosition.FlatAppearance.BorderSize = 0;
            this.Cmd_ZoomXPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmd_ZoomXPosition.Location = new System.Drawing.Point(96, 15);
            this.Cmd_ZoomXPosition.Margin = new System.Windows.Forms.Padding(0);
            this.Cmd_ZoomXPosition.MinimumSize = new System.Drawing.Size(5, 5);
            this.Cmd_ZoomXPosition.Name = "Cmd_ZoomXPosition";
            this.Cmd_ZoomXPosition.Size = new System.Drawing.Size(75, 5);
            this.Cmd_ZoomXPosition.TabIndex = 5;
            this.Cmd_ZoomXPosition.UseVisualStyleBackColor = true;
            this.Cmd_ZoomXPosition.Visible = false;
            this.Cmd_ZoomXPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cmd_ZoomXPositionMouseDown);
            this.Cmd_ZoomXPosition.MouseEnter += new System.EventHandler(this.Cmd_ZoomXPositionMouseEnter);
            this.Cmd_ZoomXPosition.MouseLeave += new System.EventHandler(this.Cmd_ZoomXPositionMouseLeave);
            this.Cmd_ZoomXPosition.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cmd_ZoomXPositionMouseMove);
            this.Cmd_ZoomXPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Cmd_ZoomXPositionMouseUp);
            // 
            // Pic_Graphic
            // 
            this.Pic_Graphic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Pic_Graphic.Location = new System.Drawing.Point(110, 41);
            this.Pic_Graphic.Margin = new System.Windows.Forms.Padding(0);
            this.Pic_Graphic.Name = "Pic_Graphic";
            this.Pic_Graphic.Size = new System.Drawing.Size(379, 255);
            this.Pic_Graphic.TabIndex = 4;
            this.Pic_Graphic.TabStop = false;
            this.Pic_Graphic.SizeChanged += new System.EventHandler(this.Pic_Graphic_SizeChanged);
            this.Pic_Graphic.DragDrop += new System.Windows.Forms.DragEventHandler(this.Pic_GraphicDragDrop);
            this.Pic_Graphic.DragEnter += new System.Windows.Forms.DragEventHandler(this.Pic_GraphicDragEnter);
            this.Pic_Graphic.DoubleClick += new System.EventHandler(this.Pic_Graphic_DoubleClick);
            this.Pic_Graphic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_GraphicMouseDown);
            this.Pic_Graphic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_GraphicMouseMove);
            this.Pic_Graphic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pic_GraphicMouseUp);
            this.Pic_Graphic.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Pic_GraphicPreviewKeyDown);
            // 
            // Pic_GraphFrame
            // 
            this.Pic_GraphFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pic_GraphFrame.BackColor = System.Drawing.Color.Black;
            this.Pic_GraphFrame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pic_GraphFrame.Location = new System.Drawing.Point(1, 1);
            this.Pic_GraphFrame.Margin = new System.Windows.Forms.Padding(1);
            this.Pic_GraphFrame.Name = "Pic_GraphFrame";
            this.Pic_GraphFrame.Size = new System.Drawing.Size(590, 373);
            this.Pic_GraphFrame.TabIndex = 3;
            this.Pic_GraphFrame.TabStop = false;
            this.Pic_GraphFrame.SizeChanged += new System.EventHandler(this.Pic_GraphFrameSizeChanged);
            this.Pic_GraphFrame.DragDrop += new System.Windows.Forms.DragEventHandler(this.Pic_GraphFrameDragDrop);
            this.Pic_GraphFrame.DragEnter += new System.Windows.Forms.DragEventHandler(this.Pic_GraphFrameDragEnter);
            // 
            // Grid_Legend
            // 
            this.Grid_Legend.AllowUserToAddRows = false;
            this.Grid_Legend.AllowUserToDeleteRows = false;
            this.Grid_Legend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Legend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Legend.ColumnHeadersVisible = false;
            this.Grid_Legend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Legend_Col_Label,
            this.Legend_Col_Value,
            this.Legend_Col_Unit,
            this.Legend_Col_GraphMin,
            this.Legend_Col_GraphMax,
            this.Legend_Col_GraphAvg,
            this.Legend_Col_RefValue,
            this.Legend_Col_RefDiff,
            this.Legend_Col_RefDiffPerc,
            this.Legend_Col_RefGradient});
            this.Grid_Legend.Location = new System.Drawing.Point(3, 3);
            this.Grid_Legend.MultiSelect = false;
            this.Grid_Legend.Name = "Grid_Legend";
            this.Grid_Legend.ReadOnly = true;
            this.Grid_Legend.RowHeadersVisible = false;
            this.Grid_Legend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Legend.Size = new System.Drawing.Size(119, 368);
            this.Grid_Legend.TabIndex = 0;
            this.Grid_Legend.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid_Legend_CellMouseDoubleClick);
            this.Grid_Legend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_Legend_KeyDown);
            this.Grid_Legend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Grid_Legend_MouseDown);
            // 
            // Legend_Col_Label
            // 
            this.Legend_Col_Label.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Legend_Col_Label.DefaultCellStyle = dataGridViewCellStyle1;
            this.Legend_Col_Label.HeaderText = "Label";
            this.Legend_Col_Label.Name = "Legend_Col_Label";
            this.Legend_Col_Label.ReadOnly = true;
            this.Legend_Col_Label.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Legend_Col_Value
            // 
            this.Legend_Col_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_Value.DefaultCellStyle = dataGridViewCellStyle2;
            this.Legend_Col_Value.HeaderText = "Value";
            this.Legend_Col_Value.Name = "Legend_Col_Value";
            this.Legend_Col_Value.ReadOnly = true;
            this.Legend_Col_Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_Value.Width = 5;
            // 
            // Legend_Col_Unit
            // 
            this.Legend_Col_Unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_Unit.DefaultCellStyle = dataGridViewCellStyle3;
            this.Legend_Col_Unit.HeaderText = "Unit";
            this.Legend_Col_Unit.Name = "Legend_Col_Unit";
            this.Legend_Col_Unit.ReadOnly = true;
            this.Legend_Col_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_Unit.Width = 5;
            // 
            // Legend_Col_GraphMin
            // 
            this.Legend_Col_GraphMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_GraphMin.DefaultCellStyle = dataGridViewCellStyle4;
            this.Legend_Col_GraphMin.HeaderText = "Min";
            this.Legend_Col_GraphMin.Name = "Legend_Col_GraphMin";
            this.Legend_Col_GraphMin.ReadOnly = true;
            this.Legend_Col_GraphMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_GraphMin.Width = 5;
            // 
            // Legend_Col_GraphMax
            // 
            this.Legend_Col_GraphMax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_GraphMax.DefaultCellStyle = dataGridViewCellStyle5;
            this.Legend_Col_GraphMax.HeaderText = "Max";
            this.Legend_Col_GraphMax.Name = "Legend_Col_GraphMax";
            this.Legend_Col_GraphMax.ReadOnly = true;
            this.Legend_Col_GraphMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_GraphMax.Width = 5;
            // 
            // Legend_Col_GraphAvg
            // 
            this.Legend_Col_GraphAvg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_GraphAvg.DefaultCellStyle = dataGridViewCellStyle6;
            this.Legend_Col_GraphAvg.HeaderText = "Avg";
            this.Legend_Col_GraphAvg.Name = "Legend_Col_GraphAvg";
            this.Legend_Col_GraphAvg.ReadOnly = true;
            this.Legend_Col_GraphAvg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_GraphAvg.Width = 5;
            // 
            // Legend_Col_RefValue
            // 
            this.Legend_Col_RefValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_RefValue.DefaultCellStyle = dataGridViewCellStyle7;
            this.Legend_Col_RefValue.HeaderText = "Ref value";
            this.Legend_Col_RefValue.Name = "Legend_Col_RefValue";
            this.Legend_Col_RefValue.ReadOnly = true;
            this.Legend_Col_RefValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_RefValue.Visible = false;
            // 
            // Legend_Col_RefDiff
            // 
            this.Legend_Col_RefDiff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_RefDiff.DefaultCellStyle = dataGridViewCellStyle8;
            this.Legend_Col_RefDiff.HeaderText = "Diff";
            this.Legend_Col_RefDiff.Name = "Legend_Col_RefDiff";
            this.Legend_Col_RefDiff.ReadOnly = true;
            this.Legend_Col_RefDiff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_RefDiff.Visible = false;
            // 
            // Legend_Col_RefDiffPerc
            // 
            this.Legend_Col_RefDiffPerc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_RefDiffPerc.DefaultCellStyle = dataGridViewCellStyle9;
            this.Legend_Col_RefDiffPerc.HeaderText = "Diff %";
            this.Legend_Col_RefDiffPerc.Name = "Legend_Col_RefDiffPerc";
            this.Legend_Col_RefDiffPerc.ReadOnly = true;
            this.Legend_Col_RefDiffPerc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_RefDiffPerc.Visible = false;
            // 
            // Legend_Col_RefGradient
            // 
            this.Legend_Col_RefGradient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Legend_Col_RefGradient.DefaultCellStyle = dataGridViewCellStyle10;
            this.Legend_Col_RefGradient.HeaderText = "Gradient";
            this.Legend_Col_RefGradient.Name = "Legend_Col_RefGradient";
            this.Legend_Col_RefGradient.ReadOnly = true;
            this.Legend_Col_RefGradient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Legend_Col_RefGradient.Visible = false;
            // 
            // Dlg_OpenData
            // 
            this.Dlg_OpenData.Filter = "CSV File|*.csv";
            // 
            // Context_PicGraphic_ZoomStats
            // 
            this.Context_PicGraphic_ZoomStats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.statisticsToolStripMenuItem});
            this.Context_PicGraphic_ZoomStats.Name = "Context_PicGraphic_Zoom";
            this.Context_PicGraphic_ZoomStats.Size = new System.Drawing.Size(121, 48);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.ZoomToolStripMenuItemClick);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.StatisticsToolStripMenuItemClick);
            // 
            // Context_PicGraph_Options
            // 
            this.Context_PicGraph_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RT_PlaytoolStripMenuItem,
            this.RT_BreaktoolStripMenuItem,
            this.RT_StoptoolStripMenuItem,
            this.toolStripSeparator8,
            this.ZoomPlustoolStripMenuItem,
            this.ZoomMinustoolStripMenuItem,
            this.ZoomMintoolStripMenuItem,
            this.ZoomMaxtoolStripMenuItem,
            this.ZoomModetoolStripMenuItem,
            this.ZoomFactortoolStripMenuItem,
            this.toolStripSeparator3,
            this.cursorToolStripMenuItem,
            this.ReferenceCursorToolStripMenuItem,
            this.toolStripMenuItem1,
            this.graphLayoutToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.toolStripMenuItem7,
            this.snapshotToolStripMenuItem,
            this.printToolStripMenuItem});
            this.Context_PicGraph_Options.Name = "Context_PicGraph_Options";
            this.Context_PicGraph_Options.Size = new System.Drawing.Size(163, 358);
            // 
            // RT_PlaytoolStripMenuItem
            // 
            this.RT_PlaytoolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.play_icone_6427;
            this.RT_PlaytoolStripMenuItem.Name = "RT_PlaytoolStripMenuItem";
            this.RT_PlaytoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.RT_PlaytoolStripMenuItem.Text = "Run";
            this.RT_PlaytoolStripMenuItem.Click += new System.EventHandler(this.RT_PlaytoolStripMenuItem_Click);
            // 
            // RT_BreaktoolStripMenuItem
            // 
            this.RT_BreaktoolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.break_icone_9058;
            this.RT_BreaktoolStripMenuItem.Name = "RT_BreaktoolStripMenuItem";
            this.RT_BreaktoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.RT_BreaktoolStripMenuItem.Text = "Break";
            this.RT_BreaktoolStripMenuItem.Click += new System.EventHandler(this.RT_BreaktoolStripMenuItem_Click);
            // 
            // RT_StoptoolStripMenuItem
            // 
            this.RT_StoptoolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.stop_icone_5072;
            this.RT_StoptoolStripMenuItem.Name = "RT_StoptoolStripMenuItem";
            this.RT_StoptoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.RT_StoptoolStripMenuItem.Text = "Stop";
            this.RT_StoptoolStripMenuItem.Click += new System.EventHandler(this.RT_StoptoolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(159, 6);
            // 
            // ZoomPlustoolStripMenuItem
            // 
            this.ZoomPlustoolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.zoom_icone_6603_16;
            this.ZoomPlustoolStripMenuItem.Name = "ZoomPlustoolStripMenuItem";
            this.ZoomPlustoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ZoomPlustoolStripMenuItem.Text = "Zoom +";
            this.ZoomPlustoolStripMenuItem.Click += new System.EventHandler(this.ZoomPlustoolStripMenuItemClick);
            // 
            // ZoomMinustoolStripMenuItem
            // 
            this.ZoomMinustoolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.zoom_back_icone_7248_16;
            this.ZoomMinustoolStripMenuItem.Name = "ZoomMinustoolStripMenuItem";
            this.ZoomMinustoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ZoomMinustoolStripMenuItem.Text = "Zoom -";
            this.ZoomMinustoolStripMenuItem.Click += new System.EventHandler(this.ZoomMinustoolStripMenuItemClick);
            // 
            // ZoomMintoolStripMenuItem
            // 
            this.ZoomMintoolStripMenuItem.Name = "ZoomMintoolStripMenuItem";
            this.ZoomMintoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ZoomMintoolStripMenuItem.Text = "Zoom min";
            this.ZoomMintoolStripMenuItem.Click += new System.EventHandler(this.ZoomMintoolStripMenuItemClick);
            // 
            // ZoomMaxtoolStripMenuItem
            // 
            this.ZoomMaxtoolStripMenuItem.Name = "ZoomMaxtoolStripMenuItem";
            this.ZoomMaxtoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ZoomMaxtoolStripMenuItem.Text = "Zoom max";
            this.ZoomMaxtoolStripMenuItem.Click += new System.EventHandler(this.ZoomMaxtoolStripMenuItemClick);
            // 
            // ZoomModetoolStripMenuItem
            // 
            this.ZoomModetoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomMode_X_ToolStripMenuItem,
            this.ZoomMode_Y_ToolStripMenuItem,
            this.ZoomMode_XY_ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.ZoomMode_Disabled_ToolStripMenuItem});
            this.ZoomModetoolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.research_zoom_icone_6545_16;
            this.ZoomModetoolStripMenuItem.Name = "ZoomModetoolStripMenuItem";
            this.ZoomModetoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ZoomModetoolStripMenuItem.Text = "Zoom mode";
            // 
            // ZoomMode_X_ToolStripMenuItem
            // 
            this.ZoomMode_X_ToolStripMenuItem.Name = "ZoomMode_X_ToolStripMenuItem";
            this.ZoomMode_X_ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ZoomMode_X_ToolStripMenuItem.Text = "Zoom X";
            this.ZoomMode_X_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomMode_X_ToolStripMenuItemClick);
            // 
            // ZoomMode_Y_ToolStripMenuItem
            // 
            this.ZoomMode_Y_ToolStripMenuItem.Name = "ZoomMode_Y_ToolStripMenuItem";
            this.ZoomMode_Y_ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ZoomMode_Y_ToolStripMenuItem.Text = "Zoom Y";
            this.ZoomMode_Y_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomMode_Y_ToolStripMenuItemClick);
            // 
            // ZoomMode_XY_ToolStripMenuItem
            // 
            this.ZoomMode_XY_ToolStripMenuItem.Name = "ZoomMode_XY_ToolStripMenuItem";
            this.ZoomMode_XY_ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ZoomMode_XY_ToolStripMenuItem.Text = "Zoom XY";
            this.ZoomMode_XY_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomMode_XY_ToolStripMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(150, 6);
            // 
            // ZoomMode_Disabled_ToolStripMenuItem
            // 
            this.ZoomMode_Disabled_ToolStripMenuItem.Name = "ZoomMode_Disabled_ToolStripMenuItem";
            this.ZoomMode_Disabled_ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ZoomMode_Disabled_ToolStripMenuItem.Text = "Zoom disabled";
            this.ZoomMode_Disabled_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomMode_Disabled_ToolStripMenuItemClick);
            // 
            // ZoomFactortoolStripMenuItem
            // 
            this.ZoomFactortoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomFactor_2_ToolStripMenuItem,
            this.ZoomFactor_4_ToolStripMenuItem,
            this.ZoomFactor_8_ToolStripMenuItem,
            this.ZoomFactor_16_ToolStripMenuItem,
            this.ZoomFactor_32_ToolStripMenuItem});
            this.ZoomFactortoolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.ZoomFactor_16;
            this.ZoomFactortoolStripMenuItem.Name = "ZoomFactortoolStripMenuItem";
            this.ZoomFactortoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ZoomFactortoolStripMenuItem.Text = "Zoom factor";
            // 
            // ZoomFactor_2_ToolStripMenuItem
            // 
            this.ZoomFactor_2_ToolStripMenuItem.Name = "ZoomFactor_2_ToolStripMenuItem";
            this.ZoomFactor_2_ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ZoomFactor_2_ToolStripMenuItem.Text = "x 2";
            this.ZoomFactor_2_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomFactor_2_ToolStripMenuItemClick);
            // 
            // ZoomFactor_4_ToolStripMenuItem
            // 
            this.ZoomFactor_4_ToolStripMenuItem.Name = "ZoomFactor_4_ToolStripMenuItem";
            this.ZoomFactor_4_ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ZoomFactor_4_ToolStripMenuItem.Text = "x 4";
            this.ZoomFactor_4_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomFactor_4_ToolStripMenuItemClick);
            // 
            // ZoomFactor_8_ToolStripMenuItem
            // 
            this.ZoomFactor_8_ToolStripMenuItem.Name = "ZoomFactor_8_ToolStripMenuItem";
            this.ZoomFactor_8_ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ZoomFactor_8_ToolStripMenuItem.Text = "x 8";
            this.ZoomFactor_8_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomFactor_8_ToolStripMenuItemClick);
            // 
            // ZoomFactor_16_ToolStripMenuItem
            // 
            this.ZoomFactor_16_ToolStripMenuItem.Name = "ZoomFactor_16_ToolStripMenuItem";
            this.ZoomFactor_16_ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ZoomFactor_16_ToolStripMenuItem.Text = "x 16";
            this.ZoomFactor_16_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomFactor_16_ToolStripMenuItemClick);
            // 
            // ZoomFactor_32_ToolStripMenuItem
            // 
            this.ZoomFactor_32_ToolStripMenuItem.Name = "ZoomFactor_32_ToolStripMenuItem";
            this.ZoomFactor_32_ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ZoomFactor_32_ToolStripMenuItem.Text = "x 32";
            this.ZoomFactor_32_ToolStripMenuItem.Click += new System.EventHandler(this.ZoomFactor_32_ToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(159, 6);
            // 
            // cursorToolStripMenuItem
            // 
            this.cursorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cursor_noneToolStripMenuItem,
            this.Cursor_verticalLineToolStripMenuItem,
            this.Cursor_horizontalLineToolStripMenuItem,
            this.Cursor_crossToolStripMenuItem,
            this.Cursor_graticuleToolStripMenuItem,
            this.Cursor_squareToolStripMenuItem,
            this.Cursor_circleToolStripMenuItem,
            this.toolStripMenuItem5,
            this.cursorStepToolStripMenuItem});
            this.cursorToolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.hand_point_finger_icone_6880_16;
            this.cursorToolStripMenuItem.Name = "cursorToolStripMenuItem";
            this.cursorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.cursorToolStripMenuItem.Text = "Cursor";
            // 
            // Cursor_noneToolStripMenuItem
            // 
            this.Cursor_noneToolStripMenuItem.Name = "Cursor_noneToolStripMenuItem";
            this.Cursor_noneToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.Cursor_noneToolStripMenuItem.Text = "None";
            this.Cursor_noneToolStripMenuItem.Click += new System.EventHandler(this.Cursor_noneToolStripMenuItemClick);
            // 
            // Cursor_verticalLineToolStripMenuItem
            // 
            this.Cursor_verticalLineToolStripMenuItem.Name = "Cursor_verticalLineToolStripMenuItem";
            this.Cursor_verticalLineToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.Cursor_verticalLineToolStripMenuItem.Text = "Vertical line";
            this.Cursor_verticalLineToolStripMenuItem.Click += new System.EventHandler(this.Cursor_verticalLineToolStripMenuItemClick);
            // 
            // Cursor_horizontalLineToolStripMenuItem
            // 
            this.Cursor_horizontalLineToolStripMenuItem.Name = "Cursor_horizontalLineToolStripMenuItem";
            this.Cursor_horizontalLineToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.Cursor_horizontalLineToolStripMenuItem.Text = "Horizontal line";
            this.Cursor_horizontalLineToolStripMenuItem.Click += new System.EventHandler(this.Cursor_horizontalLineToolStripMenuItemClick);
            // 
            // Cursor_crossToolStripMenuItem
            // 
            this.Cursor_crossToolStripMenuItem.Name = "Cursor_crossToolStripMenuItem";
            this.Cursor_crossToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.Cursor_crossToolStripMenuItem.Text = "Cross";
            this.Cursor_crossToolStripMenuItem.Click += new System.EventHandler(this.Cursor_crossToolStripMenuItemClick);
            // 
            // Cursor_graticuleToolStripMenuItem
            // 
            this.Cursor_graticuleToolStripMenuItem.Name = "Cursor_graticuleToolStripMenuItem";
            this.Cursor_graticuleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.Cursor_graticuleToolStripMenuItem.Text = "Graticule";
            this.Cursor_graticuleToolStripMenuItem.Click += new System.EventHandler(this.Cursor_graticuleToolStripMenuItemClick);
            // 
            // Cursor_squareToolStripMenuItem
            // 
            this.Cursor_squareToolStripMenuItem.Name = "Cursor_squareToolStripMenuItem";
            this.Cursor_squareToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.Cursor_squareToolStripMenuItem.Text = "Square";
            this.Cursor_squareToolStripMenuItem.Click += new System.EventHandler(this.Cursor_squareToolStripMenuItemClick);
            // 
            // Cursor_circleToolStripMenuItem
            // 
            this.Cursor_circleToolStripMenuItem.Name = "Cursor_circleToolStripMenuItem";
            this.Cursor_circleToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.Cursor_circleToolStripMenuItem.Text = "Circle";
            this.Cursor_circleToolStripMenuItem.Click += new System.EventHandler(this.Cursor_circleToolStripMenuItemClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(148, 6);
            // 
            // cursorStepToolStripMenuItem
            // 
            this.cursorStepToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cursor_Step_01_ToolStripMenuItem,
            this.Cursor_Step_02_ToolStripMenuItem,
            this.Cursor_Step_05_ToolStripMenuItem,
            this.Cursor_Step_1_ToolStripMenuItem,
            this.Cursor_Step_2_ToolStripMenuItem,
            this.Cursor_Step_5_ToolStripMenuItem,
            this.Cursor_Step_10_ToolStripMenuItem,
            this.Cursor_Step_20_ToolStripMenuItem,
            this.Cursor_Step_50_ToolStripMenuItem});
            this.cursorStepToolStripMenuItem.Name = "cursorStepToolStripMenuItem";
            this.cursorStepToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cursorStepToolStripMenuItem.Text = "Cursor step";
            // 
            // Cursor_Step_01_ToolStripMenuItem
            // 
            this.Cursor_Step_01_ToolStripMenuItem.Name = "Cursor_Step_01_ToolStripMenuItem";
            this.Cursor_Step_01_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_01_ToolStripMenuItem.Text = "0.1 %";
            this.Cursor_Step_01_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_01_ToolStripMenuItemClick);
            // 
            // Cursor_Step_02_ToolStripMenuItem
            // 
            this.Cursor_Step_02_ToolStripMenuItem.Name = "Cursor_Step_02_ToolStripMenuItem";
            this.Cursor_Step_02_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_02_ToolStripMenuItem.Text = "0.2 %";
            this.Cursor_Step_02_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_02_ToolStripMenuItemClick);
            // 
            // Cursor_Step_05_ToolStripMenuItem
            // 
            this.Cursor_Step_05_ToolStripMenuItem.Name = "Cursor_Step_05_ToolStripMenuItem";
            this.Cursor_Step_05_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_05_ToolStripMenuItem.Text = "0.5 %";
            this.Cursor_Step_05_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_05_ToolStripMenuItemClick);
            // 
            // Cursor_Step_1_ToolStripMenuItem
            // 
            this.Cursor_Step_1_ToolStripMenuItem.Name = "Cursor_Step_1_ToolStripMenuItem";
            this.Cursor_Step_1_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_1_ToolStripMenuItem.Text = "1 %";
            this.Cursor_Step_1_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_1_ToolStripMenuItemClick);
            // 
            // Cursor_Step_2_ToolStripMenuItem
            // 
            this.Cursor_Step_2_ToolStripMenuItem.Name = "Cursor_Step_2_ToolStripMenuItem";
            this.Cursor_Step_2_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_2_ToolStripMenuItem.Text = "2 %";
            this.Cursor_Step_2_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_2_ToolStripMenuItemClick);
            // 
            // Cursor_Step_5_ToolStripMenuItem
            // 
            this.Cursor_Step_5_ToolStripMenuItem.Name = "Cursor_Step_5_ToolStripMenuItem";
            this.Cursor_Step_5_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_5_ToolStripMenuItem.Text = "5 %";
            this.Cursor_Step_5_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_5_ToolStripMenuItemClick);
            // 
            // Cursor_Step_10_ToolStripMenuItem
            // 
            this.Cursor_Step_10_ToolStripMenuItem.Name = "Cursor_Step_10_ToolStripMenuItem";
            this.Cursor_Step_10_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_10_ToolStripMenuItem.Text = "10 %";
            this.Cursor_Step_10_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_10_ToolStripMenuItemClick);
            // 
            // Cursor_Step_20_ToolStripMenuItem
            // 
            this.Cursor_Step_20_ToolStripMenuItem.Name = "Cursor_Step_20_ToolStripMenuItem";
            this.Cursor_Step_20_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_20_ToolStripMenuItem.Text = "20 %";
            this.Cursor_Step_20_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_20_ToolStripMenuItemClick);
            // 
            // Cursor_Step_50_ToolStripMenuItem
            // 
            this.Cursor_Step_50_ToolStripMenuItem.Name = "Cursor_Step_50_ToolStripMenuItem";
            this.Cursor_Step_50_ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.Cursor_Step_50_ToolStripMenuItem.Text = "50 %";
            this.Cursor_Step_50_ToolStripMenuItem.Click += new System.EventHandler(this.Cursor_Step_50_ToolStripMenuItemClick);
            // 
            // ReferenceCursorToolStripMenuItem
            // 
            this.ReferenceCursorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefCursor_Set_TSMI,
            this.RefCursor_Lock_TSMI,
            this.RefCursor_Clear_TSMI,
            this.RefCursor_Mode_TSMI});
            this.ReferenceCursorToolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.tack_tack_notes_icone_5500_16;
            this.ReferenceCursorToolStripMenuItem.Name = "ReferenceCursorToolStripMenuItem";
            this.ReferenceCursorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ReferenceCursorToolStripMenuItem.Text = "Reference cursor";
            // 
            // RefCursor_Set_TSMI
            // 
            this.RefCursor_Set_TSMI.Name = "RefCursor_Set_TSMI";
            this.RefCursor_Set_TSMI.Size = new System.Drawing.Size(105, 22);
            this.RefCursor_Set_TSMI.Text = "Set";
            this.RefCursor_Set_TSMI.Click += new System.EventHandler(this.RefCursor_Set_TSMIClick);
            // 
            // RefCursor_Lock_TSMI
            // 
            this.RefCursor_Lock_TSMI.Name = "RefCursor_Lock_TSMI";
            this.RefCursor_Lock_TSMI.Size = new System.Drawing.Size(105, 22);
            this.RefCursor_Lock_TSMI.Text = "Lock";
            this.RefCursor_Lock_TSMI.Visible = false;
            this.RefCursor_Lock_TSMI.Click += new System.EventHandler(this.RefCursor_Lock_TSMIClick);
            // 
            // RefCursor_Clear_TSMI
            // 
            this.RefCursor_Clear_TSMI.Name = "RefCursor_Clear_TSMI";
            this.RefCursor_Clear_TSMI.Size = new System.Drawing.Size(105, 22);
            this.RefCursor_Clear_TSMI.Text = "Clear";
            this.RefCursor_Clear_TSMI.Click += new System.EventHandler(this.RefCursor_Clear_TSMIClick);
            // 
            // RefCursor_Mode_TSMI
            // 
            this.RefCursor_Mode_TSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefCursor_Mode_None_TSMI,
            this.RefCursor_Mode_Vertical_TSMI,
            this.RefCursor_Mode_Horizontal_TSMI});
            this.RefCursor_Mode_TSMI.Name = "RefCursor_Mode_TSMI";
            this.RefCursor_Mode_TSMI.Size = new System.Drawing.Size(105, 22);
            this.RefCursor_Mode_TSMI.Text = "Mode";
            // 
            // RefCursor_Mode_None_TSMI
            // 
            this.RefCursor_Mode_None_TSMI.Name = "RefCursor_Mode_None_TSMI";
            this.RefCursor_Mode_None_TSMI.Size = new System.Drawing.Size(151, 22);
            this.RefCursor_Mode_None_TSMI.Text = "None";
            this.RefCursor_Mode_None_TSMI.Click += new System.EventHandler(this.RefCursor_Mode_None_TSMIClick);
            // 
            // RefCursor_Mode_Vertical_TSMI
            // 
            this.RefCursor_Mode_Vertical_TSMI.Name = "RefCursor_Mode_Vertical_TSMI";
            this.RefCursor_Mode_Vertical_TSMI.Size = new System.Drawing.Size(151, 22);
            this.RefCursor_Mode_Vertical_TSMI.Text = "Vertical line";
            this.RefCursor_Mode_Vertical_TSMI.Click += new System.EventHandler(this.RefCursor_Mode_Vertical_TSMIClick);
            // 
            // RefCursor_Mode_Horizontal_TSMI
            // 
            this.RefCursor_Mode_Horizontal_TSMI.Name = "RefCursor_Mode_Horizontal_TSMI";
            this.RefCursor_Mode_Horizontal_TSMI.Size = new System.Drawing.Size(151, 22);
            this.RefCursor_Mode_Horizontal_TSMI.Text = "Horizontal line";
            this.RefCursor_Mode_Horizontal_TSMI.Click += new System.EventHandler(this.RefCursor_Mode_Horizontal_TSMIClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // graphLayoutToolStripMenuItem
            // 
            this.graphLayoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Layout_overlayToolStripMenuItem,
            this.Layout_parallelToolStripMenuItem,
            this.Layout_customToolStripMenuItem});
            this.graphLayoutToolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.graphic_curve_icone_6410_16;
            this.graphLayoutToolStripMenuItem.Name = "graphLayoutToolStripMenuItem";
            this.graphLayoutToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.graphLayoutToolStripMenuItem.Text = "Graph layout";
            // 
            // Layout_overlayToolStripMenuItem
            // 
            this.Layout_overlayToolStripMenuItem.Name = "Layout_overlayToolStripMenuItem";
            this.Layout_overlayToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.Layout_overlayToolStripMenuItem.Text = "Overlay";
            this.Layout_overlayToolStripMenuItem.Click += new System.EventHandler(this.Layout_overlayToolStripMenuItemClick);
            // 
            // Layout_parallelToolStripMenuItem
            // 
            this.Layout_parallelToolStripMenuItem.Name = "Layout_parallelToolStripMenuItem";
            this.Layout_parallelToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.Layout_parallelToolStripMenuItem.Text = "Parallel";
            this.Layout_parallelToolStripMenuItem.Click += new System.EventHandler(this.Layout_parallelToolStripMenuItemClick);
            // 
            // Layout_customToolStripMenuItem
            // 
            this.Layout_customToolStripMenuItem.Name = "Layout_customToolStripMenuItem";
            this.Layout_customToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.Layout_customToolStripMenuItem.Text = "Custom";
            this.Layout_customToolStripMenuItem.Click += new System.EventHandler(this.Layout_customToolStripMenuItemClick);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.coloriser_icone_5758;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItemClick);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(159, 6);
            // 
            // snapshotToolStripMenuItem
            // 
            this.snapshotToolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.camera_icone_8948_16;
            this.snapshotToolStripMenuItem.Name = "snapshotToolStripMenuItem";
            this.snapshotToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.snapshotToolStripMenuItem.Text = "Snapshot";
            this.snapshotToolStripMenuItem.Click += new System.EventHandler(this.SnapshotToolStripMenuItemClick);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::Ctrl_GraphWindow.Icones.printer_icone_7966_16;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItemClick);
            // 
            // Context_Legend
            // 
            this.Context_Legend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Ctxt_Legend_Edit,
            this.TSMI_Ctxt_Legend_Hide,
            this.TSMI_Ctxt_Legend_Remove,
            this.toolStripMenuItem4,
            this.TSMI_Ctxt_Legend_Infos,
            this.TSMI_Ctxt_Legend_ShowTitles,
            this.TSMI_Ctxt_Legend_ShowGridLines});
            this.Context_Legend.Name = "Context_Legend";
            this.Context_Legend.Size = new System.Drawing.Size(198, 142);
            // 
            // TSMI_Ctxt_Legend_Edit
            // 
            this.TSMI_Ctxt_Legend_Edit.Name = "TSMI_Ctxt_Legend_Edit";
            this.TSMI_Ctxt_Legend_Edit.Size = new System.Drawing.Size(197, 22);
            this.TSMI_Ctxt_Legend_Edit.Text = "Edit graph properties";
            this.TSMI_Ctxt_Legend_Edit.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_EditClick);
            // 
            // TSMI_Ctxt_Legend_Hide
            // 
            this.TSMI_Ctxt_Legend_Hide.Name = "TSMI_Ctxt_Legend_Hide";
            this.TSMI_Ctxt_Legend_Hide.ShortcutKeyDisplayString = "[T]";
            this.TSMI_Ctxt_Legend_Hide.Size = new System.Drawing.Size(197, 22);
            this.TSMI_Ctxt_Legend_Hide.Text = "Hide graph";
            this.TSMI_Ctxt_Legend_Hide.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_HideClick);
            // 
            // TSMI_Ctxt_Legend_Remove
            // 
            this.TSMI_Ctxt_Legend_Remove.Name = "TSMI_Ctxt_Legend_Remove";
            this.TSMI_Ctxt_Legend_Remove.ShortcutKeyDisplayString = "[Del]";
            this.TSMI_Ctxt_Legend_Remove.Size = new System.Drawing.Size(197, 22);
            this.TSMI_Ctxt_Legend_Remove.Text = "Remove graph";
            this.TSMI_Ctxt_Legend_Remove.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_RemoveClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(194, 6);
            // 
            // TSMI_Ctxt_Legend_Infos
            // 
            this.TSMI_Ctxt_Legend_Infos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Ctxt_Legend_Infos_Label,
            this.TSMI_Ctxt_Legend_Infos_Value,
            this.TSMI_Ctxt_Legend_Infos_Unit,
            this.TSMI_Ctxt_Legend_Infos_Min,
            this.TSMI_Ctxt_Legend_Infos_Max,
            this.TSMI_Ctxt_Legend_Infos_Avg,
            this.TSMI_Ctxt_Legend_Infos_RefCursor});
            this.TSMI_Ctxt_Legend_Infos.Name = "TSMI_Ctxt_Legend_Infos";
            this.TSMI_Ctxt_Legend_Infos.Size = new System.Drawing.Size(197, 22);
            this.TSMI_Ctxt_Legend_Infos.Text = "Legend informations";
            // 
            // TSMI_Ctxt_Legend_Infos_Label
            // 
            this.TSMI_Ctxt_Legend_Infos_Label.Name = "TSMI_Ctxt_Legend_Infos_Label";
            this.TSMI_Ctxt_Legend_Infos_Label.Size = new System.Drawing.Size(162, 22);
            this.TSMI_Ctxt_Legend_Infos_Label.Text = "Label";
            this.TSMI_Ctxt_Legend_Infos_Label.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_LabelClick);
            // 
            // TSMI_Ctxt_Legend_Infos_Value
            // 
            this.TSMI_Ctxt_Legend_Infos_Value.Name = "TSMI_Ctxt_Legend_Infos_Value";
            this.TSMI_Ctxt_Legend_Infos_Value.Size = new System.Drawing.Size(162, 22);
            this.TSMI_Ctxt_Legend_Infos_Value.Text = "Cursor value";
            this.TSMI_Ctxt_Legend_Infos_Value.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_ValueClick);
            // 
            // TSMI_Ctxt_Legend_Infos_Unit
            // 
            this.TSMI_Ctxt_Legend_Infos_Unit.Name = "TSMI_Ctxt_Legend_Infos_Unit";
            this.TSMI_Ctxt_Legend_Infos_Unit.Size = new System.Drawing.Size(162, 22);
            this.TSMI_Ctxt_Legend_Infos_Unit.Text = "Unit";
            this.TSMI_Ctxt_Legend_Infos_Unit.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_UnitClick);
            // 
            // TSMI_Ctxt_Legend_Infos_Min
            // 
            this.TSMI_Ctxt_Legend_Infos_Min.Name = "TSMI_Ctxt_Legend_Infos_Min";
            this.TSMI_Ctxt_Legend_Infos_Min.Size = new System.Drawing.Size(162, 22);
            this.TSMI_Ctxt_Legend_Infos_Min.Text = "Graph min";
            this.TSMI_Ctxt_Legend_Infos_Min.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_MinClick);
            // 
            // TSMI_Ctxt_Legend_Infos_Max
            // 
            this.TSMI_Ctxt_Legend_Infos_Max.Name = "TSMI_Ctxt_Legend_Infos_Max";
            this.TSMI_Ctxt_Legend_Infos_Max.Size = new System.Drawing.Size(162, 22);
            this.TSMI_Ctxt_Legend_Infos_Max.Text = "Graph max";
            this.TSMI_Ctxt_Legend_Infos_Max.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_MaxClick);
            // 
            // TSMI_Ctxt_Legend_Infos_Avg
            // 
            this.TSMI_Ctxt_Legend_Infos_Avg.Name = "TSMI_Ctxt_Legend_Infos_Avg";
            this.TSMI_Ctxt_Legend_Infos_Avg.Size = new System.Drawing.Size(162, 22);
            this.TSMI_Ctxt_Legend_Infos_Avg.Text = "Graph average";
            this.TSMI_Ctxt_Legend_Infos_Avg.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_AvgClick);
            // 
            // TSMI_Ctxt_Legend_Infos_RefCursor
            // 
            this.TSMI_Ctxt_Legend_Infos_RefCursor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Value,
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Diff,
            this.TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc,
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Gradient});
            this.TSMI_Ctxt_Legend_Infos_RefCursor.Name = "TSMI_Ctxt_Legend_Infos_RefCursor";
            this.TSMI_Ctxt_Legend_Infos_RefCursor.Size = new System.Drawing.Size(162, 22);
            this.TSMI_Ctxt_Legend_Infos_RefCursor.Text = "Reference cursor";
            // 
            // TSMI_Ctxt_Legend_Infos_RefCursor_Value
            // 
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Value.Name = "TSMI_Ctxt_Legend_Infos_RefCursor_Value";
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Value.Size = new System.Drawing.Size(226, 22);
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Value.Text = "Reference value";
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Value.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_RefCursor_ValueClick);
            // 
            // TSMI_Ctxt_Legend_Infos_RefCursor_Diff
            // 
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Name = "TSMI_Ctxt_Legend_Infos_RefCursor_Diff";
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Size = new System.Drawing.Size(226, 22);
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Text = "Reference value difference";
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_RefCursor_DiffClick);
            // 
            // TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc
            // 
            this.TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Name = "TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc";
            this.TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Size = new System.Drawing.Size(226, 22);
            this.TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Text = "Reference value difference %";
            this.TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_RefCursor_DiffPercClick);
            // 
            // TSMI_Ctxt_Legend_Infos_RefCursor_Gradient
            // 
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Name = "TSMI_Ctxt_Legend_Infos_RefCursor_Gradient";
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Size = new System.Drawing.Size(226, 22);
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Text = "Gradient";
            this.TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_Infos_RefCursor_GradientClick);
            // 
            // TSMI_Ctxt_Legend_ShowTitles
            // 
            this.TSMI_Ctxt_Legend_ShowTitles.Name = "TSMI_Ctxt_Legend_ShowTitles";
            this.TSMI_Ctxt_Legend_ShowTitles.Size = new System.Drawing.Size(197, 22);
            this.TSMI_Ctxt_Legend_ShowTitles.Text = "Show information titles";
            this.TSMI_Ctxt_Legend_ShowTitles.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_ShowTitlesClick);
            // 
            // TSMI_Ctxt_Legend_ShowGridLines
            // 
            this.TSMI_Ctxt_Legend_ShowGridLines.Name = "TSMI_Ctxt_Legend_ShowGridLines";
            this.TSMI_Ctxt_Legend_ShowGridLines.Size = new System.Drawing.Size(197, 22);
            this.TSMI_Ctxt_Legend_ShowGridLines.Text = "Show grid lines";
            this.TSMI_Ctxt_Legend_ShowGridLines.Click += new System.EventHandler(this.TSMI_Ctxt_Legend_ShowGridLinesClick);
            // 
            // Dlg_Save_Snapshot
            // 
            this.Dlg_Save_Snapshot.Filter = "Bitmap image|*.bmp";
            // 
            // Ctrl_WaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.TB_Graph);
            this.Name = "Ctrl_WaveForm";
            this.Size = new System.Drawing.Size(814, 399);
            this.Load += new System.EventHandler(this.Ctrl_WaveForm_Load);
            this.TB_Graph.ResumeLayout(false);
            this.TB_Graph.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Graphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_GraphFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Legend)).EndInit();
            this.Context_PicGraphic_ZoomStats.ResumeLayout(false);
            this.Context_PicGraph_Options.ResumeLayout(false);
            this.Context_Legend.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem snapshotToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripButton TSB_Print;
		private System.Windows.Forms.SaveFileDialog Dlg_Save_Snapshot;
		private System.Windows.Forms.ToolStripButton TSB_Snapshot;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_ShowGridLines;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_ShowTitles;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_RefCursor_Gradient;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_RefCursor_Diff;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_RefCursor_Value;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_RefCursor;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_Avg;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_Max;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_Min;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_Unit;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_Value;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos_Label;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Infos;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Remove;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Hide;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Ctxt_Legend_Edit;
		private System.Windows.Forms.ContextMenuStrip Context_Legend;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton TSB_ShowHide_Legend;
		private System.Windows.Forms.ToolStripMenuItem RefCursor_Lock_TSMI;
		private System.Windows.Forms.ToolStripMenuItem TSDB_RefCursor_Lock;
		private System.Windows.Forms.ToolStripMenuItem TSDB_RefCursor_Mode_Horizontal;
		private System.Windows.Forms.ToolStripMenuItem TSDB_RefCursor_Mode_Vertical;
		private System.Windows.Forms.ToolStripMenuItem TSDB_RefCursor_Mode_None;
		private System.Windows.Forms.ToolStripMenuItem TSDB_RefCursor_Mode;
		private System.Windows.Forms.ToolStripMenuItem TSDB_RefCursor_Clear;
		private System.Windows.Forms.ToolStripMenuItem TSDB_RefCursor_Set;
		private System.Windows.Forms.ToolStripDropDownButton TSDB_RefCursor;
		private System.Windows.Forms.ToolStripMenuItem RefCursor_Mode_Horizontal_TSMI;
		private System.Windows.Forms.ToolStripMenuItem RefCursor_Mode_Vertical_TSMI;
		private System.Windows.Forms.ToolStripMenuItem RefCursor_Mode_None_TSMI;
		private System.Windows.Forms.ToolStripMenuItem RefCursor_Mode_TSMI;
		private System.Windows.Forms.ToolStripMenuItem RefCursor_Clear_TSMI;
		private System.Windows.Forms.ToolStripMenuItem RefCursor_Set_TSMI;
		private System.Windows.Forms.ToolStripMenuItem ReferenceCursorToolStripMenuItem;
		private System.Windows.Forms.Button Cmd_ZoomYPosition;
		private System.Windows.Forms.Button Cmd_ZoomXPosition;
		private Ctrl_GraphWindow.GW_SelectablePictureBox Pic_GraphFrame;
		private Ctrl_GraphWindow.GW_SelectablePictureBox Pic_Graphic;
		private System.Windows.Forms.ToolStripMenuItem ZoomPlustoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomFactor_32_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomFactor_16_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomFactor_8_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomFactor_4_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomFactor_2_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_ZoomFactor_32;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_ZoomFactor_16;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_ZoomFactor_8;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_ZoomFactor_4;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_ZoomFactor_2;
		private System.Windows.Forms.ToolStripMenuItem ZoomFactortoolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton TSDdB_ZoomFactor;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_50_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_20_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_10_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_5_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_2_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_1_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_05_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_02_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_Step_01_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cursorStepToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_50_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_20_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_10_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_5_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_2_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_1_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_05_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_02_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_CurStep_01_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton TSDdB_CursorStep;
		private System.Windows.Forms.ToolStripMenuItem ZoomMode_Disabled_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripButton TSB_ZoomMinus;
		private System.Windows.Forms.ToolStripButton TSB_ZoomPlus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_zoomDisabledToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ZoomMode_XY_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomMode_Y_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomMode_X_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomModetoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomMaxtoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomMintoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ZoomMinustoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_zoomXYToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_zoomYToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_zoomXToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton TSDdB_ZoomMode;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_circleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_squareToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_graticuleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_crossToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_verticalLineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_horizontalLineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_noneToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton TSDdB_MainGraphCursor;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_customToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_parallelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSDdB_overlayToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton TSDdB_GraphLayoutMode;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem Cursor_circleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_squareToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_graticuleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_crossToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_horizontalLineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_verticalLineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cursor_noneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cursorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Layout_customToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Layout_parallelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Layout_overlayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem graphLayoutToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_PicGraph_Options;
		private System.Windows.Forms.ContextMenuStrip Context_PicGraphic_ZoomStats;
		private Ctrl_GraphWindow.Ctrl_GW_ChannelList Ctrl_ChannelList;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenData;
		private System.Windows.Forms.ToolStripButton TSB_Replot;
		private System.Windows.Forms.ToolStripLabel TSL_PlotAvg;
		private System.Windows.Forms.ToolStripLabel TSL_PlotLast;
		private System.Windows.Forms.ToolStripButton TSB_GraphProperties;
		private System.Windows.Forms.ToolStripButton TSB_ShowHide_ChannelList;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton TSB_LoadData;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip TB_Graph;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton TSB_RT_Play;
        private System.Windows.Forms.ToolStripButton TSB_RT_Break;
        private System.Windows.Forms.ToolStripButton TSB_RT_Stop;
        private System.Windows.Forms.ToolStripMenuItem RT_PlaytoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RT_BreaktoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RT_StoptoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.DataGridView Grid_Legend;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_GraphMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_GraphMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_GraphAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_RefValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_RefDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_RefDiffPerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legend_Col_RefGradient;
        private System.Windows.Forms.ToolStripComboBox TSCmb_InitialStage;
        private System.Windows.Forms.ToolStripButton TSB_SeeStep;
        private System.Windows.Forms.ToolStripButton TSB_SeePrevStep;
        private System.Windows.Forms.ToolStripButton TSB_SeeNextStep;
        private System.Windows.Forms.ToolStripLabel TSL_PlotCount;
    }
}
