namespace PokerApp
{
    class Regras
    {
        public enum Mao
        {
            Nothing,
            OnePair,
            TwoPairs,
            ThreeKind,
            Straight,
            Flush,
            FullHouse,
            FourKind
        }

        public struct MaoValor
        {
            public int Total { get; set; }
            public int MaiorCarta { get; set; }
        }

            public class AvaliadorDaMao : Carta
            {
                private int somaDeCopas;
                private int somaDeOuros;
                private int somaDePaus;
                private int somaDeEspada;
                private Carta[] cartas;
                private MaoValor valorDaMao;

                public AvaliadorDaMao(Carta[] maoRecebida)
                {
                    somaDeCopas = 0;
                    somaDeOuros = 0;
                    somaDePaus = 0;
                    somaDeEspada = 0;
                    cartas = new Carta[5];
                    cartas = maoRecebida;
                    valorDaMao = new MaoValor();
                }

                public MaoValor ValoresDaMao
                {
                    get { return valorDaMao; }
                    set { valorDaMao = value; }
                }

                public Carta[] Cartas
                {
                    get { return cartas; }
                    set
                    {
                        cartas[0] = value[0];
                        cartas[1] = value[1];
                        cartas[2] = value[2];
                        cartas[3] = value[3];
                        cartas[4] = value[4];
                    }
                }

                public Mao AvalieMao()
                {
                   
                    getNumeroDeNaipes();
                    if (FourOfKind())
                        return Mao.FourKind;
                    else if (FullHouse())
                        return Mao.FullHouse;
                    else if (Flush())
                        return Mao.Flush;
                    else if (Straight())
                        return Mao.Straight;
                    else if (ThreeOfKind())
                        return Mao.ThreeKind;
                    else if (TwoPairs())
                        return Mao.TwoPairs;
                    else if (OnePair())
                        return Mao.OnePair;

                    valorDaMao.MaiorCarta = (int)cartas[4].ValorUsado;
                    return Mao.Nothing;
                }

                private void getNumeroDeNaipes()
                {
                    foreach (var element in cartas)
                    {
                        if (element.NaipeUsado == Carta.Naipe.C)
                            somaDeCopas++;
                        else if (element.NaipeUsado == Carta.Naipe.O)
                            somaDeOuros++;
                        else if (element.NaipeUsado == Carta.Naipe.P)
                            somaDePaus++;
                        else if (element.NaipeUsado == Carta.Naipe.E)
                            somaDeEspada++;
                    }
                }

                private bool FourOfKind()
                {
                    
                    if (cartas[0].ValorUsado == cartas[1].ValorUsado && cartas[0].ValorUsado == cartas[2].ValorUsado && cartas[0].ValorUsado == cartas[3].ValorUsado)
                    {
                        valorDaMao.Total = (int)cartas[1].ValorUsado * 4;
                        valorDaMao.MaiorCarta = (int)cartas[4].ValorUsado;
                        return true;
                    }
                    else if (cartas[1].ValorUsado == cartas[2].ValorUsado && cartas[1].ValorUsado == cartas[3].ValorUsado && cartas[1].ValorUsado == cartas[4].ValorUsado)
                    {
                        valorDaMao.Total = (int)cartas[1].ValorUsado * 4;
                        valorDaMao.MaiorCarta = (int)cartas[0].ValorUsado;
                        return true;
                    }

                    return false;
                }

                private bool FullHouse()
                {
                    
                    if ((cartas[0].ValorUsado == cartas[1].ValorUsado && cartas[0].ValorUsado == cartas[2].ValorUsado && cartas[3].ValorUsado == cartas[4].ValorUsado) ||
                        (cartas[0].ValorUsado == cartas[1].ValorUsado && cartas[2].ValorUsado == cartas[3].ValorUsado && cartas[2].ValorUsado == cartas[4].ValorUsado))
                    {
                        valorDaMao.Total = (int)(cartas[0].ValorUsado) + (int)(cartas[1].ValorUsado) + (int)(cartas[2].ValorUsado) +
                            (int)(cartas[3].ValorUsado) + (int)(cartas[4].ValorUsado);
                        return true;
                    }

                    return false;
                }

