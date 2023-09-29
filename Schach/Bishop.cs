using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
     class Bishop:Piece
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w B";
            }
            else
            {
                return "b B";
            }
        }
        public override bool CanMove(string targetDestination)
        {
            int currentPositionNumber = Int32.Parse(currentPosition[1].ToString());
            int turnNumber = Int32.Parse(targetDestination[1].ToString());

            char placeL = currentPosition[0];
            char turnL = targetDestination[0];

            int diffNumber = currentPositionNumber - turnNumber;
            int diffLetter = placeL - turnL;

            diffNumber = (diffNumber < 0) ? diffNumber * -1 : diffNumber;
            diffLetter = (diffLetter < 0) ? diffLetter * -1 : diffLetter;

            if(diffNumber==diffLetter)
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

            int currentDestinationNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(targetDestination[1].ToString());

            char currentPositionLetter = currentPosition[0];
            char targetDestinationLetter = targetDestination[0];

            int differenceOfNumbers = currentDestinationNumber - targetDestinationNumber;
            int differenceOfLetters = currentPositionLetter - targetDestinationLetter;

            int letterCounter = 0;
            int numberCounter = 0;

            int additionNumber = (differenceOfNumbers > 0) ?  -1 : 1;

            int additionLetter = (differenceOfLetters > 0) ? -1 : 1;

            while (true)
            {
                
                numberCounter = numberCounter + additionLetter;
                letterCounter = letterCounter + additionNumber;
                if (numberCounter == differenceOfNumbers && letterCounter == differenceOfLetters)
                {
                    break;
                }
                int nb = currentDestinationNumber + letterCounter;
                char pl = (char)(currentPosition[0] + numberCounter);

                if (pieces.Find(d => d.currentPosition == pl.ToString()+nb) != null)
                {
                    Console.WriteLine("wrong turn, make a new input");
                    Console.ReadLine();
                    return false;
                } 
              
            }
            return true;        
        }
    }
}
