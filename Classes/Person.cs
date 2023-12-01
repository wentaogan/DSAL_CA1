using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Experiment_DSAL_assignment_1.Classes
{
    class Person
    {
        private string _name = "";
        private Color _selectColor;
        private bool _isCurrent = false;
        private bool _isPass = false;
        private int _xcor = 0;
        private int _ycor = 0;
        private int _maxSeat = 0;


        public Person()
        {

        }

        public int MaxSeat
        {
            get { return _maxSeat; }
            set { _maxSeat = value; }
        }

        public int Xcor
        {
            get { return _xcor; }
            set { _xcor = value; }
        }

        public int Ycor
        {
            get { return _ycor; }
            set { _ycor = value; }
        }

        public bool IsPass
        {
            get { return _isPass; }
            set 
            { 
                if(value == true)
                {
                    _isPass = value;
                }
            }
        }

        public bool IsCurrent
        {
            get { return _isCurrent; }
            set { _isCurrent = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        public Color SelectColor
        {
            get { return _selectColor; }
            set
            {
                _selectColor = value;
            }
        }
    }
}
