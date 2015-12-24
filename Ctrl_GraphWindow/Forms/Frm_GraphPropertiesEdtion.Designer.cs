namespace Ctrl_GraphWindow
{
    partial class Frm_GraphPropertiesEdtion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GraphPropertiesEdtion));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Chk_AllowOverScaling = new System.Windows.Forms.CheckBox();
            this.Grid_SeriesProperties = new System.Windows.Forms.DataGridView();
            this.ColSerieName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColSerieFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieTop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieBottom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieScaleMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColSerieMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieAxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerieRefLines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSeriePropSetting = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Context_Grid_SeriesProperties = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSerieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveSelectionUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveSelectionDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cmb_GraphLayoutMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Chk_LegendGridLinesVisible = new System.Windows.Forms.CheckBox();
            this.Chk_LegendHeaderVisible = new System.Windows.Forms.CheckBox();
            this.ChkLst_LegendInformations = new System.Windows.Forms.CheckedListBox();
            this.Lbl_LegendInformations = new System.Windows.Forms.Label();
            this.Chk_LegendVisible = new System.Windows.Forms.CheckBox();
            this.Cmd_LegendFont = new System.Windows.Forms.Button();
            this.Txt_LegendFontSize = new System.Windows.Forms.TextBox();
            this.Lbl_LegendFontSize = new System.Windows.Forms.Label();
            this.Txt_LegendFont = new System.Windows.Forms.TextBox();
            this.Lbl_LegendFont = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lbl_TrackMaxValComment = new System.Windows.Forms.Label();
            this.Lbl_TrackMinValComment = new System.Windows.Forms.Label();
            this.Lbl_TrackMaxVal = new System.Windows.Forms.Label();
            this.Lbl_TrackMinVal = new System.Windows.Forms.Label();
            this.TrackBar_SampleMax = new System.Windows.Forms.TrackBar();
            this.Txt_SampleMax = new System.Windows.Forms.TextBox();
            this.Lbl_MaxSampleCount = new System.Windows.Forms.Label();
            this.Chk_SubSamplingEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Pic_GraphBackColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Pic_FrameLineColor = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_FrameLineWidth = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Pic_SVGrid_Color = new System.Windows.Forms.PictureBox();
            this.Lbl_SVGrid_Color = new System.Windows.Forms.Label();
            this.Cmb_SVGrid_Style = new System.Windows.Forms.ComboBox();
            this.Lbl_SVGrid_Style = new System.Windows.Forms.Label();
            this.Txt_SVGrid_Width = new System.Windows.Forms.TextBox();
            this.Lbl_SVGrid_Width = new System.Windows.Forms.Label();
            this.Chk_SVGrid_Visible = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Lbl_SHGrid_Color = new System.Windows.Forms.Label();
            this.Cmb_SHGrid_Style = new System.Windows.Forms.ComboBox();
            this.Lbl_SHGrid_Style = new System.Windows.Forms.Label();
            this.Txt_SHGrid_Width = new System.Windows.Forms.TextBox();
            this.Lbl_SHGrid_Width = new System.Windows.Forms.Label();
            this.Chk_SHGrid_Visible = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Lbl_MVGrid_Color = new System.Windows.Forms.Label();
            this.Cmb_MVGrid_Style = new System.Windows.Forms.ComboBox();
            this.Lbl_MVGrid_Style = new System.Windows.Forms.Label();
            this.Txt_MVGrid_Width = new System.Windows.Forms.TextBox();
            this.Lbl_MVGrid_Width = new System.Windows.Forms.Label();
            this.Chk_MVGrid_Visible = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Lbl_MHGrid_Color = new System.Windows.Forms.Label();
            this.Cmb_MHGrid_Style = new System.Windows.Forms.ComboBox();
            this.Lbl_MHGrid_Style = new System.Windows.Forms.Label();
            this.Txt_MHGrid_Width = new System.Windows.Forms.TextBox();
            this.Lbl_MHGrid_Width = new System.Windows.Forms.Label();
            this.Chk_MHGrid_Visible = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Pic_SHGrid_Color = new System.Windows.Forms.PictureBox();
            this.Pic_MVGrid_Color = new System.Windows.Forms.PictureBox();
            this.Pic_MHGrid_Color = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Grp_AbscisseRefLines = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Cmd_AbscisseFont = new System.Windows.Forms.Button();
            this.Chk_AbscisseValueVisible = new System.Windows.Forms.CheckBox();
            this.Txt_AbscisseFontSize = new System.Windows.Forms.TextBox();
            this.Lbl_AbscisseFontSize = new System.Windows.Forms.Label();
            this.Txt_AbscisseFont = new System.Windows.Forms.TextBox();
            this.Lbl_AbscisseFont = new System.Windows.Forms.Label();
            this.Chk_AbscisseVisible = new System.Windows.Forms.CheckBox();
            this.Pic_AbscisseColor = new System.Windows.Forms.PictureBox();
            this.Lbl_AbscisseColor = new System.Windows.Forms.Label();
            this.Txt_AbscisseWidth = new System.Windows.Forms.TextBox();
            this.Lbl_AbscisseWidth = new System.Windows.Forms.Label();
            this.Cmb_AbscisseStyle = new System.Windows.Forms.ComboBox();
            this.Lbl_AbscisseStyle = new System.Windows.Forms.Label();
            this.Grp_AbscisseMode = new System.Windows.Forms.GroupBox();
            this.Cmb_AbscisseChannel = new System.Windows.Forms.ComboBox();
            this.Lbl_AbscisseChannel = new System.Windows.Forms.Label();
            this.Chk_AbscisseTimeMode = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Cmb_RefCursorOrdValLocation = new System.Windows.Forms.ComboBox();
            this.Lbl_RefCursorOrdValLocation = new System.Windows.Forms.Label();
            this.Chk_RefCursorOrdValVisible = new System.Windows.Forms.CheckBox();
            this.Cmd_RefCursorValFont = new System.Windows.Forms.Button();
            this.Txt_RefCursorValFontSize = new System.Windows.Forms.TextBox();
            this.Lbl_RefCursorValFontSize = new System.Windows.Forms.Label();
            this.Txt_RefCursorValFont = new System.Windows.Forms.TextBox();
            this.Lbl_RefCursorValFont = new System.Windows.Forms.Label();
            this.Cmb_RefCursorAbsValLocation = new System.Windows.Forms.ComboBox();
            this.Lbl_RefCursorAbsValLocation = new System.Windows.Forms.Label();
            this.Chk_RefCursorAbsValVisible = new System.Windows.Forms.CheckBox();
            this.Pic_RefCursorLineColor = new System.Windows.Forms.PictureBox();
            this.Lbl_RefCursorLineColor = new System.Windows.Forms.Label();
            this.Txt_RefCursorLineWidth = new System.Windows.Forms.TextBox();
            this.Lbl_RefCursorLineWidth = new System.Windows.Forms.Label();
            this.Cmb_RefCursorLineStyle = new System.Windows.Forms.ComboBox();
            this.Lbl_RefCursorLineStyle = new System.Windows.Forms.Label();
            this.Cmb_RefCursorMode = new System.Windows.Forms.ComboBox();
            this.Lbl_RefCursorMode = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Cmd_CursorValFont = new System.Windows.Forms.Button();
            this.Txt_CursorValFontSize = new System.Windows.Forms.TextBox();
            this.Lbl_CursorValFontSize = new System.Windows.Forms.Label();
            this.Txt_CursorValFont = new System.Windows.Forms.TextBox();
            this.Lbl_CursorValFont = new System.Windows.Forms.Label();
            this.Txt_CursorSize = new System.Windows.Forms.TextBox();
            this.Lbl_CursorSize = new System.Windows.Forms.Label();
            this.Cmb_CursorOrdValLocation = new System.Windows.Forms.ComboBox();
            this.Lbl_CursorOrdValLocation = new System.Windows.Forms.Label();
            this.Chk_CursorOrdValVisible = new System.Windows.Forms.CheckBox();
            this.Cmb_CursorAbsValLocation = new System.Windows.Forms.ComboBox();
            this.Lbl_CursorAbsValLocation = new System.Windows.Forms.Label();
            this.Chk_CursorAbsValVisible = new System.Windows.Forms.CheckBox();
            this.Pic_CursorLineColor = new System.Windows.Forms.PictureBox();
            this.Lbl_CursorLineColor = new System.Windows.Forms.Label();
            this.Txt_CursorLineWidth = new System.Windows.Forms.TextBox();
            this.Lbl_CursorLineWidth = new System.Windows.Forms.Label();
            this.Cmb_CursorLineStyle = new System.Windows.Forms.ComboBox();
            this.Lbl_CursorLineStyle = new System.Windows.Forms.Label();
            this.Cmb_MainCursorMode = new System.Windows.Forms.ComboBox();
            this.Lbl_MainCursorMode = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_Apply = new System.Windows.Forms.ToolStripButton();
            this.TSB_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_New = new System.Windows.Forms.ToolStripButton();
            this.TSB_Open = new System.Windows.Forms.ToolStripButton();
            this.TSB_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_ChannelList = new System.Windows.Forms.ToolStripButton();
            this.TSB_NewSerie = new System.Windows.Forms.ToolStripButton();
            this.TSB_DelSerie = new System.Windows.Forms.ToolStripButton();
            this.TSB_CopySerie = new System.Windows.Forms.ToolStripButton();
            this.TSB_PasteSerie = new System.Windows.Forms.ToolStripButton();
            this.TSB_MoveUp = new System.Windows.Forms.ToolStripButton();
            this.TSB_MoveDown = new System.Windows.Forms.ToolStripButton();
            this.Dlg_Color = new System.Windows.Forms.ColorDialog();
            this.Dlg_Open = new System.Windows.Forms.OpenFileDialog();
            this.Dlg_Save = new System.Windows.Forms.SaveFileDialog();
            this.Dlg_Font = new System.Windows.Forms.FontDialog();
            this.Img_ContextChanList = new System.Windows.Forms.ImageList(this.components);
            this.Pic_CursorValueForecolor = new System.Windows.Forms.PictureBox();
            this.Lbl_CursorValueForecolor = new System.Windows.Forms.Label();
            this.Pic_CursorTitleForecolor = new System.Windows.Forms.PictureBox();
            this.Lbl_CursorTitleForecolor = new System.Windows.Forms.Label();
            this.Cmd_CursorTitleFont = new System.Windows.Forms.Button();
            this.Txt_CursorTitleFontSize = new System.Windows.Forms.TextBox();
            this.Lbl_CursorTitleFontSize = new System.Windows.Forms.Label();
            this.Txt_CursorTitleFont = new System.Windows.Forms.TextBox();
            this.Lbl_CursorTitleFont = new System.Windows.Forms.Label();
            this.Lbl_CursorTitle = new System.Windows.Forms.Label();
            this.Txt_CursorTitle = new System.Windows.Forms.TextBox();
            this.Cmb_CursorTitleLocation = new System.Windows.Forms.ComboBox();
            this.Lbl_CursorTitleLocation = new System.Windows.Forms.Label();
            this.Ctrl_AbcisseRefLines = new Ctrl_GraphWindow.Ctrl_ReferenceLines();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_SeriesProperties)).BeginInit();
            this.Context_Grid_SeriesProperties.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar_SampleMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_GraphBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_FrameLineColor)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_SVGrid_Color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_SHGrid_Color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_MVGrid_Color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_MHGrid_Color)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.Grp_AbscisseRefLines.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AbscisseColor)).BeginInit();
            this.Grp_AbscisseMode.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_RefCursorLineColor)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_CursorLineColor)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_CursorValueForecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_CursorTitleForecolor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(3, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 388);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.Chk_AllowOverScaling);
            this.tabPage1.Controls.Add(this.Grid_SeriesProperties);
            this.tabPage1.Controls.Add(this.Cmb_GraphLayoutMode);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(807, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Series";
            // 
            // Chk_AllowOverScaling
            // 
            this.Chk_AllowOverScaling.Location = new System.Drawing.Point(339, 11);
            this.Chk_AllowOverScaling.Name = "Chk_AllowOverScaling";
            this.Chk_AllowOverScaling.Size = new System.Drawing.Size(258, 18);
            this.Chk_AllowOverScaling.TabIndex = 3;
            this.Chk_AllowOverScaling.Text = "Allow overscaling";
            this.Chk_AllowOverScaling.UseVisualStyleBackColor = true;
            // 
            // Grid_SeriesProperties
            // 
            this.Grid_SeriesProperties.AllowDrop = true;
            this.Grid_SeriesProperties.AllowUserToAddRows = false;
            this.Grid_SeriesProperties.AllowUserToResizeRows = false;
            this.Grid_SeriesProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_SeriesProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_SeriesProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSerieName,
            this.ColSerieLabel,
            this.ColSerieUnit,
            this.ColSerieColor,
            this.ColSerieVisible,
            this.ColSerieFormat,
            this.ColSerieTop,
            this.ColSerieBottom,
            this.ColSerieScaleMode,
            this.ColSerieMin,
            this.ColSerieMax,
            this.ColSerieAxis,
            this.ColSerieGrid,
            this.ColSerieRefLines,
            this.ColSeriePropSetting});
            this.Grid_SeriesProperties.ContextMenuStrip = this.Context_Grid_SeriesProperties;
            this.Grid_SeriesProperties.Location = new System.Drawing.Point(9, 37);
            this.Grid_SeriesProperties.Name = "Grid_SeriesProperties";
            this.Grid_SeriesProperties.RowHeadersVisible = false;
            this.Grid_SeriesProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_SeriesProperties.Size = new System.Drawing.Size(791, 318);
            this.Grid_SeriesProperties.TabIndex = 2;
            this.Grid_SeriesProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_SeriesProperties_CellClick);
            this.Grid_SeriesProperties.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_SeriesPropertiesCellEndEdit);
            this.Grid_SeriesProperties.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid_SeriesProperties_CellMouseDoubleClick);
            this.Grid_SeriesProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_SeriesProperties_CellValueChanged);
            this.Grid_SeriesProperties.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Grid_SeriesPropertiesEditingControlShowing);
            this.Grid_SeriesProperties.DragDrop += new System.Windows.Forms.DragEventHandler(this.Grid_SeriesProperties_DragDrop);
            this.Grid_SeriesProperties.DragEnter += new System.Windows.Forms.DragEventHandler(this.Grid_SeriesProperties_DragEnter);
            this.Grid_SeriesProperties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_SeriesProperties_KeyDown);
            // 
            // ColSerieName
            // 
            this.ColSerieName.HeaderText = "Name";
            this.ColSerieName.Name = "ColSerieName";
            // 
            // ColSerieLabel
            // 
            this.ColSerieLabel.HeaderText = "Label";
            this.ColSerieLabel.Name = "ColSerieLabel";
            // 
            // ColSerieUnit
            // 
            this.ColSerieUnit.HeaderText = "Unit";
            this.ColSerieUnit.Name = "ColSerieUnit";
            // 
            // ColSerieColor
            // 
            this.ColSerieColor.HeaderText = "Color";
            this.ColSerieColor.Name = "ColSerieColor";
            this.ColSerieColor.ReadOnly = true;
            this.ColSerieColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSerieColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSerieVisible
            // 
            this.ColSerieVisible.HeaderText = "Visible";
            this.ColSerieVisible.Name = "ColSerieVisible";
            // 
            // ColSerieFormat
            // 
            this.ColSerieFormat.HeaderText = "Format";
            this.ColSerieFormat.Name = "ColSerieFormat";
            this.ColSerieFormat.ReadOnly = true;
            // 
            // ColSerieTop
            // 
            this.ColSerieTop.HeaderText = "Top";
            this.ColSerieTop.Name = "ColSerieTop";
            // 
            // ColSerieBottom
            // 
            this.ColSerieBottom.HeaderText = "Bottom";
            this.ColSerieBottom.Name = "ColSerieBottom";
            // 
            // ColSerieScaleMode
            // 
            this.ColSerieScaleMode.HeaderText = "Scale";
            this.ColSerieScaleMode.Name = "ColSerieScaleMode";
            // 
            // ColSerieMin
            // 
            this.ColSerieMin.HeaderText = "Min";
            this.ColSerieMin.Name = "ColSerieMin";
            this.ColSerieMin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSerieMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSerieMax
            // 
            this.ColSerieMax.HeaderText = "Max";
            this.ColSerieMax.Name = "ColSerieMax";
            this.ColSerieMax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSerieMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSerieAxis
            // 
            this.ColSerieAxis.HeaderText = "Y Axis";
            this.ColSerieAxis.Name = "ColSerieAxis";
            this.ColSerieAxis.ReadOnly = true;
            // 
            // ColSerieGrid
            // 
            this.ColSerieGrid.HeaderText = "Grid";
            this.ColSerieGrid.Name = "ColSerieGrid";
            this.ColSerieGrid.ReadOnly = true;
            // 
            // ColSerieRefLines
            // 
            this.ColSerieRefLines.HeaderText = "Ref Lines";
            this.ColSerieRefLines.Name = "ColSerieRefLines";
            this.ColSerieRefLines.ReadOnly = true;
            // 
            // ColSeriePropSetting
            // 
            this.ColSeriePropSetting.HeaderText = "Details";
            this.ColSeriePropSetting.Name = "ColSeriePropSetting";
            // 
            // Context_Grid_SeriesProperties
            // 
            this.Context_Grid_SeriesProperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSerieToolStripMenuItem,
            this.deleteSelectedSeriesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.moveSelectionUpToolStripMenuItem,
            this.moveSelectionDownToolStripMenuItem});
            this.Context_Grid_SeriesProperties.Name = "Context_Grid_SeriesProperties";
            this.Context_Grid_SeriesProperties.Size = new System.Drawing.Size(188, 148);
            // 
            // addSerieToolStripMenuItem
            // 
            this.addSerieToolStripMenuItem.Name = "addSerieToolStripMenuItem";
            this.addSerieToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.addSerieToolStripMenuItem.Text = "Add serie";
            this.addSerieToolStripMenuItem.Click += new System.EventHandler(this.addSerieToolStripMenuItem_Click);
            // 
            // deleteSelectedSeriesToolStripMenuItem
            // 
            this.deleteSelectedSeriesToolStripMenuItem.Name = "deleteSelectedSeriesToolStripMenuItem";
            this.deleteSelectedSeriesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deleteSelectedSeriesToolStripMenuItem.Text = "Delete selected series";
            this.deleteSelectedSeriesToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedSeriesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 6);
            // 
            // moveSelectionUpToolStripMenuItem
            // 
            this.moveSelectionUpToolStripMenuItem.Name = "moveSelectionUpToolStripMenuItem";
            this.moveSelectionUpToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.moveSelectionUpToolStripMenuItem.Text = "Move selection up";
            this.moveSelectionUpToolStripMenuItem.Click += new System.EventHandler(this.moveSelectionUpToolStripMenuItem_Click);
            // 
            // moveSelectionDownToolStripMenuItem
            // 
            this.moveSelectionDownToolStripMenuItem.Name = "moveSelectionDownToolStripMenuItem";
            this.moveSelectionDownToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.moveSelectionDownToolStripMenuItem.Text = "Move selection down";
            this.moveSelectionDownToolStripMenuItem.Click += new System.EventHandler(this.moveSelectionDownToolStripMenuItem_Click);
            // 
            // Cmb_GraphLayoutMode
            // 
            this.Cmb_GraphLayoutMode.FormattingEnabled = true;
            this.Cmb_GraphLayoutMode.Location = new System.Drawing.Point(116, 10);
            this.Cmb_GraphLayoutMode.Name = "Cmb_GraphLayoutMode";
            this.Cmb_GraphLayoutMode.Size = new System.Drawing.Size(198, 21);
            this.Cmb_GraphLayoutMode.TabIndex = 1;
            this.Cmb_GraphLayoutMode.SelectedIndexChanged += new System.EventHandler(this.Cmb_GraphLayoutMode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Graphic layout mode";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(807, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "General";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Chk_LegendGridLinesVisible);
            this.groupBox3.Controls.Add(this.Chk_LegendHeaderVisible);
            this.groupBox3.Controls.Add(this.ChkLst_LegendInformations);
            this.groupBox3.Controls.Add(this.Lbl_LegendInformations);
            this.groupBox3.Controls.Add(this.Chk_LegendVisible);
            this.groupBox3.Controls.Add(this.Cmd_LegendFont);
            this.groupBox3.Controls.Add(this.Txt_LegendFontSize);
            this.groupBox3.Controls.Add(this.Lbl_LegendFontSize);
            this.groupBox3.Controls.Add(this.Txt_LegendFont);
            this.groupBox3.Controls.Add(this.Lbl_LegendFont);
            this.groupBox3.Location = new System.Drawing.Point(9, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(789, 195);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Legend";
            // 
            // Chk_LegendGridLinesVisible
            // 
            this.Chk_LegendGridLinesVisible.AutoSize = true;
            this.Chk_LegendGridLinesVisible.Enabled = false;
            this.Chk_LegendGridLinesVisible.Location = new System.Drawing.Point(9, 114);
            this.Chk_LegendGridLinesVisible.Name = "Chk_LegendGridLinesVisible";
            this.Chk_LegendGridLinesVisible.Size = new System.Drawing.Size(138, 17);
            this.Chk_LegendGridLinesVisible.TabIndex = 27;
            this.Chk_LegendGridLinesVisible.Text = "Legend grid lines visible";
            this.Chk_LegendGridLinesVisible.UseVisualStyleBackColor = true;
            // 
            // Chk_LegendHeaderVisible
            // 
            this.Chk_LegendHeaderVisible.AutoSize = true;
            this.Chk_LegendHeaderVisible.Enabled = false;
            this.Chk_LegendHeaderVisible.Location = new System.Drawing.Point(9, 91);
            this.Chk_LegendHeaderVisible.Name = "Chk_LegendHeaderVisible";
            this.Chk_LegendHeaderVisible.Size = new System.Drawing.Size(130, 17);
            this.Chk_LegendHeaderVisible.TabIndex = 26;
            this.Chk_LegendHeaderVisible.Text = "Legend header visible";
            this.Chk_LegendHeaderVisible.UseVisualStyleBackColor = true;
            // 
            // ChkLst_LegendInformations
            // 
            this.ChkLst_LegendInformations.Enabled = false;
            this.ChkLst_LegendInformations.FormattingEnabled = true;
            this.ChkLst_LegendInformations.Location = new System.Drawing.Point(279, 50);
            this.ChkLst_LegendInformations.Name = "ChkLst_LegendInformations";
            this.ChkLst_LegendInformations.Size = new System.Drawing.Size(171, 139);
            this.ChkLst_LegendInformations.TabIndex = 25;
            // 
            // Lbl_LegendInformations
            // 
            this.Lbl_LegendInformations.AutoSize = true;
            this.Lbl_LegendInformations.Enabled = false;
            this.Lbl_LegendInformations.Location = new System.Drawing.Point(276, 30);
            this.Lbl_LegendInformations.Name = "Lbl_LegendInformations";
            this.Lbl_LegendInformations.Size = new System.Drawing.Size(97, 13);
            this.Lbl_LegendInformations.TabIndex = 24;
            this.Lbl_LegendInformations.Text = "Legend information";
            // 
            // Chk_LegendVisible
            // 
            this.Chk_LegendVisible.AutoSize = true;
            this.Chk_LegendVisible.Location = new System.Drawing.Point(9, 29);
            this.Chk_LegendVisible.Name = "Chk_LegendVisible";
            this.Chk_LegendVisible.Size = new System.Drawing.Size(94, 17);
            this.Chk_LegendVisible.TabIndex = 23;
            this.Chk_LegendVisible.Text = "Legend visible";
            this.Chk_LegendVisible.UseVisualStyleBackColor = true;
            this.Chk_LegendVisible.CheckedChanged += new System.EventHandler(this.Chk_LegendVisible_CheckedChanged);
            // 
            // Cmd_LegendFont
            // 
            this.Cmd_LegendFont.Enabled = false;
            this.Cmd_LegendFont.Image = global::Ctrl_GraphWindow.Icones.font_icone_6304_16;
            this.Cmd_LegendFont.Location = new System.Drawing.Point(152, 50);
            this.Cmd_LegendFont.Name = "Cmd_LegendFont";
            this.Cmd_LegendFont.Size = new System.Drawing.Size(23, 23);
            this.Cmd_LegendFont.TabIndex = 22;
            this.Cmd_LegendFont.UseVisualStyleBackColor = true;
            this.Cmd_LegendFont.Click += new System.EventHandler(this.Cmd_LegendFont_Click);
            // 
            // Txt_LegendFontSize
            // 
            this.Txt_LegendFontSize.Enabled = false;
            this.Txt_LegendFontSize.Location = new System.Drawing.Point(214, 52);
            this.Txt_LegendFontSize.Name = "Txt_LegendFontSize";
            this.Txt_LegendFontSize.ReadOnly = true;
            this.Txt_LegendFontSize.Size = new System.Drawing.Size(44, 20);
            this.Txt_LegendFontSize.TabIndex = 21;
            // 
            // Lbl_LegendFontSize
            // 
            this.Lbl_LegendFontSize.AutoSize = true;
            this.Lbl_LegendFontSize.Enabled = false;
            this.Lbl_LegendFontSize.Location = new System.Drawing.Point(181, 55);
            this.Lbl_LegendFontSize.Name = "Lbl_LegendFontSize";
            this.Lbl_LegendFontSize.Size = new System.Drawing.Size(27, 13);
            this.Lbl_LegendFontSize.TabIndex = 20;
            this.Lbl_LegendFontSize.Text = "Size";
            // 
            // Txt_LegendFont
            // 
            this.Txt_LegendFont.Enabled = false;
            this.Txt_LegendFont.Location = new System.Drawing.Point(40, 52);
            this.Txt_LegendFont.Name = "Txt_LegendFont";
            this.Txt_LegendFont.ReadOnly = true;
            this.Txt_LegendFont.Size = new System.Drawing.Size(106, 20);
            this.Txt_LegendFont.TabIndex = 19;
            // 
            // Lbl_LegendFont
            // 
            this.Lbl_LegendFont.AutoSize = true;
            this.Lbl_LegendFont.Enabled = false;
            this.Lbl_LegendFont.Location = new System.Drawing.Point(6, 55);
            this.Lbl_LegendFont.Name = "Lbl_LegendFont";
            this.Lbl_LegendFont.Size = new System.Drawing.Size(28, 13);
            this.Lbl_LegendFont.TabIndex = 18;
            this.Lbl_LegendFont.Text = "Font";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Lbl_TrackMaxValComment);
            this.groupBox2.Controls.Add(this.Lbl_TrackMinValComment);
            this.groupBox2.Controls.Add(this.Lbl_TrackMaxVal);
            this.groupBox2.Controls.Add(this.Lbl_TrackMinVal);
            this.groupBox2.Controls.Add(this.TrackBar_SampleMax);
            this.groupBox2.Controls.Add(this.Txt_SampleMax);
            this.groupBox2.Controls.Add(this.Lbl_MaxSampleCount);
            this.groupBox2.Controls.Add(this.Chk_SubSamplingEnabled);
            this.groupBox2.Location = new System.Drawing.Point(9, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 90);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sub sampling";
            // 
            // Lbl_TrackMaxValComment
            // 
            this.Lbl_TrackMaxValComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_TrackMaxValComment.AutoSize = true;
            this.Lbl_TrackMaxValComment.Enabled = false;
            this.Lbl_TrackMaxValComment.Location = new System.Drawing.Point(753, 67);
            this.Lbl_TrackMaxValComment.Name = "Lbl_TrackMaxValComment";
            this.Lbl_TrackMaxValComment.Size = new System.Drawing.Size(30, 13);
            this.Lbl_TrackMaxValComment.TabIndex = 8;
            this.Lbl_TrackMaxValComment.Text = "Slow";
            // 
            // Lbl_TrackMinValComment
            // 
            this.Lbl_TrackMinValComment.AutoSize = true;
            this.Lbl_TrackMinValComment.Enabled = false;
            this.Lbl_TrackMinValComment.Location = new System.Drawing.Point(211, 67);
            this.Lbl_TrackMinValComment.Name = "Lbl_TrackMinValComment";
            this.Lbl_TrackMinValComment.Size = new System.Drawing.Size(27, 13);
            this.Lbl_TrackMinValComment.TabIndex = 7;
            this.Lbl_TrackMinValComment.Text = "Fast";
            // 
            // Lbl_TrackMaxVal
            // 
            this.Lbl_TrackMaxVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_TrackMaxVal.AutoSize = true;
            this.Lbl_TrackMaxVal.Enabled = false;
            this.Lbl_TrackMaxVal.Location = new System.Drawing.Point(743, 51);
            this.Lbl_TrackMaxVal.Name = "Lbl_TrackMaxVal";
            this.Lbl_TrackMaxVal.Size = new System.Drawing.Size(40, 13);
            this.Lbl_TrackMaxVal.TabIndex = 6;
            this.Lbl_TrackMaxVal.Text = "10 000";
            // 
            // Lbl_TrackMinVal
            // 
            this.Lbl_TrackMinVal.AutoSize = true;
            this.Lbl_TrackMinVal.Enabled = false;
            this.Lbl_TrackMinVal.Location = new System.Drawing.Point(211, 51);
            this.Lbl_TrackMinVal.Name = "Lbl_TrackMinVal";
            this.Lbl_TrackMinVal.Size = new System.Drawing.Size(25, 13);
            this.Lbl_TrackMinVal.TabIndex = 5;
            this.Lbl_TrackMinVal.Text = "100";
            // 
            // TrackBar_SampleMax
            // 
            this.TrackBar_SampleMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackBar_SampleMax.Enabled = false;
            this.TrackBar_SampleMax.LargeChange = 1000;
            this.TrackBar_SampleMax.Location = new System.Drawing.Point(214, 19);
            this.TrackBar_SampleMax.Maximum = 10000;
            this.TrackBar_SampleMax.Minimum = 100;
            this.TrackBar_SampleMax.Name = "TrackBar_SampleMax";
            this.TrackBar_SampleMax.Size = new System.Drawing.Size(569, 45);
            this.TrackBar_SampleMax.SmallChange = 100;
            this.TrackBar_SampleMax.TabIndex = 4;
            this.TrackBar_SampleMax.TickFrequency = 100;
            this.TrackBar_SampleMax.Value = 100;
            this.TrackBar_SampleMax.Scroll += new System.EventHandler(this.TrackBar_SampleMax_Scroll);
            // 
            // Txt_SampleMax
            // 
            this.Txt_SampleMax.Enabled = false;
            this.Txt_SampleMax.Location = new System.Drawing.Point(140, 29);
            this.Txt_SampleMax.Name = "Txt_SampleMax";
            this.Txt_SampleMax.Size = new System.Drawing.Size(68, 20);
            this.Txt_SampleMax.TabIndex = 3;
            this.Txt_SampleMax.Leave += new System.EventHandler(this.Txt_SampleMax_Leave);
            // 
            // Lbl_MaxSampleCount
            // 
            this.Lbl_MaxSampleCount.AutoSize = true;
            this.Lbl_MaxSampleCount.Enabled = false;
            this.Lbl_MaxSampleCount.Location = new System.Drawing.Point(6, 32);
            this.Lbl_MaxSampleCount.Name = "Lbl_MaxSampleCount";
            this.Lbl_MaxSampleCount.Size = new System.Drawing.Size(98, 13);
            this.Lbl_MaxSampleCount.TabIndex = 2;
            this.Lbl_MaxSampleCount.Text = "Max samples count";
            // 
            // Chk_SubSamplingEnabled
            // 
            this.Chk_SubSamplingEnabled.AutoSize = true;
            this.Chk_SubSamplingEnabled.Location = new System.Drawing.Point(9, 63);
            this.Chk_SubSamplingEnabled.Name = "Chk_SubSamplingEnabled";
            this.Chk_SubSamplingEnabled.Size = new System.Drawing.Size(130, 17);
            this.Chk_SubSamplingEnabled.TabIndex = 0;
            this.Chk_SubSamplingEnabled.Text = "Sub sampling enabled";
            this.Chk_SubSamplingEnabled.UseVisualStyleBackColor = true;
            this.Chk_SubSamplingEnabled.CheckedChanged += new System.EventHandler(this.Chk_SubSamplingEnabled_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Pic_GraphBackColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Pic_FrameLineColor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Txt_FrameLineWidth);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 52);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphic Frame";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Graphic back color";
            // 
            // Pic_GraphBackColor
            // 
            this.Pic_GraphBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pic_GraphBackColor.Location = new System.Drawing.Point(110, 22);
            this.Pic_GraphBackColor.Name = "Pic_GraphBackColor";
            this.Pic_GraphBackColor.Size = new System.Drawing.Size(68, 19);
            this.Pic_GraphBackColor.TabIndex = 9;
            this.Pic_GraphBackColor.TabStop = false;
            this.Pic_GraphBackColor.DoubleClick += new System.EventHandler(this.Pic_GraphBackColor_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Graphic frame line width";
            // 
            // Pic_FrameLineColor
            // 
            this.Pic_FrameLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pic_FrameLineColor.Location = new System.Drawing.Point(508, 22);
            this.Pic_FrameLineColor.Name = "Pic_FrameLineColor";
            this.Pic_FrameLineColor.Size = new System.Drawing.Size(68, 19);
            this.Pic_FrameLineColor.TabIndex = 7;
            this.Pic_FrameLineColor.TabStop = false;
            this.Pic_FrameLineColor.DoubleClick += new System.EventHandler(this.Pic_FrameLineColor_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Graphic frame line color";
            // 
            // Txt_FrameLineWidth
            // 
            this.Txt_FrameLineWidth.Location = new System.Drawing.Point(310, 21);
            this.Txt_FrameLineWidth.Name = "Txt_FrameLineWidth";
            this.Txt_FrameLineWidth.Size = new System.Drawing.Size(68, 20);
            this.Txt_FrameLineWidth.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.Pic_SVGrid_Color);
            this.tabPage3.Controls.Add(this.Lbl_SVGrid_Color);
            this.tabPage3.Controls.Add(this.Cmb_SVGrid_Style);
            this.tabPage3.Controls.Add(this.Lbl_SVGrid_Style);
            this.tabPage3.Controls.Add(this.Txt_SVGrid_Width);
            this.tabPage3.Controls.Add(this.Lbl_SVGrid_Width);
            this.tabPage3.Controls.Add(this.Chk_SVGrid_Visible);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.Lbl_SHGrid_Color);
            this.tabPage3.Controls.Add(this.Cmb_SHGrid_Style);
            this.tabPage3.Controls.Add(this.Lbl_SHGrid_Style);
            this.tabPage3.Controls.Add(this.Txt_SHGrid_Width);
            this.tabPage3.Controls.Add(this.Lbl_SHGrid_Width);
            this.tabPage3.Controls.Add(this.Chk_SHGrid_Visible);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.Lbl_MVGrid_Color);
            this.tabPage3.Controls.Add(this.Cmb_MVGrid_Style);
            this.tabPage3.Controls.Add(this.Lbl_MVGrid_Style);
            this.tabPage3.Controls.Add(this.Txt_MVGrid_Width);
            this.tabPage3.Controls.Add(this.Lbl_MVGrid_Width);
            this.tabPage3.Controls.Add(this.Chk_MVGrid_Visible);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.Lbl_MHGrid_Color);
            this.tabPage3.Controls.Add(this.Cmb_MHGrid_Style);
            this.tabPage3.Controls.Add(this.Lbl_MHGrid_Style);
            this.tabPage3.Controls.Add(this.Txt_MHGrid_Width);
            this.tabPage3.Controls.Add(this.Lbl_MHGrid_Width);
            this.tabPage3.Controls.Add(this.Chk_MHGrid_Visible);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.Pic_SHGrid_Color);
            this.tabPage3.Controls.Add(this.Pic_MVGrid_Color);
            this.tabPage3.Controls.Add(this.Pic_MHGrid_Color);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(807, 362);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Grid";
            // 
            // Pic_SVGrid_Color
            // 
            this.Pic_SVGrid_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pic_SVGrid_Color.Enabled = false;
            this.Pic_SVGrid_Color.Location = new System.Drawing.Point(430, 205);
            this.Pic_SVGrid_Color.Name = "Pic_SVGrid_Color";
            this.Pic_SVGrid_Color.Size = new System.Drawing.Size(68, 19);
            this.Pic_SVGrid_Color.TabIndex = 31;
            this.Pic_SVGrid_Color.TabStop = false;
            this.Pic_SVGrid_Color.DoubleClick += new System.EventHandler(this.Pic_SVGrid_Color_DoubleClick);
            // 
            // Lbl_SVGrid_Color
            // 
            this.Lbl_SVGrid_Color.AutoSize = true;
            this.Lbl_SVGrid_Color.Enabled = false;
            this.Lbl_SVGrid_Color.Location = new System.Drawing.Point(371, 207);
            this.Lbl_SVGrid_Color.Name = "Lbl_SVGrid_Color";
            this.Lbl_SVGrid_Color.Size = new System.Drawing.Size(53, 13);
            this.Lbl_SVGrid_Color.TabIndex = 30;
            this.Lbl_SVGrid_Color.Text = "Line color";
            // 
            // Cmb_SVGrid_Style
            // 
            this.Cmb_SVGrid_Style.Enabled = false;
            this.Cmb_SVGrid_Style.FormattingEnabled = true;
            this.Cmb_SVGrid_Style.Location = new System.Drawing.Point(288, 204);
            this.Cmb_SVGrid_Style.Name = "Cmb_SVGrid_Style";
            this.Cmb_SVGrid_Style.Size = new System.Drawing.Size(68, 21);
            this.Cmb_SVGrid_Style.TabIndex = 29;
            // 
            // Lbl_SVGrid_Style
            // 
            this.Lbl_SVGrid_Style.AutoSize = true;
            this.Lbl_SVGrid_Style.Enabled = false;
            this.Lbl_SVGrid_Style.Location = new System.Drawing.Point(231, 207);
            this.Lbl_SVGrid_Style.Name = "Lbl_SVGrid_Style";
            this.Lbl_SVGrid_Style.Size = new System.Drawing.Size(51, 13);
            this.Lbl_SVGrid_Style.TabIndex = 28;
            this.Lbl_SVGrid_Style.Text = "Line style";
            // 
            // Txt_SVGrid_Width
            // 
            this.Txt_SVGrid_Width.Enabled = false;
            this.Txt_SVGrid_Width.Location = new System.Drawing.Point(147, 204);
            this.Txt_SVGrid_Width.Name = "Txt_SVGrid_Width";
            this.Txt_SVGrid_Width.Size = new System.Drawing.Size(68, 20);
            this.Txt_SVGrid_Width.TabIndex = 27;
            // 
            // Lbl_SVGrid_Width
            // 
            this.Lbl_SVGrid_Width.AutoSize = true;
            this.Lbl_SVGrid_Width.Enabled = false;
            this.Lbl_SVGrid_Width.Location = new System.Drawing.Point(86, 207);
            this.Lbl_SVGrid_Width.Name = "Lbl_SVGrid_Width";
            this.Lbl_SVGrid_Width.Size = new System.Drawing.Size(55, 13);
            this.Lbl_SVGrid_Width.TabIndex = 26;
            this.Lbl_SVGrid_Width.Text = "Line width";
            // 
            // Chk_SVGrid_Visible
            // 
            this.Chk_SVGrid_Visible.AutoSize = true;
            this.Chk_SVGrid_Visible.Location = new System.Drawing.Point(24, 206);
            this.Chk_SVGrid_Visible.Name = "Chk_SVGrid_Visible";
            this.Chk_SVGrid_Visible.Size = new System.Drawing.Size(56, 17);
            this.Chk_SVGrid_Visible.TabIndex = 25;
            this.Chk_SVGrid_Visible.Text = "Visible";
            this.Chk_SVGrid_Visible.UseVisualStyleBackColor = true;
            this.Chk_SVGrid_Visible.CheckedChanged += new System.EventHandler(this.Chk_SVGrid_Visible_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Secondary vertical grid";
            // 
            // Lbl_SHGrid_Color
            // 
            this.Lbl_SHGrid_Color.AutoSize = true;
            this.Lbl_SHGrid_Color.Enabled = false;
            this.Lbl_SHGrid_Color.Location = new System.Drawing.Point(371, 151);
            this.Lbl_SHGrid_Color.Name = "Lbl_SHGrid_Color";
            this.Lbl_SHGrid_Color.Size = new System.Drawing.Size(53, 13);
            this.Lbl_SHGrid_Color.TabIndex = 22;
            this.Lbl_SHGrid_Color.Text = "Line color";
            // 
            // Cmb_SHGrid_Style
            // 
            this.Cmb_SHGrid_Style.Enabled = false;
            this.Cmb_SHGrid_Style.FormattingEnabled = true;
            this.Cmb_SHGrid_Style.Location = new System.Drawing.Point(288, 148);
            this.Cmb_SHGrid_Style.Name = "Cmb_SHGrid_Style";
            this.Cmb_SHGrid_Style.Size = new System.Drawing.Size(68, 21);
            this.Cmb_SHGrid_Style.TabIndex = 21;
            // 
            // Lbl_SHGrid_Style
            // 
            this.Lbl_SHGrid_Style.AutoSize = true;
            this.Lbl_SHGrid_Style.Enabled = false;
            this.Lbl_SHGrid_Style.Location = new System.Drawing.Point(231, 151);
            this.Lbl_SHGrid_Style.Name = "Lbl_SHGrid_Style";
            this.Lbl_SHGrid_Style.Size = new System.Drawing.Size(51, 13);
            this.Lbl_SHGrid_Style.TabIndex = 20;
            this.Lbl_SHGrid_Style.Text = "Line style";
            // 
            // Txt_SHGrid_Width
            // 
            this.Txt_SHGrid_Width.Enabled = false;
            this.Txt_SHGrid_Width.Location = new System.Drawing.Point(147, 148);
            this.Txt_SHGrid_Width.Name = "Txt_SHGrid_Width";
            this.Txt_SHGrid_Width.Size = new System.Drawing.Size(68, 20);
            this.Txt_SHGrid_Width.TabIndex = 19;
            // 
            // Lbl_SHGrid_Width
            // 
            this.Lbl_SHGrid_Width.AutoSize = true;
            this.Lbl_SHGrid_Width.Enabled = false;
            this.Lbl_SHGrid_Width.Location = new System.Drawing.Point(86, 151);
            this.Lbl_SHGrid_Width.Name = "Lbl_SHGrid_Width";
            this.Lbl_SHGrid_Width.Size = new System.Drawing.Size(55, 13);
            this.Lbl_SHGrid_Width.TabIndex = 18;
            this.Lbl_SHGrid_Width.Text = "Line width";
            // 
            // Chk_SHGrid_Visible
            // 
            this.Chk_SHGrid_Visible.AutoSize = true;
            this.Chk_SHGrid_Visible.Location = new System.Drawing.Point(24, 150);
            this.Chk_SHGrid_Visible.Name = "Chk_SHGrid_Visible";
            this.Chk_SHGrid_Visible.Size = new System.Drawing.Size(56, 17);
            this.Chk_SHGrid_Visible.TabIndex = 17;
            this.Chk_SHGrid_Visible.Text = "Visible";
            this.Chk_SHGrid_Visible.UseVisualStyleBackColor = true;
            this.Chk_SHGrid_Visible.CheckedChanged += new System.EventHandler(this.Chk_SHGrid_Visible_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Secondary horizontal grid";
            // 
            // Lbl_MVGrid_Color
            // 
            this.Lbl_MVGrid_Color.AutoSize = true;
            this.Lbl_MVGrid_Color.Enabled = false;
            this.Lbl_MVGrid_Color.Location = new System.Drawing.Point(371, 93);
            this.Lbl_MVGrid_Color.Name = "Lbl_MVGrid_Color";
            this.Lbl_MVGrid_Color.Size = new System.Drawing.Size(53, 13);
            this.Lbl_MVGrid_Color.TabIndex = 14;
            this.Lbl_MVGrid_Color.Text = "Line color";
            // 
            // Cmb_MVGrid_Style
            // 
            this.Cmb_MVGrid_Style.Enabled = false;
            this.Cmb_MVGrid_Style.FormattingEnabled = true;
            this.Cmb_MVGrid_Style.Location = new System.Drawing.Point(288, 90);
            this.Cmb_MVGrid_Style.Name = "Cmb_MVGrid_Style";
            this.Cmb_MVGrid_Style.Size = new System.Drawing.Size(68, 21);
            this.Cmb_MVGrid_Style.TabIndex = 13;
            // 
            // Lbl_MVGrid_Style
            // 
            this.Lbl_MVGrid_Style.AutoSize = true;
            this.Lbl_MVGrid_Style.Enabled = false;
            this.Lbl_MVGrid_Style.Location = new System.Drawing.Point(231, 93);
            this.Lbl_MVGrid_Style.Name = "Lbl_MVGrid_Style";
            this.Lbl_MVGrid_Style.Size = new System.Drawing.Size(51, 13);
            this.Lbl_MVGrid_Style.TabIndex = 12;
            this.Lbl_MVGrid_Style.Text = "Line style";
            // 
            // Txt_MVGrid_Width
            // 
            this.Txt_MVGrid_Width.Enabled = false;
            this.Txt_MVGrid_Width.Location = new System.Drawing.Point(147, 90);
            this.Txt_MVGrid_Width.Name = "Txt_MVGrid_Width";
            this.Txt_MVGrid_Width.Size = new System.Drawing.Size(68, 20);
            this.Txt_MVGrid_Width.TabIndex = 11;
            // 
            // Lbl_MVGrid_Width
            // 
            this.Lbl_MVGrid_Width.AutoSize = true;
            this.Lbl_MVGrid_Width.Enabled = false;
            this.Lbl_MVGrid_Width.Location = new System.Drawing.Point(86, 93);
            this.Lbl_MVGrid_Width.Name = "Lbl_MVGrid_Width";
            this.Lbl_MVGrid_Width.Size = new System.Drawing.Size(55, 13);
            this.Lbl_MVGrid_Width.TabIndex = 10;
            this.Lbl_MVGrid_Width.Text = "Line width";
            // 
            // Chk_MVGrid_Visible
            // 
            this.Chk_MVGrid_Visible.AutoSize = true;
            this.Chk_MVGrid_Visible.Location = new System.Drawing.Point(24, 92);
            this.Chk_MVGrid_Visible.Name = "Chk_MVGrid_Visible";
            this.Chk_MVGrid_Visible.Size = new System.Drawing.Size(56, 17);
            this.Chk_MVGrid_Visible.TabIndex = 9;
            this.Chk_MVGrid_Visible.Text = "Visible";
            this.Chk_MVGrid_Visible.UseVisualStyleBackColor = true;
            this.Chk_MVGrid_Visible.CheckedChanged += new System.EventHandler(this.Chk_MVGrid_Visible_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Main vertical grid";
            // 
            // Lbl_MHGrid_Color
            // 
            this.Lbl_MHGrid_Color.AutoSize = true;
            this.Lbl_MHGrid_Color.Enabled = false;
            this.Lbl_MHGrid_Color.Location = new System.Drawing.Point(371, 38);
            this.Lbl_MHGrid_Color.Name = "Lbl_MHGrid_Color";
            this.Lbl_MHGrid_Color.Size = new System.Drawing.Size(53, 13);
            this.Lbl_MHGrid_Color.TabIndex = 6;
            this.Lbl_MHGrid_Color.Text = "Line color";
            // 
            // Cmb_MHGrid_Style
            // 
            this.Cmb_MHGrid_Style.Enabled = false;
            this.Cmb_MHGrid_Style.FormattingEnabled = true;
            this.Cmb_MHGrid_Style.Location = new System.Drawing.Point(288, 35);
            this.Cmb_MHGrid_Style.Name = "Cmb_MHGrid_Style";
            this.Cmb_MHGrid_Style.Size = new System.Drawing.Size(68, 21);
            this.Cmb_MHGrid_Style.TabIndex = 5;
            // 
            // Lbl_MHGrid_Style
            // 
            this.Lbl_MHGrid_Style.AutoSize = true;
            this.Lbl_MHGrid_Style.Enabled = false;
            this.Lbl_MHGrid_Style.Location = new System.Drawing.Point(231, 38);
            this.Lbl_MHGrid_Style.Name = "Lbl_MHGrid_Style";
            this.Lbl_MHGrid_Style.Size = new System.Drawing.Size(51, 13);
            this.Lbl_MHGrid_Style.TabIndex = 4;
            this.Lbl_MHGrid_Style.Text = "Line style";
            // 
            // Txt_MHGrid_Width
            // 
            this.Txt_MHGrid_Width.Enabled = false;
            this.Txt_MHGrid_Width.Location = new System.Drawing.Point(147, 35);
            this.Txt_MHGrid_Width.Name = "Txt_MHGrid_Width";
            this.Txt_MHGrid_Width.Size = new System.Drawing.Size(68, 20);
            this.Txt_MHGrid_Width.TabIndex = 3;
            // 
            // Lbl_MHGrid_Width
            // 
            this.Lbl_MHGrid_Width.AutoSize = true;
            this.Lbl_MHGrid_Width.Enabled = false;
            this.Lbl_MHGrid_Width.Location = new System.Drawing.Point(86, 38);
            this.Lbl_MHGrid_Width.Name = "Lbl_MHGrid_Width";
            this.Lbl_MHGrid_Width.Size = new System.Drawing.Size(55, 13);
            this.Lbl_MHGrid_Width.TabIndex = 2;
            this.Lbl_MHGrid_Width.Text = "Line width";
            // 
            // Chk_MHGrid_Visible
            // 
            this.Chk_MHGrid_Visible.AutoSize = true;
            this.Chk_MHGrid_Visible.Location = new System.Drawing.Point(24, 37);
            this.Chk_MHGrid_Visible.Name = "Chk_MHGrid_Visible";
            this.Chk_MHGrid_Visible.Size = new System.Drawing.Size(56, 17);
            this.Chk_MHGrid_Visible.TabIndex = 1;
            this.Chk_MHGrid_Visible.Text = "Visible";
            this.Chk_MHGrid_Visible.UseVisualStyleBackColor = true;
            this.Chk_MHGrid_Visible.CheckedChanged += new System.EventHandler(this.Chk_MHGrid_Visible_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Main horizontal grid";
            // 
            // Pic_SHGrid_Color
            // 
            this.Pic_SHGrid_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pic_SHGrid_Color.Enabled = false;
            this.Pic_SHGrid_Color.Location = new System.Drawing.Point(430, 149);
            this.Pic_SHGrid_Color.Name = "Pic_SHGrid_Color";
            this.Pic_SHGrid_Color.Size = new System.Drawing.Size(68, 19);
            this.Pic_SHGrid_Color.TabIndex = 23;
            this.Pic_SHGrid_Color.TabStop = false;
            this.Pic_SHGrid_Color.DoubleClick += new System.EventHandler(this.Pic_SHGrid_Color_DoubleClick);
            // 
            // Pic_MVGrid_Color
            // 
            this.Pic_MVGrid_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pic_MVGrid_Color.Enabled = false;
            this.Pic_MVGrid_Color.Location = new System.Drawing.Point(430, 91);
            this.Pic_MVGrid_Color.Name = "Pic_MVGrid_Color";
            this.Pic_MVGrid_Color.Size = new System.Drawing.Size(68, 19);
            this.Pic_MVGrid_Color.TabIndex = 15;
            this.Pic_MVGrid_Color.TabStop = false;
            this.Pic_MVGrid_Color.DoubleClick += new System.EventHandler(this.Pic_MVGrid_Color_DoubleClick);
            // 
            // Pic_MHGrid_Color
            // 
            this.Pic_MHGrid_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pic_MHGrid_Color.Enabled = false;
            this.Pic_MHGrid_Color.Location = new System.Drawing.Point(430, 36);
            this.Pic_MHGrid_Color.Name = "Pic_MHGrid_Color";
            this.Pic_MHGrid_Color.Size = new System.Drawing.Size(68, 19);
            this.Pic_MHGrid_Color.TabIndex = 7;
            this.Pic_MHGrid_Color.TabStop = false;
            this.Pic_MHGrid_Color.DoubleClick += new System.EventHandler(this.Pic_MHGrid_Color_DoubleClick);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.Grp_AbscisseRefLines);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.Grp_AbscisseMode);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(807, 362);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Abscisse";
            // 
            // Grp_AbscisseRefLines
            // 
            this.Grp_AbscisseRefLines.Controls.Add(this.Ctrl_AbcisseRefLines);
            this.Grp_AbscisseRefLines.Location = new System.Drawing.Point(6, 153);
            this.Grp_AbscisseRefLines.Name = "Grp_AbscisseRefLines";
            this.Grp_AbscisseRefLines.Size = new System.Drawing.Size(794, 203);
            this.Grp_AbscisseRefLines.TabIndex = 13;
            this.Grp_AbscisseRefLines.TabStop = false;
            this.Grp_AbscisseRefLines.Text = "Reference lines";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.Cmd_AbscisseFont);
            this.groupBox5.Controls.Add(this.Chk_AbscisseValueVisible);
            this.groupBox5.Controls.Add(this.Txt_AbscisseFontSize);
            this.groupBox5.Controls.Add(this.Lbl_AbscisseFontSize);
            this.groupBox5.Controls.Add(this.Txt_AbscisseFont);
            this.groupBox5.Controls.Add(this.Lbl_AbscisseFont);
            this.groupBox5.Controls.Add(this.Chk_AbscisseVisible);
            this.groupBox5.Controls.Add(this.Pic_AbscisseColor);
            this.groupBox5.Controls.Add(this.Lbl_AbscisseColor);
            this.groupBox5.Controls.Add(this.Txt_AbscisseWidth);
            this.groupBox5.Controls.Add(this.Lbl_AbscisseWidth);
            this.groupBox5.Controls.Add(this.Cmb_AbscisseStyle);
            this.groupBox5.Controls.Add(this.Lbl_AbscisseStyle);
            this.groupBox5.Location = new System.Drawing.Point(6, 67);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(794, 80);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Style";
            // 
            // Cmd_AbscisseFont
            // 
            this.Cmd_AbscisseFont.Enabled = false;
            this.Cmd_AbscisseFont.Image = global::Ctrl_GraphWindow.Icones.font_icone_6304_16;
            this.Cmd_AbscisseFont.Location = new System.Drawing.Point(177, 47);
            this.Cmd_AbscisseFont.Name = "Cmd_AbscisseFont";
            this.Cmd_AbscisseFont.Size = new System.Drawing.Size(23, 23);
            this.Cmd_AbscisseFont.TabIndex = 17;
            this.Cmd_AbscisseFont.UseVisualStyleBackColor = true;
            this.Cmd_AbscisseFont.Click += new System.EventHandler(this.Cmd_AbscisseFont_Click);
            // 
            // Chk_AbscisseValueVisible
            // 
            this.Chk_AbscisseValueVisible.AutoSize = true;
            this.Chk_AbscisseValueVisible.Enabled = false;
            this.Chk_AbscisseValueVisible.Location = new System.Drawing.Point(289, 51);
            this.Chk_AbscisseValueVisible.Name = "Chk_AbscisseValueVisible";
            this.Chk_AbscisseValueVisible.Size = new System.Drawing.Size(90, 17);
            this.Chk_AbscisseValueVisible.TabIndex = 16;
            this.Chk_AbscisseValueVisible.Text = "Values visible";
            this.Chk_AbscisseValueVisible.UseVisualStyleBackColor = true;
            this.Chk_AbscisseValueVisible.CheckedChanged += new System.EventHandler(this.Chk_AbscisseValueVisible_CheckedChanged);
            // 
            // Txt_AbscisseFontSize
            // 
            this.Txt_AbscisseFontSize.Enabled = false;
            this.Txt_AbscisseFontSize.Location = new System.Drawing.Point(239, 49);
            this.Txt_AbscisseFontSize.Name = "Txt_AbscisseFontSize";
            this.Txt_AbscisseFontSize.ReadOnly = true;
            this.Txt_AbscisseFontSize.Size = new System.Drawing.Size(44, 20);
            this.Txt_AbscisseFontSize.TabIndex = 15;
            // 
            // Lbl_AbscisseFontSize
            // 
            this.Lbl_AbscisseFontSize.AutoSize = true;
            this.Lbl_AbscisseFontSize.Enabled = false;
            this.Lbl_AbscisseFontSize.Location = new System.Drawing.Point(206, 52);
            this.Lbl_AbscisseFontSize.Name = "Lbl_AbscisseFontSize";
            this.Lbl_AbscisseFontSize.Size = new System.Drawing.Size(27, 13);
            this.Lbl_AbscisseFontSize.TabIndex = 14;
            this.Lbl_AbscisseFontSize.Text = "Size";
            // 
            // Txt_AbscisseFont
            // 
            this.Txt_AbscisseFont.Enabled = false;
            this.Txt_AbscisseFont.Location = new System.Drawing.Point(65, 49);
            this.Txt_AbscisseFont.Name = "Txt_AbscisseFont";
            this.Txt_AbscisseFont.ReadOnly = true;
            this.Txt_AbscisseFont.Size = new System.Drawing.Size(106, 20);
            this.Txt_AbscisseFont.TabIndex = 13;
            // 
            // Lbl_AbscisseFont
            // 
            this.Lbl_AbscisseFont.AutoSize = true;
            this.Lbl_AbscisseFont.Enabled = false;
            this.Lbl_AbscisseFont.Location = new System.Drawing.Point(8, 52);
            this.Lbl_AbscisseFont.Name = "Lbl_AbscisseFont";
            this.Lbl_AbscisseFont.Size = new System.Drawing.Size(28, 13);
            this.Lbl_AbscisseFont.TabIndex = 12;
            this.Lbl_AbscisseFont.Text = "Font";
            // 
            // Chk_AbscisseVisible
            // 
            this.Chk_AbscisseVisible.AutoSize = true;
            this.Chk_AbscisseVisible.Location = new System.Drawing.Point(177, 24);
            this.Chk_AbscisseVisible.Name = "Chk_AbscisseVisible";
            this.Chk_AbscisseVisible.Size = new System.Drawing.Size(56, 17);
            this.Chk_AbscisseVisible.TabIndex = 8;
            this.Chk_AbscisseVisible.Text = "Visible";
            this.Chk_AbscisseVisible.UseVisualStyleBackColor = true;
            this.Chk_AbscisseVisible.CheckedChanged += new System.EventHandler(this.Chk_AbscisseVisible_CheckedChanged);
            // 
            // Pic_AbscisseColor
            // 
            this.Pic_AbscisseColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AbscisseColor.Enabled = false;
            this.Pic_AbscisseColor.Location = new System.Drawing.Point(405, 22);
            this.Pic_AbscisseColor.Name = "Pic_AbscisseColor";
            this.Pic_AbscisseColor.Size = new System.Drawing.Size(20, 20);
            this.Pic_AbscisseColor.TabIndex = 7;
            this.Pic_AbscisseColor.TabStop = false;
            this.Pic_AbscisseColor.DoubleClick += new System.EventHandler(this.Pic_AbscisseColor_DoubleClick);
            // 
            // Lbl_AbscisseColor
            // 
            this.Lbl_AbscisseColor.AutoSize = true;
            this.Lbl_AbscisseColor.Enabled = false;
            this.Lbl_AbscisseColor.Location = new System.Drawing.Point(346, 25);
            this.Lbl_AbscisseColor.Name = "Lbl_AbscisseColor";
            this.Lbl_AbscisseColor.Size = new System.Drawing.Size(53, 13);
            this.Lbl_AbscisseColor.TabIndex = 6;
            this.Lbl_AbscisseColor.Text = "Line color";
            // 
            // Txt_AbscisseWidth
            // 
            this.Txt_AbscisseWidth.Enabled = false;
            this.Txt_AbscisseWidth.Location = new System.Drawing.Point(296, 22);
            this.Txt_AbscisseWidth.Name = "Txt_AbscisseWidth";
            this.Txt_AbscisseWidth.Size = new System.Drawing.Size(44, 20);
            this.Txt_AbscisseWidth.TabIndex = 5;
            // 
            // Lbl_AbscisseWidth
            // 
            this.Lbl_AbscisseWidth.AutoSize = true;
            this.Lbl_AbscisseWidth.Enabled = false;
            this.Lbl_AbscisseWidth.Location = new System.Drawing.Point(239, 25);
            this.Lbl_AbscisseWidth.Name = "Lbl_AbscisseWidth";
            this.Lbl_AbscisseWidth.Size = new System.Drawing.Size(55, 13);
            this.Lbl_AbscisseWidth.TabIndex = 4;
            this.Lbl_AbscisseWidth.Text = "Line width";
            // 
            // Cmb_AbscisseStyle
            // 
            this.Cmb_AbscisseStyle.Enabled = false;
            this.Cmb_AbscisseStyle.FormattingEnabled = true;
            this.Cmb_AbscisseStyle.Location = new System.Drawing.Point(65, 22);
            this.Cmb_AbscisseStyle.Name = "Cmb_AbscisseStyle";
            this.Cmb_AbscisseStyle.Size = new System.Drawing.Size(106, 21);
            this.Cmb_AbscisseStyle.TabIndex = 1;
            // 
            // Lbl_AbscisseStyle
            // 
            this.Lbl_AbscisseStyle.AutoSize = true;
            this.Lbl_AbscisseStyle.Enabled = false;
            this.Lbl_AbscisseStyle.Location = new System.Drawing.Point(8, 25);
            this.Lbl_AbscisseStyle.Name = "Lbl_AbscisseStyle";
            this.Lbl_AbscisseStyle.Size = new System.Drawing.Size(51, 13);
            this.Lbl_AbscisseStyle.TabIndex = 0;
            this.Lbl_AbscisseStyle.Text = "Line style";
            // 
            // Grp_AbscisseMode
            // 
            this.Grp_AbscisseMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_AbscisseMode.Controls.Add(this.Cmb_AbscisseChannel);
            this.Grp_AbscisseMode.Controls.Add(this.Lbl_AbscisseChannel);
            this.Grp_AbscisseMode.Controls.Add(this.Chk_AbscisseTimeMode);
            this.Grp_AbscisseMode.Location = new System.Drawing.Point(6, 6);
            this.Grp_AbscisseMode.Name = "Grp_AbscisseMode";
            this.Grp_AbscisseMode.Size = new System.Drawing.Size(794, 55);
            this.Grp_AbscisseMode.TabIndex = 12;
            this.Grp_AbscisseMode.TabStop = false;
            this.Grp_AbscisseMode.Text = "Abscisse mode";
            // 
            // Cmb_AbscisseChannel
            // 
            this.Cmb_AbscisseChannel.Enabled = false;
            this.Cmb_AbscisseChannel.FormattingEnabled = true;
            this.Cmb_AbscisseChannel.Location = new System.Drawing.Point(191, 17);
            this.Cmb_AbscisseChannel.Name = "Cmb_AbscisseChannel";
            this.Cmb_AbscisseChannel.Size = new System.Drawing.Size(149, 21);
            this.Cmb_AbscisseChannel.TabIndex = 11;
            // 
            // Lbl_AbscisseChannel
            // 
            this.Lbl_AbscisseChannel.AutoSize = true;
            this.Lbl_AbscisseChannel.Enabled = false;
            this.Lbl_AbscisseChannel.Location = new System.Drawing.Point(95, 20);
            this.Lbl_AbscisseChannel.Name = "Lbl_AbscisseChannel";
            this.Lbl_AbscisseChannel.Size = new System.Drawing.Size(90, 13);
            this.Lbl_AbscisseChannel.TabIndex = 10;
            this.Lbl_AbscisseChannel.Text = "Abscisse channel";
            // 
            // Chk_AbscisseTimeMode
            // 
            this.Chk_AbscisseTimeMode.AutoSize = true;
            this.Chk_AbscisseTimeMode.Location = new System.Drawing.Point(11, 19);
            this.Chk_AbscisseTimeMode.Name = "Chk_AbscisseTimeMode";
            this.Chk_AbscisseTimeMode.Size = new System.Drawing.Size(78, 17);
            this.Chk_AbscisseTimeMode.TabIndex = 9;
            this.Chk_AbscisseTimeMode.Text = "Time mode";
            this.Chk_AbscisseTimeMode.UseVisualStyleBackColor = true;
            this.Chk_AbscisseTimeMode.CheckedChanged += new System.EventHandler(this.Chk_AbscisseTimeMode_CheckedChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(807, 362);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Cursors";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.Cmb_RefCursorOrdValLocation);
            this.groupBox6.Controls.Add(this.Lbl_RefCursorOrdValLocation);
            this.groupBox6.Controls.Add(this.Chk_RefCursorOrdValVisible);
            this.groupBox6.Controls.Add(this.Cmd_RefCursorValFont);
            this.groupBox6.Controls.Add(this.Txt_RefCursorValFontSize);
            this.groupBox6.Controls.Add(this.Lbl_RefCursorValFontSize);
            this.groupBox6.Controls.Add(this.Txt_RefCursorValFont);
            this.groupBox6.Controls.Add(this.Lbl_RefCursorValFont);
            this.groupBox6.Controls.Add(this.Cmb_RefCursorAbsValLocation);
            this.groupBox6.Controls.Add(this.Lbl_RefCursorAbsValLocation);
            this.groupBox6.Controls.Add(this.Chk_RefCursorAbsValVisible);
            this.groupBox6.Controls.Add(this.Pic_RefCursorLineColor);
            this.groupBox6.Controls.Add(this.Lbl_RefCursorLineColor);
            this.groupBox6.Controls.Add(this.Txt_RefCursorLineWidth);
            this.groupBox6.Controls.Add(this.Lbl_RefCursorLineWidth);
            this.groupBox6.Controls.Add(this.Cmb_RefCursorLineStyle);
            this.groupBox6.Controls.Add(this.Lbl_RefCursorLineStyle);
            this.groupBox6.Controls.Add(this.Cmb_RefCursorMode);
            this.groupBox6.Controls.Add(this.Lbl_RefCursorMode);
            this.groupBox6.Location = new System.Drawing.Point(5, 207);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(794, 148);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Reference cursor";
            // 
            // Cmb_RefCursorOrdValLocation
            // 
            this.Cmb_RefCursorOrdValLocation.Enabled = false;
            this.Cmb_RefCursorOrdValLocation.FormattingEnabled = true;
            this.Cmb_RefCursorOrdValLocation.Location = new System.Drawing.Point(303, 73);
            this.Cmb_RefCursorOrdValLocation.Name = "Cmb_RefCursorOrdValLocation";
            this.Cmb_RefCursorOrdValLocation.Size = new System.Drawing.Size(106, 21);
            this.Cmb_RefCursorOrdValLocation.TabIndex = 29;
            // 
            // Lbl_RefCursorOrdValLocation
            // 
            this.Lbl_RefCursorOrdValLocation.Enabled = false;
            this.Lbl_RefCursorOrdValLocation.Location = new System.Drawing.Point(217, 76);
            this.Lbl_RefCursorOrdValLocation.Name = "Lbl_RefCursorOrdValLocation";
            this.Lbl_RefCursorOrdValLocation.Size = new System.Drawing.Size(80, 19);
            this.Lbl_RefCursorOrdValLocation.TabIndex = 28;
            this.Lbl_RefCursorOrdValLocation.Text = "Value location";
            // 
            // Chk_RefCursorOrdValVisible
            // 
            this.Chk_RefCursorOrdValVisible.Enabled = false;
            this.Chk_RefCursorOrdValVisible.Location = new System.Drawing.Point(17, 71);
            this.Chk_RefCursorOrdValVisible.Name = "Chk_RefCursorOrdValVisible";
            this.Chk_RefCursorOrdValVisible.Size = new System.Drawing.Size(181, 24);
            this.Chk_RefCursorOrdValVisible.TabIndex = 27;
            this.Chk_RefCursorOrdValVisible.Text = "Show Y cursor values";
            this.Chk_RefCursorOrdValVisible.UseVisualStyleBackColor = true;
            this.Chk_RefCursorOrdValVisible.CheckedChanged += new System.EventHandler(this.Chk_RefCursorOrdValVisibleCheckedChanged);
            // 
            // Cmd_RefCursorValFont
            // 
            this.Cmd_RefCursorValFont.Enabled = false;
            this.Cmd_RefCursorValFont.Image = global::Ctrl_GraphWindow.Icones.font_icone_6304_16;
            this.Cmd_RefCursorValFont.Location = new System.Drawing.Point(217, 104);
            this.Cmd_RefCursorValFont.Name = "Cmd_RefCursorValFont";
            this.Cmd_RefCursorValFont.Size = new System.Drawing.Size(23, 23);
            this.Cmd_RefCursorValFont.TabIndex = 26;
            this.Cmd_RefCursorValFont.UseVisualStyleBackColor = true;
            this.Cmd_RefCursorValFont.Click += new System.EventHandler(this.Cmd_RefCursorValFontClick);
            // 
            // Txt_RefCursorValFontSize
            // 
            this.Txt_RefCursorValFontSize.Enabled = false;
            this.Txt_RefCursorValFontSize.Location = new System.Drawing.Point(282, 104);
            this.Txt_RefCursorValFontSize.Name = "Txt_RefCursorValFontSize";
            this.Txt_RefCursorValFontSize.ReadOnly = true;
            this.Txt_RefCursorValFontSize.Size = new System.Drawing.Size(44, 20);
            this.Txt_RefCursorValFontSize.TabIndex = 25;
            // 
            // Lbl_RefCursorValFontSize
            // 
            this.Lbl_RefCursorValFontSize.AutoSize = true;
            this.Lbl_RefCursorValFontSize.Enabled = false;
            this.Lbl_RefCursorValFontSize.Location = new System.Drawing.Point(246, 107);
            this.Lbl_RefCursorValFontSize.Name = "Lbl_RefCursorValFontSize";
            this.Lbl_RefCursorValFontSize.Size = new System.Drawing.Size(27, 13);
            this.Lbl_RefCursorValFontSize.TabIndex = 24;
            this.Lbl_RefCursorValFontSize.Text = "Size";
            // 
            // Txt_RefCursorValFont
            // 
            this.Txt_RefCursorValFont.Enabled = false;
            this.Txt_RefCursorValFont.Location = new System.Drawing.Point(105, 104);
            this.Txt_RefCursorValFont.Name = "Txt_RefCursorValFont";
            this.Txt_RefCursorValFont.ReadOnly = true;
            this.Txt_RefCursorValFont.Size = new System.Drawing.Size(106, 20);
            this.Txt_RefCursorValFont.TabIndex = 23;
            // 
            // Lbl_RefCursorValFont
            // 
            this.Lbl_RefCursorValFont.AutoSize = true;
            this.Lbl_RefCursorValFont.Enabled = false;
            this.Lbl_RefCursorValFont.Location = new System.Drawing.Point(14, 107);
            this.Lbl_RefCursorValFont.Name = "Lbl_RefCursorValFont";
            this.Lbl_RefCursorValFont.Size = new System.Drawing.Size(87, 13);
            this.Lbl_RefCursorValFont.TabIndex = 22;
            this.Lbl_RefCursorValFont.Text = "Cursor value font";
            // 
            // Cmb_RefCursorAbsValLocation
            // 
            this.Cmb_RefCursorAbsValLocation.Enabled = false;
            this.Cmb_RefCursorAbsValLocation.FormattingEnabled = true;
            this.Cmb_RefCursorAbsValLocation.Location = new System.Drawing.Point(303, 46);
            this.Cmb_RefCursorAbsValLocation.Name = "Cmb_RefCursorAbsValLocation";
            this.Cmb_RefCursorAbsValLocation.Size = new System.Drawing.Size(106, 21);
            this.Cmb_RefCursorAbsValLocation.TabIndex = 16;
            // 
            // Lbl_RefCursorAbsValLocation
            // 
            this.Lbl_RefCursorAbsValLocation.Enabled = false;
            this.Lbl_RefCursorAbsValLocation.Location = new System.Drawing.Point(217, 49);
            this.Lbl_RefCursorAbsValLocation.Name = "Lbl_RefCursorAbsValLocation";
            this.Lbl_RefCursorAbsValLocation.Size = new System.Drawing.Size(80, 19);
            this.Lbl_RefCursorAbsValLocation.TabIndex = 15;
            this.Lbl_RefCursorAbsValLocation.Text = "Value location";
            // 
            // Chk_RefCursorAbsValVisible
            // 
            this.Chk_RefCursorAbsValVisible.Enabled = false;
            this.Chk_RefCursorAbsValVisible.Location = new System.Drawing.Point(17, 44);
            this.Chk_RefCursorAbsValVisible.Name = "Chk_RefCursorAbsValVisible";
            this.Chk_RefCursorAbsValVisible.Size = new System.Drawing.Size(181, 24);
            this.Chk_RefCursorAbsValVisible.TabIndex = 14;
            this.Chk_RefCursorAbsValVisible.Text = "Show X cursor value";
            this.Chk_RefCursorAbsValVisible.UseVisualStyleBackColor = true;
            this.Chk_RefCursorAbsValVisible.CheckedChanged += new System.EventHandler(this.Chk_RefCursorAbsValVisibleCheckedChanged);
            // 
            // Pic_RefCursorLineColor
            // 
            this.Pic_RefCursorLineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_RefCursorLineColor.Enabled = false;
            this.Pic_RefCursorLineColor.Location = new System.Drawing.Point(581, 19);
            this.Pic_RefCursorLineColor.Name = "Pic_RefCursorLineColor";
            this.Pic_RefCursorLineColor.Size = new System.Drawing.Size(20, 20);
            this.Pic_RefCursorLineColor.TabIndex = 13;
            this.Pic_RefCursorLineColor.TabStop = false;
            this.Pic_RefCursorLineColor.DoubleClick += new System.EventHandler(this.Pic_RefCursorLineColorDoubleClick);
            // 
            // Lbl_RefCursorLineColor
            // 
            this.Lbl_RefCursorLineColor.AutoSize = true;
            this.Lbl_RefCursorLineColor.Enabled = false;
            this.Lbl_RefCursorLineColor.Location = new System.Drawing.Point(522, 22);
            this.Lbl_RefCursorLineColor.Name = "Lbl_RefCursorLineColor";
            this.Lbl_RefCursorLineColor.Size = new System.Drawing.Size(53, 13);
            this.Lbl_RefCursorLineColor.TabIndex = 12;
            this.Lbl_RefCursorLineColor.Text = "Line color";
            // 
            // Txt_RefCursorLineWidth
            // 
            this.Txt_RefCursorLineWidth.Enabled = false;
            this.Txt_RefCursorLineWidth.Location = new System.Drawing.Point(472, 19);
            this.Txt_RefCursorLineWidth.Name = "Txt_RefCursorLineWidth";
            this.Txt_RefCursorLineWidth.Size = new System.Drawing.Size(44, 20);
            this.Txt_RefCursorLineWidth.TabIndex = 11;
            // 
            // Lbl_RefCursorLineWidth
            // 
            this.Lbl_RefCursorLineWidth.AutoSize = true;
            this.Lbl_RefCursorLineWidth.Enabled = false;
            this.Lbl_RefCursorLineWidth.Location = new System.Drawing.Point(415, 22);
            this.Lbl_RefCursorLineWidth.Name = "Lbl_RefCursorLineWidth";
            this.Lbl_RefCursorLineWidth.Size = new System.Drawing.Size(55, 13);
            this.Lbl_RefCursorLineWidth.TabIndex = 10;
            this.Lbl_RefCursorLineWidth.Text = "Line width";
            // 
            // Cmb_RefCursorLineStyle
            // 
            this.Cmb_RefCursorLineStyle.Enabled = false;
            this.Cmb_RefCursorLineStyle.FormattingEnabled = true;
            this.Cmb_RefCursorLineStyle.Location = new System.Drawing.Point(303, 19);
            this.Cmb_RefCursorLineStyle.Name = "Cmb_RefCursorLineStyle";
            this.Cmb_RefCursorLineStyle.Size = new System.Drawing.Size(106, 21);
            this.Cmb_RefCursorLineStyle.TabIndex = 9;
            // 
            // Lbl_RefCursorLineStyle
            // 
            this.Lbl_RefCursorLineStyle.AutoSize = true;
            this.Lbl_RefCursorLineStyle.Enabled = false;
            this.Lbl_RefCursorLineStyle.Location = new System.Drawing.Point(217, 22);
            this.Lbl_RefCursorLineStyle.Name = "Lbl_RefCursorLineStyle";
            this.Lbl_RefCursorLineStyle.Size = new System.Drawing.Size(80, 13);
            this.Lbl_RefCursorLineStyle.TabIndex = 8;
            this.Lbl_RefCursorLineStyle.Text = "Cursor line style";
            // 
            // Cmb_RefCursorMode
            // 
            this.Cmb_RefCursorMode.FormattingEnabled = true;
            this.Cmb_RefCursorMode.Location = new System.Drawing.Point(105, 19);
            this.Cmb_RefCursorMode.Name = "Cmb_RefCursorMode";
            this.Cmb_RefCursorMode.Size = new System.Drawing.Size(106, 21);
            this.Cmb_RefCursorMode.TabIndex = 1;
            this.Cmb_RefCursorMode.SelectedIndexChanged += new System.EventHandler(this.Cmb_RefCursorModeSelectedIndexChanged);
            // 
            // Lbl_RefCursorMode
            // 
            this.Lbl_RefCursorMode.Location = new System.Drawing.Point(17, 26);
            this.Lbl_RefCursorMode.Name = "Lbl_RefCursorMode";
            this.Lbl_RefCursorMode.Size = new System.Drawing.Size(61, 15);
            this.Lbl_RefCursorMode.TabIndex = 0;
            this.Lbl_RefCursorMode.Text = "Mode";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.Cmb_CursorTitleLocation);
            this.groupBox4.Controls.Add(this.Lbl_CursorTitleLocation);
            this.groupBox4.Controls.Add(this.Txt_CursorTitle);
            this.groupBox4.Controls.Add(this.Lbl_CursorTitle);
            this.groupBox4.Controls.Add(this.Pic_CursorTitleForecolor);
            this.groupBox4.Controls.Add(this.Lbl_CursorTitleForecolor);
            this.groupBox4.Controls.Add(this.Cmd_CursorTitleFont);
            this.groupBox4.Controls.Add(this.Txt_CursorTitleFontSize);
            this.groupBox4.Controls.Add(this.Lbl_CursorTitleFontSize);
            this.groupBox4.Controls.Add(this.Txt_CursorTitleFont);
            this.groupBox4.Controls.Add(this.Lbl_CursorTitleFont);
            this.groupBox4.Controls.Add(this.Pic_CursorValueForecolor);
            this.groupBox4.Controls.Add(this.Lbl_CursorValueForecolor);
            this.groupBox4.Controls.Add(this.Cmd_CursorValFont);
            this.groupBox4.Controls.Add(this.Txt_CursorValFontSize);
            this.groupBox4.Controls.Add(this.Lbl_CursorValFontSize);
            this.groupBox4.Controls.Add(this.Txt_CursorValFont);
            this.groupBox4.Controls.Add(this.Lbl_CursorValFont);
            this.groupBox4.Controls.Add(this.Txt_CursorSize);
            this.groupBox4.Controls.Add(this.Lbl_CursorSize);
            this.groupBox4.Controls.Add(this.Cmb_CursorOrdValLocation);
            this.groupBox4.Controls.Add(this.Lbl_CursorOrdValLocation);
            this.groupBox4.Controls.Add(this.Chk_CursorOrdValVisible);
            this.groupBox4.Controls.Add(this.Cmb_CursorAbsValLocation);
            this.groupBox4.Controls.Add(this.Lbl_CursorAbsValLocation);
            this.groupBox4.Controls.Add(this.Chk_CursorAbsValVisible);
            this.groupBox4.Controls.Add(this.Pic_CursorLineColor);
            this.groupBox4.Controls.Add(this.Lbl_CursorLineColor);
            this.groupBox4.Controls.Add(this.Txt_CursorLineWidth);
            this.groupBox4.Controls.Add(this.Lbl_CursorLineWidth);
            this.groupBox4.Controls.Add(this.Cmb_CursorLineStyle);
            this.groupBox4.Controls.Add(this.Lbl_CursorLineStyle);
            this.groupBox4.Controls.Add(this.Cmb_MainCursorMode);
            this.groupBox4.Controls.Add(this.Lbl_MainCursorMode);
            this.groupBox4.Location = new System.Drawing.Point(5, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(794, 198);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Main cursor";
            // 
            // Cmd_CursorValFont
            // 
            this.Cmd_CursorValFont.Enabled = false;
            this.Cmd_CursorValFont.Image = global::Ctrl_GraphWindow.Icones.font_icone_6304_16;
            this.Cmd_CursorValFont.Location = new System.Drawing.Point(217, 101);
            this.Cmd_CursorValFont.Name = "Cmd_CursorValFont";
            this.Cmd_CursorValFont.Size = new System.Drawing.Size(23, 23);
            this.Cmd_CursorValFont.TabIndex = 26;
            this.Cmd_CursorValFont.UseVisualStyleBackColor = true;
            this.Cmd_CursorValFont.Click += new System.EventHandler(this.Cmd_CursorValFontClick);
            // 
            // Txt_CursorValFontSize
            // 
            this.Txt_CursorValFontSize.Enabled = false;
            this.Txt_CursorValFontSize.Location = new System.Drawing.Point(282, 104);
            this.Txt_CursorValFontSize.Name = "Txt_CursorValFontSize";
            this.Txt_CursorValFontSize.ReadOnly = true;
            this.Txt_CursorValFontSize.Size = new System.Drawing.Size(44, 20);
            this.Txt_CursorValFontSize.TabIndex = 25;
            // 
            // Lbl_CursorValFontSize
            // 
            this.Lbl_CursorValFontSize.AutoSize = true;
            this.Lbl_CursorValFontSize.Enabled = false;
            this.Lbl_CursorValFontSize.Location = new System.Drawing.Point(246, 107);
            this.Lbl_CursorValFontSize.Name = "Lbl_CursorValFontSize";
            this.Lbl_CursorValFontSize.Size = new System.Drawing.Size(27, 13);
            this.Lbl_CursorValFontSize.TabIndex = 24;
            this.Lbl_CursorValFontSize.Text = "Size";
            // 
            // Txt_CursorValFont
            // 
            this.Txt_CursorValFont.Enabled = false;
            this.Txt_CursorValFont.Location = new System.Drawing.Point(105, 103);
            this.Txt_CursorValFont.Name = "Txt_CursorValFont";
            this.Txt_CursorValFont.ReadOnly = true;
            this.Txt_CursorValFont.Size = new System.Drawing.Size(106, 20);
            this.Txt_CursorValFont.TabIndex = 23;
            // 
            // Lbl_CursorValFont
            // 
            this.Lbl_CursorValFont.AutoSize = true;
            this.Lbl_CursorValFont.Enabled = false;
            this.Lbl_CursorValFont.Location = new System.Drawing.Point(14, 106);
            this.Lbl_CursorValFont.Name = "Lbl_CursorValFont";
            this.Lbl_CursorValFont.Size = new System.Drawing.Size(87, 13);
            this.Lbl_CursorValFont.TabIndex = 22;
            this.Lbl_CursorValFont.Text = "Cursor value font";
            // 
            // Txt_CursorSize
            // 
            this.Txt_CursorSize.Enabled = false;
            this.Txt_CursorSize.Location = new System.Drawing.Point(664, 19);
            this.Txt_CursorSize.Name = "Txt_CursorSize";
            this.Txt_CursorSize.Size = new System.Drawing.Size(44, 20);
            this.Txt_CursorSize.TabIndex = 21;
            // 
            // Lbl_CursorSize
            // 
            this.Lbl_CursorSize.AutoSize = true;
            this.Lbl_CursorSize.Enabled = false;
            this.Lbl_CursorSize.Location = new System.Drawing.Point(607, 22);
            this.Lbl_CursorSize.Name = "Lbl_CursorSize";
            this.Lbl_CursorSize.Size = new System.Drawing.Size(58, 13);
            this.Lbl_CursorSize.TabIndex = 20;
            this.Lbl_CursorSize.Text = "Cursor size";
            // 
            // Cmb_CursorOrdValLocation
            // 
            this.Cmb_CursorOrdValLocation.Enabled = false;
            this.Cmb_CursorOrdValLocation.FormattingEnabled = true;
            this.Cmb_CursorOrdValLocation.Location = new System.Drawing.Point(303, 76);
            this.Cmb_CursorOrdValLocation.Name = "Cmb_CursorOrdValLocation";
            this.Cmb_CursorOrdValLocation.Size = new System.Drawing.Size(106, 21);
            this.Cmb_CursorOrdValLocation.TabIndex = 19;
            // 
            // Lbl_CursorOrdValLocation
            // 
            this.Lbl_CursorOrdValLocation.Enabled = false;
            this.Lbl_CursorOrdValLocation.Location = new System.Drawing.Point(217, 79);
            this.Lbl_CursorOrdValLocation.Name = "Lbl_CursorOrdValLocation";
            this.Lbl_CursorOrdValLocation.Size = new System.Drawing.Size(80, 19);
            this.Lbl_CursorOrdValLocation.TabIndex = 18;
            this.Lbl_CursorOrdValLocation.Text = "Value location";
            // 
            // Chk_CursorOrdValVisible
            // 
            this.Chk_CursorOrdValVisible.Enabled = false;
            this.Chk_CursorOrdValVisible.Location = new System.Drawing.Point(17, 74);
            this.Chk_CursorOrdValVisible.Name = "Chk_CursorOrdValVisible";
            this.Chk_CursorOrdValVisible.Size = new System.Drawing.Size(181, 24);
            this.Chk_CursorOrdValVisible.TabIndex = 17;
            this.Chk_CursorOrdValVisible.Text = "Show Y cursor values";
            this.Chk_CursorOrdValVisible.UseVisualStyleBackColor = true;
            this.Chk_CursorOrdValVisible.CheckedChanged += new System.EventHandler(this.Chk_CursorOrdValVisibleCheckedChanged);
            // 
            // Cmb_CursorAbsValLocation
            // 
            this.Cmb_CursorAbsValLocation.Enabled = false;
            this.Cmb_CursorAbsValLocation.FormattingEnabled = true;
            this.Cmb_CursorAbsValLocation.Location = new System.Drawing.Point(303, 46);
            this.Cmb_CursorAbsValLocation.Name = "Cmb_CursorAbsValLocation";
            this.Cmb_CursorAbsValLocation.Size = new System.Drawing.Size(106, 21);
            this.Cmb_CursorAbsValLocation.TabIndex = 16;
            // 
            // Lbl_CursorAbsValLocation
            // 
            this.Lbl_CursorAbsValLocation.Enabled = false;
            this.Lbl_CursorAbsValLocation.Location = new System.Drawing.Point(217, 49);
            this.Lbl_CursorAbsValLocation.Name = "Lbl_CursorAbsValLocation";
            this.Lbl_CursorAbsValLocation.Size = new System.Drawing.Size(80, 19);
            this.Lbl_CursorAbsValLocation.TabIndex = 15;
            this.Lbl_CursorAbsValLocation.Text = "Value location";
            // 
            // Chk_CursorAbsValVisible
            // 
            this.Chk_CursorAbsValVisible.Enabled = false;
            this.Chk_CursorAbsValVisible.Location = new System.Drawing.Point(17, 44);
            this.Chk_CursorAbsValVisible.Name = "Chk_CursorAbsValVisible";
            this.Chk_CursorAbsValVisible.Size = new System.Drawing.Size(181, 24);
            this.Chk_CursorAbsValVisible.TabIndex = 14;
            this.Chk_CursorAbsValVisible.Text = "Show X cursor value";
            this.Chk_CursorAbsValVisible.UseVisualStyleBackColor = true;
            this.Chk_CursorAbsValVisible.CheckedChanged += new System.EventHandler(this.Chk_CursorAbsValVisibleCheckedChanged);
            // 
            // Pic_CursorLineColor
            // 
            this.Pic_CursorLineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_CursorLineColor.Enabled = false;
            this.Pic_CursorLineColor.Location = new System.Drawing.Point(581, 19);
            this.Pic_CursorLineColor.Name = "Pic_CursorLineColor";
            this.Pic_CursorLineColor.Size = new System.Drawing.Size(20, 20);
            this.Pic_CursorLineColor.TabIndex = 13;
            this.Pic_CursorLineColor.TabStop = false;
            this.Pic_CursorLineColor.DoubleClick += new System.EventHandler(this.Pic_CursorLineColorDoubleClick);
            // 
            // Lbl_CursorLineColor
            // 
            this.Lbl_CursorLineColor.AutoSize = true;
            this.Lbl_CursorLineColor.Enabled = false;
            this.Lbl_CursorLineColor.Location = new System.Drawing.Point(522, 22);
            this.Lbl_CursorLineColor.Name = "Lbl_CursorLineColor";
            this.Lbl_CursorLineColor.Size = new System.Drawing.Size(53, 13);
            this.Lbl_CursorLineColor.TabIndex = 12;
            this.Lbl_CursorLineColor.Text = "Line color";
            // 
            // Txt_CursorLineWidth
            // 
            this.Txt_CursorLineWidth.Enabled = false;
            this.Txt_CursorLineWidth.Location = new System.Drawing.Point(472, 19);
            this.Txt_CursorLineWidth.Name = "Txt_CursorLineWidth";
            this.Txt_CursorLineWidth.Size = new System.Drawing.Size(44, 20);
            this.Txt_CursorLineWidth.TabIndex = 11;
            // 
            // Lbl_CursorLineWidth
            // 
            this.Lbl_CursorLineWidth.AutoSize = true;
            this.Lbl_CursorLineWidth.Enabled = false;
            this.Lbl_CursorLineWidth.Location = new System.Drawing.Point(415, 22);
            this.Lbl_CursorLineWidth.Name = "Lbl_CursorLineWidth";
            this.Lbl_CursorLineWidth.Size = new System.Drawing.Size(55, 13);
            this.Lbl_CursorLineWidth.TabIndex = 10;
            this.Lbl_CursorLineWidth.Text = "Line width";
            // 
            // Cmb_CursorLineStyle
            // 
            this.Cmb_CursorLineStyle.Enabled = false;
            this.Cmb_CursorLineStyle.FormattingEnabled = true;
            this.Cmb_CursorLineStyle.Location = new System.Drawing.Point(303, 19);
            this.Cmb_CursorLineStyle.Name = "Cmb_CursorLineStyle";
            this.Cmb_CursorLineStyle.Size = new System.Drawing.Size(106, 21);
            this.Cmb_CursorLineStyle.TabIndex = 9;
            // 
            // Lbl_CursorLineStyle
            // 
            this.Lbl_CursorLineStyle.AutoSize = true;
            this.Lbl_CursorLineStyle.Enabled = false;
            this.Lbl_CursorLineStyle.Location = new System.Drawing.Point(217, 22);
            this.Lbl_CursorLineStyle.Name = "Lbl_CursorLineStyle";
            this.Lbl_CursorLineStyle.Size = new System.Drawing.Size(80, 13);
            this.Lbl_CursorLineStyle.TabIndex = 8;
            this.Lbl_CursorLineStyle.Text = "Cursor line style";
            // 
            // Cmb_MainCursorMode
            // 
            this.Cmb_MainCursorMode.FormattingEnabled = true;
            this.Cmb_MainCursorMode.Location = new System.Drawing.Point(105, 19);
            this.Cmb_MainCursorMode.Name = "Cmb_MainCursorMode";
            this.Cmb_MainCursorMode.Size = new System.Drawing.Size(106, 21);
            this.Cmb_MainCursorMode.TabIndex = 1;
            this.Cmb_MainCursorMode.SelectedIndexChanged += new System.EventHandler(this.Cmb_MainCursorModeSelectedIndexChanged);
            // 
            // Lbl_MainCursorMode
            // 
            this.Lbl_MainCursorMode.Location = new System.Drawing.Point(17, 26);
            this.Lbl_MainCursorMode.Name = "Lbl_MainCursorMode";
            this.Lbl_MainCursorMode.Size = new System.Drawing.Size(61, 15);
            this.Lbl_MainCursorMode.TabIndex = 0;
            this.Lbl_MainCursorMode.Text = "Mode";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_Apply,
            this.TSB_Cancel,
            this.toolStripSeparator1,
            this.TSB_New,
            this.TSB_Open,
            this.TSB_Save,
            this.toolStripSeparator2,
            this.TSB_ChannelList,
            this.TSB_NewSerie,
            this.TSB_DelSerie,
            this.TSB_CopySerie,
            this.TSB_PasteSerie,
            this.TSB_MoveUp,
            this.TSB_MoveDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(818, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSB_Apply
            // 
            this.TSB_Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Apply.Image = global::Ctrl_GraphWindow.Icones.accepter_check_ok_oui_icone_4851;
            this.TSB_Apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Apply.Name = "TSB_Apply";
            this.TSB_Apply.Size = new System.Drawing.Size(23, 22);
            this.TSB_Apply.Text = "toolStripButton1";
            this.TSB_Apply.ToolTipText = "Apply modifcations";
            this.TSB_Apply.Click += new System.EventHandler(this.TSB_Apply_Click);
            // 
            // TSB_Cancel
            // 
            this.TSB_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Cancel.Image = global::Ctrl_GraphWindow.Icones.arreter_icone_6430;
            this.TSB_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Cancel.Name = "TSB_Cancel";
            this.TSB_Cancel.Size = new System.Drawing.Size(23, 22);
            this.TSB_Cancel.Text = "TSB_Cancel";
            this.TSB_Cancel.ToolTipText = "Cancel";
            this.TSB_Cancel.Click += new System.EventHandler(this.TSB_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_New
            // 
            this.TSB_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_New.Image = global::Ctrl_GraphWindow.Icones.nouveau_document_icone_4768;
            this.TSB_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_New.Name = "TSB_New";
            this.TSB_New.Size = new System.Drawing.Size(23, 22);
            this.TSB_New.Text = "toolStripButton1";
            this.TSB_New.ToolTipText = "Create new graphic window properties configuration";
            this.TSB_New.Click += new System.EventHandler(this.TSB_New_Click);
            // 
            // TSB_Open
            // 
            this.TSB_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Open.Image = global::Ctrl_GraphWindow.Icones.fileopen_icone_6858;
            this.TSB_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Open.Name = "TSB_Open";
            this.TSB_Open.Size = new System.Drawing.Size(23, 22);
            this.TSB_Open.Text = "toolStripButton2";
            this.TSB_Open.ToolTipText = "Open graphic window properties configuration";
            this.TSB_Open.Click += new System.EventHandler(this.TSB_Open_Click);
            // 
            // TSB_Save
            // 
            this.TSB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Save.Image = global::Ctrl_GraphWindow.Icones.document_enregistrez_icone_7256;
            this.TSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Save.Name = "TSB_Save";
            this.TSB_Save.Size = new System.Drawing.Size(23, 22);
            this.TSB_Save.Text = "toolStripButton3";
            this.TSB_Save.ToolTipText = "Save graphic window properties configuration";
            this.TSB_Save.Click += new System.EventHandler(this.TSB_Save_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_ChannelList
            // 
            this.TSB_ChannelList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ChannelList.Image = global::Ctrl_GraphWindow.Icones.block_modules_icone_7434;
            this.TSB_ChannelList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ChannelList.Name = "TSB_ChannelList";
            this.TSB_ChannelList.Size = new System.Drawing.Size(23, 22);
            this.TSB_ChannelList.Text = "toolStripButton1";
            this.TSB_ChannelList.ToolTipText = "Show channel list";
            this.TSB_ChannelList.Click += new System.EventHandler(this.TSB_ChannelList_Click);
            // 
            // TSB_NewSerie
            // 
            this.TSB_NewSerie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_NewSerie.Image = global::Ctrl_GraphWindow.Icones.moc_source_icone_8167;
            this.TSB_NewSerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_NewSerie.Name = "TSB_NewSerie";
            this.TSB_NewSerie.Size = new System.Drawing.Size(23, 22);
            this.TSB_NewSerie.Text = "toolStripButton1";
            this.TSB_NewSerie.ToolTipText = "Add new graphic serie";
            this.TSB_NewSerie.Click += new System.EventHandler(this.TSB_NewSerie_Click);
            // 
            // TSB_DelSerie
            // 
            this.TSB_DelSerie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_DelSerie.Image = global::Ctrl_GraphWindow.Icones.editdelete_icone_6247;
            this.TSB_DelSerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_DelSerie.Name = "TSB_DelSerie";
            this.TSB_DelSerie.Size = new System.Drawing.Size(23, 22);
            this.TSB_DelSerie.Text = "toolStripButton2";
            this.TSB_DelSerie.ToolTipText = "Remove graphic serie";
            this.TSB_DelSerie.Click += new System.EventHandler(this.TSB_DelSerie_Click);
            // 
            // TSB_CopySerie
            // 
            this.TSB_CopySerie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_CopySerie.Image = global::Ctrl_GraphWindow.Icones.copy_icone_4776;
            this.TSB_CopySerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_CopySerie.Name = "TSB_CopySerie";
            this.TSB_CopySerie.Size = new System.Drawing.Size(23, 22);
            this.TSB_CopySerie.Text = "toolStripButton1";
            this.TSB_CopySerie.ToolTipText = "Copy";
            this.TSB_CopySerie.Click += new System.EventHandler(this.TSB_CopySerie_Click);
            // 
            // TSB_PasteSerie
            // 
            this.TSB_PasteSerie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_PasteSerie.Image = global::Ctrl_GraphWindow.Icones.editpaste_icone_7191;
            this.TSB_PasteSerie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_PasteSerie.Name = "TSB_PasteSerie";
            this.TSB_PasteSerie.Size = new System.Drawing.Size(23, 22);
            this.TSB_PasteSerie.Text = "toolStripButton2";
            this.TSB_PasteSerie.ToolTipText = "Paste";
            this.TSB_PasteSerie.Click += new System.EventHandler(this.TSB_PasteSerie_Click);
            // 
            // TSB_MoveUp
            // 
            this.TSB_MoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_MoveUp.Image = global::Ctrl_GraphWindow.Icones.arrow_up_icone_7220;
            this.TSB_MoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_MoveUp.Name = "TSB_MoveUp";
            this.TSB_MoveUp.Size = new System.Drawing.Size(23, 22);
            this.TSB_MoveUp.Text = "toolStripButton1";
            this.TSB_MoveUp.ToolTipText = "Move selection up";
            this.TSB_MoveUp.Click += new System.EventHandler(this.TSB_MoveUp_Click);
            // 
            // TSB_MoveDown
            // 
            this.TSB_MoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_MoveDown.Image = global::Ctrl_GraphWindow.Icones.arrow_down_icone_5325;
            this.TSB_MoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_MoveDown.Name = "TSB_MoveDown";
            this.TSB_MoveDown.Size = new System.Drawing.Size(23, 22);
            this.TSB_MoveDown.Text = "toolStripButton2";
            this.TSB_MoveDown.ToolTipText = "Move selection down";
            this.TSB_MoveDown.Click += new System.EventHandler(this.TSB_MoveDown_Click);
            // 
            // Dlg_Open
            // 
            this.Dlg_Open.FileName = "openFileDialog1";
            this.Dlg_Open.Filter = "Graphic window properties file|*.xgw";
            // 
            // Dlg_Save
            // 
            this.Dlg_Save.Filter = "Graphic window properties file|*.xgw";
            // 
            // Img_ContextChanList
            // 
            this.Img_ContextChanList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_ContextChanList.ImageStream")));
            this.Img_ContextChanList.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_ContextChanList.Images.SetKeyName(0, "block-modules-icone-7434.ico");
            // 
            // Pic_CursorValueForecolor
            // 
            this.Pic_CursorValueForecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_CursorValueForecolor.Enabled = false;
            this.Pic_CursorValueForecolor.Location = new System.Drawing.Point(389, 104);
            this.Pic_CursorValueForecolor.Name = "Pic_CursorValueForecolor";
            this.Pic_CursorValueForecolor.Size = new System.Drawing.Size(20, 20);
            this.Pic_CursorValueForecolor.TabIndex = 28;
            this.Pic_CursorValueForecolor.TabStop = false;
            this.Pic_CursorValueForecolor.DoubleClick += new System.EventHandler(this.Pic_CursorValueForecolor_DoubleClick);
            // 
            // Lbl_CursorValueForecolor
            // 
            this.Lbl_CursorValueForecolor.AutoSize = true;
            this.Lbl_CursorValueForecolor.Enabled = false;
            this.Lbl_CursorValueForecolor.Location = new System.Drawing.Point(332, 107);
            this.Lbl_CursorValueForecolor.Name = "Lbl_CursorValueForecolor";
            this.Lbl_CursorValueForecolor.Size = new System.Drawing.Size(51, 13);
            this.Lbl_CursorValueForecolor.TabIndex = 27;
            this.Lbl_CursorValueForecolor.Text = "Forecolor";
            // 
            // Pic_CursorTitleForecolor
            // 
            this.Pic_CursorTitleForecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_CursorTitleForecolor.Enabled = false;
            this.Pic_CursorTitleForecolor.Location = new System.Drawing.Point(389, 167);
            this.Pic_CursorTitleForecolor.Name = "Pic_CursorTitleForecolor";
            this.Pic_CursorTitleForecolor.Size = new System.Drawing.Size(20, 20);
            this.Pic_CursorTitleForecolor.TabIndex = 35;
            this.Pic_CursorTitleForecolor.TabStop = false;
            this.Pic_CursorTitleForecolor.DoubleClick += new System.EventHandler(this.Pic_CursorTitleForecolor_DoubleClick);
            // 
            // Lbl_CursorTitleForecolor
            // 
            this.Lbl_CursorTitleForecolor.AutoSize = true;
            this.Lbl_CursorTitleForecolor.Enabled = false;
            this.Lbl_CursorTitleForecolor.Location = new System.Drawing.Point(332, 170);
            this.Lbl_CursorTitleForecolor.Name = "Lbl_CursorTitleForecolor";
            this.Lbl_CursorTitleForecolor.Size = new System.Drawing.Size(51, 13);
            this.Lbl_CursorTitleForecolor.TabIndex = 34;
            this.Lbl_CursorTitleForecolor.Text = "Forecolor";
            // 
            // Cmd_CursorTitleFont
            // 
            this.Cmd_CursorTitleFont.Enabled = false;
            this.Cmd_CursorTitleFont.Image = global::Ctrl_GraphWindow.Icones.font_icone_6304_16;
            this.Cmd_CursorTitleFont.Location = new System.Drawing.Point(217, 164);
            this.Cmd_CursorTitleFont.Name = "Cmd_CursorTitleFont";
            this.Cmd_CursorTitleFont.Size = new System.Drawing.Size(23, 23);
            this.Cmd_CursorTitleFont.TabIndex = 33;
            this.Cmd_CursorTitleFont.UseVisualStyleBackColor = true;
            this.Cmd_CursorTitleFont.Click += new System.EventHandler(this.Cmd_CursorTitleFont_Click);
            // 
            // Txt_CursorTitleFontSize
            // 
            this.Txt_CursorTitleFontSize.Enabled = false;
            this.Txt_CursorTitleFontSize.Location = new System.Drawing.Point(282, 167);
            this.Txt_CursorTitleFontSize.Name = "Txt_CursorTitleFontSize";
            this.Txt_CursorTitleFontSize.ReadOnly = true;
            this.Txt_CursorTitleFontSize.Size = new System.Drawing.Size(44, 20);
            this.Txt_CursorTitleFontSize.TabIndex = 32;
            // 
            // Lbl_CursorTitleFontSize
            // 
            this.Lbl_CursorTitleFontSize.AutoSize = true;
            this.Lbl_CursorTitleFontSize.Enabled = false;
            this.Lbl_CursorTitleFontSize.Location = new System.Drawing.Point(246, 170);
            this.Lbl_CursorTitleFontSize.Name = "Lbl_CursorTitleFontSize";
            this.Lbl_CursorTitleFontSize.Size = new System.Drawing.Size(27, 13);
            this.Lbl_CursorTitleFontSize.TabIndex = 31;
            this.Lbl_CursorTitleFontSize.Text = "Size";
            // 
            // Txt_CursorTitleFont
            // 
            this.Txt_CursorTitleFont.Enabled = false;
            this.Txt_CursorTitleFont.Location = new System.Drawing.Point(105, 166);
            this.Txt_CursorTitleFont.Name = "Txt_CursorTitleFont";
            this.Txt_CursorTitleFont.ReadOnly = true;
            this.Txt_CursorTitleFont.Size = new System.Drawing.Size(106, 20);
            this.Txt_CursorTitleFont.TabIndex = 30;
            // 
            // Lbl_CursorTitleFont
            // 
            this.Lbl_CursorTitleFont.AutoSize = true;
            this.Lbl_CursorTitleFont.Enabled = false;
            this.Lbl_CursorTitleFont.Location = new System.Drawing.Point(14, 169);
            this.Lbl_CursorTitleFont.Name = "Lbl_CursorTitleFont";
            this.Lbl_CursorTitleFont.Size = new System.Drawing.Size(77, 13);
            this.Lbl_CursorTitleFont.TabIndex = 29;
            this.Lbl_CursorTitleFont.Text = "Cursor title font";
            // 
            // Lbl_CursorTitle
            // 
            this.Lbl_CursorTitle.AutoSize = true;
            this.Lbl_CursorTitle.Enabled = false;
            this.Lbl_CursorTitle.Location = new System.Drawing.Point(14, 144);
            this.Lbl_CursorTitle.Name = "Lbl_CursorTitle";
            this.Lbl_CursorTitle.Size = new System.Drawing.Size(56, 13);
            this.Lbl_CursorTitle.TabIndex = 36;
            this.Lbl_CursorTitle.Text = "Cursor title";
            // 
            // Txt_CursorTitle
            // 
            this.Txt_CursorTitle.Enabled = false;
            this.Txt_CursorTitle.Location = new System.Drawing.Point(105, 141);
            this.Txt_CursorTitle.Name = "Txt_CursorTitle";
            this.Txt_CursorTitle.Size = new System.Drawing.Size(304, 20);
            this.Txt_CursorTitle.TabIndex = 37;
            // 
            // Cmb_CursorTitleLocation
            // 
            this.Cmb_CursorTitleLocation.Enabled = false;
            this.Cmb_CursorTitleLocation.FormattingEnabled = true;
            this.Cmb_CursorTitleLocation.Location = new System.Drawing.Point(495, 141);
            this.Cmb_CursorTitleLocation.Name = "Cmb_CursorTitleLocation";
            this.Cmb_CursorTitleLocation.Size = new System.Drawing.Size(106, 21);
            this.Cmb_CursorTitleLocation.TabIndex = 39;
            // 
            // Lbl_CursorTitleLocation
            // 
            this.Lbl_CursorTitleLocation.Enabled = false;
            this.Lbl_CursorTitleLocation.Location = new System.Drawing.Point(415, 144);
            this.Lbl_CursorTitleLocation.Name = "Lbl_CursorTitleLocation";
            this.Lbl_CursorTitleLocation.Size = new System.Drawing.Size(80, 19);
            this.Lbl_CursorTitleLocation.TabIndex = 38;
            this.Lbl_CursorTitleLocation.Text = "Title location";
            // 
            // Ctrl_AbcisseRefLines
            // 
            this.Ctrl_AbcisseRefLines.Location = new System.Drawing.Point(6, 20);
            this.Ctrl_AbcisseRefLines.Name = "Ctrl_AbcisseRefLines";
            this.Ctrl_AbcisseRefLines.Size = new System.Drawing.Size(581, 177);
            this.Ctrl_AbcisseRefLines.TabIndex = 0;
            // 
            // Frm_GraphPropertiesEdtion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 417);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_GraphPropertiesEdtion";
            this.Text = "Graphic Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_GraphPropertiesEdtion_FormClosing);
            this.Shown += new System.EventHandler(this.Frm_GraphPropertiesEdtion_Shown);
            this.ResizeEnd += new System.EventHandler(this.Frm_GraphPropertiesEdtion_ResizeEnd);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_SeriesProperties)).EndInit();
            this.Context_Grid_SeriesProperties.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar_SampleMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_GraphBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_FrameLineColor)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_SVGrid_Color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_SHGrid_Color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_MVGrid_Color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_MHGrid_Color)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.Grp_AbscisseRefLines.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AbscisseColor)).EndInit();
            this.Grp_AbscisseMode.ResumeLayout(false);
            this.Grp_AbscisseMode.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_RefCursorLineColor)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_CursorLineColor)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_CursorValueForecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_CursorTitleForecolor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ImageList Img_ContextChanList;
        private System.Windows.Forms.CheckBox Chk_LegendHeaderVisible;
        private System.Windows.Forms.CheckBox Chk_LegendGridLinesVisible;
        private System.Windows.Forms.CheckBox Chk_RefCursorOrdValVisible;
        private System.Windows.Forms.Label Lbl_RefCursorOrdValLocation;
        private System.Windows.Forms.ComboBox Cmb_RefCursorOrdValLocation;
        private System.Windows.Forms.Label Lbl_RefCursorMode;
        private System.Windows.Forms.ComboBox Cmb_RefCursorMode;
        private System.Windows.Forms.Label Lbl_RefCursorLineStyle;
        private System.Windows.Forms.ComboBox Cmb_RefCursorLineStyle;
        private System.Windows.Forms.Label Lbl_RefCursorLineWidth;
        private System.Windows.Forms.TextBox Txt_RefCursorLineWidth;
        private System.Windows.Forms.Label Lbl_RefCursorLineColor;
        private System.Windows.Forms.PictureBox Pic_RefCursorLineColor;
        private System.Windows.Forms.CheckBox Chk_RefCursorAbsValVisible;
        private System.Windows.Forms.Label Lbl_RefCursorAbsValLocation;
        private System.Windows.Forms.ComboBox Cmb_RefCursorAbsValLocation;
        private System.Windows.Forms.Label Lbl_RefCursorValFont;
        private System.Windows.Forms.TextBox Txt_RefCursorValFont;
        private System.Windows.Forms.Label Lbl_RefCursorValFontSize;
        private System.Windows.Forms.TextBox Txt_RefCursorValFontSize;
        private System.Windows.Forms.Button Cmd_RefCursorValFont;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox Chk_AllowOverScaling;
        private System.Windows.Forms.Label Lbl_CursorSize;
        private System.Windows.Forms.TextBox Txt_CursorSize;
        private System.Windows.Forms.Label Lbl_CursorValFont;
        private System.Windows.Forms.TextBox Txt_CursorValFont;
        private System.Windows.Forms.Label Lbl_CursorValFontSize;
        private System.Windows.Forms.TextBox Txt_CursorValFontSize;
        private System.Windows.Forms.Button Cmd_CursorValFont;
        private System.Windows.Forms.Label Lbl_CursorLineStyle;
        private System.Windows.Forms.ComboBox Cmb_CursorLineStyle;
        private System.Windows.Forms.Label Lbl_CursorLineWidth;
        private System.Windows.Forms.TextBox Txt_CursorLineWidth;
        private System.Windows.Forms.Label Lbl_CursorLineColor;
        private System.Windows.Forms.PictureBox Pic_CursorLineColor;
        private System.Windows.Forms.CheckBox Chk_CursorAbsValVisible;
        private System.Windows.Forms.Label Lbl_CursorAbsValLocation;
        private System.Windows.Forms.ComboBox Cmb_CursorAbsValLocation;
        private System.Windows.Forms.CheckBox Chk_CursorOrdValVisible;
        private System.Windows.Forms.Label Lbl_CursorOrdValLocation;
        private System.Windows.Forms.ComboBox Cmb_CursorOrdValLocation;
        private System.Windows.Forms.Label Lbl_MainCursorMode;
        private System.Windows.Forms.ComboBox Cmb_MainCursorMode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabPage tabPage5;
        private Ctrl_GraphWindow.Ctrl_ReferenceLines Ctrl_AbcisseRefLines;

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSB_Apply;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox Pic_FrameLineColor;
        private System.Windows.Forms.TextBox Txt_FrameLineWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog Dlg_Color;
        private System.Windows.Forms.ToolStripButton TSB_Cancel;
        private System.Windows.Forms.PictureBox Pic_SVGrid_Color;
        private System.Windows.Forms.Label Lbl_SVGrid_Color;
        private System.Windows.Forms.ComboBox Cmb_SVGrid_Style;
        private System.Windows.Forms.Label Lbl_SVGrid_Style;
        private System.Windows.Forms.TextBox Txt_SVGrid_Width;
        private System.Windows.Forms.Label Lbl_SVGrid_Width;
        private System.Windows.Forms.CheckBox Chk_SVGrid_Visible;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox Pic_SHGrid_Color;
        private System.Windows.Forms.Label Lbl_SHGrid_Color;
        private System.Windows.Forms.ComboBox Cmb_SHGrid_Style;
        private System.Windows.Forms.Label Lbl_SHGrid_Style;
        private System.Windows.Forms.TextBox Txt_SHGrid_Width;
        private System.Windows.Forms.Label Lbl_SHGrid_Width;
        private System.Windows.Forms.CheckBox Chk_SHGrid_Visible;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox Pic_MVGrid_Color;
        private System.Windows.Forms.Label Lbl_MVGrid_Color;
        private System.Windows.Forms.ComboBox Cmb_MVGrid_Style;
        private System.Windows.Forms.Label Lbl_MVGrid_Style;
        private System.Windows.Forms.TextBox Txt_MVGrid_Width;
        private System.Windows.Forms.Label Lbl_MVGrid_Width;
        private System.Windows.Forms.CheckBox Chk_MVGrid_Visible;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox Pic_MHGrid_Color;
        private System.Windows.Forms.Label Lbl_MHGrid_Color;
        private System.Windows.Forms.ComboBox Cmb_MHGrid_Style;
        private System.Windows.Forms.Label Lbl_MHGrid_Style;
        private System.Windows.Forms.TextBox Txt_MHGrid_Width;
        private System.Windows.Forms.Label Lbl_MHGrid_Width;
        private System.Windows.Forms.CheckBox Chk_MHGrid_Visible;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_New;
        private System.Windows.Forms.ToolStripButton TSB_Open;
        private System.Windows.Forms.ToolStripButton TSB_Save;
        private System.Windows.Forms.OpenFileDialog Dlg_Open;
        private System.Windows.Forms.SaveFileDialog Dlg_Save;
        private System.Windows.Forms.DataGridView Grid_SeriesProperties;
        private System.Windows.Forms.ComboBox Cmb_GraphLayoutMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TSB_NewSerie;
        private System.Windows.Forms.ToolStripButton TSB_DelSerie;
        private System.Windows.Forms.ToolStripButton TSB_CopySerie;
        private System.Windows.Forms.ToolStripButton TSB_PasteSerie;
        private System.Windows.Forms.ToolStripButton TSB_ChannelList;
        private System.Windows.Forms.ContextMenuStrip Context_Grid_SeriesProperties;
        private System.Windows.Forms.ToolStripMenuItem addSerieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton TSB_MoveUp;
        private System.Windows.Forms.ToolStripButton TSB_MoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem moveSelectionUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveSelectionDownToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieColor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColSerieVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieBottom;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColSerieScaleMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieAxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerieRefLines;
        private System.Windows.Forms.DataGridViewButtonColumn ColSeriePropSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar TrackBar_SampleMax;
        private System.Windows.Forms.TextBox Txt_SampleMax;
        private System.Windows.Forms.Label Lbl_MaxSampleCount;
        private System.Windows.Forms.CheckBox Chk_SubSamplingEnabled;
        private System.Windows.Forms.Label Lbl_TrackMaxVal;
        private System.Windows.Forms.Label Lbl_TrackMinVal;
        private System.Windows.Forms.Label Lbl_TrackMaxValComment;
        private System.Windows.Forms.Label Lbl_TrackMinValComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Pic_GraphBackColor;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button Cmd_AbscisseFont;
        private System.Windows.Forms.CheckBox Chk_AbscisseValueVisible;
        private System.Windows.Forms.TextBox Txt_AbscisseFontSize;
        private System.Windows.Forms.Label Lbl_AbscisseFontSize;
        private System.Windows.Forms.TextBox Txt_AbscisseFont;
        private System.Windows.Forms.Label Lbl_AbscisseFont;
        private System.Windows.Forms.CheckBox Chk_AbscisseVisible;
        private System.Windows.Forms.PictureBox Pic_AbscisseColor;
        private System.Windows.Forms.Label Lbl_AbscisseColor;
        private System.Windows.Forms.TextBox Txt_AbscisseWidth;
        private System.Windows.Forms.Label Lbl_AbscisseWidth;
        private System.Windows.Forms.ComboBox Cmb_AbscisseStyle;
        private System.Windows.Forms.Label Lbl_AbscisseStyle;
        private System.Windows.Forms.GroupBox Grp_AbscisseMode;
        private System.Windows.Forms.ComboBox Cmb_AbscisseChannel;
        private System.Windows.Forms.Label Lbl_AbscisseChannel;
        private System.Windows.Forms.CheckBox Chk_AbscisseTimeMode;
        private System.Windows.Forms.GroupBox Grp_AbscisseRefLines;
        private System.Windows.Forms.FontDialog Dlg_Font;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox ChkLst_LegendInformations;
        private System.Windows.Forms.Label Lbl_LegendInformations;
        private System.Windows.Forms.CheckBox Chk_LegendVisible;
        private System.Windows.Forms.Button Cmd_LegendFont;
        private System.Windows.Forms.TextBox Txt_LegendFontSize;
        private System.Windows.Forms.Label Lbl_LegendFontSize;
        private System.Windows.Forms.TextBox Txt_LegendFont;
        private System.Windows.Forms.Label Lbl_LegendFont;
        private System.Windows.Forms.PictureBox Pic_CursorValueForecolor;
        private System.Windows.Forms.Label Lbl_CursorValueForecolor;
        private System.Windows.Forms.TextBox Txt_CursorTitle;
        private System.Windows.Forms.Label Lbl_CursorTitle;
        private System.Windows.Forms.PictureBox Pic_CursorTitleForecolor;
        private System.Windows.Forms.Label Lbl_CursorTitleForecolor;
        private System.Windows.Forms.Button Cmd_CursorTitleFont;
        private System.Windows.Forms.TextBox Txt_CursorTitleFontSize;
        private System.Windows.Forms.Label Lbl_CursorTitleFontSize;
        private System.Windows.Forms.TextBox Txt_CursorTitleFont;
        private System.Windows.Forms.Label Lbl_CursorTitleFont;
        private System.Windows.Forms.ComboBox Cmb_CursorTitleLocation;
        private System.Windows.Forms.Label Lbl_CursorTitleLocation;
    }
}