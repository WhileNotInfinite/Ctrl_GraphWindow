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
        /// <param name="Descriptions">List of channels descriptions</param>
        /// <param name="Caller">Reference to the Frm_GraphPropertiesEdtion calling the Frm_FlyingChannelList</param>
        public Frm_FlyingChannelList(string[] Channels, string[] Descriptions, Frm_GraphPropertiesEdtion Caller)
        {
            InitializeComponent();

            FrmCaller = Caller;

            Ctrl_ChanList.ChannelList = Channels;
            Ctrl_ChanList.ChannelDescriptions = Descriptions;

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
