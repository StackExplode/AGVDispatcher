using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL
{
    public class ZhangZongSeqActions : IQueuedActions
    {
        public Queue<IAGVAction> ActionQueue { get; init; }
        public ZhangZongSeqActions()
        {
            ActionQueue = new Queue<IAGVAction>();
            ActionQueue.Enqueue(new Action_BreakeZoneTo1stPLC());
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_CallPLCWork(1));
            ActionQueue.Enqueue(new Action_RunTo2ndPLC());
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_CallPLCWork(2));
            ActionQueue.Enqueue(new Action_RunTo3rdPLC());
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_CallPLCWork(3));
            ActionQueue.Enqueue(new Action_RunToEnd());
            ActionQueue.Enqueue(new Action_ClearCache());
        }
    }

    public interface IQueuedActions
    {
        public Queue<IAGVAction> ActionQueue { get; }
    }
}
