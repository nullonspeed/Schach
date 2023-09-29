using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
     class ChessBord
    {
        public List<Piece> chessPieces { get; set; }= new List<Piece>();
        public void DrawPlainField()
        {

           
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("      a     b     c     d     e     f     g     h   ");
            Console.BackgroundColor = ConsoleColor.Black;
            int counterForRows = 0;
            int counterForRowNumbers = 8;
            ConsoleColor color = ConsoleColor.White;
            int counterForColourChange = 0;
            for (int s = 0; s < 33; s++)
            {
                if (counterForRows == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("   ");
                    for (int i = 0; i < 49; i++)
                    {
                        Console.Write("0");
                    }
                    counterForRows++;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    if (counterForRows == 2)
                    {
                        Console.Write(counterForRowNumbers + "  ");
                        counterForRowNumbers--;
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("0");
                        Console.BackgroundColor = color;
                        Console.Write("     ");
                        Console.BackgroundColor = ConsoleColor.Gray;
                        color = (counterForColourChange == 0) ? ConsoleColor.Black : ConsoleColor.White;
                        counterForColourChange = (counterForColourChange == 0) ? 1 : 0;
                    }
                    Console.Write("0");
                    if (counterForRows == 3)
                    {
                        color = (counterForColourChange == 0) ? ConsoleColor.Black : ConsoleColor.White;
                        counterForColourChange = (counterForColourChange == 0) ? 1 : 0;
                        counterForRows = 0;
                    }
                    else
                    {
                        counterForRows++;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
      public void drawFigures()
        {
           

            foreach (Piece sp in chessPieces)
            {
                char[] a = sp.currentPosition.ToCharArray();

                Position pos = getPosition(a[0].ToString(), a[1].ToString());
                Console.SetCursorPosition(pos.letter, pos.number);
                Console.Write(sp.ToString());

            }
          


        }
        Position getPosition(string letter, string number)
        {
            int temp = 0;
            int tempn = -1;
            switch (letter)
            {
                case "a":
                    temp = temp + 5;
                    break;
                case "b":
                    temp = temp + 11;
                    break;
                case "c":
                    temp = temp + 17;
                    break;
                case "d":
                    temp = temp + 23;
                    break;
                case "e":
                    temp = temp + 29;
                    break;
                case "f":
                    temp = temp + 35;
                    break;
                case "g":
                    temp = temp + 41;
                    break;
                case "h":
                    temp = temp + 47;
                    break;
                default:
                    Console.WriteLine("Wrong Letter" + letter);
                    break;
            }
            switch (number)
            {
                case "8":
                    tempn = tempn + 4;
                    break;
                case "7":
                    tempn = tempn + 8;
                    break;
                case "6":
                    tempn = tempn + 12;
                    break;
                case "5":
                    tempn = tempn + 16;
                    break;
                case "4":
                    tempn = tempn + 20;
                    break;
                case "3":
                    tempn = tempn + 24;
                    break;
                case "2":
                    tempn = tempn + 28;
                    break;
                case "1":
                    tempn = tempn + 32;
                    break;
                default:
                    Console.WriteLine("Wrong Number" + number);
                    break;
            }

            return new Position { letter = temp, number = tempn };
        }
       public Piece getFigure(String Turn, List<Piece> pieces)
        {
            char[] destinationChar = Turn.ToCharArray();
            string destinationPositionString = destinationChar[0].ToString() + destinationChar[1].ToString();
            Piece piece = pieces.Find(i => i.currentPosition.ToLower().Equals(destinationPositionString.ToLower()));

            return piece;
        }
        public bool MoveChessPiece(string Turn, bool whitesTurn)
        {
            Turn currentTurn = new Turn();
            bool isTurnCorrect = currentTurn.CheckTurn(Turn);
            if (!isTurnCorrect)
            {
               
                return false;
            }



            Piece currentPiece = getFigure(Turn, chessPieces);
            if (currentPiece == null)
            {
                Console.WriteLine("no Piece on this Position, Please write a new input");
                Console.ReadLine();
                return false;
            }
            if (whitesTurn != currentPiece.isWhite)
            {
                Console.WriteLine("The Piece is part of the opponent team, Please write a new input");
                Console.ReadLine();
                return false;
            }


            string targetDestination = Turn[3].ToString() + Turn[4].ToString();
            bool canMove = currentPiece.CanMove(targetDestination);
            if (!canMove)
            {
                return false;
            }
            canMove = currentPiece.CanMoveToTargetPosition(targetDestination, chessPieces);
            if (!canMove)
            {

                return false;
            }
            else
            {
                Piece possiblePieceToCapture = chessPieces.Find(d => d.currentPosition == targetDestination);
                if (possiblePieceToCapture != null && possiblePieceToCapture.isWhite != whitesTurn)
                {
                    chessPieces.Remove(possiblePieceToCapture);
                }
                else if (possiblePieceToCapture != null && possiblePieceToCapture.isWhite == whitesTurn)
                {
                    Console.WriteLine("you cant capture your own pieces, Please write a new input");
                    Console.ReadLine();
                    return false;
                }

                chessPieces.Find(d => d.currentPosition == currentPiece.currentPosition).currentPosition = targetDestination;
            }
            return true;
        }

       public void GeneratePieces()
        {
            int place;
            int placeBauer;
            string king;
            string queen;


            for (int colour = 0; colour < 2; colour++)
            {

                place = (colour == 0) ? 1 : 8;
                placeBauer = (colour == 0) ? 2 : 7;
                queen = (colour == 0) ? "d" : "e";
                king = (colour == 0) ? "e" : "d";



                chessPieces.Add(new Pawn { isWhite = colour == 0, currentPosition = $"a{placeBauer}" });
                chessPieces.Add(new Pawn { isWhite = colour == 0, currentPosition = $"b{placeBauer}" });
                chessPieces.Add(new Pawn { isWhite = colour == 0, currentPosition = $"c{placeBauer}" });
                chessPieces.Add(new Pawn { isWhite = colour == 0, currentPosition = $"d{placeBauer}" });
                chessPieces.Add(new Pawn { isWhite = colour == 0, currentPosition = $"e{placeBauer}" });
                chessPieces.Add(new Pawn { isWhite = colour == 0, currentPosition = $"f{placeBauer}" });
                chessPieces.Add(new Pawn { isWhite = colour == 0, currentPosition = $"g{placeBauer}" });
                chessPieces.Add(new Pawn { isWhite = colour == 0, currentPosition = $"h{placeBauer}" });

                chessPieces.Add(new Queen       { isWhite = colour == 0, currentPosition = $"{queen}{place}" });
                chessPieces.Add(new King     { isWhite = colour == 0, currentPosition = $"{king}{place}" });
                chessPieces.Add(new Bishop    { isWhite = colour == 0, currentPosition = $"c{place}" });
                chessPieces.Add(new Bishop    { isWhite = colour == 0, currentPosition = $"f{place}" });
                chessPieces.Add(new Knight   { isWhite = colour == 0, currentPosition = $"b{place}" });
                chessPieces.Add(new Knight   { isWhite = colour == 0, currentPosition = $"g{place}" });
                chessPieces.Add(new Rook       { isWhite = colour == 0, currentPosition = $"a{place}" });
                chessPieces.Add(new Rook       { isWhite = colour == 0, currentPosition = $"h{place}" });



            }

        }

    }


}
