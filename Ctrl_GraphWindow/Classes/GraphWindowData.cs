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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ctrl_GraphWindow
{
    #region Structures
    
    /// <summary>
    /// Serie statistics structure
    /// </summary>
    public struct SerieStatistics
	    {
	    	/// <summary>Serie label</summary>
    		public string Title;
    		
    		/// <summary>Serie trace color</summary>
	    	public Color SerieColor;
	    	
	    	/// <summary>Abscisse value at the minimum serie value</summary>
	    	public double MinX;
	    	
	    	/// <summary>Abscisse value at the maximum serie value</summary>
	    	public double MaxX;
	    	
	    	/// <summary>Serie min value between starting and ending points</summary>
	    	public double Min;
	    	
	    	/// <summary>Serie max value between starting and ending points</summary>
	    	public double Max;
	    	
	    	/// <summary>Serie average of serie values between starting and ending points</summary>
	    	public double Avg;
	    	
	    	/// <summary>Serie average of absolute serie values between starting and ending points</summary>
	    	public double AvgAbs;
	    	
	    	/// <summary>Serie standard deviation value between starting and ending points</summary>
	    	public double StdDev;
	    	
	    	/// <summary>Number of serie sample values between starting and ending points</summary>
	    	public int SampleCount;
	    }

    /// <summary>
    /// Graphic channel data sample structure
    /// </summary>
    public struct SerieSample
    {
        /// <summary> Time value of the sample </summary>
        public double SampleTime;

        /// <summary> Data value of the sample </summary>
        public double SampleValue;
    }

    #endregion

    #region Enums

    /// <summary>
    /// Graph window data sampling mode
    /// </summary>
    public enum SamplingMode
    {
        /// <summary> Single sampling rate for all data channels </summary>
        SingleRate = 0,

        /// <summary> Each data channel has its own sampling rate </summary>
        MultipleRates = 1,
    }

    #endregion

    #region Sub classes

    /// <summary>
    /// Graph window data channel class
    /// </summary>
    public class GW_DataChannel
    {
        #region Public properties

        /// <summary>
        /// Number of data item contained within the current GW_DataChannel object whether actual sampling mode is a SingleRate or MultipleRates 
        /// </summary>
        public int DataItemsCount
        {
            get
            {
                if (!(Values == null))
                {
                    return (Values.Count);
                }
                else if (!(Samples == null))
                {
                    return (Samples.Count);
                }

                return (0);
            }

            private set
            {

            }
        }

        #region XML Data file GW_DataChannel properties

        /// <summary>Description of the data channel</summary>
        public string Description { get; set; }

        /// <summary>Unit of data channel values</summary>
        public string Unit { get; set; }

        /// <summary>Display format of data channel values</summary>
        public GraphSerieValueFormat GraphicFormat { get; set; }

        /// <summary>Reference lines of data channel</summary>
        public List<GraphReferenceLine> ChannelReferenceLines { get; set; }

        #endregion

        #endregion

        #region Public members

        /// <summary>
        /// Data channel name
        /// </summary>
        public string Name;

        /// <summary>
        /// Data channel values for SingleRate sampling mode
        /// </summary>
        public List<double> Values;

        /// <summary>
        /// Data channel samples for MultipleRates sampling mode
        /// </summary>
        public List<SerieSample> Samples;

        /// <summary>
        /// Minimum value of the channel
        /// </summary>
        public double Min;

        /// <summary>
        /// Maximum value of the channel
        /// </summary>
        public double Max;

        /// <summary>
        /// Average value of the channel
        /// </summary>
        public double Avg;

        #endregion

        #region Internal members

        /// <summary>
        /// Data channel sample time min
        /// </summary>
        /// <remarks>Applicable only for multiple sampling rate data file</remarks>
        internal double ChannelStepTimeMin;

        /// <summary>
        /// Data channel sample time max
        /// </summary>
        /// <remarks>Applicable only for multiple sampling rate data file</remarks>
        internal double ChannelStepTimeMax;

        /// <summary>
        /// Data channel key identifier in the GW_DataFile collection of GW_DataChannel
        /// </summary>
        internal int KeyId;

        /// <summary>
        /// GW_DataFile instance owning the current GW_DataChannel object
        /// </summary>
        internal GW_DataFile ParentDataFile;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GW_DataChannel()
        {
            Name = "";
            Values = new List<double>();
            Samples = null;
            Min = 0;
            Max = 0;
            Avg = 0;
            ChannelStepTimeMin = 0;
            ChannelStepTimeMax = 0;
            KeyId = -1;

            //XML Data file channel properties default values
            Description = "";
            Unit = "";
            GraphicFormat = new GraphSerieValueFormat();
            ChannelReferenceLines = new List<GraphReferenceLine>();
        }

        /// <summary>
        /// Constructor including the name of the data channel to create
        /// </summary>
        /// <param name="ChannelName">Channel name</param>
        public GW_DataChannel(string ChannelName)
        {
            Name = ChannelName;
            Values = new List<double>();
            Samples = null;
            Min = 0;
            Max = 0;
            Avg = 0;
            ChannelStepTimeMin = 0;
            ChannelStepTimeMax = 0;
            KeyId = -1;

            //XML Data file channel properties default values
            Description = "";
            Unit = "";
            GraphicFormat = new GraphSerieValueFormat();
            ChannelReferenceLines = new List<GraphReferenceLine>();
        }

        /// <summary>
        /// Constructor including the sampling mode of the data channel to create
        /// </summary>
        /// <param name="SampleMode">Sampling mode of the data channel</param>
        public GW_DataChannel(SamplingMode SampleMode)
        {
            Name = "";
            Min = 0;
            Max = 0;
            Avg = 0;
            ChannelStepTimeMin = 0;
            ChannelStepTimeMax = 0;
            KeyId = -1;

            InitChannelValues(SampleMode);

            //XML Data file channel properties default values
            Description = "";
            Unit = "";
            GraphicFormat = new GraphSerieValueFormat();
            ChannelReferenceLines = new List<GraphReferenceLine>();
        }

        /// <summary>
        /// Constructor including name and  sampling mode of the data channel to create
        /// </summary>
        /// <param name="ChannelName">Channel name</param>
        /// <param name="SampleMode">Sampling mode of the data channel</param>
        public GW_DataChannel(string ChannelName, SamplingMode SampleMode)
        {
            Name = ChannelName;
            Min = 0;
            Max = 0;
            Avg = 0;
            ChannelStepTimeMin = 0;
            ChannelStepTimeMax = 0;
            KeyId = -1;

            InitChannelValues(SampleMode);

            //XML Data file channel properties default values
            Description = "";
            Unit = "";
            GraphicFormat = new GraphSerieValueFormat();
            ChannelReferenceLines = new List<GraphReferenceLine>();
        }

        #endregion

        #region Private methodes
        
        private void InitChannelValues(SamplingMode eSampleMode)
        {
            switch (eSampleMode)
            {
                case SamplingMode.SingleRate:

                    Values = new List<double>();
                    Samples = null;
                    break;

                case SamplingMode.MultipleRates:

                    Values = null;
                    Samples = new List<SerieSample>();
                    break;
            }
        }
        
        private void ProcessValuesStatistics()
        {
            Min = Values[0];
            Max = Values[0];
            Avg = Values[0];

            for (int iValue=1; iValue<Values.Count; iValue++)
            {
                if (Values[iValue] < Min) Min = Values[iValue];
                if (Values[iValue] > Max) Max = Values[iValue];
                Avg = ((Avg * iValue) + Values[iValue]) / (iValue + 1);
            }
        }

        private void ProcessSamplesStatistics()
        {
            Min = Samples[0].SampleValue;
            Max = Samples[0].SampleValue;
            Avg = Samples[0].SampleValue;

            for (int iSample = 1; iSample < Samples.Count; iSample++)
            {
                if (Samples[iSample].SampleValue < Min) Min = Samples[iSample].SampleValue;
                if (Samples[iSample].SampleValue > Max) Max = Samples[iSample].SampleValue;
                Avg = ((Avg * iSample) + Samples[iSample].SampleValue) / (iSample + 1);
            }
        }

        #endregion

        #region Public methodes

        /// <summary>
        /// Add a value into the channel values collection and update min, max and average values
        /// </summary>
        /// <param name="Value">Value to add into the values collection</param>
        public void Add_ChannelValue(object Value)
        {
            double DataValue = 0; ;
            int ValCnt = 0;

            if (Value.GetType().Equals(typeof(double))) //Single sampling rate data file
            {
                DataValue = (double)Value;
                Values.Add(DataValue);

                ValCnt = Values.Count;
            }
            else if (Value.GetType().Equals(typeof(SerieSample))) //Multiple sampling rate data file
            {
                SerieSample sSample = (SerieSample)Value;

                if (Samples.Count == 0) //Data channel values list is empty yet
                {
                    Samples.Add(sSample);
                }
                else //Data channel values list contains some samples already
                {
                    if (Samples[Samples.Count - 1].SampleTime < sSample.SampleTime) //Is new sample time posterior to previous sample ?
                    {
                        Samples.Add(sSample);

                        double SampleTime = sSample.SampleTime - Samples[Samples.Count - 2].SampleTime;

                        if (Samples.Count == 2)
                        {
                            ChannelStepTimeMin = SampleTime;
                            ChannelStepTimeMax = SampleTime;
                        }
                        else
                        {
                            if (SampleTime < ChannelStepTimeMin) ChannelStepTimeMin = SampleTime;
                            if (SampleTime > ChannelStepTimeMax) ChannelStepTimeMax = SampleTime;
                        }
                    }
                    else //No sample adding abort
                    {
                        return;
                    }
                }

                DataValue = sSample.SampleValue;
                ValCnt = Samples.Count;
            }
            else
            {
                return;
            }

            //Serie statistics updating
            if (ValCnt > 1)
            {
                if (DataValue < Min)
                {
                    Min = DataValue;
                    ParentDataFile.CoordConversionUpdateRequested = true;
                }

                if (DataValue > Max)
                {
                    Max = DataValue;
                    ParentDataFile.CoordConversionUpdateRequested = true;
                }

                Avg = ((Avg * (ValCnt - 1)) + DataValue) / ValCnt;
            }
            else
            {
                Min = DataValue;
                Max = DataValue;
                Avg = DataValue;

                ParentDataFile.CoordConversionUpdateRequested = true;
            }
        }

        /// <summary>
        /// Return the sample index corresponding to the time value given as argument
        /// </summary>
        /// <param name="TimeValue">Sample time to search</param>
        /// <returns>Index of the sample time</returns>
        /// <remarks>Return -1 if the sample time is not found
        /// Works only for time sampled data channel (multiple sampling rates data file)</remarks>
        public int Get_SampleTimeIndex(double TimeValue)
        {
            if (Samples != null)
            {
                for (int iSample = 0; iSample < Samples.Count; iSample++)
                {
                    if (Samples[iSample].SampleTime >= TimeValue)
                    {
                        if (Samples[iSample].SampleTime == TimeValue)
                        {
                            return (iSample);
                        }
                        else
                        {
                            if (iSample != 0)
                            {
                                return (iSample - 1);
                            }
                        }
                    }
                }
            }

            return (-1);
        }

        /// <summary>
        /// Process statistics of the current data channel
        /// </summary>
        public void ProcessChannelStatistic()
        {
            if(Samples!=null)
            {
                ProcessSamplesStatistics();
            }
            else
            {
                ProcessValuesStatistics();
            }
        }

        #endregion
    }

    /// <summary>
    /// Graph window data channel list class
    /// </summary>
    public class GW_DataChannelList : List<GW_DataChannel>
    {
        #region Private members

        private GW_DataFile Owner;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GW_DataChannelList(GW_DataFile OwnerDataFile)
        {
            Owner = OwnerDataFile;
        }

        #region Public methods

        /// <summary>
        /// Adds a GW_DataChannel to the end of the GW_DataChannelList
        /// </summary>
        /// <param name="item">The GW_DataChannel to be added to the end of the GW_DataChannelList</param>
        public new void Add(GW_DataChannel item)
        {
            item.ParentDataFile = Owner;
            base.Add(item);
        }

        #endregion
    }

    /// <summary>
    /// Graph window XML data file custom property class
    /// </summary>
    public class GW_XmlDataFileCustomProperty
    {
        #region Public properties

        /// <summary>
        /// Name of the current custom property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the current custom property
        /// </summary>
        public object PropertyValue { get; set; }

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GW_XmlDataFileCustomProperty()
        {
            Name = "";
            PropertyValue = null;
        }

        #region Internal methods

        /// <summary>
        /// Returns the value of the current custom property into a string value
        /// </summary>
        /// <returns>Value of the current custom property into a string value</returns>
        internal string GetPropertyStringValue()
        {
            Type ValType = PropertyValue.GetType();

            if (ValType.Equals(typeof(DateTime)))
            {
                return (((DateTime)PropertyValue).ToBinary().ToString());
            }
            else
            {
                return (PropertyValue.ToString());
            }

        }

        /// <summary>
        /// Returns the type of the current custom property value
        /// </summary>
        /// <returns>Type of the current custom property value</returns>
        internal string GetPropertyType()
        {
            return (PropertyValue.GetType().ToString());
        }

        /// <summary>
        /// Parse the value of the custom property from a string value
        /// </summary>
        /// <param name="StringValue">String value to parse</param>
        /// <param name="StringType">Type of value to parse</param>
        internal void ParsePropertyStringValue(string StringValue,string StringType)
        {
            try
            {
                if (StringType.Equals("int32"))
                {
                    this.PropertyValue = int.Parse(StringValue);
                }
                else if (StringType.Equals("double"))
                {
                    this.PropertyValue = double.Parse(StringValue);
                }
                else if (StringType.Equals("DateTime"))
                {
                    this.PropertyValue = DateTime.FromBinary(long.Parse(StringValue));
                }
                else
                {
                    this.PropertyValue = StringValue;
                }
                
            }
            catch
            {
                throw new Exception("Custom property value parsing error");
            }

        }

        #endregion
    }

    #endregion

    /// <summary>
    /// Graph window data file class
    /// </summary>
    public class GW_DataFile
    {
        #region Properties

        /// <summary>
        /// Depth of the time buffer in second for real time graphic
        /// </summary>
        /// <remarks>Set -1 for infinite time buffer</remarks>
        public int TimeBufferSize { get; set; }

        /// <summary>
        /// Maximum number of samples contained in a data channel
        /// </summary>
        public int MaxSampleCount
        {
            get
            {
                if (DataSamplingMode == SamplingMode.SingleRate)
                {
                    return (Time.Values.Count);
                }
                else
                {
                    int Count = 0;

                    foreach (GW_DataChannel oChan in Channels)
                    {
                        if (oChan.Samples.Count > Count)
                        {
                            Count = oChan.Samples.Count;
                        }
                    }

                    return (Count);
                }
            }

            private set
            {

            }
        }
        
        /// <summary>
        /// Lowest sample time value of the data file
        /// </summary>
        public double SampleTimeMin
        {
            get
            {
                if(DataSamplingMode== SamplingMode.SingleRate)
                {
                    return (Time.Values[0]);
                }
                else
                {
                    if (Channels.Count > 0)
                    {
                        double TimeMin = Channels[0].Samples[0].SampleTime;

                        for (int iChan = 1; iChan < Channels.Count; iChan++)
                        {
                            if (Channels[iChan].Samples.Count > 1)
                            {
                                if (Channels[iChan].Samples[0].SampleTime < TimeMin)
                                {
                                    TimeMin = Channels[iChan].Samples[0].SampleTime;
                                }
                            }
                        }

                        return (TimeMin);
                    }
                    else
                    {
                        return (double.NaN);
                    }
                }
            }

            private set
            {

            }
        }

        /// <summary>
        /// Highest sample time value of the data file
        /// </summary>
        public double SampleTimeMax
        {
            get
            {
                if (DataSamplingMode == SamplingMode.SingleRate)
                {
                    return (Time.Values[Time.Values.Count - 1]);
                }
                else
                {
                    if (Channels.Count > 0)
                    {
                        double TimeMax = Channels[0].Samples[Channels[0].Samples.Count - 1].SampleTime;

                        for (int iChan = 1; iChan < Channels.Count; iChan++)
                        {
                            if (Channels[iChan].Samples.Count > 1)
                            {
                                if (Channels[iChan].Samples[Channels[iChan].Samples.Count - 1].SampleTime > TimeMax)
                                {
                                    TimeMax = Channels[iChan].Samples[Channels[iChan].Samples.Count - 1].SampleTime;
                                }
                            }
                        }

                        return (TimeMax);
                    }
                    else
                    {
                        return (double.NaN);
                    }
                }
            }

            private set
            {

            }
        }

        /// <summary>
        /// Mininimum step time of the file
        /// </summary>
        public double StepTimeMin
        {
            get
            {
                if (DataSamplingMode == SamplingMode.SingleRate)
                {
                    return (mStepTimeMin);
                }
                else
                {
                    if(Channels.Count>0)
                    {
                        double StepTime = Channels[0].ChannelStepTimeMin;
                        
                        for(int iChan=0; iChan<Channels.Count;iChan++)
                        {
                            if(Channels[iChan].ChannelStepTimeMin<StepTime)
                            {
                                StepTime = Channels[iChan].ChannelStepTimeMin;
                            }
                        }

                        return (StepTime);
                    }
                    else
                    {
                        return (0);
                    }
                }
            }

            set
            {
                if(DataSamplingMode == SamplingMode.SingleRate)
                {
                    mStepTimeMin = value;
                }
            }
        }

        /// <summary>
        /// Maximum step time of the file
        /// </summary>
        public double StepTimeMax
        {
            get
            {
                if (DataSamplingMode == SamplingMode.SingleRate)
                {
                    return (mStepTimeMax);
                }
                else
                {
                    if (Channels.Count > 0)
                    {
                        double StepTime = Channels[0].ChannelStepTimeMax;

                        for (int iChan = 0; iChan < Channels.Count; iChan++)
                        {
                            if (Channels[iChan].ChannelStepTimeMax > StepTime)
                            {
                                StepTime = Channels[iChan].ChannelStepTimeMax;
                            }
                        }

                        return (StepTime);
                    }
                    else
                    {
                        return (0);
                    }
                }
            }

            set
            {
                if (DataSamplingMode == SamplingMode.SingleRate)
                {
                    mStepTimeMax = value;
                }
            }
        }

        #region XML Data file properties

        /// <summary>Data file start timestamp</summary>
        public DateTime DataStartTime { get; set; }

        /// <summary>Data file user comments<summary>
        public string UserComment { get; set; }

        #endregion

        #endregion

        #region Public members

        /// <summary>
        /// Data file sampling mode
        /// </summary>
        public SamplingMode DataSamplingMode;

        /// <summary>
        /// Time vector of the data file
        /// </summary>
        public GW_DataChannel Time;

        /// <summary>
        /// Data channels collection of the data file
        /// </summary>
        public GW_DataChannelList Channels;

        #region XML Data file public members

        /// <summary>Custom properties of the current data file for XML data file format</summary>
        public List<GW_XmlDataFileCustomProperty> XmlDataFileCustomProperties;

        #endregion

        #endregion

        #region Internal members

        /// <summary>
        /// Data channels coordinates conversion factors updating requested flag
        /// </summary>
        internal bool CoordConversionUpdateRequested;

        #endregion

        #region Private members

        private double mStepTimeMin;

        private double mStepTimeMax;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GW_DataFile()
        {
            DataSamplingMode = SamplingMode.SingleRate;

            Time = new GW_DataChannel("Time");
            Time.ParentDataFile = this;

            Channels = new GW_DataChannelList(this);
            TimeBufferSize = -1;

            StepTimeMin = 0;
            StepTimeMax = 0;

            CoordConversionUpdateRequested = false;

            //XML Data file default properties
            DataStartTime = DateTime.Now;
            UserComment = "";
            XmlDataFileCustomProperties = new List<GW_XmlDataFileCustomProperty>();
        }

        #region Internal methodes

        /// <summary>
        /// Return the GW_DataChannel item corresponding to the key identifier given as argument
        /// </summary>
        /// <param name="KeyId">Key identifier of the channel to retrieve</param>
        /// <returns>GW_DataChannel item corresponding to the key identifier  given as argument</returns>
        /// <remarks>Return null if the GW_DataChannel item is not found</remarks>
        internal GW_DataChannel Get_DataChannelByKeyId(int KeyId)
        {
            if (KeyId >= 0 && KeyId < Channels.Count)
            {
                return (Channels[KeyId]);
            }

            return (null);
        }

        #endregion

        #region Public methodes

        /// <summary>
        /// Read a data file
        /// </summary>
        /// <param name="fPath">Path of the file to read</param>
        /// <returns>Reading error flag: True = No Error / False = Error</returns>
        /// <remarks>
        /// CSV file type: comma separtor ';'
        /// </remarks>
        public bool Load_DataFile(string fPath)
        {
        	if (fPath == null) return(false);
        	
        	bool bFirstLine = true;
            StreamReader SR = new StreamReader(fPath);

            while(!SR.EndOfStream)
            {
                string Line = SR.ReadLine();
                string[] Data = Line.Split(';');
                bool bFirstVal = true;

                if (bFirstLine)
                {
                    bFirstLine = false;

                    for (int i=0; i<Data.Length; i++)
                    {
                        if(!(Data[i].Equals("")))
                        {
                            if (!bFirstVal)
                            {
                                GW_DataChannel oChan = new GW_DataChannel(Data[i]);
                                Channels.Add(oChan);
                            }
                            else
                            {
                                bFirstVal = false; //First value is time
                            }
                        }
                    }
                }
                else
                {
                    int ValCnt = 0;

                    for (int i=0; i<Data.Length; i++)
                    {
                        if(!(Data[i].Equals("")))
                        {
                            double Val = 0;
                            if (double.TryParse(Data[i], out Val))
                            {
                                if (!bFirstVal) //Data value
                                {
                                    Channels[i-1].Add_ChannelValue(Val);
                                    ValCnt++;
                                }
                                else //Time value
                                {
                                    Time.Add_ChannelValue(Val);
                                    bFirstVal = false;
                                    
                                    if (Time.Values.Count > 1)
                                    {
                                    	double StepTime = Val - Time.Values[Time.Values.Count - 2];
                                    	
                                    	if (Time.Values.Count == 2)
                                    	{
                                    		StepTimeMin = StepTime;
                                    		StepTimeMax = StepTime;
                                    	}
                                    	else
                                    	{
                                    		if (StepTime < StepTimeMin) StepTimeMin = StepTime;
                                    		if (StepTime > StepTimeMax) StepTimeMax = StepTime;
                                    	}
                                    }
                                }
                            }
                            else 
                            {
                                return (false); //Not a number
                            }
                        }
                    }

                    //Missing data ?
                    if (!(ValCnt == Channels.Count))
                    {
                        return (false); //Missing value
                    }
                }
            }

            SR.Close();
            SR = null;
            return (true);
        }

        /// <summary>
        /// Read a XML data file
        /// </summary>
        /// <param name="fPath">Path of the XML file to read</param>
        /// <param name="HeaderOnly">Read only data file header flag</param>
        /// <returns>Reading error flag: True = No Error / False = Error</returns>
        public bool Load_XmlDataFile(string fPath, bool HeaderOnly)
        {
            XmlNode xDataFile, xHeader, xChannels, xSamples;
            XmlNode xElemParent, xElemChild;

            this.DataSamplingMode = SamplingMode.MultipleRates;

            try
            {
                XmlDocument oXDoc = new XmlDocument();
                oXDoc.Load(fPath);

                xDataFile = oXDoc.SelectSingleNode("XmlGraphDataFile");

                #region XML Data file header

                //Header reading
                xHeader = xDataFile.SelectSingleNode("DataFileHeader");

                //Data file start time
                xElemChild = xHeader.SelectSingleNode("DataStartTime");
                this.DataStartTime = DateTime.FromBinary(long.Parse(xElemChild.InnerText));

                //User comment
                xElemChild = xHeader.SelectSingleNode("DataUserComment");
                this.UserComment = xElemChild.InnerText;

                //Data file user properties
                xElemParent = xHeader.SelectSingleNode("DataCustomProperties");

                foreach(XmlNode xProp in xElemParent.ChildNodes)
                {
                    GW_XmlDataFileCustomProperty oProp = new GW_XmlDataFileCustomProperty();

                    oProp.Name = xProp.Attributes["CustomPropertyName"].Value;

                    string PropType= xProp.Attributes["CustomPropertyType"].Value;
                    oProp.ParsePropertyStringValue(xProp.InnerText, PropType);

                    this.XmlDataFileCustomProperties.Add(oProp);
                }

                #endregion

                #region XML Data files channels

                //Data reading
                if (!HeaderOnly)
                {
                    xChannels = xDataFile.SelectSingleNode("DataFileChannels");

                    foreach (XmlNode xChan in xChannels.ChildNodes)
                    {
                        GW_DataChannel oChan = new GW_DataChannel(SamplingMode.MultipleRates);

                        //Read channel properties
                        xElemChild = xChan.SelectSingleNode("ChannelName");
                        oChan.Name = xElemChild.InnerText;

                        xElemChild = xChan.SelectSingleNode("ChannelDescription");
                        oChan.Description = xElemChild.InnerText;

                        xElemChild = xChan.SelectSingleNode("ChannelUnit");
                        oChan.Unit = xElemChild.InnerText;

                        xElemChild = xChan.SelectSingleNode("ValueFormat");
                        oChan.GraphicFormat.SetSerieValueFormatFromXmlNode(xElemChild);

                        xElemParent = xChan.SelectSingleNode("ChannelReferenceLines");

                        if (!(xElemParent==null))
                        {
                            foreach (XmlNode xRefLine in xElemParent.ChildNodes)
                            {
                                GraphReferenceLine oLine = new GraphReferenceLine();

                                if (oLine.Read_GraphLineXmlNode(xRefLine))
                                {
                                    oChan.ChannelReferenceLines.Add(oLine);
                                }
                            }
                        }

                        //Read channel samples
                        xSamples = xChan.SelectSingleNode("ChannelSamples");
                        
                        foreach(XmlNode xSerieSample in xSamples.ChildNodes)
                        {
                            SerieSample sSample = new SerieSample();

                            xElemChild = xSerieSample.SelectSingleNode("SampleTime");
                            sSample.SampleTime = double.Parse(xElemChild.InnerText);

                            xElemChild = xSerieSample.SelectSingleNode("SampleValue");
                            sSample.SampleValue = double.Parse(xElemChild.InnerText);

                            oChan.Samples.Add(sSample);

                            if (oChan.Samples.Count==1)
                            {
                                oChan.Min = sSample.SampleValue;
                                oChan.Max = sSample.SampleValue;
                            }
                            else
                            {
                                if (sSample.SampleValue < oChan.Min) oChan.Min = sSample.SampleValue;
                                if (sSample.SampleValue > oChan.Max) oChan.Max = sSample.SampleValue;
                            }
                        }

                        this.Channels.Add(oChan);
                    }
                }

                #endregion
            }
            catch
            {
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// Write the current data file object in XML format
        /// </summary>
        /// <param name="fPath">Path of the XML file to write<</param>
        public void Write_XmlDataFile(string fPath)
        {
            XmlElement xDataFile, xHeader, xChannels, xChan, xSamples;
            XmlElement xElemParent, xElemChild;

            XmlAttribute xAtr;

            if (!(fPath.Equals("")))
            {
                XmlDocument oXDoc = new XmlDocument();

                xDataFile = oXDoc.CreateElement("XmlGraphDataFile");
                oXDoc.AppendChild(xDataFile);

                #region XML Data file header

                //Write XML Data file header
                xHeader = oXDoc.CreateElement("DataFileHeader");
                xDataFile.AppendChild(xHeader);

                //Data file start time
                xElemChild = oXDoc.CreateElement("DataStartTime");
                xElemChild.InnerText = DataStartTime.ToBinary().ToString();
                xHeader.AppendChild(xElemChild);

                //User comment
                xElemChild = oXDoc.CreateElement("DataUserComment");
                xElemChild.InnerText = UserComment;
                xHeader.AppendChild(xElemChild);

                //Data file user properties
                if (XmlDataFileCustomProperties.Count > 0)
                {
                    xElemParent = oXDoc.CreateElement("DataCustomProperties");
                    xHeader.AppendChild(xElemParent);

                    foreach (GW_XmlDataFileCustomProperty oProp in XmlDataFileCustomProperties)
                    {
                        xElemChild = oXDoc.CreateElement("CustomProperty");

                        xAtr = oXDoc.CreateAttribute("CustomPropertyName");
                        xAtr.Value = oProp.Name;
                        xElemChild.Attributes.Append(xAtr);

                        xAtr = oXDoc.CreateAttribute("CustomPropertyType");
                        xAtr.Value = oProp.GetPropertyType();
                        xElemChild.Attributes.Append(xAtr);

                        xElemChild.InnerText = oProp.GetPropertyStringValue();

                        xElemParent.AppendChild(xElemChild);
                    }
                }

                #endregion

                #region XML Data files channels

                //Write all data channels
                xChannels = oXDoc.CreateElement("DataFileChannels");
                xDataFile.AppendChild(xChannels);

                foreach(GW_DataChannel oChan in Channels)
                {
                    //Channel properties
                    xChan = oXDoc.CreateElement("DataChannel");

                    xElemChild = oXDoc.CreateElement("ChannelName");
                    xElemChild.InnerText = oChan.Name;
                    xChan.AppendChild(xElemChild);

                    xElemChild = oXDoc.CreateElement("ChannelDescription");
                    xElemChild.InnerText = oChan.Description;
                    xChan.AppendChild(xElemChild);

                    xElemChild = oXDoc.CreateElement("ChannelUnit");
                    xElemChild.InnerText = oChan.Unit;
                    xChan.AppendChild(xElemChild);

                    xChan.AppendChild(oChan.GraphicFormat.GetSerieValueFormatXmlNode(oXDoc));

                    if(oChan.ChannelReferenceLines.Count>0)
                    {
                        xElemParent = oXDoc.CreateElement("ChannelReferenceLines");
                        xChan.AppendChild(xElemParent);

                        foreach (GraphReferenceLine oLine in oChan.ChannelReferenceLines)
                        {
                            xElemParent.AppendChild(oLine.Create_ReferenceLineXmlNode(oXDoc, "ReferenceLine"));
                        }
                    }

                    //Channel samples
                    xSamples = oXDoc.CreateElement("ChannelSamples");
                    xChan.AppendChild(xSamples);

                    foreach (SerieSample sSample in oChan.Samples)
                    {
                        xElemParent = oXDoc.CreateElement("ChannelSample");
                        xSamples.AppendChild(xElemParent);

                        xElemChild = oXDoc.CreateElement("SampleTime");
                        xElemChild.InnerText = sSample.SampleTime.ToString();
                        xElemParent.AppendChild(xElemChild);

                        xElemChild = oXDoc.CreateElement("SampleValue");
                        xElemChild.InnerText = sSample.SampleValue.ToString();
                        xElemParent.AppendChild(xElemChild);
                    }

                    xChannels.AppendChild(xChan);
                }

                #endregion

                oXDoc.Save(fPath);
            }
        }

        /// <summary>
        /// Return the GW_DataChannel item corresponding to the name given as argument
        /// </summary>
        /// <param name="Name">Name of the channel to retrieve</param>
        /// <returns>GW_DataChannel item corresponding to the name given as argument</returns>
        /// <remarks>Return null if the GW_DataChannel item is not found</remarks>
        public GW_DataChannel Get_DataChannel(string Name)
        {
            int Key = 0;

            foreach (GW_DataChannel oChan in Channels)
            {
                if (oChan.Name.Equals(Name))
                {
                    oChan.KeyId = Key;
                    return (oChan);
                }

                Key++;
            }

            return (null);
        }

        /// <summary>
        /// Determine whether the GW_DataChannel corresponding to the name given as argument exist in the current object channels collection
        /// </summary>
        /// <param name="Name">Name of the channel to search</param>
        /// <returns>True =  Channel exists / False = Channel doesn't exist</returns>
        public bool DataChannelExists(string Name)
        {
            foreach (GW_DataChannel oChan in Channels)
            {
                if (oChan.Name.Equals(Name))
                {
                    return (true);
                }
            }

            return (false);
        }
        
        /// <summary>
        /// Return the index of the time sample corresponding to the time value given as argument
        /// </summary>
        /// <param name="TimeVal">Time value to search</param>
        /// <returns>Index of the time sample corresponding to the time value given as argument</returns>
        /// <remarks>Return -1 if the time value is not found
        /// Works only for single sampling rate data file</remarks>
        public int Get_SampleIndexAtTime(double TimeVal)
        {
            if (DataSamplingMode == SamplingMode.SingleRate)
            {
                for (int iSample = 0; iSample < Time.Values.Count; iSample++)
                {
                    if (Time.Values[iSample] > TimeVal)
                    {
                        if (!(iSample == 0))
                        {
                            return (iSample - 1);
                        }
                        else
                        {
                            return (-1);
                        }
                    }
                }
            }

        	return(-1);
        }

        /// <summary>
        /// Return the sample value of the channel given as argument at the sample index given as argument
        /// </summary>
        /// <param name="ChannelName">Name of the channel to search</param>
        /// <param name="SampleIndex">Index of sample</param>
        /// <returns>Channel value at the sample index</returns>
        /// <remarks>Return NaN if the channel is not found or if the sample index doesn't exist</remarks>
        public double Get_ChannelValueAtIndex(string ChannelName, int SampleIndex)
        {
        	GW_DataChannel oChan = Get_DataChannel(ChannelName);

            if (!(oChan == null))
            {
                switch (DataSamplingMode)
                {
                    case SamplingMode.SingleRate:

                        if (SampleIndex >= 0 && SampleIndex < oChan.Values.Count)
                        {
                            return (oChan.Values[SampleIndex]);
                        }

                        break;

                    case SamplingMode.MultipleRates:

                        if(SampleIndex>=0 && SampleIndex < oChan.Samples.Count)
                        {
                            return (oChan.Samples[SampleIndex].SampleValue);
                        }

                        break;
                }
        	}
        	
        	return(double.NaN);
        }

        /// <summary>
        /// Return the sample value of the channel given as argument at the time value given as argument 
        /// </summary>
        /// <param name="ChannelName">Name of the channel to search</param>
        /// <param name="TimeValue">Time value to search</param>
        /// <returns>Channel value at the time</returns>
        /// <remarks>Return NaN if the channel is not found or if the time value doesn't exist</remarks>
        public double Get_ChannelValueAtTime(string ChannelName, double TimeValue)
        {
            GW_DataChannel oChan = Get_DataChannel(ChannelName);

            if (!(oChan == null))
            {
                switch(DataSamplingMode)
                {
                    case SamplingMode.SingleRate:

                        {
                            int TimeIndex = Get_SampleIndexAtTime(TimeValue);

                            if (TimeIndex >= 0 && TimeIndex < oChan.Values.Count)
                            {
                                return (oChan.Values[TimeIndex]);
                            }
                        }

                        break;

                    case SamplingMode.MultipleRates:

                        {
                            for (int iTime=0; iTime<oChan.Samples.Count; iTime++)
                            {
                                if (oChan.Samples[iTime].SampleTime > TimeValue)
                                {
                                    if (!(iTime==0))
                                    {
                                        return (oChan.Samples[iTime - 1].SampleValue);
                                    }
                                }
                            }
                        }

                        break;
                }
            }

            return (double.NaN);
        }

        /// <summary>
        /// Process the FIFO time buffer
        /// </summary>
        public void FIFO_TimeBuffer()
        {
            //TODO: Update serie Min/Max/Avg stats on value removal
            //TODO: Raise an event on Min/Max values change for series conversion coords re-computing and Y axis values updates

            if (TimeBufferSize != -1)
            {
                if (DataSamplingMode == SamplingMode.MultipleRates)
                {
                    foreach (GW_DataChannel oChan in Channels)
                    {
                        if (oChan.Samples.Count > 1)
                        {
                            SerieSample sLastSample = oChan.Samples[oChan.Samples.Count - 1];

                            while (sLastSample.SampleTime - oChan.Samples[0].SampleTime > TimeBufferSize)
                            {
                                oChan.Samples.RemoveAt(0);
                            }
                        }
                    }
                }
                else
                {
                    if (Time.Values.Count > 1)
                    {
                        double LastSampleTime = Time.Values[Time.Values.Count - 1];

                        while (LastSampleTime - Time.Values[0] > TimeBufferSize)
                        {
                            Time.Values.RemoveAt(0);

                            foreach (GW_DataChannel oChan in Channels)
                            {
                                oChan.Values.RemoveAt(0);
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
