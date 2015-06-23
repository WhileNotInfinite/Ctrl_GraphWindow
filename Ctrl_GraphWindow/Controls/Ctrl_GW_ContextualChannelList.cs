/*
 * Created by SharpDevelop.
 * User: Vincent
 * Date: 13/06/2015
 * Time: 11:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
