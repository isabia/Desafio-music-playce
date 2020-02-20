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
            try
            {
                if (lista.Count < 5 || lista.Count > 5)
                {
                    throw new System.ArgumentException("Cartas inseridas são inválidas");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Carta converteToCarta(String stringformatada)
        {
            string valorString = String.Empty;
            string naipeString = String.Empty;
            Carta carta = new Carta();
            int valor = 0;

            try
            {
                if (stringformatada.Length == 2)
                {
                    valorString = stringformatada.Remove(1);
                    naipeString = stringformatada.Substring(1, 1);
                    valor = int.Parse(valorString);
                }
                else if (stringformatada.Length == 3)
                {
                    valorString = stringformatada.Substring(0, 2);
                    naipeString = stringformatada.Substring(2, 1);
                    valor = int.Parse(valorString);
                }
                else if (stringformatada.Length > 3 || stringformatada.Length <= 0)
                {
                    throw new System.ArgumentException("Carta inserida é inválida: " + stringformatada);
                }

                carta = new Carta { NaipeUsado = this.StringToEnum(naipeString), ValorUsado = (Valor)valor };
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException formatException)
            {
                formatException = new FormatException("Formato não aceito");
                Console.WriteLine(formatException.Message);
            }

            return carta;
        }

        public Naipe StringToEnum(String naipe)
        {
            try
            {
                switch (naipe)
                {
                    case "C":
                        return Naipe.C;
                    case "O":
                        return Naipe.O;
                    case "E":
                        return Naipe.E;
                    case "P":
                        return Naipe.P;
                    default:
                        throw new System.ArgumentException("Naipe inserido é inválido: " + naipe);
                        
                }
            }
            catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            
            return Naipe.C;
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
            AvaliadorDaMao mao1Avaliador = new AvaliadorDaMao(cartasNaMao1);
            AvaliadorDaMao mao2Avaliador = new AvaliadorDaMao(cartasNaMao2);

            Mao mao1 = mao1Avaliador.AvalieMao();
            Mao mao2 = mao2Avaliador.AvalieMao();

                Console.WriteLine("\n\n\n\n\nJogador 1: " + mao1);
                Console.WriteLine("\nJogador 2: " + mao2);

            if (mao1 > mao2)
            {
                Console.WriteLine("Jogador 1 venceu! ┏(;))┛");
            }
            else if (mao1 < mao2)
            {
                Console.WriteLine("Jogador 2 venceu! ┏( ͡;))┛");
            }
            else
            {

                if (mao1Avaliador.ValoresDaMao.Total > mao2Avaliador.ValoresDaMao.Total)
                    Console.WriteLine("Jogador 1 venceu! ┏( ͡;))┛");
                else if (mao1Avaliador.ValoresDaMao.Total < mao2Avaliador.ValoresDaMao.Total)
                    Console.WriteLine("Jogador 2 venceu! ┏( ͡;) )┛");
                else if (mao1Avaliador.ValoresDaMao.MaiorCarta > mao2Avaliador.ValoresDaMao.MaiorCarta)
                    Console.WriteLine("Jogador 1 venceu! ┏( ͡;))┛");
                else if (mao1Avaliador.ValoresDaMao.MaiorCarta < mao2Avaliador.ValoresDaMao.MaiorCarta)
                    Console.WriteLine("Jogador 2 venceu! ┏( ͡;))┛");
                else
                    Console.WriteLine("Ninguém ganhou");
            }
        }

    }
}
