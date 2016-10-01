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
    partial class Ctrl_GW_ChannelList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ctrl_GW_ChannelList));
            this.LV_Channels = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Img_LV_Channel = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cmb_Filter = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_Channels
            // 
            this.LV_Channels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LV_Channels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.LV_Channels.FullRowSelect = true;
            this.LV_Channels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Channels.Location = new System.Drawing.Point(3, 3);
            this.LV_Channels.Name = "LV_Channels";
            this.LV_Channels.ShowItemToolTips = true;
            this.LV_Channels.Size = new System.Drawing.Size(168, 318);
            this.LV_Channels.SmallImageList = this.Img_LV_Channel;
            this.LV_Channels.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LV_Channels.TabIndex = 0;
            this.LV_Channels.UseCompatibleStateImageBehavior = false;
            this.LV_Channels.View = System.Windows.Forms.View.Details;
            this.LV_Channels.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LV_Channels_ItemDrag);
            this.LV_Channels.DragOver += new System.Windows.Forms.DragEventHandler(this.LV_Channels_DragOver);
            this.LV_Channels.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_Channels_KeyDown);
            this.LV_Channels.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LV_Channels_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // Img_LV_Channel
            // 
            this.Img_LV_Channel.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_LV_Channel.ImageStream")));
            this.Img_LV_Channel.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_LV_Channel.Images.SetKeyName(0, "block-modules-icone-7434.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Cmb_Filter);
            this.groupBox1.Location = new System.Drawing.Point(3, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // Cmb_Filter
            // 
            this.Cmb_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Filter.FormattingEnabled = true;
            this.Cmb_Filter.Location = new System.Drawing.Point(6, 19);
            this.Cmb_Filter.Name = "Cmb_Filter";
            this.Cmb_Filter.Size = new System.Drawing.Size(156, 21);
            this.Cmb_Filter.TabIndex = 0;
            this.Cmb_Filter.SelectedIndexChanged += new System.EventHandler(this.Cmb_Filter_SelectedIndexChanged);
            this.Cmb_Filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_Filter_KeyDown);
            // 
            // Ctrl_GW_ChannelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LV_Channels);
            this.Name = "Ctrl_GW_ChannelList";
            this.Size = new System.Drawing.Size(174, 378);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LV_Channels;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Cmb_Filter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList Img_LV_Channel;
    }
}
