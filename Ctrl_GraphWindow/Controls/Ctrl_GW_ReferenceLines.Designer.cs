namespace Ctrl_GraphWindow
{
    partial class Ctrl_ReferenceLines
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.TS_RefLines = new System.Windows.Forms.ToolStrip();
            this.TSB_AddRefLine = new System.Windows.Forms.ToolStripButton();
            this.TSB_DelRefLine = new System.Windows.Forms.ToolStripButton();
            this.TSB_ClearRefLines = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_MoveUpRefLine = new System.Windows.Forms.ToolStripButton();
            this.TSB_MoveDownRefLine = new System.Windows.Forms.ToolStripButton();
            this.TSB_CopyReferenceLines = new System.Windows.Forms.ToolStripButton();
            this.TSB_PasteReferenceLines = new System.Windows.Forms.ToolStripButton();
            this.Grid_RefLines = new System.Windows.Forms.DataGridView();
            this.Dlg_Color = new System.Windows.Forms.ColorDialog();
            this.Dlg_Font = new System.Windows.Forms.FontDialog();
            this.ColRefLineMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColRefValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefLineTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefLineVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColRefLineStyle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColRefLineColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefLineWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRefLineValuePosition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColRefLineTitlePosition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColRefLineFont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TS_RefLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_RefLines)).BeginInit();
            this.SuspendLayout();
            // 
            // TS_RefLines
            // 
            this.TS_RefLines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_AddRefLine,
            this.TSB_DelRefLine,
            this.TSB_ClearRefLines,
            this.toolStripSeparator1,
            this.TSB_MoveUpRefLine,
            this.TSB_MoveDownRefLine,
            this.TSB_CopyReferenceLines,
            this.TSB_PasteReferenceLines});
            this.TS_RefLines.Location = new System.Drawing.Point(0, 0);
            this.TS_RefLines.Name = "TS_RefLines";
            this.TS_RefLines.Size = new System.Drawing.Size(579, 25);
            this.TS_RefLines.TabIndex = 1;
            this.TS_RefLines.Text = "toolStrip5";
            // 
            // TSB_AddRefLine
            // 
            this.TSB_AddRefLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_AddRefLine.Image = global::Ctrl_GraphWindow.Icones.add_a_tag_blue_icone_6061;
            this.TSB_AddRefLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_AddRefLine.Name = "TSB_AddRefLine";
            this.TSB_AddRefLine.Size = new System.Drawing.Size(23, 22);
            this.TSB_AddRefLine.Text = "toolStripButton1";
            this.TSB_AddRefLine.ToolTipText = "Add a reference line";
            this.TSB_AddRefLine.Click += new System.EventHandler(this.TSB_AddRefLine_Click);
            // 
            // TSB_DelRefLine
            // 
            this.TSB_DelRefLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_DelRefLine.Image = global::Ctrl_GraphWindow.Icones.remove_a_blue_mark_icone_9732;
            this.TSB_DelRefLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_DelRefLine.Name = "TSB_DelRefLine";
            this.TSB_DelRefLine.Size = new System.Drawing.Size(23, 22);
            this.TSB_DelRefLine.Text = "toolStripButton2";
            this.TSB_DelRefLine.ToolTipText = "Delete reference line";
            this.TSB_DelRefLine.Click += new System.EventHandler(this.TSB_DelRefLine_Click);
            // 
            // TSB_ClearRefLines
            // 
            this.TSB_ClearRefLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ClearRefLines.Image = global::Ctrl_GraphWindow.Icones.exclamation_icone_7555;
            this.TSB_ClearRefLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ClearRefLines.Name = "TSB_ClearRefLines";
            this.TSB_ClearRefLines.Size = new System.Drawing.Size(23, 22);
            this.TSB_ClearRefLines.Text = "toolStripButton3";
            this.TSB_ClearRefLines.ToolTipText = "Clear reference lines";
            this.TSB_ClearRefLines.Click += new System.EventHandler(this.TSB_ClearRefLines_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_MoveUpRefLine
            // 
            this.TSB_MoveUpRefLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_MoveUpRefLine.Image = global::Ctrl_GraphWindow.Icones.arrow_up_icone_7220;
            this.TSB_MoveUpRefLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_MoveUpRefLine.Name = "TSB_MoveUpRefLine";
            this.TSB_MoveUpRefLine.Size = new System.Drawing.Size(23, 22);
            this.TSB_MoveUpRefLine.Text = "toolStripButton1";
            this.TSB_MoveUpRefLine.ToolTipText = "Move reference line up";
            this.TSB_MoveUpRefLine.Click += new System.EventHandler(this.TSB_MoveUpRefLine_Click);
            // 
            // TSB_MoveDownRefLine
            // 
            this.TSB_MoveDownRefLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_MoveDownRefLine.Image = global::Ctrl_GraphWindow.Icones.arrow_down_icone_5325;
            this.TSB_MoveDownRefLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_MoveDownRefLine.Name = "TSB_MoveDownRefLine";
            this.TSB_MoveDownRefLine.Size = new System.Drawing.Size(23, 22);
            this.TSB_MoveDownRefLine.Text = "toolStripButton2";
            this.TSB_MoveDownRefLine.ToolTipText = "Move reference line down";
            this.TSB_MoveDownRefLine.Click += new System.EventHandler(this.TSB_MoveDownRefLine_Click);
            // 
            // TSB_CopyReferenceLines
            // 
            this.TSB_CopyReferenceLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_CopyReferenceLines.Image = global::Ctrl_GraphWindow.Icones.copy_icone_4776;
            this.TSB_CopyReferenceLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_CopyReferenceLines.Name = "TSB_CopyReferenceLines";
            this.TSB_CopyReferenceLines.Size = new System.Drawing.Size(23, 22);
            this.TSB_CopyReferenceLines.Text = "toolStripButton1";
            this.TSB_CopyReferenceLines.ToolTipText = "Copy reference lines";
            this.TSB_CopyReferenceLines.Click += new System.EventHandler(this.TSB_CopyReferenceLines_Click);
            // 
            // TSB_PasteReferenceLines
            // 
            this.TSB_PasteReferenceLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_PasteReferenceLines.Image = global::Ctrl_GraphWindow.Icones.editpaste_icone_7191;
            this.TSB_PasteReferenceLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_PasteReferenceLines.Name = "TSB_PasteReferenceLines";
            this.TSB_PasteReferenceLines.Size = new System.Drawing.Size(23, 22);
            this.TSB_PasteReferenceLines.Text = "toolStripButton2";
            this.TSB_PasteReferenceLines.ToolTipText = "Paste reference lines";
            this.TSB_PasteReferenceLines.Click += new System.EventHandler(this.TSB_PasteReferenceLines_Click);
            // 
            // Grid_RefLines
            // 
            this.Grid_RefLines.AllowUserToAddRows = false;
            this.Grid_RefLines.AllowUserToResizeColumns = false;
            this.Grid_RefLines.AllowUserToResizeRows = false;
            this.Grid_RefLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_RefLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_RefLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRefLineMode,
            this.ColRefValue,
            this.ColRefLineTitle,
            this.ColRefLineVisible,
            this.ColRefLineStyle,
            this.ColRefLineColor,
            this.ColRefLineWidth,
            this.ColRefLineValuePosition,
            this.ColRefLineTitlePosition,
            this.ColRefLineFont});
            this.Grid_RefLines.Location = new System.Drawing.Point(0, 28);
            this.Grid_RefLines.Name = "Grid_RefLines";
            this.Grid_RefLines.RowHeadersVisible = false;
            this.Grid_RefLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_RefLines.Size = new System.Drawing.Size(579, 549);
            this.Grid_RefLines.TabIndex = 2;
            this.Grid_RefLines.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid_RefLines_CellMouseDoubleClick);
            this.Grid_RefLines.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_RefLines_CellValueChanged);
            this.Grid_RefLines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_RefLines_KeyDown);
            // 
            // ColRefLineMode
            // 
            this.ColRefLineMode.HeaderText = "Ref mode";
            this.ColRefLineMode.Name = "ColRefLineMode";
            this.ColRefLineMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefLineMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefLineMode.Width = 80;
            // 
            // ColRefValue
            // 
            this.ColRefValue.HeaderText = "Value";
            this.ColRefValue.Name = "ColRefValue";
            this.ColRefValue.Width = 55;
            // 
            // ColRefLineTitle
            // 
            this.ColRefLineTitle.HeaderText = "Title";
            this.ColRefLineTitle.Name = "ColRefLineTitle";
            this.ColRefLineTitle.Width = 55;
            // 
            // ColRefLineVisible
            // 
            this.ColRefLineVisible.HeaderText = "Visible";
            this.ColRefLineVisible.Name = "ColRefLineVisible";
            this.ColRefLineVisible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefLineVisible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefLineVisible.Width = 40;
            // 
            // ColRefLineStyle
            // 
            this.ColRefLineStyle.HeaderText = "Style";
            this.ColRefLineStyle.Name = "ColRefLineStyle";
            this.ColRefLineStyle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColRefLineStyle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColRefLineStyle.Width = 65;
            // 
            // ColRefLineColor
            // 
            this.ColRefLineColor.HeaderText = "Color";
            this.ColRefLineColor.Name = "ColRefLineColor";
            this.ColRefLineColor.ReadOnly = true;
            this.ColRefLineColor.Width = 40;
            // 
            // ColRefLineWidth
            // 
            this.ColRefLineWidth.HeaderText = "Width";
            this.ColRefLineWidth.Name = "ColRefLineWidth";
            this.ColRefLineWidth.Width = 40;
            // 
            // ColRefLineValuePosition
            // 
            this.ColRefLineValuePosition.HeaderText = "Value Position";
            this.ColRefLineValuePosition.Name = "ColRefLineValuePosition";
            this.ColRefLineValuePosition.Width = 55;
            // 
            // ColRefLineTitlePosition
            // 
            this.ColRefLineTitlePosition.HeaderText = "Title Position";
            this.ColRefLineTitlePosition.Name = "ColRefLineTitlePosition";
            this.ColRefLineTitlePosition.Width = 55;
            // 
            // ColRefLineFont
            // 
            this.ColRefLineFont.HeaderText = "Font";
            this.ColRefLineFont.Name = "ColRefLineFont";
            this.ColRefLineFont.ReadOnly = true;
            this.ColRefLineFont.Width = 90;
            // 
            // Ctrl_ReferenceLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Grid_RefLines);
            this.Controls.Add(this.TS_RefLines);
            this.Name = "Ctrl_ReferenceLines";
            this.Size = new System.Drawing.Size(579, 580);
            this.TS_RefLines.ResumeLayout(false);
            this.TS_RefLines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_RefLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TS_RefLines;
        private System.Windows.Forms.ToolStripButton TSB_AddRefLine;
        private System.Windows.Forms.ToolStripButton TSB_DelRefLine;
        private System.Windows.Forms.ToolStripButton TSB_ClearRefLines;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_MoveUpRefLine;
        private System.Windows.Forms.ToolStripButton TSB_MoveDownRefLine;
        private System.Windows.Forms.ToolStripButton TSB_CopyReferenceLines;
        private System.Windows.Forms.ToolStripButton TSB_PasteReferenceLines;
        private System.Windows.Forms.DataGridView Grid_RefLines;
        private System.Windows.Forms.ColorDialog Dlg_Color;
        private System.Windows.Forms.FontDialog Dlg_Font;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColRefLineMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefLineTitle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColRefLineVisible;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColRefLineStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefLineColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefLineWidth;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColRefLineValuePosition;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColRefLineTitlePosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRefLineFont;
    }
}
