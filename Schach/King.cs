using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
     class King:Piece
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w K";
            }
            else
            {
                return "b K";
            }
        }
        public override bool CanMove(string targetDestination)
        {
            int currentDestinationNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(targetDestination[1].ToString());
            char leftRange = (char)(currentPosition[0] - 1);
            char rightRange = (char)(currentPosition[0] + 1);

            if (currentDestinationNumber + 1 == targetDestinationNumber && targetDestination[0] <= rightRange && targetDestination[0] >= leftRange)
            {
                return true;
            }
            else if (currentDestinationNumber  == targetDestinationNumber && targetDestination[0] <= rightRange && targetDestination[0] >= leftRange)
            {
                return true;
            }
            else if (currentDestinationNumber-1 == targetDestinationNumber && targetDestination[0] <= rightRange && targetDestination[0] >= leftRange)
            {
                return true;
            }
            else
            {
                Console.WriteLine("turn not possible, please make a new input");
                Console.ReadLine();
                return false;
            }
        }
        public override bool CanMoveToTargetPosition(string targetDestination, List<Piece> pieces)
        {
            return true;
        }

    }
}
