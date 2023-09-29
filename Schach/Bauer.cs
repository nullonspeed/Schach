using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    class Bauer : Spielfigur
    {
        public override bool CanMove(string zug)
        {
            int placeNumber = Int32.Parse(place[1].ToString());
            int turnNumber = Int32.Parse(zug[1].ToString());
            

            if (isWhite==true)
            {
                if (place[0] != zug[0])
                {
                     if (turnNumber == placeNumber + 1 && zug[0] == place[0] + 1)
                    {
                        return true;

                    }
                    else if (turnNumber == placeNumber + 1 && zug[0] == place[0] - 1)
                    {
                        return true;

                    }
                    else
                    {
                        Console.WriteLine("falscher zug, erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }
                    
                }

                if (turnNumber==placeNumber+1)
                {

                    return true;
                }
                else if (turnNumber==placeNumber+2 && placeNumber==2)
                {
                    return true;
                }
                
                else {
                    Console.WriteLine("falscher zug, erneut eingeben");
                    Console.ReadLine();
                    return false; 
                }

            }
            else 
            {
                if (place[0] != zug[0])
                {
                     if (turnNumber == placeNumber - 1 && zug[0] == place[0] + 1)
                    {
                        return true;

                    }
                    else if (turnNumber == placeNumber - 1 && zug[0] == place[0] - 1)
                    {
                        return true;

                    }
                    else
                    {
                        Console.WriteLine("falscher zug, erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }

                }
                if (turnNumber == placeNumber - 1)
                {

                    return true;
                }
                else if (turnNumber == placeNumber - 2 && placeNumber == 7)
                {
                    return true;
                }
                
                else
                {
                    Console.WriteLine("falscher zug, erneut eingeben");
                    Console.ReadLine();
                    return false;
                }

            }

        }

        public override bool CanMoveToTargetPosition(string zug, List<Spielfigur> figuren)
        {
            int placeNumber = Int32.Parse(place[1].ToString());
            int turnNumber = Int32.Parse(zug[1].ToString());
            string letter = place[0].ToString();
            if (isWhite)
            {
                if (turnNumber == placeNumber + 1 && zug[0] == place[0] + 1)
                {
                    if(figuren.Find(d => d.place == zug) == null)
                    {
                        Console.WriteLine("zug nicht möglich, bitte erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                if (turnNumber == placeNumber + 1 && zug[0] == place[0] - 1)
                {
                    if (figuren.Find(d => d.place == zug) == null)
                    {
                        Console.WriteLine("zug nicht möglich, bitte erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                for (int i = placeNumber+1;i<=turnNumber;i++)
                {
                    if (figuren.Find(d=>d.place==letter+i.ToString())!=null)
                    {
                        Console.WriteLine("zug nicht möglich, bitte erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }
                  
                }
                return true;
            }
            else
            {
                if (turnNumber == placeNumber - 1 && zug[0] == place[0] + 1)
                {
                    if (figuren.Find(d => d.place == zug) == null)
                    {
                        Console.WriteLine("zug nicht möglich, bitte erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                if (turnNumber == placeNumber - 1 && zug[0] == place[0] - 1)
                {
                    if (figuren.Find(d => d.place == zug) == null)
                    {
                        Console.WriteLine("zug nicht möglich, bitte erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }
                    return true;
                }
                for (int i = placeNumber-1; i >= turnNumber; i--)
                {
                    if (figuren.Find(d => d.place == letter + i.ToString()) != null)
                    {
                        Console.WriteLine("zug nicht möglich, bitte erneut eingeben");
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
                return "w B";
            }
            else
            {
                return "s B";
            }
        }

        
    }
}
