using System;
using System.Collections.Generic;
using System.Text;

namespace Experiment_DSAL_assignment_1.Classes
{
    class ActionNode
    {
        private int _row;
        private int _col;
        private bool _isbook;
        ActionNode _prev;
        ActionNode _next;
        public ActionNode() 
        {

        }

        public ActionNode Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }

        public ActionNode Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public int Row
        {
            get { return _row; }    
            set { _row = value; }
        }

        public int Col
        {
            get { return _col; }
            set { _col = value; }
        }

        public bool IsBook
        {
            get { return _isbook; }
            set { _isbook = value; }
        }
    }
}
