using System;
using System.Collections.Generic;
using System.Text;

namespace Experiment_DSAL_assignment_1.Classes
{
    class UndoActionLog
    {
        ActionNode _start;
        ActionNode _current;
        public UndoActionLog() 
        {
            _start = null;
            _current = null;
        }

        public ActionNode Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public ActionNode Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public void RecordAction(int row, int col, bool isBook)
        {
            ActionNode newAction = new ActionNode() { Col = col, Row = row, IsBook = isBook};
            if (_start == null)
            {
                _start = newAction;
                _current = newAction;
                return;
            }
            ActionNode p = _start;
            while (p.Next != null)
            {
                p = p.Next;
            }//End of while
            p.Next = newAction;
            newAction.Prev = p;
            _current = newAction;
        }

        public ActionNode ReturnPrev()
        {
            if (_current == null)
            {
                _current = _start;
                return _current;
            }

            _current = _current.Prev;
            if(_current == null)
            {
                return _start;
            }
            return _current.Next;
            
        }
    }
}
