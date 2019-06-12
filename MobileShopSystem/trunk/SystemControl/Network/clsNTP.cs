#region SOURCE INFORMATION

// COPYRIGHT LICENCE
// 
//  Copyright (c) 2011, D.E.M.O.N Organization
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without modification,
//  are permitted provided that the following conditions are met:
// 
//      * Redistributions of source code must retain the above copyright notice,
//      this list of conditions and the following disclaimer.
//      * Redistributions in binary form must reproduce the above copyright notice,
//      this list of conditions and the following disclaimer in the documentation
//      and/or other materials provided with the distribution.
//      * Neither D.E.M.O.N Organization nor its contributors
//      may be used to endorse or promote products derived from this
//      software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//  DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
//  FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
//  DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//  SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
//  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//  OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
//  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
// 
// 
// CODE DESCRIPTION
// 
//        Created by Raistlin.K @ D.E.M.O.N at  23:47  09/10/2011 .
//        E-Mail:                         DemonVK@Gmail.com
// 
//        Project Name:                   SystemControl
//        Module  Name:                   clsNTP.cs
//        Part Of:                        LongXiangTools
//        Last Change Date:               4:13 27/12/2011

#endregion

namespace SystemControl.Network
{
    #region

    using System;
    using System.Net;
    using System.Net.Sockets;

    #endregion

    // Leap indicator field values
    public enum _LeapIndicator
    {
        NoWarning, // 0 - No warning
        LastMinute61, // 1 - Last minute has 61 seconds
        LastMinute59, // 2 - Last minute has 59 seconds
        Alarm // 3 - Alarm condition (clock not synchronized)
    }

    //Mode field values
    public enum _Mode
    {
        SymmetricActive, // 1 - Symmetric active
        SymmetricPassive, // 2 - Symmetric pasive
        Client, // 3 - Client
        Server, // 4 - Server
        Broadcast, // 5 - Broadcast
        Unknown // 0, 6, 7 - Reserved
    }

    // Stratum field values
    public enum _Stratum
    {
        Unspecified, // 0 - unspecified or unavailable
        PrimaryReference, // 1 - primary reference (e.g. radio-clock)
        SecondaryReference, // 2-15 - secondary reference (via NTP or SNTP)
        Reserved // 16-255 - reserved
    }

    ///<summary>
    ///  SNTPTimeClient 的摘要说明。
    /// 
    ///  Public class members:
    ///
    ///  LeapIndicator - Warns of an impending leap second to be inserted/deleted in the last
    ///  minute of the current day. (See the _LeapIndicator enum)
    /// 
    ///  VersionNumber - Version number of the protocol (3 or 4).
    /// 
    ///  Mode - Returns mode. (See the _Mode enum)
    /// 
    ///  Stratum - Stratum of the clock. (See the _Stratum enum)
    /// 
    ///  PollInterval - Maximum interval between successive messages.
    /// 
    ///  Precision - Precision of the clock.
    /// 
    ///  RootDelay - Round trip time to the primary reference source.
    /// 
    ///  RootDispersion - Nominal error relative to the primary reference source.
    /// 
    ///  ReferenceID - Reference identifier (either a 4 character string or an IP address).
    /// 
    ///  ReferenceTimestamp - The time at which the clock was last set or corrected.
    /// 
    ///  OriginateTimestamp - The time at which the request departed the client for the server.
    /// 
    ///  ReceiveTimestamp - The time at which the request arrived at the server.
    /// 
    ///  Transmit Timestamp - The time at which the reply departed the server for client.
    /// 
    ///  RoundTripDelay - The time between the departure of request and arrival of reply.
    /// 
    ///  LocalClockOffset - The offset of the local clock relative to the primary reference
    ///  source.
    /// 
    ///  Initialize - Sets up data structure and prepares for connection.
    /// 
    ///  Connect - Connects to the time server and populates the data structure.
    /// 
    ///  IsResponseValid - Returns true if received data is valid and if comes from
    ///  a NTP-compliant time server.
    /// 
    ///  ToString - Returns a string representation of the object.
    /// 
    ///  -----------------------------------------------------------------------------
    ///  Structure of the standard NTP header (as described in RFC 2030)
    ///  1                   2                   3
    ///  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |LI | VN  |Mode |    Stratum    |     Poll      |   Precision   |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                          Root Delay                           |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                       Root Dispersion                         |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                     Reference Identifier                      |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                                                               |
    ///  |                   Reference Timestamp (64)                    |
    ///  |                                                               |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                                                               |
    ///  |                   Originate Timestamp (64)                    |
    ///  |                                                               |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                                                               |
    ///  |                    Receive Timestamp (64)                     |
    ///  |                                                               |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                                                               |
    ///  |                    Transmit Timestamp (64)                    |
    ///  |                                                               |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                 Key Identifier (optional) (32)                |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                                                               |
    ///  |                                                               |
    ///  |                 Message Digest (optional) (128)               |
    ///  |                                                               |
    ///  |                                                               |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// 
    ///  -----------------------------------------------------------------------------
    /// 
    ///  NTP Timestamp Format (as described in RFC 2030)
    ///  1                   2                   3
    ///  0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                           Seconds                             |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///  |                  Seconds Fraction (0-padded)                  |
    ///  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ///</summary>
    public class SNTPTimeClient
    {
        // NTP Data Structure Length
        private const byte NTPDataLength = 48;
        // NTP Data Structure (as described in RFC 2030)