                private bool Flush()
                {
                    
                    if (somaDeCopas == 5 || somaDeOuros == 5 || somaDePaus == 5 || somaDeEspada == 5)
                    {
                        
                        valorDaMao.Total = (int)cartas[4].ValorUsado;
                        return true;
                    }

                    return false;
                }

                private bool Straight()
                {
                   
                    if (cartas[0].ValorUsado + 1 == cartas[1].ValorUsado &&
                        cartas[1].ValorUsado + 1 == cartas[2].ValorUsado &&
                        cartas[2].ValorUsado + 1 == cartas[3].ValorUsado &&
                        cartas[3].ValorUsado + 1 == cartas[4].ValorUsado)
                    {
                        
                        valorDaMao.Total = (int)cartas[4].ValorUsado;
                        return true;
                    }

                    return false;
                }

                private bool ThreeOfKind()
                {
                    
                    if ((cartas[0].ValorUsado == cartas[1].ValorUsado && cartas[0].ValorUsado == cartas[2].ValorUsado) ||
                    (cartas[1].ValorUsado == cartas[2].ValorUsado && cartas[1].ValorUsado == cartas[3].ValorUsado))
                    {
                        valorDaMao.Total = (int)cartas[2].ValorUsado * 3;
                        valorDaMao.MaiorCarta = (int)cartas[4].ValorUsado;
                        return true;
                    }
                    else if (cartas[2].ValorUsado == cartas[3].ValorUsado && cartas[2].ValorUsado == cartas[4].ValorUsado)
                    {
                        valorDaMao.Total = (int)cartas[2].ValorUsado * 3;
                        valorDaMao.MaiorCarta = (int)cartas[1].ValorUsado;
                        return true;
                    }
                    return false;
                }

                private bool TwoPairs()
                {
                   
                    if (cartas[0].ValorUsado == cartas[1].ValorUsado && cartas[2].ValorUsado == cartas[3].ValorUsado)
                    {
                        valorDaMao.Total = ((int)cartas[1].ValorUsado * 2) + ((int)cartas[3].ValorUsado * 2);
                        valorDaMao.MaiorCarta = (int)cartas[4].ValorUsado;
                        return true;
                    }
                    else if (cartas[0].ValorUsado == cartas[1].ValorUsado && cartas[3].ValorUsado == cartas[4].ValorUsado)
                    {
                        valorDaMao.Total = ((int)cartas[1].ValorUsado * 2) + ((int)cartas[3].ValorUsado * 2);
                        valorDaMao.MaiorCarta = (int)cartas[2].ValorUsado;
                        return true;
                    }
                    else if (cartas[1].ValorUsado == cartas[2].ValorUsado && cartas[3].ValorUsado == cartas[4].ValorUsado)
                    {
                        valorDaMao.Total = ((int)cartas[1].ValorUsado * 2) + ((int)cartas[3].ValorUsado * 2);
                        valorDaMao.MaiorCarta = (int)cartas[0].ValorUsado;
                        return true;
                    }
                    return false;
                }

                private bool OnePair()
                {
                    
                    if (cartas[0].ValorUsado == cartas[1].ValorUsado)
                    {
                        valorDaMao.Total = (int)cartas[0].ValorUsado * 2;
                        valorDaMao.MaiorCarta = (int)cartas[4].ValorUsado;
                        return true;
                    }
                    else if (cartas[1].ValorUsado == cartas[2].ValorUsado)
                    {
                        valorDaMao.Total = (int)cartas[1].ValorUsado * 2;
                        valorDaMao.MaiorCarta = (int)cartas[4].ValorUsado;
                        return true;
                    }
                    else if (cartas[2].ValorUsado == cartas[3].ValorUsado)
                    {
                        valorDaMao.Total = (int)cartas[2].ValorUsado * 2;
                        valorDaMao.MaiorCarta = (int)cartas[4].ValorUsado;
                        return true;
                    }
                    else if (cartas[3].ValorUsado == cartas[4].ValorUsado)
                    {
                        valorDaMao.Total = (int)cartas[3].ValorUsado * 2;
                        valorDaMao.MaiorCarta = (int)cartas[2].ValorUsado;
                        return true;
                    }

                    return false;
                }

            }
    }
}
