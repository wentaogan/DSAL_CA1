using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;

namespace Experiment_DSAL_assignment_1.Classes
{
    class SeatManager
    {
        private SeatList _seatList = new SeatList();
        public SeatManager()
        {

        }

        public SeatList SeatList
        {
            get { return _seatList;}
            set { _seatList = value; }
        }
        public void AddSeat(Seat pSeat)
        {
            _seatList.Add(pSeat);
        }// end of AddSeat
        public Seat Search (int pRow, int pCol)
        {
            return _seatList.Search(pRow, pCol);

        }

        
        public void SaveToFile()
        {
            string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/data.txt";
            TextWriter tw = new StreamWriter(filepath);
            Node seatNode = _seatList.Start;
            do
            {
                Seat seat = seatNode.Seat;
                tw.WriteLine($"{seat.status},{seat.RowNumber},{seat.ColumnNumber},{seat.IAmBooked},{seat.IAmBookedBy},{seat.Xcor},{seat.Ycor}");
                seatNode = seatNode.Next;
            }while(seatNode != null );
            tw.Close();
        }

        
        public void ReadFromFile()
        {

            string line = null;
            string filepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/data.txt";
            TextReader tr = new StreamReader(filepath);
            line = tr.ReadLine();
            do
            {
                string[] data = line.Split(",");
                Seat seat = new Seat()
                {
                    status = bool.Parse(data[0]),
                    RowNumber = int.Parse(data[1]),
                    ColumnNumber = int.Parse(data[2]),
                    IAmBooked = bool.Parse(data[3]),
                    IAmBookedBy = data[4],
                    Xcor = int.Parse(data[5]),
                    Ycor = int.Parse(data[6])
                };
                this.SeatList.Add(seat);
                line = tr.ReadLine();
            }while(line != null);
            tr.Close();
        }
        
    }
}
