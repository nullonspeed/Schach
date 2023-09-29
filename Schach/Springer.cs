using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
     class Springer: Spielfigur
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w S";
            }
            else
            {
                return "s S";
            }
        }
        public override bool CanMove(string zug)
        {
            int placeNumber = Int32.Parse(place[1].ToString());
            int turnNumber = Int32.Parse(zug[1].ToString());
            char placeLetter = place[0];
            char turnLetter = zug[0];

            if (placeNumber + 2 == turnNumber && placeLetter + 1 == turnLetter)
            {
                return true;
            }
            else if (placeNumber + 2 == turnNumber && placeLetter - 1 == turnLetter)
            {
                return true;
            }
            else if (placeNumber - 2 == turnNumber && placeLetter + 1 == turnLetter)
            {
                return true;
            }
            else if (placeNumber - 2 == turnNumber && placeLetter - 1 == turnLetter)
            {
                return true;
            }
            else if (placeNumber + 1 == turnNumber && placeLetter + 2 == turnLetter)
            {
                return true;
            }
            else if (placeNumber + 1 == turnNumber && placeLetter - 2 == turnLetter)
            {
                return true;
            }
            else if (placeNumber - 1 == turnNumber && placeLetter + 2 == turnLetter)
            {
                return true;
            }
            else if (placeNumber - 1 == turnNumber && placeLetter - 2 == turnLetter)
            {
                return true;
            }
            else { return false; }
        }
        public override bool CanMoveToTargetPosition(string zug, List<Spielfigur> figuren)
        {
            return true;        }
    }
}
