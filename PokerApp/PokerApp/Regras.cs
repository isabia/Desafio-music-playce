namespace PokerApp
{
    class GerenciamentoDasCartas
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

        class MaoAvaliador : Carta
        {
            private int _somaDeCopas;
            private int _somaDeOuros;
            private int _somaDePaus;
            private int _somaDeEspadas;
            private Carta[] _cartas;
            private MaoValor _maoValor;

            public MaoAvaliador(Carta[] maoRecebida)
            {
                _somaDeCopas = 0;
                _somaDeOuros = 0;
                _somaDePaus = 0;
                _somaDeEspadas = 0;
                Cartas = new Carta[5];
                Cartas = maoRecebida;
                _maoValor = new MaoValor();
            }

            public MaoValor MaoValores
            {
                get { return _maoValor; }
                set { _maoValor = value; }
            }

            public Carta[] Cartas
            {
                get { return Cartas; }
                set
                {
                    Cartas[0] = value[0];
                    Cartas[1] = value[1];
                    Cartas[2] = value[2];
                    Cartas[3] = value[3];
                    Cartas[4] = value[4];
                }
            }

            public Mao EvaluateMao()
            {
                getValorDoNaipe();
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

                _maoValor.MaiorCarta = (int)Cartas[4].ValorUsado;
                return Mao.Nothing;
            }

            private void getValorDoNaipe()
            {
                foreach (var element in Cartas)
                {
                    if (element.NaipeUsado == Carta.Naipe.C)
                        _somaDeCopas++;
                    else if (element.NaipeUsado == Carta.Naipe.O)
                        _somaDeOuros++;
                    else if (element.NaipeUsado == Carta.Naipe.P)
                        _somaDePaus++;
                    else if (element.NaipeUsado == Carta.Naipe.E)
                        _somaDeEspadas++;
                }
            }

            private bool FourOfKind()
            {
          
              
                if (Cartas[0].ValorUsado == Cartas[1].ValorUsado && Cartas[0].ValorUsado == Cartas[2].ValorUsado && Cartas[0].ValorUsado == Cartas[3].ValorUsado)
                {
                    _maoValor.Total = (int)Cartas[1].ValorUsado * 4;
                    _maoValor.MaiorCarta = (int)Cartas[4].ValorUsado;
                    return true;
                }
                else if (Cartas[1].ValorUsado == Cartas[2].ValorUsado && Cartas[1].ValorUsado == Cartas[3].ValorUsado && Cartas[1].ValorUsado == Cartas[4].ValorUsado)
                {
                    _maoValor.Total = (int)Cartas[1].ValorUsado * 4;
                    _maoValor.MaiorCarta = (int)Cartas[0].ValorUsado;
                    return true;
                }

                return false;
            }

            private bool FullHouse()
            {
               
                if ((Cartas[0].ValorUsado == Cartas[1].ValorUsado && Cartas[0].ValorUsado == Cartas[2].ValorUsado && Cartas[3].ValorUsado == Cartas[4].ValorUsado) ||
                    (Cartas[0].ValorUsado == Cartas[1].ValorUsado && Cartas[2].ValorUsado == Cartas[3].ValorUsado && Cartas[2].ValorUsado == Cartas[4].ValorUsado))
                {
                    _maoValor.Total = (int)(Cartas[0].ValorUsado) + (int)(Cartas[1].ValorUsado) + (int)(Cartas[2].ValorUsado) +
                        (int)(Cartas[3].ValorUsado) + (int)(Cartas[4].ValorUsado);
                    return true;
                }

                return false;
            }

            private bool Flush()
            {
                
                if (_somaDeCopas == 5 || _somaDeOuros == 5 || _somaDePaus == 5 || _somaDeEspadas == 5)
                {
                    _maoValor.Total = (int)Cartas[4].ValorUsado;
                    return true;
                }

                return false;
            }

            private bool Straight()
            {
                if (Cartas[0].ValorUsado + 1 == Cartas[1].ValorUsado &&
                    Cartas[1].ValorUsado + 1 == Cartas[2].ValorUsado &&
                    Cartas[2].ValorUsado + 1 == Cartas[3].ValorUsado &&
                    Cartas[3].ValorUsado + 1 == Cartas[4].ValorUsado)
                {
                    _maoValor.Total = (int)Cartas[4].ValorUsado;
                    return true;
                }

                return false;
            }

            private bool ThreeOfKind()
            {
              
                if ((Cartas[0].ValorUsado == Cartas[1].ValorUsado && Cartas[0].ValorUsado == Cartas[2].ValorUsado) ||
                (Cartas[1].ValorUsado == Cartas[2].ValorUsado && Cartas[1].ValorUsado == Cartas[3].ValorUsado))
                {
                    _maoValor.Total = (int)Cartas[2].ValorUsado * 3;
                    _maoValor.MaiorCarta = (int)Cartas[4].ValorUsado;
                    return true;
                }
                else if (Cartas[2].ValorUsado == Cartas[3].ValorUsado && Cartas[2].ValorUsado == Cartas[4].ValorUsado)
                {
                    _maoValor.Total = (int)Cartas[2].ValorUsado * 3;
                    _maoValor.MaiorCarta = (int)Cartas[1].ValorUsado;
                    return true;
                }
                return false;
            }

            private bool TwoPairs()
            {
                
                if (Cartas[0].ValorUsado == Cartas[1].ValorUsado && Cartas[2].ValorUsado == Cartas[3].ValorUsado)
                {
                    _maoValor.Total = ((int)Cartas[1].ValorUsado * 2) + ((int)Cartas[3].ValorUsado * 2);
                    _maoValor.MaiorCarta = (int)Cartas[4].ValorUsado;
                    return true;
                }
                else if (Cartas[0].ValorUsado == Cartas[1].ValorUsado && Cartas[3].ValorUsado == Cartas[4].ValorUsado)
                {
                    _maoValor.Total = ((int)Cartas[1].ValorUsado * 2) + ((int)Cartas[3].ValorUsado * 2);
                    _maoValor.MaiorCarta = (int)Cartas[2].ValorUsado;
                    return true;
                }
                else if (Cartas[1].ValorUsado == Cartas[2].ValorUsado && Cartas[3].ValorUsado == Cartas[4].ValorUsado)
                {
                    _maoValor.Total = ((int)Cartas[1].ValorUsado * 2) + ((int)Cartas[3].ValorUsado * 2);
                    _maoValor.MaiorCarta = (int)Cartas[0].ValorUsado;
                    return true;
                }
                return false;
            }

            private bool OnePair()
            {

                if (Cartas[0].ValorUsado == Cartas[1].ValorUsado)
                {
                    _maoValor.Total = (int)Cartas[0].ValorUsado * 2;
                    _maoValor.MaiorCarta = (int)Cartas[4].ValorUsado;
                    return true;
                }
                else if (Cartas[1].ValorUsado == Cartas[2].ValorUsado)
                {
                    _maoValor.Total = (int)Cartas[1].ValorUsado * 2;
                    _maoValor.MaiorCarta = (int)Cartas[4].ValorUsado;
                    return true;
                }
                else if (Cartas[2].ValorUsado == Cartas[3].ValorUsado)
                {
                    _maoValor.Total = (int)Cartas[2].ValorUsado * 2;
                    _maoValor.MaiorCarta = (int)Cartas[4].ValorUsado;
                    return true;
                }
                else if (Cartas[3].ValorUsado == Cartas[4].ValorUsado)
                {
                    _maoValor.Total = (int)Cartas[3].ValorUsado * 2;
                    _maoValor.MaiorCarta = (int)Cartas[2].ValorUsado;
                    return true;
                }

                return false;
        }   }
    }
}
