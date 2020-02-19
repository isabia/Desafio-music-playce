using System;
using System.Text;

namespace PokerApp
{
    class DenenhaCartas
    {
        public static void DrawCartaOutline(int xcoor, int ycoor)
        {
            Console.ForegroundColor = ConsoleColor.White;

            int x = xcoor * 12;
            int y = ycoor;

            Console.SetCursorPosition(x, y);
            Console.Write(" __________\n"); 

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);

                if (i != 9)
                    Console.WriteLine("|          |");
                else
                    Console.WriteLine("|__________|");//bottom edge of the Carta
            }
        }

        
        public static void DrawCartaNaipeValue(Carta Carta, int xcoor, int ycoor)
        {
            char CartaNaipe = ' ';
            int x = xcoor * 12;
            int y = ycoor;

            switch (Carta.NaipeUsado)
            {
                case Carta.Naipe.C:
                    CartaNaipe = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Carta.Naipe.O:
                    CartaNaipe = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Carta.Naipe.P:
                    CartaNaipe = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Carta.Naipe.E:
                    CartaNaipe = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

           
            Console.SetCursorPosition(x + 5, y + 5);
            Console.Write(CartaNaipe);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(Carta.ValorUsado);

        }
    }
}
