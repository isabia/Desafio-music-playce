﻿using System;
using static PokerApp.Regras;

namespace PokerApp
{
    class GerenciadorDasCartas : Baralho
    {
 
            const int QUANTIDADE_DE_CARTAS_PARTIDA = 5;

            private Carta[] Mao1;
            private Carta[] Mao2;


            public GerenciadorDasCartas()
            {
                Mao1 = new Carta[QUANTIDADE_DE_CARTAS_PARTIDA];
                Mao2 = new Carta[QUANTIDADE_DE_CARTAS_PARTIDA];
            }

            public void Deal()
            {
                getMao();
                LeCartas();
                evaluateMaos();
            }

            public void getMao()
            {
                for (int i = 0; i < 5; i++)
                    Mao1[i] = getBaralho[i];

                for (int i = 5; i < 10; i++)
                    Mao2[i - 5] = getBaralho[i];
            }

            public void LeCartas()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Jogador 1");
                Console.WriteLine("Digite suas cartas na forma: ValorNaipe; \n Exemplo: 4E;5O;10C;7O;5E - 4 Espadas; 5 ouros; 10 copas ...");
                Console.WriteLine("Aperte enter quando acabar de digitar");

                String mao1 = String.Empty;
                mao1 = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                
                Console.WriteLine("Jogador 2");
                Console.WriteLine("Digite suas cartas na forma: ValorNaipe; \n Exemplo: 4E;5O;10C;7O;5E - 4 Espadas; 5 ouros; 10 copas ...");
                Console.WriteLine("Aperte enter quando acabar de digitar");

                String mao2 = String.Empty;
                mao1 = Console.ReadLine();
            }

            public void evaluateMaos()
            {
            MaoAvaliador mao1Avaliador = new MaoAvaliador(Mao1);
            MaoAvaliador mao2Avaliador = new MaoAvaliador(Mao2);

            Mao mao1 = mao1Avaliador.EvaluateMao();
            Mao mao2 = mao2Avaliador.EvaluateMao();

                Console.WriteLine("\n\n\n\n\nJogador 1: " + Mao1);
                Console.WriteLine("\nJogador 2: " + Mao2);

            if (mao1 > mao2)
            {
                Console.WriteLine("Jogador 1 venceu! ┏( ͡❛ ͜ʖ ͡❛)┛");
            }
            else if (mao1 < mao2)
            {
                Console.WriteLine("Jogador 2 venceu! ┏( ͡❛ ͜ʖ ͡❛)┛");
            }
            else
            {

                if (mao1Avaliador.MaoValores.Total > mao2Avaliador.MaoValores.Total)
                    Console.WriteLine("Jogador 1 venceu! ┏( ͡❛ ͜ʖ ͡❛)┛");
                else if (mao1Avaliador.MaoValores.Total < mao2Avaliador.MaoValores.Total)
                    Console.WriteLine("Jogador 2 venceu! ┏( ͡❛ ͜ʖ ͡❛)┛");
                else if (mao1Avaliador.MaoValores.MaiorCarta > mao2Avaliador.MaoValores.MaiorCarta)
                    Console.WriteLine("Jogador 1 venceu! ┏( ͡❛ ͜ʖ ͡❛)┛");
                else if (mao1Avaliador.MaoValores.MaiorCarta < mao2Avaliador.MaoValores.MaiorCarta)
                    Console.WriteLine("Jogador 2 venceu! ┏( ͡❛ ͜ʖ ͡❛)┛");
                else
                    Console.WriteLine("Ninguém ganhou");
            }
        }

    }
}
