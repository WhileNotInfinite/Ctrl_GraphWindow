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
    /// Flying channel list form for the graph properties edition form
    /// </summary>
    public partial class Frm_FlyingChannelList : Form
    {
        #region Private members

        Frm_GraphPropertiesEdtion FrmCaller;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Channels">List of channels</param>
        /// <param name="Caller">Reference to the Frm_GraphPropertiesEdtion calling the Frm_FlyingChannelList</param>
        public Frm_FlyingChannelList(string[] Channels, Frm_GraphPropertiesEdtion Caller)
        {
            InitializeComponent();

            FrmCaller = Caller;
            Ctrl_ChanList.ChannelList = Channels;
            Ctrl_ChanList.Show_ChannelList();
        }

        #region Control events

        #region Form

        private void Frm_FlyingChannelList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        #endregion

        #endregion

        #region Public methodes

        /// <summary>
        /// Send a list a channel names coming from the Ctrl_GW_ChannelList to the Frm_GraphPropertiesEdition form having called this flying channel list
        /// </summary>
        /// <param name="NameList">List of channel names</param>
        public void Send_NameListToPropertiesForm(string[] NameList)
        {
            FrmCaller.Add_SerieItems(NameList);
        }

        #endregion
    }
}
