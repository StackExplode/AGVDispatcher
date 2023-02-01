using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XXXTest;

namespace AGVDispatcher
{
    static class DataTemplateTest
    {
        public static void Run()
        {
            byte[] buff = { 1,2,3,4,5,6,7,8 };
            AGVComData<IComDataField> rdata = new AGVComData<IComDataField>();
            rdata.buffer = buff;
            var fdata = Unsafe.As<AGVComData<UnknownData>>(rdata);
            Debug.WriteLine($"Byte2={fdata.RawData.ByteLast2}, Payload2={1/*fdata.RawData.PayLoad.DataAPayLoad2*/}");
        }
    }
}

namespace XXXTest
{

    public interface IComDataField
    {

    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DataField<T> where T : IComDataField
    {
        public byte Byte1;
        public byte Byte2;
        public T PayLoad;
        public byte ByteLast2;
        public byte ByteLast1;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct UnknownData : IComDataField
    {
        
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DataA : IComDataField
    {
        public byte DataAPayLoad1;
        public byte DataAPayLoad2;
        public byte DataAPayLoad3;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DataB : IComDataField
    {
        public byte DataBPayLoad1;
        public byte DataBPayLoad2;
        public byte DataBPayLoad3;
        public byte DataBPayLoad4;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DataC : IComDataField
    {
        public byte DataCPayLoad1;
        public byte DataCPayLoad2;
    }

    public interface IComData {

    }

    public class AGVComData<TData> :IComData where TData : IComDataField
    {
        public byte[] buffer;

        public ref DataField<TData> RawData
        {
            get
            {
                ref DataField<TData> data = ref Unsafe.As<byte, DataField<TData>>(ref buffer[0]);
                return ref data;
            }
        }
    }

}
