using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : Piece
    {
        public override bool CanMove(string targetDestination)
        {
            int currentPositionNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(targetDestination[1].ToString());
            

            if (isWhite==true)
            {
                if (currentPosition[0] != targetDestination[0])
                {
                     if (targetDestinationNumber == currentPositionNumber + 1 && targetDestination[0] == currentPosition[0] + 1)
                    {
                        return true;

                    }
                    else if (targetDestinationNumber == currentPositionNumber + 1 && targetDestination[0] == currentPosition[0] - 1)
                    {
                        return true;

                    }
                    else
                    {
                        Console.WriteLine("wrong turn, make a new input");
                        Console.ReadLine();
                        return false;
                    }
                    
                }

                if (targetDestinationNumber==currentPositionNumber+1)
                {

                    return true;
                }
                else if (targetDestinationNumber==currentPositionNumber+2 && currentPositionNumber==2)
                {
                    return true;
                }
                
                else {
                    Console.WriteLine("wrong turn, make a new input");
                    Console.ReadLine();
                    return false; 
                }

            }
            else 
            {
                if (currentPosition[0] != targetDestination[0])
                {
                     if (targetDestinationNumber == currentPositionNumber - 1 && targetDestination[0] == currentPosition[0] + 1)
                    {
                        return true;

                    }
                    else if (targetDestinationNumber == currentPositionNumber - 1 && targetDestination[0] == currentPosition[0] - 1)
                    {
                        return true;

                    }
                    else
                    {
                        Console.WriteLine("wrong turn, make a new input");
                        Console.ReadLine();
                        return false;
                    }

                }
                if (targetDestinationNumber == currentPositionNumber - 1)
                {

                    return true;
                }
                else if (targetDestinationNumber == currentPositionNumber - 2 && currentPositionNumber == 7)
                {
                    return true;
                }
                
                else
                {
                    Console.WriteLine("wrong turn, make a new input");
                    Console.ReadLine();
                    return false;
                }

            }

        }

        public override bool CanMoveToTargetPosition(string targetDestination, List<Piece> pieces)
        {
            int currentPositionNumber = Int32.Parse(currentPosition[1].ToString());
            int targetDestinationNumber = Int32.Parse(targetDestination[1].ToString());
            string currentPositionLetter = currentPosition[0].ToString();
            if (isWhite)
            {
                if (targetDestinationNumber == currentPositionNumber + 1 && targetDestination[0] == currentPosition[0] + 1)
                {
                    if(pieces.Find(d => d.currentPosition == targetDestination) == null)
                    {
                        Console.WriteLine("turn not possible, please make a new input");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                if (targetDestinationNumber == currentPositionNumber + 1 && targetDestination[0] == currentPosition[0] - 1)
                {
                    if (pieces.Find(d => d.currentPosition == targetDestination) == null)
                    {
                        Console.WriteLine("turn not possible, please make a new input");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                for (int i = currentPositionNumber+1;i<=targetDestinationNumber;i++)
                {
                    if (pieces.Find(d=>d.currentPosition==currentPositionLetter+i.ToString())!=null)
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
                if (targetDestinationNumber == currentPositionNumber - 1 && targetDestination[0] == currentPosition[0] + 1)
                {
                    if (pieces.Find(d => d.currentPosition == targetDestination) == null)
                    {
                        Console.WriteLine("turn not possible, please make a new input");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                if (targetDestinationNumber == currentPositionNumber - 1 && targetDestination[0] == currentPosition[0] - 1)
                {
                    if (pieces.Find(d => d.currentPosition == targetDestination) == null)
                    {
                        Console.WriteLine("turn not possible, please make a new input");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                for (int i = currentPositionNumber-1; i >= targetDestinationNumber; i--)
                {
                    if (pieces.Find(d => d.currentPosition == currentPositionLetter + i.ToString()) != null)
                    {
                        Console.WriteLine("turn not possible, please make a new input");
                        Console.ReadLine();
                        return false;
                    }

                }
                return true;
            }
        }

        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w P";
            }
            else
            {
                return "b P";
            }
        }

        
    }
}
