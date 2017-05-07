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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ctrl_GraphWindow
{
    /// <summary>
    /// Data channel list control class
    /// </summary>
    public partial class Ctrl_GW_ChannelList : UserControl
    {
        #region Public members

        /// <summary>
        /// List of channels
        /// </summary>
        public string[] ChannelList;

        /// <summary>
        /// Descriptions of channels contained in the channel list
        /// </summary>
        public string[] ChannelDescriptions;

        #endregion

        #region Public Events

        /// <summary>
        /// Data channel clicked event
        /// </summary>
        public event EventHandler<ChannelClickEventArgs> DataChannelClicked;

        /// <summary>
        /// Data channel double clicked event
        /// </summary>
        public event EventHandler<ChannelClickEventArgs> DataChannelDoubleClicked;

        /// <summary>
        /// Data channel selection changed event
        /// </summary>
        public event EventHandler<ChannelSelectionChangedEventArgs> DataChannelSelectionChanged;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public Ctrl_GW_ChannelList()
        {
            InitializeComponent();

            ChannelList = new string[0];
            ChannelDescriptions = new string[0];
        }

        #region Control events

        #region LV_Channels

        private void LV_Channels_ItemDrag(object sender, ItemDragEventArgs e)
        {
            LV_Channels.DoDragDrop(LV_Channels.SelectedItems, DragDropEffects.Move);
        }

        private void LV_Channels_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void LV_Channels_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Send_NameListToForm();
        }

        private void LV_Channels_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Send_NameListToForm();
            }
        }

        private void LV_Channels_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                ChannelSelectionChangedEventArgs Arg = new ChannelSelectionChangedEventArgs();
                Arg.ChannelName = e.Item.Text;

                OnDataChannelSelectionChanged(Arg);
            }
        }

        private void LV_Channels_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (LV_Channels.SelectedItems != null)
                {
                    ChannelClickEventArgs Arg = new ChannelClickEventArgs();
                    Arg.ChannelName = LV_Channels.SelectedItems[0].Text;

                    OnDataChannelClicked(Arg);
                }
            }
        }

        #endregion

        #region Cmb_Filter

        private void Cmb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(Cmb_Filter.Text.Equals("")))
            {
                Fill_ChannelList(Cmb_Filter.Text);
            }
        }

        private void Cmb_Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            {
                if(!(Cmb_Filter.Text.Equals("")))
                {
                    if(Cmb_Filter.SelectedIndex==-1)
                    {
                        //Add new filter into the combo box
                        Cmb_Filter.Items.Insert(0, Cmb_Filter.Text);

                        //Limit Cmb_Filter item count to 10
                        if (Cmb_Filter.Items.Count > 10)
                        {
                            Cmb_Filter.Items.RemoveAt(10);
                        }
                    }

                    Fill_ChannelList(Cmb_Filter.Text);
                }
                else //Filter reset
                {
                    Show_ChannelList();
                }
            }
        }

        #endregion

        #endregion

        #region Private methodes

        private void Fill_ChannelList(string Filter)
        {
            LV_Channels.Items.Clear();

            if (!(ChannelList == null))
            {
                int i = 0;

                foreach (string sItem in ChannelList)
                {
                    if ((sItem.ToLower().Contains(Filter.ToLower())) || (Filter.Equals("")))
                    {
                        ListViewItem It = LV_Channels.Items.Add(sItem, 0);

                        if(!(ChannelDescriptions[i].Equals("")))
                        {
                            It.ToolTipText = ChannelDescriptions[i];
                        }
                    }

                    i++;
                }

                if(LV_Channels.Items.Count>0)
                {
                    LV_Channels.Sort();
                    LV_Channels.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        private string[] Create_SelectedItemsNameList()
        {
            if (!(LV_Channels.SelectedItems == null))
            {
                string[] Names = new string[LV_Channels.SelectedItems.Count];

                for(int i=0;i<LV_Channels.SelectedItems.Count;i++)
                {
                    Names[i] = LV_Channels.SelectedItems[i].Text;
                }

                return (Names);
            }
            else
            {
                return (null);
            }
        }

        private void Send_NameListToForm()
        {
            if (this.Parent.GetType().Equals(typeof(Frm_FlyingChannelList))) //Ctrl_GW_ChannelList hosted by a Frm_FlyingChannelList form
            {
                ((Frm_FlyingChannelList)this.Parent).Send_NameListToPropertiesForm(Create_SelectedItemsNameList());
            }
            else if (this.Parent.Parent.Parent.GetType().Equals(typeof(Ctrl_WaveForm))) //Ctrl_GW_ChannelList hosted by a Ctrl_GraphWindow user control
            {
            	((Ctrl_WaveForm)this.Parent.Parent.Parent).Add_Series(Create_SelectedItemsNameList());
            }
            else //Unknown control parent type, generate a data channel double click event
            {
                if (!(LV_Channels.SelectedItems == null))
                {
                    ChannelClickEventArgs Arg = new ChannelClickEventArgs();
                    Arg.ChannelName = LV_Channels.SelectedItems[0].Text;

                    OnDataChannelDoubleClicked(Arg);
                }
            }
        }

        private string Get_ChannelDescription(string ChannelName)
        {
            if (!(ChannelList == null))
            {
                for(int i=0;i< ChannelList.Length;i++)
                {
                    if(ChannelList[i].Equals(ChannelName))
                    {
                        return (ChannelDescriptions[i]);
                    }
                }
            }

            return ("");
        }

        #endregion

        #region Event handling methodes

        /// <summary>
        /// DataChannelClicked event handler
        /// </summary>
        /// <param name="e">ChannelClickEventArgs event argument</param>
        protected virtual void OnDataChannelClicked(ChannelClickEventArgs e)
        {
            EventHandler<ChannelClickEventArgs> handler = DataChannelClicked;
            if(handler!=null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// DataChannelDoubleClicked event handler
        /// </summary>
        /// <param name="e">ChannelClickEventArgs event argument</param>
        protected virtual void OnDataChannelDoubleClicked(ChannelClickEventArgs e)
        {
            EventHandler<ChannelClickEventArgs> handler = DataChannelDoubleClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// DataChannelSelectionChanged event handler
        /// </summary>
        /// <param name="e">ChannelSelectionChangedEventArgs event argument</param>
        protected virtual void OnDataChannelSelectionChanged(ChannelSelectionChangedEventArgs e)
        {
            EventHandler<ChannelSelectionChangedEventArgs> handler = DataChannelSelectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region Public methodes

        /// <summary>
        /// Show the list of channels
        /// </summary>
        public void Show_ChannelList()
        {
            Fill_ChannelList("");
        }

        /// <summary>
        /// Clear contents of the current Ctrl_GW_ChannelList object
        /// </summary>
        public void Clear_ChannelList()
        {
            ChannelList = new string[0];
            Fill_ChannelList("");
        }

        /// <summary>
        /// Add a channel name to the current Ctrl_GW_ChannelList list of channel names
        /// </summary>
        /// <param name="ChannelName">Name of the channel to add in the list</param>
        public void Add_ChannelName(string ChannelName)
        {
            if(!(ChannelName.Equals("")))
            {
                List<string> TmpChanList = new List<string>();
                List<string> TmpChanDesc = new List<string>();

                //TODO: Remove old code
                //foreach (string Name in ChannelList)
                //{
                //    TmpChanList.Add(Name);
                //}

                TmpChanList.AddRange(ChannelList);
                TmpChanDesc.AddRange(ChannelDescriptions);

                TmpChanList.Add(ChannelName);
                TmpChanDesc.Add("");

                ChannelList = TmpChanList.ToArray();
                ChannelDescriptions = TmpChanDesc.ToArray();

                Fill_ChannelList(Cmb_Filter.Text);
            }
        }

        /// <summary>
        /// Add a channel name and its description to the current Ctrl_GW_ChannelList list of channel names
        /// </summary>
        /// <param name="ChannelName">Name of the channel to add in the list</param>
        /// <param name="ChannelDescription">Description of the channel to add in the list</param>
        public void Add_ChannelNameWithDescription(string ChannelName, string ChannelDescription)
        {
            if (!(ChannelName.Equals("")))
            {
                Add_ChannelName(ChannelName);
                ChannelDescriptions[ChannelDescriptions.Length - 1] = ChannelDescription;
            }
        }

        #endregion
    }

    #region Custom event argument classes

    /// <summary>
    /// Data channnel click event argument class
    /// </summary>
    public class ChannelClickEventArgs : EventArgs
    {
        /// <summary>
        /// Name of the data channel that has been clicked
        /// </summary>
        public string ChannelName { get; set; }
    }

    /// <summary>
    /// Data channnel selection changed event argument class
    /// </summary>
    public class ChannelSelectionChangedEventArgs:EventArgs
    {
        /// <summary>
        /// Name of the data channel that has been clicked
        /// </summary>
        public string ChannelName { get; set; }
    }

    #endregion
}
