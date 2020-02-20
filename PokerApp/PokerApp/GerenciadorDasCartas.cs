using System;
using System.Collections.Generic;
using static PokerApp.Regras;

namespace PokerApp
{
    class GerenciadorDasCartas : Baralho
    {
 
            const int QUANTIDADE_DE_CARTAS_PARTIDA = 5;

            private Carta[] cartasNaMao1;
            private Carta[] cartasNaMao2;
            Valor enumValor;
            Naipe enumNaipe;


            public GerenciadorDasCartas()
            {
                cartasNaMao1 = new Carta[QUANTIDADE_DE_CARTAS_PARTIDA];
                cartasNaMao2 = new Carta[QUANTIDADE_DE_CARTAS_PARTIDA];
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
                cartasNaMao1[i] = getBaralho[i];

                for (int i = 5; i < 10; i++)
                cartasNaMao2[i - 5] = getBaralho[i];
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
            if (!this.ValidacaoEntrada(mao1))
            {
                Console.WriteLine("A entrada não pode conter caracteres especiais");
            }
                List<string> temporario = new List<string>();
                temporario.AddRange(mao1.Split(';'));
                if(mao1.Length <5 || mao1.Length > 5)
                {
                    Console.WriteLine("A entrada não pode conter mais de 5 cartas");
                }
                temporario.ForEach((x) => {
                var stringformatada = x.Trim().ToUpper();
                List<Carta> carta = new List<Carta>();
                if (stringformatada.Length == 2) {
                        var valorString = stringformatada.Substring(0, 1);
                        var naipeString = stringformatada.Substring(1, 2);
                        int.Parse(valorString);
                        //Enum.GetValues(Valor);
                        //carta.Add(Valor);
                        
                }                              
                });

                Console.ForegroundColor = ConsoleColor.DarkRed;
                
                Console.WriteLine("Jogador 2");
                Console.WriteLine("Digite suas cartas na forma: ValorNaipe; \n Exemplo: 4E;5O;10C;7O;5E - 4 Espadas; 5 ouros; 10 copas ...");
                Console.WriteLine("Aperte enter quando acabar de digitar");

                String mao2 = String.Empty;
                mao1 = Console.ReadLine();
                if (!this.ValidacaoEntrada(mao2))
                {
                    Console.WriteLine("A entrada não pode conter caracteres especiais");
                }
                 List<string> temporario2 = new List<string>();
                temporario2.AddRange(mao2.Split(';'));
                if (mao2.Length < 5 || mao2.Length > 5)
                {
                    Console.WriteLine("A entrada não pode conter mais de 5 cartas");
                }
            }

        public bool ValidacaoEntrada(String input)
        {
            if (input.Contains('.'))  return false; 
            if (input.Contains(','))  return false; 
            if (input.Contains(':'))  return false; 
            return true;
        }

        public void evaluateMaos()
        {
            MaoAvaliador mao1Avaliador = new MaoAvaliador(cartasNaMao1);
            MaoAvaliador mao2Avaliador = new MaoAvaliador(cartasNaMao2);

            Mao mao1 = mao1Avaliador.EvaluateMao();
            Mao mao2 = mao2Avaliador.EvaluateMao();

                Console.WriteLine("\n\n\n\n\nJogador 1: " + mao1);
                Console.WriteLine("\nJogador 2: " + mao2);

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
