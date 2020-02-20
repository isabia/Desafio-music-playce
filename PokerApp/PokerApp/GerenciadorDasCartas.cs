using System;
using System.Collections.Generic;
using static PokerApp.Carta;
using static PokerApp.Regras;

namespace PokerApp
{
    class GerenciadorDasCartas 
    {
 
            const int QUANTIDADE_DE_CARTAS_PARTIDA = 5;

            private Carta[] cartasNaMao1;
            private Carta[] cartasNaMao2;
 
            public GerenciadorDasCartas()
            {
                cartasNaMao1 = new Carta[QUANTIDADE_DE_CARTAS_PARTIDA];
                cartasNaMao2 = new Carta[QUANTIDADE_DE_CARTAS_PARTIDA];
            }

            public void Deal()
            {
                LeCartas();
                evaluateMaos();
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
                Console.WriteLine("A entrada não pode conter caracteres especiais além de ;");
            }

            List<string> temporario = new List<string>();
            temporario.AddRange(mao1.Split(';'));
            this.ValidacaoDeTamanho(temporario);
            int i = 0;
            temporario.ForEach((x) =>
            {
                var stringformatada = x.Trim().ToUpper();
                cartasNaMao1[i] = this.converteToCarta(stringformatada);
                i++;
            });

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("Jogador 2");
            Console.WriteLine("Digite suas cartas na forma: ValorNaipe; \n Exemplo: 4E;5O;10C;7O;5E - 4 Espadas; 5 ouros; 10 copas ...");
            Console.WriteLine("Aperte enter quando acabar de digitar");

            String mao2 = String.Empty;
            mao2 = Console.ReadLine();
            if (!this.ValidacaoEntrada(mao2))
            {
                Console.WriteLine("A entrada não pode conter caracteres especiais além de ;");
            }

            List<string> temporario2 = new List<string>();
            temporario2.AddRange(mao2.Split(';'));
            this.ValidacaoDeTamanho(temporario2);
         
            int j = 0;
            temporario2.ForEach((x) =>
            {
                var stringformatada = x.Trim().ToUpper();
                cartasNaMao2[j] = this.converteToCarta(stringformatada);
                j++;
            }
            );
        }

        public void ValidacaoDeTamanho(List<String> lista)
        {
            if (lista.Count < 5 || lista.Count > 5)
            {
                Console.WriteLine("A entrada não pode conter mais de 5 cartas");
            }
        }
        public Carta converteToCarta(String stringformatada)
        {
            string valorString = String.Empty;
            string naipeString = String.Empty;
            int valor = 0;

            if(stringformatada.Length == 2)
            {
                valorString = stringformatada.Remove(1);
                naipeString = stringformatada.Substring(1, 1);
                valor = int.Parse(valorString);
            }
            else if(stringformatada.Length == 3)
            { 
                valorString = stringformatada.Substring(0, 1);
                naipeString = stringformatada.Substring(1, 2);
                valor = int.Parse(valorString);
            }
            else if(stringformatada.Length > 3 || stringformatada.Length <= 0)
            {
                Console.WriteLine("Cartas inseridas não são válidas");
            }

            return new Carta { NaipeUsado = this.StringToEnum(naipeString), ValorUsado = (Valor)valor };
        }

        public Naipe StringToEnum(String naipe)
        {
            switch (naipe)
            {
                case "C":
                    return Naipe.C;
                    break;
                case "O":
                    return Naipe.O;
                    break;
                case "E":
                    return Naipe.E;
                    break;
                case "P":
                    return Naipe.P;
                default:
                    return Naipe.C;
                    break;
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
