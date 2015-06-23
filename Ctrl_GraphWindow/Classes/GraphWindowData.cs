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
        /// Data channel values
        /// </summary>
        public List<double> Values;

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

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GW_DataChannel()
        {
            Name = "";
            Values = new List<double>();
            Min = 0;
            Max = 0;
        }

        /// <summary>
        /// Constructor including the name of the data channel to create
        /// </summary>
        /// <param name="ChannelName">Channel name</param>
        public GW_DataChannel(string ChannelName)
        {
            Name = ChannelName;
            Values = new List<double>();
            Min = 0;
            Max = 0;
        }

        #endregion

        #region Public methodes

        /// <summary>
        /// Add a value into the channel values collection and update min, max and average values
        /// </summary>
        /// <param name="Value">Value to add into the values collection</param>
        public void Add_ChannelValue(double Value)
        {
            Values.Add(Value);

            if (Values.Count > 1)
            {
                if (Value < Min) Min = Value;
                if (Value > Max) Max = Value;
                Avg = ((Avg * (Values.Count - 1)) + Value) / Values.Count;
            }
            else
            {
                Min = Value;
                Max = Value;
                Avg = Value;
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
        #region Public members

        /// <summary>
        /// Time vector of the data file
        /// </summary>
        public GW_DataChannel Time;

        /// <summary>
        /// Data channels collection of the data file
        /// </summary>
        public List<GW_DataChannel> Channels;
        
        /// <summary>
        /// Mininimum step time of the file
        /// </summary>
        public double StepTimeMin;
        
         /// <summary>
        /// Maximum step time of the file
        /// </summary>
        public double StepTimeMax;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GW_DataFile()
        {
            Time = new GW_DataChannel("Time");
            Channels = new List<GW_DataChannel>();
            
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
        /// <remarks>Return -1 if the time value is not found</remarks>
        public int Get_SampleIndexAtTime(double TimeVal)
        {
        	for (int iSample = 0; iSample < Time.Values.Count; iSample++)
        	{
        		if (Time.Values[iSample] > TimeVal)
        		{
        			if (!(iSample == 0))
        			{
        				return(iSample - 1);
        			}
        			else
        			{
        				return(-1);
        			}
        		}
        	}
        	
        	return(-1);
        }
        
        /// <summary>
        /// Return the sample value at the index given as argument of the channel given as argument
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
        		if (SampleIndex >= 0 && SampleIndex < oChan.Values.Count)
        		{
        			return(oChan.Values[SampleIndex]);
        		}
        	}
        	
        	return(double.NaN);
        }

        #endregion
    }
}
