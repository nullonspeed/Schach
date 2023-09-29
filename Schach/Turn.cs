using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Turn
    {

        public bool CheckTurn(string turnString)
        {
            if (turnString.ToCharArray().Length == 5)
            {
                char[]cuted = turnString.ToCharArray();
                if (Int32.TryParse(cuted[1].ToString(), out int s) && Int32.TryParse(cuted[4].ToString(), out int s1) && cuted[2].ToString().Equals("-") && "abcdefgh".Contains(cuted[0].ToString()) && "abcdefgh".Contains(cuted[3].ToString()))
                {
                    if(s > 0 && s1 >0 && s1<9&&s<9)
                    {
                        return true;

                    }
                    else
                    {
                        Console.WriteLine("your input has the wrong format, please make a new one");
                        Console.ReadLine();
                        return false;
                    }


                    

                }
                else {

                    Console.WriteLine("Die Eingabe ist nicht im richtigen format, bitte enter drücken und dann erneut eingeben");
                    Console.ReadLine();
                    return false; 
                }

            }
            else
            {
                Console.WriteLine("Die Eingabe ist nicht im richtigen format, bitte enter drücken und dann erneut eingeben");
                Console.ReadLine();
                return false;
            }

        }
    }
}
