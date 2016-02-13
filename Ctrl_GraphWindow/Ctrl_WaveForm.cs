/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 9/14/2014
 * Time: 12:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#if DEBUG
using System.Diagnostics;
using System.IO;
#endif

namespace Ctrl_GraphWindow
{
    #region Public enums

    /// <summary>
    /// Graphic drawing stages enumeration
    /// </summary>
    public enum GraphDrawingStages
    {
        /// <summary>Nothing exists at this stage</summary>
        Scratch = 0,

        /// <summary>Frame and graphic pictures size and background color set,
        /// start from graphic frame borders drawing</summary>
        Frame = 1,

        /// <summary>Graphic frame borders are drawn,
        /// start from grid drawing</summary>
        Grid = 2,

        /// <summary>Graphic grid drawn,
        /// start from graphic X axis lines drawing</summary>
        XAxis_Lines = 3,

        /// <summary>Graphic X axis lines drawn,
        /// start from graphic Y axis lines drawing</summary>
        YAxis_Lines = 4,

        /// <summary>Graphic Y axis lines drawn,
        /// start from graphic Y axis values writing</summary>
        YAxis_Values = 5,

        /// <summary>Graphic Y axis values written,
        /// start from graphic series options drawing</summary>
        Series_Options = 6,

        /// <summary>Graphic series options drawn,
        /// start from graphic X axis options drawing</summary>
        XAxis_Options = 7,

        /// <summary>Graphic X axis options drawn,
        /// start from graphic X axis values writing</summary>
        XAxis_Values = 8,

        /// <summary>Graphic X axis values written,
        /// start from graphic series values tracing</summary>
        Series_Values = 9,
    }

    #endregion

    /// <summary>
    /// Description of Ctrl_WaveForm.
    /// </summary>
    public partial class Ctrl_WaveForm : UserControl
	{
		#region Private classes

	    #region Marker classes
	
	    private class DiamondMarker
	    {
	        #region Public members
	
	        public Point[] Points;
	
	        #endregion
	
	        public DiamondMarker()
	        {
	            Points = new Point[4];
	        }
	    }
	
	    private class CrossMarker
	    {
	        #region Public members
	
	        public Point[] Points;
	
	        #endregion
	
	        public CrossMarker()
	        {
	            Points = new Point[4];
	        }
	    }
	
	    private class TriangleMarker
	    {
	        #region Public members
	
	        public Point[] Points;
	
	        #endregion
	
	        public TriangleMarker()
	        {
	            Points = new Point[3];
	        }
	    }
	
	    #endregion

	    #region Axis classes
	
	    private class GraphAxis
	    {
	        #region Public members
	
	        public int StartPos;
	        public int EndPos;
	        public int SerieKey;
	        public int TitleLeft;

            public AxisGraduation[] Graduations;

	        #endregion
	
	        public GraphAxis()
	        {
	            StartPos = 0;
	            EndPos = 0;

                Graduations = null;
            }
	
	        #region Public methodes
	
	        public void Set_AxisGraduations(int FrameSize, int FramePosOffset)
	        {
	            int GradCnt = 0;
	
	            //Percentage of frame size used by the axis
	            int FracFrameSize = (EndPos - StartPos) * 100 / FrameSize;
	
	            //Definition of the number of axis graduation
	            if (FracFrameSize <= 1) //Axis is less than 1% of the frame size
	            {
	                GradCnt = 0; //0 Graduation
	            }
	            else if (FracFrameSize <= 5) //Axis is less than 5% of the frame size
	            {
	                GradCnt = 2; //Min & Max values
	            }
	            else if (FracFrameSize <= 10) //Axis is less than 10% of the frame size
	            {
	                GradCnt = 3; //Min, Max & median values
	            }
	            else if (FracFrameSize <= 25) //Axis is less than 25% of the frame size
	            {
	                GradCnt = 5; //Min, Max, median and 2 intermediate values
	            }
	            else if (FracFrameSize <= 50) //Axis is less than 50% of the frame size
	            {
	                GradCnt = 7; //Min, Max, median and 4 intermediate values
	            }
	            else if (FracFrameSize <= 75) //Axis is less than 75% of the frame size
	            {
	                GradCnt = 9; //Min, Max, median and 6 intermediate values
	            }
	            else //Axis is bigger than 75% of the frame size
	            {
	                GradCnt = 11; //Min, Max, median and 8 intermediate values
	            }
	
	            if(GradCnt>0)
	            {
	                Graduations = new AxisGraduation[GradCnt];
	
	                int GradPosStep = ((EndPos - StartPos) / (GradCnt - 1));
	
	                for (int iGrad = 0; iGrad < GradCnt; iGrad++)
	                {
	                    Graduations[iGrad] = new AxisGraduation();

	                    if (!(iGrad == GradCnt - 1))
	                    {
	                    	Graduations[iGrad].Position = StartPos + (GradPosStep * iGrad);
	                    }
	                    else
	                    {
	                    	Graduations[iGrad].Position = EndPos;
	                    }
	                }	
	            }	
	        }
			
            public void Set_GraduationsValues(double ValueMin, double ValueMax, GraphSerieValueFormat oFormat, bool bAbscisse)
            {
                double GradValStep = (ValueMax - ValueMin) / (Graduations.Length - 1);

                for (int iGrad = 0; iGrad < Graduations.Length; iGrad++)
                {
                    if (!bAbscisse)
                    {
                        Graduations[iGrad].Value = oFormat.Get_ValueFormatted(ValueMax - (GradValStep * iGrad));
                    }
                    else
                    {
                        Graduations[iGrad].Value = oFormat.Get_ValueFormatted(ValueMin + (GradValStep * iGrad));
                    }
                }
            }

	        public string Get_LongestGraduationText(int FrameSize, int FramePosOffset, double ValueMin, double ValueMax, GraphSerieValueFormat oFormat, bool bAbscisse)
	        {
                Set_AxisGraduations(FrameSize, FramePosOffset);
                Set_GraduationsValues(ValueMin, ValueMax, oFormat, bAbscisse);
	        	
	        	if (!(Graduations == null))
	        	{
	        		string LongestGradTxt = "";
	        		
	        		foreach (AxisGraduation sGrad in Graduations)
	        		{
	        			if ((sGrad.Value.Length > LongestGradTxt.Length) || (LongestGradTxt.Equals("")))
	        			{
	        				LongestGradTxt = sGrad.Value;
	        			}
	        		}

	        		return(LongestGradTxt);
	        	}
	        	
	        	return("");
	        }
	        
	        #endregion
	    }
	
	    private class GraphAxisGroup
	    {
	        #region Public members
	
	        public int LeftOffset;
	        public int Width;
	        public List<GraphAxis> AxisGroup;
	
	        #endregion
	
	        public GraphAxisGroup()
	        {
	            LeftOffset = 0;
	            Width = 0;
	            AxisGroup = new List<GraphAxis>();
	        }
	    }
	
	    private class GraphAxisCollection
	    {
	        #region Public members
	
	        public int TotalAxisWidth;
	        public List<GraphAxisGroup> AxisTable;
	        
	        #endregion
	
	        public GraphAxisCollection()
	        {
	            AxisTable = new List<GraphAxisGroup>();
	            TotalAxisWidth = 0;
	        }
	
	        #region Public methodes
	
	        public object[] Get_AxisInfos(int SerieKey)
	        {
	            foreach(GraphAxisGroup oGrp in AxisTable)
	            {
	                foreach(GraphAxis oAxis in oGrp.AxisGroup)
	                {
	                    if(oAxis.SerieKey==SerieKey)
	                    {
	                        object[] AxisInfos = new object[2];
	
	                        AxisInfos[0] = (object)oAxis;
	                        AxisInfos[1] = (object)oGrp.LeftOffset;
	
	                        return (AxisInfos);
	                    }
	                }
	            }
	
	            return (null);
	        }
	
	        #endregion
	    }

        #endregion

        #region Graphic classes

        private class GraphicUpdateRequest
        {
            #region Public properties

            public bool UpdateRequested
            {
                get
                {
                    return (mUpdateRequest);
                }

                set
                {
                    mUpdateRequest = value;

                    if(mUpdateRequest)
                    {
                        OnRequestRaised();
                    }
                }
            }

            #endregion

            #region Public events

            public event EventHandler RequestRaised;

            #endregion

            #region Private members

            private bool mUpdateRequest;

            #endregion

            public GraphicUpdateRequest(bool Init)
            {
                UpdateRequested = Init;
            }

            #region Events handling methods

            protected virtual void OnRequestRaised()
            {
                EventHandler Handler = RequestRaised;

                if(Handler!=null)
                {
                    Handler(this, new EventArgs());
                }
            }

            #endregion
        }

        private class GraphicDrawingStage
        {
            #region Public members

            public GraphDrawingStages DrawingStage;
            public Bitmap InitialFrameImage;
            public Bitmap InitialGraphImage;

            #endregion

            public GraphicDrawingStage()
            {
                DrawingStage = GraphDrawingStages.Scratch;
                InitialFrameImage = null;
                InitialGraphImage = null;
            }
        }

        private class GraphicCoordinates
	    {
	    	#region public members
	    	
	    	public double Abs;
	    	public SerieValueAtPoint[] Ords;
	    	
	    	#endregion
	    	
	    	public GraphicCoordinates()
	    	{
	    		Abs = double.NaN;
	    		Ords = null;
	    	}
	    	
	    	#region Public methodes
	    	
	    	public bool Get_OrdinateValue(int SerieKeyId, out SerieValueAtPoint OrdOut)
	    	{
	    		OrdOut = new Ctrl_WaveForm.SerieValueAtPoint();
	    		
	    		foreach (SerieValueAtPoint Val in Ords)
	    		{
	    			if (Val.SerieKeyId == SerieKeyId)
	    			{
	    				OrdOut = Val;
	    				return(true);
	    			}
	    		}
	    		
	    		return(false);
	    	}
	    	
	    	#endregion
	    }
	    
        private class LegendItemData
        {
            #region Public member

            public GraphSerieProperties ItemProperties;

            public double CurrentValue;
            public double Min;
            public double Max;
            public double Avg;

            #endregion

            public LegendItemData()
            {
                ItemProperties = null;
            }
        }

	    #endregion
	    
    	#endregion
	    
	    #region Private structures
	
	    private struct AxisGraduation
	    {
	        public int Position;
	        public string Value;
	    }
	    
	    private struct SerieValueAtPoint
	    {
	    	public string SerieName;
	    	public string SerieValue;
	    	public double SerieDblValue;
	    	public Color SerieColor;
	    	public int SerieKeyId;
	    }
	  	
	    private struct SerieCoordConversion
	    {
	    	public int SerieKeyId;
	    	public GW_SampleCoordConversion CoordConversion;
	    }
	    
	    #endregion
		
	    #region Private enums
	    
	    private enum GraphicCursorObject
	    {
	    	CursorMain = 0,
	    	CursorReference = 1,
	    }
	    
	    private enum GraphicCursorMovingDirection
	    {
	    	Left = 0,
	    	Right = 1,
	    	Up = 3,
	    	Down = 4,
	    }
	    
        private enum GraphicRealTimeStatus
        {
            Running = 0,
            Broken  = 1,
            Stopped = 2,
        }

	    #endregion
	    
		#region Privates constants

        private const string MSG_BOX_TITLE = "Graph Window";

        private const int GRAPH_FRAME_HEIGHT_OFFSET = 20; //40
        private const int GRAPH_FRAME_WIDTH_OFFSET = 20;

        private const int HORIZONTAL_GRID_LINES_COUNT = 9;
        private const int VERTICAL_GRID_LINES_COUNT = 9;

        private const int SEC_H_GRID_LINES_COUNT = HORIZONTAL_GRID_LINES_COUNT * 2 + 1;
        private const int SEC_V_GRID_LINES_COUNT = VERTICAL_GRID_LINES_COUNT *2 + 1;

        private const int MARKER_BASE_SIZE = 4; //Must be a pair number since it's gonna be divided by 2 to set the final marker size

        private const int AXIS_BASE_SIZE = 5;
        private const int AXIS_BASE_POS = 10;
        private const int AXIS_SEPARATION_SPACE = 5;
        private const int AXIS_TEXT_POS_OFFSET = 2;
        private const int AXIS_TITLE_POS_OFFSET = 5;
        
        private const int CURSOR_BASE_SIZE = 10; //Must be a pair number since it's gonna be divided by 2 to set the final cursor size
        private const int CURSOR_TEXT_LEFT_OFFSET = 5;
        private const int CURSOR_TEXT_TOP_OFFSET = 5;

        private const int REF_LINE_TEXT_POS_OFFSET = 5;

        private const int LEGEND_LABEL_COL          = 0;
        private const int LEGEND_VALUE_COL          = 1;
        private const int LEGEND_UNIT_COL           = 2;
        private const int LEGEND_MIN_COL            = 3;
        private const int LEGEND_MAX_COL            = 4;
        private const int LEGEND_AVG_COL            = 5;
        private const int LEGEND_REF_VAL_COL        = 6;
        private const int LEGEND_REF_DIFF_COL       = 7;
        private const int LEGEND_REF_DIFF_PERC_COL  = 8;
        private const int LEGEND_REF_GRADIENT_COL   = 9;

#if DEBUG
        private const string TASK_TIME_LOG_DIR = "..\\..\\..\\GraphControlLogs";
        private const string TASK_TIME_LOG_FILE = TASK_TIME_LOG_DIR + "\\TracingTimeLog_";
#endif

        #endregion

        #region Public events

        /// <summary>
        /// PreviewKeyDown event to be handled by host application
        /// </summary>
        /// <remarks>Fired on PreviewKeyDown internal event of the control</remarks>
        [Category("Key"), Browsable(true), Description("Occurs when a key is pressed while the focus is on this control")]
        public event EventHandler<PreviewKeyDownEventArgs> ControlPreviewKeyDown;

        #endregion

        #region Private delegates

        private delegate void Pic_GraphicSetupDelegateHandler(Rectangle PicGraphicRectangle);

        private delegate void InitLegendDelegateHandler();

        private delegate void AddLegendItemDelegateHandler(LegendItemData LegendItem);

        private delegate void GraphicPicturePostTracingDelegateHandler();

        #endregion

        #region Public control designer properties

        /// <summary>
        /// Control toolbar visible property
        /// </summary>
        [Category("Appearance"), Browsable(true), Description("Determines whether the control toolbar is visible")]
        public bool ToolBarVisible
        {
            get
            {
                return (TB_Graph.Visible);
            }

            set
            {
                TB_Graph.Visible = value;
            }
        }

        /// <summary>
        /// Load data command visible property
        /// </summary>
        [Category("Appearance"), Browsable(true), Description("Determines whether the load data command of the toolbar is visible")]
        public bool OpenFileVisible
        {
            get
            {
                return (TSB_LoadData.Visible);
            }

            set
            {
                TSB_LoadData.Visible = value;
                toolStripSeparator1.Visible = TSB_LoadData.Visible;
            }
        }

        /// <summary>
        /// Real time graphic flag
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether the graphic is used as a real time data display")]
        public bool RealTimeGraphic
        {
            get
            {
                return (bRealTimeGraphic);
            }

            set
            {
                bRealTimeGraphic = value;

                TSB_RT_Play.Visible = bRealTimeGraphic;
                TSB_RT_Break.Visible = bRealTimeGraphic;
                TSB_RT_Stop.Visible = bRealTimeGraphic;
                toolStripSeparator7.Visible = bRealTimeGraphic && (TSB_LoadData.Visible || bChannelListEnabled || bLegendEnabled ||
                    bEditGraphicConfigurationEnable || bCursorEnabled || bZoomEnabled || bPrintEnabled || bSnapShotEnabled);

                RT_PlaytoolStripMenuItem.Visible = bRealTimeGraphic;
                RT_BreaktoolStripMenuItem.Visible = bRealTimeGraphic;
                RT_StoptoolStripMenuItem.Visible = bRealTimeGraphic;
                toolStripSeparator8.Visible = bRealTimeGraphic && (bZoomEnabled || bCursorEnabled || bPrintEnabled || bSnapShotEnabled);

            }
        }

        /// <summary>
        /// Graphic properties editable property
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether the user can edit graphic properties")]
        public bool EditGraphicConfigurationEnable
        {
            get
            {
                return (bEditGraphicConfigurationEnable);
            }

            set
            {
                bEditGraphicConfigurationEnable = value;

                TSB_GraphProperties.Visible = value;
                TSDdB_GraphLayoutMode.Visible = value;
                toolStripSeparator5.Visible = bEditGraphicConfigurationEnable && (TSB_LoadData.Visible || bChannelListEnabled || bLegendEnabled);

                graphLayoutToolStripMenuItem.Visible = value;
                propertiesToolStripMenuItem.Visible = value;
                toolStripMenuItem1.Visible = bEditGraphicConfigurationEnable && (bZoomEnabled || bZoomEnabled);
            }
        }

        /// <summary>
        /// Cusrors enabled properties
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether graphic cursors are enabled")]
        public bool CursorEnabled
        {
            get
            {
                return (bCursorEnabled);
            }

            set
            {
                bCursorEnabled = value;

                TSDdB_MainGraphCursor.Visible = value;
                TSDdB_CursorStep.Visible = value;
                TSDB_RefCursor.Visible = value;
                toolStripSeparator2.Visible = bCursorEnabled && (TSB_LoadData.Visible || bChannelListEnabled || bLegendEnabled || bEditGraphicConfigurationEnable);

                cursorToolStripMenuItem.Visible = value;
                ReferenceCursorToolStripMenuItem.Visible = value;
                toolStripSeparator3.Visible = bCursorEnabled && bZoomEnabled;
            }
        }

        /// <summary>
        /// Zoom enabled properties
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether graphic zoom is enabled")]
        public bool ZoomEnabled
        {
            get
            {
                return (bZoomEnabled);
            }

            set
            {
                bZoomEnabled = value;

                TSDdB_ZoomMode.Visible = value;
                TSDdB_ZoomFactor.Visible = value;
                TSB_ZoomPlus.Visible = value;
                TSB_ZoomMinus.Visible = value;
                toolStripSeparator4.Visible = bZoomEnabled && (TSB_LoadData.Visible || bChannelListEnabled || bLegendEnabled|| bEditGraphicConfigurationEnable || bCursorEnabled);

                ZoomPlustoolStripMenuItem.Visible = value;
                ZoomMinustoolStripMenuItem.Visible = value;
                ZoomMintoolStripMenuItem.Visible = value;
                ZoomMaxtoolStripMenuItem.Visible = value;
                ZoomModetoolStripMenuItem.Visible = value;
                ZoomFactortoolStripMenuItem.Visible = value;
                toolStripSeparator3.Visible = true;
            }
        }

        /// <summary>
        /// Channel list enabled properties
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether graphic channel list and its functions are enabled")]
        public bool ChannelListEnabled
        {
            get
            {
                return (bChannelListEnabled);
            }

            set
            {
                bChannelListEnabled = value;

                splitContainer1.Panel1Collapsed = !value;
                TSB_ShowHide_ChannelList.Visible = value;
                toolStripSeparator1.Visible = TSB_LoadData.Visible && (ChannelListEnabled || bLegendEnabled);
            }
        }

        /// <summary>
        /// Legend enabled properties
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether graphic legend and its functions are enabled")]
        public bool LegendEnabled

        {
            get
            {
                return (bLegendEnabled);
            }

            set
            {
                bLegendEnabled = value;

                splitContainer2.Panel2Collapsed = !value;
                TSB_ShowHide_Legend.Visible = value;
                toolStripSeparator1.Visible = TSB_LoadData.Visible && (ChannelListEnabled || bLegendEnabled);
            }
        }

        /// <summary>
        /// Graphic snapshot enabled properties
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether graphic snapshot function is enabled")]
        public bool SnapShotEnabled
        {
            get
            {
                return (bSnapShotEnabled);
            }

            set
            {
                bSnapShotEnabled = value;

                TSB_Snapshot.Visible = value;
                toolStripSeparator6.Visible = (bSnapShotEnabled || bPrintEnabled) && (TSB_LoadData.Visible || bChannelListEnabled || bLegendEnabled || bEditGraphicConfigurationEnable || bCursorEnabled || bZoomEnabled);

                snapshotToolStripMenuItem.Visible = value;
                toolStripMenuItem7.Visible = (bSnapShotEnabled || bPrintEnabled) && (bZoomEnabled || bCursorEnabled || bEditGraphicConfigurationEnable);
            }
        }

        /// <summary>
        /// Graphic print enabled properties
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether graphic print out function is enabled")]
        public bool PrintEnabled
        {
            get
            {
                return (bPrintEnabled);
            }

            set
            {
                bPrintEnabled = value;

                TSB_Print.Visible = value;
                toolStripSeparator6.Visible = (bSnapShotEnabled || bPrintEnabled) && (TSB_LoadData.Visible || bChannelListEnabled || bLegendEnabled || bEditGraphicConfigurationEnable || bCursorEnabled || bZoomEnabled);

                printToolStripMenuItem.Visible = value;
                toolStripMenuItem7.Visible = (bSnapShotEnabled || bPrintEnabled) && (bZoomEnabled || bCursorEnabled || bEditGraphicConfigurationEnable);
            }
        }

        /// <summary>
        /// Keyboard shortcuts enabled properties
        /// </summary>
        [Category("Behavior"), Browsable(true), Description("Determines whether keyboard shortcuts are enabled")]
        public bool ShortcutKeysEnabled
        {
            get
            {
                return (bShortcutKeysEnabled);
            }

            set
            {
                bShortcutKeysEnabled = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Main curor abscisse value
        /// </summary>
        /// <remarks>Is NaN when cursor is not visible</remarks>
        public double MainCursorAbscisse
        {
            get
            {
                return (mMainCursorAbscisse);
            }

            private set
            {

            }
        }

        #endregion

        #region Private members

        private Thread GraphPictureMaker;
        private ManualResetEvent WaitHandle;
        private GraphicUpdateRequest oGraphicUpdateRequest;

        private Pic_GraphicSetupDelegateHandler Pic_GraphicSetupDelegate;
        private InitLegendDelegateHandler InitLegendDelegate;
        private AddLegendItemDelegateHandler AddLegendItemDelegate;
        private GraphicPicturePostTracingDelegateHandler GraphicPicturePostTracingDelegate;

        private bool bDataPlotted;

        private GraphDrawingStages eCurrentStage;
        private GraphicDrawingStage[] DrawingStages;

        private Image FrameImage;
        private Image GraphImage;

        private GW_DataFile WholeDataFile;
        private GW_DataFile DataFile;
        private List<SerieCoordConversion> SeriesReferenceCoordConversion;

        private int FrameWidth;
        private int FrameHeight;
        private int FrameLeftPoint;
        private int FrameRightPoint;
        private int FrameTopPoint;
        private int FrameBottomPoint;

        private int nSampleCount;
        private int nMarkCount;
        private double DblSampleStep;

        private int SeriesVisibleCount;
        private int[] AbscisseCoords;

        GraphAxis oAbscisseAxis;

        private GraphAxisCollection oYAxis;
        
        private int BaseLegendWidth;

        private GW_DataChannel oWholeAbcsisseChannel;
        private GW_DataChannel oAbcsisseChannel;
        private GraphSerieValueFormat oAbcisseValFormat;
        
        private GraphicCursorObject CurrentGraphCursor;
        private Point PtCursorPos;
        private Point PtRefCursorPos;
        private double[] CursorSteps = new double[] {0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50};
        private int CursorStepIndex;
        private GraphicCoordinates RefCursorCoordinates;
        
        private Point CursorPosMouseDown;
        private Point CursorPosMouseUp;
        private bool bZooming;
        private int[] ZoomFactors = new int[] {2, 4, 8, 16, 32};
        private int ZoomFactorIndex;
        private bool bXZoom;
        private bool bYZoom;
        private int RefZoomYUpperBound;
        private int RefZoomYLowerBound;
        
        private Point PtZoomBarMouseDown;

        private GraphicRealTimeStatus mRTStatus;

        #region Control designer options members

        private bool bRealTimeGraphic;
        private bool bEditGraphicConfigurationEnable;
        private bool bCursorEnabled;
        private bool bZoomEnabled;
        private bool bChannelListEnabled;
        private bool bLegendEnabled;
        private bool bSnapShotEnabled;
        private bool bPrintEnabled;
        private bool bShortcutKeysEnabled;
        #endregion

        #region Control feedback to host application members

        private double mMainCursorAbscisse;

        #endregion

#if DEBUG

        private int GraphPlotCount;
        private long LastPlotTime;
        private double AvgPlotTime;

        private GraphDrawingStages eGraphStartingPointLog;

        private long InitTime;
        private long FrameTime;
        private long GridTime;
        private long XAxisLineTime;
        private long YAxisLineTime;
        private long YAxisValueTime;
        private long SeriesOptionsTime;
        private long XAxisOptionsTime;
        private long XAxisValueTime;
        private long SeriesValuesTime;

        private string TraceTimeLogFile = "";

        private int iStageDbg;

#endif

        #endregion

        #region Private properties

        private GraphicRealTimeStatus RTStatus
        {
            get
            {
                return (mRTStatus);
            }

            set
            {
                mRTStatus = value;

                if (bRealTimeGraphic)
                {
                    switch (mRTStatus)
                    {
                        case GraphicRealTimeStatus.Running:

                            TSB_RT_Play.Visible = false;
                            TSB_RT_Break.Visible = true;
                            TSB_RT_Stop.Visible = true;

                            RT_PlaytoolStripMenuItem.Visible = false;
                            RT_BreaktoolStripMenuItem.Visible = true;
                            RT_StoptoolStripMenuItem.Visible = true;

                            break;

                        case GraphicRealTimeStatus.Broken:

                            TSB_RT_Play.Visible = true;
                            TSB_RT_Break.Visible = false;
                            TSB_RT_Stop.Visible = true;

                            RT_PlaytoolStripMenuItem.Visible = true;
                            RT_BreaktoolStripMenuItem.Visible = false;
                            RT_StoptoolStripMenuItem.Visible = true;

                            break;

                        case GraphicRealTimeStatus.Stopped:

                            TSB_RT_Play.Visible = true;
                            TSB_RT_Break.Visible = false;
                            TSB_RT_Stop.Visible = false;

                            RT_PlaytoolStripMenuItem.Visible = true;
                            RT_BreaktoolStripMenuItem.Visible = false;
                            RT_StoptoolStripMenuItem.Visible = false;

                            break;
                    }
                }
            }
        }

        #endregion

        #region Public members

        /// <summary>
        /// Graphical properties of the graph
        /// </summary>
        public GraphWindowProperties Properties;
		
        #endregion
        
        /// <summary>
        /// Default constructor
        /// </summary>
		public Ctrl_WaveForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

            bDataPlotted = false;

            eCurrentStage = GraphDrawingStages.Scratch;
            Init_DrawingStages();

            FrameImage = null;
            GraphImage = null;

            Properties = new GraphWindowProperties();
			WholeDataFile = null;
            DataFile = null;
            SeriesReferenceCoordConversion = null;

            oAbscisseAxis = null;

            oYAxis = new GraphAxisCollection();
            
            oWholeAbcsisseChannel = null;
            oAbcsisseChannel = null;
            oAbcisseValFormat = new GraphSerieValueFormat(); //Default format is 'Auto'

            BaseLegendWidth = Grid_Legend.Width;
            
            CurrentGraphCursor =  GraphicCursorObject.CursorMain;
            PtCursorPos = Point.Empty;
            PtRefCursorPos = Point.Empty;
            CursorStepIndex = 3; // 1%
            RefCursorCoordinates = null;
            
            CursorPosMouseDown = Point.Empty;
            CursorPosMouseUp = Point.Empty;
            bZooming = false;
            ZoomFactorIndex = 0; // x2
            bXZoom = false;
            bYZoom = false;
            
            Pic_GraphFrame.AllowDrop = true;
            Pic_Graphic.AllowDrop = true;
            
            Pic_GraphFrame.Controls.Add(Pic_Graphic);
            
            Pic_GraphFrame.Controls.Add(Cmd_ZoomXPosition);
            Cmd_ZoomXPosition.Top = 6;
            
            Pic_GraphFrame.Controls.Add(Cmd_ZoomYPosition);
            Cmd_ZoomYPosition.Left = Pic_GraphFrame.Width - 10;

            PtZoomBarMouseDown = Point.Empty;

            //Control designer options members init
            RealTimeGraphic = false;
            ToolBarVisible = true;
            OpenFileVisible = true;
            bEditGraphicConfigurationEnable = true;
            bCursorEnabled =  true;
            bZoomEnabled =  true;
            bChannelListEnabled = true;
            bLegendEnabled =  true;
            bSnapShotEnabled =  true;
            bPrintEnabled =  true;
            bShortcutKeysEnabled = true;

            //Control feedback to host application members init
            mMainCursorAbscisse = double.NaN;

            //Toolbar ShortCut keys
            TSDdB_zoomXToolStripMenuItem.ShortcutKeyDisplayString = "[X]";
            TSDdB_zoomYToolStripMenuItem.ShortcutKeyDisplayString = "[Y]";
            TSDdB_zoomXYToolStripMenuItem.ShortcutKeyDisplayString = "[B]";
            TSDB_RefCursor_Set.ShortcutKeyDisplayString = "[R]";
            TSDB_RefCursor_Lock.ShortcutKeyDisplayString = "[Enter]";
            TSDB_RefCursor_Clear.ShortcutKeyDisplayString = "[Esc]";
            TSDdB_overlayToolStripMenuItem.ShortcutKeyDisplayString = "[O]";
            TSDdB_parallelToolStripMenuItem.ShortcutKeyDisplayString = "[P]";
            TSDdB_customToolStripMenuItem.ShortcutKeyDisplayString = "[C]";
            TSDdB_verticalLineToolStripMenuItem.ShortcutKeyDisplayString = "[V]";
            TSDdB_horizontalLineToolStripMenuItem.ShortcutKeyDisplayString = "[H]";
            TSDdB_crossToolStripMenuItem.ShortcutKeyDisplayString = "[K]";
            
            //Context_PicGraph_Options ShortCut keys
            ZoomMode_X_ToolStripMenuItem.ShortcutKeyDisplayString = "[X]";
            ZoomMode_Y_ToolStripMenuItem.ShortcutKeyDisplayString = "[Y]";
            ZoomMode_XY_ToolStripMenuItem.ShortcutKeyDisplayString = "[B]";
            ZoomPlustoolStripMenuItem.ShortcutKeyDisplayString = "[+]";
            ZoomMinustoolStripMenuItem.ShortcutKeyDisplayString = "[-]";
            RefCursor_Set_TSMI.ShortcutKeyDisplayString = "[R]";
            RefCursor_Lock_TSMI.ShortcutKeyDisplayString = "[Enter]";
            RefCursor_Clear_TSMI.ShortcutKeyDisplayString = "[Esc]";
            Layout_overlayToolStripMenuItem.ShortcutKeyDisplayString = "[O]";
            Layout_parallelToolStripMenuItem.ShortcutKeyDisplayString = "[P]";
            Layout_customToolStripMenuItem.ShortcutKeyDisplayString = "[C]";
            propertiesToolStripMenuItem.ShortcutKeyDisplayString = "[G]";
            Cursor_verticalLineToolStripMenuItem.ShortcutKeyDisplayString = "[V]";
            Cursor_horizontalLineToolStripMenuItem.ShortcutKeyDisplayString = "[H]";
            Cursor_crossToolStripMenuItem.ShortcutKeyDisplayString = "[K]";
            ZoomMintoolStripMenuItem.ShortcutKeyDisplayString = "[W]";
            ZoomMaxtoolStripMenuItem.ShortcutKeyDisplayString = "[N]";

#if DEBUG
            //Test data file loading in debug mode avoiding to have to load it all the time
            //DataFile = new GW_DataFile();
            //Fill_ChannelList();

            //Graph configuration file loading in debug mode avoiding to have to load it all the time

            //Plot statistics labels displaying
            TSCmb_InitialStage.Visible = true;
            TSB_Replot.Visible = true;
            TSB_SeeStep.Visible = true;
            TSB_SeePrevStep.Visible = true;
            TSB_SeeNextStep.Visible = true;
            TSL_PlotCount.Visible = true;
            TSL_PlotLast.Visible = true;
            TSL_PlotAvg.Visible = true;

            TSCmb_InitialStage.Items.Clear();
            TSCmb_InitialStage.Items.AddRange(Enum.GetNames(typeof(GraphDrawingStages)));
            TSCmb_InitialStage.SelectedIndex = 0;

            //Plot statistics init
            GraphPlotCount = 0;
            LastPlotTime = 0;
            AvgPlotTime = 0;
#endif

            //Launch graphic tracing thread

            /*
                We are using a class here, not a simple 'bool' in order to lock the ressource
                since the lock(){} statement works only with reference types (wrapped) 
                not with value types such as 'bool'
            */
            oGraphicUpdateRequest = new GraphicUpdateRequest(false);
            oGraphicUpdateRequest.RequestRaised += new EventHandler(GraphicUpdateRequestRaised);

            Pic_GraphicSetupDelegate = new Pic_GraphicSetupDelegateHandler(Pic_GraphicSetupTask);
            InitLegendDelegate = new InitLegendDelegateHandler(LegendInitTask);
            AddLegendItemDelegate = new AddLegendItemDelegateHandler(AddLegendSerieTask);
            GraphicPicturePostTracingDelegate = new GraphicPicturePostTracingDelegateHandler(GraphicPicturePostTracingTask);

            WaitHandle = new ManualResetEvent(false);
            GraphPictureMaker = new Thread(new ThreadStart(GraphTracingThreadTask));
            GraphPictureMaker.IsBackground = true; //This to automatically close the thread on host application closing
        }

        #region Control events

        #region Control

        private void Ctrl_WaveForm_Load(object sender, EventArgs e)
        {
            RTStatus = GraphicRealTimeStatus.Running;

            GraphPictureMaker.Start();
        }

        #endregion

        #region Toolbar

        private void TSB_LoadData_Click(object sender, EventArgs e)
        {
            Load_DataFile();
        }

        private void TSB_ShowHide_ChannelList_Click(object sender, EventArgs e)
        {
            ShowHide_ChannelList();
        }
		
        private void TSB_ShowHide_LegendClick(object sender, EventArgs e)
		{
        	ShowHide_Legend();
		}
        
        private void TSB_GraphProperties_Click(object sender, EventArgs e)
        {
            Edit_GraphProperties();
        }
        
        #region TSDdB_GraphLayoutMode
        
        private void TSDdB_overlayToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(TSDdB_overlayToolStripMenuItem.Checked))
        	{
        		Change_GraphLayout(GraphicWindowLayoutModes.Overlay);
        	}
		}
		
