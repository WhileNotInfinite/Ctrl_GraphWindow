using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ctrl_GraphWindow
{
    #region Enums

    #region Common enums

    /// <summary>
    /// Enumeration of screen positions for string value display
    /// </summary>
    public enum ScreenPositions
    {
        /// <summary>String not shown (invisible)</summary>
        Invisible   = 0,
        
        /// <summary>String shown at the center (horizontal or vertical) of the screen</summary>
        Center = 1,

        /// <summary>String shown at the top of the screen</summary>
        Top    = 2,

        /// <summary>String shown at the bottom of the screen</summary>
        Bottom = 3,

        /// <summary>String shown at the left of the screen</summary>
        Left   = 4,

        /// <summary>String shown at the rigth of the screen</summary>
        Right  = 5,
    }

    #endregion

    #region Graphic serie property enums

    /// <summary>
    /// Enumeration of graphic serie output value format
    /// </summary>
    public enum GraphSerieLegendFormats
    {
        /// <summary>Legend value format autmatic</summary>
    	Auto        = 0,
    	
    	/// <summary>Legend value format decimal</summary>
        Decimal     = 1,
        
        /// <summary>Legend value format hexadecimal</summary>
        Hexadecimal = 2,
        
        /// <summary>Legend value format binary</summary>
        Binary      = 3,
        
        /// <summary>Legend value format enumeration</summary>
        Enum        = 4,
    }

    /// <summary>
    /// Enumeration of graphic serie drawing modes
    /// </summary>
    public enum GraphSerieDrawingModes
    {
        /// <summary>Serie trace drawing mode step</summary>
    	Step = 0,
    	
    	/// <summary>Serie trace drawing mode line</summary>
        Line = 1,
    }

    /// <summary>
    /// Enumeration of graphic serie scaling mode
    /// </summary>
    public enum GraphSerieScaleModes
    {
        /// <summary>Serie scaling mode automatic</summary>
    	Auto = 0,
    	
    	/// <summary>Serie scaling mode custom (scale user defined)</summary>
        Custom = 1,
    }

    /// <summary>
    /// Enumeration of graphic serie marker styles
    /// </summary>
    public enum GraphSerieMarkerStyles
    {
        /// <summary>No serie sample point marker</summary>
    	None     = 0,
    	
    	/// <summary>Square serie sample point marker</summary>
        Square   = 1,
        
        /// <summary>Round serie sample point marker</summary>
        Round    = 2,
        
        /// <summary>Diamond serie sample point marker</summary>
        Diamond  = 3,
        
        /// <summary>Cross serie sample point marker</summary>
        Cross    = 4,
        
        /// <summary>Triangle serie sample point marker</summary>
        Triangle = 5,
    }

    /// <summary>
    /// Enumeration of graphic serie user grid modes
    /// </summary>
    public enum GraphSerieUserGridModes
    {
        /// <summary>Serie user grid mode none: No user grid</summary>
    	None         = 0,
    	
    	/// <summary>Serie user grid mode even: even repartion of grid line along the graph</summary>
        Even         = 1,
        
        /// <summary>Serie user grid mode min, max and average: one grid line for each min, max and average values</summary>
        MinMaxAvg    = 2,
        
        /// <summary>Serie user grid mode min, max and zero: one grid line for each min, max and zero values</summary>
        MinMaxZero   = 3,
        
        /// <summary>Serie user grid mode custom values: one grid line for each value defined by the user</summary>
        CustomValues = 4,
    }

    /// <summary>
    /// Enumeration of graphic serie reference lines modes
    /// </summary>
    public enum GraphSerieReferenceLineModes
    {
        /// <summary>Serie reference line mode none: No reference line</summary>
    	None    = 0,
    	
    	/// <summary>Serie reference line mode zero: Reference line drawn at zero</summary>
        Zero    = 1,
        
        /// <summary>Serie reference line mode min: Reference line drawn at the minimum serie value</summary>
        Min     = 2,
        
        /// <summary>Serie reference line mode max: Reference line drawn at the maximum serie value</summary>
        Max     = 3,
        
        /// <summary>Serie reference line mode average: Reference line drawn at the average serie value</summary>
        Average = 4,
        
        /// <summary>Serie reference line mode custom: Reference line drawn at the value defined by the user</summary>
        Custom  = 5,
    }

    #endregion

    #region Graphic window property enums

    /// <summary>
    /// Enumeration of graphic window layout modes
    /// </summary>
    public enum GraphicWindowLayoutModes
    {
        ///<summary>Series overlaying each other</summary>
        Overlay = 0,

        ///<summary>Series paralel to each other</summary>
        Paralel = 1,

        ///<summary>Custom serie arrangement into the graphic</summary>
        Custom = 2,
    }

    /// <summary>
    /// Enumeration of graphic legend informations
    /// </summary>
    /// <remarks>Bits field</remarks>
    public enum GraphicLegendInformations
    {
        /// <summary>Serie title</summary>
    	Label              = 0x001, //OK
    	
    	/// <summary>Serie current value</summary>
        CurrentValue       = 0x002, //OK
        
        /// <summary>Serie unit</summary>
        Unit               = 0x004, //OK
        
        /// <summary>Serie minimum value showed in the graphic</summary>
        GraphMin           = 0x008, //OK
        
        /// <summary>Serie maximum value showed in the graphic</summary>
        GraphMax           = 0x010, //OK
        
        /// <summary>Average of serie values showed in the graphic</summary>
        GraphAvg           = 0x020, //OK
        
        /// <summary>Serie value at the reference cursor</summary>
        RefCursorValue     = 0x040,
        
        /// <summary>Serie value difference between current and reference cursors</summary>
        RefCursorDiffValue = 0x080,
        
        /// <summary>Serie value difference in percent between current and reference cursors</summary>
        RefCursorDiffPerc  = 0x100,
        
        /// <summary>Serie value gradient between current and reference cursors</summary>
        RefCursorGradient  = 0x200,
    }

    /// <summary>
    /// Enumeration of graphic cursor modes
    /// </summary>
    public enum GraphicCursorMode
    {
    	/// <summary>No graphic cursor</summary>
    	None           = 0,
    	
    	/// <summary>Vertical line graphic cursor</summary>
    	VerticalLine   = 1,
    	
    	/// <summary>Horizontal line graphic cursor</summary>
    	HorizontalLine = 2,
    	
    	/// <summary>Vertical and horizontal line graphic cursor</summary>
    	Cross          = 3,
    	
    	/// <summary>Small cross line graphic cursor</summary>
    	Graticule      = 4,
    	
    	/// <summary>Square shape graphic cursor</summary>
    	Square         = 5,
    	
    	/// <summary>Circle shape graphic cursor</summary>
    	Circle         = 6,
    }
    
    /// <summary>
    /// Enumeration of graphic zoom mode
    /// </summary>
    public enum GraphicZoomMode
    {
    	/// <summary>Zooming function disabled</summary> 
    	Disabled = 0,
    	
    	/// <summary>Zoom on X axis only</summary> 
    	ZoomX    = 1,
    	
    	/// <summary>Zoom on Y axis only</summary> 
    	ZoomY    = 2,
    	
    	/// <summary>Zoom on both X and Y axis</summary> 
    	ZoomXY   = 3,
    }
    
    #endregion

    #endregion

    #region Structures

    #region Graphic serie property structure

    /// <summary>
    /// Structure of an enumeration value
    /// </summary>
    public struct GraphSerieEnumValue
    {
        /// <summary>
        /// Value of the enumeration
        /// </summary>
        public int Value;

        /// <summary>
        /// Text of the enumeration
        /// </summary>
        public string Text;
    }
    
    /// <summary>
    /// Sample data conversion to screen coordinates components
    /// </summary>
    public struct GW_SampleCoordConversion
    {
        /// <summary>
        /// Value to coordinate conversion gain
        /// </summary>
        public double Gain;

        /// <summary>
        /// Value to coordinate conversion zero
        /// </summary>
        public double Zero;

        /// <summary>
        /// StartPos Y point of a serie
        /// </summary>
        public int Top;
        
        /// <summary>
        /// EndPos Y point of a serie
        /// </summary>
        public int Bottom;

        /// <summary>
        /// Min Y value of the serie
        /// </summary>
        public double Min;

        /// <summary>
        /// Max Y value of the serie
        /// </summary>
        public double Max;
    }
    
    #endregion

    #endregion
    
    #region Sub classes

    #region Common sub-classes

    /// <summary>
    /// Graphic window font class
    /// </summary>
    /// <remarks>
    /// This class features a base 'Font' class and implement two methodes for the font properties XML node writing and reading
    /// </remarks>
    public class GW_Font
    {
        #region Private constants

        private const string DEF_FONT_NAME = "Arial";
        private const float  DEF_FONT_SIZE = 8;
        private const bool   DEF_FONT_OPT  = false;

        #endregion
        
        #region Public enums
        
        /// <summary>
        /// Enumeration of font internal properties
        /// </summary>
        public enum FontProperty
        {
        	/// <summary>Name of the font</summary>
        	Name      = 0,
        	
        	/// <summary>Size of the font</summary>
        	Size      = 1,
        	
        	/// <summary>Bold flag of the font</summary>
        	Bold      = 2,
        	
        	/// <summary>Italic flag of the font</summary>
        	Italic    = 3,
        	
        	/// <summary>Strikeout flag of the font</summary>
        	Strikeout = 4,
        	
        	/// <summary>Underline flag of the font</summary>
        	Underline = 5,
        }
        
        #endregion

        #region Public members

        /// <summary>
        /// Font of the GW_Font object
        /// </summary>
        public Font oFont;

        #endregion

        /// <summary>
        /// Default GW_Font constructor
        /// </summary>
        /// <param name="FontName">Font name</param>
        /// <param name="FontSize">Font size</param>
        /// <param name="bBold">Bold font flag</param>
        /// <param name="bItalic">Italic font flag</param>
        /// <param name="bRegular">Regular font flag</param>
        /// <param name="bStrikeout">Strikeout font flag</param>
        /// <param name="bUnderline">Underline font flag</param>
        public GW_Font(string FontName, float FontSize, bool bBold, bool bItalic, bool bRegular, bool bStrikeout, bool bUnderline)
        {
            FontStyle eStyle = new FontStyle();

            if (bBold)      eStyle |= FontStyle.Bold;
            if (bItalic)    eStyle |= FontStyle.Italic;
            if (bRegular)   eStyle |= FontStyle.Regular;
            if (bStrikeout) eStyle |= FontStyle.Strikeout;
            if (bUnderline) eStyle |= FontStyle.Underline;

            oFont = new Font(FontName, FontSize, eStyle);
        }

        #region Public methodes

        /// <summary>
        /// Return the XML node of the GW_Font properties
        /// </summary>
        /// <param name="oXDoc">XML document in which the GW_Font properties node will be created</param>
        /// <param name="NodeName">Name of the XML node to create</param>
        /// <returns>XML node of the GW_Font properties</returns>
        public XmlElement Create_FontXmlNode(XmlDocument oXDoc, string NodeName)
        {
            XmlElement xProp = null;
            XmlElement xFont = oXDoc.CreateElement(NodeName);
            
                xProp = oXDoc.CreateElement("Name");
                xProp.InnerText = oFont.Name;
                xFont.AppendChild(xProp);

                xProp = oXDoc.CreateElement("Size");
                xProp.InnerText = oFont.Size.ToString();
                xFont.AppendChild(xProp);

                xProp = oXDoc.CreateElement("Bold");
                xProp.InnerText = oFont.Bold.ToString();
                xFont.AppendChild(xProp);

                xProp = oXDoc.CreateElement("Italic");
                xProp.InnerText = oFont.Italic.ToString();
                xFont.AppendChild(xProp);

                xProp = oXDoc.CreateElement("Strikeout");
                xProp.InnerText = oFont.Strikeout.ToString();
                xFont.AppendChild(xProp);

                xProp = oXDoc.CreateElement("Underline");
                xProp.InnerText = oFont.Underline.ToString();
                xFont.AppendChild(xProp);

            return (xFont);
        }

        /// <summary>
        /// Read the XML node of the GW_Font properties
        /// </summary>
        /// <param name="xFont">GW_Font properties XML node to read</param>
        /// <returns>Node reading error flag: True = No Error / False = Error</returns>
        public bool Read_FontXmlNode(XmlNode xFont)
        {
            XmlNode xProp = null;

            try
            {
                xProp = xFont.SelectSingleNode("Name");
                string FontName = xProp.InnerText;

                xProp = xFont.SelectSingleNode("Size");
                float FontSize = float.Parse(xProp.InnerText);

                xProp = xFont.SelectSingleNode("Bold");
                bool bBold = bool.Parse(xProp.InnerText);

                xProp = xFont.SelectSingleNode("Italic");
                bool bItalic = bool.Parse(xProp.InnerText);

                xProp = xFont.SelectSingleNode("Strikeout");
                bool bStrikeout = bool.Parse(xProp.InnerText);

                xProp = xFont.SelectSingleNode("Underline");
                bool bUnderline = bool.Parse(xProp.InnerText);

                FontStyle eStyle = new FontStyle();

                if (bBold) eStyle |= FontStyle.Bold;
                if (bItalic) eStyle |= FontStyle.Italic;
                if (bStrikeout) eStyle |= FontStyle.Strikeout;
                if (bUnderline) eStyle |= FontStyle.Underline;

                oFont = new Font(FontName, FontSize, eStyle);
            }
            catch
            {
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// Determines whether the current object is set with default properties.
        /// </summary>
        /// <returns>True: Object is set with default properties / False: Object has custom properties</returns>
        public bool HasDefaultProperties()
        {
            if ((oFont.Name.Equals(DEF_FONT_NAME))
                && (oFont.Size == DEF_FONT_SIZE)
                && (oFont.Bold == DEF_FONT_OPT)
                && (oFont.Italic == DEF_FONT_OPT)
                && (oFont.Strikeout == DEF_FONT_OPT)
                && (oFont.Underline == DEF_FONT_OPT))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GW_Font Get_Clone()
        {
            GW_Font oClone = new GW_Font(oFont.Name, 
                                            oFont.Size, 
                                            oFont.Bold, 
                                            oFont.Italic, 
                                            true, 
                                            oFont.Strikeout, 
                                            oFont.Underline);

            return (oClone);
        }
		
        /// <summary>
        /// Change a property of the current font
        /// </summary>
        /// <param name="PropertyTarget">Property to change</param>
        /// <param name="PropertyValue">New property value</param>
        /// <returns>Property change result: True = property changed / False = Property not changed (error)</returns>
        public bool Set_FontProperty(FontProperty PropertyTarget, object PropertyValue)
        {
        	GW_Font FontClone = this.Get_Clone();
        	
        	FontStyle eStyle = new FontStyle();
        	eStyle |= FontStyle.Regular;
        	
        	switch (PropertyTarget)
        	{
        		case FontProperty.Name:
        			
        			if (!(PropertyValue.GetType().Equals(typeof(string))))
        			{
        				return(false);
        			}
        			
        			if (FontClone.oFont.Bold)      eStyle |= FontStyle.Bold;
		            if (FontClone.oFont.Italic)    eStyle |= FontStyle.Italic;
		            if (FontClone.oFont.Strikeout) eStyle |= FontStyle.Strikeout;
		            if (FontClone.oFont.Underline) eStyle |= FontStyle.Underline;
		
		            oFont = new Font((string)PropertyValue, FontClone.oFont.Size, eStyle);
        			
        			break;
        			
        		case FontProperty.Size:
        			
        			if (!(PropertyValue.GetType().Equals(typeof(float))))
        			{
        				return(false);
        			}
        			
        			if (FontClone.oFont.Bold)      eStyle |= FontStyle.Bold;
		            if (FontClone.oFont.Italic)    eStyle |= FontStyle.Italic;
		            if (FontClone.oFont.Strikeout) eStyle |= FontStyle.Strikeout;
		            if (FontClone.oFont.Underline) eStyle |= FontStyle.Underline;
		
		            oFont = new Font(FontClone.oFont.Name, (float)PropertyValue, eStyle);
        			
        			break;
        		
        		case FontProperty.Bold:
        			
        			if (!(PropertyValue.GetType().Equals(typeof(bool))))
        			{
        				return(false);
        			}
        			
        			if ((bool)PropertyValue)       eStyle |= FontStyle.Bold;
		            if (FontClone.oFont.Italic)    eStyle |= FontStyle.Italic;
		            if (FontClone.oFont.Strikeout) eStyle |= FontStyle.Strikeout;
		            if (FontClone.oFont.Underline) eStyle |= FontStyle.Underline;
		
		            oFont = new Font(FontClone.oFont.Name, FontClone.oFont.Size, eStyle);
        			
        			break;
        			
        		case FontProperty.Italic:
        			
        			if (!(PropertyValue.GetType().Equals(typeof(bool))))
        			{
        				return(false);
        			}
        			
        			if (FontClone.oFont.Bold)      eStyle |= FontStyle.Bold;
        			if ((bool)PropertyValue)       eStyle |= FontStyle.Italic;
		            if (FontClone.oFont.Strikeout) eStyle |= FontStyle.Strikeout;
		            if (FontClone.oFont.Underline) eStyle |= FontStyle.Underline;
		
		            oFont = new Font(FontClone.oFont.Name, FontClone.oFont.Size, eStyle);
        			
        			break;
        			
        		case FontProperty.Strikeout:
        			
        			if (!(PropertyValue.GetType().Equals(typeof(bool))))
        			{
        				return(false);
        			}
        			
        			if (FontClone.oFont.Bold)      eStyle |= FontStyle.Bold;
        			if (FontClone.oFont.Italic)    eStyle |= FontStyle.Italic;
        			if ((bool)PropertyValue)       eStyle |= FontStyle.Strikeout;
		            if (FontClone.oFont.Underline) eStyle |= FontStyle.Underline;
		
		            oFont = new Font(FontClone.oFont.Name, FontClone.oFont.Size, eStyle);
        			
        			break;
        			
        		case FontProperty.Underline:
        			
        			if (!(PropertyValue.GetType().Equals(typeof(bool))))
        			{
        				return(false);
        			}
        			
        			if (FontClone.oFont.Bold)      eStyle |= FontStyle.Bold;
        			if (FontClone.oFont.Italic)    eStyle |= FontStyle.Italic;
        			if (FontClone.oFont.Strikeout) eStyle |= FontStyle.Strikeout;
        			if ((bool)PropertyValue)       eStyle |= FontStyle.Underline;
		            
		            oFont = new Font(FontClone.oFont.Name, FontClone.oFont.Size, eStyle);
        			
        			break;
        	}
        	
        	return(true);
        }
        
        #endregion
    }

    /// <summary>
    /// Graphic line properties class
    /// </summary>
    public class GraphLineProperties
    {
        #region Private constants

        private const bool DEF_VISIBLE = true;
        private const int  DEF_WIDTH   = 1;
        private const System.Drawing.Drawing2D.DashStyle DEF_STYLE = System.Drawing.Drawing2D.DashStyle.Solid;

        #endregion

        #region Public members

        /// <summary>
        /// Grid visibility flag
        /// </summary>
        public bool Visible;

        /// <summary>
        /// Grid line width
        /// </summary>
        public int LineWidth;

        /// <summary>
        /// Grid line color
        /// </summary>
        public Color LineColor;

        /// <summary>
        /// Grid line style
        /// </summary>
        public System.Drawing.Drawing2D.DashStyle LineStyle;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphLineProperties()
        {
            Visible   = DEF_VISIBLE;
            LineWidth = DEF_WIDTH;
            LineColor = Color.LightGray;
            LineStyle = DEF_STYLE;
        }

        /// <summary>
        /// Constructor instancing a GraphLineProperties using a GraphLineProperties template properties
        /// </summary>
        /// <param name="Template">GraphLineProperties template</param>
        public GraphLineProperties(GraphLineProperties Template)
        {
            Visible = Template.Visible;
            LineWidth = Template.LineWidth;
            LineColor = Template.LineColor;
            LineStyle = Template.LineStyle;
        }

        #endregion

        #region Public methodes

        /// <summary>
        /// Return the XML node of the graphic line properties
        /// </summary>
        /// <param name="oXDoc">XML document in which the graphic line properties node will be created</param>
        /// <param name="NodeName">Name of the XML node to create</param>
        /// <returns>XML node of the graphic line properties</returns>
        public XmlElement Create_GraphLineXmlNode(XmlDocument oXDoc, string NodeName)
        {
            XmlElement xProp = null;
            XmlElement xLine = oXDoc.CreateElement(NodeName);

                xProp = oXDoc.CreateElement("Visible");
                xProp.InnerText = Visible.ToString();
                xLine.AppendChild(xProp);

                xProp = oXDoc.CreateElement("Width");
                xProp.InnerText = LineWidth.ToString();
                xLine.AppendChild(xProp);

                xProp = oXDoc.CreateElement("Color");
                xProp.InnerText = LineColor.ToArgb().ToString();
                xLine.AppendChild(xProp);

                xProp = oXDoc.CreateElement("LineStyle");
                xProp.InnerText = LineStyle.ToString();
                xLine.AppendChild(xProp);

            return (xLine);    
        }

        /// <summary>
        /// Read the XML node of the graphic line properties
        /// </summary>
        /// <param name="xLine">Graphic line properties XML node to read</param>
        /// <returns>Node reading error flag: True = No Error / False = Error</returns>
        public bool Read_GraphLineXmlNode(XmlNode xLine)
        {
            XmlNode xProp = null;

            try
            {
                xProp = xLine.SelectSingleNode("Visible");
                Visible = bool.Parse(xProp.InnerText);

                xProp = xLine.SelectSingleNode("Width");
                LineWidth = int.Parse(xProp.InnerText);

                xProp = xLine.SelectSingleNode("Color");
                LineColor = Color.FromArgb(int.Parse(xProp.InnerText));

                xProp = xLine.SelectSingleNode("LineStyle");
                LineStyle = (System.Drawing.Drawing2D.DashStyle)(Enum.Parse(typeof(System.Drawing.Drawing2D.DashStyle), xProp.InnerText));
            }
            catch
            {
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// Determines whether the current object is set with default properties.
        /// </summary>
        /// <returns>True: Object is set with default properties / False: Object has custom properties</returns>
        /// <remarks>Member 'LineColor' is excluded of the comparison</remarks>
        public bool HasDefaultProperties()
        {
            if ((Visible == DEF_VISIBLE)
                && (LineWidth == DEF_WIDTH)
                && (LineStyle.Equals(DEF_STYLE)))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// Determines whether the current object is set with default template properties.
        /// </summary>
        /// <param name="Template">Default template properties</param>
        /// <returns>True: Object is set with default template properties / False: Object has custom properties</returns>
        /// <remarks>Member 'LineColor' is excluded of the comparison</remarks>
        public bool HasDefaultProperties(GraphLineProperties Template)
        {
            if ((Visible == Template.Visible)
                && (LineWidth == Template.LineWidth)
                && (LineStyle.Equals(Template.LineStyle)))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphLineProperties Get_Clone()
        {
            GraphLineProperties oClone = new GraphLineProperties();

            oClone.Visible = Visible;
            oClone.LineWidth = LineWidth;
            oClone.LineColor = LineColor;
            oClone.LineStyle = LineStyle;

            return (oClone);
        }

        #endregion
    }

    /// <summary>
    /// Grahic serie reference line properties class
    /// </summary>
    public class GraphReferenceLine
    {
        #region Public members

        /// <summary>
        /// Identification key of the reference line
        /// </summary>
        public int iKey;

        /// <summary>
        /// Graph serie reference line visible flag
        /// </summary>
        public bool Visible;

        /// <summary>
        /// Graph serie reference line mode
        /// </summary>
        public GraphSerieReferenceLineModes ReferenceMode;

        /// <summary>
        /// Graph serie reference line style
        /// </summary>
        public GraphLineProperties ReferenceStyle;

        /// <summary>
        /// Graph serie reference line value for the 'Custom' mode
        /// </summary>
        public double ReferenceValue;

        /// <summary>
        /// Graph serie reference line value position on screen
        /// </summary>
        public ScreenPositions ReferenceValuePosition;

        /// <summary>
        /// Graph serie reference line title
        /// </summary>
        public string ReferenceTitle;

        /// <summary>
        /// Graph serie reference line title position on screen
        /// </summary>
        public ScreenPositions ReferenceTitlePosition;

        /// <summary>
        /// Refenrence line value text font
        /// </summary>
        public GW_Font ReferenceValueFont;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphReferenceLine()
        {
            iKey = -1;
            Visible = true;
            ReferenceMode = GraphSerieReferenceLineModes.Custom;
            ReferenceStyle = new GraphLineProperties();
            ReferenceValue = 0;
            ReferenceValuePosition = ScreenPositions.Center;
            ReferenceTitle = "";
            ReferenceValuePosition = ScreenPositions.Center;
            ReferenceTitlePosition = ScreenPositions.Invisible;
            ReferenceValueFont = new GW_Font("Arial", 8, false, false, true, false, false);
        }

        #region Public methodes

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphReferenceLine Get_Clone()
        {
            GraphReferenceLine oClone = new GraphReferenceLine();

            oClone.iKey = iKey;
            oClone.Visible = Visible;
            oClone.ReferenceMode = ReferenceMode;
            oClone.ReferenceStyle = ReferenceStyle.Get_Clone();
            oClone.ReferenceValue = ReferenceValue;
            oClone.ReferenceValuePosition = ReferenceValuePosition;
            oClone.ReferenceTitle = ReferenceTitle;
            oClone.ReferenceTitlePosition = ReferenceTitlePosition;
            oClone.ReferenceValueFont = ReferenceValueFont.Get_Clone();

            return (oClone);
        }
        
        /// <summary>
        /// Return the XML node of the current graphic reference line properties
        /// </summary>
        /// <param name="oXDoc">XML document in which the graphic reference line properties node will be created</param>
        /// <param name="NodeName">Name of the XML node to create</param>
        /// <returns>XML node of the current graphic reference line properties</returns>
        public XmlElement Create_ReferenceLineXmlNode(XmlDocument oXDoc, string NodeName)
        {
            XmlElement xProp = null;
            XmlElement xLine = oXDoc.CreateElement(NodeName);

                XmlAttribute xAtrLineKey = oXDoc.CreateAttribute("KeyId");
                xAtrLineKey.Value = iKey.ToString();
                xLine.Attributes.Append(xAtrLineKey);

                xProp = oXDoc.CreateElement("Visible");
                xProp.InnerText = Visible.ToString();
                xLine.AppendChild(xProp);

                xProp = oXDoc.CreateElement("ReferenceMode");
                xProp.InnerText = ReferenceMode.ToString();
                xLine.AppendChild(xProp);

                XmlElement xRefStyle = ReferenceStyle.Create_GraphLineXmlNode(oXDoc, "ReferenceLineStyle");
                xLine.AppendChild(xRefStyle);

                xProp = oXDoc.CreateElement("ReferenceValue");
                xProp.InnerText = ReferenceValue.ToString();
                xLine.AppendChild(xProp);

                xProp = oXDoc.CreateElement("ReferenceValuePosition");
                xProp.InnerText = ReferenceValuePosition.ToString();
                xLine.AppendChild(xProp);

                xProp = oXDoc.CreateElement("ReferenceTitle");
                xProp.InnerText = ReferenceTitle;
                xLine.AppendChild(xProp);

                xProp = oXDoc.CreateElement("ReferenceTitlePosition");
                xProp.InnerText = ReferenceTitlePosition.ToString();
                xLine.AppendChild(xProp);

                XmlElement xLineValFont = ReferenceValueFont.Create_FontXmlNode(oXDoc, "ReferenceValueFont");
                xLine.AppendChild(xLineValFont);

            return (xLine);
        }

        /// <summary>
        /// Read the XML node of the graphic reference line properties
        /// </summary>
        /// <param name="xLine">Graphic reference line properties XML node to read</param>
        /// <returns>Node reading error flag: True = No Error / False = Error</returns>
        public bool Read_GraphLineXmlNode(XmlNode xLine)
        {
            XmlNode xProp = null;

            try
            {
                iKey = int.Parse(xLine.Attributes["KeyId"].Value);

                    xProp = xLine.SelectSingleNode("Visible");
                    Visible = bool.Parse(xProp.InnerText);

                    xProp = xLine.SelectSingleNode("ReferenceMode");
                    ReferenceMode = (GraphSerieReferenceLineModes)Enum.Parse(typeof(GraphSerieReferenceLineModes), xProp.InnerText);

                    XmlNode xRefStyle = xLine.SelectSingleNode("ReferenceLineStyle");
                    ReferenceStyle.Read_GraphLineXmlNode(xRefStyle);

                    xProp = xLine.SelectSingleNode("ReferenceValue");
                    ReferenceValue = double.Parse(xProp.InnerText);

                    xProp = xLine.SelectSingleNode("ReferenceValuePosition");
                    ReferenceValuePosition = (ScreenPositions)Enum.Parse(typeof(ScreenPositions), xProp.InnerText);

                    xProp = xLine.SelectSingleNode("ReferenceTitle");
                    ReferenceTitle = xProp.InnerText;

                    xProp = xLine.SelectSingleNode("ReferenceTitlePosition");
                    ReferenceTitlePosition = (ScreenPositions)Enum.Parse(typeof(ScreenPositions), xProp.InnerText);

                    XmlNode xLineValFont = xLine.SelectSingleNode("ReferenceValueFont");
                    ReferenceValueFont.Read_FontXmlNode(xLineValFont);
            }
            catch
            {
                return (false);
            }

            return (true);
        }

        #endregion
    }

    #endregion

    #region Graphic serie property sub-classes

    /// <summary>
    /// Grahic serie output value format properties class
    /// </summary>
    public class GraphSerieValueFormat
    {
        #region Private constants

        private const GraphSerieLegendFormats DEF_FORMAT = GraphSerieLegendFormats.Auto;
        private const int DEF_DECIMALS = 3;

        #endregion

        #region Public members

        /// <summary>
        /// Graphic serie output value format
        /// </summary>
        public GraphSerieLegendFormats Format;

        /// <summary>
        /// Number of decimals of a serie value
        /// </summary>
        public int Decimals;

        /// <summary>
        /// List of enumerations
        /// </summary>
        public List<GraphSerieEnumValue> Enums;

        #endregion

        #region Private members

        private int AutoDecNumbers;
        
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphSerieValueFormat()
        {
            Format = DEF_FORMAT;
            Decimals = DEF_DECIMALS;
            Enums = new List<GraphSerieEnumValue>();

            AutoDecNumbers = 0;

        }

        #region Public methodes

        /// <summary>
        /// Return the value given as argument formatted accordingly to the current GraphSerieValueFormat object properties
        /// </summary>
        /// <param name="ValIn">Value to format</param>
        /// <returns>Formatted value</returns>
        public string Get_ValueFormatted(double ValIn)
        {
            string sValFormatted = "";

            switch(Format)
            {
                case GraphSerieLegendFormats.Auto:

                    sValFormatted = (Math.Round(ValIn, AutoDecNumbers)).ToString();
                    break;

                case GraphSerieLegendFormats.Decimal:

                    sValFormatted = (Math.Round(ValIn, Decimals)).ToString();
                    break;

                case GraphSerieLegendFormats.Hexadecimal:

                    //sValFormatted = ((int)ValIn).ToString("{0:x}");
                    sValFormatted = "0x" + ((int)ValIn).ToString("X");
                    break;

                case GraphSerieLegendFormats.Binary:

                    sValFormatted = Convert.ToString((int)ValIn, 2);
                    break;

                case GraphSerieLegendFormats.Enum:

                    sValFormatted = Get_EnumText((int)ValIn);
                    break;
            }

            return (sValFormatted);
        }

        /// <summary>
        /// Determines whether the current object is set with default properties.
        /// </summary>
        /// <returns>True: Object is set with default properties / False: Object has custom properties</returns>
        public bool HasDefaultProperties()
        {
            if ((Format.Equals(DEF_FORMAT))
                && (Decimals == DEF_DECIMALS) 
                && (Enums.Count == 0))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphSerieValueFormat Get_Clone()
        {
            GraphSerieValueFormat oClone = new GraphSerieValueFormat();

            oClone.Format = Format;
            oClone.Decimals = Decimals;

            if(Enums.Count>0)
            {
                foreach(GraphSerieEnumValue sEnum in Enums)
                {
                    GraphSerieEnumValue sCloneEnum = new GraphSerieEnumValue();

                    sCloneEnum.Value = sEnum.Value;
                    sCloneEnum.Text = sEnum.Text;

                    oClone.Enums.Add(sCloneEnum);
                }
            }

            return (oClone);
        }

        /// <summary>
        /// Add a new enum to the enumeration list
        /// </summary>
        /// <param name="Value">Value of the enum to add</param>
        /// <param name="Text">Text of the enum to add</param>
        public void Add_NewEnum(int Value, string Text)
        {
            GraphSerieEnumValue sEnum = new GraphSerieEnumValue();

            sEnum.Value = Value;
            sEnum.Text = Text;

            Enums.Add(sEnum);
        }

        /// <summary>
        /// Set the value range for decimal number calculation in 'Auto' mode
        /// </summary>
        /// <param name="Range">Serie value range</param>
        public void Set_ValueRange(double Range)
        {
            Set_AutoDecimalsNumber(Range);
        }

        #endregion

        #region Private methodes

        private string Get_EnumText(int Value)
        {
            foreach(GraphSerieEnumValue sEnum in Enums)
            {
                if(sEnum.Value==Value)
                {
                    return (sEnum.Text);
                }
            }

            return ("<?>");
        }

        private void Set_AutoDecimalsNumber(double ValueRange)
        {
            if (ValueRange == 0)
            {
                AutoDecNumbers = 0;
            }
            else if (ValueRange < 0.00001)
            {
                AutoDecNumbers = 7;
            }
            else if (ValueRange < 0.0001)
            {
                AutoDecNumbers = 6;
            }
            else if (ValueRange < 0.001)
            {
                AutoDecNumbers = 5;
            }
            else if (ValueRange < 0.01)
            {
                AutoDecNumbers = 4;
            }
            else if (ValueRange < 0.1)
            {
                AutoDecNumbers = 3;
            }
            else if (ValueRange < 1)
            {
                AutoDecNumbers = 2;
            }
            else if (ValueRange < 10)
            {
                AutoDecNumbers = 1;
            }
            else
            {
                AutoDecNumbers = 0;
            }
        }

        #endregion
    }

    /// <summary>
    /// Grahic serie marker properties class
    /// </summary>
    public class GraphSerieMarkProperties
    {
        #region Public members

        /// <summary>
        /// Serie markers visible flag
        /// </summary>
        public bool Visible;

        /// <summary>
        /// Marker style
        /// </summary>
        public GraphSerieMarkerStyles Style;
        
        /// <summary>
        /// Marker size
        /// </summary>
        public int Size;

        /// <summary>
        /// Marker interior empty flag
        /// </summary>
        public bool InteriorEmpty;

        /// <summary>
        /// Marker border color
        /// </summary>
        public Color MarkColor;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphSerieMarkProperties()
        {
            Visible = false;
            Style = GraphSerieMarkerStyles.Square;
            Size = 1;
            InteriorEmpty = false;
            MarkColor = Color.White;
        }

        #region Public methodes

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphSerieMarkProperties Get_Clone()
        {
            GraphSerieMarkProperties oClone = new GraphSerieMarkProperties();

            oClone.Visible = Visible;
            oClone.Style = Style;
            oClone.InteriorEmpty = InteriorEmpty;
            oClone.MarkColor = MarkColor;

            return (oClone);
        }

        #endregion
    }

    /// <summary>
    /// Grahic serie user grid properties class
    /// </summary>
    public class GraphSerieUserGrid
    {
        #region Private constants

        private const GraphSerieUserGridModes DEF_MODE = GraphSerieUserGridModes.Even;
        private const int DEF_DIV_COUNT = 10;
        private const bool DEF_VAL_VISIBLE = false;
        private const string DEF_FONT_NAME = "Arial";
        private const int DEF_FONT_SIZE = 8;
        private const bool DEF_FONT_OPT = false;
        #endregion

        #region Public members

        #region Common properties

        /// <summary>
        /// Graph serie user grid visible flag
        /// </summary>
        public bool Visible;

        #endregion

        #region Vertical grid

        /// <summary>
        /// Graph serie vertical user grid mode
        /// </summary>
        public GraphSerieUserGridModes VerticalGridMode;

        /// <summary>
        /// Graph serie vertical user grid line properties
        /// </summary>
        public GraphLineProperties VerticalLinesStyle;

        /// <summary>
        /// Number of divisions of the graph serie vertical user grid in 'Even' mode
        /// </summary>
        public int VerticalDivisionCount;

        /// <summary>
        /// Graph serie vertical user grid custom values list for grid in 'CustomValues' mode
        /// </summary>
        public List<double> VerticalCustomValues;

        /// <summary>
        /// Graph serie vertical user grid values visible flag
        /// </summary>
        public bool VerticalGridValuesVisible;

        /// <summary>
        /// Vertical grid values texts font
        /// </summary>
        public GW_Font VerticalGridValueFont;

        #endregion

        #region Horizontal grid

        /// <summary>
        /// Graph serie horizontal user grid mode
        /// </summary>
        public GraphSerieUserGridModes HorizontalGridMode;

        /// <summary>
        /// Graph serie horizontal user grid line properties
        /// </summary>
        public GraphLineProperties HorizontalLinesStyle;

        /// <summary>
        /// Number of divisions of the graph serie horizontal user grid in 'Even' mode
        /// </summary>
        public int HorizontalDivisionCount;

        /// <summary>
        /// Graph serie horizontal user grid custom values list for grid in 'CustomValues' mode
        /// </summary>
        public List<double> HorizontalCustomValues;

        /// <summary>
        /// Graph serie horizontal user grid values visible flag
        /// </summary>
        public bool HorizontalGridValuesVisible;

        /// <summary>
        /// Horizontal grid values texts font
        /// </summary>
        public GW_Font HorizontalGridValueFont;

        #endregion

        #endregion

        #region Private members

        private static GraphLineProperties DefGridLineStyle;
        
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphSerieUserGrid()
        {
            DefGridLineStyle = new GraphLineProperties();
            DefGridLineStyle.LineColor = Color.White;
            DefGridLineStyle.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            DefGridLineStyle.LineWidth = 1;
            DefGridLineStyle.Visible = false;

            Visible = false;

            VerticalGridMode = DEF_MODE;
            VerticalLinesStyle = new GraphLineProperties(DefGridLineStyle);
            VerticalDivisionCount = DEF_DIV_COUNT;
            VerticalCustomValues = new List<double>();
            VerticalGridValuesVisible = DEF_VAL_VISIBLE;
            VerticalGridValueFont = new GW_Font(DEF_FONT_NAME, (float)DEF_FONT_SIZE, DEF_FONT_OPT, DEF_FONT_OPT, true, DEF_FONT_OPT, DEF_FONT_OPT);

            HorizontalGridMode = DEF_MODE;
            HorizontalLinesStyle = new GraphLineProperties(DefGridLineStyle);
            HorizontalDivisionCount = DEF_DIV_COUNT;
            HorizontalCustomValues = new List<double>();
            HorizontalGridValuesVisible = DEF_VAL_VISIBLE;
            HorizontalGridValueFont = new GW_Font(DEF_FONT_NAME, (float)DEF_FONT_SIZE, DEF_FONT_OPT, DEF_FONT_OPT, true, DEF_FONT_OPT, DEF_FONT_OPT);
        }

        #region Public methodes

        /// <summary>
        /// Determines whether the current object is set with default properties.
        /// </summary>
        /// <returns>True: Object is set with default properties / False: Object has custom properties</returns>
        public bool HasDefaultProperties()
        {
            if ((Visible == false)
                && (VerticalGridMode.Equals(DEF_MODE))
                && (VerticalLinesStyle.HasDefaultProperties(DefGridLineStyle))
                && (VerticalDivisionCount == DEF_DIV_COUNT)
                && (VerticalCustomValues.Count == 0)
                && (VerticalGridValuesVisible == DEF_VAL_VISIBLE)
                && (VerticalGridValueFont.oFont.Name.Equals(DEF_FONT_NAME))
                && (VerticalGridValueFont.oFont.Size.Equals((float)DEF_FONT_SIZE))
                && (VerticalGridValueFont.oFont.Bold == DEF_FONT_OPT)
                && (VerticalGridValueFont.oFont.Italic == DEF_FONT_OPT)
                && (VerticalGridValueFont.oFont.Strikeout == DEF_FONT_OPT)
                && (VerticalGridValueFont.oFont.Underline == DEF_FONT_OPT)
                && (HorizontalGridMode.Equals(DEF_MODE))
                && (HorizontalLinesStyle.HasDefaultProperties(DefGridLineStyle))
                && (HorizontalDivisionCount == DEF_DIV_COUNT)
                && (HorizontalCustomValues.Count == 0)
                && (HorizontalGridValuesVisible == DEF_VAL_VISIBLE)
                && (HorizontalGridValueFont.oFont.Name.Equals(DEF_FONT_NAME))
                && (HorizontalGridValueFont.oFont.Size.Equals((float)DEF_FONT_SIZE))
                && (HorizontalGridValueFont.oFont.Bold == DEF_FONT_OPT)
                && (HorizontalGridValueFont.oFont.Italic == DEF_FONT_OPT)
                && (HorizontalGridValueFont.oFont.Strikeout == DEF_FONT_OPT)
                && (HorizontalGridValueFont.oFont.Underline == DEF_FONT_OPT))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphSerieUserGrid Get_Clone()
        {
            GraphSerieUserGrid oClone = new GraphSerieUserGrid();

            oClone.Visible = Visible;
            
            oClone.VerticalGridMode = VerticalGridMode;
            oClone.VerticalLinesStyle = VerticalLinesStyle.Get_Clone();
            oClone.VerticalDivisionCount = VerticalDivisionCount;
            oClone.VerticalGridValuesVisible = VerticalGridValuesVisible;
            oClone.VerticalGridValueFont = VerticalGridValueFont.Get_Clone();

            if(VerticalCustomValues.Count>0)
            {
                foreach(double Val in VerticalCustomValues)
                {
                    oClone.VerticalCustomValues.Add(Val);
                }
            }

            oClone.HorizontalGridMode = HorizontalGridMode;
            oClone.HorizontalLinesStyle = HorizontalLinesStyle.Get_Clone();
            oClone.HorizontalDivisionCount = HorizontalDivisionCount;
            oClone.HorizontalGridValuesVisible = HorizontalGridValuesVisible;
            oClone.HorizontalGridValueFont = HorizontalGridValueFont.Get_Clone();

            if (HorizontalCustomValues.Count > 0)
            {
                foreach (double Val in HorizontalCustomValues)
                {
                    oClone.HorizontalCustomValues.Add(Val);
                }
            }

            return (oClone);
        }

        #endregion
    }

    /// <summary>
    /// Graphic serie Y axis properties class
    /// </summary>
    public class GraphSerieAxis
    {
        #region Private constants

        private const bool DEF_AXIS_VISIBLE  = true;
        private const bool DEF_VALUE_VISIBLE = true;

        #endregion

        #region Public members

        /// <summary>
        /// Graph serie Y axis visible flag
        /// </summary>
        public bool Visible;

        /// <summary>
        /// Graph serie Y axis line style
        /// </summary>
        public GraphLineProperties AxisLineStyle;

        /// <summary>
        /// Graph serie Y axis scale values visible flag
        /// </summary>
        public bool AxisValuesVisible;
        
        /// <summary>
        /// Graph serie Y axis title visible flag
        /// </summary>
        public bool AxisTitleVisible;

        /// <summary>
        /// Graph serie Y axis scale values font
        /// </summary>
        public GW_Font AxisValuesFont;

        #endregion

        #region Private members

        private static GraphLineProperties DefYAxisStyle;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphSerieAxis()
        {
            DefYAxisStyle = new GraphLineProperties();
            DefYAxisStyle.Visible = true;
            DefYAxisStyle.LineWidth = 1;
            DefYAxisStyle.LineColor = Color.White;
            DefYAxisStyle.LineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            
            Visible = DEF_AXIS_VISIBLE;
            AxisLineStyle = new GraphLineProperties(DefYAxisStyle);
            AxisValuesVisible = DEF_VALUE_VISIBLE;
            AxisTitleVisible = false;
            AxisValuesFont = new GW_Font("Arial", 8, false, false, true, false, false);
        }

        #region Public methodes

        /// <summary>
        /// Determines whether the current object is set with default properties.
        /// </summary>
        /// <returns>True: Object is set with default properties / False: Object has custom properties</returns>
        public bool HasDefaultProperties()
        {
            if ((Visible == DEF_AXIS_VISIBLE)
                && (AxisLineStyle.HasDefaultProperties(DefYAxisStyle))
                && (AxisValuesVisible == DEF_VALUE_VISIBLE)
                && (AxisTitleVisible == false)
                && (AxisValuesFont.HasDefaultProperties()))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphSerieAxis Get_Clone()
        {
            GraphSerieAxis oClone = new GraphSerieAxis();

            oClone.Visible = Visible;
            oClone.AxisLineStyle = AxisLineStyle.Get_Clone();
            oClone.AxisValuesVisible = AxisValuesVisible;
            oClone.AxisTitleVisible = AxisTitleVisible;
            oClone.AxisValuesFont = AxisValuesFont.Get_Clone();

            return (oClone);
        }

        #endregion
    }

    #endregion

    #region Graphic window property sub-classes

    /// <summary>
    /// Graphic frame properties class
    /// </summary>
    public class GraphFrameProperties
    {
        #region Public members

        /// <summary>
        /// Line width of the frame
        /// </summary>
        public int BorderWidth;

        /// <summary>
        /// Line color of the frame
        /// </summary>
        public Color BorderColor;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphFrameProperties()
        {
            BorderWidth = 2;
            BorderColor = Color.White;
        }

        #region Public methodes

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphFrameProperties Get_Clone()
        {
            GraphFrameProperties oClone = new GraphFrameProperties();

            oClone.BorderWidth = BorderWidth;
            oClone.BorderColor = BorderColor;

            return (oClone);
        }

        #endregion
    }

    /// <summary>
    /// Graphic grids properties class
    /// </summary>
    public class GraphGridProperties
    {
        #region Public members

        /// <summary>
        /// Main horizontal grid properties
        /// </summary>
        public GraphLineProperties MainHorizontalGrid;

        /// <summary>
        /// Main vertical grid properties
        /// </summary>
        public GraphLineProperties MainVerticalGrid;

        /// <summary>
        /// Secondary horizontal grid properties
        /// </summary>
        public GraphLineProperties SecondaryHorizontalGrid;

        /// <summary>
        /// Secondary vertical grid properties
        /// </summary>
        public GraphLineProperties SecondaryVerticalGrid;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphGridProperties()
        {
            MainHorizontalGrid      = new GraphLineProperties();
            MainVerticalGrid        = new GraphLineProperties();
            SecondaryHorizontalGrid = new GraphLineProperties();
            SecondaryVerticalGrid   = new GraphLineProperties();

            //Main grids properties default values
            MainHorizontalGrid.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            MainHorizontalGrid.LineColor = Color.DarkGray;

            MainVerticalGrid.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            MainVerticalGrid.LineColor = Color.DarkGray;

            //Secondary grids properties default values
            SecondaryHorizontalGrid.Visible = false;
            SecondaryHorizontalGrid.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            SecondaryHorizontalGrid.LineColor = Color.LightGray;

            SecondaryVerticalGrid.Visible = false;
            SecondaryVerticalGrid.LineStyle   = System.Drawing.Drawing2D.DashStyle.Dot;
            SecondaryVerticalGrid.LineColor = Color.LightGray;
        }

        #region Public methodes

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphGridProperties Get_Clone()
        {
            GraphGridProperties oClone = new GraphGridProperties();

            oClone.MainHorizontalGrid = MainHorizontalGrid.Get_Clone();
            oClone.MainVerticalGrid = MainVerticalGrid.Get_Clone();
            oClone.SecondaryHorizontalGrid = SecondaryHorizontalGrid.Get_Clone();
            oClone.SecondaryVerticalGrid = SecondaryVerticalGrid.Get_Clone();

            return (oClone);
        }

        #endregion
    }
    
    /// <summary>
    /// Graphic cursor properties class
    /// </summary>
    public class GraphCursorProperties
    {
    	#region Public members
    	
    	/// <summary>
    	/// Cursor mode
    	/// </summary>
    	public GraphicCursorMode Mode;
    	
    	/// <summary>
    	/// Cursor line style
    	/// </summary>
    	public GraphLineProperties Style;
    	
    	/// <summary>
    	/// Cursor value font
    	/// </summary>
    	public GW_Font CursorValueFont;
    	
    	/// <summary>
    	/// Cursor abscisse value displayed flag
    	/// </summary>
    	public bool ShowCursorAbscisseValue;
    	
    	/// <summary>
    	/// Abscisse value position on the cursor
    	/// </summary>
        public ScreenPositions AbscisseValuePostion;
    	
    	/// <summary>
    	/// Cursor ordinates values displayed flag
    	/// </summary>
    	public bool ShowCursorOrdinatesValue;
    	
    	/// <summary>
    	/// Ordinates values position on the cursor
    	/// </summary>
        public ScreenPositions OrdinateValuesPosition;
    	
    	/// <summary>
    	/// Cursor size
    	/// </summary>
    	/// <remarks>Used only for 'Graticule', 'Square' and 'Circle' modes</remarks>
    	public int CursorSize;
    	
    	#endregion
    	
    	/// <summary>
    	/// Default constructor
    	/// </summary>
    	public GraphCursorProperties()
    	{
    		Mode = GraphicCursorMode.Cross;
    		
    		Style = new GraphLineProperties();
    		Style.LineColor = Color.White;
    		Style.LineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
    		Style.LineWidth = 1;
    		Style.Visible = true;
    		
    		CursorValueFont = new GW_Font("Arial", 8, false, false, true, false, false);
    		
    		ShowCursorAbscisseValue = true;
            AbscisseValuePostion = ScreenPositions.Top;
    		
    		ShowCursorOrdinatesValue = true;
            OrdinateValuesPosition = ScreenPositions.Right;
    		
    		CursorSize = 2;
    	}
    	
    	#region Public methodes
    	
    	/// <summary>
    	/// Return a clone of the current object
    	/// </summary>
    	/// <returns>Clone of the current object</returns>
    	public GraphCursorProperties Get_Clone()
    	{
    		GraphCursorProperties oClone = new GraphCursorProperties();
    		
    		oClone.Mode = Mode;
    		oClone.Style =  Style.Get_Clone();
    		oClone.CursorValueFont =  CursorValueFont.Get_Clone();
    		oClone.ShowCursorAbscisseValue = ShowCursorAbscisseValue;
    		oClone.AbscisseValuePostion = AbscisseValuePostion;
    		oClone.ShowCursorOrdinatesValue = ShowCursorOrdinatesValue;
    		oClone.OrdinateValuesPosition = OrdinateValuesPosition;
    		oClone.CursorSize = CursorSize;
    		
    		return(oClone);
    	}
    	
    	/// <summary>
    	/// Return the XML node of the cursor properties
    	/// </summary>
    	/// <param name="oXDoc">XML document in which the cursor properties node will be created</param>
    	/// <param name="NodeName">Name of the XML node to create</param>
    	/// <returns>XML node of the cursor properties</returns>
    	public XmlElement Create_CursorXmlNode(XmlDocument oXDoc, string NodeName)
    	{
    		XmlElement xProp = null;
    		XmlElement xCursor = oXDoc.CreateElement(NodeName);
            
            	xProp = oXDoc.CreateElement("CusorMode");
            	xProp.InnerText = Mode.ToString();
            	xCursor.AppendChild(xProp);
            	
            	xProp = Style.Create_GraphLineXmlNode(oXDoc, "CursorStyle");
            	xCursor.AppendChild(xProp);
            	
            	xProp = CursorValueFont.Create_FontXmlNode(oXDoc, "CursorValueFont");
            	xCursor.AppendChild(xProp);
            	
            	xProp = oXDoc.CreateElement("CursorAbsValVisible");
            	xProp.InnerText = ShowCursorAbscisseValue.ToString();
            	xCursor.AppendChild(xProp);
            	
            	xProp = oXDoc.CreateElement("CursorAbsValPosition");
            	xProp.InnerText = AbscisseValuePostion.ToString();
            	xCursor.AppendChild(xProp);
            	
            	xProp = oXDoc.CreateElement("CursorOrdValVisible");
            	xProp.InnerText = ShowCursorOrdinatesValue.ToString();
            	xCursor.AppendChild(xProp);
            	
            	xProp = oXDoc.CreateElement("CursorOrdValPosition");
            	xProp.InnerText = OrdinateValuesPosition.ToString();
            	xCursor.AppendChild(xProp);
            	
            	xProp = oXDoc.CreateElement("CursorSize");
            	xProp.InnerText = CursorSize.ToString();
            	xCursor.AppendChild(xProp);
            	
        	return(xCursor);
    	}
    	
    	/// <summary>
        /// Read the XML node of the cursor properties
        /// </summary>
        /// <param name="xCursor">cursor properties XML node to read</param>
        /// <returns>Node reading error flag: True = No Error / False = Error</returns>
    	public bool Read_CursorXmlNode(XmlNode xCursor)
    	{
    		XmlNode xProp = null;
    		
    		try
    		{
    			xProp = xCursor.SelectSingleNode("CusorMode");
    			Mode = (GraphicCursorMode) Enum.Parse(typeof(GraphicCursorMode), xProp.InnerText);
    			
    			xProp = xCursor.SelectSingleNode("CursorStyle");
    			Style.Read_GraphLineXmlNode(xProp);
    			
    			xProp = xCursor.SelectSingleNode("CursorValueFont");
    			CursorValueFont.Read_FontXmlNode(xProp);
    			
    			xProp = xCursor.SelectSingleNode("CursorAbsValVisible");
    			ShowCursorAbscisseValue = bool.Parse(xProp.InnerText);
    			
    			xProp = xCursor.SelectSingleNode("CursorAbsValPosition");
                AbscisseValuePostion = (ScreenPositions)Enum.Parse(typeof(ScreenPositions), xProp.InnerText);
    			
    			xProp = xCursor.SelectSingleNode("CursorOrdValVisible");
    			ShowCursorOrdinatesValue = bool.Parse(xProp.InnerText);
    			
    			xProp = xCursor.SelectSingleNode("CursorOrdValPosition");
                OrdinateValuesPosition = (ScreenPositions)Enum.Parse(typeof(ScreenPositions), xProp.InnerText);
    			
    			xProp = xCursor.SelectSingleNode("CursorSize");
    			CursorSize = int.Parse(xProp.InnerText);
    		}
    		catch
    		{
    			return(false);
    		}
    		
    		return(true);
    	}
    	
    	#endregion
    }

    /// <summary>
    /// Graphic abscisse axis class
    /// </summary>
    public class GraphAbscisseAxis : GraphSerieAxis
    {
        #region Public members

        /// <summary>
        /// Abscisse time mode flag 
        /// </summary>
        public bool TimeMode;

        /// <summary>
        /// Abscisse data channel name if not in 'Abscisse time' mode 
        /// </summary>
        public string AbscisseChannelName;

        /// <summary>
        /// Abcisse reference lines collection
        /// </summary>
        public List<GraphReferenceLine> ReferenceLines;
        
        /// <summary>
        /// Abscisse sample data conversion to screen coordinates components
        /// </summary>
        public GW_SampleCoordConversion CoordConversion;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphAbscisseAxis()
        {
            TimeMode = true;
            AbscisseChannelName = "";
            ReferenceLines = new List<GraphReferenceLine>();
            CoordConversion = new GW_SampleCoordConversion();
        }

        #region Public methodes
        
        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public new GraphAbscisseAxis Get_Clone()
        {
            GraphAbscisseAxis oClone = new GraphAbscisseAxis();

            oClone.AbscisseChannelName = AbscisseChannelName;
            oClone.AxisLineStyle = AxisLineStyle.Get_Clone();
            oClone.AxisValuesFont = AxisValuesFont.Get_Clone();
            oClone.AxisValuesVisible = AxisValuesVisible;
            oClone.TimeMode = TimeMode;
            oClone.Visible = Visible;
            
            foreach(GraphReferenceLine oLine in ReferenceLines)
            {
                oClone.ReferenceLines.Add(oLine.Get_Clone());
            }

            return (oClone);
        }
        
        #endregion
    }

    /// <summary>
    /// Graphic legend properties class
    /// </summary>
    public class GraphLegendProperties
    {
        #region Public members

        /// <summary>
        /// Legend visibility flag
        /// </summary>
        public bool Visible;

        /// <summary>
        /// Legend items font
        /// </summary>
        public GW_Font LegendFont;

        /// <summary>
        /// Legend informations displayed
        /// </summary>
        public GraphicLegendInformations Informations;
        
        /// <summary>
        /// Legend header visisble flag
        /// </summary>
        public bool LegendHeaderVisible;
		
        /// <summary>
        /// Legend grid lines visible flag
        /// </summary>
        public bool LegendGridLinesVisible;
        
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphLegendProperties()
        {
            Visible = true;
            LegendFont = new GW_Font("Arial", 8, false, false, true, false, false);

            Informations=((GraphicLegendInformations)((GraphicLegendInformations.Label 
                                                    | GraphicLegendInformations.CurrentValue 
                                                    | GraphicLegendInformations.Unit)));
            
            LegendHeaderVisible = false;
            LegendGridLinesVisible = false;
        }

        #region Public methodes

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphLegendProperties Get_Clone()
        {
            GraphLegendProperties oClone = new GraphLegendProperties();

            oClone.Visible = Visible;
            oClone.LegendFont = LegendFont.Get_Clone();
            oClone.Informations = Informations;
            oClone.LegendHeaderVisible = LegendHeaderVisible;
            oClone.LegendGridLinesVisible = LegendGridLinesVisible;

            return (oClone);
        }

        #endregion
    }

    /// <summary>
    /// Graphic serie properties class
    /// </summary>
    public class GraphSerieProperties
    {
        #region Public members

        /// <summary>
        /// Serie identification key
        /// </summary>
        public int KeyId;

        /// <summary>
        /// Serie data source name
        /// </summary>
        public string Name;

        /// <summary>
        /// Serie label name in the graphic
        /// </summary>
        public string Label;

        /// <summary>
        /// Serie unit
        /// </summary>
        public string Unit;

        /// <summary>
        /// Serie visibility flag
        /// </summary>
        public bool Visible;

        /// <summary>
        /// Serie top position in percent of the total graph window heigth
        /// </summary>
        public int Top;

        /// <summary>
        /// Serie bottom position in percent of the total graph window heigth
        /// </summary>
        public int Bottom;

        /// <summary>
        /// Serie min scale value for 'Custom' scaling mode
        /// </summary>
        public double Min;

        /// <summary>
        /// Serie max scale value for 'Custom' scaling mode
        /// </summary>
        public double Max;

        /// <summary>
        /// Output format of the serie value
        /// </summary>
        public GraphSerieValueFormat ValueFormat;

        /// <summary>
        /// Serie scaling mode
        /// </summary>
        public GraphSerieScaleModes ScalingMode;

        /// <summary>
        /// Serie drawing mode
        /// </summary>
        public GraphSerieDrawingModes DrawingMode;

        /// <summary>
        /// Serie trace line graphic properties
        /// </summary>
        public GraphLineProperties Trace;

        /// <summary>
        /// Serie markers graphic properties
        /// </summary>
        public GraphSerieMarkProperties Markers;

        /// <summary>
        /// Serie Y axis graphic properties
        /// </summary>
        public GraphSerieAxis YAxis;

        /// <summary>
        /// Serie user grid properties
        /// </summary>
        public GraphSerieUserGrid UserGrid;

        /// <summary>
        /// Serie reference lines properties
        /// </summary>
        public List<GraphReferenceLine> ReferenceLines;
        
        /// <summary>
        /// Serie sample data conversion to screen coordinates components
        /// </summary>
        public GW_SampleCoordConversion CoordConversion;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphSerieProperties()
        {
            KeyId = -1; //OK
            Name = "";  //OK
            Label = "";
            Unit = "";
            Visible = true; //OK
            Top = 100; //OK
            Bottom = 0; //OK
            Min = 0; //OK
            Max = 0; //OK
            ValueFormat = new GraphSerieValueFormat();
            ScalingMode = GraphSerieScaleModes.Auto; //OK
            DrawingMode = GraphSerieDrawingModes.Line; //OK
            Trace = new GraphLineProperties(); //OK
            Markers = new GraphSerieMarkProperties(); //OK
            YAxis = new GraphSerieAxis(); //OK
            UserGrid = new GraphSerieUserGrid(); //OK
            ReferenceLines = new List<GraphReferenceLine>(); //OK
            CoordConversion = new GW_SampleCoordConversion();
        }

        #region Public methodes

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphSerieProperties Get_Clone()
        {
            GraphSerieProperties oClone = new GraphSerieProperties();

            oClone.KeyId = KeyId;
            oClone.Name = Name;
            oClone.Label = Label;
            oClone.Unit = Unit;
            oClone.Visible = Visible;
            oClone.Top = Top;
            oClone.Bottom = Bottom;
            oClone.Min = Min;
            oClone.Max = Max;
            oClone.ValueFormat = ValueFormat.Get_Clone();
            oClone.ScalingMode = ScalingMode;
            oClone.DrawingMode = DrawingMode;
            oClone.Trace = Trace.Get_Clone();
            oClone.Markers = Markers.Get_Clone();
            oClone.YAxis = YAxis.Get_Clone();
            oClone.UserGrid = UserGrid.Get_Clone();

            if (ReferenceLines.Count > 0)
            {
                foreach (GraphReferenceLine oLine in ReferenceLines)
                {
                    oClone.ReferenceLines.Add(oLine.Get_Clone());
                }
            }

            return (oClone);
        }
        
        #region Reference lines

        /// <summary>
        /// Return the GraphReferenceLine corresponding to the identification key given as argument
        /// </summary>
        /// <param name="iLineKey">Identification key of the reference line to retrieve</param>
        /// <returns>GraphReferenceLine corresponding to the identification key given as argument</returns>
        /// <remarks>Retun null if the GraphReferenceLine item is not found</remarks>
        public GraphReferenceLine Get_ReferenceLineAtKey(int iLineKey)
        {
            foreach (GraphReferenceLine oLine in ReferenceLines)
            {
                if (oLine.iKey == iLineKey)
                {
                    return (oLine);
                }
            }

            return (null);
        }

        #endregion

        #endregion
    }

    #endregion

    #endregion
    
    /// <summary>
    /// Graphic window properties class
    /// </summary>
    public class GraphWindowProperties
    {
    	#region Public members

        #region Saved members

        /// <summary>
        /// Graphic window back color
        /// </summary>
        public Color WindowBackColor;

        /// <summary>
        /// Graphic frame properties
        /// </summary>
        public GraphFrameProperties Frame;

        /// <summary>
        /// Graphic grids properties
        /// </summary>
        public GraphGridProperties Grid;

        /// <summary>
        /// Graphic abscisse axis properties
        /// </summary>
        public GraphAbscisseAxis AbscisseAxis;

        /// <summary>
        /// Graphic legend properties
        /// </summary>
        public GraphLegendProperties LegendProperties;
        
        /// <summary>
        /// Graphic cursor properties
        /// </summary>
        public GraphCursorProperties Cursor;
        
        /// <summary>
        /// Reference graphic cursor properties
        /// </summary>
        public GraphCursorProperties ReferenceCursor;

        /// <summary>
        /// Graphic window layout mode
        /// </summary>
        public GraphicWindowLayoutModes GraphLayoutMode;

        /// <summary>
        /// Graphic series graphical properties
        /// </summary>
        public List<GraphSerieProperties> SeriesProperties;

        /// <summary>
        /// Enabled flag of the graph sub-sampling feature
        /// </summary>
        public bool bSubSamplingEnabled;

        /// <summary>
        /// Max number of samples point drawn in the graphic sub sampling enabled
        /// </summary>
        public int nGraphicSampleMax;
        
        /// <summary>
        /// Allow the drawing of overscaled points (IE: Point Y = 105 for a Y max of 100)
        /// </summary>
        public bool bAllowOverScaling;

        #endregion

        #region Unsaved members

        /// <summary>
        /// Configuaration modified flag
        /// </summary>
        public bool bModified;

        /// <summary>
        /// Filepath of the graphic configuration
        /// </summary>
        public string FilePath;
        
        /// <summary>
        /// Graphic zoom mode
        /// </summary>
        public GraphicZoomMode ZoomMode;
        
        #endregion

        #endregion
        
        #region Private member
        
        int SerieColorIndex;
        int NextSerieKeyId;
        
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphWindowProperties()
        {	
        	//Member init
        	WindowBackColor = Color.Black; //OK
            Frame = new GraphFrameProperties(); //OK
            Grid = new GraphGridProperties(); //OK
            AbscisseAxis = new GraphAbscisseAxis();
            LegendProperties = new GraphLegendProperties();
            Cursor = new GraphCursorProperties();
            ReferenceCursor = new GraphCursorProperties();
            GraphLayoutMode = GraphicWindowLayoutModes.Overlay; //Overlay: / Paralel: / Custom:
            SeriesProperties = new List<GraphSerieProperties>();
            bSubSamplingEnabled = true; //OK
            nGraphicSampleMax = 1000; //OK
            bAllowOverScaling = false; //OK
			
            //Reference cursor init
            Init_ReferenceCursor();

            //Unsaved member init
            bModified = false;
            FilePath = "";
            ZoomMode = GraphicZoomMode.ZoomX;
            
            //Private member init
            SerieColorIndex = 0;
            NextSerieKeyId = 0;
        }

        #region Public methodes

        #region Properties files management     
        
        /// <summary>
        /// Save the graph window properties into a file
        /// </summary>
        /// <param name="fPath">Path of the file to create</param>
        public void Save_Properties(string fPath)
        {
            XmlDocument oPropDoc = new XmlDocument();
            
            XmlElement xGraphConfig = Create_PropertiesXmlNode(oPropDoc, "GraphWindowProperties");
            
            if (!(xGraphConfig == null))
            {
            	oPropDoc.AppendChild(xGraphConfig);
            	oPropDoc.Save(fPath);
            	FilePath = fPath;
            }
            
            //Create_PropertiesXmlNode(oPropDoc); //GraphWindowProperties
            //oPropDoc.Save(fPath);
            //FilePath = fPath;
        }

        /// <summary>
        /// Return the XML node of the current GraphWindowProperties object
        /// </summary>
        /// <param name="oXDoc">XML document in which the graph window properties will be created</param>
        /// <param name="NodeName">Name of the XML node to create</param>
        /// <returns>XML node of the current GraphWindowProperties object</returns>
        public XmlElement Create_PropertiesXmlNode(XmlDocument oXDoc, string NodeName)
        {
            if (!(oXDoc == null))
            {
                XmlElement xProp = null;
                
                //Graph window properties root node creation
                XmlElement xGraphProps = oXDoc.CreateElement(NodeName);
				
                /*
                if (!(oXDoc.HasChildNodes)) //Node creation for graph window properties file
                {
                    oXDoc.AppendChild(xGraphProps);
                }
                else //Graph window properties node is embedded into an another document
                {
                    oXDoc.FirstChild.AppendChild(xGraphProps);
                }
                */

                //Graph window back color
                XmlElement xBackColor = oXDoc.CreateElement("GraphBackColor");
                xBackColor.InnerText = WindowBackColor.ToArgb().ToString();
                xGraphProps.AppendChild(xBackColor);

                //Sub sampling
                XmlElement xSubSampling = oXDoc.CreateElement("SubSampling");
                xGraphProps.AppendChild(xSubSampling);

                    XmlAttribute xAtrSubSamplingEnabled = oXDoc.CreateAttribute("Enabled");
                    xAtrSubSamplingEnabled.Value = bSubSamplingEnabled.ToString();
                    xSubSampling.Attributes.Append(xAtrSubSamplingEnabled);

                    XmlElement xSampleMax = oXDoc.CreateElement("SampleMax");
                    xSampleMax.InnerText = nGraphicSampleMax.ToString();
                    xSubSampling.AppendChild(xSampleMax);

                //Graphic frame
                XmlElement xFrame = oXDoc.CreateElement("GraphicFrame");
                xGraphProps.AppendChild(xFrame);

                    XmlElement xFrameWidth = oXDoc.CreateElement("BorderWidth");
                    xFrameWidth.InnerText = Frame.BorderWidth.ToString();
                    xFrame.AppendChild(xFrameWidth);

                    XmlElement xFrameColor = oXDoc.CreateElement("BorderColor");
                    xFrameColor.InnerText = Frame.BorderColor.ToArgb().ToString();
                    xFrame.AppendChild(xFrameColor);

                //Grids
                XmlElement xGrids = oXDoc.CreateElement("GraphicGrids");
                xGraphProps.AppendChild(xGrids);

                    XmlElement xMHGrid = Grid.MainHorizontalGrid.Create_GraphLineXmlNode(oXDoc, "MainHorizontalGrid");
                    xGrids.AppendChild(xMHGrid);

                    XmlElement xMVGrid = Grid.MainVerticalGrid.Create_GraphLineXmlNode(oXDoc, "MainVerticalGrid");
                    xGrids.AppendChild(xMVGrid);

                    XmlElement xSHGrid = Grid.SecondaryHorizontalGrid.Create_GraphLineXmlNode(oXDoc, "SecondaryHorizontalGrid");
                    xGrids.AppendChild(xSHGrid);

                    XmlElement xSVGrid = Grid.SecondaryVerticalGrid.Create_GraphLineXmlNode(oXDoc, "SecondaryVerticalGrid");
                    xGrids.AppendChild(xSVGrid);
                
                //Graph layout mode
                XmlElement xLayoutMode = oXDoc.CreateElement("GraphicLayout");
                xLayoutMode.InnerText = GraphLayoutMode.ToString();
                xGraphProps.AppendChild(xLayoutMode);
                
                //OverScalling
                XmlElement  xOverScalling = oXDoc.CreateElement("OverScalingEnabled");
                xOverScalling.InnerText = bAllowOverScaling.ToString();
                xGraphProps.AppendChild(xOverScalling);

                //Abscisse axis
                XmlElement xAbscisseAxis = oXDoc.CreateElement("AbscisseAxis");
                xGraphProps.AppendChild(xAbscisseAxis);

                    xProp = oXDoc.CreateElement("TimeMode");
                    xProp.InnerText = AbscisseAxis.TimeMode.ToString();
                    xAbscisseAxis.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("AbscisseChannel");
                    xProp.InnerText = AbscisseAxis.AbscisseChannelName;
                    xAbscisseAxis.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("Visible");
                    xProp.InnerText = AbscisseAxis.Visible.ToString();
                    xAbscisseAxis.AppendChild(xProp);

                    XmlElement xAbscisseLine = AbscisseAxis.AxisLineStyle.Create_GraphLineXmlNode(oXDoc, "AbscisseLineStyle");
                    xAbscisseAxis.AppendChild(xAbscisseLine);

                    xProp = oXDoc.CreateElement("AbscisseValuesVisible");
                    xProp.InnerText = AbscisseAxis.AxisValuesVisible.ToString();
                    xAbscisseAxis.AppendChild(xProp);

                    XmlElement xAbscisseFont = AbscisseAxis.AxisValuesFont.Create_FontXmlNode(oXDoc, "AbscisseFont");
                    xAbscisseAxis.AppendChild(xAbscisseFont);

                    XmlElement xAbscisseRefLines = oXDoc.CreateElement("ReferenceLines");
                    xAbscisseAxis.AppendChild(xAbscisseRefLines);

                    foreach (GraphReferenceLine oLine in AbscisseAxis.ReferenceLines)
                    {
                        XmlElement xLine = oLine.Create_ReferenceLineXmlNode(oXDoc, "ReferenceLine");
                        xAbscisseRefLines.AppendChild(xLine);
                    }

                //Legend
                XmlElement xLegend = oXDoc.CreateElement("LegendProperties");
                xGraphProps.AppendChild(xLegend);

                    xProp = oXDoc.CreateElement("Visible");
                    xProp.InnerText = LegendProperties.Visible.ToString();
                    xLegend.AppendChild(xProp);

                    XmlElement xLegendFont = LegendProperties.LegendFont.Create_FontXmlNode(oXDoc, "LegendFont");
                    xLegend.AppendChild(xLegendFont);

                    xProp = oXDoc.CreateElement("Informations");
                    xProp.InnerText = Convert.ToInt16(LegendProperties.Informations).ToString();
                    xLegend.AppendChild(xProp);
                    
                    xProp = oXDoc.CreateElement("HeaderVisible");
                    xProp.InnerText = LegendProperties.LegendHeaderVisible.ToString();
                    xLegend.AppendChild(xProp);
                    
                    xProp = oXDoc.CreateElement("GridLinesVisible");
                    xProp.InnerText = LegendProperties.LegendHeaderVisible.ToString();
                    xLegend.AppendChild(xProp);
                
                //Cursor
                XmlElement xCursor = Cursor.Create_CursorXmlNode(oXDoc, "CursorProperties");
                xGraphProps.AppendChild(xCursor);
                
                //Reference cursor
                XmlElement xRefCursor = ReferenceCursor.Create_CursorXmlNode(oXDoc, "ReferenceCursorProperties");
                xGraphProps.AppendChild(xRefCursor);
                	
                //Series
                XmlElement xSeriesProps = oXDoc.CreateElement("SeriesGraphicalProperties");
                xGraphProps.AppendChild(xSeriesProps);

                foreach (GraphSerieProperties oSerie in SeriesProperties)
                {
                    XmlElement xSerie = oXDoc.CreateElement("SerieProperties");
                    xSeriesProps.AppendChild(xSerie);

                    //Identification Key
                    XmlAttribute xAtrSerieKey = oXDoc.CreateAttribute("KeyId");
                    xAtrSerieKey.Value = oSerie.KeyId.ToString();
                    xSerie.Attributes.Append(xAtrSerieKey);

                    //General properties
                    xProp = oXDoc.CreateElement("Name");
                    xProp.InnerText = oSerie.Name;
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("Label");
                    xProp.InnerText = oSerie.Label;
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("Unit");
                    xProp.InnerText = oSerie.Unit;
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("Visible");
                    xProp.InnerText = oSerie.Visible.ToString();
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("Top");
                    xProp.InnerText = oSerie.Top.ToString();
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("Bottom");
                    xProp.InnerText = oSerie.Bottom.ToString();
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("Min");
                    xProp.InnerText = oSerie.Min.ToString();
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("Max");
                    xProp.InnerText = oSerie.Max.ToString();
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("ScalingMode");
                    xProp.InnerText = oSerie.ScalingMode.ToString();
                    xSerie.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("DrawingMode");
                    xProp.InnerText = oSerie.DrawingMode.ToString();
                    xSerie.AppendChild(xProp);

                    //Value format
                    XmlElement xFormat = oXDoc.CreateElement("ValueFormat");
                    xSerie.AppendChild(xFormat);

                        xProp = oXDoc.CreateElement("Format");
                        xProp.InnerText = oSerie.ValueFormat.Format.ToString();
                        xFormat.AppendChild(xProp);

                        xProp = oXDoc.CreateElement("Decimals");
                        xProp.InnerText = oSerie.ValueFormat.Decimals.ToString();
                        xFormat.AppendChild(xProp);

                        XmlElement xEnums = oXDoc.CreateElement("Enumerations");
                        xFormat.AppendChild(xEnums);

                        foreach (GraphSerieEnumValue sEnum in oSerie.ValueFormat.Enums)
                        {
                            XmlElement xEnumDef = oXDoc.CreateElement("Enum");
                            xEnums.AppendChild(xEnumDef);

                                xProp = oXDoc.CreateElement("Value");
                                xProp.InnerText = sEnum.Value.ToString();
                                xEnumDef.AppendChild(xProp);

                                xProp = oXDoc.CreateElement("Text");
                                xProp.InnerText = sEnum.Text;
                                xEnumDef.AppendChild(xProp);
                        }

                    //Trace line
                    XmlElement xTrace = oSerie.Trace.Create_GraphLineXmlNode(oXDoc, "Trace");
                    xSerie.AppendChild(xTrace);

                    //Markers
                    XmlElement xMarker = oXDoc.CreateElement("Markers");
                    xSerie.AppendChild(xMarker);

                        xProp = oXDoc.CreateElement("Visible");
                        xProp.InnerText = oSerie.Markers.Visible.ToString();
                        xMarker.AppendChild(xProp);

                        xProp = oXDoc.CreateElement("Style");
                        xProp.InnerText = oSerie.Markers.Style.ToString();
                        xMarker.AppendChild(xProp);

                        xProp = oXDoc.CreateElement("Size");
                        xProp.InnerText = oSerie.Markers.Size.ToString();
                        xMarker.AppendChild(xProp);

                        xProp = oXDoc.CreateElement("InteriorEmpty");
                        xProp.InnerText = oSerie.Markers.InteriorEmpty.ToString();
                        xMarker.AppendChild(xProp);

                        xProp = oXDoc.CreateElement("MarkColor");
                        xProp.InnerText = oSerie.Markers.MarkColor.ToArgb().ToString();
                        xMarker.AppendChild(xProp);

                    //YAxis
                    XmlElement xAxis = oXDoc.CreateElement("YAxis");
                    xSerie.AppendChild(xAxis);

                        xProp = oXDoc.CreateElement("Visible");
                        xProp.InnerText = oSerie.YAxis.Visible.ToString();
                        xAxis.AppendChild(xProp);

                        XmlElement xAxisLine = oSerie.YAxis.AxisLineStyle.Create_GraphLineXmlNode(oXDoc, "AxisLineStyle");
                        xAxis.AppendChild(xAxisLine);

                        xProp = oXDoc.CreateElement("AxisValuesVisible");
                        xProp.InnerText = oSerie.YAxis.AxisValuesVisible.ToString();
                        xAxis.AppendChild(xProp);
                        
                        xProp = oXDoc.CreateElement("AxisTitleVisible");
                        xProp.InnerText = oSerie.YAxis.AxisTitleVisible.ToString();
                        xAxis.AppendChild(xProp);

                        XmlElement xAxisFont = oSerie.YAxis.AxisValuesFont.Create_FontXmlNode(oXDoc, "AxisFont");
                        xAxis.AppendChild(xAxisFont);

                    //User grid
                    XmlElement xGridLineStyle = null;
                    XmlElement xGridValues = null;


                    XmlElement xUserGrid = oXDoc.CreateElement("SerieUserGrid");
                    xSerie.AppendChild(xUserGrid);

                        xProp = oXDoc.CreateElement("Visible");
                        xProp.InnerText = oSerie.UserGrid.Visible.ToString();
                        xUserGrid.AppendChild(xProp);

                        //Vertical user grid
                        XmlElement xVGrid = oXDoc.CreateElement("VerticalUserGrid");
                        xUserGrid.AppendChild(xVGrid);

                            xProp = oXDoc.CreateElement("GridMode");
                            xProp.InnerText = oSerie.UserGrid.VerticalGridMode.ToString();
                            xVGrid.AppendChild(xProp);

                            xGridLineStyle = oSerie.UserGrid.VerticalLinesStyle.Create_GraphLineXmlNode(oXDoc, "GridStyle");
                            xVGrid.AppendChild(xGridLineStyle);

                            xProp = oXDoc.CreateElement("GridDivisionCount");
                            xProp.InnerText = oSerie.UserGrid.VerticalDivisionCount.ToString();
                            xVGrid.AppendChild(xProp);

                            xGridValues = oXDoc.CreateElement("GridCustomValues");
                            xVGrid.AppendChild(xGridValues);

                            foreach(double Val in oSerie.UserGrid.VerticalCustomValues)
                            {
                                xProp = oXDoc.CreateElement("CustomValue");
                                xProp.InnerText = Val.ToString();
                                xGridValues.AppendChild(xProp);
                            }

                            xProp = oXDoc.CreateElement("GridValuesVisible");
                            xProp.InnerText = oSerie.UserGrid.VerticalGridValuesVisible.ToString();
                            xVGrid.AppendChild(xProp);

                            XmlElement xVertGridFont = oSerie.UserGrid.VerticalGridValueFont.Create_FontXmlNode(oXDoc, "GridFont");
                            xVGrid.AppendChild(xVertGridFont);

                        //Horizontal user grid
                        XmlElement xHGrid = oXDoc.CreateElement("HorizontalUserGrid");
                        xUserGrid.AppendChild(xHGrid);

                            xProp = oXDoc.CreateElement("GridMode");
                            xProp.InnerText = oSerie.UserGrid.HorizontalGridMode.ToString();
                            xHGrid.AppendChild(xProp);

                            xGridLineStyle = oSerie.UserGrid.HorizontalLinesStyle.Create_GraphLineXmlNode(oXDoc, "GridStyle");
                            xHGrid.AppendChild(xGridLineStyle);

                            xProp = oXDoc.CreateElement("GridDivisionCount");
                            xProp.InnerText = oSerie.UserGrid.HorizontalDivisionCount.ToString();
                            xHGrid.AppendChild(xProp);

                            xGridValues = oXDoc.CreateElement("GridCustomValues");
                            xHGrid.AppendChild(xGridValues);

                            foreach (double Val in oSerie.UserGrid.HorizontalCustomValues)
                            {
                                xProp = oXDoc.CreateElement("CustomValue");
                                xProp.InnerText = Val.ToString();
                                xGridValues.AppendChild(xProp);
                            }

                            xProp = oXDoc.CreateElement("GridValuesVisible");
                            xProp.InnerText = oSerie.UserGrid.HorizontalGridValuesVisible.ToString();
                            xHGrid.AppendChild(xProp);

                            XmlElement xHorzGridFont = oSerie.UserGrid.HorizontalGridValueFont.Create_FontXmlNode(oXDoc, "GridFont");
                            xHGrid.AppendChild(xHorzGridFont);

                    //Reference lines
                    XmlElement xRefLines = oXDoc.CreateElement("SerieReferenceLines");
                    xSerie.AppendChild(xRefLines);

                    foreach (GraphReferenceLine oRefLine in oSerie.ReferenceLines)
                    {
                        XmlElement xLine = oRefLine.Create_ReferenceLineXmlNode(oXDoc, "ReferenceLine");
                        xRefLines.AppendChild(xLine);
                    }
                }

                bModified = false;
                return(xGraphProps);
            }
            
            return(null);
        }

        /// <summary>
        /// Read a graph window properties file
        /// </summary>
        /// <param name="fPath">Path of the file to read</param>
        /// <returns>File reading error flag: True = No Error / False = Error</returns>
        public bool Open_Properties(string fPath)
        {
            XmlDocument oXDoc = new XmlDocument();
            oXDoc.Load(fPath);
            FilePath = fPath;
            return (Read_PropertiesXmlNode(oXDoc.FirstChild));
        }

        /// <summary>
        /// Read a graph window properties XML node
        /// </summary>
        /// <param name="xGraphProps">XML node to read</param>
        /// <returns>Node reading error flag: True = No Error / False = Error</returns>
        public bool Read_PropertiesXmlNode(XmlNode xGraphProps)
        {
            if (!(xGraphProps.Name.Equals("GraphWindowProperties")))
            {
                return (false);
            }

            try
            {
                XmlNode xProp = null;

                //Graph window back color
                XmlNode xBackColor = xGraphProps.SelectSingleNode("GraphBackColor");
                WindowBackColor = Color.FromArgb(int.Parse(xBackColor.InnerText));

                //Sub sampling
                XmlNode xSubSampling = xGraphProps.SelectSingleNode("SubSampling");

                    bSubSamplingEnabled = bool.Parse(xSubSampling.Attributes["Enabled"].Value);

                    XmlNode xSampleMax = xSubSampling.SelectSingleNode("SampleMax");
                    nGraphicSampleMax = int.Parse(xSampleMax.InnerText);

                //Frame
                XmlNode xFrame = xGraphProps.SelectSingleNode("GraphicFrame");

                    XmlNode xFrameWidth = xFrame.SelectSingleNode("BorderWidth");
                    Frame.BorderWidth = int.Parse(xFrameWidth.InnerText);

                    XmlNode xFrameColor = xFrame.SelectSingleNode("BorderColor");
                    Frame.BorderColor = Color.FromArgb(int.Parse(xFrameColor.InnerText));

                //Grids
                XmlNode xGrids = xGraphProps.SelectSingleNode("GraphicGrids");

                    XmlNode xMHGrid = xGrids.SelectSingleNode("MainHorizontalGrid");
                    Grid.MainHorizontalGrid.Read_GraphLineXmlNode(xMHGrid);

                    XmlNode xMVGrid = xGrids.SelectSingleNode("MainVerticalGrid");
                    Grid.MainVerticalGrid.Read_GraphLineXmlNode(xMVGrid);

                    XmlNode xSHGrid = xGrids.SelectSingleNode("SecondaryHorizontalGrid");
                    Grid.SecondaryHorizontalGrid.Read_GraphLineXmlNode(xSHGrid);

                    XmlNode xSVGrid = xGrids.SelectSingleNode("SecondaryVerticalGrid");
                    Grid.SecondaryVerticalGrid.Read_GraphLineXmlNode(xSVGrid);

                //Graph layout mode
                XmlNode xLayoutMode = xGraphProps.SelectSingleNode("GraphicLayout");
                GraphLayoutMode = (GraphicWindowLayoutModes)Enum.Parse(typeof(GraphicWindowLayoutModes), xLayoutMode.InnerText);
				
                //OverScalling
                XmlNode xOverScalling = xGraphProps.SelectSingleNode("OverScalingEnabled");
                bAllowOverScaling = bool.Parse(xOverScalling.InnerText);
                
                //Abscisse axis
                XmlNode xAbscisseAxis = xGraphProps.SelectSingleNode("AbscisseAxis");

                    xProp = xAbscisseAxis.SelectSingleNode("TimeMode");
                    AbscisseAxis.TimeMode = bool.Parse(xProp.InnerText);

                    xProp = xAbscisseAxis.SelectSingleNode("AbscisseChannel");
                    AbscisseAxis.AbscisseChannelName = xProp.InnerText;

                    xProp = xAbscisseAxis.SelectSingleNode("Visible");
                    AbscisseAxis.Visible = bool.Parse(xProp.InnerText);

                    XmlNode xAbscisseLine = xAbscisseAxis.SelectSingleNode("AbscisseLineStyle");
                    AbscisseAxis.AxisLineStyle.Read_GraphLineXmlNode(xAbscisseLine);

                    xProp = xAbscisseAxis.SelectSingleNode("AbscisseValuesVisible");
                    AbscisseAxis.AxisValuesVisible = bool.Parse(xProp.InnerText);

                    XmlNode xAbscisseFont = xAbscisseAxis.SelectSingleNode("AbscisseFont");
                    AbscisseAxis.AxisValuesFont.Read_FontXmlNode(xAbscisseFont);

                    XmlNode xAbscisseRefLines = xAbscisseAxis.SelectSingleNode("ReferenceLines");
                    AbscisseAxis.ReferenceLines = new List<GraphReferenceLine>();

                    foreach (XmlNode xRefLine in xAbscisseRefLines.ChildNodes)
                    {
                        GraphReferenceLine oRefLine = new GraphReferenceLine();
                        oRefLine.Read_GraphLineXmlNode(xRefLine);
                        AbscisseAxis.ReferenceLines.Add(oRefLine);
                    }

                //Legend
                XmlNode xLegend = xGraphProps.SelectSingleNode("LegendProperties");

                    xProp = xLegend.SelectSingleNode("Visible");
                    LegendProperties.Visible = bool.Parse(xProp.InnerText);

                    XmlNode xLegendFont = xLegend.SelectSingleNode("LegendFont");
                    LegendProperties.LegendFont.Read_FontXmlNode(xLegendFont);

                    xProp = xLegend.SelectSingleNode("Informations");
                    LegendProperties.Informations = (GraphicLegendInformations)Enum.ToObject(typeof(GraphicLegendInformations), int.Parse(xProp.InnerText));
                    
                    xProp = xLegend.SelectSingleNode("HeaderVisible");
                    LegendProperties.LegendHeaderVisible = bool.Parse(xProp.InnerText);
                    
                    xProp = xLegend.SelectSingleNode("GridLinesVisible");
                    LegendProperties.LegendGridLinesVisible = bool.Parse(xProp.InnerText);
                 
                //Cursor
                XmlNode xCursor = xGraphProps.SelectSingleNode("CursorProperties");
                Cursor.Read_CursorXmlNode(xCursor);
                
                //Reference cursor
                XmlNode xRefCursor = xGraphProps.SelectSingleNode("ReferenceCursorProperties");
                ReferenceCursor.Read_CursorXmlNode(xRefCursor);
                	
                //Series
                XmlNode xSeriesProps = xGraphProps.SelectSingleNode("SeriesGraphicalProperties");
                SeriesProperties.Clear();

                foreach(XmlNode xSerie in xSeriesProps.ChildNodes)
                {
                    GraphSerieProperties oSerie = new GraphSerieProperties();

                    //Identification Key
                    oSerie.KeyId = int.Parse(xSerie.Attributes["KeyId"].Value);
                    
                    if (oSerie.KeyId >= NextSerieKeyId) NextSerieKeyId = oSerie.KeyId + 1;
                    
                    SerieColorIndex++;
                    if (SerieColorIndex > 15) SerieColorIndex = 0;
                    
                    //General properties
                    xProp = xSerie.SelectSingleNode("Name");
                    oSerie.Name = xProp.InnerText;

                    xProp = xSerie.SelectSingleNode("Label");
                    oSerie.Label = xProp.InnerText;

                    xProp = xSerie.SelectSingleNode("Unit");
                    oSerie.Unit = xProp.InnerText;

                    xProp = xSerie.SelectSingleNode("Visible");
                    oSerie.Visible = bool.Parse(xProp.InnerText);

                    xProp = xSerie.SelectSingleNode("Top");
                    oSerie.Top = int.Parse(xProp.InnerText);

                    xProp = xSerie.SelectSingleNode("Bottom");
                    oSerie.Bottom = int.Parse(xProp.InnerText);

                    xProp = xSerie.SelectSingleNode("Min");
                    oSerie.Min = double.Parse(xProp.InnerText);

                    xProp = xSerie.SelectSingleNode("Max");
                    oSerie.Max = double.Parse(xProp.InnerText);

                    xProp = xSerie.SelectSingleNode("ScalingMode");
                    oSerie.ScalingMode = (GraphSerieScaleModes)Enum.Parse(typeof(GraphSerieScaleModes), xProp.InnerText);

                    xProp = xSerie.SelectSingleNode("DrawingMode");
                    oSerie.DrawingMode = (GraphSerieDrawingModes)Enum.Parse(typeof(GraphSerieDrawingModes), xProp.InnerText);

                    //Value format
                    XmlNode xFormat = xSerie.SelectSingleNode("ValueFormat");

                        xProp = xFormat.SelectSingleNode("Format");
                        oSerie.ValueFormat.Format = (GraphSerieLegendFormats)Enum.Parse(typeof(GraphSerieLegendFormats), xProp.InnerText);

                        xProp = xFormat.SelectSingleNode("Decimals");
                        oSerie.ValueFormat.Decimals = int.Parse(xProp.InnerText);

                        XmlNode xEnums = xFormat.SelectSingleNode("Enumerations");
                        oSerie.ValueFormat.Enums = new List<GraphSerieEnumValue>();

                        foreach (XmlNode xEnumDef in xEnums.ChildNodes)
                        {
                            GraphSerieEnumValue sEnum = new GraphSerieEnumValue();

                            xProp = xEnumDef.SelectSingleNode("Value");
                            sEnum.Value = int.Parse(xProp.InnerText);

                            xProp = xEnumDef.SelectSingleNode("Text");
                            sEnum.Text = xProp.InnerText;

                            oSerie.ValueFormat.Enums.Add(sEnum);
                        }

                    //Trace line
                    XmlNode xTrace = xSerie.SelectSingleNode("Trace");
                    oSerie.Trace.Read_GraphLineXmlNode(xTrace);

                    //Markers
                    XmlNode xMarker = xSerie.SelectSingleNode("Markers");

                        xProp = xMarker.SelectSingleNode("Visible");
                        oSerie.Markers.Visible = bool.Parse(xProp.InnerText);

                        xProp = xMarker.SelectSingleNode("Style");
                        oSerie.Markers.Style = (GraphSerieMarkerStyles)Enum.Parse(typeof(GraphSerieMarkerStyles), xProp.InnerText);

                        xProp = xMarker.SelectSingleNode("Size");
                        oSerie.Markers.Size = int.Parse(xProp.InnerText);

                        xProp = xMarker.SelectSingleNode("InteriorEmpty");
                        oSerie.Markers.InteriorEmpty = bool.Parse(xProp.InnerText);

                        xProp = xMarker.SelectSingleNode("MarkColor");
                        oSerie.Markers.MarkColor = Color.FromArgb(int.Parse(xProp.InnerText));

                    //YAxis
                    XmlNode xAxis = xSerie.SelectSingleNode("YAxis");

                        xProp = xAxis.SelectSingleNode("Visible");
                        oSerie.YAxis.Visible = bool.Parse(xProp.InnerText);

                        XmlNode xAxisLine = xAxis.SelectSingleNode("AxisLineStyle");
                        oSerie.YAxis.AxisLineStyle.Read_GraphLineXmlNode(xAxisLine);

                        xProp = xAxis.SelectSingleNode("AxisValuesVisible");
                        oSerie.YAxis.AxisValuesVisible = bool.Parse(xProp.InnerText);
                        
                        xProp = xAxis.SelectSingleNode("AxisTitleVisible");
                        oSerie.YAxis.AxisTitleVisible = bool.Parse(xProp.InnerText);

                        XmlNode xAxisFont = xAxis.SelectSingleNode("AxisFont");
                        oSerie.YAxis.AxisValuesFont.Read_FontXmlNode(xAxisFont);

                    //User grid
                    XmlNode xGridLineStyle = null;
                    XmlNode xGridValues = null;

                    XmlNode xUserGrid = xSerie.SelectSingleNode("SerieUserGrid");

                        xProp = xUserGrid.SelectSingleNode("Visible");
                        oSerie.UserGrid.Visible = bool.Parse(xProp.InnerText);

                        //Vertical user grid
                        XmlNode xVGrid = xUserGrid.SelectSingleNode("VerticalUserGrid");

                            xProp = xVGrid.SelectSingleNode("GridMode");
                            oSerie.UserGrid.VerticalGridMode = (GraphSerieUserGridModes)Enum.Parse(typeof(GraphSerieUserGridModes), xProp.InnerText);

                            xGridLineStyle = xVGrid.SelectSingleNode("GridStyle");
                            oSerie.UserGrid.VerticalLinesStyle.Read_GraphLineXmlNode(xGridLineStyle);

                            xProp = xVGrid.SelectSingleNode("GridDivisionCount");
                            oSerie.UserGrid.VerticalDivisionCount = int.Parse(xProp.InnerText);

                            xGridValues = xVGrid.SelectSingleNode("GridCustomValues");
                            oSerie.UserGrid.VerticalCustomValues = new List<double>();

                            foreach(XmlNode xVal in xGridValues.ChildNodes)
                            {
                                oSerie.UserGrid.VerticalCustomValues.Add(double.Parse(xVal.InnerText));
                            }

                            xProp = xVGrid.SelectSingleNode("GridValuesVisible");
                            oSerie.UserGrid.VerticalGridValuesVisible = bool.Parse(xProp.InnerText);

                            XmlNode xVertGridFont = xAxis.SelectSingleNode("GridFont");
                            oSerie.UserGrid.VerticalGridValueFont.Read_FontXmlNode(xVertGridFont);

                        //Horizontal user grid
                        XmlNode xHGrid = xUserGrid.SelectSingleNode("HorizontalUserGrid");

                            xProp = xHGrid.SelectSingleNode("GridMode");
                            oSerie.UserGrid.HorizontalGridMode = (GraphSerieUserGridModes)Enum.Parse(typeof(GraphSerieUserGridModes), xProp.InnerText);

                            xGridLineStyle = xHGrid.SelectSingleNode("GridStyle");
                            oSerie.UserGrid.HorizontalLinesStyle.Read_GraphLineXmlNode(xGridLineStyle);

                            xProp = xHGrid.SelectSingleNode("GridDivisionCount");
                            oSerie.UserGrid.HorizontalDivisionCount = int.Parse(xProp.InnerText);

                            xGridValues = xHGrid.SelectSingleNode("GridCustomValues");
                            oSerie.UserGrid.HorizontalCustomValues = new List<double>();

                            foreach (XmlNode xVal in xGridValues.ChildNodes)
                            {
                                oSerie.UserGrid.HorizontalCustomValues.Add(double.Parse(xVal.InnerText));
                            }

                            xProp = xHGrid.SelectSingleNode("GridValuesVisible");
                            oSerie.UserGrid.HorizontalGridValuesVisible = bool.Parse(xProp.InnerText);

                            XmlNode xHorzGridFont = xAxis.SelectSingleNode("GridFont");
                            oSerie.UserGrid.HorizontalGridValueFont.Read_FontXmlNode(xHorzGridFont);

                        //Reference lines
                        XmlNode xRefLines = xSerie.SelectSingleNode("SerieReferenceLines");
                        oSerie.ReferenceLines = new List<GraphReferenceLine>();

                        foreach (XmlNode xLine in xRefLines.ChildNodes)
                        {
                            GraphReferenceLine oRefLine = new GraphReferenceLine();
                            oRefLine.Read_GraphLineXmlNode(xLine);
                            oSerie.ReferenceLines.Add(oRefLine);
                        }

                    SeriesProperties.Add(oSerie);
                }

                bModified = false;
                return (true);
            }
            catch
            {
                return (false);
            }
        }

        #endregion

        #region SeriesProperties management

        /// <summary>
        /// Return the GraphSerieProperties item corresponding to the identification key given as argument
        /// </summary>
        /// <param name="iKey">Identification key of the serie to retrieve</param>
        /// <returns>GraphSerieProperties item corresponding to the identification key given as argument</returns>
        /// <remarks>Retun null if the GraphSerieProperties item is not found</remarks>
        public GraphSerieProperties Get_SerieAtKey(int iKey)
        {
            foreach (GraphSerieProperties oSerie in SeriesProperties)
            {
                if(oSerie.KeyId==iKey)
                {
                    return (oSerie);
                }
            }

            return (null);
        }

        /// <summary>
        /// Remove the GraphSerieProperties item corresponding to the identification key given as argument
        /// </summary>
        /// <param name="iKey">Identification key of the serie to remove</param>
        public void Remove_SerieAtKey(int iKey)
        {
            GraphSerieProperties oSerie = Get_SerieAtKey(iKey);

            if (!(oSerie == null))
            {
                SeriesProperties.Remove(oSerie);
            }
        }

        /// <summary>
        /// Return a clone of the GraphSerieProperties item corresponding to the identifaction key given as argument
        /// </summary>
        /// <param name="iKey">Identification key of the item to clone</param>
        /// <returns>Clone of the GraphSerieProperties item corresponding to the identifaction key given as argument</returns>
        /// <remarks>Return null if the item to clone is not found</remarks>
        public GraphSerieProperties Clone_Serie(int iKey)
        {
            GraphSerieProperties oSerie = Get_SerieAtKey(iKey);

            if(!(oSerie==null))
            {
                return (oSerie.Get_Clone());
            }
            else
            {
                return (null);
            }
        }

        /// <summary>
        /// Move the GraphSerieProperties item corresponding to the identification key given as argument into the collection in the direction given as argument
        /// </summary>
        /// <param name="iKey">Identification key of the serie to move</param>
        /// <param name="Direction">Item moving direction: "Up" = Moving up / "Down" = Moving down</param>
        public void Move_Serie(int iKey, string Direction)
        {
            GraphSerieProperties oSerie = Get_SerieAtKey(iKey);

            if(!(oSerie==null))
            {
                int NewIndex = SeriesProperties.IndexOf(oSerie);

                if (Direction.Equals("Up") && (!(NewIndex == 0)))
                {
                    NewIndex--;
                }
                else if (Direction.Equals("Down") && (!(NewIndex == SeriesProperties.Count - 1)))
                {
                    NewIndex += 2;
                }

                if(!(NewIndex==SeriesProperties.IndexOf(oSerie)))
                {
                    SeriesProperties.Insert(NewIndex, oSerie.Get_Clone());
                    SeriesProperties.Remove(oSerie);
                }
            }
        }
        
        /// <summary>
        /// Create a new serie into the serie collection
        /// </summary>
        /// <param name="SerieName">Name of the serie to be created</param>
        public void Create_Serie(string SerieName)
        {
        	GraphSerieProperties oSerie = new GraphSerieProperties();

            oSerie.KeyId = NextSerieKeyId;
            NextSerieKeyId++;

            oSerie.Name = SerieName;
            oSerie.Label = SerieName;
            
            Color SerieColor = GetDefaultSerieColor();

            oSerie.Trace.LineColor = SerieColor;
            oSerie.Markers.MarkColor = SerieColor;
            oSerie.UserGrid.HorizontalLinesStyle.LineColor = SerieColor;
            oSerie.UserGrid.VerticalLinesStyle.LineColor = SerieColor;
            oSerie.YAxis.AxisLineStyle.LineColor = SerieColor;

            SeriesProperties.Add(oSerie);
        }
		
        /// <summary>
        /// Return the current value of NextSerieKeyId
        /// </summary>
        /// <returns>Current value of NextSerieKeyId</returns>
        public int Get_NextSerieKeyId()
        {
        	return(NextSerieKeyId);
        }
        
        /// <summary>
        /// Increase by 1 the value of NextSerieKeyId
        /// </summary>
        public void Increase_NextSerieKeyId()
        {
        	NextSerieKeyId++;
        }
        
        #endregion

        #region Misc

        /// <summary>
        /// Return a clone of the current object
        /// </summary>
        /// <returns>Clone of the current object</returns>
        public GraphWindowProperties Get_Clone()
        {
            GraphWindowProperties oClone = new GraphWindowProperties();

            oClone.WindowBackColor = WindowBackColor;
            oClone.Frame = Frame.Get_Clone();
            oClone.Grid = Grid.Get_Clone();
            oClone.AbscisseAxis = AbscisseAxis.Get_Clone();
            oClone.LegendProperties = LegendProperties.Get_Clone();
            oClone.Cursor = Cursor.Get_Clone();
            oClone.ReferenceCursor = ReferenceCursor.Get_Clone();
            oClone.GraphLayoutMode = GraphLayoutMode;
            oClone.bSubSamplingEnabled = bSubSamplingEnabled;
            oClone.nGraphicSampleMax = nGraphicSampleMax;
            oClone.bAllowOverScaling = bAllowOverScaling;

            foreach (GraphSerieProperties oSerie in SeriesProperties)
            {
                oClone.SeriesProperties.Add(oSerie.Get_Clone());
            }

            return (oClone);
        }

        #endregion

        #endregion
        
        #region private methodes
        
        private void Init_ReferenceCursor()
        {
        	ReferenceCursor.Mode = GraphicCursorMode.VerticalLine;
        	ReferenceCursor.ShowCursorAbscisseValue =  true;
        	ReferenceCursor.Style.LineColor = Color.Cyan;
        	ReferenceCursor.Style.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        	ReferenceCursor.Style.LineWidth = 2;
        	ReferenceCursor.CursorValueFont = new GW_Font("Arial", 10, false, true, true, false, false);
        }

        /// <summary>
        /// Return a default line color for a graph serie
        /// </summary>
        /// <returns>Default line color for a graph serie</returns>
        private Color GetDefaultSerieColor()
        {
            Color SerieColor = Color.Empty;

            int BackColorIndex = -1;
            if (WindowBackColor.Equals(Color.Black))
            {
                BackColorIndex = 0;
            }
            else if (WindowBackColor.Equals(Color.White))
            {
                BackColorIndex = 1;
            }


            switch (SerieColorIndex)
            {
                case 0:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.Red;
                            break;
                        case 1: //White
                            SerieColor = Color.Red;
                            break;
                        default: //Other
                            SerieColor = Color.Red;
                            break;
                    }

                    break;

                case 1:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.Yellow;
                            break;
                        case 1: //White
                            SerieColor = Color.Goldenrod;
                            break;
                        default: //Other
                            SerieColor = Color.Orange;
                            break;
                    }

                    break;

                case 2:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.Lime;
                            break;
                        case 1: //White
                            SerieColor = Color.Green;
                            break;
                        default: //Other
                            SerieColor = Color.GreenYellow;
                            break;
                    }

                    break;

                case 3:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.Cyan;
                            break;
                        case 1: //White
                            SerieColor = Color.Blue;
                            break;
                        default: //Other
                            SerieColor = Color.DarkBlue;
                            break;
                    }

                    break;

                case 4:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.Magenta;
                            break;
                        case 1: //White
                            SerieColor = Color.Purple;
                            break;
                        default: //Other
                            SerieColor = Color.Indigo;
                            break;
                    }

                    break;

                case 5:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.Orange;
                            break;
                        case 1: //White
                            SerieColor = Color.DarkOrange;
                            break;
                        default: //Other
                            SerieColor = Color.DarkGoldenrod;
                            break;
                    }

                    break;

                case 6:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.LimeGreen;
                            break;
                        case 1: //White
                            SerieColor = Color.OliveDrab;
                            break;
                        default: //Other
                            SerieColor = Color.GreenYellow;
                            break;
                    }

                    break;

                case 7:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.DeepSkyBlue;
                            break;
                        case 1: //White
                            SerieColor = Color.MidnightBlue;
                            break;
                        default: //Other
                            SerieColor = Color.RoyalBlue;
                            break;
                    }

                    break;

                case 8:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.Magenta;
                            break;
                        case 1: //White
                            SerieColor = Color.Crimson;
                            break;
                        default: //Other
                            SerieColor = Color.Fuchsia;
                            break;
                    }

                    break;

                case 9:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.LemonChiffon;
                            break;
                        case 1: //White
                            SerieColor = Color.DarkOrange;
                            break;
                        default: //Other
                            SerieColor = Color.Yellow;
                            break;
                    }

                    break;

                case 10:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.MediumSpringGreen;
                            break;
                        case 1: //White
                            SerieColor = Color.MediumSeaGreen;
                            break;
                        default: //Other
                            SerieColor = Color.ForestGreen;
                            break;
                    }

                    break;

                case 11:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.SkyBlue;
                            break;
                        case 1: //White
                            SerieColor = Color.DodgerBlue;
                            break;
                        default: //Other
                            SerieColor = Color.SteelBlue;
                            break;
                    }


                    break;

                case 12:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.Purple;
                            break;
                        case 1: //White
                            SerieColor = Color.DarkRed;
                            break;
                        default: //Other
                            SerieColor = Color.Tomato;
                            break;
                    }

                    break;

                case 13:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.SandyBrown;
                            break;
                        case 1: //White
                            SerieColor = Color.Brown;
                            break;
                        default: //Other
                            SerieColor = Color.SaddleBrown;
                            break;
                    }

                    break;

                case 14:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.MediumOrchid;
                            break;
                        case 1: //White
                            SerieColor = Color.BlueViolet;
                            break;
                        default: //Other
                            SerieColor = Color.PaleVioletRed;
                            break;
                    }

                    break;

                case 15:

                    switch (BackColorIndex)
                    {
                        case 0: //Black
                            SerieColor = Color.DarkCyan;
                            break;
                        case 1: //White
                            SerieColor = Color.Teal;
                            break;
                        default: //Other
                            SerieColor = Color.DarkSlateGray;
                            break;
                    }

                    break;
            }

            SerieColorIndex++;
            if (SerieColorIndex > 15) SerieColorIndex = 0;

            return (SerieColor);
        }

        #endregion
    }
}
