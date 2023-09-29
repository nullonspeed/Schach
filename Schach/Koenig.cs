using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
     class Koenig:Spielfigur
    {
        public override string ToString()
        {
            if (isWhite == true)
            {
                return "w K";
            }
            else
            {
                return "s K";
            }
        }
        public override bool CanMove(string zug)
        {
            int placeNumber = Int32.Parse(place[1].ToString());
            int turnNumber = Int32.Parse(zug[1].ToString());
            char placeAroundleft = (char)(place[0] - 1);
            char placeAroundright = (char)(place[0] + 1);

            if (placeNumber + 1 == turnNumber && zug[0] <= placeAroundright && zug[0] >= placeAroundleft)
            {
                return true;
            }
            else if (placeNumber  == turnNumber && zug[0] <= placeAroundright && zug[0] >= placeAroundleft)
            {
                return true;
            }
            else if (placeNumber-1 == turnNumber && zug[0] <= placeAroundright && zug[0] >= placeAroundleft)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool CanMoveToTargetPosition(string zug, List<Spielfigur> figuren)
        {
            return true;
        }

    }
}
