

using System;

namespace PokerApp
{
    class Baralho : Carta
    {
        
            const int QUANTIDADE_DE_CARTAS = 52; 
            private Carta[] _baralho; 

            public Baralho() => _baralho = new Carta[QUANTIDADE_DE_CARTAS];
            
            public Carta[] getBaralho { get { return _baralho; } } 

          
            public void setBaralho()
            {
                int i = 0;
                foreach (Naipe n in Enum.GetValues(typeof(Naipe)))
                {
                    foreach (Valor v in Enum.GetValues(typeof(Valor)))
                    {
                        _baralho[i] = new Carta { NaipeUsado = n, ValorUsado = v };
                        i++;
                    }
                }

            }

           
    }
    
}
