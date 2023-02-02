using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGVDispatcher.App
{
    public class WareHouseMapv2 : WareHouseMap
    {
        public override BreakZonePoint BKEnterPoint => (BreakZonePoint)this[4];
        public override int MAX_PROD => 21;
        public override int MAX_BREAK => 4;

        public override (TurnPoint, TurnType) PickProductTurnWay(int prod)
        {
            return ((TurnPoint)this[(ushort)(100 + prod)], TurnType.RightTurn);
        }

        public override (TurnPoint, TurnType) PutProductTurnWay(int prod)
        {
            if(prod == 6)
                return ((TurnPoint)this[206], TurnType.NoChange);
            else
                return ((TurnPoint)this[(ushort)(200 + prod)], TurnType.RightTurn);
        }

       

        public NormalPoint PickWaitPoint => (NormalPoint)this[150];

        private ReaderWriterLockSlim pick_lock = new ReaderWriterLockSlim();
        private ReaderWriterLockSlim put_lock = new ReaderWriterLockSlim();
        private ReaderWriterLockSlim putsp_lock = new ReaderWriterLockSlim();

        bool pick_busy = false;
        bool put_busy = false;
        bool putsp_busy = false;
        public bool PickBusy
        {
            get
            {
                bool rt;
                pick_lock.EnterReadLock();
                rt = pick_busy;
                pick_lock.ExitReadLock();
                return rt;
            }
            set
            {
                pick_lock.EnterWriteLock();
                pick_busy = value;
                pick_lock.ExitWriteLock();
            }
        }
        public bool PutBusy
        {
            get
            {
                bool rt;
                put_lock.EnterReadLock();
                rt = put_busy;
                put_lock.ExitReadLock();
                return rt;
            }
            set
            {
                put_lock.EnterWriteLock();
                put_busy = value;
                put_lock.ExitWriteLock();
            }
        }

        public bool PutSpBusy
        {
            get
            {
                bool rt;
                putsp_lock.EnterReadLock();
                rt = putsp_busy;
                putsp_lock.ExitReadLock();
                return rt;
            }
            set
            {
                putsp_lock.EnterWriteLock();
                putsp_busy = value;
                putsp_lock.ExitWriteLock();
            }
        }

        public bool IsPutProdctSpecial(int productid)
        {
            if (productid >= 1 && productid <= 5)
                return true;
            else
                return false;
        }

        public NormalPoint PutWaitPoint => (NormalPoint)this[200];
        public NormalPoint BreakWaitPoint => (NormalPoint)this[251];

        protected override void InitPoints()
        {
            all_pt_logic.Clear();
            for (ushort i = 0; i < MAX_BREAK; i++)
                all_pt_logic.Add((ushort)(i + 1), new BreakZonePoint()
                {
                    Order = (byte)(i),
                    LogicID = i
                });

            all_pt_logic.Add(150, new NormalPoint() { LogicID = 150 });

            for(ushort i = 1; i <= MAX_PROD; i++)
            {
                all_pt_logic.Add((ushort)(100 + i), new TurnPoint() { LogicID = (ushort)(100 + i) });
                all_pt_logic.Add((ushort)(1000 + i), new ProductPoint()
                {
                    ProductID = (byte)i,
                    IsTakePoint = true,
                    LogicID = (ushort)(1000 + i)
                });
            }

            all_pt_logic.Add(50001, new WorkPoint(1) { LogicID = 50001, PLCOrder = 1 });
            all_pt_logic.Add(50002, new WorkPoint(2) { LogicID = 50002, PLCOrder = 1 });
            all_pt_logic.Add(50006, new CheckPoint(5) { LogicID = 50006, PLCOrder = 1 });

            all_pt_logic.Add(200, new NormalPoint() { LogicID = 200 });
            all_pt_logic.Add(251, new NormalPoint() { LogicID = 251 });

            for (ushort i = 1; i <= MAX_PROD; i++)
            {
                all_pt_logic.Add((ushort)(200 + i), new TurnPoint() { LogicID = (ushort)(200 + i) });
                all_pt_logic.Add((ushort)(2000 + i), new ProductPoint()
                {
                    ProductID = (byte)i,
                    IsTakePoint = false,
                    LogicID = (ushort)(2000 + i)
                });
            }
        }
    }
}