        // Offset constants for timestamps in the data structure
        private const byte offReferenceID = 12;
        private const byte offReferenceTimestamp = 16;
        private const byte offOriginateTimestamp = 24;
        private const byte offReceiveTimestamp = 32;
        private const byte offTransmitTimestamp = 40;
        private readonly string TimePort;
        private readonly string TimeServer;
        private byte[] NTPData = new byte[NTPDataLength];
        public DateTime ReceptionTimestamp;

        public SNTPTimeClient(string host, string port)
        {
            TimeServer = host;
            TimePort = port;
        }

        // Leap Indicator
        public _LeapIndicator LeapIndicator
        {
            get
            {
                // Isolate the two most significant bits
                var val = (byte) (NTPData[0] >> 6);
                switch (val)
                {
                    case 0:
                        return _LeapIndicator.NoWarning;
                    case 1:
                        return _LeapIndicator.LastMinute61;
                    case 2:
                        return _LeapIndicator.LastMinute59;
                    case 3:
                    default:
                        return _LeapIndicator.Alarm;
                }
            }
        }

        // Version Number
        public byte VersionNumber
        {
            get
            {
                // Isolate bits 3 - 5
                var val = (byte) ((NTPData[0] & 0x38) >> 3);
                return val;
            }
        }

        // Mode
        public _Mode Mode
        {
            get
            {
                // Isolate bits 0 - 3
                var val = (byte) (NTPData[0] & 0x7);
                switch (val)
                {
                    case 0:
                    case 6:
                    case 7:
                    default:
                        return _Mode.Unknown;
                    case 1:
                        return _Mode.SymmetricActive;
                    case 2:
                        return _Mode.SymmetricPassive;
                    case 3:
                        return _Mode.Client;
                    case 4:
                        return _Mode.Server;
                    case 5:
                        return _Mode.Broadcast;
                }
            }
        }

        // Stratum
        public _Stratum Stratum
        {
            get
            {
                byte val = NTPData[1];
                if (val == 0) return _Stratum.Unspecified;
                else if (val == 1) return _Stratum.PrimaryReference;
                else if (val <= 15) return _Stratum.SecondaryReference;
                else
                    return _Stratum.Reserved;
            }
        }

        // Poll Interval
        public uint PollInterval
        {
            get { return (uint) Math.Round(Math.Pow(2, NTPData[2])); }
        }

        // Precision (in milliseconds)
        public double Precision
        {
            get { return (1000*Math.Pow(2, NTPData[3])); }
        }

        // Root Delay (in milliseconds)
        public double RootDelay
        {
            get
            {
                int temp = 0;
                temp = 256*(256*(256*NTPData[4] + NTPData[5]) + NTPData[6]) + NTPData[7];
                return 1000*(((double) temp)/0x10000);
            }
        }

        // Root Dispersion (in milliseconds)
        public double RootDispersion
        {
            get
            {
                int temp = 0;
                temp = 256*(256*(256*NTPData[8] + NTPData[9]) + NTPData[10]) + NTPData[11];
                return 1000*(((double) temp)/0x10000);
            }
        }

