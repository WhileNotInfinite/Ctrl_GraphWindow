using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            InitChannelValues(SampleMode);
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

            InitChannelValues(SampleMode);
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

            if (Value.GetType().Equals(typeof(double)))
            {
                DataValue = (double)Value;
                Values.Add(DataValue);

                ValCnt = Values.Count;
            }
            else if (Value.GetType().Equals(typeof(SerieSample)))
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
                if (DataValue < Min) Min = DataValue;
                if (DataValue > Max) Max = DataValue;
                Avg = ((Avg * (ValCnt - 1)) + DataValue) / ValCnt;
            }
            else
            {
                Min = DataValue;
                Max = DataValue;
                Avg = DataValue;
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
                            if (Channels[iChan].Samples[0].SampleTime < TimeMin)
                            {
                                TimeMin = Channels[iChan].Samples[0].SampleTime;
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
                            if (Channels[iChan].Samples[Channels[iChan].Samples.Count - 1].SampleTime > TimeMax)
                            {
                                TimeMax = Channels[iChan].Samples[Channels[iChan].Samples.Count - 1].SampleTime;
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
        public List<GW_DataChannel> Channels;
       
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
            Channels = new List<GW_DataChannel>();
            TimeBufferSize = -1;

            StepTimeMin = 0;
            StepTimeMax = 0;
        }

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
        /// Return the GW_DataChannel item corresponding to the name given as argument
        /// </summary>
        /// <param name="Name">Name of the channel to retrieve</param>
        /// <returns>GW_DataChannel item corresponding to the name given as argument</returns>
        /// <remarks>Return null if the GW_DataChannel item is not found</remarks>
        public GW_DataChannel Get_DataChannel(string Name)
        {
            foreach (GW_DataChannel oChan in Channels)
            {
                if (oChan.Name.Equals(Name))
                {
                    return (oChan);
                }
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
            if (TimeBufferSize != -1)
            {
                if (DataSamplingMode == SamplingMode.MultipleRates)
                {
                    foreach(GW_DataChannel oChan in Channels)
                    {
                        SerieSample sLastSample = oChan.Samples[oChan.Samples.Count - 1];

                        while (sLastSample.SampleTime - oChan.Samples[0].SampleTime > TimeBufferSize)
                        {
                            oChan.Samples.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    double LastSampleTime = Time.Values[Time.Values.Count - 1];

                    while (LastSampleTime - Time.Values[0] > TimeBufferSize)
                    {
                        Time.Values.RemoveAt(0);

                        foreach(GW_DataChannel oChan in Channels)
                        {
                            oChan.Values.RemoveAt(0);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
