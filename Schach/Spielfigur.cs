using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    public abstract class Spielfigur
    {
        public bool isWhite { get; set; }

        public string place { get; set; }

        public abstract override string ToString();

        public abstract bool CanMove(string zug);

        public abstract bool CanMoveToTargetPosition(string zug, List<Spielfigur> figuren);

        

    }
}
