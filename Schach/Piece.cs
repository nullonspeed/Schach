using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Piece
    {
        public bool isWhite { get; set; }

        public string currentPosition { get; set; }

        public abstract override string ToString();

        public abstract bool CanMove(string destinationString);

        public abstract bool CanMoveToTargetPosition(string destinationString, List<Piece> pieces);

        

    }
}
