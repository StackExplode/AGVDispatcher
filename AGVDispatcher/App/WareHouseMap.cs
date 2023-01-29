using AGVDispatcher.Entity;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using System.Linq;

namespace AGVDispatcher.App
{
    public abstract class WareHouseMap
    {
        public virtual int MAX_PROD => 33;
        public virtual int MAX_BREAK => 3;
        private ReaderWriterLockSlim prod_lock = new ReaderWriterLockSlim();
        private SpinLock break_lock = new SpinLock();

        public virtual BreakZonePoint BKEnterPoint => (BreakZonePoint)this[3];

        protected Dictionary<ushort, IPoint> all_pt_logic;
        protected Dictionary<ushort, IPoint> all_pt_physic;

        public WareHouseMap()
        {
            all_pt_logic = new Dictionary<ushort, IPoint>();
            all_pt_physic = new Dictionary<ushort, IPoint>();
            InitPoints();

        }

        public void GeneratePHYIndex()
        {
            all_pt_physic.Clear();
            foreach (var x in all_pt_logic)
            {
                all_pt_physic.Add(x.Value.PhysicID, x.Value);
            }
        }

        protected virtual void InitPoints()
        {
            all_pt_logic.Clear();
            for (ushort i = 0; i < MAX_BREAK; i++)
                all_pt_logic.Add((ushort)(i + 1), new BreakZonePoint()
                {
                    Order = (byte)(MAX_BREAK - i),
                    LogicID = i
                });

            all_pt_logic.Add(103, new TurnPoint() { LogicID = 103 });
            all_pt_logic.Add(102, new TurnPoint() { LogicID = 102 });
            all_pt_logic.Add(101, new TurnPoint() { LogicID = 101 });
            all_pt_logic.Add(106, new TurnPoint() { LogicID = 106 });

            for (ushort i = 1; i <= MAX_PROD; i++)
                all_pt_logic.Add((ushort)(1000 + i), new ProductPoint()
                {
                    ProductID = (byte)i,
                    IsTakePoint = true,
                    LogicID = (ushort)(1000 + i)
                });

            all_pt_logic.Add(5001, new WorkPoint() { LogicID = 5001, PLCOrder = 1 });
            all_pt_logic.Add(5002, new WorkPoint() { LogicID = 5002, PLCOrder = 2 });
            all_pt_logic.Add(5006, new WorkPoint() { LogicID = 5006, PLCOrder = 3 });

            for (ushort i = 1; i <= MAX_PROD; i++)
            {
                all_pt_logic.Add((ushort)(2000 + i), new ProductPoint()
                {
                    ProductID = (byte)i,
                    IsTakePoint = false,
                    LogicID = (ushort)(2000 + i)
                });
            }      
        }

        public void ResetMapState()
        {
            prod_lock.EnterWriteLock();
            _prod_av = 1;
            _break_av = 0;
            prod_lock.ExitWriteLock();
        }

        private int _prod_av = 1;

        public int LastAvilableProduct
        {
            get
            {
                prod_lock.EnterReadLock();
                int rt = _prod_av;
                prod_lock.ExitReadLock();
                return rt;
            }
        }

        public int PickLastestProduct()
        {
            prod_lock.EnterWriteLock();
            for (; _prod_av <= MAX_PROD; _prod_av++)
            {
                ProductPoint pt = GetPickProductPoint(_prod_av);
                if (pt.IsAvailable)
                {
                    break;
                }
            }
            if (_prod_av > MAX_PROD)
                _prod_av = -1;
            prod_lock.ExitWriteLock();
            return _prod_av;
        }

        private int _break_av = 0;

        public BreakZonePoint GetLastBreakZonePoint()
        {
            bool ll = false;
            break_lock.Enter(ref ll);
            _break_av++;
            var pt = this[(ushort)_break_av];
            break_lock.Exit();
            return (BreakZonePoint)pt;
        }

        public virtual (TurnPoint, TurnType) PickProductTurnWay(int prod)
        {
            if (prod >= 28 && prod <= 33)
                return ((TurnPoint)this[103], TurnType.LeftTurn);
            else if (prod >= 19 && prod <= 27)
                return ((TurnPoint)this[102], TurnType.LeftTurn);
            else if (prod >= 10 && prod <= 18)
                return ((TurnPoint)this[101], TurnType.LeftTurn);
            else
                return ((TurnPoint)this[101], TurnType.NoChange);
        }

        public virtual (TurnPoint, TurnType) PutProductTurnWay(int prod)
        {
            if (prod >= 1 && prod <= 20)
                return ((TurnPoint)this[106], TurnType.RightTurn);
            else
                return ((TurnPoint)this[106], TurnType.NoChange);
        }

        public WorkPoint GetWorkStationPoint(int index)
        {
            switch (index)
            {
                case 1: return (WorkPoint)this[50001];
                case 2: return (WorkPoint)this[50002];
                case 3: return (WorkPoint)this[50006];
            }

            return null;
        }

        public ProductPoint GetPickProductPoint(int prod)
        {
            return (ProductPoint)this[(ushort)(1000 + prod)];
        }

        public ProductPoint GetPutProductPoint(int prod)
        {
            return (ProductPoint)this[(ushort)(2000 + prod)];
        }

        public virtual IPoint this[ushort id, bool isphy = false]
        {
            get
            {
                if (isphy)
                {
                    var query = from r in all_pt_logic where r.Value.PhysicID == id select r.Value;
                    return (query?.First());
                    //return all_pt_physic[id];
                }
                else
                    return all_pt_logic[id];
            }
        }

        public void SaveToFile(string fname)
        {
            XmlSerializer writer = new XmlSerializer(all_pt_logic.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            System.IO.FileStream file = System.IO.File.Create(fname);

            writer.Serialize(file, this, ns);
            file.Close();
        }

        public void LoadFromFile(string fname)
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(all_pt_logic.GetType());

            System.IO.StreamReader file = new System.IO.StreamReader(fname);

            Dictionary<ushort, IPoint> dic = (Dictionary<ushort, IPoint>)reader.Deserialize(file);
            file.Close();

            foreach (var d in dic)
            {
                all_pt_logic[d.Value.LogicID].CopyFrom(d.Value);
            }
        }
    }
}