        // Reference Identifier
        public string ReferenceID
        {
            get
            {
                string val = "";
                switch (Stratum)
                {
                    case _Stratum.Unspecified:
                    case _Stratum.PrimaryReference:
                        val += Convert.ToChar(NTPData[offReferenceID + 0]);
                        val += Convert.ToChar(NTPData[offReferenceID + 1]);
                        val += Convert.ToChar(NTPData[offReferenceID + 2]);
                        val += Convert.ToChar(NTPData[offReferenceID + 3]);
                        break;
                    case _Stratum.SecondaryReference:
                        ////     switch(VersionNumber)
                        ////     {
                        ////      case 3: // Version 3, Reference ID is an IPv4 address
                        ////       string Address = NTPData[offReferenceID + 0].ToString() + "." +
                        ////        NTPData[offReferenceID + 1].ToString() + "." +
                        ////        NTPData[offReferenceID + 2].ToString() + "." +
                        ////        NTPData[offReferenceID + 3].ToString();
                        ////       try
                        ////       {
                        ////        IPAddress RefAddr = new IPAddress(Address);
                        ////        IPHostEntry Host = DNS.GetHostByAddr(RefAddr);
                        ////        val = Host.Hostname + " (" + Address + ")";
                        ////       }
                        ////       catch(Exception)
                        ////       {
                        ////        val = "N/A";
                        ////       }
                        ////     
                        ////       break;
                        ////      case 4: // Version 4, Reference ID is the timestamp of last update
                        ////       DateTime time = ComputeDate(GetMilliSeconds(offReferenceID));
                        ////       // Take care of the time zone
                        ////       long offset = TimeZone.CurrentTimeZone.GetUTCOffset(DateTime.Now);
                        ////       TimeSpan offspan = TimeSpan.FromTicks(offset);
                        ////       val = (time + offspan).ToString();
                        ////       break;
                        ////      default:
                        ////       val = "N/A";
                        ////     }
                        break;
                }

                return val;
            }
        }

        // Reference Timestamp
        public DateTime ReferenceTimestamp
        {
            get
            {
                DateTime time = ComputeDate(GetMilliSeconds(offReferenceTimestamp));
                // Take care of the time zone
                long offset = Convert.ToInt64(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now));
                TimeSpan offspan = TimeSpan.FromTicks(offset);
                return time + offspan;
            }
        }

        // Originate Timestamp
        public DateTime OriginateTimestamp
        {
            get { return ComputeDate(GetMilliSeconds(offOriginateTimestamp)); }
        }

        // Receive Timestamp
        public DateTime ReceiveTimestamp
        {
            get
            {
                DateTime time = ComputeDate(GetMilliSeconds(offReceiveTimestamp));
                // Take care of the time zone
                long offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Ticks;
                TimeSpan offspan = TimeSpan.FromTicks(offset);
                return time + offspan;
            }
        }

        // Transmit Timestamp
        public DateTime TransmitTimestamp
        {
            get
            {
                DateTime time = ComputeDate(GetMilliSeconds(offTransmitTimestamp));
                // Take care of the time zone    
                long offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Ticks;
                TimeSpan offspan = TimeSpan.FromTicks(offset);
                return time + offspan;
            }
            set { SetDate(offTransmitTimestamp, value); }
        }

        // Reception Timestamp

        // Round trip delay (in milliseconds)
        public int RoundTripDelay
        {
            get
            {
                TimeSpan span = (ReceiveTimestamp - OriginateTimestamp) + (ReceptionTimestamp - TransmitTimestamp);
                return (int) span.TotalMilliseconds;
            }
        }

        // Local clock offset (in milliseconds)
        public int LocalClockOffset
        {
            get
            {
                TimeSpan span = (ReceiveTimestamp - OriginateTimestamp) - (ReceptionTimestamp - TransmitTimestamp);
                return (int) (span.TotalMilliseconds/2);
            }
        }

        // Compute date, given the number of milliseconds since January 1, 1900
        private DateTime ComputeDate(ulong milliseconds)
        {
            TimeSpan span = TimeSpan.FromMilliseconds(milliseconds);
            var time = new DateTime(1900, 1, 1);
            time += span;
            return time;
        }

        // Compute the number of milliseconds, given the offset of a 8-byte array
        private ulong GetMilliSeconds(byte offset)
        {
            ulong intpart = 0, fractpart = 0;

            for (int i = 0; i <= 3; i++)
            {
                intpart = 256*intpart + NTPData[offset + i];
            }
            for (int i = 4; i <= 7; i++)
            {
                fractpart = 256*fractpart + NTPData[offset + i];
            }
            ulong milliseconds = intpart*1000 + (fractpart*1000)/0x100000000L;
            return milliseconds;
        }

