using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    class Dame : Spielfigur
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w D";
            }
            else
            {
                return "s D";
            }
        }
        public override bool CanMove(string zug)
        {
            int placeNumber = Int32.Parse(place[1].ToString());
            int turnNumber = Int32.Parse(zug[1].ToString());

            char placeL = place[0];
            char turnL = zug[0];

            int diffNumber = placeNumber - turnNumber;
            int diffLetter = placeL - turnL;

            diffNumber = (diffNumber < 0) ? diffNumber * -1 : diffNumber;
            diffLetter = (diffLetter < 0) ? diffLetter * -1 : diffLetter;

            if (diffNumber == diffLetter)
            {
                return true;
            }
            else if (placeNumber == turnNumber && place[0] != zug[0])
            {

                return true;
            }
            else if (placeNumber != turnNumber && place[0] == zug[0])
            {

                return true;

            }
            else
            {
                Console.WriteLine("zug nicht möglich, bitte erneut eingeben");
                Console.ReadLine();
                return false;
            }
        }
        public override bool CanMoveToTargetPosition(string zug, List<Spielfigur> figuren)
        {
            int placeNumber = Int32.Parse(place[1].ToString());
            int turnNumber = Int32.Parse(zug[1].ToString());

            char placeL = place[0];
            char turnL = zug[0];

            int diffNumber = placeNumber - turnNumber;
            int diffLetter = placeL - turnL;

            int letterNb = 0;
            int numberL = 0;

            int plusNumber = (diffNumber > 0) ? -1 : 1;

            int plusLetter = (diffLetter > 0) ? -1 : 1;


            int diffNumberCheck = (diffNumber < 0) ? diffNumber * -1 : diffNumber;
            int diffLetterCheck = (diffLetter < 0) ? diffLetter * -1 : diffLetter;

            if (diffNumber == diffLetter)
            {
                return true;
            }
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
            else if(diffNumberCheck== diffLetterCheck)
            {
                while (true)
                {

                    numberL = numberL + plusLetter;
                    letterNb = letterNb + plusNumber;
                    if (numberL == diffNumber && letterNb == diffLetter)
                    {
                        
                        break;
                    }
                    int nb = placeNumber + letterNb;
                    char pl = (char)(place[0] + numberL);

                    if (figuren.Find(d => d.place == pl.ToString() + nb) != null)
                    {
                        Console.WriteLine("falscher zug, erneut eingeben");
                        Console.ReadLine();
                        return false;
                    }



                }
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
}
