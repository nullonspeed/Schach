using Schach;

Spielfeld spielfeld = new Spielfeld();


Console.SetWindowSize(80, 40);
bool end = false;
spielfeld.GeneratePieces();
bool whitesTurn=true;

while (!end)
{
    if (spielfeld.Spielfiguren.Find(d=>d.ToString() == "w K")==null)
    {
        Console.Clear();
        Console.WriteLine("Schwarz hat gewonnen");
        Console.ReadLine();
        break;
    }
    if (spielfeld.Spielfiguren.Find(d => d.ToString() == "s K") == null)
    {
        Console.Clear();
        Console.WriteLine("Weiß hat gewonnen");
        Console.ReadLine();
        break;
    }
    Console.Clear();
    spielfeld.DrawPlainField();
    spielfeld.drawFigures();
    Console.SetCursorPosition(0, 35);

    if(whitesTurn){
        Console.WriteLine("White:");
        Console.WriteLine("Geben sie ihren zug ein:");

    }
    else {
        Console.WriteLine("Schwarz:");
        Console.WriteLine("Geben sie ihren zug ein:");
    }
    string Turn = Console.ReadLine();
    if (Turn.ToLower().Equals(("end")))
    {
        end = true;
        break;
    }


    bool movePossible = spielfeld.MoveChessPiece(Turn, whitesTurn);
    if (!movePossible)
    {

        continue;
    }

    whitesTurn = (whitesTurn) ? false : true;

}


