using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGVDispatcher.App
{
    public class WareHouseMapv2 : WareHouseMap
    {
        public override BreakZonePoint BKEnterPoint => (BreakZonePoint)this[4];
        public override int MAX_PROD => 20;
        public override int MAX_BREAK => 4;

        public override (TurnPoint, TurnType) GetPickProductTurnWay(int prod)
        {
            Contract.Ensures(prod >= 1 && prod <= MAX_PROD);
            //return ((TurnPoint)this[(ushort)(100 + prod)], TurnType.RightTurn);
            if(prod <= 10)
                return ((TurnPoint)this[(ushort)(100 + prod)], TurnType.RightTurn);
            else
                return ((TurnPoint)this[(ushort)(100 + prod + 1)], TurnType.RightTurn);
        }

        public override (TurnPoint, TurnType) GetPutProductTurnWay(int prod)
        {
            Contract.Requires(prod >= 1 && prod <= MAX_PROD);
            //if(prod == 6)
            //    return ((TurnPoint)this[206], TurnType.NoChange);
            //else
            return ((TurnPoint)this[(ushort)(200 + prod)], TurnType.RightTurn);
        }

       

        public NormalPoint PickWaitPoint => (NormalPoint)this[111];

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

        public bool IsPutProdctSpecial([Pure]int productid)
        {
            return false;
            if (productid >= 1 && productid <= 5)
                return true;
            else
                return false;
        }

        public NormalPoint PutWaitPoint => (NormalPoint)this[250];
        public NormalPoint BreakWaitPoint => (NormalPoint)this[251];

        protected override void InitPoints()
        {
            all_pt_logic.Clear();
            for (ushort i = 0; i < MAX_BREAK; i++)
                all_pt_logic.Add((ushort)(i + 1), new BreakZonePoint()
                {
                    Order = (byte)(i),
                    LogicID = (ushort)(i + 1)
                });

            all_pt_logic.Add(111, new NormalPoint() { LogicID = 111 });

            for(ushort i = 1; i <= MAX_PROD; i++)
            {
                if(i <= 10)
                    all_pt_logic.Add((ushort)(100 + i), new TurnPoint() { LogicID = (ushort)(100 + i) });
                else
                    all_pt_logic.Add((ushort)(100 + i + 1), new TurnPoint() { LogicID = (ushort)(100 + i + 1) });
                all_pt_logic.Add((ushort)(1000 + i), new ProductPoint()
                {
                    ProductID = (byte)i,
                    IsTakePoint = true,
                    LogicID = (ushort)(1000 + i)
                });
            }

            all_pt_logic.Add(301, new WorkPoint(1) { LogicID = 301, PLCOrder = 1 });
            all_pt_logic.Add(302, new WorkPoint(2) { LogicID = 302, PLCOrder = 1 });
            all_pt_logic.Add(306, new CheckPoint(5) { LogicID = 306, PLCOrder = 1 });

            all_pt_logic.Add(250, new NormalPoint() { LogicID = 250 });
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
