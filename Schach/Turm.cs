using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
     class Turm:Spielfigur
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w T";
            }
            else
            {
                return "s T";
            }
        }
        public override bool CanMove(string zug)
        {
            int placeNumber = Int32.Parse(place[1].ToString());
            int turnNumber = Int32.Parse(zug[1].ToString());


            if (placeNumber == turnNumber && place[0] != zug[0])
            {
              
                return true;
            }
            else if (placeNumber != turnNumber && place[0] == zug[0])
            {
                
                return true;

            }
            else {
                Console.WriteLine("falscher zug, erneut eingeben");
                Console.ReadLine();
                return false; 
            }



        }
        public override bool CanMoveToTargetPosition(string zug, List<Spielfigur> figuren)
        {
            int placeNumber = Int32.Parse(place[1].ToString());
            int turnNumber = Int32.Parse(zug[1].ToString());

            if (placeNumber == turnNumber && place[0] != zug[0])
            {


                for (char letter = place[0]; letter < zug[0]; letter++)
                {
                    if (figuren.Find(d => d.place == letter + placeNumber.ToString()) != null)
                    {
                        Console.WriteLine("zug nicht möglich, bitte erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }
                }
               
                 

                
                return true;
            }
            else if (placeNumber != turnNumber && place[0] == zug[0])
            {

                for (int i = placeNumber + 1; i < turnNumber; i++)
                {
                    if (figuren.Find(d => d.place == zug[0] + i.ToString()) != null)
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
                Console.WriteLine("something wrent wrong, bitte neu eingeben");
                Console.ReadLine();
                return false;
            }

           
        }
    }
}
