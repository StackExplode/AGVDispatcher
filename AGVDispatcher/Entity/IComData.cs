using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ReadOnlyCollection<byte> RawBuffer { get; }
        public void SetBuffer(byte[] data);
        public byte CalcCheckSum();
        public byte CheckCode { get; }
        public byte AGVID { get; }
        public ushort SerialCode { get; }
        public AGVComData<UnknownData> AsUnkownData();
        public AGVComData<T> UnsafeAs<T>() where T : IComDataField;
    }


    public class AGVComData<TData> : IComData where TData : IComDataField
    {
        public const int DataLen = 20 + 6;
        protected byte[] buffer;
        public AGVComData()
        {
            buffer = new byte[DataLen];
            RawData.DataType = PayLoad.DataType;
            RawData.StartFlag = 0x55;
            RawData.EndFlag = 0xAA;
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
        public ReadOnlyCollection<byte> RawBuffer => Array.AsReadOnly(buffer);

        public AGVComData(byte id,ushort serialcode = 0):this()
        {
            AGVID = id;
            SerialCode = serialcode;
        }

        public void ChangeBuffer(byte[] buff)
        {
            this.buffer = buff;
        }

        public ref DataField<TData> RawData
        {
            get
            {
                ref DataField<TData> data = ref Unsafe.As<byte, DataField<TData>>(ref buffer[0]);
                return ref data;
            }
        }

        //public ref DataField<TTT> GetRawDataAs<TTT>() where TTT : IComDataField
        //{
        //    ref DataField<TTT> data = ref Unsafe.As<byte, DataField<TTT>>(ref buffer[0]);
        //    return ref data;
        //}

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
            RawData.CheckCode = CalcCheckSum();  
            return buffer;
        }

        public byte CalcCheckSum()
        {
            uint sum = 0;
            for (int i = 1; i <= 23; i++)
                sum += buffer[i];
            //sum += 0xFF;
            byte mod = (byte)(sum % 256);
            //return mod;
            return (byte)(-mod);
        }

        public AGVComData<UnknownData> AsUnkownData()
        {
            return (AGVComData<UnknownData>)(IComData)this;
        }

        public AGVComData<T> UnsafeAs<T>() where T : IComDataField
        {
            return Unsafe.As<AGVComData<T>>(this);
        }

        public static explicit operator AGVComData<TData>(AGVComData<UnknownData> v)
        {
            return Unsafe.As<AGVComData<TData>>(v);
        }

    }


}
