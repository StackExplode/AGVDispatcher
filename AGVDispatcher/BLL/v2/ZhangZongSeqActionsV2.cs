using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.BLL.v2
{
    public class ZhangZongSeqActionsV2 : IQueuedActions
    {
        public Queue<IAGVAction> ActionQueue { get; init; }

        public ZhangZongSeqActionsV2()
        {
            ActionQueue = new Queue<IAGVAction>();
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_BreakTo150());
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_WaitForPick());
            ActionQueue.Enqueue(new Action_Pick());
            ActionQueue.Enqueue(new Action_PickBackDelCache());
            ActionQueue.Enqueue(new Action_BackwardAfterPick());
            ActionQueue.Enqueue(new Action_RunTo1stPLC());
            ActionQueue.Enqueue(new Action_ClearCache());
#if !DEBUG
#error Change it!
#endif
            ActionQueue.Enqueue(new Action_CallPLCWork(1));
            ActionQueue.Enqueue(new Action_RunTo2ndPLC());
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_CallPLCWork(2));
            ActionQueue.Enqueue(new Action_RunTo3rdPLC());
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_CallPLCWork(5));
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_RunTo200());
            ActionQueue.Enqueue(new Action_ClearCache());
            ActionQueue.Enqueue(new Action_WaitForPut());
            ActionQueue.Enqueue(new Action_Put());
            ActionQueue.Enqueue(new Action_PutBackDelCache());
            ActionQueue.Enqueue(new Action_BackwardAfterPut());
            //ActionQueue.Enqueue(new Action_RunTo251());
            //ActionQueue.Enqueue(new Action_WaitForBreak());
            //ActionQueue.Enqueue(new AGVDispatcher.BLL.v2.Action_RunToEnd());
            ActionQueue.Enqueue(new AGVDispatcher.BLL.v2.Action_RunToEnd_v3());
            ActionQueue.Enqueue(new Action_ClearCache());
        }
    }
}