        // Compute the 8-byte array, given the date
        private void SetDate(byte offset, DateTime date)
        {
            ulong intpart = 0, fractpart = 0;
            var StartOfCentury = new DateTime(1900, 1, 1, 0, 0, 0); // January 1, 1900 12:00 AM

            var milliseconds = (ulong) (date - StartOfCentury).TotalMilliseconds;
            intpart = milliseconds/1000;
            fractpart = ((milliseconds%1000)*0x100000000L)/1000;

            ulong temp = intpart;
            for (int i = 3; i >= 0; i--)
            {
                NTPData[offset + i] = (byte) (temp%256);
                temp = temp/256;
            }

            temp = fractpart;
            for (int i = 7; i >= 4; i--)
            {
                NTPData[offset + i] = (byte) (temp%256);
                temp = temp/256;
            }
        }

        // Initialize the NTPClient data
        private void Initialize()
        {
            // Set version number to 4 and Mode to 3 (client)
            NTPData[0] = 0x1B;
            // Initialize all other fields with 0
            for (int i = 1; i < 48; i++)
            {
                NTPData[i] = 0;
            }
            // Initialize the transmit timestamp
            TransmitTimestamp = DateTime.Now;
        }

        // Connect to the time server
        public void Connect()
        {
            try
            {
                IPAddress hostadd = IPAddress.Parse(TimeServer);
                var EPhost = new IPEndPoint(hostadd, Convert.ToInt32(TimePort));

                var TimeSocket = new UdpClient();
                TimeSocket.Connect(EPhost);
                Initialize();
                TimeSocket.Send(NTPData, NTPData.Length);
                NTPData = TimeSocket.Receive(ref EPhost);
                if (!IsResponseValid())
                {
                    throw new Exception("Invalid response from " + TimeServer);
                }
                ReceptionTimestamp = DateTime.Now;
            }
            catch (SocketException e)
            {
                throw new Exception(e.Message);
            }
        }

        // Check if the response from server is valid
        public bool IsResponseValid()
        {
            if (NTPData.Length < NTPDataLength || Mode != _Mode.Server)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Converts the object to string
        public override string ToString()
        {
            string str;

            str = "Leap Indicator: ";
            switch (LeapIndicator)
            {
                case _LeapIndicator.NoWarning:
                    str += "No warning";
                    break;
                case _LeapIndicator.LastMinute61:
                    str += "Last minute has 61 seconds";
                    break;
                case _LeapIndicator.LastMinute59:
                    str += "Last minute has 59 seconds";
                    break;
                case _LeapIndicator.Alarm:
                    str += "Alarm Condition (clock not synchronized)";
                    break;
            }
            str += "\r\nVersion number: " + VersionNumber + "\r\n";
            str += "Mode: ";
            switch (Mode)
            {
                case _Mode.Unknown:
                    str += "Unknown";
                    break;
                case _Mode.SymmetricActive:
                    str += "Symmetric Active";
                    break;
                case _Mode.SymmetricPassive:
                    str += "Symmetric Pasive";
                    break;
                case _Mode.Client:
                    str += "Client";
                    break;
                case _Mode.Server:
                    str += "Server";
                    break;
                case _Mode.Broadcast:
                    str += "Broadcast";
                    break;
            }
            str += "\r\nStratum: ";
            switch (Stratum)
            {
                case _Stratum.Unspecified:
                case _Stratum.Reserved:
                    str += "Unspecified";
                    break;
                case _Stratum.PrimaryReference:
                    str += "Primary Reference";
                    break;
                case _Stratum.SecondaryReference:
                    str += "Secondary Reference";
                    break;
            }
            str += "\r\nLocal time: " + TransmitTimestamp;
            str += "\r\nPrecision: " + Precision + " ms";
            str += "\r\nPoll Interval: " + PollInterval + " s";
            str += "\r\nReference ID: " + ReferenceID;
            str += "\r\nRoot Dispersion: " + RootDispersion + " ms";
            str += "\r\nRound Trip Delay: " + RoundTripDelay + " ms";
            str += "\r\nLocal Clock Offset: " + LocalClockOffset + " ms";
            str += "\r\n";

            return str;
        }

        // The URL of the time server we're connecting to
    }
}