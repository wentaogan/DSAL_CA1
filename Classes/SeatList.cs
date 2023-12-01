using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace Experiment_DSAL_assignment_1.Classes
{
    [Serializable]
    class SeatList
    {
        private Node _start;    //Every single Double Linked List class "usually" has one start variable
        public SeatList(){
            _start = null;
         }//Constructor

        public Node Start
        {
            get { return _start; }
            set { _start = value; } 
        }
        public void Add(Seat pSeat)
        {
            Node newNode = new Node(pSeat);
            if (_start == null)
            {
                _start = newNode;
                return; //End of processing, no point continue to structure the node
            }
            Node p = _start;

            //Traverse through the list until the p refers to
            //the last node.
            while (p.Next != null)
            {
                p = p.Next;
            }//End of while
            p.Next = newNode;
            newNode.Prev = p;
        }//end of InsertAtEnd
        public Seat Search(int pRow, int pCol)
        {
            if (_start == null) return null;
          
            Node p = _start;
            while (p != null)
            {
                if (p.Seat.RowNumber == pRow && p.Seat.ColumnNumber == pCol)
                {
                    return p.Seat;
                 
                }//End of if
                p = p.Next;
            }//End of while
            return null;
        }//End of Search




    }//end of SeatList
}//end of namespace
