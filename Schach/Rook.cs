using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
     class Rook:Piece
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w R";
            }
            else
            {
                return "b R";
            }
        }
        public override bool CanMove(string targetDestination)
        {
            int currentPositionNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(targetDestination[1].ToString());


            if (currentPositionNumber == targetDestinationNumber && currentPosition[0] != targetDestination[0])
            {
              
                return true;
            }
            else if (currentPositionNumber != targetDestinationNumber && currentPosition[0] == targetDestination[0])
            {
                
                return true;

            }
            else {
                Console.WriteLine("turn not possible, please make a new input");
                Console.ReadLine(); ;
                return false; 
            }



        }
        public override bool CanMoveToTargetPosition(string targetDestination, List<Piece> pieces)
        {
            int currentPositionNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(targetDestination[1].ToString());

            if (currentPositionNumber == targetDestinationNumber && currentPosition[0] != targetDestination[0])
            {


                for (char letter = currentPosition[0]; letter < targetDestination[0]; letter++)
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
            else if (currentPositionNumber != targetDestinationNumber && currentPosition[0] == targetDestination[0])
            {

                for (int i = currentPositionNumber + 1; i < targetDestinationNumber; i++)
                {
                    if (pieces.Find(d => d.currentPosition == targetDestination[0] + i.ToString()) != null)
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
                Console.WriteLine("something wrent wrong, please make a new input");
                Console.ReadLine();
                return false;
            }

           
        }
    }
}
