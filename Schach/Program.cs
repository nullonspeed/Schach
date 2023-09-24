Console.Clear();
Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("      a     b     c     d     e     f     g     h   ");
Console.BackgroundColor = ConsoleColor.Black;
int tempColour = 0;
int number = 8;
ConsoleColor color = ConsoleColor.White;
int tempcol = 0;
for(int s=0; s< 33;s++) { 
   if(tempColour == 0)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Write("   ");
        for (int i = 0; i < 49; i++)
        {
            Console.Write("0");
        }
        tempColour  ++;
        Console.BackgroundColor = ConsoleColor.Black;
    }
    else 
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        if(tempColour==2){
            Console.Write(number + "  ");
            number--;
        }
        else
        {
            Console.Write("   ");
        }
        for(int j  = 0;j<8;j++)
        {
            Console.Write("0");
            Console.BackgroundColor = color;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.Gray;
            color = (tempcol == 0) ?  ConsoleColor.Black : ConsoleColor.White;
            tempcol = (tempcol == 0) ? 1 : 0;
        }     
        Console.Write("0");
        if(tempColour == 3)
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