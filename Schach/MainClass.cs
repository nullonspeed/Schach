using Chess;

ChessBord chessBoard = new ChessBord();


Console.SetWindowSize(80, 40);
bool end = false;
chessBoard.GeneratePieces();
bool whitesTurn=true;

while (!end)
{
    if (chessBoard.chessPieces.Find(d=>d.ToString() == "w K")==null)
    {
        Console.Clear();
        Console.WriteLine("Black won");
        Console.ReadLine();
        break;
    }
    if (chessBoard.chessPieces.Find(d => d.ToString() == "b K") == null)
    {
        Console.Clear();
        Console.WriteLine("White won");
        Console.ReadLine();
        break;
    }
    Console.Clear();
    chessBoard.DrawPlainField();
    chessBoard.drawFigures();
    Console.SetCursorPosition(0, 35);

    if(whitesTurn){
        Console.WriteLine("White:");
        Console.WriteLine("Please make your turn:");

    }
    else {
        Console.WriteLine("Black:");
        Console.WriteLine("Please make your turn:");
    }
    string Turn = Console.ReadLine();
    if (Turn.ToLower().Equals(("end")))
    {
        end = true;
        break;
    }


    bool movePossible = chessBoard.MoveChessPiece(Turn, whitesTurn);
    if (!movePossible)
    {

        continue;
    }

    whitesTurn = (whitesTurn) ? false : true;

}


