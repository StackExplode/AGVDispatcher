using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct UnknownData : IComDataField
    {
        public fixed byte NoUse[19];
        public ComDataType DataType => ComDataType.GenralResponse;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct GeneralResponseData : IComDataField
    {
        public ComDataType RequestCode;
        public ComErrorCode ErrorCode;
        public fixed byte NoUse[19 - 2];

        public ComDataType DataType =>  ComDataType.GenralResponse;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct AuthRequestData : IComDataField
    {
        public fixed byte NoUse[19];

        public ComDataType DataType => ComDataType.AuthRequest;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct AuthResponseData : IComDataField
    {
        public bool IsAuthNeeded;
        public fixed byte Salt[8];
        public fixed byte NoUse[19 - 8 - 1]; 

        public ComDataType DataType => ComDataType.GenralResponse;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ValidationData : IComDataField
    {
        public fixed byte Code[16];
        public fixed byte NoUse[19 - 16];
        
        public ComDataType DataType => ComDataType.Validation;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct QueryStateData : IComDataField
    {
        public fixed byte NoUse[19];

        public ComDataType DataType => ComDataType.QueryState;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct StateResponseData : IComDataField
    {
        public AGVState State;
        public ushort PhysicPoint;
        public uint Mileage;
        public ushort LogicPoint;
        public SensorState @SensorState;
        public byte CurrentSpeed;
        public DirectionCode Direction;
        public bool Hooked;
        public IOState InputState;
        public IOState OutputState;
        public byte VoltageInt;
        public byte VoltageDecimal;
        public byte BatteryPercent;
        public fixed byte NoUse[1];

        public ComDataType DataType => ComDataType.StateResponse;
        public float Voltage => VoltageInt + VoltageDecimal / 10.0f;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct StartRunData : IComDataField
    {
        public DirectionCode Direction;
        public fixed byte NoUse[19 - 1];

        public ComDataType DataType => ComDataType.StartRun;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct StopRunData : IComDataField
    {
        public StopType @StopType;
        public fixed byte NoUse[19 - 1];

        public ComDataType DataType => ComDataType.StopRun;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct TurnDirectionData : IComDataField
    {
        public TurnType @TurnType;
        public fixed byte NoUse[19 - 1];

        public ComDataType DataType => ComDataType.TurnDirection;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SetSpeedData : IComDataField
    {
        public byte Speed;
        public fixed byte NoUse[19 - 1];

        public ComDataType DataType => ComDataType.SetSpeed;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SetIOData : IComDataField
    {
        public IOSetMode Hook;
        public IOSetMode ExtIO1;
        public IOSetMode ExtIO2;
        public IOSetMode ExtIO3;
        public IOSetMode ExtIO4;
        public fixed byte NoUse[14];

        public ComDataType DataType => ComDataType.SetIO;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SetIODataPLCFake : IComDataField
    {
        private fixed byte _ExtIO[18];
        public ComDataType DataType => ComDataType.SetIO;
        public void SetExtIO(byte index, IOSetMode io) => _ExtIO[index] = (byte)io;
        public IOSetMode GetExtIO(byte index) => (IOSetMode)_ExtIO[index];

    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ButtonSimulateData : IComDataField
    {
        public bool EmergencyStop;
        public bool Ready;
        public bool FaultClear;
        public IOSetMode Driver;
        public fixed byte NoUse[15];

        public ComDataType DataType => ComDataType.ButtonSimulate;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SetPointInsCacheData : IComDataField
    {
        public CacheOpCode CacheOP;
        public ushort Point;
        //         public InsOpCode Instruction1;
        //         public byte Parameter1;
        //         public InsOpCode Instruction2;
        //         public byte Parameter2;
        //         public InsOpCode Instruction3;
        //         public byte Parameter3;
        //         public InsOpCode Instruction4;
        //         public byte Parameter4;
        //         public InsOpCode Instruction5;
        //         public byte Parameter5;
        //         public InsOpCode Instruction6;
        //         public byte Parameter6;
        //         public InsOpCode Instruction7;
        //         public byte Parameter7;
        //         public InsOpCode Instruction8;
        //         public byte Parameter8;

        public fixed byte buff[16];

        public ref (InsOpCode OpCode, byte Param) Instructions(int index) //index start from 1 and not more than 8
        {
            Contract.Assert(index >= 1);
            Contract.Assert(index <= 8);
            ref (InsOpCode, byte) x = ref Unsafe.As<byte, (InsOpCode, byte)>(ref buff[sizeof((InsOpCode, byte)) * (index - 1)]);
            return ref x;

        }

        public ComDataType DataType => ComDataType.SetPointInsCache;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SetTimeoutData : IComDataField
    {
        public ushort Timeout;
        public fixed byte NoUse[17];

        public ComDataType DataType => ComDataType.SetTimeout;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct WritePLCData : IComDataField
    {
        public byte StartAddr;
        public byte Number;
        public fixed ushort Values[8];
        public fixed byte NoUse[1];

        public ComDataType DataType => ComDataType.WritePLC;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ReadPLCResponseData : IComDataField
    {
        public byte StartAddr;
        public byte Number;
        public fixed ushort Values[8];
        public fixed byte NoUse[1];

        public ComDataType DataType => ComDataType.ReadPLCResponse;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ReadPLCRequestData : IComDataField
    {
        public byte StartAddr;
        public byte Number;
        public fixed byte NoUse[17];

        public ComDataType DataType => ComDataType.ReadPLCRequest;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ForceStationData : IComDataField
    {
        public ushort StationID;
        public fixed byte NoUse[17];

        public ComDataType DataType => ComDataType.ForceStation;
    }

}
