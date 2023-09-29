using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
     class Spielfeld
    {
        public List<Spielfigur> Spielfiguren { get; set; }= new List<Spielfigur>();
        public void DrawPlainField()
        {

           
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("      a     b     c     d     e     f     g     h   ");
            Console.BackgroundColor = ConsoleColor.Black;
            int tempColour = 0;
            int number = 8;
            ConsoleColor color = ConsoleColor.White;
            int tempcol = 0;
            for (int s = 0; s < 33; s++)
            {
                if (tempColour == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("   ");
                    for (int i = 0; i < 49; i++)
                    {
                        Console.Write("0");
                    }
                    tempColour++;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    if (tempColour == 2)
                    {
                        Console.Write(number + "  ");
                        number--;
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
                        color = (tempcol == 0) ? ConsoleColor.Black : ConsoleColor.White;
                        tempcol = (tempcol == 0) ? 1 : 0;
                    }
                    Console.Write("0");
                    if (tempColour == 3)
                    {
                        color = (tempcol == 0) ? ConsoleColor.Black : ConsoleColor.White;
                        tempcol = (tempcol == 0) ? 1 : 0;
                        tempColour = 0;
                    }
                    else
                    {
                        tempColour++;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
      public void drawFigures()
        {
           

            foreach (Spielfigur sp in Spielfiguren)
            {
                char[] a = sp.place.ToCharArray();

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
                    Console.WriteLine("Wrong Letter" + letter);
                    break;
            }

            return new Position { letter = temp, number = tempn };
        }
       public Spielfigur getFigure(String Turn, List<Spielfigur> pieces)
        {
            char[] turns = Turn.ToCharArray();
            string figure = turns[0].ToString() + turns[1].ToString();
            Spielfigur figur = pieces.Find(i => i.place.ToLower().Equals(figure.ToLower()));

            return figur;
        }
        public bool MoveChessPiece(string Turn, bool whitesTurn)
        {
            Zug turn = new Zug();
            bool correctTurn = turn.CheckTurn(Turn);
            if (!correctTurn)
            {
               
                return false;
            }



            Spielfigur current = getFigure(Turn, Spielfiguren);
            if (current == null)
            {
                Console.WriteLine("an dieser Stelle steht keine Spielfigur, bitte erneut eingeben");
                Console.ReadLine();
                return false;
            }
            if (whitesTurn != current.isWhite)
            {
                Console.WriteLine("Spielfigur vom Falschen team ausgewählt bitte erneut eingeben, bitte erneut eingeben");
                Console.ReadLine();
                return false;
            }


            string zug = Turn[3].ToString() + Turn[4].ToString();
            bool canMove = current.CanMove(zug);
            if (!canMove)
            {
                return false;
            }
            canMove = current.CanMoveToTargetPosition(zug, Spielfiguren);
            if (!canMove)
            {

                return false;
            }
            else
            {
                Spielfigur toDeletePiece = Spielfiguren.Find(d => d.place == zug);
                if (toDeletePiece != null && toDeletePiece.isWhite != whitesTurn)
                {
                    Spielfiguren.Remove(toDeletePiece);
                }
                else if (toDeletePiece != null && toDeletePiece.isWhite == whitesTurn)
                {
                    Console.WriteLine("mann kann keine eigenen Figuren schmeißen, bitte erneut eingeben");
                    Console.ReadLine();
                    return false;
                }

                Spielfiguren.Find(d => d.place == current.place).place = zug;
            }
            return true;
        }

       public void GeneratePieces()
        {
            int place;
            int placeBauer;
            string koenig;
            string dame;


            for (int farbe = 0; farbe < 2; farbe++)
            {

                place = (farbe == 0) ? 1 : 8;
                placeBauer = (farbe == 0) ? 2 : 7;
                dame = (farbe == 0) ? "d" : "e";
                koenig = (farbe == 0) ? "e" : "d";



                Spielfiguren.Add(new Bauer { isWhite = farbe == 0, place = $"a{placeBauer}" });
                Spielfiguren.Add(new Bauer { isWhite = farbe == 0, place = $"b{placeBauer}" });
                Spielfiguren.Add(new Bauer { isWhite = farbe == 0, place = $"c{placeBauer}" });
                Spielfiguren.Add(new Bauer { isWhite = farbe == 0, place = $"d{placeBauer}" });
                Spielfiguren.Add(new Bauer { isWhite = farbe == 0, place = $"e{placeBauer}" });
                Spielfiguren.Add(new Bauer { isWhite = farbe == 0, place = $"f{placeBauer}" });
                Spielfiguren.Add(new Bauer { isWhite = farbe == 0, place = $"g{placeBauer}" });
                Spielfiguren.Add(new Bauer { isWhite = farbe == 0, place = $"h{placeBauer}" });

                Spielfiguren.Add(new Dame       { isWhite = farbe == 0, place = $"{dame}{place}" });
                Spielfiguren.Add(new Koenig     { isWhite = farbe == 0, place = $"{koenig}{place}" });
                Spielfiguren.Add(new Laeufer    { isWhite = farbe == 0, place = $"c{place}" });
                Spielfiguren.Add(new Laeufer    { isWhite = farbe == 0, place = $"f{place}" });
                Spielfiguren.Add(new Springer   { isWhite = farbe == 0, place = $"b{place}" });
                Spielfiguren.Add(new Springer   { isWhite = farbe == 0, place = $"g{place}" });
                Spielfiguren.Add(new Turm       { isWhite = farbe == 0, place = $"a{place}" });
                Spielfiguren.Add(new Turm       { isWhite = farbe == 0, place = $"h{place}" });



            }

        }

    }


}
