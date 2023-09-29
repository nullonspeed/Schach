using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : Piece
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w Q";
            }
            else
            {
                return "b Q";
            }
        }
        public override bool CanMove(string targetDestination)
        {
            int currentPositionNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(targetDestination[1].ToString());

            char currentPositionLetter = currentPosition[0];
            char targetDestinationLetter = targetDestination[0];

            int numberDifference = currentPositionNumber - targetDestinationNumber;
            int letterDifference = currentPositionLetter - targetDestinationLetter;

            numberDifference = (numberDifference < 0) ? numberDifference * -1 : numberDifference;
            letterDifference = (letterDifference < 0) ? letterDifference * -1 : letterDifference;

            if (numberDifference == letterDifference)
            {
                return true;
            }
            else if (currentPositionNumber == targetDestinationNumber && currentPosition[0] != targetDestination[0])
            {

                return true;
            }
            else if (currentPositionNumber != targetDestinationNumber && currentPosition[0] == targetDestination[0])
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
        public override bool CanMoveToTargetPosition(string zug, List<Piece> pieces)
        {
            int currentPositionNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(zug[1].ToString());

            char currentPositionLetter = currentPosition[0];
            char targetDestinationLetter = zug[0];

            int numberDifference = currentPositionNumber - targetDestinationNumber;
            int letterDifference = currentPositionLetter - targetDestinationLetter;

            int counterForLetters = 0;
            int counterForNumbers = 0;

            int additionForNumbers = (numberDifference > 0) ? -1 : 1;

            int additionForLetters = (letterDifference > 0) ? -1 : 1;


            int differenceNumberCheck = (numberDifference < 0) ? numberDifference * -1 : numberDifference;
            int differenceLetterCheck = (letterDifference < 0) ? letterDifference * -1 : letterDifference;

            if (numberDifference == letterDifference)
            {
                return true;
            }
            if (currentPositionNumber == targetDestinationNumber && currentPosition[0] != zug[0])
            {


                for (char letter = currentPosition[0]; letter < zug[0]; letter++)
                {
                    if (pieces.Find(d => d.currentPosition == letter + currentPositionNumber.ToString()) != null)
                    {
                        Console.WriteLine("turn not possible, please make a new input");
                        Console.ReadLine();
                        return false;
                    }
                }




                return true;
            }
            else if (currentPositionNumber != targetDestinationNumber && currentPosition[0] == zug[0])
            {

                for (int i = currentPositionNumber + 1; i < targetDestinationNumber; i++)
                {
                    if (pieces.Find(d => d.currentPosition == zug[0] + i.ToString()) != null)
                    {
                        Console.WriteLine("turn not possible, please make a new input");
                        Console.ReadLine();
                        return false;
                    }

                }
                return true;

            }
            else if(differenceNumberCheck== differenceLetterCheck)
            {
                while (true)
                {

                    counterForNumbers = counterForNumbers + additionForLetters;
                    counterForLetters = counterForLetters + additionForNumbers;
                    if (counterForNumbers == numberDifference && counterForLetters == letterDifference)
                    {
                        
                        break;
                    }
                    int nb = currentPositionNumber + counterForLetters;
                    char pl = (char)(currentPosition[0] + counterForNumbers);

                    if (pieces.Find(d => d.currentPosition == pl.ToString() + nb) != null)
                    {
                        Console.WriteLine("turn not possible, please make a new input");
                        Console.ReadLine();
                        return false;
                    }



                }
                return true;
            }
            else
            {
                Console.WriteLine("turn not possible, please make a new input");
                Console.ReadLine();
                return false;
            }
           

           
                }
    }
}
