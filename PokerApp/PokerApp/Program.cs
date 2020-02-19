using System;

namespace PokerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(65, 40);
           
            Console.Title = "Poker Game";
            GerenciadorDasCartas gerenciamentoDasCartas = new GerenciadorDasCartas();
            bool desistir = false;

            while (!desistir)
            {
                gerenciamentoDasCartas.Deal();

                char selection = ' ';
                while (!selection.Equals('S') && !selection.Equals('N'))
                {
                    Console.WriteLine("Jogar de novo?");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (selection.Equals('S'))
                        desistir = false;
                    else if (selection.Equals('N'))
                        desistir = true;
                    else
                        Console.WriteLine("Seleção inválida ¯\\(°_o)/¯");
                }
            }

            Console.ReadKey();
        }
    }
}
