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
using System.Drawing;
using System.Windows.Forms;

namespace Ctrl_GraphWindow
{
	/// <summary>
	/// Contextual channel list control class
	/// </summary>
	public class Ctrl_GW_ContextualChannelList : ListView
	{
		#region Public members
		
		/// <summary>Width of the string of the longest channel name</summary>
		public int MaxStringWidth;
		
		#endregion
		
		#region Private members
		
		private List<string> Channels;
		
		#endregion
		
		/// <summary>
		/// Default constructor
		/// </summary>
		public Ctrl_GW_ContextualChannelList()
		{
			Channels = new List<string>();
			MaxStringWidth = 0;
		}
		
		#region Public methodes
		
		/// <summary>
		/// Add a channel name into the current object
		/// </summary>
		/// <param name="ChanName">Name of the channel to add</param>
		public void AddChannel(string ChanName)
		{
			Channels.Add(ChanName);
			
			Graphics g = this.CreateGraphics();
			
			int TxtSize = (int)g.MeasureString(ChanName, this.Font).Width;
			if (TxtSize > MaxStringWidth) MaxStringWidth = TxtSize;
				
			g.Dispose();
		}
		
		/// <summary>
		/// Show the channel list
		/// </summary>
		public void ShowChannels()
		{
			FilterItems("");
		}
		
		/// <summary>
		/// Apply a filter to show only items matching the filter
		/// </summary>
		/// <param name="Filter">Filter value</param>
		public void FilterItems(string Filter)
		{
			Items.Clear();
			
			foreach (string Chan in Channels)
			{
				if (Chan.ToUpper().Contains(Filter.ToUpper()) || Filter.Equals(""))
				{
					Items.Add(Chan, 0);
				}
			}
		}
		
		#endregion
	}
}
