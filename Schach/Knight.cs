using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
     class Knight: Piece
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "wKn";
            }
            else
            {
                return "bKn";
            }
        }
        public override bool CanMove(string targetDestination)
        {
            int currentPositionNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(targetDestination[1].ToString());
            char currentPositionLetter = currentPosition[0];
            char targetDestinationLetter = targetDestination[0];

            if (currentPositionNumber + 2 == targetDestinationNumber && currentPositionLetter + 1 == targetDestinationLetter)
            {
                return true;
            }
            else if (currentPositionNumber + 2 == targetDestinationNumber && currentPositionLetter - 1 == targetDestinationLetter)
            {
                return true;
            }
            else if (currentPositionNumber - 2 == targetDestinationNumber && currentPositionLetter + 1 == targetDestinationLetter)
            {
                return true;
            }
            else if (currentPositionNumber - 2 == targetDestinationNumber && currentPositionLetter - 1 == targetDestinationLetter)
            {
                return true;
            }
            else if (currentPositionNumber + 1 == targetDestinationNumber && currentPositionLetter + 2 == targetDestinationLetter)
            {
                return true;
            }
            else if (currentPositionNumber + 1 == targetDestinationNumber && currentPositionLetter - 2 == targetDestinationLetter)
            {
                return true;
            }
            else if (currentPositionNumber - 1 == targetDestinationNumber && currentPositionLetter + 2 == targetDestinationLetter)
            {
                return true;
            }
            else if (currentPositionNumber - 1 == targetDestinationNumber && currentPositionLetter - 2 == targetDestinationLetter)
            {
                return true;
            }
            else {
                Console.WriteLine("turn not possible, please make a new input");
                Console.ReadLine();
                return false;
            }
        }
        public override bool CanMoveToTargetPosition(string zug, List<Piece> figuren)
        {
            return true;        }
    }
}
