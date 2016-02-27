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
        public  string[] ChannelList;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public Ctrl_GW_ChannelList()
        {
            InitializeComponent();
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
                foreach (string sItem in ChannelList)
                {
                    if ((sItem.ToLower().Contains(Filter.ToLower())) || (Filter.Equals("")))
                    {
                        LV_Channels.Items.Add(sItem, 0);
                    }
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

                foreach (string Name in ChannelList)
                {
                    TmpChanList.Add(Name);
                }

                TmpChanList.Add(ChannelName);
                ChannelList = TmpChanList.ToArray();

                Fill_ChannelList(Cmb_Filter.Text);
            }
        }

        #endregion
    }
}
