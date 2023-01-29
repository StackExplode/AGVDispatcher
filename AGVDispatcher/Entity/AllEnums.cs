﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Entity
{
    public enum AGVState : byte
    {
        StopIdle = 0,
        Running = 1,
        E_Stop = 2,
        DriverFailure = 3,
        OutOfLine = 4,
        FullLine = 5,
        Anticollision_M = 6,
        Anticollision_L = 7,
        BatteryLow = 8,
        InternalError = 9,
        DispatchTimeout = 10,
        ExecutionTimout = 11,
        LimitTrigger = 12,
        UnReady = 255
    }

    [Flags]
    public enum AGVComState : byte
    {
        Unkown = 0,
        OnLine = 1,
        Authorized = (1 << 1),
        TimeOut = (1 << 2),
        ComError = (1 << 3),
        Normal = OnLine | Authorized,

    }

    public enum AGVWorkState : byte
    {
        NotReady,
        Idle,
        Running,
        Waiting,
        Working
    }

    public enum ComErrorCode : byte
    {
        Success = 0,
        WRError = 1,
        UnReady = 2,
        DataConflict = 3,
        UnSupport = 4,
        Overflow = 5,
        UnAuthorized = 255
    }

    public enum ComDataType : byte
    {
        GenralResponse = 0xFF,
        AuthRequest = 0x00,
        AuthResponse = 0x80,
        Validation = 0x01,
        QueryState = 0x02,
        StateResponse = 0x82,
        StartRun = 0x05,
        StopRun = 0x06,
        TurnDirection = 0x07,
        SetSpeed = 0x08,
        ForceStation = 0x09,
        SetIO = 0x0A,
        ButtonSimulate = 0x0B,
        BarrierAvoidReq = 0x0D,
        BarrierAvoidRes = 0x8D,
        SetBarrierVoid = 0x0E,
        SetPointInsCache = 0x10,
        SetTimeout = 0x12,
        WritePLC = 0x13,
        ReadPLCRequest = 0x14,
        ReadPLCResponse = 0x94

    }

    [Flags]
    public enum SensorState : byte
    {
        StopOutLine = (1 << 7),
        LowBattery = (1 << 6),
        BarrierNearby = (1 << 5),
        BarrierDetect = (1 << 4),
        BarrierAvoidFailure = (1 << 3),

        UnTriggered = 0
    }

    [Flags]
    public enum DirectionCode : byte
    {
        Old_Backward = (1 << 7),
        Old_Right = (1 << 6),

        None = 1,
        Forward = 2,
        Backward = 3,
        AntiClockwiseRotate = 4,
        ClockwiseRotate = 5,
        LeftMove = 6,
        RightMove = 7,
    }

    [Flags]
    public enum IOState : byte
    {
        Bit1 = (1 << 7),
        Bit2 = (1 << 6),
        Bit3 = (1 << 5),
        Bit4 = (1 << 4),
    }

    public enum StopType : byte
    {
        Normal = 0,
        Brake = 1,
        SlowDown = 2
    }

    public enum TurnType : byte
    {
        NoChange = 0,
        Reverse = 1,
        LeftTurn = 2,
        RightTurn = 3
    }

    public enum IOSetMode : byte
    {
        NoChange = 0,
        Reverse = 1,
        Release = 2,
        Trigger = 3,
        Hook = 3,
        PutUp = 2,
        PutDown = 3
    }

    public enum CacheOpCode : byte
    {
        Create = 0,
        Delete = 1,
        Clear = 2
    }

    public enum InsOpCode : byte
    {
        Empty = 0x00,
        SetSpeed,
        QuestCondition,
        DirectionCondition,
        SignalCondition,
        Brake,
        Stop,
        SlowStop,
        Run,
        Turn,
        Hook,
        SetSensorChannel,
        SetIO1,
        SetIO2,
        SetIO3,
        SetIO4,
        SetQuestCondition,
        DeleteQuestCondition,
        ForcePoint,
        ClearCondition,
        HookCondition,
        SetAngel = 0xFB,
        CenterRotate = 0xFC,
        Translation = 0x0FD,
        SituRotate = 0xFE,
        Delay = 0xFF
    }

    public enum PointType : byte
    {
        Normal = 0,
        BreakZone,
        Product,
        Turn,
        WorkStation
    }

    public enum AGVType : byte
    {
        AGVNormal = 0,
        PLCSimu = 1
    }

    public enum OpRunParam : byte
    {
        Foreward = 0,
        Backward = 1,
        SameAsLast = 2,
        ReverseAsLast = 3
    }

    public enum OpHookParam : byte
    {
        Release = 0,
        Hookup = 1,
        Switch = 2
    }

    public enum OpTurnType : byte
    {
        LeftTurn = 0,
        RightTurn = 1,
        Switch = 2
    }
}
