using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    public interface IComDataField
    {
        public ComDataType DataType { get; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DataField<T> where T : IComDataField
    {
        public byte StartFlag;
        public byte AGVID;
        public ushort SerialCode;
        public ComDataType DataType;
        public T PayLoad;
        public byte CheckCode;
        public byte EndFlag;
    }

#if DEBUG
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct HelloDataField : IComDataField
    {       
        public ushort testdata;
        public fixed byte NoUse[16];
        public byte tdata2;

        public ComDataType DataType => (ComDataType)0x5F;
    }
#endif
    public interface IComData
    {
        public ComDataType DataType { get; }
        public byte[] RawBuffer { get; }
        public void SetBuffer(byte[] data);
        public byte CheckSum();
        public byte CheckCode { get; }
        public byte AGVID { get; }
        public ushort SerialCode { get; }
    }

    public class AGVComData<TData> : IComData where TData : IComDataField
    {
        public const int DataLen = 20 + 6;
        protected byte[] buffer;
        public AGVComData()
        {
            buffer = new byte[DataLen];
        }
        public byte AGVID
        {
            get => RawData.AGVID;
            set => RawData.AGVID = value;
        }
        public ushort SerialCode
        {
            get => RawData.SerialCode;
            set => RawData.SerialCode = value;
        }
        public ComDataType DataType
        {
            get => RawData.DataType;
            //set => RawData.DataType = value;
        }
        public byte[] RawBuffer => buffer;

        public AGVComData(byte id,ushort serialcode = 0):this()
        {
            AGVID = id;
            SerialCode = serialcode;
        }
        

        public ref DataField<TData> RawData
        {
            get
            {
                ref DataField<TData> data = ref Unsafe.As<byte, DataField<TData>>(ref buffer[0]);
                return ref data;
            }
        }

        public ref TData PayLoad
        {
            get
            {
                /*ref TData data = ref Unsafe.As<byte, TData>(ref RawData.PayLoad[0]);
                return ref data;*/
                return ref RawData.PayLoad;
            }
        }

        public byte CheckCode => RawData.CheckCode;

        public void SetBuffer(byte[] data)
        {
            Buffer.BlockCopy(data, 0, buffer, 0, DataLen);
 
        }


        public byte[] ToArray()
        {
            RawData.StartFlag = 0x55;
            RawData.EndFlag = 0xAA;
            RawData.CheckCode = CheckSum();
            RawData.DataType = PayLoad.DataType;
            return buffer;
        }

        public byte CheckSum()
        {
            uint sum = 0;
            for (int i = 1; i < 23; i++)
                sum += buffer[i];
            byte mod = (byte)(sum % 256);
            return (byte)(0xFF - mod);
        }

    }


}
