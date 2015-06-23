/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 9/23/2014
 * Time: 13:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ctrl_GraphWindow
{
	/// <summary>
	/// Picture box getting the focus on click (derived of a picture box)
	/// </summary>
	public class GW_SelectablePictureBox : PictureBox
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public GW_SelectablePictureBox()
		{
			this.SetStyle(ControlStyles.Selectable, true);
		}
		
		/// <summary>
		/// Set the focus on the current control
		/// </summary>
		/// <param name="e">Mouse event argument</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.Focus();
			base.OnMouseDown(e);
		}
	}
}