		private void TSDdB_parallelToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_parallelToolStripMenuItem.Checked))
			{
				Change_GraphLayout(GraphicWindowLayoutModes.Parallel);
			}
		}
		
		private void TSDdB_customToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_customToolStripMenuItem.Checked))
			{
				Change_GraphLayout(GraphicWindowLayoutModes.Custom);
			}
		}
        
        #endregion
        
        #region TSDdB_MainGraphCursor
        
        private void TSDdB_noneToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(TSDdB_noneToolStripMenuItem.Checked))
        	{
        		Change_MainCursorMode(GraphicCursorMode.None);
        	}
		}
		
		private void TSDdB_horizontalLineToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_horizontalLineToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.HorizontalLine);
			}
		}
		
		private void TSDdB_verticalLineToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_verticalLineToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.VerticalLine);
			}
		}
		
		private void TSDdB_crossToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_crossToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.Cross);
			}
		}
		
		private void TSDdB_graticuleToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_graticuleToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.Graticule);
			}
		}
		
		private void TSDdB_squareToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_squareToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.Square);
			}
		}
		
		private void TSDdB_circleToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_circleToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.Circle);
			}
		}
        
        #endregion
        
        #region TSDdB_CursorStep
        
        private void TSDdB_CurStep_01_ToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(TSDdB_CurStep_01_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 0;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_CurStep_02_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_CurStep_02_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 1;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_CurStep_05_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_CurStep_05_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 2;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_CurStep_1_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_CurStep_1_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 3;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_CurStep_2_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_CurStep_2_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 4;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_CurStep_5_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_CurStep_5_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 5;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_CurStep_10_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_CurStep_10_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 6;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_CurStep_20_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_CurStep_20_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 7;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_CurStep_50_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_CurStep_50_ToolStripMenuItem.Checked))
        	{
        		CursorStepIndex = 8;
        		Set_Options_Controls();
        	}
		}
        
        #endregion
        
        #region TSDB_RefCursor
        
        private void TSDB_RefCursor_SetClick(object sender, EventArgs e)
		{
        	Set_ReferenceCursor();
		}
		
        private void TSDB_RefCursor_LockClick(object sender, EventArgs e)
		{
        	Lock_ReferenceCursor();
		}
        
		private void TSDB_RefCursor_ClearClick(object sender, EventArgs e)
		{
			Clear_ReferenceCursor();
		}
        
        #region TSDB_RefCursor_Mode
        
        private void TSDB_RefCursor_Mode_NoneClick(object sender, EventArgs e)
		{
        	if (!(TSDB_RefCursor_Mode_None.Checked))
        	{
        		Properties.ReferenceCursor.Mode = GraphicCursorMode.None;
        		Set_Options_Controls();
        	}
        		
		}
		
		private void TSDB_RefCursor_Mode_VerticalClick(object sender, EventArgs e)
		{
			if (!(TSDB_RefCursor_Mode_Vertical.Checked))
			{
				Properties.ReferenceCursor.Mode = GraphicCursorMode.VerticalLine;
        		Set_Options_Controls();
			}
		}
		
		private void TSDB_RefCursor_Mode_HorizontalClick(object sender, EventArgs e)
		{
			if (!(TSDB_RefCursor_Mode_Horizontal.Checked))
			{
				Properties.ReferenceCursor.Mode = GraphicCursorMode.HorizontalLine;
        		Set_Options_Controls();
			}
		}
        
        #endregion
        
        #endregion
        
        #region TSDdB_ZoomMode
        
        private void TSDdB_zoomXToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(TSDdB_zoomXToolStripMenuItem.Checked))
        	{
        		Change_ZoomMode(GraphicZoomMode.ZoomX);
        	}
		}
		
		private void TSDdB_zoomYToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_zoomYToolStripMenuItem.Checked))
			{
				Change_ZoomMode(GraphicZoomMode.ZoomY);
			}
		}
		
		private void TSDdB_zoomXYToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(TSDdB_zoomXYToolStripMenuItem.Checked))
			{
				Change_ZoomMode(GraphicZoomMode.ZoomXY);
			}
		}
        
		private void TSDdB_zoomDisabledToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (TSDdB_zoomDisabledToolStripMenuItem.Checked)
			{
				Change_ZoomMode(GraphicZoomMode.ZoomX);
			}
			else
			{
				Change_ZoomMode(GraphicZoomMode.Disabled);
			}
		}
		
        #endregion
        
        #region TSDdB_ZoomFactor
        
        private void TSDdB_ZoomFactor_2Click(object sender, EventArgs e)
		{
        	if (!(TSDdB_ZoomFactor_2.Checked))
        	{
        		ZoomFactorIndex = 0;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_ZoomFactor_4Click(object sender, EventArgs e)
		{
			if (!(TSDdB_ZoomFactor_4.Checked))
        	{
        		ZoomFactorIndex = 1;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_ZoomFactor_8Click(object sender, EventArgs e)
		{
			if (!(TSDdB_ZoomFactor_8.Checked))
        	{
        		ZoomFactorIndex = 2;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_ZoomFactor_16Click(object sender, EventArgs e)
		{
			if (!(TSDdB_ZoomFactor_16.Checked))
        	{
        		ZoomFactorIndex = 3;
        		Set_Options_Controls();
        	}
		}
		
		private void TSDdB_ZoomFactor_32Click(object sender, EventArgs e)
		{
			if (!(TSDdB_ZoomFactor_32.Checked))
        	{
        		ZoomFactorIndex = 4;
        		Set_Options_Controls();
        	}
		}
        
        #endregion
        
        private void TSB_ZoomPlusClick(object sender, EventArgs e)
		{
        	if (bDataPlotted) ZoomPlus();	
		}
		
		private void TSB_ZoomMinusClick(object sender, EventArgs e)
		{
			if (bDataPlotted) ZoomMinus();
		}
		
		private void TSB_SnapshotClick(object sender, EventArgs e)
		{
			Make_GraphicSnapshot();
		}
		
		private void TSB_PrintClick(object sender, EventArgs e)
		{
			Print_Graphic();
		}

        private void TSB_RT_Play_Click(object sender, EventArgs e)
        {
            Start_RealTimeTrace();
        }

        private void TSB_RT_Break_Click(object sender, EventArgs e)
        {
            Break_RealTimeTrace();
        }

        private void TSB_RT_Stop_Click(object sender, EventArgs e)
        {
            Stop_RealTimeTrace();
        }

        #region Debug buttons

        private void TSB_Replot_Click(object sender, EventArgs e)
        {
#if DEBUG
            Refresh_Graphic((GraphDrawingStages)TSCmb_InitialStage.SelectedIndex);
#endif
        }

        private void TSB_SeeStep_Click(object sender, EventArgs e)
        {
            if (DrawingStages != null)
            {
                iStageDbg = TSCmb_InitialStage.SelectedIndex;

                if (iStageDbg < DrawingStages.Length)
                {
                    Pic_GraphFrame.Image = (Bitmap)DrawingStages[iStageDbg].InitialFrameImage.Clone();
                    Pic_Graphic.Image = (Bitmap)DrawingStages[iStageDbg].InitialGraphImage.Clone();
                }
            }
        }

        private void TSB_SeePrevStep_Click(object sender, EventArgs e)
        {
            if (DrawingStages != null)
            {
                if (iStageDbg > 0)
                {
                    iStageDbg--;

                    Pic_GraphFrame.Image = (Bitmap)DrawingStages[iStageDbg].InitialFrameImage.Clone();
                    Pic_Graphic.Image = (Bitmap)DrawingStages[iStageDbg].InitialGraphImage.Clone(); ;
                }
            }
        }

        private void TSB_SeeNextStep_Click(object sender, EventArgs e)
        {
            if (DrawingStages != null)
            {
                if (iStageDbg < DrawingStages.Length - 1)
                {
                    iStageDbg++;

                    Pic_GraphFrame.Image = (Bitmap)DrawingStages[iStageDbg].InitialFrameImage.Clone();
                    Pic_Graphic.Image = (Bitmap)DrawingStages[iStageDbg].InitialGraphImage.Clone(); ;
                }
            }
        }

        #endregion

        #endregion

        #region Pic_GraphFrame

        private void Pic_GraphFrameSizeChanged(object sender, EventArgs e)
		{
            eCurrentStage = GraphDrawingStages.Scratch;
            oGraphicUpdateRequest.UpdateRequested = true;
        }
        
        private void Pic_GraphFrameDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}
        
        private void Pic_GraphFrameDragDrop(object sender, DragEventArgs e)
		{
        	Drop_Series(e);
		}
        
        #endregion
        
        #region Pic_Graphic
       
        private void Pic_GraphicMouseDown(object sender, MouseEventArgs e)
		{	
        	bZooming = false;
        	
        	if (bDataPlotted)
        	{
	        	switch (e.Button)
	        	{
	        		case MouseButtons.Left: //Cursor
	        			
	        			CursorPosMouseDown = Point.Empty;
	        			
	        			if (bCursorEnabled)
	        			{
	        				Draw_Cursor(e.Location);
	        			}
	        			
	        			break;
	        			
	        		case MouseButtons.Right: //Zoom or contextual menu
	        		
	        			CursorPosMouseDown = e.Location;
	        			bZooming = true;
	        			break;
	        	}
        	}
		}
        
        private void Pic_GraphicMouseUp(object sender, MouseEventArgs e)
		{
        	if (bDataPlotted)
        	{
        		if (e.Button.Equals(MouseButtons.Right))
        		{
        			if (!(Properties.ZoomMode.Equals(GraphicZoomMode.Disabled))) //Zoom enabled => Choice context option or context zoom
        			{
        				if ((Math.Abs(CursorPosMouseDown.X - e.X) > 10) || (Math.Abs(CursorPosMouseDown.Y - e.Y) > 10))
        				{
        					//Large displacement => Zoom
        					if (bZoomEnabled)
        					{
        						CursorPosMouseUp = e.Location;
        						Context_PicGraphic_ZoomStats.Show(Pic_Graphic, e.Location);
        					}
        				}
        				else
        				{
        					//Small or no displacement => Options
        					CursorPosMouseUp = Point.Empty;
        					
        					if (ToolBarVisible)
        					{
        						Context_PicGraph_Options.Show(Pic_Graphic, e.Location);
        					}
        				}
        			}
        			else //Zoom disabled => context options only
        			{
        				CursorPosMouseUp = Point.Empty;
        				
        				if (ToolBarVisible)
        				{
        					Context_PicGraph_Options.Show(Pic_Graphic, e.Location);
        				}
        			}
        		}
        	}
		}
        
        private void Pic_GraphicMouseMove(object sender, MouseEventArgs e)
		{
        	if (bDataPlotted)
        	{
	        	switch (e.Button)
	        	{
	        		case MouseButtons.Left:
	        			
	        			if (bCursorEnabled)
	        			{
	        				Draw_Cursor(e.Location);
	        			}
	        			
	        			break;
	        			
	        		case MouseButtons.Right:
	        			
	        			#region Zoom box drawing
	        			
	        			if (bZoomEnabled)
	        			{
	        				if (bZooming && (!(Properties.ZoomMode.Equals(GraphicZoomMode.Disabled))))
	        				{
	        					Pic_Graphic.Refresh();
	        					
	        					Point ZoomBoxLocation = Point.Empty;
	        					Size ZoomBoxSize = Size.Empty;
	        					Rectangle ZoomBox = Rectangle.Empty;
	        					
	        					switch (Properties.ZoomMode)
	        					{
	        						case GraphicZoomMode.ZoomX:
	        							
	        							if (e.X >= CursorPosMouseDown.X)
	        							{
	        								ZoomBoxLocation = new Point(CursorPosMouseDown.X, 0);
	        								ZoomBoxSize = new Size(e.X - CursorPosMouseDown.X, FrameHeight);
	        							}
	        							else
	        							{
	        								ZoomBoxLocation = new Point(e.X, 0);
	        								ZoomBoxSize = new Size(CursorPosMouseDown.X - e.X, FrameHeight);
	        							}
	        							
	        							break;
	        							
	        						case GraphicZoomMode.ZoomY:
	        							
	        							if (e.Y >= CursorPosMouseDown.Y)
	        							{
	        								ZoomBoxLocation = new Point(0, CursorPosMouseDown.Y);
	        								ZoomBoxSize = new Size(FrameWidth, e.Y - CursorPosMouseDown.Y);
	        							}
	        							else
	        							{
	        								
	        								ZoomBoxLocation = new Point(0, e.Y);
	        								ZoomBoxSize = new Size(FrameWidth, CursorPosMouseDown.Y - e.Y);
	        							}
	        							
	        							break;
	        							
	        						case GraphicZoomMode.ZoomXY:
	        							
	        							if (e.X >= CursorPosMouseDown.X && e.Y >= CursorPosMouseDown.Y) //Top left to bottom right points
	        							{
	        								ZoomBoxLocation = new Point(CursorPosMouseDown.X, CursorPosMouseDown.Y);
	        								ZoomBoxSize = new Size(e.X - CursorPosMouseDown.X, e.Y - CursorPosMouseDown.Y);
	        								
	        							}
	        							else if (e.X >= CursorPosMouseDown.X && e.Y < CursorPosMouseDown.Y) //Bottom left to top right points
	        							{
	        								ZoomBoxLocation = new Point(CursorPosMouseDown.X, e.Y);
	        								ZoomBoxSize = new Size(e.X - CursorPosMouseDown.X, CursorPosMouseDown.Y - e.Y);
	        							}
	        							else if (e.X < CursorPosMouseDown.X && e.Y >= CursorPosMouseDown.Y) //Top right to bottom left points
	        							{
	        								ZoomBoxLocation = new Point(e.X, CursorPosMouseDown.Y);
	        								ZoomBoxSize = new Size(CursorPosMouseDown.X -  e.X, e.Y - CursorPosMouseDown.Y);
	        							}
	        							else if (e.X < CursorPosMouseDown.X && e.Y < CursorPosMouseDown.Y) //Bottom right to top left points
	        							{
	        								ZoomBoxLocation = new Point(e.X, e.Y);
	        								ZoomBoxSize = new Size(CursorPosMouseDown.X - e.X, CursorPosMouseDown.Y - e.Y);
	        							}
	        							
	        							break;
	        					}
	        					
	        					ZoomBox = new Rectangle(ZoomBoxLocation, ZoomBoxSize);
	        					
	        					Graphics g = Pic_Graphic.CreateGraphics();
	        					Color c = Color.FromArgb(Properties.WindowBackColor.ToArgb() ^ 0xffffff); //Background color inversion
	        					Pen p = new Pen(c, 2);
	        					
	        					g.DrawRectangle(p, ZoomBox);
	        					
	        					p.Dispose();
	        					g.Dispose();
	        				}
	        			}
	        			#endregion
	        			
	        			break;
	        	}
        	}
		}
        
        private void Pic_GraphicPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
        	if (bDataPlotted && bShortcutKeysEnabled)
        	{
        		switch (e.KeyCode)
        		{
        			case Keys.Up:
        				
        				if (bCursorEnabled)
        				{
        					Move_Cursor(GraphicCursorMovingDirection.Up);
        				}
        				
        				break;
        				
        			case Keys.Down:
        				
        				if (bCursorEnabled)
        				{
        					Move_Cursor(GraphicCursorMovingDirection.Down);
        				}
        				
        				break;
        				
        			case Keys.Left:
        				
        				if (bCursorEnabled)
        				{
        					Move_Cursor(GraphicCursorMovingDirection.Left);
        				}
        				
        				break;
        				
        			case Keys.Right:
        				
        				if (bCursorEnabled)
        				{
        					Move_Cursor(GraphicCursorMovingDirection.Right);
        				}
        				
        				break;
        				
        			case Keys.PageUp:
        				
        				if (CursorStepIndex < CursorSteps.Length - 1)
        				{
        					CursorStepIndex++;
        					Set_Options_Controls();
        				}
        				
        				break;
        				
        			case Keys.PageDown:
        				
        				if (CursorStepIndex != 0)
        				{
        					CursorStepIndex--;
        					Set_Options_Controls();
        				}
        				
        				break;
        				
        			case Keys.Add:
        				
        				if (bZoomEnabled)
        				{
        					ZoomPlus();
        				}
        				
        				break;
        				
        			case Keys.Subtract:
        				
        				if (bZoomEnabled)
        				{
        					ZoomMinus();
        				}
        				
        				break;
        				
        			case Keys.X:
        				
        				if (bZoomEnabled)
        				{
        					Properties.ZoomMode = GraphicZoomMode.ZoomX;
        				}
        				
        				break;
        				
        			case Keys.Y:
        				
        				if (bZoomEnabled)
        				{
        					Properties.ZoomMode = GraphicZoomMode.ZoomY;
        				}
        				
        				break;
        				
        			case Keys.B:
        				
        				if (bZoomEnabled)
        				{
        					Properties.ZoomMode = GraphicZoomMode.ZoomXY;
        				}
        				
        				break;
        				
        			case Keys.R:
        				
        				if (bCursorEnabled)
        				{
        					Set_ReferenceCursor();
        				}
        				
        				break;
        				
        			case Keys.Enter:
        				
        				if (bCursorEnabled)
        				{
        					Lock_ReferenceCursor();
        				}
        				
        				break;
        				
        			case Keys.Escape:
        				
        				if (bCursorEnabled)
        				{
        					Clear_ReferenceCursor();
        				}
        				
        				break;
        				
        			case Keys.O:
        				
        				if (bEditGraphicConfigurationEnable)
        				{
        					Properties.GraphLayoutMode = GraphicWindowLayoutModes.Overlay;
                            eCurrentStage = GraphDrawingStages.Scratch;
                            oGraphicUpdateRequest.UpdateRequested = true;
                        }
        				
        				break;
        				
        			case Keys.P:
        				
        				if (bEditGraphicConfigurationEnable)
        				{
        					Properties.GraphLayoutMode = GraphicWindowLayoutModes.Parallel;
                            eCurrentStage = GraphDrawingStages.Scratch;
                            oGraphicUpdateRequest.UpdateRequested = true;
                        }
        				
        				break;
        				
        			case Keys.C:
        				
        				if (bEditGraphicConfigurationEnable)
        				{
        					Properties.GraphLayoutMode = GraphicWindowLayoutModes.Custom;
                            eCurrentStage = GraphDrawingStages.Grid;
                            oGraphicUpdateRequest.UpdateRequested = true;
                        }
        				
        				break;
        				
        			case Keys.G:
        				
        				if (bEditGraphicConfigurationEnable)
        				{
        					Edit_GraphProperties();
        				}
        				
        				break;
        				
        			case Keys.V:
        				
        				if (bCursorEnabled)
        				{
        					Properties.Cursor.Mode = GraphicCursorMode.VerticalLine;
        					Set_Options_Controls();
        				}
        				
        				break;
        				
        			case Keys.H:
        				
        				if (bCursorEnabled)
        				{
        					Properties.Cursor.Mode = GraphicCursorMode.HorizontalLine;
        					Set_Options_Controls();
        				}
        				
        				break;
        				
        			case Keys.K:
        				
        				if (bCursorEnabled)
        				{
        					Properties.Cursor.Mode = GraphicCursorMode.Cross;
        					Set_Options_Controls();
        				}
        				
        				break;
        				
        			case Keys.W:
        				
        				if (bZoomEnabled)
        				{
        					ZoomMin();
        				}
        				
        				break;
        				
        			case Keys.N:
        				
        				if (bZoomEnabled)
        				{
        					ZoomPlus(true);
        				}
        				
        				break;
        		}
        	}

            OnControlPreviewKeyDown(e);
        }
        
        private void Pic_GraphicDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}
        
        private void Pic_GraphicDragDrop(object sender, DragEventArgs e)
		{
        	Drop_Series(e);
		}

        #endregion

        #region Context_PicGraph_Options

        private void RT_PlaytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start_RealTimeTrace();
        }

        private void RT_BreaktoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Break_RealTimeTrace();
        }

        private void RT_StoptoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop_RealTimeTrace();
        }

        private void ZoomPlustoolStripMenuItemClick(object sender, EventArgs e)
		{
        	ZoomPlus();
		}
		
		private void ZoomMinustoolStripMenuItemClick(object sender, EventArgs e)
		{
			ZoomMinus();
		}
		
		private void ZoomMintoolStripMenuItemClick(object sender, EventArgs e)
		{
			ZoomMin();
		}
		
		private void ZoomMaxtoolStripMenuItemClick(object sender, EventArgs e)
		{
			ZoomPlus(true);
		}
        
        #region Zoom mode
        
        private void ZoomMode_X_ToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(ZoomMode_X_ToolStripMenuItem.Checked))
        	{
        		Change_ZoomMode(GraphicZoomMode.ZoomX);
        	}
		}
		
		private void ZoomMode_Y_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ZoomMode_Y_ToolStripMenuItem.Checked))
			{
				Change_ZoomMode(GraphicZoomMode.ZoomY);
			}
		}
		
		private void ZoomMode_XY_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ZoomMode_XY_ToolStripMenuItem.Checked))
			{
				Change_ZoomMode(GraphicZoomMode.ZoomXY);
			}
		}
		
		private void ZoomMode_Disabled_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (ZoomMode_Disabled_ToolStripMenuItem.Checked)
			{
				Change_ZoomMode(GraphicZoomMode.ZoomX);
			}
			else
			{
				Change_ZoomMode(GraphicZoomMode.Disabled);
			}
		}
        
        #endregion
        
        #region Zoom factor
        
        private void ZoomFactor_2_ToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(ZoomFactor_2_ToolStripMenuItem.Checked))
        	{
        		ZoomFactorIndex = 0;
        		Set_Options_Controls();
        	}
		}
		
		private void ZoomFactor_4_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ZoomFactor_4_ToolStripMenuItem.Checked))
        	{
        		ZoomFactorIndex = 1;
        		Set_Options_Controls();
        	}
		}
		
		private void ZoomFactor_8_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ZoomFactor_8_ToolStripMenuItem.Checked))
        	{
        		ZoomFactorIndex = 2;
        		Set_Options_Controls();
        	}
		}
		
		private void ZoomFactor_16_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ZoomFactor_16_ToolStripMenuItem.Checked))
        	{
        		ZoomFactorIndex = 3;
        		Set_Options_Controls();
        	}
		}
		
		private void ZoomFactor_32_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ZoomFactor_32_ToolStripMenuItem.Checked))
        	{
        		ZoomFactorIndex = 4;
        		Set_Options_Controls();
        	}
		}
        
        #endregion
        
        #region Graph Layout
        
        private void Layout_overlayToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(Layout_overlayToolStripMenuItem.Checked))
        	{
        		Change_GraphLayout(GraphicWindowLayoutModes.Overlay);
        	}
		}
		
		private void Layout_parallelToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Layout_parallelToolStripMenuItem.Checked))
			{
				Change_GraphLayout(GraphicWindowLayoutModes.Parallel);
			}
		}
		
		private void Layout_customToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Layout_customToolStripMenuItem.Checked))
			{
				Change_GraphLayout(GraphicWindowLayoutModes.Custom);
			}
		}
        
        #endregion
        
        #region Cursor
        
        private void Cursor_noneToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(Cursor_noneToolStripMenuItem.Checked))
        	{
        		Change_MainCursorMode(GraphicCursorMode.None);
        	}
		}
		
		private void Cursor_verticalLineToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_verticalLineToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.VerticalLine);
			}
		}
		
		private void Cursor_horizontalLineToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_horizontalLineToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.HorizontalLine);
			}
		}
		
		private void Cursor_crossToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_crossToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.Cross);
			}
		}
		
		private void Cursor_graticuleToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_graticuleToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.Graticule);
			}      
		}
		
		private void Cursor_squareToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_squareToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.Square);
			}
		}
		
		private void Cursor_circleToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_circleToolStripMenuItem.Checked))
			{
				Change_MainCursorMode(GraphicCursorMode.Circle);
			}
		}
        
		#region Cursor step
		
		private void Cursor_Step_01_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_01_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 0;
				Set_Options_Controls();
			}
		}
		
		private void Cursor_Step_02_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_02_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 1;
				Set_Options_Controls();
			}
		}
		
		private void Cursor_Step_05_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_05_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 2;
				Set_Options_Controls();
			}
		}
		
		private void Cursor_Step_1_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_1_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 3;
				Set_Options_Controls();
			}
		}
		
		private void Cursor_Step_2_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_2_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 4;
				Set_Options_Controls();
			}
		}
		
		private void Cursor_Step_5_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_5_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 5;
				Set_Options_Controls();
			}
		}
		
		private void Cursor_Step_10_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_10_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 6;
				Set_Options_Controls();
			}
		}
		
		private void Cursor_Step_20_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_20_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 7;
				Set_Options_Controls();
			}
		}
		
		private void Cursor_Step_50_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Cursor_Step_50_ToolStripMenuItem.Checked))
			{
				CursorStepIndex = 8;
				Set_Options_Controls();
			}
		}
		
		#endregion
		
        #endregion
        
        #region Reference cursor
        
        private void RefCursor_Set_TSMIClick(object sender, EventArgs e)
		{
        	Set_ReferenceCursor();
		}
		
        private void RefCursor_Lock_TSMIClick(object sender, EventArgs e)
		{
        	Lock_ReferenceCursor();
		}
        
		private void RefCursor_Clear_TSMIClick(object sender, EventArgs e)
		{
			Clear_ReferenceCursor();
		}
        
        #region Mode
        
        private void RefCursor_Mode_None_TSMIClick(object sender, EventArgs e)
		{
        	if (!(RefCursor_Mode_None_TSMI.Checked))
        	{
        		Properties.ReferenceCursor.Mode = GraphicCursorMode.None;
        		Set_Options_Controls();
        	}
		}
		
		private void RefCursor_Mode_Vertical_TSMIClick(object sender, EventArgs e)
		{
			if (!(RefCursor_Mode_Vertical_TSMI.Checked))
			{
				Properties.ReferenceCursor.Mode = GraphicCursorMode.VerticalLine;
        		Set_Options_Controls();
			}
		}
		
		private void RefCursor_Mode_Horizontal_TSMIClick(object sender, EventArgs e)
		{
			if (!(RefCursor_Mode_Horizontal_TSMI.Checked))
			{
				Properties.ReferenceCursor.Mode = GraphicCursorMode.HorizontalLine;
        		Set_Options_Controls();
			}
		}
        
        #endregion
        
        #endregion
        
        private void PropertiesToolStripMenuItemClick(object sender, EventArgs e)
		{
        	Edit_GraphProperties();
		}
        
        private void SnapshotToolStripMenuItemClick(object sender, EventArgs e)
		{
			Make_GraphicSnapshot();
		}
		
		private void PrintToolStripMenuItemClick(object sender, EventArgs e)
		{
			Print_Graphic();
		}
        
        #endregion
        
        #region Context_PicGraphic_ZoomStats
        
        private void ZoomToolStripMenuItemClick(object sender, EventArgs e)
		{
        	Plot_ZoomBoxData();
		}
		
		private void StatisticsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Show_ZoomBoxStatistics();
		}
        
        #endregion
        
        #region Cmd_ZoomXPosition
        
        private void Cmd_ZoomXPositionMouseDown(object sender, MouseEventArgs e)
		{
        	if (e.Button.Equals(MouseButtons.Left))
        	{
        		PtZoomBarMouseDown = e.Location;
        	}
		}
        
        private void Cmd_ZoomXPositionMouseMove(object sender, MouseEventArgs e)
		{
        	if (e.Button.Equals(MouseButtons.Left))
        	{
        		int NewLeft = Cmd_ZoomXPosition.Left + (e.Location.X - PtZoomBarMouseDown.X);
        		
        		if (NewLeft >= FrameLeftPoint && NewLeft + Cmd_ZoomXPosition.Width <= FrameRightPoint)
        		{
        			Cmd_ZoomXPosition.Left += (e.Location.X - PtZoomBarMouseDown.X);
        		}
        	}
		}
        
        private void Cmd_ZoomXPositionMouseUp(object sender, MouseEventArgs e)
		{
        	if (e.Button.Equals(MouseButtons.Left))
        	{
        		Plot_DataAtXZoomBarPosition();
        	}
		}
        
        private void Cmd_ZoomXPositionMouseEnter(object sender, EventArgs e)
		{
        	Cursor = Cursors.SizeWE;
		}
		
		private void Cmd_ZoomXPositionMouseLeave(object sender, EventArgs e)
		{
			Cursor = Cursors.Default;
		}
        
        #endregion
        
        #region Cmd_ZoomYPosition
        
        private void Cmd_ZoomYPositionMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button.Equals(MouseButtons.Left))
        	{
        		PtZoomBarMouseDown = e.Location;
        	}
		}
        
        private void Cmd_ZoomYPositionMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button.Equals(MouseButtons.Left))
			{
				int NewTop = Cmd_ZoomYPosition.Top + (e.Y - PtZoomBarMouseDown.Y);
				
				if (NewTop >= FrameTopPoint && NewTop + Cmd_ZoomYPosition.Height <= FrameBottomPoint)
				{
					Cmd_ZoomYPosition.Top += (e.Y - PtZoomBarMouseDown.Y);
				}
			}
		}
        
        private void Cmd_ZoomYPositionMouseUp(object sender, MouseEventArgs e)
		{
        	if (e.Button.Equals(MouseButtons.Left))
        	{
        		Plot_DataAtYZoomBarPosition();
        	}
		}
        
        private void Cmd_ZoomYPositionMouseEnter(object sender, EventArgs e)
		{
			Cursor = Cursors.SizeNS;
		}
		
		private void Cmd_ZoomYPositionMouseLeave(object sender, EventArgs e)
		{
			Cursor = Cursors.Default;
		}

        #endregion

        #region Grid_Legend

        private void Grid_Legend_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                if (!(Grid_Legend.SelectedRows == null))
                {
                    TSMI_Ctxt_Legend_Edit.Enabled = true;
                    TSMI_Ctxt_Legend_Hide.Enabled = true;
                    TSMI_Ctxt_Legend_Remove.Enabled = true;

                    if (Grid_Legend.SelectedRows[0].Cells[LEGEND_LABEL_COL].Style.Font.Strikeout)
                    {
                        TSMI_Ctxt_Legend_Hide.Text = "Show graph";
                    }
                    else
                    {
                        TSMI_Ctxt_Legend_Hide.Text = "Hide graph";
                    }
                }
                else
                {
                    TSMI_Ctxt_Legend_Edit.Enabled = false;
                    TSMI_Ctxt_Legend_Hide.Enabled = false;
                    TSMI_Ctxt_Legend_Remove.Enabled = false;
                }

                if (PtRefCursorPos.IsEmpty)
                {
                    TSMI_Ctxt_Legend_Infos_RefCursor.Visible = false;
                }
                else
                {
                    TSMI_Ctxt_Legend_Infos_RefCursor.Visible = true;
                }

                if(Grid_Legend.ColumnHeadersVisible)
                {
                    TSMI_Ctxt_Legend_ShowTitles.Text = "Hide information titles";
                }
                else
                {
                    TSMI_Ctxt_Legend_ShowTitles.Text = "Show information titles";
                }

                if (Grid_Legend.CellBorderStyle == DataGridViewCellBorderStyle.Single)
                {
                    TSMI_Ctxt_Legend_ShowGridLines.Text = "Hide grid lines";
                }
                else
                {
                    TSMI_Ctxt_Legend_ShowGridLines.Text = "Show grid lines";
                }

                Context_Legend.Show(Grid_Legend, e.Location);
            }
        }

        private void Grid_Legend_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!(Grid_Legend.SelectedCells == null))
            {
                Edit_SerieProperties((int)Grid_Legend.SelectedRows[0].Cells[LEGEND_LABEL_COL].Tag);
            }
        }

        private void Grid_Legend_KeyDown(object sender, KeyEventArgs e)
        {
            if (Grid_Legend.SelectedCells != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.T:

                        foreach (DataGridViewRow oRow in Grid_Legend.SelectedRows)
                        {
                            Change_SerieVisibility((int)oRow.Cells[LEGEND_LABEL_COL].Tag);
                        }

                        break;

                    case Keys.Delete:

                        foreach (DataGridViewRow oRow in Grid_Legend.SelectedRows)
                        {
                            Remove_Serie((int)oRow.Cells[LEGEND_LABEL_COL].Tag);
                        }

                        break;
                }
            }
        }

        #endregion

        #region Context_Legend
        
        private void TSMI_Ctxt_Legend_EditClick(object sender, EventArgs e)
		{
            if (Grid_Legend.SelectedRows != null)
            {
                Edit_SerieProperties((int)Grid_Legend.SelectedRows[0].Cells[LEGEND_LABEL_COL].Tag);
            }
		}
        
        private void TSMI_Ctxt_Legend_HideClick(object sender, EventArgs e)
		{
            if (Grid_Legend.SelectedRows != null)
            {
                Change_SerieVisibility((int)Grid_Legend.SelectedRows[0].Cells[LEGEND_LABEL_COL].Tag);
            }
		}
        
        private void TSMI_Ctxt_Legend_RemoveClick(object sender, EventArgs e)
		{
            if (Grid_Legend.SelectedRows != null)
            {
                Remove_Serie((int)Grid_Legend.SelectedRows[0].Cells[LEGEND_LABEL_COL].Tag);
            }
		}
        
        #region Legend informations
        
        private void TSMI_Ctxt_Legend_Infos_LabelClick(object sender, EventArgs e)
		{
        	TSMI_Ctxt_Legend_Infos_Label.Checked = !TSMI_Ctxt_Legend_Infos_Label.Checked;
            Grid_Legend.Columns[LEGEND_LABEL_COL].Visible = TSMI_Ctxt_Legend_Infos_Label.Checked;

            if (TSMI_Ctxt_Legend_Infos_Label.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.Label;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.Label;
			}			
		}
		
		private void TSMI_Ctxt_Legend_Infos_ValueClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_Value.Checked = !TSMI_Ctxt_Legend_Infos_Value.Checked;
            Grid_Legend.Columns[LEGEND_VALUE_COL].Visible = TSMI_Ctxt_Legend_Infos_Value.Checked;

            if (TSMI_Ctxt_Legend_Infos_Value.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.CurrentValue;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.CurrentValue;
			}
		}
		
		private void TSMI_Ctxt_Legend_Infos_UnitClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_Unit.Checked = !TSMI_Ctxt_Legend_Infos_Unit.Checked;
            Grid_Legend.Columns[LEGEND_UNIT_COL].Visible = TSMI_Ctxt_Legend_Infos_Unit.Checked;

            if (TSMI_Ctxt_Legend_Infos_Unit.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.Unit;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.Unit;
			}
		}
		
		private void TSMI_Ctxt_Legend_Infos_MinClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_Min.Checked = !TSMI_Ctxt_Legend_Infos_Min.Checked;
            Grid_Legend.Columns[LEGEND_MIN_COL].Visible = TSMI_Ctxt_Legend_Infos_Min.Checked;

            if (TSMI_Ctxt_Legend_Infos_Min.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.GraphMin;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.GraphMin;
			}
		}
		
		private void TSMI_Ctxt_Legend_Infos_MaxClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_Max.Checked = !TSMI_Ctxt_Legend_Infos_Max.Checked;
            Grid_Legend.Columns[LEGEND_MAX_COL].Visible = TSMI_Ctxt_Legend_Infos_Max.Checked;

            if (TSMI_Ctxt_Legend_Infos_Max.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.GraphMax;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.GraphMax;
			}
		}
		
		private void TSMI_Ctxt_Legend_Infos_AvgClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_Avg.Checked = !TSMI_Ctxt_Legend_Infos_Avg.Checked;
            Grid_Legend.Columns[LEGEND_AVG_COL].Visible = TSMI_Ctxt_Legend_Infos_Avg.Checked;

            if (TSMI_Ctxt_Legend_Infos_Avg.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.GraphAvg;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.GraphAvg;
			}
		}
		
        #region Reference cursor
        
        private void TSMI_Ctxt_Legend_Infos_RefCursor_ValueClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_RefCursor_Value.Checked = !TSMI_Ctxt_Legend_Infos_RefCursor_Value.Checked;
            Grid_Legend.Columns[LEGEND_REF_VAL_COL].Visible = TSMI_Ctxt_Legend_Infos_RefCursor_Value.Checked;

            if (TSMI_Ctxt_Legend_Infos_RefCursor_Value.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.RefCursorValue;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.RefCursorValue;
			}
		}
		
		private void TSMI_Ctxt_Legend_Infos_RefCursor_DiffClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Checked = !TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Checked;
            Grid_Legend.Columns[LEGEND_REF_DIFF_COL].Visible = TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Checked;

            if (TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.RefCursorDiffValue;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.RefCursorDiffValue;
			}
		}
		
		private void TSMI_Ctxt_Legend_Infos_RefCursor_DiffPercClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Checked = !TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Checked;
            Grid_Legend.Columns[LEGEND_REF_DIFF_PERC_COL].Visible = TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Checked;

            if (TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.RefCursorDiffPerc;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.RefCursorDiffPerc;
			}
		}
		
		private void TSMI_Ctxt_Legend_Infos_RefCursor_GradientClick(object sender, EventArgs e)
		{
			TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Checked = !TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Checked;
            Grid_Legend.Columns[LEGEND_REF_GRADIENT_COL].Visible = TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Checked;

            if (TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Checked)
			{
				Properties.LegendProperties.Informations |= GraphicLegendInformations.RefCursorGradient;
			}
			else
			{
				Properties.LegendProperties.Informations -= GraphicLegendInformations.RefCursorGradient;
			}
		}
        
        #endregion
        
        #endregion
        
        private void TSMI_Ctxt_Legend_ShowTitlesClick(object sender, EventArgs e)
		{
            Properties.LegendProperties.LegendHeaderVisible = !Properties.LegendProperties.LegendHeaderVisible;
            Grid_Legend.ColumnHeadersVisible = Properties.LegendProperties.LegendHeaderVisible;
		}
        
        private void TSMI_Ctxt_Legend_ShowGridLinesClick(object sender, EventArgs e)
		{
            if (Grid_Legend.CellBorderStyle == DataGridViewCellBorderStyle.Single)
            {
                Grid_Legend.CellBorderStyle = DataGridViewCellBorderStyle.None;
                Properties.LegendProperties.LegendGridLinesVisible = false;
            }
            else
            {
                Grid_Legend.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                Properties.LegendProperties.LegendGridLinesVisible = true;
            }
		}

        #endregion

        #endregion

        #region Private classes events

        private void GraphicUpdateRequestRaised(object sender, EventArgs e)
        {
            if (GraphPictureMaker.ThreadState == (System.Threading.ThreadState.Background | System.Threading.ThreadState.WaitSleepJoin))
            {
                Grid_Legend.SuspendLayout();
                WaitHandle.Set();
            }
        }

        #endregion

        #region Private methodes

        #region Threaded method and delegates

        private void GraphTracingThreadTask()
        {
            while (true)
            {
                WaitHandle.WaitOne();

                lock (oGraphicUpdateRequest)
                {
                    if (oGraphicUpdateRequest.UpdateRequested)
                    {
#if DEBUG
                        Stopwatch swTaskTime = new Stopwatch();
                        swTaskTime.Start();
#endif
                        bDataPlotted = false;
                        DrawGraphFromStage(eCurrentStage);

#if DEBUG
                        //Plot statistics computation
                        swTaskTime.Stop();
                        LastPlotTime = swTaskTime.ElapsedMilliseconds;
#endif
                        oGraphicUpdateRequest.UpdateRequested = false;
                        this.Invoke(this.GraphicPicturePostTracingDelegate);
                    }
                }

                WaitHandle.Reset();
            }
        }

        private void Pic_GraphicSetupTask(Rectangle PicGraphicRectangle)
        {
            Pic_Graphic.Location = PicGraphicRectangle.Location;
            Pic_Graphic.Size = PicGraphicRectangle.Size;
        }

        private void LegendInitTask()
        {
            Init_Legend();
        }

        private void AddLegendSerieTask(LegendItemData LegendData)
        {
            Grid_Legend.Rows.Add();
            DataGridViewRow oRow = Grid_Legend.Rows[Grid_Legend.Rows.Count - 1];

            foreach(DataGridViewCell oCell in oRow.Cells)
            {
                oCell.Style.BackColor = Properties.WindowBackColor;
                oCell.Style.ForeColor = LegendData.ItemProperties.Trace.LineColor;

                Properties.LegendProperties.LegendFont.Set_FontProperty(GW_Font.FontProperty.Strikeout, !LegendData.ItemProperties.Visible);
                oCell.Style.Font = Properties.LegendProperties.LegendFont.oFont;

                switch(oCell.ColumnIndex)
                {
                    case LEGEND_LABEL_COL:

                        oCell.Tag = LegendData.ItemProperties.KeyId;
                        oCell.Value = LegendData.ItemProperties.Name;
                        break;

                    case LEGEND_VALUE_COL:

                        oCell.Value = LegendData.ItemProperties.ValueFormat.Get_ValueFormatted(LegendData.CurrentValue);
                        break;

                    case LEGEND_UNIT_COL:

                        oCell.Value = LegendData.ItemProperties.Unit;
                        break;

                    case LEGEND_MIN_COL:

                        oCell.Value = LegendData.ItemProperties.ValueFormat.Get_ValueFormatted(LegendData.Min);
                        break;

                    case LEGEND_MAX_COL:

                        oCell.Value = LegendData.ItemProperties.ValueFormat.Get_ValueFormatted(LegendData.Max);
                        break;

                    case LEGEND_AVG_COL:

                        oCell.Value = LegendData.ItemProperties.ValueFormat.Get_ValueFormatted(LegendData.Avg);
                        break;
                }
            }
        }

        private void GraphicPicturePostTracingTask()
        {
            Pic_GraphFrame.Image = FrameImage;
            Pic_Graphic.Image = GraphImage;

            Grid_Legend.ResumeLayout(true);
            Set_ZoomBars();
            Set_Options_Controls();

#if DEBUG
            if (LastPlotTime > 0)
            {
                AvgPlotTime = ((AvgPlotTime * GraphPlotCount) + (double)LastPlotTime) / (GraphPlotCount + 1);
                GraphPlotCount++;

                TSL_PlotCount.Text = "Plots: " + GraphPlotCount.ToString();
                TSL_PlotAvg.Text = "Avg: " + AvgPlotTime.ToString("F3") + " ms";
            }

            TSL_PlotLast.Text = "Last total: " + LastPlotTime.ToString() + " ms";

            StreamWriter SR = null;

            if (TraceTimeLogFile.Equals(""))
            {
                if(!Directory.Exists(TASK_TIME_LOG_DIR))
                {
                    Directory.CreateDirectory(TASK_TIME_LOG_DIR);
                }

                TraceTimeLogFile = TASK_TIME_LOG_FILE 
                                    + this.Name + "_"
                                    + DateTime.Now.Year.ToString("D4")
                                    + DateTime.Now.Month.ToString("D2")
                                    + DateTime.Now.Day.ToString("D2")
                                    + "_" 
                                    + DateTime.Now.Hour.ToString("D2")
                                    + DateTime.Now.Minute.ToString("D2")
                                    + DateTime.Now.Second.ToString("D2") + ".txt";

                SR = new StreamWriter(TraceTimeLogFile);
            }
            else
            {
                SR = new StreamWriter(TraceTimeLogFile, true);
            }

            SR.Write(DateTime.Now.ToShortDateString()
                + " " + DateTime.Now.ToLongTimeString()
                + " Plot #" + GraphPlotCount.ToString("D4")
                + " Initial stage: " + eGraphStartingPointLog.ToString()
                + " Avg time: " + AvgPlotTime.ToString("F3")                         + " ms"
                + " Total time: " + LastPlotTime.ToString("D3")                      + " ms\n"
                + "      Init time           : "  + InitTime.ToString("D2")          + " ms\n"
                + "      Frame time          : "  + FrameTime.ToString("D2")         + " ms\n"
                + "      Grid time           : "  + GridTime.ToString("D2")          + " ms\n"
                + "      X Axis line time    : "  + XAxisLineTime.ToString("D2")     + " ms\n"
                + "      Y Axis line time    : "  + YAxisLineTime.ToString("D2")     + " ms\n"
                + "      Y Axis values time  : "  + YAxisValueTime.ToString("D2")    + " ms\n"
                + "      Series options time : "  + SeriesOptionsTime.ToString("D2") + " ms\n"
                + "      X Axis options time : "  + XAxisOptionsTime.ToString("D2")  + " ms\n"
                + "      X Axis values time  : "  + XAxisValueTime.ToString("D2")    + " ms\n"
                + "      Series values time  : "  + SeriesValuesTime.ToString("D2")  + " ms\n");

            SR.WriteLine("");

            //Time measurements reset
            InitTime = 0;
            FrameTime = 0;
            GridTime = 0;
            XAxisLineTime = 0;
            YAxisLineTime = 0;
            YAxisValueTime = 0;
            SeriesOptionsTime = 0;
            XAxisOptionsTime = 0;
            XAxisValueTime = 0;
            SeriesValuesTime = 0;

            SR.Close();
            SR.Dispose();
#endif
        }

        #endregion

        #region Drawing stages

        private void Init_DrawingStages()
        {
            string[] eStageNames = Enum.GetNames(typeof(GraphDrawingStages));
            DrawingStages = new GraphicDrawingStage[eStageNames.Length - 1];

            int StageId = 0;

            for (int iStage = 1; iStage < eStageNames.Length; iStage++)
            {
                DrawingStages[StageId] = new GraphicDrawingStage();
                DrawingStages[StageId].DrawingStage = (GraphDrawingStages)iStage;
                StageId++;
            }
        }

        private void DrawGraphFromStage(GraphDrawingStages InitialStage)
        {

#if DEBUG
            Stopwatch swTimer = new Stopwatch();
            eGraphStartingPointLog = InitialStage;
#endif

            if (Pic_GraphFrame.Width == 0 || Pic_GraphFrame.Height == 0)
            {
                return;
            }

            #region Local variables

            Graphics FrameGraphics;
            Graphics GraphGraphics;

            int StageIndex = (int)InitialStage - 1;

            Pen oPen = null;
            SolidBrush oBrush = null;

            #endregion

#if DEBUG
            swTimer.Start();
#endif

            if (InitialStage != GraphDrawingStages.Scratch)
            {
                //TODO: Is Graphics.DrawBitmap faster ?
                FrameImage = (Bitmap)DrawingStages[StageIndex].InitialFrameImage.Clone();
                GraphImage = (Bitmap)DrawingStages[StageIndex].InitialGraphImage.Clone();

                FrameGraphics = Graphics.FromImage(FrameImage);
                GraphGraphics = Graphics.FromImage(GraphImage);

                switch (InitialStage)
                {
                    case GraphDrawingStages.Frame:

                        goto FrameDrawingStage;

                    case GraphDrawingStages.Grid:

                        goto GridDrawingStage;

                    case GraphDrawingStages.XAxis_Lines:

                        goto XAxisLinesDrawingStage;

                    case GraphDrawingStages.YAxis_Lines:

                        goto YAxisLinesDrawingStage;

                    case GraphDrawingStages.YAxis_Values:

                        goto YAxisValuesDrawingStage;

                    case GraphDrawingStages.Series_Options:

                        goto SeriesOptionsDrawingStage;

                    case GraphDrawingStages.XAxis_Values:

                        goto XAxisValuesDrawingStage;

                    case GraphDrawingStages.XAxis_Options:

                        goto XAxisOptionsDrawingStage;

                    case GraphDrawingStages.Series_Values:

                        goto SeriesValuesDrawingStage;
                }
            }

            #region Initialization

            Init_GraphWindow();

            Init_DrawingStages();
            StageIndex = 0;

            FrameImage = new Bitmap(Pic_GraphFrame.Width, Pic_GraphFrame.Height);
            GraphImage = new Bitmap(Pic_Graphic.Width, Pic_Graphic.Height);

            FrameGraphics = Graphics.FromImage(FrameImage);
            GraphGraphics = Graphics.FromImage(GraphImage);

            #endregion

#if DEBUG
            InitTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region Frame drawing

            FrameDrawingStage: //Graphic frmame drawing

            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;

            oPen = new Pen(Properties.Frame.BorderColor, (float)Properties.Frame.BorderWidth);
            oPen.DashStyle = DashStyle.Solid;

            FrameGraphics.DrawRectangle(oPen, FrameLeftPoint, FrameTopPoint, FrameWidth, FrameHeight);

            #endregion

#if DEBUG
            FrameTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region Grid drawing

            GridDrawingStage: //Graphic grids drawing
            
            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;

            //Main horizontal grid
            if (Properties.Grid.MainHorizontalGrid.Visible)
            {
                oPen = new Pen(Properties.Grid.MainHorizontalGrid.LineColor, Properties.Grid.MainHorizontalGrid.LineWidth);
                oPen.DashStyle = Properties.Grid.MainHorizontalGrid.LineStyle;

                int hGridStep = (int)(FrameWidth / (HORIZONTAL_GRID_LINES_COUNT + 1));

                for (int i = 0; i < HORIZONTAL_GRID_LINES_COUNT; i++)
                {
                    GraphGraphics.DrawLine(oPen, (hGridStep * (i + 1)),
                                       0,
                                       (hGridStep * (i + 1)),
                                       Pic_Graphic.Height);
                }
            }

            //Main vertical grid
            if (Properties.Grid.MainVerticalGrid.Visible)
            {
                oPen = new Pen(Properties.Grid.MainVerticalGrid.LineColor, Properties.Grid.MainVerticalGrid.LineWidth);
                oPen.DashStyle = Properties.Grid.MainVerticalGrid.LineStyle;

                int vGridStep = (int)(FrameHeight / (VERTICAL_GRID_LINES_COUNT + 1));

                for (int i = 0; i < VERTICAL_GRID_LINES_COUNT; i++)
                {
                    GraphGraphics.DrawLine(oPen, 0,
                                       (vGridStep * (i + 1)),
                                       Pic_Graphic.Width,
                                       (vGridStep * (i + 1)));
                }
            }

            //Secondary horizontal grid
            if (Properties.Grid.SecondaryHorizontalGrid.Visible)
            {
                oPen = new Pen(Properties.Grid.SecondaryHorizontalGrid.LineColor, Properties.Grid.SecondaryHorizontalGrid.LineWidth);
                oPen.DashStyle = Properties.Grid.SecondaryHorizontalGrid.LineStyle;

                int hGridStep = (int)(FrameWidth / (SEC_H_GRID_LINES_COUNT + 1));

                for (int i = 0; i < SEC_H_GRID_LINES_COUNT; i++)
                {
                    GraphGraphics.DrawLine(oPen, (hGridStep * (i + 1)),
                                       0,
                                       (hGridStep * (i + 1)),
                                       Pic_Graphic.Height);
                }
            }

            //Secondary vertical grid
            if (Properties.Grid.SecondaryVerticalGrid.Visible)
            {
                oPen = new Pen(Properties.Grid.SecondaryVerticalGrid.LineColor, Properties.Grid.SecondaryVerticalGrid.LineWidth);
                oPen.DashStyle = Properties.Grid.SecondaryVerticalGrid.LineStyle;

                int vGridStep = (int)(FrameHeight / (SEC_V_GRID_LINES_COUNT + 1));

                for (int i = 0; i < SEC_V_GRID_LINES_COUNT; i++)
                {
                    GraphGraphics.DrawLine(oPen, 0,
                                       (vGridStep * (i + 1)),
                                       Pic_Graphic.Width,
                                       (vGridStep * (i + 1)));
                }
            }

            #endregion

#if DEBUG
            GridTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region X Axis lines

            XAxisLinesDrawingStage: //Axis X line and graduations drawing

            //TOOD: Remove old code
            //DrawingStages[StageIndex].InitialFrameState = FrameGraphics.Save();
            //DrawingStages[StageIndex].InitialGraphState = GraphGraphics.Save();

            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;

            if(Properties.AbscisseAxis.Visible && (Properties.AbscisseAxis.CoordConversion.Min != Properties.AbscisseAxis.CoordConversion.Max))
            {
                oPen = new Pen(Properties.AbscisseAxis.AxisLineStyle.LineColor, Properties.AbscisseAxis.AxisLineStyle.LineWidth);
                oPen.DashStyle = Properties.AbscisseAxis.AxisLineStyle.LineStyle;

                oAbscisseAxis = new GraphAxis();
                oAbscisseAxis.StartPos = FrameLeftPoint;
                oAbscisseAxis.EndPos = FrameRightPoint;

                oAbscisseAxis.Set_AxisGraduations(FrameWidth, 0);

                int AxisPos = FrameBottomPoint + AXIS_BASE_POS;

                //Main abscisse axis line drawing
                FrameGraphics.DrawLine(oPen, FrameLeftPoint, AxisPos, FrameRightPoint, AxisPos);

                if (oAbscisseAxis.Graduations != null)
                {
                    int GradEndPos = AxisPos + (AXIS_BASE_SIZE * (int)Properties.AbscisseAxis.AxisLineStyle.LineWidth);

                    foreach (AxisGraduation oGrad in oAbscisseAxis.Graduations)
                    {
                        FrameGraphics.DrawLine(oPen, oGrad.Position, AxisPos, oGrad.Position, GradEndPos);
                    }
                }
            }

            #endregion

#if DEBUG
            XAxisLineTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region Y Axis lines

            YAxisLinesDrawingStage: //Series Y Axis lines and graduations drawing
            
            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;

            //Legend initialisation
            this.BeginInvoke(this.InitLegendDelegate);

            if (DataFile != null && SeriesVisibleCount > 0)
            {
                foreach (GraphSerieProperties oSerieProps in Properties.SeriesProperties)
                {
                    if(oSerieProps.Visible && (oSerieProps.Trace.Visible || oSerieProps.Markers.Visible))
                    {
                        //Serie Y Axis
                        if (oSerieProps.YAxis.Visible)
                        {
                            object[] oAxisInfos = oYAxis.Get_AxisInfos(oSerieProps.KeyId);

                            if (oAxisInfos != null)
                            {
                                GraphAxis oAxis = (GraphAxis)oAxisInfos[0];
                                int AxisPos = FrameLeftPoint - AXIS_BASE_POS - (int)oAxisInfos[1];

                                oPen = new Pen(oSerieProps.YAxis.AxisLineStyle.LineColor, oSerieProps.YAxis.AxisLineStyle.LineWidth);
                                oPen.DashStyle = oSerieProps.YAxis.AxisLineStyle.LineStyle;

                                oAxis.Set_AxisGraduations(FrameHeight, FrameTopPoint);

                                //Main axis line drawing
                                FrameGraphics.DrawLine(oPen, AxisPos, oAxis.StartPos, AxisPos, oAxis.EndPos);

                                //Graduations drawing
                                if (oAxis.Graduations != null)
                                {
                                    int GradEndPos = AxisPos - (AXIS_BASE_SIZE * (int)oSerieProps.YAxis.AxisLineStyle.LineWidth);

                                    foreach (AxisGraduation oGrad in oAxis.Graduations)
                                    {
                                        FrameGraphics.DrawLine(oPen, AxisPos, oGrad.Position, GradEndPos, oGrad.Position);
                                    }
                                }

                                //Axis title drawing
                                if (oSerieProps.YAxis.AxisTitleVisible)
                                {
                                    if (!(oSerieProps.Label.Equals("")))
                                    {
                                        oBrush = new SolidBrush(oSerieProps.YAxis.AxisLineStyle.LineColor);

                                        StringFormat sFormat = new StringFormat();
                                        sFormat.FormatFlags |= StringFormatFlags.DirectionVertical;
                                        sFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;

                                        SizeF TitleSize = FrameGraphics.MeasureString(oSerieProps.Label, oSerieProps.YAxis.AxisValuesFont.oFont, new PointF(0, 0), sFormat);
                                        PointF pTitle = new PointF(AxisPos - oAxis.TitleLeft, oAxis.StartPos + (((oAxis.EndPos - oAxis.StartPos) - TitleSize.Height) / 2));

                                        FrameGraphics.DrawString(oSerieProps.Label, oSerieProps.YAxis.AxisValuesFont.oFont, oBrush, pTitle, sFormat);
                                    }
                                }
                            }
                        }

                        //Serie legend item
                        if (Properties.LegendProperties.Visible)
                        {
                            GW_DataChannel oSerieData = DataFile.Get_DataChannelByKeyId(oSerieProps.DataChannelKeyId);

                            if (oSerieData != null)
                            {
                                LegendItemData oLegendData = new LegendItemData();

                                oLegendData.ItemProperties = oSerieProps;

                                if (DataFile.DataSamplingMode == SamplingMode.MultipleRates)
                                {
                                    oLegendData.CurrentValue = oSerieData.Samples[0].SampleValue;
                                }
                                else
                                {
                                    oLegendData.CurrentValue = oSerieData.Values[0];
                                }

                                oLegendData.Min = oSerieData.Min;
                                oLegendData.Max = oSerieData.Max;
                                oLegendData.Avg = oSerieData.Avg;

                                this.BeginInvoke(this.AddLegendItemDelegate, new object[] { oLegendData });
                            }
                        }
                    }
                }
            }

            #endregion

#if DEBUG
            YAxisLineTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region Y Axis values

            YAxisValuesDrawingStage: //Series Y Axis graduations values drawing
            
            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;

            if (DataFile != null && SeriesVisibleCount > 0)
            {
                foreach (GraphSerieProperties oSerieProps in Properties.SeriesProperties)
                {
                    if (oSerieProps.Visible && (oSerieProps.Trace.Visible || oSerieProps.Markers.Visible) && oSerieProps.YAxis.Visible)
                    {
                        object[] oAxisInfos = oYAxis.Get_AxisInfos(oSerieProps.KeyId);

                        if (oAxisInfos != null)
                        {
                            GraphAxis oAxis = (GraphAxis)oAxisInfos[0];
                            int AxisPos = FrameLeftPoint - AXIS_BASE_POS - (int)oAxisInfos[1];

                            if (oAxis.Graduations != null && oSerieProps.YAxis.AxisValuesVisible)
                            {
                                oBrush = new SolidBrush(oSerieProps.YAxis.AxisLineStyle.LineColor);

                                oAxis.Set_GraduationsValues(oSerieProps.CoordConversion.Min,
                                                            oSerieProps.CoordConversion.Max,
                                                            oSerieProps.ValueFormat, false);

                                int GradEndPos = AxisPos - (AXIS_BASE_SIZE * (int)oSerieProps.YAxis.AxisLineStyle.LineWidth);

                                for (int iGrad = 0; iGrad < oAxis.Graduations.Length; iGrad++)
                                {
                                    SizeF sGradTxt = FrameGraphics.MeasureString(oAxis.Graduations[iGrad].Value, oSerieProps.YAxis.AxisValuesFont.oFont);
                                    PointF pGradTxt = new PointF();

                                    pGradTxt.X = (float)(GradEndPos - AXIS_TEXT_POS_OFFSET) - sGradTxt.Width;

                                    if (iGrad == 0) //First graduation
                                    {
                                        pGradTxt.Y = (float)(oAxis.Graduations[iGrad].Position);
                                    }
                                    else if (iGrad == oAxis.Graduations.Length - 1) //Last graduation
                                    {
                                        pGradTxt.Y = (float)(oAxis.Graduations[iGrad].Position) - sGradTxt.Height;
                                    }
                                    else //General case
                                    {
                                        pGradTxt.Y = (float)(oAxis.Graduations[iGrad].Position) - (sGradTxt.Height / 2);
                                    }

                                    FrameGraphics.DrawString(oAxis.Graduations[iGrad].Value, oSerieProps.YAxis.AxisValuesFont.oFont, oBrush, pGradTxt);
                                }
                            }
                        }
                    }
                }
            }

            #endregion

#if DEBUG
            YAxisValueTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region Series Options

            SeriesOptionsDrawingStage: //Series options (custom grids, reference lines) drawing
            
            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;

            if (DataFile != null && SeriesVisibleCount > 0)
            {
                foreach (GraphSerieProperties oSerieProps in Properties.SeriesProperties)
                {
                    if (oSerieProps.Visible && (oSerieProps.Trace.Visible || oSerieProps.Markers.Visible))
                    {
                        #region Serie user grid

                        #region Vertical grid

                        if (oSerieProps.UserGrid.VerticalLinesStyle.Visible)
                        {
                            oPen = new Pen(oSerieProps.UserGrid.VerticalLinesStyle.LineColor, oSerieProps.UserGrid.VerticalLinesStyle.LineWidth);
                            oPen.DashStyle = oSerieProps.UserGrid.VerticalLinesStyle.LineStyle;

                            oBrush = new SolidBrush(oSerieProps.UserGrid.VerticalLinesStyle.LineColor);

                            double[] GridValues = null;

                            switch (oSerieProps.UserGrid.VerticalGridMode)
                            {
                                case GraphSerieUserGridModes.Even:

                                    if (oSerieProps.UserGrid.VerticalDivisionCount > 1)
                                    {
                                        GridValues = new double[oSerieProps.UserGrid.VerticalDivisionCount - 1];

                                        double vGridStep = (double)((DataFile.Time.Max - DataFile.Time.Min) / (oSerieProps.UserGrid.VerticalDivisionCount));

                                        for (int i = 0; i < oSerieProps.UserGrid.VerticalDivisionCount - 1; i++)
                                        {
                                            GridValues[i] = Properties.AbscisseAxis.CoordConversion.Min + (vGridStep * (i + 1));
                                        }

                                    }

                                    break;

                                case GraphSerieUserGridModes.CustomValues:

                                    if (oSerieProps.UserGrid.VerticalCustomValues.Count > 0)
                                    {
                                        GridValues = oSerieProps.UserGrid.VerticalCustomValues.ToArray();

                                    }

                                    break;
                            }

                            if (GridValues != null)
                            {
                                foreach (double Val in GridValues)
                                {
                                    int ValAbs = (int)(Val * Properties.AbscisseAxis.CoordConversion.Gain + Properties.AbscisseAxis.CoordConversion.Zero);

                                    if (ValAbs >= 0 && ValAbs <= FrameWidth)
                                    {
                                        GraphGraphics.DrawLine(oPen, ValAbs, oSerieProps.CoordConversion.Top, ValAbs, oSerieProps.CoordConversion.Bottom);

                                        if (oSerieProps.UserGrid.VerticalGridValuesVisible)
                                        {
                                            string sVal = oSerieProps.ValueFormat.Get_ValueFormatted(Val);

                                            SizeF sValTxt = GraphGraphics.MeasureString(sVal, oSerieProps.UserGrid.VerticalGridValueFont.oFont);

                                            PointF pValTxt = new PointF((float)(ValAbs - 5) - sValTxt.Width,
                                                                        (float)(oSerieProps.CoordConversion.Top) + sValTxt.Height);

                                            if (pValTxt.X > 0)
                                            {
                                                GraphGraphics.DrawString(sVal, oSerieProps.UserGrid.VerticalGridValueFont.oFont, oBrush, pValTxt);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Horizontal grid

                        if (oSerieProps.UserGrid.HorizontalLinesStyle.Visible)
                        {
                            oPen = new Pen(oSerieProps.UserGrid.HorizontalLinesStyle.LineColor, oSerieProps.UserGrid.HorizontalLinesStyle.LineWidth);
                            oPen.DashStyle = oSerieProps.UserGrid.HorizontalLinesStyle.LineStyle;

                            oBrush = new SolidBrush(oSerieProps.UserGrid.HorizontalLinesStyle.LineColor);

                            double[] GridValues = null;

                            switch (oSerieProps.UserGrid.HorizontalGridMode)
                            {
                                case GraphSerieUserGridModes.Even:

                                    if (oSerieProps.UserGrid.HorizontalDivisionCount > 1)
                                    {
                                        GridValues = new double[oSerieProps.UserGrid.HorizontalDivisionCount + 1];

                                        double hGridStep = (double)((oSerieProps.CoordConversion.Max - oSerieProps.CoordConversion.Min) / (oSerieProps.UserGrid.HorizontalDivisionCount));

                                        for (int i = 0; i < oSerieProps.UserGrid.HorizontalDivisionCount + 1; i++)
                                        {
                                            GridValues[i] = oSerieProps.CoordConversion.Min + (hGridStep * i);
                                        }

                                    }

                                    break;

                                case GraphSerieUserGridModes.MinMaxAvg:

                                    {
                                        GW_DataChannel oSerieData = DataFile.Get_DataChannelByKeyId(oSerieProps.DataChannelKeyId);

                                        if (oSerieData != null)
                                        {
                                            GridValues = new double[3];
                                            GridValues[0] = oSerieData.Min;
                                            GridValues[1] = oSerieData.Avg;
                                            GridValues[2] = oSerieData.Max;
                                        }
                                    }

                                    break;

                                case GraphSerieUserGridModes.MinMaxZero:

                                    {
                                        GW_DataChannel oSerieData = DataFile.Get_DataChannelByKeyId(oSerieProps.DataChannelKeyId);

                                        if (oSerieData != null)
                                        {
                                            GridValues = new double[3];
                                            GridValues[0] = oSerieData.Min;
                                            GridValues[1] = 0;
                                            GridValues[2] = oSerieData.Max;
                                        }
                                    }

                                    break;

                                case GraphSerieUserGridModes.CustomValues:

                                    if (oSerieProps.UserGrid.VerticalCustomValues.Count > 0)
                                    {
                                        GridValues = oSerieProps.UserGrid.VerticalCustomValues.ToArray();

                                    }

                                    break;
                            }

                            if (GridValues != null)
                            {
                                foreach (double Val in GridValues)
                                {
                                    int ValOrd = (int)(Val * oSerieProps.CoordConversion.Gain + oSerieProps.CoordConversion.Zero);

                                    if (ValOrd >= 0 && ValOrd <= FrameHeight)
                                    {
                                        GraphGraphics.DrawLine(oPen, 0, ValOrd, FrameWidth, ValOrd);

                                        if (oSerieProps.UserGrid.HorizontalGridValuesVisible)
                                        {
                                            string sVal = oSerieProps.ValueFormat.Get_ValueFormatted(Val);

                                            PointF pValTxt = new PointF(5, (ValOrd + oSerieProps.UserGrid.HorizontalLinesStyle.LineWidth + 1));

                                            if (pValTxt.Y > 0 && pValTxt.Y < (float)FrameHeight)
                                            {
                                                GraphGraphics.DrawString(sVal, oSerieProps.UserGrid.HorizontalGridValueFont.oFont, oBrush, pValTxt);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        #endregion

                        #region Serie reference lines

                        if (oSerieProps.ReferenceLines.Count > 0)
                        {
                            GW_DataChannel oSerieData = DataFile.Get_DataChannelByKeyId(oSerieProps.DataChannelKeyId);

                            if (oSerieData != null)
                            {
                                foreach (GraphReferenceLine oLine in oSerieProps.ReferenceLines)
                                {
                                    if (oLine.Visible)
                                    {
                                        int LineOrd = 0;
                                        string sLineVal = "";

                                        switch (oLine.ReferenceMode)
                                        {
                                            case GraphSerieReferenceLineModes.Average:

                                                LineOrd = (int)(oSerieData.Avg * oSerieProps.CoordConversion.Gain + oSerieProps.CoordConversion.Zero);
                                                sLineVal = oSerieProps.ValueFormat.Get_ValueFormatted(oSerieData.Avg);
                                                break;

                                            case GraphSerieReferenceLineModes.Custom:

                                                LineOrd = (int)(oLine.ReferenceValue * oSerieProps.CoordConversion.Gain + oSerieProps.CoordConversion.Zero);
                                                sLineVal = oSerieProps.ValueFormat.Get_ValueFormatted(oLine.ReferenceValue);
                                                break;

                                            case GraphSerieReferenceLineModes.Max:

                                                LineOrd = (int)(oSerieData.Max * oSerieProps.CoordConversion.Gain + oSerieProps.CoordConversion.Zero);
                                                sLineVal = oSerieProps.ValueFormat.Get_ValueFormatted(oSerieData.Max);
                                                break;

                                            case GraphSerieReferenceLineModes.Min:

                                                LineOrd = (int)(oSerieData.Min * oSerieProps.CoordConversion.Gain + oSerieProps.CoordConversion.Zero);
                                                sLineVal = oSerieProps.ValueFormat.Get_ValueFormatted(oSerieData.Min);
                                                break;

                                            case GraphSerieReferenceLineModes.Zero:

                                                LineOrd = (int)(0 * oSerieProps.CoordConversion.Gain + oSerieProps.CoordConversion.Zero);
                                                sLineVal = oSerieProps.ValueFormat.Get_ValueFormatted(0);
                                                break;

                                            default:

                                                LineOrd = -1;
                                                break;
                                        }

                                        if (LineOrd >= oSerieProps.CoordConversion.Top && LineOrd <= oSerieProps.CoordConversion.Bottom)
                                        {
                                            oPen = new Pen(oLine.ReferenceStyle.LineColor, oLine.ReferenceStyle.LineWidth);
                                            oPen.DashStyle = oLine.ReferenceStyle.LineStyle;

                                            //Line drawing
                                            GraphGraphics.DrawLine(oPen, 0, LineOrd, FrameWidth, LineOrd);

                                            //Reference line value and title drawing
                                            if(!(oLine.ReferenceValuePosition.Equals(ScreenPositions.Invisible) && oLine.ReferenceTitlePosition.Equals(ScreenPositions.Invisible) && oLine.ReferenceTitle.Equals("")))
                                            {
                                                oBrush = new SolidBrush(oLine.ReferenceStyle.LineColor);

                                                PointF pValTxt = new PointF(0, 0);

                                                //Check user setting for value position (top & bottom forbidden for serie reference line)
                                                ScreenPositions ValPos = oLine.ReferenceValuePosition;
                                                if (ValPos.Equals(ScreenPositions.Top) || ValPos.Equals(ScreenPositions.Bottom))
                                                {
                                                    ValPos = ScreenPositions.Center;
                                                }

                                                //Check user setting for title position (top & bottom forbidden for serie reference line)
                                                ScreenPositions TitlePos = oLine.ReferenceTitlePosition;
                                                if (TitlePos.Equals(ScreenPositions.Top) || TitlePos.Equals(ScreenPositions.Bottom))
                                                {
                                                    TitlePos = ScreenPositions.Center;
                                                }

                                                if (ValPos == TitlePos) //Both title and value have the same location
                                                {
                                                    //Title and value strings concatenation
                                                    if (!oLine.ReferenceTitle.Equals(""))
                                                    {
                                                        string s = sLineVal;
                                                        sLineVal = oLine.ReferenceTitle + " " + s;
                                                    }

                                                    SizeF RefTxtSize = GraphGraphics.MeasureString(sLineVal, oLine.ReferenceValueFont.oFont);

                                                    //Text written on top of the reference line if reference line is drawn under 2 times REF_LINE_TEXT_POS_OFFSET
                                                    //Otherwise it is written on the bottom of the reference line
                                                    if (((float)LineOrd - RefTxtSize.Height) > (float)REF_LINE_TEXT_POS_OFFSET * 2)
                                                    {
                                                        pValTxt.Y = (float)(LineOrd - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Height;
                                                    }
                                                    else
                                                    {
                                                        pValTxt.Y = (float)(LineOrd + REF_LINE_TEXT_POS_OFFSET);
                                                    }

                                                    switch (ValPos)
                                                    {
                                                        case ScreenPositions.Left:

                                                            pValTxt.X = (float)REF_LINE_TEXT_POS_OFFSET;
                                                            break;

                                                        case ScreenPositions.Right:

                                                            pValTxt.X = (float)(FrameWidth - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Width;
                                                            break;

                                                        case ScreenPositions.Center:

                                                            pValTxt.X = ((float)FrameWidth / 2) - (RefTxtSize.Width / 2);
                                                            break;
                                                    }

                                                    GraphGraphics.DrawString(sLineVal, oLine.ReferenceValueFont.oFont, oBrush, pValTxt);
                                                }
                                                else
                                                {
                                                    if (!ValPos.Equals(ScreenPositions.Invisible))
                                                    {
                                                        SizeF RefTxtSize = GraphGraphics.MeasureString(sLineVal, oLine.ReferenceValueFont.oFont);

                                                        //Text written on top of the reference line if reference line is drawn under 2 times REF_LINE_TEXT_POS_OFFSET
                                                        //Otherwise it is written on the bottom of the reference line
                                                        if (((float)LineOrd - RefTxtSize.Height) > (float)REF_LINE_TEXT_POS_OFFSET * 2)
                                                        {
                                                            pValTxt.Y = (float)(LineOrd - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Height;
                                                        }
                                                        else
                                                        {
                                                            pValTxt.Y = (float)(LineOrd + REF_LINE_TEXT_POS_OFFSET);
                                                        }

                                                        switch (ValPos)
                                                        {
                                                            case ScreenPositions.Left:

                                                                pValTxt.X = (float)REF_LINE_TEXT_POS_OFFSET;
                                                                break;

                                                            case ScreenPositions.Right:

                                                                pValTxt.X = (float)(FrameWidth - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Width;
                                                                break;

                                                            case ScreenPositions.Center:

                                                                pValTxt.X = ((float)FrameWidth / 2) - (RefTxtSize.Width / 2);
                                                                break;
                                                        }

                                                        GraphGraphics.DrawString(sLineVal, oLine.ReferenceValueFont.oFont, oBrush, pValTxt);
                                                    }

                                                    if (!(TitlePos.Equals(ScreenPositions.Invisible) || oLine.ReferenceTitle.Equals("")))
                                                    {
                                                        pValTxt = PointF.Empty;

                                                        SizeF RefTxtSize = GraphGraphics.MeasureString(oLine.ReferenceTitle, oLine.ReferenceValueFont.oFont);

                                                        //Text written on top of the reference line if reference line is drawn under 2 times REF_LINE_TEXT_POS_OFFSET
                                                        //Otherwise it is written on the bottom of the reference line
                                                        if (((float)LineOrd - RefTxtSize.Height) > (float)REF_LINE_TEXT_POS_OFFSET * 2)
                                                        {
                                                            pValTxt.Y = (float)(LineOrd - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Height;
                                                        }
                                                        else
                                                        {
                                                            pValTxt.Y = (float)(LineOrd + REF_LINE_TEXT_POS_OFFSET);
                                                        }

                                                        switch (TitlePos)
                                                        {
                                                            case ScreenPositions.Left:

                                                                pValTxt.X = (float)REF_LINE_TEXT_POS_OFFSET;
                                                                break;

                                                            case ScreenPositions.Right:

                                                                pValTxt.X = (float)(FrameWidth - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Width;
                                                                break;

                                                            case ScreenPositions.Center:

                                                                pValTxt.X = ((float)FrameWidth / 2) - (RefTxtSize.Width / 2);
                                                                break;
                                                        }

                                                        GraphGraphics.DrawString(oLine.ReferenceTitle, oLine.ReferenceValueFont.oFont, oBrush, pValTxt);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion
                    }
                }
            }

            #endregion

#if DEBUG
            SeriesOptionsTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region X Axis options

            XAxisOptionsDrawingStage: //X Axis options (reference lines) drawing
            
            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;

            //Abscisse reference lines
            foreach (GraphReferenceLine oRefLine in Properties.AbscisseAxis.ReferenceLines)
            {
                if (oRefLine.Visible)
                {
                    int LineAbcsisse = 0;
                    string sLineVal = "";

                    switch (oRefLine.ReferenceMode)
                    {
                        case GraphSerieReferenceLineModes.Average:

                            LineAbcsisse = (int)(Properties.AbscisseAxis.CoordConversion.Gain * oAbcsisseChannel.Avg + Properties.AbscisseAxis.CoordConversion.Zero);
                            sLineVal = oAbcisseValFormat.Get_ValueFormatted(oAbcsisseChannel.Avg);
                            break;

                        case GraphSerieReferenceLineModes.Custom:

                            LineAbcsisse = (int)(Properties.AbscisseAxis.CoordConversion.Gain * oRefLine.ReferenceValue + Properties.AbscisseAxis.CoordConversion.Zero);
                            sLineVal = oAbcisseValFormat.Get_ValueFormatted(oRefLine.ReferenceValue);
                            break;

                        case GraphSerieReferenceLineModes.Max:

                            LineAbcsisse = (int)(Properties.AbscisseAxis.CoordConversion.Gain * oAbcsisseChannel.Max + Properties.AbscisseAxis.CoordConversion.Zero);
                            sLineVal = oAbcisseValFormat.Get_ValueFormatted(oAbcsisseChannel.Max);
                            break;

                        case GraphSerieReferenceLineModes.Min:

                            LineAbcsisse = (int)(Properties.AbscisseAxis.CoordConversion.Gain * oAbcsisseChannel.Min + Properties.AbscisseAxis.CoordConversion.Zero);
                            sLineVal = oAbcisseValFormat.Get_ValueFormatted(oAbcsisseChannel.Min);
                            break;

                        case GraphSerieReferenceLineModes.Zero:

                            LineAbcsisse = (int)(Properties.AbscisseAxis.CoordConversion.Gain * 0 + Properties.AbscisseAxis.CoordConversion.Zero);
                            sLineVal = oAbcisseValFormat.Get_ValueFormatted(0);
                            break;

                        default:

                            LineAbcsisse = -1;
                            break;
                    }

                    if (LineAbcsisse >= FrameLeftPoint && LineAbcsisse <= FrameRightPoint)
                    {
                        oPen = new Pen(oRefLine.ReferenceStyle.LineColor, oRefLine.ReferenceStyle.LineWidth);
                        oPen.DashStyle = oRefLine.ReferenceStyle.LineStyle;

                        //Reference line drawing
                        GraphGraphics.DrawLine(oPen, LineAbcsisse, 0, LineAbcsisse, FrameHeight);

                        //Reference line value and title drawing
                        if (!(oRefLine.ReferenceValuePosition.Equals(ScreenPositions.Invisible) && oRefLine.ReferenceTitlePosition.Equals(ScreenPositions.Invisible) && oRefLine.ReferenceTitle.Equals("")))
                        {
                            oBrush = new SolidBrush(oRefLine.ReferenceStyle.LineColor);
                            PointF pRefTxt = PointF.Empty;

                            //Check user setting for value position (left & right forbidden for abscisse reference line)
                            ScreenPositions ValPos = oRefLine.ReferenceValuePosition;
                            if (ValPos.Equals(ScreenPositions.Left) || ValPos.Equals(ScreenPositions.Right))
                            {
                                ValPos = ScreenPositions.Center;
                            }

                            //Check user setting for title position (left & right forbidden for abscisse reference line)
                            ScreenPositions TitlePos = oRefLine.ReferenceTitlePosition;
                            if (TitlePos.Equals(ScreenPositions.Left) || TitlePos.Equals(ScreenPositions.Right))
                            {
                                TitlePos = ScreenPositions.Center;
                            }

                            if (ValPos == TitlePos) //Both title and value have the same location
                            {
                                //Title and value strings concatenation
                                if (!oRefLine.ReferenceTitle.Equals(""))
                                {
                                    string s = sLineVal;
                                    sLineVal = oRefLine.ReferenceTitle + " " + s;
                                }

                                SizeF RefTxtSize = GraphGraphics.MeasureString(sLineVal, oRefLine.ReferenceValueFont.oFont);

                                //Text written on left of the reference line if reference line is drawn beyond the middle of the frame
                                //Otherwise it is written on the right of the reference line
                                if (LineAbcsisse > (FrameWidth / 2))
                                {
                                    pRefTxt.X = (float)(LineAbcsisse - RefTxtSize.Width - REF_LINE_TEXT_POS_OFFSET);
                                }
                                else
                                {
                                    pRefTxt.X = (float)(LineAbcsisse + REF_LINE_TEXT_POS_OFFSET);
                                }

                                switch (ValPos)
                                {
                                    case ScreenPositions.Center:

                                        pRefTxt.Y = (float)(FrameHeight / 2) - (RefTxtSize.Height / 2);
                                        break;

                                    case ScreenPositions.Top:

                                        pRefTxt.Y = (float)REF_LINE_TEXT_POS_OFFSET;
                                        break;

                                    case ScreenPositions.Bottom:

                                        pRefTxt.Y = (float)(FrameHeight - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Height;
                                        break;
                                }

                                GraphGraphics.DrawString(sLineVal, oRefLine.ReferenceValueFont.oFont, oBrush, pRefTxt);
                            }
                            else //Title and value have different position
                            {
                                //Reference line value drawing
                                if (!ValPos.Equals(ScreenPositions.Invisible))
                                {
                                    SizeF RefTxtSize = GraphGraphics.MeasureString(sLineVal, oRefLine.ReferenceValueFont.oFont);

                                    //Text written on left of the reference line if reference line is drawn beyond the middle of the frame
                                    //Otherwise it is written on the right of the reference line
                                    if (LineAbcsisse > (FrameWidth / 2))
                                    {
                                        pRefTxt.X = (float)(LineAbcsisse - RefTxtSize.Width - REF_LINE_TEXT_POS_OFFSET);
                                    }
                                    else
                                    {
                                        pRefTxt.X = (float)(LineAbcsisse + REF_LINE_TEXT_POS_OFFSET);
                                    }

                                    switch (ValPos)
                                    {
                                        case ScreenPositions.Center:

                                            pRefTxt.Y = (float)(FrameHeight / 2) - (RefTxtSize.Height / 2);
                                            break;

                                        case ScreenPositions.Top:

                                            pRefTxt.Y = (float)REF_LINE_TEXT_POS_OFFSET;
                                            break;

                                        case ScreenPositions.Bottom:

                                            pRefTxt.Y = pRefTxt.Y = (float)(FrameHeight - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Height;
                                            break;
                                    }

                                    GraphGraphics.DrawString(sLineVal, oRefLine.ReferenceValueFont.oFont, oBrush, pRefTxt);
                                }

                                //Reference line title drawing
                                if (!(TitlePos.Equals(ScreenPositions.Invisible) || oRefLine.ReferenceTitle.Equals("")))
                                {
                                    pRefTxt = PointF.Empty;

                                    SizeF RefTxtSize = GraphGraphics.MeasureString(oRefLine.ReferenceTitle, oRefLine.ReferenceValueFont.oFont);

                                    //Text written on left of the reference line if reference line is drawn beyond the middle of the frame
                                    //Otherwise it is written on the right of the reference line
                                    if (LineAbcsisse > (FrameLeftPoint + (FrameWidth / 2)))
                                    {
                                        pRefTxt.X = (float)(LineAbcsisse - RefTxtSize.Width - REF_LINE_TEXT_POS_OFFSET);
                                    }
                                    else
                                    {
                                        pRefTxt.X = (float)(LineAbcsisse + REF_LINE_TEXT_POS_OFFSET);
                                    }

                                    switch (TitlePos)
                                    {
                                        case ScreenPositions.Center:

                                            pRefTxt.Y = (float)(FrameHeight / 2) - (RefTxtSize.Height / 2);
                                            break;

                                        case ScreenPositions.Top:

                                            pRefTxt.Y = (float)REF_LINE_TEXT_POS_OFFSET;
                                            break;

                                        case ScreenPositions.Bottom:

                                            pRefTxt.Y = pRefTxt.Y = (float)(FrameHeight - REF_LINE_TEXT_POS_OFFSET) - RefTxtSize.Height;
                                            break;
                                    }

                                    GraphGraphics.DrawString(oRefLine.ReferenceTitle, oRefLine.ReferenceValueFont.oFont, oBrush, pRefTxt);
                                }
                            }
                        }
                    }
                }
            }

            #endregion

#if DEBUG
            XAxisOptionsTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region X Axis values

            XAxisValuesDrawingStage: //X Axis graduation values drawing
            
            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;

            if (Properties.AbscisseAxis.Visible && (Properties.AbscisseAxis.CoordConversion.Min != Properties.AbscisseAxis.CoordConversion.Max))
            {
                //Graduation value
                if (oAbscisseAxis.Graduations != null && Properties.AbscisseAxis.AxisValuesVisible)
                {
                    oAbscisseAxis.Set_GraduationsValues(Properties.AbscisseAxis.CoordConversion.Min,
                                                        Properties.AbscisseAxis.CoordConversion.Max,
                                                        oAbcisseValFormat, true);
                                                        

                    int AxisPos = FrameBottomPoint + AXIS_BASE_POS;

                    oBrush = new SolidBrush(Properties.AbscisseAxis.AxisLineStyle.LineColor);

                    foreach (AxisGraduation oGrad in oAbscisseAxis.Graduations)
                    {
                        int GradEndPos = AxisPos + (AXIS_BASE_SIZE * (int)Properties.AbscisseAxis.AxisLineStyle.LineWidth);

                        SizeF sGradTxt = FrameGraphics.MeasureString(oGrad.Value, Properties.AbscisseAxis.AxisValuesFont.oFont);

                        PointF pGradTxt = new PointF((float)oGrad.Position - sGradTxt.Width/2,
                                                     (float)(GradEndPos + AXIS_TEXT_POS_OFFSET));

                        FrameGraphics.DrawString(oGrad.Value, Properties.AbscisseAxis.AxisValuesFont.oFont, oBrush, pGradTxt);
                    }
                }
            }

            #endregion

#if DEBUG
            XAxisValueTime = swTimer.ElapsedMilliseconds;
            swTimer.Restart();
#endif

            #region Series values

            SeriesValuesDrawingStage: //Series values (trace and markers) drawing
            
            DrawingStages[StageIndex].InitialFrameImage = (Bitmap)FrameImage.Clone();
            DrawingStages[StageIndex].InitialGraphImage = (Bitmap)GraphImage.Clone();
            StageIndex++;
            
            if (DataFile != null && SeriesVisibleCount > 0)
            {
                //Sub sampling
                if (DataFile.DataSamplingMode == SamplingMode.SingleRate)
                {
                    Compute_SubSampling(oAbcsisseChannel.Values.Count);
                }

                bDataPlotted = true;

                int iSerie = 0;

                foreach (GraphSerieProperties oSerieProps in Properties.SeriesProperties)
                {
                    if (oSerieProps.Visible && (oSerieProps.Trace.Visible || oSerieProps.Markers.Visible) && oSerieProps.YAxis.Visible)
                    {
                        GW_DataChannel oSerieData = DataFile.Get_DataChannelByKeyId(oSerieProps.DataChannelKeyId);

                        if (oSerieData != null)
                        {
                            if ((!(double.IsNaN(oSerieProps.CoordConversion.Gain) || double.IsNaN(oSerieProps.CoordConversion.Zero))) && (oSerieData.DataItemsCount > 2))
                            {
                                //Sub sampling
                                if (DataFile.DataSamplingMode == SamplingMode.MultipleRates)
                                {
                                    Compute_SubSampling(oSerieData.Samples.Count);
                                }

                                //Trace points coords init
                                List<Point[]> SerieCoords = new List<Point[]>();
                                List<Point> PartialSerieCoords = new List<Point>();
                                int nVisiblePointCnt = 0;
                                double DblSampleIndex = 0;

                                //Marks objects init
                                #region Markers init

                                List<object> SerieMarksCoords = null;

                                int MarkerSize = MARKER_BASE_SIZE * oSerieProps.Markers.Size;
                                int Marker_Pos_Ofset = MarkerSize / 2;
                                bool bMark = true;

                                if (oSerieProps.Markers.Visible)
                                {
                                    SerieMarksCoords = new List<object>();
                                }

                                #endregion

                                #region Graphic points coordinates calculation

                                for (int iSample = 0; iSample < nSampleCount; iSample++)
                                {
                                    int iSampleIndex = (int)DblSampleIndex;
                                    DblSampleIndex += DblSampleStep;

                                    //Trace points coords computation 
                                    Point PtSample = Point.Empty;
                                    bool bPointValid = true;

                                    switch (DataFile.DataSamplingMode)
                                    {
                                        case SamplingMode.SingleRate:

                                            {
                                                int TmpY = (int)SATURA((oSerieData.Values[iSampleIndex]
                                                                * oSerieProps.CoordConversion.Gain
                                                                + oSerieProps.CoordConversion.Zero),
                                                                -100, FrameHeight + 100);

                                                PtSample = new Point(AbscisseCoords[iSampleIndex], TmpY);
                                            }
                                            break;

                                        case SamplingMode.MultipleRates:

                                            {
                                                int TmpX = (int)SATURA((oSerieData.Samples[iSampleIndex].SampleTime
                                                                        * Properties.AbscisseAxis.CoordConversion.Gain
                                                                        + Properties.AbscisseAxis.CoordConversion.Zero),
                                                                        -100, FrameWidth + 100);

                                                int TmpY = (int)SATURA((oSerieData.Samples[iSampleIndex].SampleValue
                                                                        * oSerieProps.CoordConversion.Gain
                                                                        + oSerieProps.CoordConversion.Zero),
                                                                        -100, FrameHeight + 100);

                                                PtSample = new Point(TmpX, TmpY);
                                            }

                                            break;
                                    }

                                    if ((PtSample.X < 0 && PtSample.X > FrameWidth)
                                                && ((PtSample.Y < oSerieProps.CoordConversion.Top || PtSample.Y > oSerieProps.CoordConversion.Bottom)
                                                    && (!(Properties.bAllowOverScaling || bYZoom))))
                                    {
                                        bPointValid = false;

                                        //Serie's samples set adding to sample set collection
                                        if (PartialSerieCoords.Count > 1) //Minimum 2 points to trace a line
                                        {
                                            SerieCoords.Add(PartialSerieCoords.ToArray());
                                        }

                                        PartialSerieCoords = new List<Point>();
                                    }
                                    else
                                    {
                                        nVisiblePointCnt++;
                                        PartialSerieCoords.Add(PtSample);
                                    }

                                    //Marks objects computation
                                    #region Markers points definition

                                    if (oSerieProps.Markers.Visible)
                                    {
                                        if (bPointValid)
                                        {
                                            if (bMark)
                                            {
                                                switch (oSerieProps.Markers.Style)
                                                {
                                                    case GraphSerieMarkerStyles.Square:

                                                        {
                                                            Rectangle RecMark = new Rectangle(PtSample.X - Marker_Pos_Ofset,
                                                                                              PtSample.Y - Marker_Pos_Ofset,
                                                                                              MarkerSize, MarkerSize);

                                                            SerieMarksCoords.Add((object)RecMark);
                                                        }
                                                        break;

                                                    case GraphSerieMarkerStyles.Round:

                                                        {
                                                            Rectangle RecMark = new Rectangle(PtSample.X - Marker_Pos_Ofset,
                                                                                              PtSample.Y - Marker_Pos_Ofset,
                                                                                             MarkerSize, MarkerSize);

                                                            SerieMarksCoords.Add((object)RecMark);
                                                        }
                                                        break;

                                                    case GraphSerieMarkerStyles.Diamond:

                                                        {
                                                            DiamondMarker Diamond = new DiamondMarker();
                                                            Diamond.Points[0] = new Point(PtSample.X, PtSample.Y - Marker_Pos_Ofset);
                                                            Diamond.Points[1] = new Point(PtSample.X + Marker_Pos_Ofset, PtSample.Y);
                                                            Diamond.Points[2] = new Point(PtSample.X, PtSample.Y + Marker_Pos_Ofset);
                                                            Diamond.Points[3] = new Point(PtSample.X - Marker_Pos_Ofset, PtSample.Y);

                                                            SerieMarksCoords.Add((object)Diamond);
                                                        }

                                                        break;

                                                    case GraphSerieMarkerStyles.Cross:

                                                        {
                                                            CrossMarker Cross = new CrossMarker();
                                                            Cross.Points[0] = new Point(PtSample.X - Marker_Pos_Ofset, PtSample.Y - Marker_Pos_Ofset);
                                                            Cross.Points[1] = new Point(PtSample.X + Marker_Pos_Ofset, PtSample.Y + Marker_Pos_Ofset);
                                                            Cross.Points[2] = new Point(PtSample.X + Marker_Pos_Ofset, PtSample.Y - Marker_Pos_Ofset);
                                                            Cross.Points[3] = new Point(PtSample.X - Marker_Pos_Ofset, PtSample.Y + Marker_Pos_Ofset);

                                                            SerieMarksCoords.Add((object)Cross);
                                                        }

                                                        break;

                                                    case GraphSerieMarkerStyles.Triangle:

                                                        {
                                                            TriangleMarker Triangle = new TriangleMarker();
                                                            Triangle.Points[0] = new Point(PtSample.X - Marker_Pos_Ofset, PtSample.Y);
                                                            Triangle.Points[1] = new Point(PtSample.X + Marker_Pos_Ofset, PtSample.Y);
                                                            Triangle.Points[2] = new Point(PtSample.X, PtSample.Y - Marker_Pos_Ofset);

                                                            SerieMarksCoords.Add((object)Triangle);
                                                        }

                                                        break;
                                                }
                                            }

                                            bMark = !bMark;
                                        }
                                    }

                                    #endregion  
                                }

                                //Add the last (or unique) set of sample points
                                if (PartialSerieCoords.Count > 1) //Minimum 2 points to trace a line
                                {
                                    SerieCoords.Add(PartialSerieCoords.ToArray());
                                }

                                #endregion

                                #region Serie trace and sample markers drawing

                                if (nVisiblePointCnt > 1)
                                {
                                    //Trace ploting
                                    #region Trace ploting

                                    if (oSerieProps.Trace.Visible)
                                    {
                                        oPen = new Pen(oSerieProps.Trace.LineColor, oSerieProps.Trace.LineWidth);
                                        oPen.DashStyle = oSerieProps.Trace.LineStyle;

                                        switch (oSerieProps.DrawingMode)
                                        {
                                            case GraphSerieDrawingModes.Line:

                                                foreach (Point[] SeriePoints in SerieCoords)
                                                {
                                                    GraphGraphics.DrawLines(oPen, SeriePoints);
                                                }

                                                break;

                                            case GraphSerieDrawingModes.Step:

                                                foreach (Point[] SeriePoints in SerieCoords)
                                                {
                                                    Point[] SerieStepPoints = new Point[SeriePoints.Length * 2 - 1];
                                                    int iPoint = 0;

                                                    for (int iSample = 0; iSample < SeriePoints.Length; iSample++)
                                                    {
                                                        SerieStepPoints[iPoint] = SeriePoints[iSample];

                                                        if (iSample < SeriePoints.Length - 1)
                                                        {
                                                            SerieStepPoints[iPoint + 1] = new Point(SeriePoints[iSample + 1].X, SeriePoints[iSample].Y);
                                                        }

                                                        iPoint += 2;
                                                    }

                                                    GraphGraphics.DrawLines(oPen, SerieStepPoints);
                                                }

                                                break;
                                        }
                                    }

                                    #endregion

                                    //Markers plotting
                                    #region Markers plotting

                                    if (oSerieProps.Markers.Visible)
                                    {
                                        oPen = new Pen(oSerieProps.Markers.MarkColor);
                                        oBrush = new SolidBrush(oSerieProps.Markers.MarkColor);

                                        switch (oSerieProps.Markers.Style)
                                        {
                                            case GraphSerieMarkerStyles.Square:

                                                if (oSerieProps.Markers.InteriorEmpty)
                                                {
                                                    foreach (object Mark in SerieMarksCoords)
                                                    {
                                                        GraphGraphics.DrawRectangle(oPen, (Rectangle)Mark);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (object Mark in SerieMarksCoords)
                                                    {
                                                        GraphGraphics.FillRectangle(oBrush, (Rectangle)Mark);
                                                    }
                                                }

                                                break;

                                            case GraphSerieMarkerStyles.Round:

                                                if (oSerieProps.Markers.InteriorEmpty)
                                                {
                                                    foreach (object Mark in SerieMarksCoords)
                                                    {
                                                        GraphGraphics.DrawEllipse(oPen, (Rectangle)Mark);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (object Mark in SerieMarksCoords)
                                                    {
                                                        GraphGraphics.FillEllipse(oBrush, (Rectangle)Mark);
                                                    }
                                                }

                                                break;

                                            case GraphSerieMarkerStyles.Diamond:

                                                if (oSerieProps.Markers.InteriorEmpty)
                                                {
                                                    foreach (object Mark in SerieMarksCoords)
                                                    {
                                                        GraphGraphics.DrawPolygon(oPen, ((DiamondMarker)Mark).Points);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (object Mark in SerieMarksCoords)
                                                    {
                                                        GraphGraphics.FillPolygon(oBrush, ((DiamondMarker)Mark).Points);
                                                    }
                                                }

                                                break;

                                            case GraphSerieMarkerStyles.Cross:

                                                foreach (object Mark in SerieMarksCoords)
                                                {
                                                    CrossMarker CrossMark = (CrossMarker)Mark;

                                                    GraphGraphics.DrawLine(oPen, CrossMark.Points[0], CrossMark.Points[1]);
                                                    GraphGraphics.DrawLine(oPen, CrossMark.Points[2], CrossMark.Points[3]);
                                                }

                                                break;

                                            case GraphSerieMarkerStyles.Triangle:

                                                if (oSerieProps.Markers.InteriorEmpty)
                                                {
                                                    foreach (object Mark in SerieMarksCoords)
                                                    {
                                                        GraphGraphics.DrawPolygon(oPen, ((TriangleMarker)Mark).Points);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (object Mark in SerieMarksCoords)
                                                    {
                                                        GraphGraphics.FillPolygon(oBrush, ((TriangleMarker)Mark).Points);
                                                    }
                                                }

                                                break;
                                        }
                                    }
                                }

                                #endregion

                                #endregion
                            }
                        }
                    }

                    iSerie++;
                }
            }

            #endregion

#if DEBUG
            SeriesValuesTime = swTimer.ElapsedMilliseconds;
#endif

            if (oPen != null) oPen.Dispose();
            if (oBrush != null) oBrush.Dispose();

            eCurrentStage = GraphDrawingStages.Series_Values;

            //Cursor positions reset
            PtCursorPos = Point.Empty;
            CursorPosMouseDown = Point.Empty;
            CursorPosMouseUp = Point.Empty;

#if DEBUG
            swTimer.Stop();
#endif
        }

        #endregion

        #region Graphic plotting functions

        private void Init_GraphWindow()
        {
            //Control feedback to host application members init
            mMainCursorAbscisse = double.NaN;

            //Zoom cursor buttons
            Cmd_ZoomXPosition.BackColor = Color.FromArgb(Properties.WindowBackColor.ToArgb() ^ 0xffffff); //Background color inversion
            Cmd_ZoomXPosition.FlatAppearance.MouseDownBackColor = Cmd_ZoomXPosition.BackColor;
            Cmd_ZoomXPosition.FlatAppearance.MouseOverBackColor = Cmd_ZoomXPosition.BackColor;

            Cmd_ZoomYPosition.BackColor = Color.FromArgb(Properties.WindowBackColor.ToArgb() ^ 0xffffff); //Background color inversion
            Cmd_ZoomYPosition.FlatAppearance.MouseDownBackColor = Cmd_ZoomYPosition.BackColor;
            Cmd_ZoomYPosition.FlatAppearance.MouseOverBackColor = Cmd_ZoomYPosition.BackColor;

            splitContainer2.Panel2Collapsed = !(Properties.LegendProperties.Visible & bLegendEnabled);

            //Graphic frame height computation
            FrameHeight = Pic_GraphFrame.Height;  //Pic_Graphic.Height;

            if (Properties.AbscisseAxis.Visible)
            {
                FrameHeight -= ((AXIS_BASE_SIZE * (int)Properties.AbscisseAxis.AxisLineStyle.LineWidth) + AXIS_SEPARATION_SPACE + AXIS_BASE_POS); //Abscisse axis space

                if (Properties.AbscisseAxis.AxisValuesVisible)
                {
                    FrameHeight -= (((int)(Properties.AbscisseAxis.AxisValuesFont.oFont.Size)) + AXIS_TEXT_POS_OFFSET); //Abscisse values space
                }
            }

            FrameHeight = RoundClosest(FrameHeight - GRAPH_FRAME_HEIGHT_OFFSET, SEC_V_GRID_LINES_COUNT + 1);

            //Graphic frame corners points definition
            FrameTopPoint = GRAPH_FRAME_HEIGHT_OFFSET;
            FrameBottomPoint = FrameTopPoint + FrameHeight;

            //Graphic frame width computation
            FrameWidth = Pic_GraphFrame.Width;  //Pic_Graphic.Width;
            oYAxis = new Ctrl_WaveForm.GraphAxisCollection();

            SeriesVisibleCount = 0;

            if (!(DataFile == null))
            {
                SeriesVisibleCount = Get_PlottedChannelCount();

                if (SeriesVisibleCount > 0 && DataFile.MaxSampleCount > 2)
                {
                    int iSeriePloted = 0;
                    oYAxis.AxisTable = new List<GraphAxisGroup>();

                    if (!bYZoom)
                    {
                        RefZoomYUpperBound = 0;
                        RefZoomYLowerBound = FrameHeight;
                        SeriesReferenceCoordConversion = new List<Ctrl_WaveForm.SerieCoordConversion>();
                    }

                    foreach (GraphSerieProperties oSerieProps in Properties.SeriesProperties)
                    {
                        if (oSerieProps.Visible && (oSerieProps.Trace.Visible || oSerieProps.Markers.Visible))
                        {
                            GW_DataChannel oSerieData = DataFile.Get_DataChannel(oSerieProps.Name);

                            if (!(oSerieData == null))
                            {
                                oSerieProps.DataChannelKeyId = oSerieData.KeyId;

                                if (!bYZoom) Set_SerieCoordConversions(oSerieProps, oSerieData, iSeriePloted);
                                oSerieProps.ValueFormat.Set_ValueRange(oSerieProps.CoordConversion.Max - oSerieProps.CoordConversion.Min);
                                iSeriePloted++;

                                if (oSerieProps.YAxis.Visible)
                                {
                                    Add_YAxis(oSerieProps.KeyId, oSerieProps.YAxis, oSerieProps.ValueFormat, oSerieProps.CoordConversion);
                                }
                            }
                        }
                    }
                }
            }

            FrameWidth = RoundClosest(FrameWidth - oYAxis.TotalAxisWidth - GRAPH_FRAME_WIDTH_OFFSET, SEC_H_GRID_LINES_COUNT + 1);

            //Graphic frame corners points definition
            FrameLeftPoint = Pic_GraphFrame.Width - GRAPH_FRAME_WIDTH_OFFSET - FrameWidth; //Pic_Graphic.Width - GRAPH_FRAME_WIDTH_OFFSET - FrameWidth;
            FrameRightPoint = FrameLeftPoint + FrameWidth;

            //Set Pic_Graphic size and position
            this.BeginInvoke(this.Pic_GraphicSetupDelegate,
                             new object[] { new Rectangle(FrameLeftPoint,
                                                          FrameTopPoint,
                                                          FrameWidth,
                                                          FrameHeight) });
            //Abscisse coords definition
            Update_AbscisseCoordsConversion();

            //Update reference cursor X position
            if (!(PtRefCursorPos.IsEmpty))
            {
                if (Properties.ReferenceCursor.Mode == GraphicCursorMode.VerticalLine)
                {
                    PtRefCursorPos.X = (int)(RefCursorCoordinates.Abs * Properties.AbscisseAxis.CoordConversion.Gain + Properties.AbscisseAxis.CoordConversion.Zero);
                }
                else
                {
                    PtRefCursorPos.X = 0;
                }
            }
        }

        private void Update_AbscisseCoordsConversion()
        {
            //Abscisse coords definition
            if (!(DataFile == null))
            {
                if (SeriesVisibleCount > 0 && DataFile.MaxSampleCount > 2)
                {
                    if (Properties.AbscisseAxis.TimeMode) //Graphic window in time mode
                    {
                        if (DataFile.DataSamplingMode == SamplingMode.SingleRate)
                        {
                            oWholeAbcsisseChannel = WholeDataFile.Time;
                            oAbcsisseChannel = DataFile.Time;
                            Set_AbcisseCordConversion(DataFile.Time);
                        }
                        else
                        {
                            Properties.AbscisseAxis.CoordConversion.Min = DataFile.SampleTimeMin;
                            Properties.AbscisseAxis.CoordConversion.Max = DataFile.SampleTimeMax;

                            if (!(double.IsNaN(Properties.AbscisseAxis.CoordConversion.Min) || double.IsNaN(Properties.AbscisseAxis.CoordConversion.Max)))
                            {
                                Set_AbcisseCoordConversion_MultipleRatesSampling(Properties.AbscisseAxis.CoordConversion.Min,
                                                                                 Properties.AbscisseAxis.CoordConversion.Max);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else //Graphic window in XY mode
                    {
                        //TODO: Treat the case of multiple rates sampling mode

                        GW_DataChannel oTmpChan = DataFile.Get_DataChannel(Properties.AbscisseAxis.AbscisseChannelName);

                        if (!(oTmpChan == null))
                        {
                            if (oTmpChan.Min != oTmpChan.Max)
                            {
                                oWholeAbcsisseChannel = WholeDataFile.Get_DataChannel(Properties.AbscisseAxis.AbscisseChannelName);

                                oAbcsisseChannel = new GW_DataChannel(oTmpChan.Name);

                                oAbcsisseChannel.Values = oTmpChan.Values;
                                oAbcsisseChannel.Min = oTmpChan.Min;
                                oAbcsisseChannel.Max = oTmpChan.Max;
                                oAbcsisseChannel.Avg = oTmpChan.Avg;

                                Set_AbcisseCordConversion(oAbcsisseChannel);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The abcisse channel " + Properties.AbscisseAxis.AbscisseChannelName + " is missing !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                oAbcisseValFormat.Set_ValueRange(Properties.AbscisseAxis.CoordConversion.Max - Properties.AbscisseAxis.CoordConversion.Min);
            }
        }

        private void Compute_SubSampling(int SampleCount)
        {
            nSampleCount = SampleCount;
            DblSampleStep = 1;
            nMarkCount = SampleCount / 2;

            if (Properties.bSubSamplingEnabled && (SampleCount > Properties.nGraphicSampleMax))
            {
                DblSampleStep = (double)SampleCount / (double)Properties.nGraphicSampleMax;
                nSampleCount = Properties.nGraphicSampleMax;

                nMarkCount = nSampleCount / 2;
                if ((nMarkCount % 2) != 0) nMarkCount++; //If nSampleCount is odd (363)
            }
        }

        private void Set_AbcisseCordConversion(GW_DataChannel oAbcisse)
        {
        	Properties.AbscisseAxis.CoordConversion.Gain = (double)((double)(FrameWidth) / (oAbcisse.Max - oAbcisse.Min));
            Properties.AbscisseAxis.CoordConversion.Zero = (double)((double)(FrameWidth) - Properties.AbscisseAxis.CoordConversion.Gain * oAbcisse.Max);

            Properties.AbscisseAxis.CoordConversion.Min = oAbcisse.Min;
            Properties.AbscisseAxis.CoordConversion.Max = oAbcisse.Max;

            AbscisseCoords = new int[oAbcisse.Values.Count];

            for (int i = 0; i < oAbcisse.Values.Count; i++)
            {
                AbscisseCoords[i] = (int)(oAbcisse.Values[i] * Properties.AbscisseAxis.CoordConversion.Gain + Properties.AbscisseAxis.CoordConversion.Zero);
            }
        }

        private void Set_AbcisseCoordConversion_MultipleRatesSampling(double TimeMin, double TimeMax)
        {
            if (!(double.IsNaN(TimeMin) || double.IsNaN(TimeMax)))
            {
                Properties.AbscisseAxis.CoordConversion.Gain = (double)((double)(FrameWidth) / (TimeMax - TimeMin));
                Properties.AbscisseAxis.CoordConversion.Zero = (double)((double)(FrameWidth) - Properties.AbscisseAxis.CoordConversion.Gain * TimeMax);
            }
            else
            {
                Properties.AbscisseAxis.CoordConversion.Gain = double.NaN;
                Properties.AbscisseAxis.CoordConversion.Zero = double.NaN;
            }
        }
        
        private void Set_SerieCoordConversions(GraphSerieProperties oProp, GW_DataChannel oData, int iPlot)
        {
        	GW_DataChannel oWholeDataChan = WholeDataFile.Get_DataChannel(oData.Name);
        	
        	if (!(oWholeDataChan == null))
        	{
        		SerieCoordConversion sRefCoordConv = new SerieCoordConversion();
        		sRefCoordConv.SerieKeyId = oProp.KeyId;
        		
        		switch (oProp.ScalingMode)
        		{
        			case GraphSerieScaleModes.Auto:

        				oProp.CoordConversion.Min = oData.Min;
        				oProp.CoordConversion.Max = oData.Max;
        				
        				if (oProp.CoordConversion.Min == oProp.CoordConversion.Max) //To not make a division by zero later on...
        				{
        					if (!(oProp.CoordConversion.Min == 0))
        					{
        						oProp.CoordConversion.Min -= (Math.Abs(oProp.CoordConversion.Min) / 2);
        						oProp.CoordConversion.Max += (Math.Abs(oProp.CoordConversion.Max) / 2);
        					}
        					else
        					{
        						oProp.CoordConversion.Min = -1;
        						oProp.CoordConversion.Max = 1;
        					}
        				}
        				
        				break;

        			case GraphSerieScaleModes.Custom:

        				oProp.CoordConversion.Min = oProp.Min;
        				oProp.CoordConversion.Max = oProp.Max;
        				break;
        		}

        		//100 % = FrameTopPoint
        		//0 %   = FrameBottomPoint
        		switch(Properties.GraphLayoutMode)
        		{
        			case GraphicWindowLayoutModes.Overlay:

        				oProp.CoordConversion.Top = 0;
        				oProp.CoordConversion.Bottom = FrameHeight;
        				break;

        			case GraphicWindowLayoutModes.Parallel:

        				int SerieSpace = (int)((FrameHeight) / SeriesVisibleCount);
        				oProp.CoordConversion.Top = (int)(SerieSpace * iPlot);
        				oProp.CoordConversion.Bottom = oProp.CoordConversion.Top + SerieSpace;
        				break;

        			case GraphicWindowLayoutModes.Custom:
        				
        				double a = ((double)(FrameHeight)) / -100;
        				double b = 0 - a * 100;
        				
        				oProp.CoordConversion.Top = (int)(a * oProp.Top + b);
        				oProp.CoordConversion.Bottom = (int)(a * oProp.Bottom + b);
        				
        				break;
        		}

                if (oProp.CoordConversion.Min < oProp.CoordConversion.Max)
                {
                    oProp.CoordConversion.Gain = (double)((double)(oProp.CoordConversion.Top - oProp.CoordConversion.Bottom) / (oProp.CoordConversion.Max - oProp.CoordConversion.Min));
                    oProp.CoordConversion.Zero = (double)((double)(oProp.CoordConversion.Top) - oProp.CoordConversion.Gain * oProp.CoordConversion.Max);
                }
                else
                {
                    oProp.CoordConversion.Gain = double.NaN;
                    oProp.CoordConversion.Zero = double.NaN;
                }
                       		
        		sRefCoordConv.CoordConversion = oProp.CoordConversion;
        		SeriesReferenceCoordConversion.Add(sRefCoordConv);
        	}
        }

        private void Add_YAxis(int SerieKey, GraphSerieAxis oAxisProps, GraphSerieValueFormat oFormat, GW_SampleCoordConversion sDataCoord)
        {
            GraphAxisGroup oAxisGrp = null;

            //Ord axis creation
            GraphAxis oAxis = new GraphAxis(); 
            oAxis.StartPos = sDataCoord.Top + FrameTopPoint;
            oAxis.EndPos = sDataCoord.Bottom +  FrameTopPoint;
            oAxis.SerieKey = SerieKey;

            //Search a free slot into the axis table
            if (oYAxis.AxisTable.Count > 0) //Axis table does contain axis already
            {
                foreach (GraphAxisGroup oGrp in oYAxis.AxisTable)
                {
                    bool bFreeSlot = true;
                	
                	foreach(GraphAxis goa in oGrp.AxisGroup)
                    {
                		if ((oAxis.StartPos >= goa.StartPos && oAxis.StartPos < goa.EndPos) || (oAxis.EndPos >= goa.StartPos && oAxis.EndPos < goa.EndPos))
                        {
                            bFreeSlot = false;
                            break;
                        }
                    }

                    if (bFreeSlot) //Axis ground found, exit the 1st level loop
                    {
                        oAxisGrp = oGrp; //Axis ground found, exit the 2nd level loop
                    	break;
                    }
                }

                if (oAxisGrp == null) //No free slot found in axis groups, creation of a new group
                {
                    oAxisGrp = new GraphAxisGroup();
                    oYAxis.AxisTable.Add(oAxisGrp);
                }
            }
            else //Axis table doesn't contain any axis yet
            {
                oAxisGrp = new GraphAxisGroup();
                oYAxis.AxisTable.Add(oAxisGrp);
            }

            oAxisGrp.AxisGroup.Add(oAxis); //Axis adding into the found or created group

            //Axis group 'width' property update 
            int AxisWidth = (AXIS_BASE_SIZE * (int)oAxisProps.AxisLineStyle.LineWidth) + AXIS_SEPARATION_SPACE;
            
            if (oAxisProps.AxisValuesVisible)
            {            	
            	Graphics g = Pic_GraphFrame.CreateGraphics();
            	
            	AxisWidth += (int)g.MeasureString(oAxis.Get_LongestGraduationText(FrameHeight, FrameTopPoint, sDataCoord.Min, sDataCoord.Max, oFormat, false),
            	                                  oAxisProps.AxisValuesFont.oFont, new PointF(0, 0), StringFormat.GenericDefault).Width;
            	
            	AxisWidth += AXIS_TEXT_POS_OFFSET;
            	
            	g.Dispose();
            }
            
            if (oAxisProps.AxisTitleVisible)
            {
            	oAxis.TitleLeft = AxisWidth + AXIS_TITLE_POS_OFFSET;
            	AxisWidth += (int)(oAxisProps.AxisValuesFont.oFont.Size * 2) + AXIS_TITLE_POS_OFFSET;
            }

            if(AxisWidth>oAxisGrp.Width) //Axis group has a new width ?
            {
                oAxisGrp.Width = AxisWidth;

                //All axis groups 'left' & AxisTable 'TotalAxisWidth' properties update
                oYAxis.TotalAxisWidth = AXIS_BASE_POS;

                for (int iGrp = 0; iGrp < oYAxis.AxisTable.Count; iGrp++)
                {
                    if (iGrp > 0)
                    {
                        oYAxis.AxisTable[iGrp].LeftOffset = oYAxis.AxisTable[iGrp - 1].LeftOffset + oYAxis.AxisTable[iGrp - 1].Width;
                    }

                    oYAxis.TotalAxisWidth += oYAxis.AxisTable[iGrp].Width;
                }
            }
        }
		
        private int Get_PlottedChannelCount()
        {
            int Cnt = 0;

            foreach (GraphSerieProperties oProp in Properties.SeriesProperties)
            {
                if((oProp.Visible && (oProp.Trace.Visible || oProp.Markers.Visible)) && DataFile.DataChannelExists(oProp.Name))
                {
                    Cnt++;
                }
            }

            return (Cnt);
        }
        
        #endregion
        
        #region Cursor functions
        
        private void Draw_Cursor(Point MouseLocation)
        {
        	Draw_Cursor(MouseLocation, null, null);
        }
        
        private void Draw_Cursor(Point MouseLocation, GraphCursorProperties oCursor)
        {
        	Draw_Cursor(MouseLocation, oCursor, null);
        }
        
        private void Draw_Cursor(Point MouseLocation, GraphCursorProperties oCursor, Graphics GraphicsTarget)
        {	
        	Pic_Graphic.Refresh();
        	
        	if (oCursor == null)
        	{
	        	switch (CurrentGraphCursor)
	        	{
	        		case GraphicCursorObject.CursorMain:
	        			
	        			oCursor = Properties.Cursor;
                        mMainCursorAbscisse = double.NaN;

                        if (!(PtRefCursorPos.IsEmpty))
	        			{
	        				Draw_Cursor(PtRefCursorPos,Properties.ReferenceCursor);
	        			}
	        			
	        			break;
	        			
	        		case GraphicCursorObject.CursorReference:
	        			
	        			oCursor = Properties.ReferenceCursor;
	        			break;
	        			
	        		default:
	        			
	        			return;
	        	}
        	}
        	
        	PtCursorPos = Point.Empty;
        	
        	if (MouseLocation.X >= 0 && MouseLocation.X <= FrameWidth && MouseLocation.Y >= 0 && MouseLocation.Y <= FrameHeight)
			{
        		if (oCursor.Equals(Properties.ReferenceCursor))
        		{
        			PtRefCursorPos = MouseLocation;
        		}
        		else
        		{
        			PtCursorPos = MouseLocation;
        		}
				
        		int CursorSize = CURSOR_BASE_SIZE * oCursor.CursorSize;
    			int CursorX = MouseLocation.X;
    			int CursorY = MouseLocation.Y;
    			GraphicCoordinates CursorCoord = GetPointGraphCoordinates(MouseLocation);
                if (CurrentGraphCursor == GraphicCursorObject.CursorMain) mMainCursorAbscisse = CursorCoord.Abs;

        		Graphics g = null;
        		
        		if (GraphicsTarget == null) //Cursor drawing in the graphic picture box
        		{
					g = Pic_Graphic.CreateGraphics();
        		}
        		else //Cursor drawing in a graphic snapshot
        		{
        			g = GraphicsTarget;
        		}
				
				Pen p = new Pen(oCursor.Style.LineColor, oCursor.Style.LineWidth);
    			p.DashStyle = oCursor.Style.LineStyle;
    			
    			SolidBrush b = null;
    			
    			//Cursor drawing
    			switch (oCursor.Mode)
    			{
    				case GraphicCursorMode.VerticalLine:
    					
    					g.DrawLine(p, CursorX, 0, CursorX, FrameHeight);
    					break;
    					
    				case GraphicCursorMode.HorizontalLine:
    					
    					g.DrawLine(p, 0, CursorY, FrameWidth, CursorY);
    					break;
    					
    				case GraphicCursorMode.Cross:
    					
    					g.DrawLine(p, CursorX, 0, CursorX, FrameHeight);
    					g.DrawLine(p, 0, CursorY, FrameWidth, CursorY);
    					break;
    					
    				case GraphicCursorMode.Graticule:
    					
    					g.DrawLine(p, CursorX - (CursorSize / 2), CursorY, CursorX + (CursorSize / 2), CursorY);
    					g.DrawLine(p, CursorX, CursorY - (CursorSize / 2), CursorX, CursorY + (CursorSize / 2));
    					break;
    					
    				case GraphicCursorMode.Square:
    					
    					g.DrawRectangle(p, CursorX - (CursorSize / 2), CursorY - (CursorSize / 2), CursorSize, CursorSize);
    					break;
    					
    				case GraphicCursorMode.Circle:
    					
    					g.DrawEllipse(p, CursorX - (CursorSize / 2), CursorY - (CursorSize / 2), CursorSize, CursorSize);
    					break;
    					
    				default:
    					
    					break;
    			}
    			
    			//Abscisse cursor value
    			if ((oCursor.ShowCursorAbscisseValue) && (oCursor.Mode.Equals(GraphicCursorMode.VerticalLine) || oCursor.Mode.Equals(GraphicCursorMode.Cross)))
				{
    			    SerieValueAtPoint AbsCursorValue = new Ctrl_WaveForm.SerieValueAtPoint();
    			    
    			    AbsCursorValue.SerieName = "X: ";
    			    AbsCursorValue.SerieValue = Math.Round(CursorCoord.Abs, 3).ToString();
    			    AbsCursorValue.SerieColor = Properties.AbscisseAxis.AxisLineStyle.LineColor;
    			    
    			    PointF PtAbsCursorVal = new PointF();
    			    
    			    if (CursorX < FrameWidth / 2)
    			    {
    			    	PtAbsCursorVal.X = (float)(CursorX + CURSOR_TEXT_LEFT_OFFSET);
    			    }
    			    else
    			    {
    			    	PtAbsCursorVal.X = (float)(CursorX - CURSOR_TEXT_LEFT_OFFSET 
    			    	                           - ((AbsCursorValue.SerieValue.Length 
    			    	                               + AbsCursorValue.SerieName.Length) 
    			    	                               * oCursor.CursorValueFont.oFont.Size));
    			    }
    			    
					switch (oCursor.AbscisseValuePostion)
					{
                        case ScreenPositions.Top:
							
							PtAbsCursorVal.Y = (float)(CURSOR_TEXT_TOP_OFFSET);
							break;

                        case ScreenPositions.Center:
							
							PtAbsCursorVal.Y = (float)((FrameHeight / 2) - (oCursor.CursorValueFont.oFont.GetHeight() / 2));
							break;

                        case ScreenPositions.Bottom:
							
							PtAbsCursorVal.Y = (float)(FrameHeight - CURSOR_TEXT_TOP_OFFSET - oCursor.CursorValueFont.oFont.GetHeight());
							break;
					}
					
					if (oCursor.Equals(Properties.ReferenceCursor))
					{
						b = new SolidBrush(oCursor.Style.LineColor);
					}
					else
					{
                        if (oCursor.CursorValueForeColor == Color.Empty)
                        {
                            b = new SolidBrush(AbsCursorValue.SerieColor);
                        }
                        else
                        {
                            b = new SolidBrush(oCursor.CursorValueForeColor);
                        }
					}
					
					g.DrawString(AbsCursorValue.SerieName + AbsCursorValue.SerieValue, 
					             oCursor.CursorValueFont.oFont, b, PtAbsCursorVal);
					
				}
    			
    			//Ordinate cusor value    			
    			if ((oCursor.ShowCursorOrdinatesValue) && (oCursor.Mode.Equals(GraphicCursorMode.HorizontalLine) || oCursor.Mode.Equals(GraphicCursorMode.Cross)))
    			{
					if (!(CursorCoord == null))
    				{
						if (!(CursorCoord.Ords == null))
						{
							int TxtLenMax = Get_OrdinateValuesTextLenMax(CursorCoord.Ords);
							
							PointF PtOrdCursorVal = new PointF();
							
							switch (oCursor.OrdinateValuesPosition)
							{
                                case ScreenPositions.Left:
									
									PtOrdCursorVal.X = (float) (CURSOR_TEXT_LEFT_OFFSET);
									break;

                                case ScreenPositions.Center:
									
									PtOrdCursorVal.X = (float)((FrameWidth / 2) - (TxtLenMax * oCursor.CursorValueFont.oFont.Size / 2));
									break;

                                case ScreenPositions.Right:
									
									PtOrdCursorVal.X = (float) (FrameWidth - CURSOR_TEXT_LEFT_OFFSET - (TxtLenMax * oCursor.CursorValueFont.oFont.Size));
									break;
							}
							
							float PtOrdCursorValInc = 0;
							
							if (CursorY < FrameTopPoint + FrameHeight / 2)
							{
								PtOrdCursorVal.Y = (float)(CursorY + CURSOR_TEXT_TOP_OFFSET);
								PtOrdCursorValInc = oCursor.CursorValueFont.oFont.GetHeight() + 1;
							}
							else
							{
								PtOrdCursorVal.Y = (float)(CursorY - CURSOR_TEXT_TOP_OFFSET - (CursorCoord.Ords.Length * oCursor.CursorValueFont.oFont.GetHeight()) - CursorCoord.Ords.Length);
								PtOrdCursorValInc = (oCursor.CursorValueFont.oFont.GetHeight() + 1) * -1;
							}
							
							foreach (SerieValueAtPoint sCursorVal in CursorCoord.Ords)
							{
                                if (oCursor.CursorValueForeColor == Color.Empty)
                                {
                                    b = new SolidBrush(sCursorVal.SerieColor);
                                }
                                else
                                {
                                    b = new SolidBrush(oCursor.CursorValueForeColor);
                                }

                                g.DrawString(sCursorVal.SerieName + ": " + sCursorVal.SerieValue, oCursor.CursorValueFont.oFont, b, PtOrdCursorVal);
								PtOrdCursorVal.Y += PtOrdCursorValInc;
							}
						}
    				}
    			}

                //Cursor title
                if (oCursor.Equals(Properties.Cursor))
                {
                    if ((!(oCursor.CursorTitle.Equals("") || oCursor.CursorTitlePosition== ScreenPositions.Invisible)) 
                        && (oCursor.Mode == GraphicCursorMode.Cross || oCursor.Mode == GraphicCursorMode.VerticalLine || oCursor.Mode == GraphicCursorMode.HorizontalLine))
                    {
                        PointF PtTitle = new PointF();
                        SizeF TitleStringSize = g.MeasureString(oCursor.CursorTitle, oCursor.CursorTitleFont.oFont);

                        if (oCursor.Mode == GraphicCursorMode.HorizontalLine)
                        {
                            if (CursorY < FrameTopPoint + FrameHeight / 2)
                            {
                                PtTitle.Y = (float)(CursorY + CURSOR_TEXT_TOP_OFFSET);
                            }
                            else
                            {
                                PtTitle.Y = (float)(CursorY - CURSOR_TEXT_TOP_OFFSET) - TitleStringSize.Height;
                            }

                            ScreenPositions eTitleLocation;
                            if(oCursor.CursorTitlePosition== ScreenPositions.Top)
                            {
                                eTitleLocation = ScreenPositions.Left;
                            }
                            else if (oCursor.CursorTitlePosition== ScreenPositions.Bottom)
                            {
                                eTitleLocation = ScreenPositions.Right;
                            }
                            else
                            {
                                eTitleLocation = oCursor.CursorTitlePosition;
                            }

                            switch(eTitleLocation)
                            {
                                case ScreenPositions.Left:

                                    PtTitle.X = (float)(CURSOR_TEXT_LEFT_OFFSET);
                                    break;

                                case ScreenPositions.Right:

                                    PtTitle.X = (float)(FrameWidth - CURSOR_TEXT_LEFT_OFFSET) - TitleStringSize.Width;
                                    break;

                                default: //Center

                                    PtTitle.X = ((float)(FrameWidth) / 2) - (TitleStringSize.Width / 2);
                                    break;
                            }
                        }
                        else
                        {
                            if (CursorX < FrameWidth / 2)
                            {
                                PtTitle.X = (float)(CursorX + CURSOR_TEXT_LEFT_OFFSET);
                            }
                            else
                            {
                                PtTitle.X = (float)(CursorX - CURSOR_TEXT_LEFT_OFFSET) - TitleStringSize.Width;
                            }

                            ScreenPositions eTitleLocation;
                            if (oCursor.CursorTitlePosition == ScreenPositions.Left)
                            {
                                eTitleLocation = ScreenPositions.Top;
                            }
                            else if (oCursor.CursorTitlePosition == ScreenPositions.Right)
                            {
                                eTitleLocation = ScreenPositions.Bottom;
                            }
                            else
                            {
                                eTitleLocation = oCursor.CursorTitlePosition;
                            }

                            switch(eTitleLocation)
                            {
                                case ScreenPositions.Top:

                                    PtTitle.Y = (float)(CURSOR_TEXT_TOP_OFFSET);
                                    break;

                                case ScreenPositions.Bottom:

                                    PtTitle.Y = (float)(FrameHeight - CURSOR_TEXT_TOP_OFFSET) - TitleStringSize.Height;
                                    break;

                                default: //Center

                                    PtTitle.Y = ((float)FrameHeight / 2) - (TitleStringSize.Height / 2);
                                    break;
                            }
                        }

                        b = new SolidBrush(oCursor.CursorTitleForeColor);
                        g.DrawString(oCursor.CursorTitle, oCursor.CursorTitleFont.oFont, b, PtTitle);
                    }
                }

    			p.Dispose();
				if (GraphicsTarget == null) g.Dispose(); //Do not dispose of g is the target isn't the default target (Pic_Graphic), otherwise target becomes null for the function caller as well...
				if (!(b == null)) b.Dispose();
    			
    			//Legend update
    			if (Properties.LegendProperties.Visible)
    			{
    				if (Properties.AbscisseAxis.TimeMode && (!(oCursor.Mode.Equals(GraphicCursorMode.HorizontalLine))))
    				{
    					UpDate_LegendValues(CursorCoord.Abs);
    				}
    				else
    				{
    					UpDate_LegendValues_XY(CursorCoord);
    				}
    			}
			}	
        }
        
        private int Get_OrdinateValuesTextLenMax(SerieValueAtPoint[] Values)
        {
        	int LenMax = 0;
        	
        	if (!(Values == null))
        	{
        		for (int i=0; i < Values.Length; i++)
        		{
        			string s = Values[i].SerieName + ": " + Values[i].SerieValue;
        			
        			if (i != 0)
        			{
        				if (LenMax < s.Length)
        				{
        					LenMax = s.Length;
        				}
        			}
        			else
        			{
        				LenMax = s.Length;
        			}
        		}
        	}
        	
        	return(LenMax);
        }
        
        private void Set_ReferenceCursor()
        {
        	if (CurrentGraphCursor.Equals(GraphicCursorObject.CursorMain))
        	{
        		CurrentGraphCursor = GraphicCursorObject.CursorReference;
        		
        		TSDB_RefCursor_Set.Visible = false;
        		TSDB_RefCursor_Lock.Visible = true;
        		TSDB_RefCursor_Mode.Enabled = true;
        		
        		RefCursor_Set_TSMI.Visible = false;
        		RefCursor_Lock_TSMI.Visible = true;
        		RefCursor_Mode_TSMI.Enabled = true;
        	}
        }
        
        private void Lock_ReferenceCursor()
        {
        	if (CurrentGraphCursor.Equals(GraphicCursorObject.CursorReference))
        	{
        		CurrentGraphCursor = GraphicCursorObject.CursorMain;
        		
        		TSDB_RefCursor_Set.Visible = true;
        		TSDB_RefCursor_Lock.Visible = false;
        		TSDB_RefCursor_Mode.Enabled = false;
        		
        		RefCursor_Set_TSMI.Visible = true;
        		RefCursor_Lock_TSMI.Visible = false;
        		RefCursor_Mode_TSMI.Enabled = false;
        		
        		Set_RefCursorCoordinates();
        		
        		Properties.LegendProperties.Informations |= (GraphicLegendInformations) (GraphicLegendInformations.RefCursorValue 
        		                                                                         | GraphicLegendInformations.RefCursorDiffValue 
        		                                                                         | GraphicLegendInformations.RefCursorDiffPerc 
        		                                                                         | GraphicLegendInformations.RefCursorGradient);
        		if (Properties.LegendProperties.Visible)
        		{
	        		Resize_Legend(true);
	        		Init_Legend();
        		}
        	}
        }
        
        private void Clear_ReferenceCursor()
        {
        	CurrentGraphCursor = GraphicCursorObject.CursorMain;
        	PtRefCursorPos = Point.Empty;
        	RefCursorCoordinates = null;
        	
        	TSDB_RefCursor_Mode.Enabled = true;
        	RefCursor_Mode_TSMI.Enabled = true;
        	
        	Properties.LegendProperties.Informations -= (GraphicLegendInformations) (GraphicLegendInformations.RefCursorValue 
        		                                                                         | GraphicLegendInformations.RefCursorDiffValue 
        		                                                                         | GraphicLegendInformations.RefCursorDiffPerc 
        		                                                                         | GraphicLegendInformations.RefCursorGradient);
        	
        	if (Properties.LegendProperties.Visible)
        	{
				Resize_Legend(false);        	
    			Init_Legend();
        	}
        	
        	Pic_Graphic.Refresh();
        }
        
        private void Set_RefCursorCoordinates()
        {
        	if (!(PtRefCursorPos.IsEmpty))
        	{
        		RefCursorCoordinates = new Ctrl_WaveForm.GraphicCoordinates();
        		
        		if (!(Properties.ReferenceCursor.Mode.Equals(GraphicCursorMode.HorizontalLine)))
        		{
        			//Abscisse value
        			RefCursorCoordinates.Abs = Get_AbscisseValueAtPostion(PtRefCursorPos.X);

                    //Ordinate values
                    List<SerieValueAtPoint> TmpOrds = new List<Ctrl_WaveForm.SerieValueAtPoint>();

                    switch (DataFile.DataSamplingMode)
                    {
                        case SamplingMode.SingleRate:

                            {
                                int iSample = DataFile.Get_SampleIndexAtTime(RefCursorCoordinates.Abs);

                                if (!(iSample == -1))
                                {
                                    foreach (GraphSerieProperties oSerieProp in Properties.SeriesProperties)
                                    {
                                        if (oSerieProp.Visible && (oSerieProp.Trace.Visible || oSerieProp.Markers.Visible))
                                        {
                                            GW_DataChannel oSerieData = DataFile.Get_DataChannel(oSerieProp.Name);

                                            if (!(oSerieData == null))
                                            {
                                                SerieValueAtPoint Ord = new Ctrl_WaveForm.SerieValueAtPoint();

                                                Ord.SerieColor = oSerieProp.Trace.LineColor;
                                                Ord.SerieKeyId = oSerieProp.KeyId;
                                                Ord.SerieName = oSerieProp.Name;
                                                Ord.SerieDblValue = oSerieData.Values[iSample];

                                                TmpOrds.Add(Ord);
                                            }
                                        }
                                    }
                                }
                            }

                            break;

                        case SamplingMode.MultipleRates:

                            {
                                foreach (GraphSerieProperties oSerieProp in Properties.SeriesProperties)
                                {
                                    if (oSerieProp.Visible && (oSerieProp.Trace.Visible || oSerieProp.Markers.Visible))
                                    {
                                        double SerieValue = DataFile.Get_ChannelValueAtTime(oSerieProp.Name, RefCursorCoordinates.Abs);

                                        if(!(double.IsNaN(SerieValue)))
                                        {
                                            SerieValueAtPoint Ord = new Ctrl_WaveForm.SerieValueAtPoint();

                                            Ord.SerieColor = oSerieProp.Trace.LineColor;
                                            Ord.SerieKeyId = oSerieProp.KeyId;
                                            Ord.SerieName = oSerieProp.Name;
                                            Ord.SerieDblValue = SerieValue;

                                            TmpOrds.Add(Ord);
                                        }
                                    }
                                }
                            }

                            break;
                    }

                    if (TmpOrds.Count > 0)
                    {
                        RefCursorCoordinates.Ords = TmpOrds.ToArray();
                    }
                    else
                    {
                        RefCursorCoordinates.Ords = null;
                    }
        		}
        		else
        		{
        			//Abscisse value
        			RefCursorCoordinates.Abs = double.NaN;
        			
        			//Ordinate values
        			RefCursorCoordinates.Ords = Get_OrdinateValuesAtPosition(PtRefCursorPos.Y);
        			
        			for (int iVal = 0; iVal < RefCursorCoordinates.Ords.Length; iVal++)
        			{
        				RefCursorCoordinates.Ords[iVal].SerieDblValue = double.Parse(RefCursorCoordinates.Ords[iVal].SerieValue);
        			}
        		}
        	}
        }
        
        private void Move_Cursor(GraphicCursorMovingDirection eDirection)
        {
        	if (!(PtCursorPos.Equals(Point.Empty) || Properties.Cursor.Mode.Equals(GraphicCursorMode.None)))
        	{
        		int Step = 0;
        		Point PtCursor = new Point(PtCursorPos.X, PtCursorPos.Y);
        		
        		switch (eDirection)
        		{
        			case GraphicCursorMovingDirection.Left:
        				
        				if (!(Properties.Cursor.Mode.Equals(GraphicCursorMode.HorizontalLine)))
        				{
        					Step = (int)(CursorSteps[CursorStepIndex] * (double)FrameWidth / 100);
        					
        					if (!((PtCursorPos.X - Step) < 0))
        					{
        						PtCursorPos.X -= Step;
        						Draw_Cursor(PtCursorPos);
        					}
        					else
        					{
        						if (bXZoom)
        						{
        							if ((Cmd_ZoomXPosition.Left - Step) > FrameLeftPoint)
        							{
        								Cmd_ZoomXPosition.Left -= Step;
        								Plot_DataAtXZoomBarPosition();
        								PtCursorPos = PtCursor;
        								Draw_Cursor(PtCursorPos);
        							}
        						}
        					}
        				}
        				
        				break;
        				
        			case GraphicCursorMovingDirection.Right:
        				
        				if (!(Properties.Cursor.Mode.Equals(GraphicCursorMode.HorizontalLine)))
        				{
        					Step = (int)(CursorSteps[CursorStepIndex] * (double)FrameWidth / 100);
        					
        					if (!((PtCursorPos.X + Step) > FrameWidth))
        					{
        						PtCursorPos.X += Step;
        						Draw_Cursor(PtCursorPos);
        					}
        					else
        					{
        						if (bXZoom)
        						{
        							if ((Cmd_ZoomXPosition.Left + Cmd_ZoomXPosition.Width + Step) < FrameRightPoint)
        							{
        								Cmd_ZoomXPosition.Left += Step;
        								Plot_DataAtXZoomBarPosition();
        								PtCursorPos = PtCursor;
        								Draw_Cursor(PtCursorPos);
        							}
        						}
        					}
        				}
        				
        				break;
        				
        			case GraphicCursorMovingDirection.Up:
        				
        				if (!(Properties.Cursor.Mode.Equals(GraphicCursorMode.VerticalLine)))
        				{
        					Step = (int)(CursorSteps[CursorStepIndex] * (double)FrameHeight / 100);
        					
        					if (!((PtCursorPos.Y - Step) < 0))
        					{
        						PtCursorPos.Y -= Step;
        						Draw_Cursor(PtCursorPos);
        					}
        					else
        					{
        						if (bYZoom)
        						{
        							if ((Cmd_ZoomYPosition.Top - Step) > FrameTopPoint)
        							{
        								Cmd_ZoomYPosition.Top -= Step;
        								Plot_DataAtYZoomBarPosition();
        								PtCursorPos = PtCursor;
        								Draw_Cursor(PtCursorPos);
        							}
        						}
        					}
        				}
        				
        				break;
        				
        			case GraphicCursorMovingDirection.Down:
        				
        				if (!(Properties.Cursor.Mode.Equals(GraphicCursorMode.VerticalLine)))
        				{
        					Step = (int)(CursorSteps[CursorStepIndex] * (double)FrameHeight / 100);
        					
        					if (!((PtCursorPos.Y + Step) > FrameHeight))
        					{
        						PtCursorPos.Y += Step;
        						Draw_Cursor(PtCursorPos);
        					}
        					else
        					{
        						if (bYZoom)
        						{
        							if ((Cmd_ZoomYPosition.Top + Cmd_ZoomYPosition.Height + Step) < FrameBottomPoint)
        							{
        								Cmd_ZoomYPosition.Top += Step;
        								Plot_DataAtYZoomBarPosition();
        								PtCursorPos = PtCursor;
        								Draw_Cursor(PtCursorPos);
        							}
        						}
        					}
        				}
        				
        				break;
        		}
        	}
        }
        
        #endregion
        
        #region Zoom and stats functions
        
        private void Plot_ZoomBoxData()
        {
        	GraphicCoordinates[] ZoomBoxCoords = GetZoomBoxGraphCoordinates();
        	bool bPlot = false;
        	
        	if (!(ZoomBoxCoords == null))
        	{
        		switch (Properties.ZoomMode)
        		{
        			case GraphicZoomMode.ZoomX:
        				
        				if (ZoomBoxCoords[0].Abs < ZoomBoxCoords[1].Abs)
        				{
        					bPlot = Set_DataFile_BetweenAbsPoint(ZoomBoxCoords[0].Abs, ZoomBoxCoords[1].Abs);
        				} 
        				else
        				{
        					bPlot = Set_DataFile_BetweenAbsPoint(ZoomBoxCoords[1].Abs, ZoomBoxCoords[0].Abs);
        				}
        				
        				break;
        				
         			case GraphicZoomMode.ZoomY:
        				
        				if (CursorPosMouseUp.Y > CursorPosMouseDown.Y)
        				{
        					bPlot = Set_DataFileForYZoom(CursorPosMouseDown.Y, CursorPosMouseUp.Y, true);
        				}
        				else
        				{
        					bPlot = Set_DataFileForYZoom(CursorPosMouseUp.Y, CursorPosMouseDown.Y, true);
        				}
        				
        				break;
        				
        			case GraphicZoomMode.ZoomXY:
        				
        				//Zoom Y
        				if (CursorPosMouseUp.Y > CursorPosMouseDown.Y)
        				{
        					bPlot = Set_DataFileForYZoom(CursorPosMouseDown.Y, CursorPosMouseUp.Y, true);
        				}
        				else
        				{
        					bPlot = Set_DataFileForYZoom(CursorPosMouseUp.Y, CursorPosMouseDown.Y, true);
        				}
        				
        				//Zoom X
        				if (bPlot)
        				{
        					if (ZoomBoxCoords[0].Abs < ZoomBoxCoords[1].Abs)
	        				{
	        					bPlot = Set_DataFile_BetweenAbsPoint(ZoomBoxCoords[0].Abs, ZoomBoxCoords[1].Abs);
	        				} 
	        				else
	        				{
	        					bPlot = Set_DataFile_BetweenAbsPoint(ZoomBoxCoords[1].Abs, ZoomBoxCoords[0].Abs);
	        				}
        				}
        				
        				break;
        				
        			default:
        				
        				return;
        		}
        		
        		if (bPlot)
        		{
                    eCurrentStage = GraphDrawingStages.Scratch;
                    oGraphicUpdateRequest.UpdateRequested = true;
                }
        	}
        }
        
        private void ZoomPlus()
        {
        	ZoomPlus(false);
        }
        	
        private void ZoomPlus(bool ZoomMax)
        {
        	bool bPlot = false;
        	
        	switch (Properties.ZoomMode)
        	{
        		case GraphicZoomMode.ZoomX:
        			
		        	bPlot = Zoom_X_Plus(ZoomMax);
		        	break;
		        	
		        case GraphicZoomMode.ZoomY:
		        	
		        	bPlot = Zoom_Y_Plus(ZoomMax);
		        	break;
		        	
		        case GraphicZoomMode.ZoomXY:
		        	
		        	if (Zoom_Y_Plus(ZoomMax))
		        	{
		        		bPlot = Zoom_X_Plus(ZoomMax);
		        	}
		        	
		        	break;
        	}
        	
        	if (bPlot)
        	{
                eCurrentStage = GraphDrawingStages.Scratch;
                oGraphicUpdateRequest.UpdateRequested = true;
            }
        }
        
        private bool Zoom_X_Plus(bool ZoomMax)
        {
        	GraphicCoordinates ZoomCenter = null;
        	double XZoomRange, ZoomX1, ZoomX2;
        	
        	if (!(PtCursorPos.Equals(Point.Empty) || Properties.Cursor.Mode.Equals(GraphicCursorMode.HorizontalLine))) //Main cursor visible
        	{
        		ZoomCenter = GetPointGraphCoordinates(PtCursorPos);
        	}
        	else //Main cursor unvisible
        	{
        		ZoomCenter = new Ctrl_WaveForm.GraphicCoordinates();
        		ZoomCenter.Abs = Properties.AbscisseAxis.CoordConversion.Min + ((Properties.AbscisseAxis.CoordConversion.Max - Properties.AbscisseAxis.CoordConversion.Min) / 2);
        	}
        	
        	if (!(ZoomCenter == null))
        	{
        		XZoomRange = 0;
        		
        		if (ZoomMax)
        		{
        			if (Properties.AbscisseAxis.TimeMode)
        			{
                        if (WholeDataFile.StepTimeMin > 0)
                        {
                            XZoomRange = WholeDataFile.StepTimeMin * 3; //Show at least 3 samples
                        }
                        else
                        {
                            return (false);
                        }
        			}
        			else
        			{
        				XZoomRange = (Properties.AbscisseAxis.CoordConversion.Max - Properties.AbscisseAxis.CoordConversion.Min) / 100; //1% of the full value range
        			}
        		}
        		else
        		{
        			XZoomRange = (Properties.AbscisseAxis.CoordConversion.Max - Properties.AbscisseAxis.CoordConversion.Min) / ((double) ZoomFactors[ZoomFactorIndex]);
        		}
        		
        		if (XZoomRange > 0)
        		{
        			ZoomX1 = ZoomCenter.Abs - (XZoomRange / 2);
        			if (ZoomX1 < Properties.AbscisseAxis.CoordConversion.Min)
        			{
        				ZoomX1 = Properties.AbscisseAxis.CoordConversion.Min;
        			}
        			
        			ZoomX2 = ZoomX1 + XZoomRange;
        			if (ZoomX2 > Properties.AbscisseAxis.CoordConversion.Max)
        			{
        				ZoomX2 = Properties.AbscisseAxis.CoordConversion.Max;
        			}
        			
        			if (!(ZoomX1 == ZoomX2))
        			{
        				if (Set_DataFile_BetweenAbsPoint (ZoomX1, ZoomX2))
        				{
        					return(true);
        				}
        			}
        		}
        	}
        	
        	return(false);
        }
        
        private bool Zoom_Y_Plus(bool ZoomMax)
        {
        	int ZoomCenter = -1;
        	double ZoomRange = 0;
        	int ZoomY1, ZoomY2;
        	
        	if (!(PtCursorPos.Equals(Point.Empty) || Properties.Cursor.Mode.Equals(GraphicCursorMode.VerticalLine))) //Main cursor visible
        	{
        		ZoomCenter = PtCursorPos.Y;
        	}
        	else
        	{
        		ZoomCenter = FrameHeight / 2;
        	}
        	
        	if (ZoomCenter > 0 && ZoomCenter < FrameHeight)
        	{
        		if (ZoomMax) //1% of the whole graph height
        		{
        			ZoomRange = ((double)FrameHeight / 100);
        		}
        		else
        		{
        			ZoomRange = ((double)FrameHeight / (double)ZoomFactors[ZoomFactorIndex]);
        		}
        		
        		if (ZoomRange > 0)
        		{
        			ZoomY1 = (int)((double)ZoomCenter - (ZoomRange / 2));
        			if (ZoomY1 < 0)
        			{
        				ZoomY1 = 0;
        			}
        			
        			ZoomY2 = ZoomY1 + (int)ZoomRange;
        			if (ZoomY2 > FrameHeight)
        			{
        				ZoomY2 = FrameHeight;
        			}
        			
        			if (!(ZoomY1 == ZoomY2))
        			{
        				if (Set_DataFileForYZoom(ZoomY1, ZoomY2, true))
        				{
        					return(true);
        				}
        			}
        		}
        	}
        	
        	return(false);
        }
        
        private void ZoomMinus()
        {
        	bool bPlot = false;
        	
        	switch (Properties.ZoomMode)
        	{
        		case GraphicZoomMode.ZoomX:
        			
		        	bPlot = Zoom_X_Minus();
		        	break;
		        	
		        case GraphicZoomMode.ZoomY:
		        	
		        	bPlot = Zoom_Y_Minus();
		        	break;
		        	
		        case GraphicZoomMode.ZoomXY:
		        	
		        	if (Zoom_Y_Minus())
		        	{
		        		bPlot = Zoom_X_Minus();
		        	}
		        	
		        	break;
        	}
        	
        	if (bPlot)
        	{
                eCurrentStage = GraphDrawingStages.Scratch;
                oGraphicUpdateRequest.UpdateRequested = true;
            }
        }
        
        private void ZoomMin()
        {
        	DataFile = WholeDataFile;
        	bXZoom = false;
        	bYZoom = false;
            eCurrentStage = GraphDrawingStages.Scratch;
            oGraphicUpdateRequest.UpdateRequested = true;

        }
        
        private bool Zoom_X_Minus()
        {
            if (!(Properties.AbscisseAxis.CoordConversion.Min == WholeDataFile.SampleTimeMin && Properties.AbscisseAxis.CoordConversion.Max == WholeDataFile.SampleTimeMax))
        	{
        		GraphicCoordinates ZoomCenter = null;
        		double XZoomRange, ZoomX1, ZoomX2;
        		
        		if (!(PtCursorPos.Equals(Point.Empty) || Properties.Cursor.Mode.Equals(GraphicCursorMode.HorizontalLine))) //Main cursor visible
        		{
        			ZoomCenter = GetPointGraphCoordinates(PtCursorPos);
        		}
        		else //Main cursor unvisible
        		{
        			ZoomCenter = new Ctrl_WaveForm.GraphicCoordinates();
        			ZoomCenter.Abs = Properties.AbscisseAxis.CoordConversion.Min + ((Properties.AbscisseAxis.CoordConversion.Max - Properties.AbscisseAxis.CoordConversion.Min) / 2);
        		}
        		
        		if (!(ZoomCenter == null))
        		{
        			XZoomRange = (Properties.AbscisseAxis.CoordConversion.Max - Properties.AbscisseAxis.CoordConversion.Min) * ((double) ZoomFactors[ZoomFactorIndex]);
        			
        			ZoomX1 = ZoomCenter.Abs - (XZoomRange / 2);
        			if (ZoomX1 < WholeDataFile.SampleTimeMin)
        			{
        				ZoomX1 = WholeDataFile.SampleTimeMin;
        			}
        			
        			ZoomX2 = ZoomX1 + XZoomRange;
        			if (ZoomX2 > WholeDataFile.SampleTimeMax)
        			{
        				ZoomX2 = WholeDataFile.SampleTimeMax;
        			}
        			
        			if (Set_DataFile_BetweenAbsPoint (ZoomX1, ZoomX2))
        			{
        				if (ZoomX1 == WholeDataFile.SampleTimeMin && ZoomX2 == WholeDataFile.SampleTimeMax)
	        			{
	        				bXZoom = false;
	        			}
        				
        				return(true);
        			}
        		}
        	}
        	
        	return(false);
        }
        
        private bool Zoom_Y_Minus()
        {
        	if (!(RefZoomYUpperBound == 0 && RefZoomYLowerBound == FrameHeight))
        	{
        		
        		int ZoomCenter = -1;
        		int ZoomY1, ZoomY2;
        		double ZoomRange = 0;
        		
        		if (!(PtCursorPos.Equals(Point.Empty) || Properties.Cursor.Mode.Equals(GraphicCursorMode.VerticalLine))) //Main cursor visible
        		{
        			double a = (double)(RefZoomYLowerBound - RefZoomYUpperBound) / (double)(FrameHeight);
        			double b = (double)RefZoomYLowerBound - a * (double)FrameHeight;
        			
        			ZoomCenter =  (int)((double)PtCursorPos.Y *a + b);
        		}
        		else
        		{
        			ZoomCenter = RefZoomYUpperBound + ((RefZoomYLowerBound -  RefZoomYUpperBound) / 2);
        		}
        		
        		if (ZoomCenter >= 0 && ZoomCenter <= FrameHeight)
        		{
        			ZoomRange = (double)(RefZoomYLowerBound - RefZoomYUpperBound) * (double)ZoomFactors[ZoomFactorIndex];
        			
        			if (ZoomRange > 0)
        			{
        				ZoomY1 = (int)((double)ZoomCenter - (ZoomRange / 2));
        				if (ZoomY1 < 0)
        				{
        					ZoomY1 = 0;
        				}
        				
        				ZoomY2 = ZoomY1 + (int)ZoomRange;
        				if (ZoomY2 > FrameHeight)
        				{
        					ZoomY2 = FrameHeight;
        				}
        				
        				if (!(ZoomY1 == ZoomY2))
        				{
        					if (Set_DataFileForYZoom(ZoomY1, ZoomY2, false))
        					{
        						return(true);
        					}
        				}
        			}
        		}
        	}
        	
        	return(false);
        }
        
        private void Plot_DataAtXZoomBarPosition()
        {
            double StartRangeRatio = (double)(Cmd_ZoomXPosition.Left - FrameLeftPoint) / (double)FrameWidth;
        	double X1 = WholeDataFile.SampleTimeMin + ((WholeDataFile.SampleTimeMax - WholeDataFile.SampleTimeMin) * StartRangeRatio);
        	
        	double VisibleRangeRatio = (double)Cmd_ZoomXPosition.Width / (double)FrameWidth;
        	double X2 = X1 + ((WholeDataFile.SampleTimeMax - WholeDataFile.SampleTimeMin) * VisibleRangeRatio);
        	
        	if (Set_DataFile_BetweenAbsPoint(X1, X2))
        	{
                eCurrentStage = GraphDrawingStages.Scratch;
                oGraphicUpdateRequest.UpdateRequested = true;
            }
        }
        
        private void Plot_DataAtYZoomBarPosition()
        {
        	int ZoomY1, ZoomY2;
        	
        	ZoomY1 = Cmd_ZoomYPosition.Top - FrameTopPoint;
        	ZoomY2 = ZoomY1 + Cmd_ZoomYPosition.Height;
        	
        	if (Set_DataFileForYZoom(ZoomY1, ZoomY2, false))
        	{
                eCurrentStage = GraphDrawingStages.Scratch;
                oGraphicUpdateRequest.UpdateRequested = true;
            }    
        }
        
        private void Show_ZoomBoxStatistics()
        {
        	GraphicCoordinates[] ZoomBoxCoords = GetZoomBoxGraphCoordinates();
        	
        	if (!(ZoomBoxCoords == null))
        	{
        		SerieStatistics[] Stats = null;
        		
        		if (ZoomBoxCoords[0].Abs < ZoomBoxCoords[1].Abs)
        		{
        			Stats = Get_SeriesStatisticsBetweenPoints(ZoomBoxCoords[0].Abs, ZoomBoxCoords[1].Abs);
        		}
        		else
        		{
        			Stats = Get_SeriesStatisticsBetweenPoints(ZoomBoxCoords[1].Abs, ZoomBoxCoords[0].Abs);
        		}
        		
        		if (!(Stats == null))
        		{
        			Frm_GraphSeriesStatistics Frm = new Frm_GraphSeriesStatistics(Stats, Properties.WindowBackColor);
        			Frm.Show();
        		}
        	}
        }
        
        private GraphicCoordinates[] GetZoomBoxGraphCoordinates()
        {
        	if (!(CursorPosMouseDown.Equals(Point.Empty) || CursorPosMouseUp.Equals(Point.Empty)))
        	{
        		GraphicCoordinates[] Coords = new Ctrl_WaveForm.GraphicCoordinates[2];
        		
        		Coords[0] = GetPointGraphCoordinates(CursorPosMouseDown);
        		Coords[1] = GetPointGraphCoordinates(CursorPosMouseUp);
        		
        		if (!(Coords[0].Abs == double.NaN || Coords[1].Abs == double.NaN))
        		{
        			return(Coords);
        		}
        	}
        	
        	return(null);
        }
        
        private GraphicCoordinates GetPointGraphCoordinates(Point Pt)
        {
        	GraphicCoordinates Coord = new Ctrl_WaveForm.GraphicCoordinates();
        	
        	Coord.Abs = Get_AbscisseValueAtPostion(Pt.X);
        	Coord.Ords = Get_OrdinateValuesAtPosition(Pt.Y);
        	
        	return(Coord);
        }
        
        private SerieStatistics[] Get_SeriesStatisticsBetweenPoints(double X1, double X2)
        {
        	List<SerieStatistics> Stats = new List<SerieStatistics>();
        	
        	foreach (GraphSerieProperties oSerieProp in Properties.SeriesProperties)
        	{
        		if (oSerieProp.Visible && (oSerieProp.Trace.Visible || oSerieProp.Markers.Visible))
        		{
        			GW_DataChannel oSerieData = DataFile.Get_DataChannel(oSerieProp.Name);
        			
        			if (!(oSerieData == null))
        			{
        				SerieStatistics sSerieStats = new SerieStatistics();
        				
        				sSerieStats.Title = oSerieProp.Label;
        				sSerieStats.SerieColor = oSerieProp.Trace.LineColor;

                        if (DataFile.DataSamplingMode == SamplingMode.MultipleRates)
                        {
                            int iSampleX1 = oSerieData.Get_SampleTimeIndex(X1);
                            int iSampleX2 = oSerieData.Get_SampleTimeIndex(X2) + 1;

                            if(iSampleX2==0)
                            {
                                iSampleX2 = oSerieData.Samples.Count;
                            }

                            if (iSampleX1 != -1 && iSampleX2 != -1)
                            {
                                for (int iSample = iSampleX1; iSample < iSampleX2; iSample++)
                                {
                                    //Min & max
                                    if (iSample != iSampleX1)
                                    {
                                        if(oSerieData.Samples[iSample].SampleValue<sSerieStats.Min)
                                        {
                                            sSerieStats.Min = oSerieData.Samples[iSample].SampleValue;
                                            sSerieStats.MinX = oSerieData.Samples[iSample].SampleTime;
                                        }

                                        if (oSerieData.Samples[iSample].SampleValue > sSerieStats.Max)
                                        {
                                            sSerieStats.Max = oSerieData.Samples[iSample].SampleValue;
                                            sSerieStats.MaxX = oSerieData.Samples[iSample].SampleTime;
                                        }
                                    }
                                    else
                                    {
                                        sSerieStats.Min = oSerieData.Samples[iSample].SampleValue;
                                        sSerieStats.Max = oSerieData.Samples[iSample].SampleValue;

                                        sSerieStats.MinX = oSerieData.Samples[iSample].SampleTime;
                                        sSerieStats.MaxX = oSerieData.Samples[iSample].SampleTime;
                                    }

                                    //Avg & AvgAbs
                                    sSerieStats.Avg += oSerieData.Samples[iSample].SampleValue;
                                    sSerieStats.AvgAbs += Math.Abs(oSerieData.Samples[iSample].SampleValue);

                                    //Sample count
                                    sSerieStats.SampleCount++;

                                    //Final Avg & AvgAbs computation
                                    sSerieStats.Avg /= sSerieStats.SampleCount;
                                    sSerieStats.AvgAbs /= sSerieStats.SampleCount;
                                }

                                //StdDev computation
                                double SumSquare = 0;

                                for (int iSample = iSampleX1; iSample < iSampleX2; iSample++)
                                {
                                    SumSquare += Math.Pow((sSerieStats.Avg - oSerieData.Samples[iSample].SampleValue), 2);
                                }

                                sSerieStats.StdDev = Math.Sqrt(SumSquare / sSerieStats.SampleCount);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < oAbcsisseChannel.Values.Count; i++)
                            {
                                if (oAbcsisseChannel.Values[i] >= X1 && oAbcsisseChannel.Values[i] <= X2)
                                {
                                    //Min & max
                                    if (!(sSerieStats.SampleCount == 0))
                                    {
                                        if (oSerieData.Values[i] < sSerieStats.Min)
                                        {
                                            sSerieStats.Min = oSerieData.Values[i];
                                            sSerieStats.MinX = oAbcsisseChannel.Values[i];
                                        }

                                        if (oSerieData.Values[i] > sSerieStats.Max)
                                        {
                                            sSerieStats.Max = oSerieData.Values[i];
                                            sSerieStats.MaxX = oAbcsisseChannel.Values[i];
                                        }
                                    }
                                    else
                                    {
                                        sSerieStats.Min = oSerieData.Values[i];
                                        sSerieStats.Max = oSerieData.Values[i];

                                        sSerieStats.MinX = oAbcsisseChannel.Values[i];
                                        sSerieStats.MaxX = oAbcsisseChannel.Values[i];
                                    }

                                    //Avg & AvgAbs
                                    sSerieStats.Avg += oSerieData.Values[i];
                                    sSerieStats.AvgAbs += Math.Abs(oSerieData.Values[i]);

                                    //Sample count
                                    sSerieStats.SampleCount++;
                                }
                            }

                            //Final Avg & AvgAbs computation
                            sSerieStats.Avg /= sSerieStats.SampleCount;
                            sSerieStats.AvgAbs /= sSerieStats.SampleCount;

                            //StdDev computation
                            double SumSquare = 0;

                            for (int i = 0; i < oAbcsisseChannel.Values.Count; i++)
                            {
                                if (oAbcsisseChannel.Values[i] >= X1 && oAbcsisseChannel.Values[i] <= X2)
                                {
                                    SumSquare += Math.Pow((sSerieStats.Avg - oSerieData.Values[i]), 2);
                                }
                            }

                            sSerieStats.StdDev = Math.Sqrt(SumSquare / sSerieStats.SampleCount);
                        }
        				
        				//Add serie statitics into the list
        				Stats.Add(sSerieStats);
        			}
        		}
        	}
        	
        	return(Stats.ToArray());
        }

        private bool Set_DataFile_BetweenAbsPoint(double X1, double X2)
        {
            switch(DataFile.DataSamplingMode)
            {
                case SamplingMode.SingleRate:

                    return (Set_DataFile_BetweenAbsPoint_SingleRateSampling(X1, X2));

                case SamplingMode.MultipleRates:

                    return (Set_DataFile_BetweenAbsPoint_MultipleRatesSampling(X1, X2));
            }

            return (false);
        }

        private bool Set_DataFile_BetweenAbsPoint_MultipleRatesSampling(double X1, double X2)
        {
            GW_DataFile TmpDataFile = new GW_DataFile();
            TmpDataFile.DataSamplingMode = SamplingMode.MultipleRates;

            foreach (GW_DataChannel oWholeDataChan in WholeDataFile.Channels)
            {
                int iSampleX1 = oWholeDataChan.Get_SampleTimeIndex(X1);
                int iSampleX2 = oWholeDataChan.Get_SampleTimeIndex(X2);

                if(iSampleX2==-1)
                {
                    iSampleX2 = oWholeDataChan.Samples.Count - 1;
                }

                if (iSampleX1 != -1 && iSampleX2 != -1)
                {
                    GW_DataChannel oDataChan = new GW_DataChannel(oWholeDataChan.Name, SamplingMode.MultipleRates);
                    oDataChan.Samples = oWholeDataChan.Samples.GetRange(iSampleX1, (iSampleX2 - iSampleX1));

                    if (oDataChan.Samples.Count > 1)
                    {
                        oDataChan.ProcessChannelStatistic();
                        TmpDataFile.Channels.Add(oDataChan);
                    }
                }
            }

            if(TmpDataFile.Channels.Count>0)
            {
                bXZoom = true;
                DataFile = TmpDataFile;
                return (true);
            }

            return (false);
        }

        private bool Set_DataFile_BetweenAbsPoint_SingleRateSampling(double X1, double X2)
        {
        	GW_DataFile TmpDataFile = new GW_DataFile();
        	
        	for (int iSample = 0; iSample < oWholeAbcsisseChannel.Values.Count; iSample++)
        	{
        		if (oWholeAbcsisseChannel.Values[iSample] >= X1 && oWholeAbcsisseChannel.Values[iSample] <= X2)
        		{
        			TmpDataFile.Time.Add_ChannelValue(WholeDataFile.Time.Values[iSample]);
        			
        			foreach (GW_DataChannel oDataChan in DataFile.Channels)
        			{
        				GW_DataChannel oChan = null;
        				GW_DataChannel oWholeChan = WholeDataFile.Get_DataChannel(oDataChan.Name);
        				
        				if (!(oWholeChan == null))
        				{
	        				if (TmpDataFile.DataChannelExists(oDataChan.Name))
	        				{
	        					oChan = TmpDataFile.Get_DataChannel(oDataChan.Name);
	        				}
	        				else
	        				{
	        					oChan = new GW_DataChannel();
	        					oChan.Name = oDataChan.Name;
	        					TmpDataFile.Channels.Add(oChan);
	        				}
	        				
	        				if (!(oChan == null))
	        				{
	        					oChan.Add_ChannelValue(oWholeChan.Values[iSample]);
	        				}
        				}
        			}
        		}
        	}
        	
        	if (TmpDataFile.Channels.Count > 0)
        	{
        		if (TmpDataFile.Channels[0].Values.Count > 1)
        		{
        			//In case of uneven values repartition zoom magnitude may be lost
        			//X = [00, 10, 11, 12, 25, 26, 30]
        			//Y = [01, 05, 26, 32, 54, 22, 56]  
        			//Then zoom magnitude is forced
        			if (Properties.AbscisseAxis.TimeMode)
        			{
        				TmpDataFile.Time.Min = X1;
        				TmpDataFile.Time.Max = X2;
        			}
        			else
        			{
        				GW_DataChannel oAbsTmp = TmpDataFile.Get_DataChannel(Properties.AbscisseAxis.AbscisseChannelName);
        				
        				if (!(oAbsTmp == null))
        				{
        					oAbsTmp.Min = X1;
        					oAbsTmp.Max = X2;
        				}
        			}
        			
        			bXZoom = true;
        			DataFile = TmpDataFile;
        			return(true);
        		}
        	}
        	
        	return(false);
        }
        
        private bool Set_DataFileForYZoom(int TopPosition, int BottomPosition, bool bZoomIn)
        {        	
        	int tmpi = 0;
        	
        	GW_DataFile ReferenceDataFile = null;
        	
        	if (bZoomIn) //Zoom In
        	{
        		ReferenceDataFile = DataFile;
        	}
        	else //Zoom Out
        	{
        		ReferenceDataFile = WholeDataFile;
        	}
        	
        	GW_DataFile TmpDataFile = new GW_DataFile();
            TmpDataFile.DataSamplingMode = ReferenceDataFile.DataSamplingMode;

            if (ReferenceDataFile.DataSamplingMode == SamplingMode.SingleRate) TmpDataFile.Time = ReferenceDataFile.Time;
        	
        	foreach (GraphSerieProperties oProp in Properties.SeriesProperties)
        	{	
        		if((oProp.Visible && (oProp.Trace.Visible || oProp.Markers.Visible)) && ReferenceDataFile.DataChannelExists(oProp.Name))
        		{
        			GW_DataChannel oRefChanData = ReferenceDataFile.Get_DataChannel(oProp.Name);
        			
        			if (!(oRefChanData == null))
        			{        				
        				Nullable<GW_SampleCoordConversion> sRefCoordConv = null;
        				
        				if (bZoomIn)
        				{
        					sRefCoordConv = oProp.CoordConversion;
        				}
        				else
        				{
        					sRefCoordConv = Get_SerieReferenceCoordConversion(oProp.KeyId);
        				}
        				
        				if (sRefCoordConv.HasValue)
        				{	        					
        					//If serie is within the given ordinates range
        					if ((TopPosition >= sRefCoordConv.Value.Top && TopPosition < sRefCoordConv.Value.Bottom)
        					    || (BottomPosition > sRefCoordConv.Value.Top && BottomPosition <= sRefCoordConv.Value.Bottom)
        					    || (TopPosition < sRefCoordConv.Value.Top && BottomPosition > sRefCoordConv.Value.Bottom))
        					{

                                GW_DataChannel oChanData = null;

                                if (ReferenceDataFile.DataSamplingMode == SamplingMode.MultipleRates)
                                {
                                    oChanData = new GW_DataChannel(SamplingMode.MultipleRates);

                                    oChanData.Name = oRefChanData.Name;
                                    oChanData.Samples = oRefChanData.Samples;
                                    oChanData.Avg = oRefChanData.Avg;
                                    oChanData.Min = oRefChanData.Min;
                                    oChanData.Max = oRefChanData.Max;
                                }
                                else
                                {
                                    oChanData = new GW_DataChannel();

                                    oChanData.Name = oRefChanData.Name;
                                    oChanData.Values = oRefChanData.Values;
                                    oChanData.Avg = oRefChanData.Avg;
                                    oChanData.Min = oRefChanData.Min;
                                    oChanData.Max = oRefChanData.Max;
                                }
        						
        						double ValGain = (sRefCoordConv.Value.Max - sRefCoordConv.Value.Min) / (sRefCoordConv.Value.Top - sRefCoordConv.Value.Bottom);
        						double ValOffset = sRefCoordConv.Value.Max - ValGain * sRefCoordConv.Value.Top;
        						
        						double PosGain = (double)(FrameHeight) / (double)(BottomPosition - TopPosition);
        						double PosOffset = 0 - PosGain * (double)TopPosition;
        						
        						if (sRefCoordConv.Value.Top < TopPosition)
        						{        							
        							oProp.CoordConversion.Top =  0;
        							oProp.CoordConversion.Max = (double)TopPosition * ValGain + ValOffset;
        						}
        						else
        						{
        							tmpi = (int)(sRefCoordConv.Value.Top * PosGain + PosOffset);
        							
        							oProp.CoordConversion.Top = tmpi;
        							oProp.CoordConversion.Max = sRefCoordConv.Value.Max;
        						}
        						
        						if (sRefCoordConv.Value.Bottom > BottomPosition)
        						{        							
        							oProp.CoordConversion.Bottom = FrameHeight;
        							oProp.CoordConversion.Min = (double)BottomPosition * ValGain + ValOffset;
        						}
        						else
        						{
        							tmpi = (int)(sRefCoordConv.Value.Bottom * PosGain + PosOffset);
        							
        							oProp.CoordConversion.Bottom = tmpi;
        							oProp.CoordConversion.Min = sRefCoordConv.Value.Min;
        						}
        						
        						if (!((oProp.CoordConversion.Top == oProp.CoordConversion.Bottom) || (oProp.CoordConversion.Min == oProp.CoordConversion.Max)))
        						{        							
        							oProp.CoordConversion.Gain = (double)((double)(oProp.CoordConversion.Top - oProp.CoordConversion.Bottom) / (oProp.CoordConversion.Max - oProp.CoordConversion.Min));
        							oProp.CoordConversion.Zero = (double)((double)(oProp.CoordConversion.Top) - oProp.CoordConversion.Gain * oProp.CoordConversion.Max);
        							
        							TmpDataFile.Channels.Add(oChanData);
        						}
        					}
        				}
        			}
        		}
        	}
        	
        	if (TmpDataFile.Channels.Count > 0)
        	{
                bool bDataPresent = false;

                if(TmpDataFile.DataSamplingMode == SamplingMode.MultipleRates)
                {
                    bDataPresent = (TmpDataFile.MaxSampleCount > 1);
                }
                else
                {
                    bDataPresent = (TmpDataFile.Channels[0].Values.Count > 1);
                }

                if (bDataPresent)
        		{
        			if (!Properties.AbscisseAxis.TimeMode)
        			{
        				GW_DataChannel oAbs = ReferenceDataFile.Get_DataChannel(Properties.AbscisseAxis.AbscisseChannelName);
        				if (oAbs == null) return(false);
        				TmpDataFile.Channels.Add(oAbs);
        			}
        			
        			bYZoom = true;
        			DataFile = TmpDataFile;
        			
        			if (bXZoom && !bZoomIn)
        			{
        				if (!Set_DataFile_BetweenAbsPoint(Properties.AbscisseAxis.CoordConversion.Min, Properties.AbscisseAxis.CoordConversion.Max))
        				{
        					return(false);
        				}
        			}
        			
        			//Zoom Y reference bounds update
        			if ((RefZoomYUpperBound == 0 && RefZoomYLowerBound == FrameHeight) || (!bZoomIn)) //No Y zoom yet OR Zoom out
        			{
        				RefZoomYUpperBound = TopPosition;
        				RefZoomYLowerBound = BottomPosition;
        			}
        			else //Already Y zooming
        			{
        				double a = (double)(RefZoomYLowerBound - RefZoomYUpperBound) / (double)(FrameHeight);
        				double b = (double)RefZoomYLowerBound - a * (double)FrameHeight;
        				
        				RefZoomYUpperBound = (int)((double)TopPosition * a + b);
        				RefZoomYLowerBound = (int)((double)BottomPosition * a + b);
        			}
        			
        			if (RefZoomYUpperBound == 0 && RefZoomYLowerBound == FrameHeight)
        			{
        				bYZoom = false;
        			}
        			
        			return(true);
        		}
        	}
        	
        	return(false);
        }
        
        private void Set_ZoomBars()
        {
        	if (bXZoom)
        	{
                double VisibleRangeRatio = 0;
                double StartRangeRatio = 0;

                if (DataFile.DataSamplingMode== SamplingMode.MultipleRates)
                {
                    VisibleRangeRatio = (WholeDataFile.SampleTimeMax - WholeDataFile.SampleTimeMin) / (DataFile.SampleTimeMax - DataFile.SampleTimeMin);
                    StartRangeRatio = DataFile.SampleTimeMin / (WholeDataFile.SampleTimeMax - WholeDataFile.SampleTimeMin);
                }
                else
                {
                    VisibleRangeRatio = (oWholeAbcsisseChannel.Max - oWholeAbcsisseChannel.Min) / (oAbcsisseChannel.Max - oAbcsisseChannel.Min);
                    StartRangeRatio = oAbcsisseChannel.Min / (oWholeAbcsisseChannel.Max - oWholeAbcsisseChannel.Min);
                }

        		Cmd_ZoomXPosition.Width = (int)(FrameWidth / VisibleRangeRatio);
        		Cmd_ZoomXPosition.Left = FrameLeftPoint + (int)(FrameWidth * StartRangeRatio);
        		Cmd_ZoomXPosition.Visible = true;
        	}
        	else
        	{
        		Cmd_ZoomXPosition.Visible = false;
        	}
        	
        	if (bYZoom)
        	{
        		double VisibleRangeRatio = (double)FrameHeight / (double)(RefZoomYLowerBound -  RefZoomYUpperBound);
        		Cmd_ZoomYPosition.Height = (int)(FrameHeight / VisibleRangeRatio);
        		
        		Cmd_ZoomYPosition.Left = FrameRightPoint + 6;
        		Cmd_ZoomYPosition.Top = RefZoomYUpperBound + FrameTopPoint;
        		
        		Cmd_ZoomYPosition.Visible = true;
        	}
        	else
        	{
        		Cmd_ZoomYPosition.Visible = false;
        	}
        }
        
        private Nullable<GW_SampleCoordConversion> Get_SerieReferenceCoordConversion(int SerieKeyId)
        {
        	foreach (SerieCoordConversion sSCC in SeriesReferenceCoordConversion)
        	{
        		if (sSCC.SerieKeyId == SerieKeyId)
        		{
        			return (sSCC.CoordConversion);
        		}
        	}
        	
        	return(null);
        }
        
        #endregion
         
        #region Legend
         
        private void Init_Legend()
        {
            Grid_Legend.Rows.Clear();
            Grid_Legend.BackgroundColor = Properties.WindowBackColor;
            
            if(Properties.LegendProperties.LegendGridLinesVisible)
            {
                Grid_Legend.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
            else
            {
                Grid_Legend.CellBorderStyle = DataGridViewCellBorderStyle.None;
            }

            Grid_Legend.ColumnHeadersVisible = Properties.LegendProperties.LegendHeaderVisible;

            if(Properties.LegendProperties.Visible)
            {
                Grid_Legend.GridColor = Properties.Frame.BorderColor;

                Grid_Legend.Columns[LEGEND_LABEL_COL].Visible         = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.Label);
                Grid_Legend.Columns[LEGEND_VALUE_COL].Visible         = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.CurrentValue);
                Grid_Legend.Columns[LEGEND_UNIT_COL].Visible          = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.Unit);
                Grid_Legend.Columns[LEGEND_MIN_COL].Visible           = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.GraphMin);
                Grid_Legend.Columns[LEGEND_MAX_COL].Visible           = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.GraphMax);
                Grid_Legend.Columns[LEGEND_AVG_COL].Visible           = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.GraphAvg);
                Grid_Legend.Columns[LEGEND_REF_VAL_COL].Visible       = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.RefCursorValue);
                Grid_Legend.Columns[LEGEND_REF_DIFF_COL].Visible      = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.RefCursorDiffValue);
                Grid_Legend.Columns[LEGEND_REF_DIFF_PERC_COL].Visible = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.RefCursorDiffPerc);
                Grid_Legend.Columns[LEGEND_REF_GRADIENT_COL].Visible  = Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.RefCursorGradient);
            }
        }

        private void UpDate_LegendValues(double AbscisseValue)
        {
            switch(DataFile.DataSamplingMode)
            {
                case SamplingMode.SingleRate:

                    UpDate_LegendValues_SingleRateSampling(AbscisseValue);
                    break;

                case SamplingMode.MultipleRates:

                    UpDate_LegendValues_MultipleRatesSampling(AbscisseValue);
                    break;
            }
        }

        private void UpDate_LegendValues_MultipleRatesSampling(double AbscisseValue)
        {
            foreach(DataGridViewRow oLegRow in Grid_Legend.Rows)
            {
                GraphSerieProperties oSerieProp = Properties.Get_SerieAtKey((int)oLegRow.Cells[LEGEND_LABEL_COL].Tag);

                if (!(oSerieProp == null))
                {
                    double SerieValue = DataFile.Get_ChannelValueAtTime(oSerieProp.Name, AbscisseValue);

                    if (!(double.IsNaN(SerieValue)))
                    {
                        Set_LegendItemValues(oLegRow, SerieValue, AbscisseValue, oSerieProp);
                    }
                }
            }
        }

        private void UpDate_LegendValues_SingleRateSampling(double AbscisseValue)
        {
        	int TimeSampleIndex = DataFile.Get_SampleIndexAtTime(AbscisseValue);
        	
        	if (!(TimeSampleIndex == -1))
        	{
                foreach (DataGridViewRow oLegRow in Grid_Legend.Rows)
                {
                    GraphSerieProperties oSerieProp = Properties.Get_SerieAtKey((int)oLegRow.Cells[LEGEND_LABEL_COL].Tag);

                    if (!(oSerieProp == null))
                    {
                        double SerieValue = DataFile.Get_ChannelValueAtIndex(oSerieProp.Name, TimeSampleIndex);

                        if (!(double.IsNaN(SerieValue)))
                        {
                            Set_LegendItemValues(oLegRow, SerieValue, AbscisseValue, oSerieProp);
                        }
                    }
                }
        	}
        }
        
        private void Set_LegendItemValues(DataGridViewRow LegendRow, double ItemValue, double AbscisseValue, GraphSerieProperties oSerieProp)
        {
            //Main cursor value
            LegendRow.Cells[LEGEND_VALUE_COL].Value = oSerieProp.ValueFormat.Get_ValueFormatted(ItemValue);

            //Reference cursor values
            if (!(RefCursorCoordinates == null))
            {
                SerieValueAtPoint RefCursorOrd = new Ctrl_WaveForm.SerieValueAtPoint();

                if (RefCursorCoordinates.Get_OrdinateValue(oSerieProp.KeyId, out RefCursorOrd))
                {
                    LegendRow.Cells[LEGEND_REF_VAL_COL].Value = oSerieProp.ValueFormat.Get_ValueFormatted(RefCursorOrd.SerieDblValue);
                    LegendRow.Cells[LEGEND_REF_DIFF_COL].Value = oSerieProp.ValueFormat.Get_ValueFormatted(RefCursorOrd.SerieDblValue - ItemValue);
                    LegendRow.Cells[LEGEND_REF_DIFF_PERC_COL].Value = ((RefCursorOrd.SerieDblValue - ItemValue) * 100 / RefCursorOrd.SerieDblValue).ToString("F2");
                    LegendRow.Cells[LEGEND_REF_DIFF_PERC_COL].Value = ((RefCursorOrd.SerieDblValue - ItemValue) / (RefCursorCoordinates.Abs - AbscisseValue)).ToString("F3");
                }
            }
        }

        private void UpDate_LegendValues_XY(GraphicCoordinates LegendValue)
        {
        	if (!(LegendValue == null))
        	{
                foreach (DataGridViewRow oRow in Grid_Legend.Rows)
                {
                    SerieValueAtPoint Val = new Ctrl_WaveForm.SerieValueAtPoint();

                    if (LegendValue.Get_OrdinateValue((int)oRow.Cells[LEGEND_LABEL_COL].Tag, out Val))
                    {
                        oRow.Cells[LEGEND_VALUE_COL].Value = Val.SerieValue;

                        if (!(RefCursorCoordinates == null))
                        {
                            SerieValueAtPoint RefCursorOrd = new Ctrl_WaveForm.SerieValueAtPoint();

                            if (RefCursorCoordinates.Get_OrdinateValue((int)oRow.Cells[LEGEND_LABEL_COL].Tag, out RefCursorOrd))
                            {
                                oRow.Cells[LEGEND_REF_VAL_COL].Value = RefCursorOrd.SerieValue;
                                oRow.Cells[LEGEND_REF_DIFF_COL].Value = (RefCursorOrd.SerieDblValue - double.Parse(Val.SerieValue)).ToString("F3");
                                oRow.Cells[LEGEND_REF_DIFF_PERC_COL].Value = (((RefCursorOrd.SerieDblValue - double.Parse(Val.SerieValue)) * 100) / RefCursorOrd.SerieDblValue).ToString("F2");
                                oRow.Cells[LEGEND_REF_GRADIENT_COL].Value = ((RefCursorOrd.SerieDblValue - double.Parse(Val.SerieValue)) / (RefCursorCoordinates.Abs - mMainCursorAbscisse)).ToString("F3");
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewCell oCell in oRow.Cells)
                        {
                            if (!(oCell.ColumnIndex == LEGEND_LABEL_COL || oCell.ColumnIndex == LEGEND_UNIT_COL))
                            {
                                oCell.Value = "NoRx";
                            }
                        }
                    }
                }
        	}
        }
        
        private void ShowHide_Legend()
        {
        	Properties.LegendProperties.Visible = splitContainer2.Panel2Collapsed;
        	splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        	
        }
        
        private void Resize_Legend(bool RefCursorVisible)
        {
        	int SizeOffset = 250 - BaseLegendWidth;;
        	
        	if (RefCursorVisible)
        	{
        		splitContainer2.SplitterDistance -= SizeOffset;
        		Grid_Legend.Width += SizeOffset;
        	}
        	else
        	{
        		if (Grid_Legend.Width >= 250)
        		{
        			splitContainer2.SplitterDistance += SizeOffset;
                    Grid_Legend.Width -= SizeOffset;
        		}
        	}
        }
        
        #endregion
        
        #region Data file functions
        
        private void Load_DataFile()
        {
            if (Dlg_OpenData.ShowDialog().Equals(DialogResult.OK))
            {
                GW_DataFile oNewData = new GW_DataFile();

                if (oNewData.Load_DataFile(Dlg_OpenData.FileName))
                {
                	Set_DataFile(oNewData);
                    oGraphicUpdateRequest.UpdateRequested = true;
                }
                else
                {
                    MessageBox.Show("Data file reading error !", MSG_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataFile = null;
                }
            }
        }
        
        #endregion
        
        #region Graphic properties

        private void Edit_GraphProperties()
        {
            string[] ChannelNames = null;

            if(!(WholeDataFile==null))
            {
            	if (WholeDataFile.Channels.Count > 0)
            	{
	            	ChannelNames = new string[WholeDataFile.Channels.Count];
	                for (int i=0; i<WholeDataFile.Channels.Count; i++)
	                {
	                    ChannelNames[i] = WholeDataFile.Channels[i].Name;
	                }
            	}
            }

            Frm_GraphPropertiesEdtion Frm = new Frm_GraphPropertiesEdtion(this, ChannelNames);
            Frm.Show();
        }
        
        private void Edit_SerieProperties(int SerieKey)
        {
        	GraphSerieProperties oSerieProp = Properties.Get_SerieAtKey(SerieKey);
        	
        	if (!(oSerieProp == null))
        	{
        		Frm_GraphSerieDetailedProperties Frm = new Frm_GraphSerieDetailedProperties(oSerieProp, this, "General");
        		Frm.Show();
        	}
        }
        
        private void Set_Options_Controls()
        {
        	//Graph layout
        	#region Graph layout
        	
        	switch (Properties.GraphLayoutMode)
        	{
        		case GraphicWindowLayoutModes.Overlay:
        			
        			//Context_PicGraph_Options items update
        			Layout_overlayToolStripMenuItem.Checked = true;
        			Layout_parallelToolStripMenuItem.Checked = false;
        			Layout_customToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_overlayToolStripMenuItem.Checked = true;
        			TSDdB_parallelToolStripMenuItem.Checked = false;
        			TSDdB_customToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case GraphicWindowLayoutModes.Parallel:
        			
        			//Context_PicGraph_Options items update
        			Layout_overlayToolStripMenuItem.Checked = false;
        			Layout_parallelToolStripMenuItem.Checked = true;
        			Layout_customToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_overlayToolStripMenuItem.Checked = false;
        			TSDdB_parallelToolStripMenuItem.Checked = true;
        			TSDdB_customToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case GraphicWindowLayoutModes.Custom:
        			
        			//Context_PicGraph_Options items update
        			Layout_overlayToolStripMenuItem.Checked = false;
        			Layout_parallelToolStripMenuItem.Checked = false;
        			Layout_customToolStripMenuItem.Checked = true;
        			
        			//ToolBar items update
        			TSDdB_overlayToolStripMenuItem.Checked = false;
        			TSDdB_parallelToolStripMenuItem.Checked = false;
        			TSDdB_customToolStripMenuItem.Checked = true;
        			
        			break;
        	}
        	
        	#endregion
        	
        	//Cursor
        	#region Cursor
        	
        	switch (Properties.Cursor.Mode)
        	{
        		case GraphicCursorMode.None:
        			
        			//Context_PicGraph_Options items update
        			Cursor_noneToolStripMenuItem.Checked = true;
        			Cursor_verticalLineToolStripMenuItem.Checked = false;
        			Cursor_horizontalLineToolStripMenuItem.Checked = false;
        			Cursor_crossToolStripMenuItem.Checked = false;
        			Cursor_graticuleToolStripMenuItem.Checked = false;
        			Cursor_squareToolStripMenuItem.Checked = false;
        			Cursor_circleToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_noneToolStripMenuItem.Checked = true;
        			TSDdB_verticalLineToolStripMenuItem.Checked = false;
        			TSDdB_horizontalLineToolStripMenuItem.Checked = false;
        			TSDdB_crossToolStripMenuItem.Checked = false;
        			TSDdB_graticuleToolStripMenuItem.Checked = false;
        			TSDdB_squareToolStripMenuItem.Checked = false;
        			TSDdB_circleToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case GraphicCursorMode.VerticalLine:
        			
        			//Context_PicGraph_Options items update
        			Cursor_noneToolStripMenuItem.Checked = false;
        			Cursor_verticalLineToolStripMenuItem.Checked = true;
        			Cursor_horizontalLineToolStripMenuItem.Checked = false;
        			Cursor_crossToolStripMenuItem.Checked = false;
        			Cursor_graticuleToolStripMenuItem.Checked = false;
        			Cursor_squareToolStripMenuItem.Checked = false;
        			Cursor_circleToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_noneToolStripMenuItem.Checked = false;
        			TSDdB_verticalLineToolStripMenuItem.Checked = true;
        			TSDdB_horizontalLineToolStripMenuItem.Checked = false;
        			TSDdB_crossToolStripMenuItem.Checked = false;
        			TSDdB_graticuleToolStripMenuItem.Checked = false;
        			TSDdB_squareToolStripMenuItem.Checked = false;
        			TSDdB_circleToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case GraphicCursorMode.HorizontalLine:
        			
        			//Context_PicGraph_Options items update
        			Cursor_noneToolStripMenuItem.Checked = false;
        			Cursor_verticalLineToolStripMenuItem.Checked = false;
        			Cursor_horizontalLineToolStripMenuItem.Checked = true;
        			Cursor_crossToolStripMenuItem.Checked = false;
        			Cursor_graticuleToolStripMenuItem.Checked = false;
        			Cursor_squareToolStripMenuItem.Checked = false;
        			Cursor_circleToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_noneToolStripMenuItem.Checked = false;
        			TSDdB_verticalLineToolStripMenuItem.Checked = false;
        			TSDdB_horizontalLineToolStripMenuItem.Checked = true;
        			TSDdB_crossToolStripMenuItem.Checked = false;
        			TSDdB_graticuleToolStripMenuItem.Checked = false;
        			TSDdB_squareToolStripMenuItem.Checked = false;
        			TSDdB_circleToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case GraphicCursorMode.Cross:
        			
        			//Context_PicGraph_Options items update
        			Cursor_noneToolStripMenuItem.Checked = false;
        			Cursor_verticalLineToolStripMenuItem.Checked = false;
        			Cursor_horizontalLineToolStripMenuItem.Checked = false;
        			Cursor_crossToolStripMenuItem.Checked = true;
        			Cursor_graticuleToolStripMenuItem.Checked = false;
        			Cursor_squareToolStripMenuItem.Checked = false;
        			Cursor_circleToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_noneToolStripMenuItem.Checked = false;
        			TSDdB_verticalLineToolStripMenuItem.Checked = false;
        			TSDdB_horizontalLineToolStripMenuItem.Checked = false;
        			TSDdB_crossToolStripMenuItem.Checked = true;
        			TSDdB_graticuleToolStripMenuItem.Checked = false;
        			TSDdB_squareToolStripMenuItem.Checked = false;
        			TSDdB_circleToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case GraphicCursorMode.Graticule:
        			
        			//Context_PicGraph_Options items update
        			Cursor_noneToolStripMenuItem.Checked = false;
        			Cursor_verticalLineToolStripMenuItem.Checked = false;
        			Cursor_horizontalLineToolStripMenuItem.Checked = false;
        			Cursor_crossToolStripMenuItem.Checked = false;
        			Cursor_graticuleToolStripMenuItem.Checked = true;
        			Cursor_squareToolStripMenuItem.Checked = false;
        			Cursor_circleToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_noneToolStripMenuItem.Checked = false;
        			TSDdB_verticalLineToolStripMenuItem.Checked = false;
        			TSDdB_horizontalLineToolStripMenuItem.Checked = false;
        			TSDdB_crossToolStripMenuItem.Checked = false;
        			TSDdB_graticuleToolStripMenuItem.Checked = true;
        			TSDdB_squareToolStripMenuItem.Checked = false;
        			TSDdB_circleToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case GraphicCursorMode.Square:
        			
        			//Context_PicGraph_Options items update
        			Cursor_noneToolStripMenuItem.Checked = false;
        			Cursor_verticalLineToolStripMenuItem.Checked = false;
        			Cursor_horizontalLineToolStripMenuItem.Checked = false;
        			Cursor_crossToolStripMenuItem.Checked = false;
        			Cursor_graticuleToolStripMenuItem.Checked = false;
        			Cursor_squareToolStripMenuItem.Checked = true;
        			Cursor_circleToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_noneToolStripMenuItem.Checked = false;
        			TSDdB_verticalLineToolStripMenuItem.Checked = false;
        			TSDdB_horizontalLineToolStripMenuItem.Checked = false;
        			TSDdB_crossToolStripMenuItem.Checked = false;
        			TSDdB_graticuleToolStripMenuItem.Checked = false;
        			TSDdB_squareToolStripMenuItem.Checked = true;
        			TSDdB_circleToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case GraphicCursorMode.Circle:
        			
        			//Context_PicGraph_Options items update
        			Cursor_noneToolStripMenuItem.Checked = false;
        			Cursor_verticalLineToolStripMenuItem.Checked = false;
        			Cursor_horizontalLineToolStripMenuItem.Checked = false;
        			Cursor_crossToolStripMenuItem.Checked = false;
        			Cursor_graticuleToolStripMenuItem.Checked = false;
        			Cursor_squareToolStripMenuItem.Checked = false;
        			Cursor_circleToolStripMenuItem.Checked = true;
        			
        			//ToolBar items update
        			TSDdB_noneToolStripMenuItem.Checked = false;
        			TSDdB_verticalLineToolStripMenuItem.Checked = false;
        			TSDdB_horizontalLineToolStripMenuItem.Checked = false;
        			TSDdB_crossToolStripMenuItem.Checked = false;
        			TSDdB_graticuleToolStripMenuItem.Checked = false;
        			TSDdB_squareToolStripMenuItem.Checked = false;
        			TSDdB_circleToolStripMenuItem.Checked = true;
        			
        			break;
        	}
        	
        	#endregion
        	
        	//Cursor step
        	#region Cursor step
        	
        	switch (CursorStepIndex)
        	{
        		case 0:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = true;
        			Cursor_Step_02_ToolStripMenuItem.Checked = false;
        			Cursor_Step_05_ToolStripMenuItem.Checked = false;
        			Cursor_Step_1_ToolStripMenuItem.Checked = false;
        			Cursor_Step_2_ToolStripMenuItem.Checked = false;
        			Cursor_Step_5_ToolStripMenuItem.Checked = false;
        			Cursor_Step_10_ToolStripMenuItem.Checked = false;
        			Cursor_Step_20_ToolStripMenuItem.Checked = false;
        			Cursor_Step_50_ToolStripMenuItem.Checked = false;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = true;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case 1:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = false;
        			Cursor_Step_02_ToolStripMenuItem.Checked = true;
        			Cursor_Step_05_ToolStripMenuItem.Checked = false;
        			Cursor_Step_1_ToolStripMenuItem.Checked = false;
        			Cursor_Step_2_ToolStripMenuItem.Checked = false;
        			Cursor_Step_5_ToolStripMenuItem.Checked = false;
        			Cursor_Step_10_ToolStripMenuItem.Checked = false;
        			Cursor_Step_20_ToolStripMenuItem.Checked = false;
        			Cursor_Step_50_ToolStripMenuItem.Checked = false;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = true;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case 2:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = false;
        			Cursor_Step_02_ToolStripMenuItem.Checked = false;
        			Cursor_Step_05_ToolStripMenuItem.Checked = true;
        			Cursor_Step_1_ToolStripMenuItem.Checked = false;
        			Cursor_Step_2_ToolStripMenuItem.Checked = false;
        			Cursor_Step_5_ToolStripMenuItem.Checked = false;
        			Cursor_Step_10_ToolStripMenuItem.Checked = false;
        			Cursor_Step_20_ToolStripMenuItem.Checked = false;
        			Cursor_Step_50_ToolStripMenuItem.Checked = false;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = true;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case 3:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = false;
        			Cursor_Step_02_ToolStripMenuItem.Checked = false;
        			Cursor_Step_05_ToolStripMenuItem.Checked = false;
        			Cursor_Step_1_ToolStripMenuItem.Checked = true;
        			Cursor_Step_2_ToolStripMenuItem.Checked = false;
        			Cursor_Step_5_ToolStripMenuItem.Checked = false;
        			Cursor_Step_10_ToolStripMenuItem.Checked = false;
        			Cursor_Step_20_ToolStripMenuItem.Checked = false;
        			Cursor_Step_50_ToolStripMenuItem.Checked = false;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = true;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case 4:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = false;
        			Cursor_Step_02_ToolStripMenuItem.Checked = false;
        			Cursor_Step_05_ToolStripMenuItem.Checked = false;
        			Cursor_Step_1_ToolStripMenuItem.Checked = false;
        			Cursor_Step_2_ToolStripMenuItem.Checked = true;
        			Cursor_Step_5_ToolStripMenuItem.Checked = false;
        			Cursor_Step_10_ToolStripMenuItem.Checked = false;
        			Cursor_Step_20_ToolStripMenuItem.Checked = false;
        			Cursor_Step_50_ToolStripMenuItem.Checked = false;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = true;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case 5:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = false;
        			Cursor_Step_02_ToolStripMenuItem.Checked = false;
        			Cursor_Step_05_ToolStripMenuItem.Checked = false;
        			Cursor_Step_1_ToolStripMenuItem.Checked = false;
        			Cursor_Step_2_ToolStripMenuItem.Checked = false;
        			Cursor_Step_5_ToolStripMenuItem.Checked = true;
        			Cursor_Step_10_ToolStripMenuItem.Checked = false;
        			Cursor_Step_20_ToolStripMenuItem.Checked = false;
        			Cursor_Step_50_ToolStripMenuItem.Checked = false;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = true;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case 6:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = false;
        			Cursor_Step_02_ToolStripMenuItem.Checked = false;
        			Cursor_Step_05_ToolStripMenuItem.Checked = false;
        			Cursor_Step_1_ToolStripMenuItem.Checked = false;
        			Cursor_Step_2_ToolStripMenuItem.Checked = false;
        			Cursor_Step_5_ToolStripMenuItem.Checked = false;
        			Cursor_Step_10_ToolStripMenuItem.Checked = true;
        			Cursor_Step_20_ToolStripMenuItem.Checked = false;
        			Cursor_Step_50_ToolStripMenuItem.Checked = false;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = true;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case 7:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = false;
        			Cursor_Step_02_ToolStripMenuItem.Checked = false;
        			Cursor_Step_05_ToolStripMenuItem.Checked = false;
        			Cursor_Step_1_ToolStripMenuItem.Checked = false;
        			Cursor_Step_2_ToolStripMenuItem.Checked = false;
        			Cursor_Step_5_ToolStripMenuItem.Checked = false;
        			Cursor_Step_10_ToolStripMenuItem.Checked = false;
        			Cursor_Step_20_ToolStripMenuItem.Checked = true;
        			Cursor_Step_50_ToolStripMenuItem.Checked = false;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = true;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = false;
        			
        			break;
        			
        		case 8:
        			
        			//Context_PicGraph_Options items update
        			Cursor_Step_01_ToolStripMenuItem.Checked = false;
        			Cursor_Step_02_ToolStripMenuItem.Checked = false;
        			Cursor_Step_05_ToolStripMenuItem.Checked = false;
        			Cursor_Step_1_ToolStripMenuItem.Checked = false;
        			Cursor_Step_2_ToolStripMenuItem.Checked = false;
        			Cursor_Step_5_ToolStripMenuItem.Checked = false;
        			Cursor_Step_10_ToolStripMenuItem.Checked = false;
        			Cursor_Step_20_ToolStripMenuItem.Checked = false;
        			Cursor_Step_50_ToolStripMenuItem.Checked = true;
        				
        			//ToolBar items update
        			TSDdB_CurStep_01_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_02_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_05_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_1_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_2_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_5_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_10_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_20_ToolStripMenuItem.Checked = false;
        			TSDdB_CurStep_50_ToolStripMenuItem.Checked = true;
        			
        			break;
        	}
        	
        	#endregion
        	
        	//Reference cursor
        	#region Reference cursor
        	
        	switch (Properties.ReferenceCursor.Mode)
        	{
        		case GraphicCursorMode.VerticalLine:
        			
        			//Context_PicGraph_Options items update
        			RefCursor_Mode_None_TSMI.Checked = false;
        			RefCursor_Mode_Vertical_TSMI.Checked = true;
        			RefCursor_Mode_Horizontal_TSMI.Checked = false;
        			
        			//ToolBar items update
        			TSDB_RefCursor_Mode_None.Checked = false;
        			TSDB_RefCursor_Mode_Vertical.Checked = true;
        			TSDB_RefCursor_Mode_Horizontal.Checked = false;
        			
        			break;
        			
        		case GraphicCursorMode.HorizontalLine:
        			
        			//Context_PicGraph_Options items update
        			RefCursor_Mode_None_TSMI.Checked = false;
        			RefCursor_Mode_Vertical_TSMI.Checked = false;
        			RefCursor_Mode_Horizontal_TSMI.Checked = true;
        			
        			//ToolBar items update
        			TSDB_RefCursor_Mode_None.Checked = false;
        			TSDB_RefCursor_Mode_Vertical.Checked = false;
        			TSDB_RefCursor_Mode_Horizontal.Checked = true;
        			
        			break;
        			
        		default:
        			
        			//Context_PicGraph_Options items update
        			RefCursor_Mode_None_TSMI.Checked = true;
        			RefCursor_Mode_Vertical_TSMI.Checked = false;
        			RefCursor_Mode_Horizontal_TSMI.Checked = false;
        			
        			//ToolBar items update
        			TSDB_RefCursor_Mode_None.Checked = true;
        			TSDB_RefCursor_Mode_Vertical.Checked = false;
        			TSDB_RefCursor_Mode_Horizontal.Checked = false;
        			
        			break;
        	}
        	
        	#endregion
        	
        	//Zoom mode
        	#region Zoom mode
        	
        	if (!(Properties.ZoomMode.Equals(GraphicZoomMode.Disabled)))
        	{
	        	
        		//Context_PicGraph_Options items update
	        	ZoomPlustoolStripMenuItem.Enabled = true;
	        	ZoomMinustoolStripMenuItem.Enabled = true;
	        	ZoomMintoolStripMenuItem.Enabled = true;
	        	ZoomMaxtoolStripMenuItem.Enabled = true;
	        	ZoomFactortoolStripMenuItem.Enabled = true;
	        	ZoomMode_X_ToolStripMenuItem.Enabled = true;
	        	ZoomMode_Y_ToolStripMenuItem.Enabled = true;
	        	ZoomMode_XY_ToolStripMenuItem.Enabled = true;
	        	ZoomMode_Disabled_ToolStripMenuItem.Checked=false;
	        	
	        	//ToolBar items update
	        	TSDdB_ZoomFactor.Enabled = true;
	        	TSDdB_zoomXToolStripMenuItem.Enabled = true;
	        	TSDdB_zoomYToolStripMenuItem.Enabled = true;
        		TSDdB_zoomXYToolStripMenuItem.Enabled = true;
        		TSDdB_zoomDisabledToolStripMenuItem.Checked = false;
        		TSB_ZoomPlus.Enabled = true;
        		TSB_ZoomMinus.Enabled = true;
        		
        		switch (Properties.ZoomMode)
	        	{
	        		case GraphicZoomMode.ZoomX:
	        			
	        			//Context_PicGraph_Options items update
	        			ZoomMode_X_ToolStripMenuItem.Checked = true;
	        			ZoomMode_Y_ToolStripMenuItem.Checked = false;
	        			ZoomMode_XY_ToolStripMenuItem.Checked = false;
	        			
	        			//ToolBar items update
	        			TSDdB_zoomXToolStripMenuItem.Checked = true;
	        			TSDdB_zoomYToolStripMenuItem.Checked = false;
	        			TSDdB_zoomXYToolStripMenuItem.Checked = false;
	        			
	        			break;
	        			
	        		case GraphicZoomMode.ZoomY:
	        			
	        			//Context_PicGraph_Options items update
	        			ZoomMode_X_ToolStripMenuItem.Checked = false;
	        			ZoomMode_Y_ToolStripMenuItem.Checked = true;
	        			ZoomMode_XY_ToolStripMenuItem.Checked = false;
	        			
	        			//ToolBar items update
	        			TSDdB_zoomXToolStripMenuItem.Checked = false;
	        			TSDdB_zoomYToolStripMenuItem.Checked = true;
	        			TSDdB_zoomXYToolStripMenuItem.Checked = false;
	        			
	        			break;
	        			
	        		case GraphicZoomMode.ZoomXY:
	        			
	        			//Context_PicGraph_Options items update
	        			ZoomMode_X_ToolStripMenuItem.Checked = false;
	        			ZoomMode_Y_ToolStripMenuItem.Checked = false;
	        			ZoomMode_XY_ToolStripMenuItem.Checked = true;
	        			
	        			//ToolBar items update
	        			TSDdB_zoomXToolStripMenuItem.Checked = false;
	        			TSDdB_zoomYToolStripMenuItem.Checked = false;
	        			TSDdB_zoomXYToolStripMenuItem.Checked = true;
	        			
	        			break;
	        	}
        	}
        	else
        	{
        		//Context_PicGraph_Options items update
	        	ZoomPlustoolStripMenuItem.Enabled = false;
	        	ZoomMinustoolStripMenuItem.Enabled = false;
	        	ZoomMintoolStripMenuItem.Enabled = false;
	        	ZoomMaxtoolStripMenuItem.Enabled = false;
	        	ZoomFactortoolStripMenuItem.Enabled = false;
	        	ZoomMode_Disabled_ToolStripMenuItem.Checked=true;
	        	
	        	ZoomMode_X_ToolStripMenuItem.Enabled = false;
	        	ZoomMode_X_ToolStripMenuItem.Checked = false;
	        	
	        	ZoomMode_Y_ToolStripMenuItem.Enabled = false;
	        	ZoomMode_Y_ToolStripMenuItem.Checked = false;
	        	
	        	ZoomMode_XY_ToolStripMenuItem.Enabled = false;
	        	ZoomMode_XY_ToolStripMenuItem.Checked =false;
	        	
	        	//ToolBar items update
	        	TSDdB_zoomDisabledToolStripMenuItem.Checked = true;
	        	
	        	TSDdB_ZoomFactor.Enabled = false;
	        	
	        	TSDdB_zoomXToolStripMenuItem.Enabled = false;
	        	TSDdB_zoomXToolStripMenuItem.Checked = false;
	        	
	        	TSDdB_zoomYToolStripMenuItem.Enabled = false;
	        	TSDdB_zoomYToolStripMenuItem.Checked = false;
	        	
        		TSDdB_zoomXYToolStripMenuItem.Enabled = false;
        		TSDdB_zoomXYToolStripMenuItem.Checked = false;
        		
        		TSB_ZoomPlus.Enabled = false;
        		TSB_ZoomMinus.Enabled = false;
        	}
        	
        	#endregion
        	
        	//Zoom factor
        	#region Zoom factor
        	
        	switch (ZoomFactorIndex)
        	{
        		case 0:
        			
        			//Context_PicGraph_Options items update
        			ZoomFactor_2_ToolStripMenuItem.Checked = true;
        			ZoomFactor_4_ToolStripMenuItem.Checked = false;
        			ZoomFactor_8_ToolStripMenuItem.Checked = false;
        			ZoomFactor_16_ToolStripMenuItem.Checked = false;
        			ZoomFactor_32_ToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_ZoomFactor_2.Checked = true;
        			TSDdB_ZoomFactor_4.Checked = false;
        			TSDdB_ZoomFactor_8.Checked = false;
        			TSDdB_ZoomFactor_16.Checked = false;
        			TSDdB_ZoomFactor_32.Checked = false;
        			
        			break;
        			
        		case 1:
        			
        			//Context_PicGraph_Options items update
        			ZoomFactor_2_ToolStripMenuItem.Checked = false;
        			ZoomFactor_4_ToolStripMenuItem.Checked = true;
        			ZoomFactor_8_ToolStripMenuItem.Checked = false;
        			ZoomFactor_16_ToolStripMenuItem.Checked = false;
        			ZoomFactor_32_ToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_ZoomFactor_2.Checked = false;
        			TSDdB_ZoomFactor_4.Checked = true;
        			TSDdB_ZoomFactor_8.Checked = false;
        			TSDdB_ZoomFactor_16.Checked = false;
        			TSDdB_ZoomFactor_32.Checked = false;
        			
        			break;
        			
        		case 2:
        			
        			//Context_PicGraph_Options items update
        			ZoomFactor_2_ToolStripMenuItem.Checked = false;
        			ZoomFactor_4_ToolStripMenuItem.Checked = false;
        			ZoomFactor_8_ToolStripMenuItem.Checked = true;
        			ZoomFactor_16_ToolStripMenuItem.Checked = false;
        			ZoomFactor_32_ToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_ZoomFactor_2.Checked = false;
        			TSDdB_ZoomFactor_4.Checked = false;
        			TSDdB_ZoomFactor_8.Checked = true;
        			TSDdB_ZoomFactor_16.Checked = false;
        			TSDdB_ZoomFactor_32.Checked = false;
        			
        			break;
        			
        		case 3:
        			
        			//Context_PicGraph_Options items update
        			ZoomFactor_2_ToolStripMenuItem.Checked = false;
        			ZoomFactor_4_ToolStripMenuItem.Checked = false;
        			ZoomFactor_8_ToolStripMenuItem.Checked = false;
        			ZoomFactor_16_ToolStripMenuItem.Checked = true;
        			ZoomFactor_32_ToolStripMenuItem.Checked = false;
        			
        			//ToolBar items update
        			TSDdB_ZoomFactor_2.Checked = false;
        			TSDdB_ZoomFactor_4.Checked = false;
        			TSDdB_ZoomFactor_8.Checked = false;
        			TSDdB_ZoomFactor_16.Checked = true;
        			TSDdB_ZoomFactor_32.Checked = false;
        			
        			break;
        			
        		case 4:
        			
        			//Context_PicGraph_Options items update
        			ZoomFactor_2_ToolStripMenuItem.Checked = false;
        			ZoomFactor_4_ToolStripMenuItem.Checked = false;
        			ZoomFactor_8_ToolStripMenuItem.Checked = false;
        			ZoomFactor_16_ToolStripMenuItem.Checked = false;
        			ZoomFactor_32_ToolStripMenuItem.Checked = true;
        			
        			//ToolBar items update
        			TSDdB_ZoomFactor_2.Checked = false;
        			TSDdB_ZoomFactor_4.Checked = false;
        			TSDdB_ZoomFactor_8.Checked = false;
        			TSDdB_ZoomFactor_16.Checked = false;
        			TSDdB_ZoomFactor_32.Checked = true;
        			
        			break;
        	}
        	
        	#endregion
        	
        	//Legend informations
        	#region Legend informations
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.Label))
        	{
        		TSMI_Ctxt_Legend_Infos_Label.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_Label.Checked = false;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.CurrentValue))
        	{
        		TSMI_Ctxt_Legend_Infos_Value.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_Value.Checked = false;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.Unit))
        	{
        		TSMI_Ctxt_Legend_Infos_Unit.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_Unit.Checked = false;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.GraphMin))
        	{
        		TSMI_Ctxt_Legend_Infos_Min.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_Min.Checked = false;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.GraphMax))
        	{
        		TSMI_Ctxt_Legend_Infos_Max.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_Max.Checked = false;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.GraphAvg))
        	{
        		TSMI_Ctxt_Legend_Infos_Avg.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_Avg.Checked = false;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.RefCursorValue))
        	{
        		TSMI_Ctxt_Legend_Infos_RefCursor_Value.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_RefCursor_Value.Checked = true;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.RefCursorDiffValue))
        	{
        		TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_RefCursor_Diff.Checked = true;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.RefCursorDiffPerc))
        	{
        		TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_RefCursor_DiffPerc.Checked = true;
        	}
        	
        	if (Properties.LegendProperties.Informations.HasFlag(GraphicLegendInformations.RefCursorGradient))
        	{
        		TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Checked = true;
        	}
        	else
        	{
        		TSMI_Ctxt_Legend_Infos_RefCursor_Gradient.Checked = true;
        	}
        	
        	#endregion
        }
        
        private void Change_GraphLayout(GraphicWindowLayoutModes eNewLayoutMode)
        {
        	Properties.GraphLayoutMode = eNewLayoutMode;
            eCurrentStage = GraphDrawingStages.Scratch;
            oGraphicUpdateRequest.UpdateRequested = true;
        }
        
        private void Change_MainCursorMode(GraphicCursorMode eNewCursorMode)
        {
        	Pic_Graphic.Refresh();
        	Properties.Cursor.Mode = eNewCursorMode;
        	Set_Options_Controls();
        }
        
        private void Change_ZoomMode(GraphicZoomMode eNewZoomMode)
        {
        	Pic_Graphic.Refresh();
        	Properties.ZoomMode = eNewZoomMode;
        	Set_Options_Controls();
        }
        
        private void Change_SerieVisibility(int SerieKey)
        {
        	GraphSerieProperties oSerieProp = Properties.Get_SerieAtKey(SerieKey);
        	
        	if (!(oSerieProp == null))
        	{
        		oSerieProp.Visible = !oSerieProp.Visible;
        		Refresh_Graphic(GraphDrawingStages.YAxis_Lines);
        	}
        }
        
        private void Remove_Serie(int SerieKey)
        {
        	GraphSerieProperties oSerieProp = Properties.Get_SerieAtKey(SerieKey);
        	
        	if (!(oSerieProp == null))
        	{
        		Properties.SeriesProperties.Remove(oSerieProp);
        		Refresh_Graphic();
        	}
        }
        
        private void Drop_Series(DragEventArgs DropItems)
        {
        	ListView.SelectedListViewItemCollection Items = (ListView.SelectedListViewItemCollection)DropItems.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

            if(!(Items==null))
            {
                foreach(ListViewItem ItChannel in Items)
                {
                    Properties.Create_Serie(ItChannel.Text);
                }

                eCurrentStage = GraphDrawingStages.Scratch;
                oGraphicUpdateRequest.UpdateRequested = true;
            }
        }
        
        #endregion

        #region Channel list

        private void Fill_ChannelList()
        {
            if (!(WholeDataFile == null))
            {
                string[] ChanList = new string[WholeDataFile.Channels.Count];

                for (int i = 0; i < WholeDataFile.Channels.Count; i++)
                {
                    ChanList[i] = WholeDataFile.Channels[i].Name;
                }

                Ctrl_ChannelList.ChannelList = ChanList;
                Ctrl_ChannelList.Show_ChannelList();
            }
        }

        private void ShowHide_ChannelList()
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        #endregion
		
        #region Snapshot and print
        
        private void Make_GraphicSnapshot()
        {
        	if (Dlg_Save_Snapshot.ShowDialog().Equals(DialogResult.OK))
        	{        		
        		Image SnapShot = Get_SnapshotImage();
        		SnapShot.Save(Dlg_Save_Snapshot.FileName);
        		SnapShot.Dispose();
        	}
        }
        
        private void Print_Graphic()
        {
        	Image GraphImage = Get_SnapshotImage();
        	
        	if (!(GraphImage == null))
        	{
        		Frm_GraphPrinting Frm = new Frm_GraphPrinting(GraphImage);
        		Frm.Show();
        	}
        }
        
        private Image Get_SnapshotImage()
        {
        	System.Threading.Thread.Sleep(50); //To not catch the save as window...
        	
        	Image SnapShot = null;
        	Graphics SnapGraphics = null;
        	
        	if (!(splitContainer2.Panel2Collapsed)) //Legend visible
        	{
        		SnapShot = new Bitmap(splitContainer2.Width, splitContainer2.Height);
        		SnapGraphics = Graphics.FromImage(SnapShot);
        		
        		SnapGraphics.Clear(Properties.WindowBackColor);
        		
        		Point PtSrc = Grid_Legend.PointToScreen(Grid_Legend.Location);        		
        		Point PtDest = new Point (FrameRightPoint + GRAPH_FRAME_WIDTH_OFFSET, FrameTopPoint);
        		
        		SnapGraphics.CopyFromScreen(PtSrc, PtDest, Grid_Legend.Size);
        	}
        	else //Legend hidden
        	{
        		SnapShot = new Bitmap(Pic_GraphFrame.Width, Pic_GraphFrame.Height);
        		SnapGraphics = Graphics.FromImage(SnapShot);
        	}
        	
        	PointF PtImage = new PointF(0, 0);
        	SnapGraphics.DrawImage(Pic_GraphFrame.Image, PtImage);
        	
        	Image GraphImage = (Image)Pic_Graphic.Image.Clone();
        	Graphics GraphImgGraphics = Graphics.FromImage(GraphImage);
        	
        	//Cursor drawing
        	if (!(PtCursorPos.IsEmpty))
        	{
        		Draw_Cursor(PtCursorPos, Properties.Cursor, GraphImgGraphics);
        	}
        	
        	if (!(PtRefCursorPos.IsEmpty))
        	{
        		Draw_Cursor(PtRefCursorPos, Properties.ReferenceCursor, GraphImgGraphics);
        	}
        	
        	PtImage = new PointF(FrameLeftPoint, FrameTopPoint);
        	SnapGraphics.DrawImage(GraphImage, PtImage);
        	
        	GraphImgGraphics.Dispose();
        	SnapGraphics.Dispose();
        	
        	return(SnapShot);
        	
        	//SnapShot.Save(Dlg_Save_Snapshot.FileName);
        	//SnapShot.Dispose();
        }

        #endregion

        #region Real time graphic control
        
        private void Start_RealTimeTrace()
        {
            if(RTStatus== GraphicRealTimeStatus.Stopped)
            {
                Properties = new GraphWindowProperties();

                eCurrentStage = GraphDrawingStages.Scratch;
                oGraphicUpdateRequest.UpdateRequested = true;
            }

            RTStatus = GraphicRealTimeStatus.Running;
        }

        private void Break_RealTimeTrace()
        {
            RTStatus = GraphicRealTimeStatus.Broken;
        }

        private void Stop_RealTimeTrace()
        {
            RTStatus = GraphicRealTimeStatus.Stopped;
        }

        #endregion

        #region Tools

        private int RoundClosest(int Value, int Divider)
        {
            //Return argument 'Value' rounded to the closest value dividable by 'Divider'
        	
        	int Rem = 1;
            Value++;

            while (Rem != 0)
            {
                Value--;
                long Div = Math.DivRem(Value, Divider, out Rem);
            }

            return (Value);
        }
        
        private double SATURA(double Value, double Min, double Max)
        {
        	if (Value > Max)
        	{
        		return(Max);
        	}
        	else if (Value < Min)
        	{
        		return(Min);
        	}
        	
        	return(Value);
        }
		
        private double Get_AbscisseValueAtPostion(int Position)
        {
            double a = (Properties.AbscisseAxis.CoordConversion.Max - Properties.AbscisseAxis.CoordConversion.Min) / (FrameWidth);
    		double b = Properties.AbscisseAxis.CoordConversion.Max - a * FrameWidth;
    		
    		return((double)Position * a + b);
        }
        
        private SerieValueAtPoint[] Get_OrdinateValuesAtPosition(int Position)
        {
        	List<SerieValueAtPoint> CursorValues = new List<Ctrl_WaveForm.SerieValueAtPoint>();
        	
        	foreach (GraphSerieProperties oProp in Properties.SeriesProperties)
            {
                if((oProp.Visible && (oProp.Trace.Visible || oProp.Markers.Visible)) && DataFile.DataChannelExists(oProp.Name))
                {
                	GW_DataChannel oChanData = DataFile.Get_DataChannel(oProp.Name);
                	
                	if (!(oChanData == null))
                	{
                		if (Position >= oProp.CoordConversion.Top && Position <= oProp.CoordConversion.Bottom)
                		{
	                		SerieValueAtPoint sCursorVal = new Ctrl_WaveForm.SerieValueAtPoint();
	                		
	                		double a = (oProp.CoordConversion.Max - oProp.CoordConversion.Min) / (oProp.CoordConversion.Top - oProp.CoordConversion.Bottom);
	                		double b = oProp.CoordConversion.Max - a * oProp.CoordConversion.Top;
	                		
	                		sCursorVal.SerieColor = oProp.Trace.LineColor;
	                		sCursorVal.SerieName = oProp.Label;
	                		sCursorVal.SerieValue = oProp.ValueFormat.Get_ValueFormatted((double)Position * a + b);
	                		sCursorVal.SerieKeyId = oProp.KeyId;
	                		
	                		CursorValues.Add(sCursorVal);
                		}
                	}
                }
            }
        	
        	if (CursorValues.Count > 0)
        	{
        		return(CursorValues.ToArray());
        	}
        	else
        	{
        		return(null);
        	}
        }

        #endregion

        #endregion

        #region Events handling methods

        /// <summary>
        /// UserControlKey down event firing method
        /// </summary>
        /// <param name="e">Key data</param>
        protected virtual void OnControlPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            EventHandler<PreviewKeyDownEventArgs> Handler = ControlPreviewKeyDown;

            if(Handler != null)
            {
                Handler(this, e);
            }

        }

        #endregion

        #region Public methodes

        #region Graphic methodes

        /// <summary>
        /// Redraw the graphic window from scratch
        /// </summary>
        public void Refresh_Graphic()
        {
            if (!bRealTimeGraphic || mRTStatus == GraphicRealTimeStatus.Running)
            {
                eCurrentStage = GraphDrawingStages.Scratch;
                oGraphicUpdateRequest.UpdateRequested = true;
            }
        }

        /// <summary>
        /// Redraw the graphic window from the stage given as argument
        /// </summary>
        /// <param name="eInitialStage">Drawing stage to start from</param>
        public void Refresh_Graphic(GraphDrawingStages eInitialStage)
        {
            if (!bRealTimeGraphic || mRTStatus == GraphicRealTimeStatus.Running)
            {
                eCurrentStage = eInitialStage; 

                if (bDataPlotted)
                {
                    if (bRealTimeGraphic)
                    {
                        Update_AbscisseCoordsConversion();

                        if (DataFile != null)
                        {
                            if (DataFile.CoordConversionUpdateRequested)
                            {
                                eCurrentStage = GraphDrawingStages.Scratch;
                                DataFile.CoordConversionUpdateRequested = false;
                            }
                        }
                    }
                }
                else
                {
                    eCurrentStage = GraphDrawingStages.Scratch;
                }

                oGraphicUpdateRequest.UpdateRequested = true;
            }
        }

        /// <summary>
        /// Reset GraphWindowProperties of the current object
        /// </summary>
        /// <param name="Caller">Frm_GraphPropertiesEdtion having requested the reset</param>
        /// <remarks>Function 'New' of a Frm_GraphPropertiesEdtion</remarks>
        public void Reset_Properties(Frm_GraphPropertiesEdtion Caller)
        {
            Properties = new GraphWindowProperties();
            Caller.UpDate_Properties(Properties);
        }
		
        /// <summary>
        /// Set the GW_DataFile object containing the data to plot
        /// </summary>
        /// <param name="oNewDataFile">GW_DataFile object containing the data to plot</param>
        public void Set_DataFile(GW_DataFile oNewDataFile)
        {
        	WholeDataFile = oNewDataFile;
        	DataFile = WholeDataFile;
            eCurrentStage = GraphDrawingStages.Scratch;
            SeriesReferenceCoordConversion = null;
        	Fill_ChannelList();
        }
        
        /// <summary>
        /// Add one or more series into the graphic window
        /// </summary>
        /// <param name="SerieNames">Names of series to add</param>
        public void Add_Series(string[] SerieNames)
        {
        	if (!(SerieNames == null))
        	{
        		foreach (string Name in SerieNames)
        		{
        			Properties.Create_Serie(Name);
        		}

                eCurrentStage = GraphDrawingStages.Scratch;
                oGraphicUpdateRequest.UpdateRequested = true;
            }
        }
        
        /// <summary>
        /// Draw the main cursor at abscisse value given as argument
        /// </summary>
        /// <param name="AbscisseValue">Abscisse value to draw the cursor at</param>
        public void Set_MainCursorAtAbscisse(double AbscisseValue)
        {
            if(bDataPlotted)
            {
                int PtX = (int)(AbscisseValue * Properties.AbscisseAxis.CoordConversion.Gain + Properties.AbscisseAxis.CoordConversion.Zero);
                Draw_Cursor(new Point(PtX, 0));
            }
        }

        #endregion

        #region Channel list

        /// <summary>
        /// Clear the channel list of the current Ctrl_WaveForm
        /// </summary>
        public void Clear_ChannelList()
        {
            Ctrl_ChannelList.Clear_ChannelList();
        }

        /// <summary>
        /// Add a channel item to the channel list of the current Ctrl_WaveForm object
        /// </summary>
        /// <param name="ChannelName">Name of the channel to be added</param>
        public void Add_ChannelToChannelList(string ChannelName)
        {
            Ctrl_ChannelList.Add_ChannelName(ChannelName);
        }

        #endregion

        #endregion
    }
}
